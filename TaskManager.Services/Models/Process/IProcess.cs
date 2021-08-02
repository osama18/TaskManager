using System;

namespace TaskManager.Services.Models.Process
{
    public interface IProcess : IDisposable
    {
       long PID { get; }
       Priority Priority { get; }
       DateTime CreatedAt { get; }
       string GroupName { get; set; }
       void Kill();
    }
}