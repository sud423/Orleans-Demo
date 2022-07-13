using IDemoGrains;
using Microsoft.Extensions.Logging;
using Orleans;

namespace DemoGrains
{
    public class HelloGrain : Grain, IHelloGrain
    {
        private readonly ILogger logger;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
        }


        public Task<string> SayHello(string msg)
        {
            logger.LogInformation($"\n SayHello 方法收到客户端发来的消息：'{msg}'");

            return Task.FromResult($"客户端发了消息，你不回点都不好意思了。\n来而不往非礼也");
        }
    }
}