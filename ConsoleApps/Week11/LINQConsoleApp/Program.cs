using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LINQ

            /*
             * Overview of LINQ
             *
             * LINQ (Language Integrated Query)
             *
             * .Net-in support etdiyi dillerde db query emeliyyatlarini development environment-de
             * gerceklesdire bilmeyimizi temin eden Microsoft .NET Framework-un bir parcasidir.
             *
             * Microsoft'un Visual Studio 2008 ve .NET Framework 3.5 ile beraber bu texnologiyani istifadeye vermisdir.
             *
             *
             * LINQ ile birlikde SQL(Structured Query Language) Server db-lerinde, xml tipinde olan file-larda ADO.Net Dataset
             * lerinde ve ya ram-da saxlanan collection tipindeki datalar ucun daha asan sekilde query-ler yaza bilerik.
             *
             * LINQ to Objects
             * yaddasdaki datalar nezerde tutulur
             *
             * LINQ to SQL
             * Sql Server db-deki cedveller ucun query
             *
             * LINQ to DataSet
             * Ado.Net Dataset-ler
             *
             * LINQ to xml
             *
             *
             * LINQ to Entity
             * ADO.NET Entity Framework 
             *
             * LINQ query-leri query syntax ve method-based sytax olaraq yazila biliner, lakin daha oxunaqli formasi query syntax
             * olaraq gorulur. Ikisi arasinda Microsoftun resmi sehifesinde qeyd olunana gore performans ferqi yoxdur ve biri ile
             * yazilan query digeri ilede eyni sekilde yazila biler sadece Count ve Max  hazir olaraq querylerde method olaraq istifade edilir.
             *
             * LINQ query ifadelerimiz compile zamani ya expression tree ya da delagete cevrilmekdedir, IEnumerable<T> query-ler delegate-lere
             *
             * IQueryable<T> query-ler expression tree lere cevrilmekdedir.
             *
             * https://www.tutorialsteacher.com/linq/linq-tutorials
             */

            #endregion

            #region examples

            #region FakeData

            var customers = DataSource.GetCustomers();




            //Console.WriteLine(customers.Count);

            /*
             * Task 1 Adi 'A' ile baslayan customerlerin sayini tapib cap edin
             */

            #region task 1

            int count = 0;


            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Name.StartsWith('A'))
                {
                    count++;
                }
            }

            //Console.WriteLine("Adi 'A' ile baslayan musterilerin sayi: \t{0}", count);

            #region v2

            int count1 = customers.Where(t => t.Name.StartsWith('A')).Count();
            // or
            int count2 = customers.Count(t => t.Name.StartsWith('A'));

            //Console.WriteLine("where:{0}", count1);
            //Console.WriteLine("count:{0}", count1);
            #endregion
            #endregion

            #region fakeData with linq

            // linq query syntax

            var count4 = (from customer in customers
                          where customer.Name.StartsWith('A')
                          select customer).Count();

            // method based syntax
            var count5 = customers.Count(i => i.Name.StartsWith('A'));

            #region examples

            #region olke adlari A ile baslayanlarin siyahisi

            var customers1 = customers.Where(i => i.Country.StartsWith('A'));

            #endregion

            #region adinin icerisinde 'a' herfi ve olke icerisinde 'a' herfi olan musteriler

            var customers2 = customers.Where(i => i.Name.Contains('a') && i.Country.Contains('a')).ToList();

            #endregion

            #region bithdate-i 1990-dan boyuk adinda 'a' olan musteriler

            var customer3 = from customer in customers
                            where customer.Birthdate.Year > 1990 && customer.Name.Contains('a')
                            select customer;

            #endregion

            #region bithdate-i 1990-dan boyuk ve ya adinda 'a' olan musteriler

            var customer4 = from customer in customers
                            where customer.Birthdate.Year > 1990 || customer.Name.Contains('a')
                            select customer;

            #endregion

            #region orderby, thenBy 

            var orderedList = from customer in customers
                              where customer.Birthdate.Year > 1950
                              orderby customer.Birthdate.Year, customer.Name, customer.Surname // ilk ile gore siralayacaq
                              select new
                              {
                                  Name = customer.Name,
                                  Surname = customer.Surname,
                                  Year = customer.Birthdate.Year.ToString()
                              };
            Console.WriteLine("===================");
            //orderedList.ToList().ForEach(i => Console.WriteLine($"{i.Name} {i.Surname} {i.Year}"));

            Console.WriteLine("===================");
            var orderedList1 = customers
                .FindAll(i => i.Birthdate.Year < 1950)
                .OrderBy(i => i.Name) // ilk ada gore siralayacaq
                .ThenBy(i => i.Birthdate.Year)
                .Select(i => new { i.Name, i.Surname, i.Birthdate.Year });
            orderedList1.ToList().ForEach(i => Console.WriteLine($"{i.Name} {i.Surname} {i.Year}"));
            Console.WriteLine("===================");

            #endregion

            #endregion
            #endregion

            #endregion

            #region Using delegates in query operations
            /*
             * func 
             */
            Func<Customer, bool> funcDelegate = new Func<Customer, bool>(StartsWithA);

            var customers4 = customers.Where(funcDelegate);

            var customers5 = customers.Where(StartsWithA);

            var customers6 = customers.Where(new Func<Customer, bool>(StartsWithA));

            var customers7 = customers.Where(predicate: delegate (Customer c) { return c.Name.StartsWith('a'); });
            /*
             * predicate ile func arasindaki ferq predicate her zaman  bool tipi qaytarir
             */

            Predicate<Customer> predicate = new Predicate<Customer>(CheckBirthDateYear);

            var customers8 = customers.FindAll(CheckBirthDateYear);

            var customers9 = customers.FindAll(predicate);

            /*
             * action
             */
            Action<Customer> action = new Action<Customer>(Print);

            customers.ForEach(action);
            //
            //customers.ForEach(i =>
            //{
            //    Console.WriteLine($"{i.Name} {i.Surname}");
            //});

            customers.ForEach(new Action<Customer>(Print));
            #endregion

            #region 1 query syntax into

            //// Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            //// linq
            //// Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;



            List<int> sortedScoreList = new List<int>();
            //foreach (var score in scores)
            //{
            //    if (score > 80)
            //    {
            //        sortedScoreList.Add(score);
            //    }
            //}


            //// Execute the query.
            //foreach (int i in scoreQuery)
            //{
            //    Console.Write(i + " ");
            //}

            #endregion

            #region 2 query sytanx and method-based syntax
            /*
             * Any query that can be expressed by using query syntax can also be expressed by using method syntax.
             * However, in most cases query syntax is more 'readable' and concise.
             *
             * As a rule when you write LINQ queries, we recommend that you use query syntax whenever possible and method syntax whenever necessary. 
             */
            string sentence = "the quick brown fox jumps over the lazy dog";
            //// Split the string into individual words to create a collection.  
            string[] words = sentence.Split(' ');

            // Using query expression syntax.  
            var query = from word in words
                        group word.ToUpper() by word.Length into gr
                        orderby gr.Key
                        select new { Length = gr.Key, Words = gr };

            //// Using method-based query syntax.  
            var query2 = words.
                GroupBy(w => w.Length, w => w.ToUpper()).
                Select(g => new { Length = g.Key, Words = g }).
                OrderBy(o => o.Length);

            foreach (var obj in query)
            {
                Console.WriteLine("Words of length {0}:", obj.Length);
                foreach (string word in obj.Words)
                    Console.WriteLine(word);
            }

            //// This code example produces the following output:  
            ////  
            //// Words of length 3:  
            //// THE  
            //// FOX  
            //// THE  
            //// DOG  
            //// Words of length 4:  
            //// OVER  
            //// LAZY  
            //// Words of length 5:  
            //// QUICK  
            //// BROWN  
            //// JUMPS

            //*
            // *
            // */
            int[] numbers = { 5, 10, 8, 3, 6, 12 };

            //Query syntax:
            IEnumerable<int> numQuery1 =
                from num in numbers
                where num % 2 == 0
                orderby num
                select num;

            //Method syntax:
            IEnumerable<int> numQuery2 = numbers.Where(num => num % 2 == 0).OrderBy(n => n);

            foreach (int i in numQuery1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(System.Environment.NewLine);
            foreach (int i in numQuery2)
            {
                Console.Write(i + " ");
            }

            // Keep the console open in debug mode.
            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            #endregion

            #endregion
        }

        #region Using delegates in query operations
        /// <summary>
        /// func
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        static bool StartsWithA(Customer customer)
        {
            return customer.Name.StartsWith('A');
        }
        /// <summary>
        /// predicate
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        static bool CheckBirthDateYear(Customer customer) => customer.Birthdate.Year > 1990;


        static void Print(Customer customer) => Console.WriteLine("{0} {1}", customer.Name, customer.Surname);

        #endregion
    }
}
