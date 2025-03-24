namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 10, 7, 8, 9, 1, 5 };


            Console.WriteLine("Unsorted array");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
            QuickSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine("\nSorted array");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }

        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }
        public static int Partition(int[] arr, int low, int high)
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
    }
}
