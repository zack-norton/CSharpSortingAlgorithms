using System;

namespace CSharpSortingAlgorithms
{
    internal class SortingMachine
    {
        private string _fileName;

        public int[] Data { get; set; }

        public SortingMachine(string fileName)
        {
            _fileName = fileName;
        }
        
        internal void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(_fileName);

            Data = new int[lines.Length];

            for(int i = 0; i < lines.Length; i++)
            {
                Data[i] = int.Parse(lines[i]);
            }
        }
        #region Sorting Algorithms 
        #region Bubble Sort
        public int[] BubbleSort()
        {
            int[] result = Data;

            int n = result.Length;
            int newn;
            int temp;
            while(n > 1)
            {
                newn = 0;
                for(int i = 1; i < n; i++)
                {
                    if(result[i-1] > result[i])
                    {
                        temp = result[i - 1];
                        result[i - 1] = result[i];
                        result[i] = temp;
                        newn = i;
                    }
                }
                n = newn;
            }

            return result;
        }
        #endregion

        #region Insertion Sort
        public int[] InsertionSort()
        {
            int[] result = Data;

            for(int i = 1; i < result.Length; i++)
            {
                int x = result[i];
                int j = i - 1;
                while(j >= 0 && result[j] > x)
                {
                    result[j + 1] = result[j];
                    j = j - 1;
                }
                result[j + 1] = x;
            }

            return result;
        }
        #endregion

        #region Selection Sort
        public int[] SelectionSort()
        {
            int[] result = Data;

            int minIndex;
            int temp;
            for(int i = 0; i < result.Length - 1; i++)
            {
                minIndex = i;
                for(int j = i + 1; j < result.Length; j++)
                {
                    if(result[j] < result[minIndex])
                    {
                        minIndex = j;
                    }
                }
                temp = result[i];
                result[i] = result[minIndex];
                result[minIndex] = temp;
            }

            return result;
        }
        #endregion

        #region Heap Sort
        public int[] HeapSort()
        {
            int[] result = Data;

            //build heap
            for(int i = result.Length/2-1; i >= 0; i--)
            {
                heapify(result, result.Length, i);
            }

            for(int i = result.Length-1; i > 0; i--)
            {
                //move root to end
                int temp = result[0];
                result[0] = result[i];
                result[i] = temp;

                heapify(result, i, 0);
            }

            return result;
        }

        private void heapify(int[] result, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if(left < n && result[left] > result[largest])
            {
                largest = left;
            }
            if (right < n && result[right] > result[largest])
            {
                largest = right;
            }

            if(largest != i)
            {
                int temp = result[i];
                result[i] = result[largest];
                result[largest] = temp;

                heapify(result, n, largest);
            }
        }
        #endregion

        #region Merge Sort
        public int[] MergeSort()
        {
            int[] result = Data;

            recursiveMergeSort(result, 0, result.Length-1);

            return result;
        }

        private void recursiveMergeSort(int[] result, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + (right - 1)) / 2;

                recursiveMergeSort(result, left, middle);
                recursiveMergeSort(result, middle + 1, right);

                merge(result, left, middle, right);
            }
        }

        private void merge(int[] result, int left, int middle, int right)
        {
            int i, j, k;
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] tempLeft = new int[n1];
            int[] tempRight = new int[n2];

            for(i = 0; i < n1; i++)
            {
                tempLeft[i] = result[left + i];
            }
            for(j = 0; j < n2; j++)
            {
                tempRight[j] = result[middle + 1 + j];
            }

            i = 0;
            j = 0;
            k = left;
            while(i < n1 && j < n2)
            {
                if(tempLeft[i] <= tempRight[j])
                {
                    result[k] = tempLeft[i];
                    i++;
                }
                else
                {
                    result[k] = tempRight[j];
                    j++;
                }
                k++;
            }

            while(i < n1)
            {
                result[k] = tempLeft[i];
                i++;
                k++;
            }
            while(j < n2)
            {
                result[k] = tempRight[j];
                j++;
                k++;
            }
        }
        #endregion

        #region Quick Sort
        public int[] QuickSort()
        {
            int[] result = Data;

            recursiveQuickSort(result, 0, result.Length - 1);

            return result;
        }

        private void recursiveQuickSort(int[] result, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = partition(result, low, high);

                recursiveQuickSort(result, low, partitionIndex - 1);
                recursiveQuickSort(result, partitionIndex + 1, high);
            }
        }

        private int partition(int[] result, int low, int high)
        {
            int pivot = result[high];

            int i = low - 1;
            int temp;

            for(int j = low; j <= high - 1; j++)
            {
                if(result[j] < pivot)
                {
                    i++;
                    temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
            temp = result[i + 1];
            result[i + 1] = result[high];
            result[high] = temp;

            return (i + 1);
        }
        #endregion
        #endregion
    }
}