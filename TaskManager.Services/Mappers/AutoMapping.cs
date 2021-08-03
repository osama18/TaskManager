using AutoMapper;
using TaskManager.Models.Process;
using TaskManager.Services.Models.Process;
using TaskManagers.DAL.Entities;

namespace TaskManager.Services.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ConcreteProcess, ProcessEntity>()
                .ForMember(s => s.Priority, src => src.MapFrom(c => (int)c.Priority));

            CreateMap<ProcessEntity, ProcessDto>()
                .ForMember(s => s.PID, src => src.MapFrom(c => c.Id))
                .ForMember(s => s.Priority, src => src.MapFrom(c => ((Priority)c.Priority).ToString()));
        }
    }
}
