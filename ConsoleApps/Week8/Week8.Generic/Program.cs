using System;
using System.Collections;
using System.Collections.Generic;

namespace Week8.Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Generic
            /*
             * Umumilikde Genericler bize tek bir tip ile deyil ferqli tiplerle islemeyimize
             * ve daha az kod yazaraq islerimizi hell etmeye imkan yaradir.
             *
             * Generic sekilde teyin etdiyimiz interface , class, metod ve ya parametrler
             * bir tip ucun deyil proyekde olan diger tiplerle de islemeyimize imkan yaradan
             * bir sablon hazirlamagimiza imkan yaradir ve bununlada Generic serviceler,
             * repositoryler yaradaraq tekrarlanan emeliyyatlarimizi bir yerden idare ede bilirik.
             *
             *
             * Generic -ler >.Net 2.0 ile birlikde istifadeye verilmisdir.
             *
             ******** Avantajlar
             * *Tekrarlanan kod bloklarinin tekrar yazmagin qarshisini alir.
             * *Daha yaxsi idare oluna bilen ve keyfiyyetli kod yazmagimiza imkan verir
             * *RunTime da lazimsiz Cast Boxing-UnBoxing emeliyyatlarina ehtiyyac qalmir
             * bunun ucun daha effektivdir.
             *
             *
             * **** Generic ve CLR desteyi
             * Generic-ler dil seviyyesinde bir ozellik deyil, .Net CLR
             * genericleri avtomatik sekilde taniyir. Yaradilan Generic
             * class, method ve ya parametr sadece bir defe yaradilir ve generic
             * struktura oturulen her tip ucun CLR arxa planda gedib ilk yaradilan
             * generic strukturu ve daxilindeki emeliyyatlari istifade edir.
             *
             *
             * *** Generic Class
             * *** Generic Methods
             * *** Generic Type Parameters
             * *** Generic Interface
             * *** Generic Constraint
             *
             * where T : struct          T value type olmalidir.
             * where T : class           T reference type olmalidir.
             * where T : new()           T default ctor parametrsiz.
             * where T : class_name      T inheritance alimis olmalidir.
             * where T : interface_name  T implement edilmis olmalidir.
             *
             *
             * *** Inheritance
             * MyClass1<T> formasinda teyin edilen class-lar "open-constructed generic" adlanir.
             * MyClass1<int> formasinda "closed-constructed generic"
             *
             * Open-constructed generic, closed-constructed generic-den inheritance ala biler.
             * Open-constructed generic oz tipinde classdan inheritance ala biler.
             *
             * Generic olmayan class closed-constructed generic-den inheritance ala biler lakin
             * open-constructed generic-den ala bilmez
             *
             * public class MyClass : MyClass1<int>
             *
             * public class MyClass : MyClass1<T>  *** olmaz ***
             *
             *
             *
             * https://dotnettutorials.net/lesson/generics-csharp/
             */
            #endregion

            #region examples

            #region non generic class

            Customer customer = new Customer {Id = 1};

            #endregion

            #region Generic class

            //CustomerGeneric<int> customerGeneric = new CustomerGeneric<int>();

            //customerGeneric.Id = 1;
            //customerGeneric.CustomerNo = 1234;
            //customerGeneric.GetCustomerNo();

            //Console.WriteLine(customerGeneric.GetCustomerNo());
            //Console.WriteLine("=========");

            //CustomerGeneric<Guid> customerGeneric1 = new CustomerGeneric<Guid>();
            //customerGeneric1.Id= Guid.NewGuid();
            //customerGeneric1.CustomerNo=Guid.NewGuid();
            //Console.WriteLine(customerGeneric1.GetCustomerNo());
            #endregion

            #region Generic class real case

            GenericRepository<CustomerRealCase> customerRepository = new GenericRepository<CustomerRealCase>();
            customerRepository.Add(new CustomerRealCase
            {
                Id = 1,
                Name = "Customer",
                Surname = "Customer",
                Birthdate = DateTime.Now,
                CustomerNo = Guid.NewGuid().ToString()
            });
            var customerList=customerRepository.GetAll();
            foreach (var item in customerList)
            {
                Console.WriteLine($"id:{item.Id} name:{item.Name} customerNo:{item.CustomerNo}");
            }

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");


            GenericRepository<Product> productRepository = new GenericRepository<Product>();

            // GenericRepository<int> x = new GenericRepository<int>();

            productRepository.Add(new Product
            {
                Id = 1,
                Name = "product 1"
            });
            var productList = productRepository.GetAll();

            foreach (var item in productList)
            {
                Console.WriteLine($"id:{item.Id} name:{item.Name}");
            }
            #endregion

            #region CLR desteyi

            //MyList<int> myIntList = new MyList<int>();
            //MyList<int> myIntList2 = new MyList<int>();

            //MyList<double> myDoubleList = new MyList<double>();

            //MyList<SampleClass> mySampleList = new MyList<SampleClass>();

            //Console.WriteLine(myIntList.Count);
            //Console.WriteLine(myIntList2.Count);
            //Console.WriteLine(myDoubleList.Count);
            //Console.WriteLine(mySampleList.Count);
            //Console.WriteLine(new MyList<SampleClass>().Count);

            //Console.ReadLine();

            #endregion

            #region generic method copy<T>

            List<int> list1 = new List<int> {1, 2, 3, 4, 5, 6};
            List<int> list2 = new List<int>();
            GenericMethodClassExample.Copy(list1,list2);
            #endregion

            #endregion
        }
        #region Constraint

        //public static T Max<T>(T op1, T op2)
        //{
        //    if (op1.CompareTo(op2) < 0) // xeta verecek cunki bilmir hansi tip gelir
        //        return op1;
        //    return op2;
        //}


        // gelen tip bu interface implemet edecek deye xeta vermeyecek
        public static T Max<T>(T op1, T op2) where T : IComparable
        {
            if (op1.CompareTo(op2) < 0)
                return op1;
            return op2;
        }
        #endregion
    }

    #region examples

    #region Non-Generic class

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }


    #endregion
    #region Generic class
    public class CustomerGeneric<T> // T : Type  / int
    {
        public T Id { get; set; } // int
        public T CustomerNo { get; set; } // int
        public string Name { get; set; }
        public string Surname { get; set; }

        public T GetCustomerNo()
        {
            return CustomerNo;
        }
    }
    #endregion
    #region Generic class real case
    /*
     * Database | MSSQl
     * Application | Console C#
     *
     * tblCustomer
     * id int
     * customerNo uniqueIdentify (C# GUID)
     * name nvarchar(50) string
     * surname nvarchar(50) string
     * birthdate Datetime
     *
     *
     * UnitOfWorks => Generic Class | Generic Interface
     *
     *
     */
    public class CustomerRealCase : IExampleInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CustomerNo { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class Product : IExampleInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductRepository
    {

    }

    public interface IExampleInterface
    {

    }
    public class GenericRepository<T> where T :  class
    {

        #region context : Database
        // EF : Db first
        //private ArrayList data= new ArrayList();
        private readonly List<T> dataList;

        #endregion

        #region ctor

        public GenericRepository()
        {
            dataList = new List<T>();
        }
        #endregion

        #region methods
        /// <summary>
        /// GetAll method generic collection qaytaracaq
        /// </summary>
        /// <returns>List<T></returns>
        public virtual List<T> GetAll()
        {
            return dataList;
        }

        /// <summary>
        /// dbya insert isleri gorulur
        /// </summary>
        /// <param name="data"></param>
        public virtual void Add(T data)
        {
            if (data != null)
            {
                dataList.Add(data);
            }
        }
        #endregion
    }
    #endregion
    #region CLR desteyi
    public class MyList<T> // open constructed generic class
    {
        private static int objCount = 0;

        public MyList()
        {
            objCount++;
        }

        public int Count => objCount;
    }


    #endregion
    #region generic method copy<T>
    public static class GenericMethodClassExample
    {
        public static void Copy<T>(List<T> source, List<T> destination)
        {
            foreach (T obj in source)
            {
                destination.Add(obj);
            }
        }
    }
    #endregion
    #region inheritance

    public class MyClassGeneric<T> // open constructed generic
    {
        public T Name { get; set; }
    }

    public class MyClass2Generic<T> : MyClassGeneric<T>
    {

    }



    class Test
    {
        public void Test1()
        {
            MyClass2Generic<string> newClass2Generic = new MyClass2Generic<string>();

            var name = newClass2Generic.Name; // string

            MyClass2NonGeneric myClass2NonGeneric = new MyClass2NonGeneric();

            var name2=myClass2NonGeneric.Name; // string
        }
    }

    //public class MyClass2NonGeneric : MyClassGeneric<T> // open-constructed generic ala bilmez
    //{

    //}
    public class MyClass2NonGeneric : MyClassGeneric<string> // closed-constructed generic
    {

    }

    #endregion
    #endregion
}
