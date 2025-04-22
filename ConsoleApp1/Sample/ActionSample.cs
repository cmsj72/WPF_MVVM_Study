using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ConsoleApp1
{    
    public partial class Program
    {
        public delegate void ShowValue();

        static void ActionSamples()
        {
            ActionSample1();
        }

        static void ActionSample1()
        {
            //  Action
            //  매개 변수가 없으며 값을 반환하지 않는 메서드를 캡슐화

            Name testName = new Name("chan");
            ShowValue showMethod1 = testName.DisplayToWindow;
            showMethod1();

            Action showMethod2 = testName.DisplayToConsole;
            showMethod2();

            Action showMethod3 = () => testName.DisplayToWindow();
            showMethod3();
        }
    }   

    public class Name
    {
        private string instanceName;

        public Name(string name)
        {
            this.instanceName = name;
        }

        public void DisplayToConsole()
        {
            Console.WriteLine(this.instanceName);
        }

        public void DisplayToWindow()
        {
            MessageBox.Show(this.instanceName);
        }
    }
}
