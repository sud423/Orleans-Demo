using Orleans;

namespace IDemoGrains
{
    public interface IExampleGrain : IGrainWithIntegerKey
    {

        Task<long> GetKey();

    }
}
