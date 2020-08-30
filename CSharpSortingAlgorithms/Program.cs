using System;
using System.Timers;

namespace CSharpSortingAlgorithms
{
    class Program
    {
        public const string _fileName = "data.txt";

        static void Main(string[] args)
        {
            SortingMachine sort = new SortingMachine(_fileName);
            sort.LoadData();

            Console.WriteLine("Unsorted data:");
            foreach (int val in sort.Data)
            {
                Console.WriteLine(val);
            }

            //Bubble Sort
            DateTime startTime = DateTime.Now;
            int[] bubbleSortedData = sort.BubbleSort();
            DateTime endtime = DateTime.Now;

            Console.Write("Bubble Sort time: ");
            Console.WriteLine(endtime - startTime);

            Console.WriteLine("Bubble Sorted Data:");
            foreach (int val in bubbleSortedData)
            {
                Console.WriteLine(val);
            }
            
            //Insertion Sort
            startTime = DateTime.Now;
            int[] insertionSortData = sort.InsertionSort();
            endtime = DateTime.Now;

            Console.Write("Insertion Sort time: ");
            Console.WriteLine(endtime - startTime);

            Console.WriteLine("Insertion Sorted Data:");
            foreach (int val in insertionSortData)
            {
                Console.WriteLine(val);
            }

            //Selection Sort
            startTime = DateTime.Now;
            int[] selectionSortData = sort.SelectionSort();
            endtime = DateTime.Now;

            Console.Write("Selection Sort time: ");
            Console.WriteLine(endtime - startTime);

            Console.WriteLine("Selection Sorted Data:");
            foreach (int val in selectionSortData)
            {
                Console.WriteLine(val);
            }

            //Heap Sort
            startTime = DateTime.Now;
            int[] heapSortData = sort.HeapSort();
            endtime = DateTime.Now;

            Console.Write("Heap Sort time: ");
            Console.WriteLine(endtime - startTime);

            Console.WriteLine("Heap Sorted Data:");
            foreach (int val in heapSortData)
            {
                Console.WriteLine(val);
            }

            //Merge Sort
            startTime = DateTime.Now;
            int[] mergeSortData = sort.MergeSort();
            endtime = DateTime.Now;

            Console.Write("Merge Sort time: ");
            Console.WriteLine(endtime - startTime);

            Console.WriteLine("Merge Sorted Data:");
            foreach (int val in mergeSortData)
            {
                Console.WriteLine(val);
            }

            //Quick Sort
            startTime = DateTime.Now;
            int[] quickSortData = sort.QuickSort();
            endtime = DateTime.Now;

            Console.Write("Quick Sort time: ");
            Console.WriteLine(endtime - startTime);

            Console.WriteLine("Quick Sorted Data:");
            foreach (int val in quickSortData)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        
    }
}
