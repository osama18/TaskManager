﻿using System.Diagnostics.CodeAnalysis;
using TaskManager.Models.Process;

namespace TaskManager.Services.Models.Process.DecoratedProcesses
{
    public class PIDComparableProcess : ProcessDto, IComparableProcess
    {
        public PIDComparableProcess(ProcessDto process) : base(process)
        {
            this.Process = process;
        }

        public int CompareTo([AllowNull] IComparableProcess other)
        {
            if (other == null)
                return 1;

            if (PID < other.Process.PID)
                return -1;
            if (PID == other.Process.PID)
                return 0;
            return 1;
        }

        public ProcessDto Process { get; set; }
    }
}
