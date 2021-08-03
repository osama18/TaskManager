using AutoMapper;
using System;
using TaskManager.Services.Models;
using TaskManager.Services.Models.Memory;
using TaskManagers.Common.Settings;
using TaskManagers.DAL.Repostiories;

namespace TaskManager.Services.Factories.Memory
{
    internal class MemoryFactory : IMemoryFactory
    {
        private readonly IProcessRepository processRepository;
        private readonly ISettingProvider settingsProvider;
        private readonly IMapper mapper;
        private string MemoryType;

        public MemoryFactory(IProcessRepository processRepository,
            ISettingProvider settingsProvider,
            IMapper mapper)
        {
            this.processRepository = processRepository;
            this.settingsProvider = settingsProvider;
            this.mapper = mapper;
        }

        public IMemory Construct()
        {
            LoadMemoryType();
            switch (MemoryType)
            {
                case Constants.HeapMemoryType:
                    return new HeapMemory(processRepository, mapper, Constants.MemoryCapacity);

                case Constants.QueueMemoryType:
                    return new QueueMemory(processRepository, mapper, Constants.MemoryCapacity);

                case Constants.PriorityQueueMemoryType:
                    return new PriorityQueueMemory(processRepository, mapper, Constants.MemoryCapacity);

            }

            throw new NotImplementedException("Couldn't find configured memory type");
        }

        private void LoadMemoryType()
        {
            if (string.IsNullOrEmpty(MemoryType))
            {
               MemoryType = settingsProvider.GetSetting<string>(Constants.MemoryType);
            }
        }
    }
}
