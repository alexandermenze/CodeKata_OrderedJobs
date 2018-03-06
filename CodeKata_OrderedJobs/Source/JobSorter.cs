using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata_OrderedJobs.Source
{
    internal class JobSorter
    {
        private readonly ICollection<char> _finished = new List<char>();
        private readonly IEnumerable<char> _jobIds;
        private readonly Stack<char> _processingStack = new Stack<char>();
        private readonly IDictionary<char, ICollection<char>> _rules;

        public JobSorter(IEnumerable<char> jobIds, IDictionary<char, ICollection<char>> rulesDictionary)
        {
            _jobIds = jobIds;
            _rules = rulesDictionary;
        }

        public string Sort()
        {
            _processingStack.Clear();
            _finished.Clear();

            var stringBuilder = new StringBuilder();
            foreach (var job in _jobIds)
                Process(job, stringBuilder);

            return stringBuilder.ToString();
        }

        private void Process(char c, StringBuilder stringBuilder)
        {
            if (_processingStack.Contains(c))
                throw new InvalidOperationException("Circular dependency!");

            _processingStack.Push(c);
            InternalProcess(c, stringBuilder);
            _processingStack.Pop();
        }

        private void InternalProcess(char c, StringBuilder stringBuilder)
        {
            if (_finished.Contains(c))
                return;

            if (_rules.ContainsKey(c))
                foreach (var ruleJobId in _rules[c])
                    Process(ruleJobId, stringBuilder);

            stringBuilder.Append(c);
            _finished.Add(c);
        }
    }
}