using System;

namespace DelegatesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region delegate

            /*
             * Delegate method imzasini temsil eden reference typedir.
             * Delegate vasitesile bir sira geri donus tipine ve ya parametr qebul eden method=larin cagrilmasini
             * temin ede bilerik : delegate ozunde methodlari saxlamaqdadir ve onlari ram uzerinde depolayir.
             * her hansisa bir method delegate-den instance almaqla ise salina bilmekdedir.
             *
             * Delegate method-lari basqa methodlara argument olaraq oture bilmeyimize imkan yaradir.
             *
             * Windows form-da qarsimiza cixan Event Handler ozude delegate type dir.
             *
             * Delegate vasitesile invoke edilen methodlarin geri donus deyeri ve qebul etdiyi parametrler
             * bire bir eyni olmalidir.
             *
             *
             * Delegate vasitesile ard-arda birden cox method invoke edile bilmekdedir .
             *
             * **************
             * Delegate ise salinmasi ucun once onu bir deyisen olaraq teyin edirik sonra ona eyni imzaya sahib
             * methodlari set edirik en sonda invoke emeliyyati yerine yetirilir.
             *
             * Declare : [access modifier] delegate [return type] [delegate name]([parameters])
             *
             *           public delegate void MyDelegate(string msg);
             *
             * Delegate class daxilinde ve xaricinde teyin edile bilmekdedir.
             *
             * Bir delegate teyin edildikden sonra set edilecek bir method ve ya lambda expression istifade
             * edilmelidir
             *
             *
             * https://www.tutorialsteacher.com/csharp/csharp-delegates
             */

            #endregion

            #region example task 
            /*
             *  ele bir class dizayn etmelisiz ki , daxilindeki method 3 parametr qebul edecek
             *
             * ilk ikisi int tipinde ededler olacaq , classin ucuncu parametri ise qarsilashtirma emeliyyatini yerine yetirecek
             *  classlarin instance-i olacaq yeni bir defe == dirmini yoxlayan classin instance-i daxil edile bilmeli bir defe
             * boyuk ve ya kicik olmasini yoxlayan classin instance-i
             *
             *  bool CompareTo(int a, int b, new Instance1()) ==
             *  bool CompareTo(int a, int b, new Instance2()) > or <
             */

            #endregion
        }
    }
}
