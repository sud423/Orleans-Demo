using IDemoGrains;
using Microsoft.Extensions.Logging;
using Orleans;

namespace DemoGrains
{
    public class TimerGrain : Grain, ITimerGrain
    {
        private readonly ILogger logger;

        private IDisposable? disposable;

        public TimerGrain(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
        }

        public Task Start()
        {
            disposable = RegisterTimer(o =>
            {
                logger.LogInformation($"time tick = {DateTime.Now}\n ");
                return Task.CompletedTask;
            }, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task Finish()
        {
            if (disposable != null)
            {
                logger.LogInformation($"计时器停止--{DateTime.Now}\n ");
                disposable.Dispose();
                disposable = null;
            }

            return Task.CompletedTask;
        }
    }
}
