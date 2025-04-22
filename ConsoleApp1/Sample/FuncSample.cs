using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class Program
    {
        public delegate bool WriteMethod();
        static void FuncSamples()
        {
            FuncSample1();
            FuncSample2();
        }

        static void FuncSample1()
        {
            //  Func
            //  매개 변수가 없는 메서드를 캡슐화하고 매개 변수로 지정된 형식의 값을 반환

            LazyValue<int> lazyOne = new LazyValue<int>(() => ExpensiveOne());
            LazyValue<long> lazyTwo = new LazyValue<long>(() => ExpensiveTwo("apple"));

            Console.WriteLine("LazyValue objects have been created.");

            // Get the values of the LazyValue objects.
            Console.WriteLine(lazyOne.Value);
            Console.WriteLine(lazyTwo.Value);
        }

        static void FuncSample2()
        {
            OutputTarget output = new OutputTarget();

            WriteMethod methodCall1 = output.SendToFile;

            Func<bool> methodCall2 = output.SendToFile;

            Func<bool> methodCall3 = delegate () { return output.SendToFile(); };

            Func<bool> methodCall4 = () => output.SendToFile();

            if (methodCall1())
                Console.WriteLine("Success!");
            else
                Console.WriteLine("File write operation failed.");
        }

        static int ExpensiveOne()
        {
            Console.WriteLine("\nExpensiveOne() is executing.");
            return 1;
        }

        static long ExpensiveTwo(string input)
        {
            Console.WriteLine("\nExpensiveTwo() is executing.");
            return (long)input.Length;
        }
    }

    class LazyValue<T> where T : struct
    {
        private Nullable<T> val;
        private Func<T> getValue;

        public LazyValue(Func<T> func)
        {
            val = null;
            getValue = func;
        }

        public T Value
        {
            get
            {
                if (val == null)
                    val = getValue();
                return (T)val;
            }
        }
    }

    class OutputTarget
    {
        public bool SendToFile()
        {
            try
            {
                string fn = Path.GetTempFileName();
                StreamWriter sw = new StreamWriter(fn);
                sw.WriteLine("Hello, World");
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
