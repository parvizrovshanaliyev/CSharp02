namespace DelegatesConsoleApp
{
    public delegate bool ComparerHandler3(int a, int b);

    public class Caller3
    {
        void Test()
        {
            // Anonymous Method with del
            CompareNumber3.CompareTo(1, 2, delegate(int a, int b) { return a == b; });
            CompareNumber3.CompareTo(1, 2, delegate(int a, int b) { return a > b; });
        }

    }

    public  class CompareNumber3
    {
        public static bool CompareTo(int a, int b, ComparerHandler comparerHandler)
        {
            return comparerHandler(a, b);
        }
    }
}
