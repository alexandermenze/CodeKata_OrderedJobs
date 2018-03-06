namespace CodeKata_OrderedJobs.Source
{
    public interface IOrderedJobs
    {
        void Register(char dependentJob, char independentJob);
        void Register(char job);

        string Sort();

        string Sort(string registrations);
    }
}