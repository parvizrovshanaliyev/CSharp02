using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp
{
    public delegate bool ComparerHandler4(int a, int b);

    public class Caller4
    {
        void Test()
        {
            // Anonymous Method with lambda
            CompareNumber3.CompareTo(1, 2, (a, b) => a == b);
            CompareNumber3.CompareTo(1, 2, (a, b) => a > b);
        }

    }

    public class CompareNumber4
    {
        public static bool CompareTo(int a, int b, ComparerHandler comparerHandler)
        {
            return comparerHandler(a, b);
        }
    }
}
