using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Stopwatch sw = Stopwatch.StartNew();

            Random random = new Random();
            int[] arr = new int[20000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, 20000);
            }

            Console.WriteLine("Quick Sort");
            Console.WriteLine("-----------");
            sw.Start();
            QuickSortFirst(arr, 0, arr.Length - 1);
            sw.Stop();

            Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);

            Console.WriteLine();
            Console.WriteLine("Quick Sort: First Element as Pivot");
            Console.WriteLine("-----------------------");

            sw.Restart();
            QuickSortLast(arr, 0, arr.Length - 1);
            sw.Stop();
            Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);



        }

        public static void QuickSortFirst(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionFirst(arr, low, high);
                QuickSortFirst(arr, low, pi - 1);
                QuickSortFirst(arr, pi + 1, high);
            }
        }
        public static int PartitionFirst(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int tempValue= arr[i];
                    arr[i] = arr[j];
                    arr[j] = tempValue;
                }
            }
            int temp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp;
            return i + 1;
        }
        public static void QuickSortLast(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionLast(arr, low, high);
                QuickSortLast(arr, low, pi - 1);
                QuickSortLast(arr, pi + 1, high);
            }
        }
        public static int PartitionLast(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int left = low + 1;
            int right = high;

            while (true)
            {
                while (left <= right && arr[left] <= pivot)
                    left++;

                while (left <= right && arr[right] >= pivot)
                    right--;

                if (left > right)
                    break;

                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }

            arr[low] = arr[right];
            arr[right] = pivot;
            return right;
        }
    }
}
