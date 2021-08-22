using System;

namespace Week6.OOP.Class
{
    /// <summary>
    ///Musteri bankdan kredit goturur , ilkin versiyada standart nece ay
    ///goture biler, ne qeder mebleg goture biler , nece faizle goturecek
    ///kimi limitler yoxdur , en sade formada sabit olaraq  mebleg , ay , faiz
    ///daxil edilen zaman musterinin odeme tarixini  ve cari tarixde olan ayliq odemesini
    ///gostermeliyik.
    /// 
    ///Qeyd : eger ayliq odeme qaliqla alinarsa bu qaliq en son ayin uzerine gelecek.
    /// </summary>
    public class Credit
    {
        // month = 12, price = 600, percentage=0,7
        //Umumi mebleg:650,4
        //============================
        //tarix :24.04.2021, mebleg:54
        //============================
        //tarix :24.05.2021, mebleg:54
        //============================
        //tarix :24.06.2021, mebleg:54
        //============================
        //tarix :24.07.2021, mebleg:54
        //============================
        //tarix :24.08.2021, mebleg:54
        //============================
        //tarix :24.09.2021, mebleg:54
        //============================
        //tarix :24.10.2021, mebleg:54
        //============================
        //tarix :24.11.2021, mebleg:54
        //============================
        //tarix :24.12.2021, mebleg:54
        //============================
        //tarix :24.01.2022, mebleg:54
        //============================
        //tarix :24.02.2022, mebleg:54
        //============================
        //tarix :24.03.2022, mebleg:56,39999999999995
        public Credit(byte month, double price, double percentage)
        {
            Months = month;
            Price = price;
            Percentage = percentage;
        }

        public double Price { get; set; }
        public byte Months { get; set; }
        public double Percentage { get; set; }
        private DateTime Date { get; set; } = DateTime.Now;


        //600 => 100 %
        //x => 0,5 %
        public void Calc()
        {
            double total = Price + (Price * Percentage / 100) * Months;
            double monthlyPay = total / Months;
            double part = monthlyPay % 1;
            monthlyPay -= part;

            part *= Months;

            Console.WriteLine("Umumi mebleg:{0}",total);

            for (int i = 1; i <= Months; i++)
            {
                if (i == Months)
                {
                    monthlyPay += part;
                }

                PrintResult(monthlyPay);

                Date=Date.AddMonths(1);
            }
        }

        private void PrintResult(double monthlyPay)
        {
            Console.WriteLine("============================");
            Console.WriteLine("tarix :{0:d}, mebleg:{1}", Date, monthlyPay);
        }
    }
}
