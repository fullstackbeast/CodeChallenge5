using System;
using System.Linq;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            var max = MaxRectangle(new int[] { 2,2,1,6,4,0,3 });

            Console.WriteLine(max);
        }
   
        static int MaxRectangle(int[] arr)
        {
            switch (arr.Length)
            {
                case 0:
                    return 0;
                case 1:
                    return arr[0];
            }

            var maxValue = arr.Max();
            var max = 0;

            for (var i = maxValue; i > 0; i--)
            {
                if(i * arr.Length <= max) break;
               
                var currentMax = 0;
                foreach (var t in arr)
                {
                    if (t >= i) currentMax += i;
                    else
                    {
                        max = Math.Max(max, currentMax);
                        currentMax = 0;
                    }
                }

                max = Math.Max(max, currentMax);
            }

            return max;
        }
    }
}