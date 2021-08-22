using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Week8.GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Generic Collections
            /*
             * 
             *
             * Generic collection-lar(gc)
             * Non-Generic collection-lar(ngc)
             * Generic collection-lar(gc) System.Collections.Generic namespace-si altinda yerlesir.
             * NGC-de type safety yoxdur , elementleri object tipine boxing edirdiler,
             * GC-de ise type safety var ve buna gore de ngc-deki kimi boxing ve ya unboxing emeliyyatlarina
             * ehtiyyac qalmir, bu ozluyunde performans artisi demekdir.
             *
             *
             * *** Genericden once
             *
             * *** Generic collections
             *  GC                      NGC
             * Queue<T>               \ Queue
             * SortedDictionary<K,T>  \ SortedList
             * Stack<T>               \ Stack
             * List<T>                \ ArrayList
             * Dictionary<K,T>        \ Hashtable
             *
             *
             *                                                   |------------ Stack<T>
             *                                 IEnumerable<T> <--|
             *                                       ^           |------------ Stack<T>
             *                                       |
             *                                       |
             *                |------------->ICollection<T><-------------|
             *                |                      ^                   |
             *                |                      |                   |
             *                |                      |                   |
             *          HasSet<T>                    |               LinkedList<T>
             *                                       |
             *                                    IList<T>
             *                                       ^
             *                                       |
             *                              |------------------|
             *                              |                  |
             *                              |                  |
             *                              |                  |
             *                              |                  |
             *                           List<T>             Collection<T>
             *
             *
             * https://www.tutorialsteacher.com/csharp/csharp-collection
             */
            #endregion

            #region Genericden evvel Type Safety c# 1.0

            VirtualDatabase.Add(5);


            #endregion

            #region List<T>
            /*
            * ngc olan ArrayList-in gc olan formasidir.
            */
            ArrayList arrayList = new ArrayList();
            
            List<int> numbers = new List<int>{1,2,10,3,4}; // 5 // index : 3 value 10
            var numbers1 = new List<int>{1,2,10,3,4}; // 5 // index : 3 value 10

            List<string> names = new List<string> {"Elcan", "Kamran", "Ferid", "Resad"};
            numbers.Add(5);

            // insert
            /*
             * insert vasitesile lazim olan indexe deyer assign ede bilerik lakin bu zaman hemin indexe uygun
             * deyer varsa yeni deyerden sonraya kecir
             */
            numbers.Insert(2,10);
            Console.WriteLine();
            numbers[2] = 10;
            /*
             * Any
             */
            var result = numbers.Any();
            var result2 = numbers.Any(i=>i>0&&i<10);

            if (numbers.Any())
            {
                Console.WriteLine("item");
            }
            numbers.Sort();
            /*
             * yuxaridakilardan elave asagidaki kimi bir sira diger methodlar var bunlara aid  her birine bir numune yazacaqsiz task olaraq.
             * Sort()
             * Remove()
             * RemoveAll()
             * RemoveAt()
             * Max()
             * Min()
             */

            #endregion

            #region Dictionary<K,T>

            /*
            * ngc olan Hastable-in gc olan formasidir.
            * Bu collection iki deyer tipi almaqdadir birinci K tipi collectiondaki elementlerin keyleri,
            * ikinci T tipi K tipindeki key-lere uygun deyerlerdir.
            */

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dictionary.Add("Age",35);
            dictionary.Add("Year",2021);

            #endregion
        }
    }

    #region Genericden evvel Type Safety c# 1.0

    public static class VirtualDatabase
    {
        private static readonly ArrayList dataArrayList = new ArrayList();

        public static void Add(int data)
        {
            dataArrayList.Add(data);
        }
    }
   
    #endregion
}
