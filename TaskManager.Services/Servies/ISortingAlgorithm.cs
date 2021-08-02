using System;

namespace TaskManager.Services.Services
{
    internal interface ISortingAlgorithm 
    {
        T[] Sort<T>(T[] arr) where T : IComparable<T>;
    }
}