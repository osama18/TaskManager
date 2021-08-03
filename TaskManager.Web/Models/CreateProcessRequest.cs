using TaskManager.Services.Models.Process;

namespace TaskManagers.Web.Models
{
    public class CreateProcessRequest
    {
        public Priority Priority { get; set; }
        public string GroupName { get; set; }
    }
}