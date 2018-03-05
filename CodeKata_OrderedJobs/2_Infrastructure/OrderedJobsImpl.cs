using CodeKata_OrderedJobs.BL;
using CodeKata_OrderedJobs.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CodeKata_OrderedJobs.Infrastructure
{
    public class OrderedJobsImpl : IOrderedJobs
    {
        private TreeNode<char> jobsRoot = new TreeNode<char>(' ');
        

        public void Register(char jobId, char dependsOn)
        {
            jobsRoot.Search(jobId).AddChild(dependsOn);
        }

        public void Register(char jobId)
        {
            jobsRoot.AddChild(jobId);
        }

        public string Sort()
        {
            
        }
    }
}
