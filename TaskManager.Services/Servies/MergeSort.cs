using System;
using TaskManager.Services.Services;

namespace TaskManager.Services
{
    internal class MergeSort : ISortingAlgorithm 
    {

        public T[] Sort<T>(T[] arr) where T : IComparable<T>
        {
            int size = arr.Length;
            T[] tempArray = new T[size];
            return mergeSrt(arr, tempArray, 0, size - 1);
        }

        private T[] mergeSrt<T>(T[] arr, T[] tempArray, int lowerIndex, int upperIndex) where T : IComparable<T>
        {
            if (lowerIndex >= upperIndex)
            {
                return arr;
            }
            int middleIndex = (lowerIndex + upperIndex) / 2;
            mergeSrt(arr, tempArray, lowerIndex, middleIndex);
            mergeSrt(arr, tempArray, middleIndex + 1, upperIndex);
            return merge(arr, tempArray, lowerIndex, middleIndex, upperIndex);
        }
        private T[] merge<T>(T[] arr, T[] tempArray, int lowerIndex, int middleIndex, int upperIndex) where T : IComparable<T>
        {
            int lowerStart = lowerIndex;
            int lowerStop = middleIndex;
            int upperStart = middleIndex + 1;
            int upperStop = upperIndex;
            int count = lowerIndex;
            while (lowerStart <= lowerStop && upperStart <= upperStop)
            {
                if (arr[lowerStart].CompareTo(arr[upperStart]) < 0)
                {
                    tempArray[count++] = arr[lowerStart++];
                }
                else
                {
                    tempArray[count++] = arr[upperStart++];
                }
            }
            while (lowerStart <= lowerStop)
            {
                tempArray[count++] = arr[lowerStart++];
            }
            while (upperStart <= upperStop)
            {
                tempArray[count++] = arr[upperStart++];
            }
            for (int i = lowerIndex; i <= upperIndex; i++)
            {
                arr[i] = tempArray[i];
            }

            return arr;
        }

    }
}
