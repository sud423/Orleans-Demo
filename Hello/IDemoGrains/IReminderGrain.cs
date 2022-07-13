using Orleans;

namespace IDemoGrains
{
    public interface IReminderGrain : IGrainWithIntegerKey
    {
        Task Execute();
        Task Cancel();
    }
}
