using System;

namespace TaskManagers.DAL.Entities
{
    public class ProcessEntity : Entity
    {
        public string GroupName { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}