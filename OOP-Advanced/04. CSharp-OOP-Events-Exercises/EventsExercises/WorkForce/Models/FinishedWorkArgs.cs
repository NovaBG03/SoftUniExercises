namespace WorkForce.Models
{
    using System;

    public class FinishedWorkArgs : EventArgs
    {
        public FinishedWorkArgs(string jobName)
        {
            this.JobName = jobName;
        }

        public string JobName { get; }
    }
}
