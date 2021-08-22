using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp
{

    public  class Caller
    {

        void Test()
        {
            CompareNumber compareNumber = new CompareNumber();

            compareNumber.CompareTo(1, 2, new Comparer());

            compareNumber.CompareTo(1, 2, new IsBigComparer());

            compareNumber.CompareTo(1, 2, new IsSmallComparer());
        }
       
    }


    public interface IComparer
    {
        bool Compare(int a, int b);
    }

    public class Comparer : IComparer
    {
        #region Implementation of IComparer

        public bool Compare(int a, int b)
        {
            return a == b;
        }

        #endregion
    }

    public class IsBigComparer : IComparer
    {
        #region Implementation of IComparer

        public bool Compare(int a, int b)
        {
            return a > b;
        }

        #endregion
    }


    public class IsSmallComparer : IComparer
    {
        #region Implementation of IComparer

        public bool Compare(int a, int b)
        {
            return a < b;
        }

        #endregion
    }

    public class CompareNumber
    {
        public bool CompareTo(int a, int b, IComparer comparer)
        {
            return comparer.Compare(a, b);
        }
    }
}
