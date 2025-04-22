using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp1
{
    public partial class Program
    {
        static void PredicateSamples()
        {
            PredicateSample1();
            PredicateSample2();
            PredicateSample3();
        }

        static void PredicateSample1()
        {
            //  조건 집합을 정의하고 지정된 개체가 이러한 조건을 충족하는지 여부를 확인하는 메서드를 나타냄
            Predicate<object> isNumber = obj => obj is int;

            Console.WriteLine(isNumber(123));
            Console.WriteLine(isNumber("hello"));

            List<object> items = new List<object> { 1, "hello", 3.14, 42, new Tuple<int, int>(1, 3) };

            Predicate<object> isInt = obj => obj is int;

            object found = items.Find(isInt);
            Console.WriteLine(found);

            //Predicate<object> myPredicate = delegate (object obj)
            //{
            //    return 조건식;
            //};

            //Predicate<object> myPredicate = obj => 조건식;
        }

        static void PredicateSample2()
        {
            // Create an array of Point structures.
            Point[] points = { new Point(100, 200),
                         new Point(150, 250), new Point(250, 375),
                         new Point(275, 395), new Point(295, 450) };

            //Predicate<Point> predicate = FindPoints;
            //bool FindPoints(Point obj)
            //{
            //    return obj.X * obj.Y > 100000;
            //}

            Predicate<Point> predicate = obj => obj.X * obj.Y > 100000;

            //Point first = Array.Find(points, predicate);
            Point first = Array.Find(points, point => point.X * point.Y > 100000);
        }

        static void PredicateSample3()
        {
            Random rnd = new Random();
            List<HockeyTeam> teams = new List<HockeyTeam>();
            teams.AddRange(
                new HockeyTeam[]
                {
                    new HockeyTeam("Detroit Red Wings", 1926),
                    new HockeyTeam("Chicago Blackhawks", 1926),
                    new HockeyTeam("San Jose Sharks", 1991),
                    new HockeyTeam("Montreal Canadiens", 1909),
                    new HockeyTeam("St. Louis Blues", 1967)
                }
            );

            int[] years = { 1920, 1930, 1980, 2000 };
            int foundedBeforeYear = years[rnd.Next(0, years.Length)];
            foreach (var team in teams.FindAll(x => x.Founded <= foundedBeforeYear))
                Console.WriteLine();
        }
    }

    public class HockeyTeam
    {
        private string _name;
        private int _founded;

        public HockeyTeam(string name, int year)
        {
            _name = name;
            _founded = year;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Founded
        {
            get { return _founded; }
        }
    }
}
}
