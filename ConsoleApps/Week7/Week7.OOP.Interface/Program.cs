using System;

namespace Week7.OOP.Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            #region OOP.Interface
            /*
             * Interface esasen class-lara hansi isleri goreceyini bildiren bir struktura sahibdir,
             * desek yanilmariq .
             * Proyektde goreceyimiz eyni emeliyyatlari Interface icerisinde cemlesdirib istifade eden
             * zaman kod tekrarinin azaldigini daha effektiv ierarxik strukturlu kod yazdigimizin ferqine
             * varacagiq.
             *
             * Interface-nin OOP de onemli yeri vardir.
             *
             * Ozellikleri
             * * Interface-den instance ala bilmerik .
             * * Esasen icerisinde teyin edilen method ve ya property-lerin body-si olmur
             *   Implement edildikleri class icerisinde yazilir.
             * * Adlandirma qaydasina gore interface I ile baslamalidir.
             * * Bir class birden cox Interface implement ede biler
             * * Interface member-ler public olaraq qebul edilir.
             * * Interface-de ctor teyin edile bilmez
             *
             * **** C# 8.0 Default Implementations
             *
             * bu ozellikle bilikde artiq interfacelerin icerisinde olan memberlerin body-si
             * interface icerisinde yerlesdirile bilmekdedir, bununla yanasi body interface icerisinde teyin edildiyinden
             * body-si olan memeberin implemet edilmesi mecburiyyeti aradan qaldirilmisdir ,hemcinin staticle isaret edilerek
             * ram-da static hissede yerlesdirile bilerler.
             */
            #endregion

            #region examples

            #region 1

            #endregion


            #endregion
        }
    }
    #region examples
    #region 1.
    public interface IEmployee
    {
        
        string Name { get; set; }
        string SurName { get; set; }
        string Deparment { get; set; }

        decimal FeePerOur { get; set; }
        decimal TotalWorkHour { get; set; }

        decimal CalculateSalary(decimal feePerOur, decimal totalWorkHour);

    }

    public class Employee : IEmployee
    {
        //public string Name { get; set; }
        //public string SurName { get; set; }
        //public string Deparment { get; set; }
        //public decimal FeePerOur { get; set; }
        //public decimal TotalWorkHour { get; set; }

        //public decimal CalculateSalary(decimal FeePerOur, decimal TotalWorkHour)
        //{
        //    return FeePerOur * TotalWorkHour;
        //}

        #region Implementation of IEmployee

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Deparment { get; set; }
        public decimal FeePerOur { get; set; }
        public decimal TotalWorkHour { get; set; }
        public decimal CalculateSalary(decimal feePerOur, decimal totalWorkHour)
        {
            throw new NotImplementedException();
        }

        #endregion

       
    }
    #endregion

    #region default implementations

    interface IExample
    {
        void X();
        void Y()
        {
            Console.WriteLine("y method body");
        }
    }

    public class Example : IExample
    {
        #region Implementation of IExample

        public void X()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region interface segratation

    interface IXY
    {
        void X();
        void Y();
    }

    class Example1: IXY
    {
        #region Implementation of IXY

        public void X()
        {
            throw new NotImplementedException();
        }

        public void Y()
        {
           
        }

        #endregion
    }

    interface IX
    {
        void X();
        
    }

    class Example2: IXY
    {
        #region Implementation of IXY

        public void X()
        {
            
        }

        public void Y()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    interface ICRUDService
    {
        void Create();
        void Update(int id);

        void Delete(int id);
        void GetInfo();
    }

    public class Product:ICRUDService
    {
        #region Implementation of ICRUDService

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void GetInfo()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class Car : ICRUDService
    {
        #region Implementation of ICRUDService

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void GetInfo()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion
}
