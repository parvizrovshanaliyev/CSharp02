using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp
{
    public delegate bool ComparerHandler(int a, int b);

    public class Caller2
    {

        void Test()
        {
            CompareNumber2 compareNumber = new CompareNumber2();

            ComparerHandler comparerHandler = new ComparerHandler(Compare);

            // v1
            compareNumber.CompareTo(1, 2, comparerHandler);

            // v2
            compareNumber.CompareTo(1, 2, Compare);
            compareNumber.CompareTo(1, 2, IsBigCompare);
        }


        public  bool Compare(int a, int b)
        {
            return a == b;
        }

        public bool IsBigCompare(int a, int b)
        {
            return a > b;
        }
    }
    

    public class CompareNumber2
    {
        public bool CompareTo(int a, int b, ComparerHandler comparerHandler)
        {
            return comparerHandler(a, b);
            //
            // or
            //return comparerHandler.Invoke(a, b);
        }
    }
}
