using CodeKata_OrderedJobs.BL;
using System.Collections.Generic;
using System.Linq;

namespace CodeKata_OrderedJobs.Infrastructure
{
    public class OrderedJobsImpl : IOrderedJobs
    {
        private ICollection<char> jobs = new List<char>();

        public void Register(char dependentJob, char independentJob)
        {
            
        }

        public void Register(char jobId)
        {
            if (jobs.Contains(jobId))
                return;

            jobs.Add(jobId);
        }

        public string Sort()
        {
            return new string(jobs.ToArray());
        }
    }
}
