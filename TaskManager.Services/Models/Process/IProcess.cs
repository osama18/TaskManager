using System;

namespace TaskManager.Services.Models.Process
{
    public interface IProcess 
    {
       long PID { get; }
       Priority Priority { get; }
       DateTime CreatedAt { get; }
       string GroupName { get; set; }
       void Kill();
    }
}