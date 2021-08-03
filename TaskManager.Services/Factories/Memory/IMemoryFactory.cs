using TaskManager.Services.Models;

namespace TaskManager.Services.Factories.Memory
{
    public interface IMemoryFactory
    {
        IMemory Construct();
    }
}