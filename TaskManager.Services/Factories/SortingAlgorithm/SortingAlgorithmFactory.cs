using TaskManager.Services.Services;

namespace TaskManager.Services.Factories.SortingAlgorithm
{
    internal class SortingAlgorithmFactory : ISortingAlgorithmFactory
    {
        
        public ISortingAlgorithm Construct(bool mustbeStable = true, bool favorTimeoverSpace = true)
        {
            if (mustbeStable)
            {
                if (favorTimeoverSpace)
                {
                    return new MergeSort();
                }
                else
                {
                    //return insertion or bubble
                }
            }
            else
            {
                if (favorTimeoverSpace)
                {
                    //heap sort
                }
                else
                {
                    //return insertion or bubble
                }
            }
            return new MergeSort();
        }

        
    }
}
