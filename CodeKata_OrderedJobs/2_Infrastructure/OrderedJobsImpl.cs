using CodeKata_OrderedJobs.BL;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeKata_OrderedJobs.Infrastructure
{
    public class OrderedJobsImpl : IOrderedJobs
    {
        private List<char> jobs = new List<char>();
        private Dictionary<char, List<char>> rules = new Dictionary<char, List<char>>();
        private Dictionary<char, int> orderedJobs = new Dictionary<char, int>();
        private List<char> finished = new List<char>();
        private StringBuilder output = new StringBuilder();

        public void Register(char jobId, char dependsOn)
        {
            Register(jobId);
            if (rules.ContainsKey(jobId))
            {
                rules[jobId].Add(dependsOn);
            }
            else
            {
                rules[jobId] = new List<char>() { dependsOn };
            }
        }

        public void Register(char jobId)
        {
            if (!jobs.Contains(jobId))
                jobs.Add(jobId);
        }

        public string Sort()
        {
            output.Clear();
            foreach(var job in jobs)
            {
                Create(job);
            }
            return output.ToString();
        }

        private void Create(char c)
        {
            if (finished.Contains(c)) return;
            if (rules.ContainsKey(c))
            {
                foreach (var rule in rules[c])
                {
                    Create(rule);
                }
            }
            output.Append(c);
            finished.Add(c);
        }
    }
}
