using CodeKata_OrderedJobs.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeKata_OrderedJobs.Infrastructure
{
    public class OrderedJobsImpl : IOrderedJobs
    {
        private ICollection<char> jobIds = new List<char>();
        private IDictionary<char, List<char>> rules = new Dictionary<char, List<char>>();

        private ICollection<char> finished = new List<char>();
        private Stack<char> processingStack = new Stack<char>();

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
            if (!jobIds.Contains(jobId))
                jobIds.Add(jobId);
        }

        public string Sort()
        {
            var stringBuilder = new StringBuilder();
            foreach(var job in jobIds)
            {
                Process(job, stringBuilder);
            }
            return stringBuilder.ToString();
        }

        private void Process(char c, StringBuilder stringBuilder)
        {
            if (processingStack.Contains(c))
                throw new InvalidOperationException("Circular dependency!");

            processingStack.Push(c);
            InternalProcess(c, stringBuilder);
            processingStack.Pop();
        }

        private void InternalProcess(char c, StringBuilder stringBuilder)
        {
            if (finished.Contains(c))
                return;

            if (rules.ContainsKey(c))
            {
                foreach (var ruleJobId in rules[c])
                {
                    Process(ruleJobId, stringBuilder);
                }
            }
            stringBuilder.Append(c);
            finished.Add(c);
        }
    }
}
