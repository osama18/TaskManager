using TaskManager.Services.Models;
using TaskManager.Services.Services;

namespace TaskManager.Services.Factories.SortingAlgorithm
{
    public interface ISortingAlgorithmFactory
    {
        ISortingAlgorithm Construct(bool mustbeStable = true, bool favorTimeoverSpace = true);
    }
}