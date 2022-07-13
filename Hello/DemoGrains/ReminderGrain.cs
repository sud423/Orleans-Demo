using IDemoGrains;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;

namespace DemoGrains
{
    public class ReminderGrain : Grain, IReminderGrain, IRemindable
    {
        private IGrainReminder? reminder;
        private readonly ILogger logger;


        public ReminderGrain(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
        }
        public Task Cancel()
        {
            if (reminder != null)
            {
                logger.LogInformation($"结束 Reminider --{DateTime.Now}\n");
                UnregisterReminder(reminder);
            }

            return Task.CompletedTask;
        }

        public async Task Execute()
        {
            reminder = await RegisterOrUpdateReminder("Reminder Demo", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(60));
            //return Task.CompletedTask;
        }

        public Task ReceiveReminder(string reminderName, TickStatus status)
        {
            logger.LogInformation($"执行 Reminider --{DateTime.Now}\n");
            return Task.CompletedTask;
        }
    }
}
