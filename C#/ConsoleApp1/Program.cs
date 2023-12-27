using System;

namespace HelloWorld
{
    public static class Extensions
    {
        // EXTENSION METHODS
        public static void Print(this object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        public static TValue SetDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue
        )
        {
            TValue ret;
            if (!dictionary.TryGetValue(key, out ret))
            {
                ret = defaultValue;
            }
            return ret;
        }
    }

    class Program
    {
        static int FuncaoObscura(
            int maxCount, // First variable, expects an int
            int count = 0, // will default the value to 0 if not passed in
            int another = 3,
            params string[] otherParams // captures all other parameters passed to method
        )
        {
            Console.WriteLine("Max: {0}, Count: {1}, Another: {2}", maxCount, count, another);
            return -1;
        }

        static void FuncaoObscura(ref int maxCount, out int count)
        {
            maxCount = 10;
            count = 1;
        }

        static void Main(string[] args)
        {
            // string fooFs = string.Format("Check Check, {0} {1}, {0} {1:0.00}", 1, 2);
            // Console.WriteLine(fooFs);

            // List<int> myList = new List<int>();
            // myList.Add(1);
            // myList.Add(3);
            // Console.WriteLine(myList[0]);

            // Bicycle bicycle = new();
            // bicycle.Cadence = 10;
            // Console.WriteLine(bicycle);

            // Console.WriteLine(FuncaoObscura(3, 1, 3, "Some", "Extra", "Strings"));
            // Console.WriteLine(FuncaoObscura(maxCount: 3, another: 3));

            // int maxCount = 3,
            //     count;
            // FuncaoObscura(ref maxCount, out count);
            // Console.WriteLine("Count: {0}, MaxCount: {1}", count, maxCount);

            // YIELD:
            // static IEnumerable<int> YieldCounter(int limit = 10)
            // {
            //     for (var i = 0; i < limit; i++)
            //         yield return i;
            // }
            // static IEnumerable<int> ManyYieldCounter()
            // {
            //     yield return 0;
            //     yield return 1;
            //     yield return 2;
            //     yield return 3;
            // }
            // // you can also use "yield break" to stop the Iterator
            // // this method would only return half of the values from 0 to limit.
            // static IEnumerable<int> YieldCounterWithBreak(int limit = 10)
            // {
            //     for (var i = 0; i < limit; i++)
            //     {
            //         if (i > limit / 2)
            //             yield break;
            //         yield return i;
            //     }
            // }

            // static void PrintYieldCounterToConsole()
            // {
            //     foreach (var counter in YieldCounter())
            //         Console.WriteLine(counter);
            // }
            // PrintYieldCounterToConsole();

            // int? nullable = null;
            // int notNullable = nullable ?? 0;
            // Console.WriteLine(notNullable);
            
        }
    }
}
