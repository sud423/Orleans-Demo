using Orleans;

namespace IDemoGrains
{
    public interface IHelloGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string msg);
    }
}