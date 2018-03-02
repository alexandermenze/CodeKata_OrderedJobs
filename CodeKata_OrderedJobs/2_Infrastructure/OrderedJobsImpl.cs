using CodeKata_OrderedJobs.BL;
using System.Collections.Generic;
using System.Linq;

namespace CodeKata_OrderedJobs.Infrastructure
{
    public class OrderedJobsImpl : IOrderedJobs
    {
        private IDictionary<char, char?> jobs = new Dictionary<char, char?>();

        public void Register(char jobId, char dependsOn)
        {
            if (jobs.ContainsKey(dependsOn))
            {
                jobs.Add(jobId, jobs[dependsOn] - 1);
            }
        }

        public void Register(char jobId)
        {
            if (jobs.ContainsKey(jobId))
                return;

            jobs.Add(jobId, int.MaxValue);
        }

        public string Sort()
        {
            return new string(jobs.OrderBy(job => job.Value).Select(job => job.Key).ToArray());
        }
    }
}
