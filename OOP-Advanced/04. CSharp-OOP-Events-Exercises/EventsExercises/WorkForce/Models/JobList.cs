namespace WorkForce.Models
{
    using System.Collections.Generic;

    public class JobList : List<Job>
    {
        public void DeliteJob(object sender, FinishedWorkArgs args)
        {
            this.Remove((Job)sender);
        }
    }
}
