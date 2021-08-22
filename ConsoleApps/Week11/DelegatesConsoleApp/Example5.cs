using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp
{

    public class Caller5
    {
        void Test()
        {
            // built in FUNC
            CompareNumber3.CompareTo(1, 2, (a, b) => a == b);
            CompareNumber3.CompareTo(1, 2, (a, b) => a > b);
        }

    }

    public class CompareNumber5
    {
        public static bool CompareTo(int a, int b, Func<int,int, bool> comparerHandler)
        {
            return comparerHandler(a, b);
        }
    }
}
