using System.Collections.Generic;

namespace CodeKata_OrderedJobs.BL
{
    public class OrderedJobsImpl : IOrderedJobs
    {
        private readonly ICollection<char> _jobIds = new List<char>();
        private readonly IDictionary<char, ICollection<char>> _rules = new Dictionary<char, ICollection<char>>();

        public void Register(char jobId, char dependsOn)
        {
            Register(jobId);
            if (_rules.ContainsKey(jobId))
                _rules[jobId].Add(dependsOn);
            else
                _rules[jobId] = new List<char> {dependsOn};
        }

        public void Register(char jobId)
        {
            if (!_jobIds.Contains(jobId))
                _jobIds.Add(jobId);
        }

        public string Sort() 
            => new JobSorter(_jobIds, _rules).Sort();
    }
}