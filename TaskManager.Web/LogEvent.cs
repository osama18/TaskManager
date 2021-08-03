namespace TaskManagers.Web
{
    internal enum LogEvent
    {
        FailedToListTaskManagerProcesses,
        FailedToAddProcess,
        FailedToKillProcess,
        FailedToKillAll,
        FailedToKillProcessGroup
    }
}