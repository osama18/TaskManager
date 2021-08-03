using System;
using TaskManager.Services.Models.Process;

namespace TaskManager.Models.Process
{
    public class ProcessDto 
    {
        public readonly ProcessDto Origin;
        public ProcessDto()
        { 

        }
        public ProcessDto(ProcessDto process)
        {
            Origin = process;
            PID = process.PID;
            this.Priority = process.Priority;
            CreatedAt = process.CreatedAt;
            GroupName = process.GroupName;
        }
        public long PID { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public string GroupName { get; set; }

    }
}