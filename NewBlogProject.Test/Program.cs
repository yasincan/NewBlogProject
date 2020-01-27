using System;
using System.Collections.Generic;

namespace NewBlogProject.Test
{
    class Program
    {
        static void Main()
        {
            // Person person = new Developer();

            // Console.WriteLine("Test");

            // Utilities utilities = new Utilities();
            // List<Test> people = utilities.BuildList<Test>(new Test(), new Test());

            // foreach (var item in people)
            // {
            //     Console.WriteLine(item.Price);
            // }
            // //var computerName=Dns.GetHostName();
            //// Console.WriteLine(Dns.GetHostByName(computerName).AddressList[2].ToString());

            // Test test = new Test();
            // Console.WriteLine(test.IsValid);

            // decimal? number= 121212.121215m;
            //Console.WriteLine(Decimal.Round(number,2));
            //Console.WriteLine(number.Value);
            //IEnumerable<string> vs = new string[] { "Yasin" ,"Deneme"};
            //Console.WriteLine(vs.FirstOrDefault(c=>c.Length>4));
            //foreach (var item in vs)
            //{
            //    Console.WriteLine(item);
            //}
            //List<string> CounterList = new List<string> { };
            //CounterList.Add("ABD");
            //CounterList.Add("Türkiye");
            //CounterList.Add("Türkiye");
            //CounterList.Add("Türkiye");
            //CounterList.Add("Türkiye");
            //CounterList.Add("Rusya");
            //CounterList.Add("Merih");

            //Console.Write("Arama cümlesini giriniz:");
            //var searchKey=Console.ReadLine().ToUpper();

            //var collection = CounterList.Where(x => x.ToUpper().Contains(searchKey)).ToList();

            //var result=CounterList.IndexOf(searchKey);

            //int j= 1;
            //foreach (var item in collection)
            //{
            //    Console.WriteLine($"{j++} {item}");
            //}

            //for (int i = 0; i < CounterList.Count; i++)
            //{
            //    Console.WriteLine(CounterList[i].ToUpper());
            //}


            Console.ReadKey();

        }
        class Utilities
        {
            internal List<Type> BuildList<Type>(params Type[] item)
            {
                return new List<Type>(item);
            }

        }

        class Test
        {
            public int ID { get; set; }
            public string TestName { get; set; }
            public decimal Price { get; set; }

            public bool IsValid =>
                !string.IsNullOrEmpty(TestName) &&
                Price != 0;
        }
    }
}
