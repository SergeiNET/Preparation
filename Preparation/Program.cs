using System;
using Preparation.Sort;

namespace Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Sorting Algorithms---");
            var iArr = new int[] { 3, 2, 1, 9 };
            //SortAlgorithms.InsertionSort(iArr);
            iArr = new int[] { 3, 2, 1, 9, 47, 37 };
            //SortAlgorithms.QuickSort(iArr);

            //SortAlgorithms.HeapSort(iArr);

            var res = SortAlgorithms.MergeSort(iArr);
        }
    }
}
