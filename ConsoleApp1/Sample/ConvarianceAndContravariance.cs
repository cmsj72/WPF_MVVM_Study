using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class Program
    {
        static void ConvarAndContravarSamples()
        {
            ConvarAndContravarSample1();
        }

        static void ConvarAndContravarSample1()
        {
            //  공변성(Convariance)과 반공변성(Contravariance)
            //  원래 지정된 것보다 더 많이 파생되거나(더 구체적인)
            //  더 적게 파생된 형식(덜 구체적인)을 사용할 수 있는 능력을 지칭하는 용어
            //  제네릭 형식 매개 변수는 더욱 유연하게 제네릭 형식을 할당하고 사용할 수 있도록 공변성과 반공변성을 지원

            //  Base : 기본 클래스
            //  Derived : 파생 클래스

            //  Convariance(공변성)
            //  원래 지정된 것보다 더 많이 파생된 형식을 사용 가능
            //  IEnumerable<Derived>의 인스턴스를 IEnumerable<Base> 형식의 변수에 할당 가능

            //  Contravariance(반공변성)
            //  원래 지정된 것보다 더 제네릭한(덜 파생적인) 형식을 사용 가능
            //  Action<Base>의 인스턴스를 Action<Derived> 형식의 변수에 할당 가능

            //  Invariance
            //  원래 지정된 형식만 사용할 수 있음을 의미.
            //  고정 제네릭 형식 매개 변수는 공변 및 반공변이 아님.
            //  List<base>의 인스턴스를 List<Derived> 형식의 변수에 할당 불가능, 그 반대로도 할당 불가능

            IProducer<string> stringProducer = new StringProducer();
            
            //  공변성: string -> object 가능
            IProducer<object> objectProducer = stringProducer;

            object result = objectProducer.Produce();
            Console.WriteLine(result);


            IConsumer<object> objectConsumer = new ObjectConsumer();

            //  반공변성 : object -> string 가능
            IConsumer<string> stringConumser = objectConsumer;

            stringConumser.Consume("Hi from string");

        }
    }

    #region [Convariance]

    public interface IProducer<out T>
    {
        T Produce();
    }

    public class StringProducer : IProducer<string>
    {
        public string Produce() => "Hello";
    }

    #endregion

    #region [Contravariance]

    public interface IConsumer<in T>
    {
        void Consume(T item);
    }

    public class ObjectConsumer : IConsumer<object>
    {
        public void Consume(object item)
        {
            Console.WriteLine($"Consumed: {item}");
        }
    }

    #endregion
}
