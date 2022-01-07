using System;
using System.Linq;

namespace Pizza
{
    class Program
    {
        static void Main(string[] args)
        {
            var mySlice = BiggestSlice(new[] { 7, 2, 3, 4, 5, 6, 14,3,7 });
            Console.WriteLine(mySlice);
        }

        static int BiggestSlice(int[] slices)
        {
            switch (slices.Length)
            {
                case 3: return slices.Max();
                case 0: return 0;
            }

            var totalBiggestSlice = 0;

            var sliceList = slices.ToList();

            while (sliceList.Count > 0)
            {
                var myBiggestSlice = sliceList.Max();
                totalBiggestSlice+= myBiggestSlice;

                var biggestSliceIndex = sliceList.IndexOf(myBiggestSlice);

                //For alice (anti clockwise)
                var aliceIndex = biggestSliceIndex == 0 ? sliceList.Count - 1 : biggestSliceIndex - 1;

                //For bob (clockwise)
                var bobIndex = biggestSliceIndex == sliceList.Count - 1 ? 0 : biggestSliceIndex + 1;

                sliceList.RemoveAll(p => p == sliceList[aliceIndex] || p == sliceList[bobIndex] || p == myBiggestSlice);
            }


            return totalBiggestSlice;
        }
    }
}