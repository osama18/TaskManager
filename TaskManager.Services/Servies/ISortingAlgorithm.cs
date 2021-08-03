using System;

namespace TaskManager.Services.Services
{
    public interface ISortingAlgorithm 
    {
        T[] Sort<T>(T[] arr) where T : IComparable<T>;
    }
}