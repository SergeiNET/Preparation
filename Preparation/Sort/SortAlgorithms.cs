using System;
using Preparation.Utils;
using System.Collections.Generic;

namespace Preparation.Sort
{
    public class SortAlgorithms
    {
		//https://en.wikipedia.org/wiki/Insertion_sort
		/*
            Insertion sort iterates, consuming one input element each repetition, and growing a sorted output list. At each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list, and inserts it there. 
            It repeats until no input elements remain.
            Sorting is typically done in-place, by iterating up the array, growing the sorted list behind it.
            At each array-position, it checks the value there against the largest value in the sorted list
            (which happens to be next to it, in the previous array-position checked). 
            If larger, it leaves the element in place and moves to the next. 
            If smaller, it finds the correct position within the sorted list, 
            shifts all the larger values up to make a space, and inserts into that correct position.
            The resulting array after k iterations has the property where the first k + 1 entries are sorted ("+1" because the first entry is skipped). In each iteration the first remaining entry of the input is removed, 
            and inserted into the result at the correct position, thus extending the result:
            with each element greater than x copied to the right as it is compared against x.
        */
		public static void InsertionSort(int[] arr) 
        {
            Console.WriteLine("---Insertion Sort---");
            // 
            int i = 1; 
            while(i < arr.Length) 
            {
                arr.Print();
                var temp = arr[i];
                Console.WriteLine($"Store {temp}, index {i}");
                int j = i - 1;

                while(j >= 0 && arr[j] > temp)
                {
                    Console.WriteLine($"Move {arr[j]} from index {j} to index {j + 1}");
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
                Console.WriteLine($"Insert stored {temp} to index {j + 1}");
                i++;
            }
        }

        //https://en.wikipedia.org/wiki/Quicksort
        public static void QuickSort(int[] arr) 
        {
			Console.WriteLine("---Quick Sort---");
            _QuickSort(arr, 0, arr.Length - 1);
        }

        private static void _QuickSort(int[] A, int lo, int hi) 
        {
            if(lo < hi) 
            {
                A.Print();
                var pivot = A[hi]; // Pivot
                var pivotIndex = hi;
                var wall = lo; // Wall

                for(int i = lo; i <= hi; i++)
                {
                    if(A[i] < pivot)
                    {
                        var tmp = A[wall]; // Swap values smaler ann lager than pivot value
                        A[wall] = A[i];
                        A[i] = tmp;
                        wall++; // Move Wall 
                    }
                }

                if (pivot < A[wall])
                {
                    var tmp1 = A[wall]; // Put pivot between smaler and lager values (swap it with element newarest to the wall)
                    A[wall] = pivot;
                    A[pivotIndex] = tmp1;
                }
                _QuickSort(A, lo, wall - 1);
                _QuickSort(A, wall + 1, hi);
            }
        }

        //https://en.wikipedia.org/wiki/Heapsort
        public static void HeapSort(int[] input)
        {
            //Build-Max-Heap
            int heapSize = input.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(input, heapSize, p);

            for (int i = input.Length - 1; i > 0; i--)
            {
                //Swap (Take Max element from the Heap and swap put it before prev max element in the end of arr
                int temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                MaxHeapify(input, heapSize, 0); // Fix Heap Properties
            }
        }

        private static void MaxHeapify(int[] input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapify(input, heapSize, largest);
            }
        }



        private static int ParentIndex(int[] a, int current)
        {
            return (current - 1) / 2;
        }

        private static int LeftChildIndex(int current)
        {
            return 2 * current + 1;
        }

        private static int RightChildIndex(int current)
        {
            return 2 * current + 2;
        }

        //https://en.wikipedia.org/wiki/Merge_sort
        public static int[] MergeSort(int[] a)
        {
            if(a.Length == 1)
            {
                return a;
            }
            

            var capacityR = (a.Length / 2);
            int capacityL = capacityR;
            int leftCursor = 0;
            int rightCursor = 0;

            if (a.Length % 2 > 0)
            {
                capacityR++;
            }

            var left = new int[capacityL];
            var right = new int[capacityR];

            for(var i = 0; i < a.Length; i++)
            {
                if(i % 2 > 0)
                {
                    left[leftCursor] = a[i];
                    leftCursor++;
                }
                else
                {
                    right[rightCursor] = a[i];
                    rightCursor++;
                }
            }

            var lRes = MergeSort(left);
            var rRes = MergeSort(right);
            return Merge(lRes, rRes);
        }

        public static int[] Merge(int[] l, int[] r)
        {
            var result = new int[l.Length + r.Length];
            int leftCursor = 0;
            int rightCursor = 0;

            for(int i = 0; i < result.Length; i++)
            {
                if(leftCursor < l.Length && rightCursor < r.Length)                   
                {
                    if (l[leftCursor] < r[rightCursor])
                    {
                        result[i] = l[leftCursor];
                        leftCursor++;
                    } else
                    {
                        result[i] = r[rightCursor];
                        rightCursor++;
                    }
                }
                else
                {
                    if(leftCursor == l.Length)
                    {
                        result[i] = r[rightCursor];
                        rightCursor++;
                    }
                    else
                    {
                        result[i] = l[leftCursor];
                        leftCursor++;
                    }
                }
            }

            return result;
        }
    }
}
