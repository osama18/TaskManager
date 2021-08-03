using System;
using System.Threading.Tasks;

namespace TaskManagers.Common.Logging
{
    public interface ILogger 
    {
        public Task LogErrorAsync(ErrorLevel ErrorLevel, Exception ex, string LogType);
    }
}
