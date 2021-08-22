using System;
using System.Collections;

namespace Week7.OOP.Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            #region OOP.Abstraction
            /*
             * Abstract class sualina cavab olaraq deye bilerik ki, ortaq ozellikleri
             * olan class-larin base class-i olaraq yaradilir.
             * Abstract class-dan instance alinmaz ve bir class-in abstract olaraq
             * teyin etmek ucun abstract keyword-den istifade edilir
             *
             * ****** access modifier
             * Abstract c. private , protected, private internal ile isaretlene bilmezler.
             *
             * ****** sealed keyword
             *
             * Abstract c. sealed keyword-u ile istifade edilmir.
             * sealed ile isarelenmis classdan inheritance alinmaz deye A.c ile uygun gelmir.
             *
             * ****** static
             * Static methodlar teyin edile bilmez
             *
             * ****** method
             *
             * Abstract method sadece abstract c. icerisinde teyin edile biler ve bu methodlar override
             * edilmelidir.
             * Abstract method private olaraq teyin edile bilmez.
             * Abstract methodlarin body-si derived class-da yazilir.
             *
             * ****** abstract vs virtual
             * abstract -da bir nov ozunu virtual kimi aparir aralarindaki ferq virtual-in override edilme
             * mecburiyyeti yoxdur.
             */


            #endregion

            #region examples

            #region Shopping

            Bread bread = new Bread
            {
                Quantity = 2,
                Name = "Corek",
                Price = 0.5
            };

            Meat meat = new Meat
            {
                Name = "qoyun eti",
                Price = 13,
                Weight = 2
            };

            Shopping shopping = new Shopping
            {
                Orders = new ArrayList
                {
                    bread,
                    meat
                }
            };

            var totalPrice=shopping.Calculate();

            Console.WriteLine(totalPrice);
            #endregion

            //BaseEntity baseEntity = new BaseEntity();
            #region 3.log

            LogBase sqlLog = new SqlLog();

            LogBase fileLog = new FileLog();

            // file yazib oxuma emeliyyatlari

            try

            {

                // read file

                Console.WriteLine("*read file");

                fileLog.WriteLog();

                throw new Exception();

            }

            catch (Exception)

            {

                // exception

                fileLog.WriteErrorLog();

            }

            // Sql CRUD emeliyyatlari
            try
            {

                // Sql insert success

                Console.WriteLine("*Sql İnsert success");

                sqlLog.WriteLog();

                throw new Exception();

            }

            catch (Exception)

            {

                sqlLog.WriteErrorLog();

            }

            Console.ReadKey();

            #endregion

            #endregion
        }
    }

    #region examples

    #region how to define absctract class

    public abstract class User
    {
    }

    #endregion

    #region method

    public abstract class AirPlane
    {
        public int PassengerCapacity { get; set; }
        public string AirCraftCompany { get; set; }

        // method
        public abstract void Price();
    }

    public class BigAirplane : AirPlane
    {
        #region Overrides of AirPlane

        public override void Price()
        {
            Console.WriteLine("1.000.000");
        }

        #endregion
    }
    public class MidAirplane : AirPlane
    {
        #region Overrides of AirPlane

        public override void Price()
        {
            Console.WriteLine("500.000");
        }

        #endregion
    }
    #endregion

    #region 3.log
    public abstract class LogBase

    {
        public abstract void WriteLog();

        public abstract void WriteErrorLog();

    }

    public class SqlLog : LogBase

    {
       

        public override void WriteLog()

        {

            Console.WriteLine("SqlLog yazıldı.");

        }

        public override void WriteErrorLog()

        {

            Console.Write("Sql Error Log yazıldı");

        }

    }
    public class FileLog : LogBase

    {

        public override void WriteLog()

        {

            Console.WriteLine("File Log yazıldı.");

        }

        public override void WriteErrorLog()

        {

            Console.WriteLine("File Error Log yazıldı.");

        }

    }
    #endregion

    #region base entity
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; } = DateTime.Now;

        public string CreatedBy { get; } = "admin";

        public DateTime UpdatedDate { get; } = DateTime.Now;

        public string UpdatedBy { get; } = "admin";
    }

    public class Product : AuditableEntity
    {

    }

    public class Car : BaseEntity
    {

    }

    #endregion
   
    #endregion
}
