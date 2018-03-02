namespace CodeKata_OrderedJobs.BL
{
    public interface IOrderedJobs
    {
        void Register(char dependentJob, char independentJob);
        void Register(char job);

        string Sort();
    }
}
