using System.Collections.Generic;

namespace CodeKata_OrderedJobs.Domain
{
    struct Job
    {
        public char Identifier { get; }

        public char? DependantJob { get; }

        public Job(char id, char? dependsOn = null)
        {
            Identifier = id;
            DependantJob = dependsOn;
        }
    }
}
