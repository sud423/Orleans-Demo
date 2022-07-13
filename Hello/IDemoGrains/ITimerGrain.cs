using Orleans;

namespace IDemoGrains
{
    public interface ITimerGrain : IGrainWithIntegerKey
    {
        Task Start();
        Task Finish();
    }

}
