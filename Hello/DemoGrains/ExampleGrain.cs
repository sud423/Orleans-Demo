using IDemoGrains;
using Orleans;

namespace DemoGrains
{
    public class ExampleGrain : Grain, IExampleGrain
    {
        public Task<long> GetKey()
        {
            Console.WriteLine(this.GetGrainIdentity());

            return Task.FromResult(this.GetPrimaryKeyLong());
        }
    }
}
