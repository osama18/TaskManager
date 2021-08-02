using System;
namespace TaskManager.Services.Models.Process
{
    public class ConcreteProcess : IProcess
    {
        private readonly long pID;
        private readonly Priority priority;
        private readonly DateTime createdAt;
        private string groupName { get; set; }
        public ConcreteProcess(long pID, Priority priority , string groupName)
        {
            this.pID = pID;
            this.priority = priority;
            this.groupName = groupName;
            this.createdAt = DateTime.UtcNow;
        }

        public long PID { get { return pID; } }
        public Priority Priority { get { return priority; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public string GroupName { get { return groupName; } set { groupName = value; } }

        public void Kill()
        {
            Dispose();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
