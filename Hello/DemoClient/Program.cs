// See https://aka.ms/new-console-template for more information
using IDemoGrains;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;

using var client = new ClientBuilder()
    // 这里配置与 Silo 相同
    .UseLocalhostClustering()
    //与 Silo 配置的服务一样，否则客户端会连接失败
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "dev";
        options.ServiceId = "YldDemoService";
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .Build();


await client.Connect();


var helloGrain = client.GetGrain<IHelloGrain>(1);
var response = await helloGrain.SayHello("你好, Grain！" );
Console.WriteLine("\n\n{0}\n\n", response);



Console.WriteLine();
Console.WriteLine("========================");
Console.WriteLine("Grain Identity 获取 key");
for (int i = 0; i < 5; i++)
{

    var exampleGrain = client.GetGrain<IExampleGrain>(i);
    var key = await exampleGrain.GetKey();
    Console.WriteLine("key = " + exampleGrain.GetGrainIdentity());


}


Console.WriteLine();
Console.WriteLine("========================");
Console.WriteLine("Timer 启动--" + DateTime.Now);
var timerGrain = client.GetGrain<ITimerGrain>(1);
await timerGrain.Start();

Console.WriteLine("待待 10 秒 ...");
Thread.Sleep(10000);

Console.WriteLine("Timer 停止--" + DateTime.Now);
await timerGrain.Finish();




Console.WriteLine();
Console.WriteLine("========================");
Console.WriteLine("Reminder 启动--"+DateTime.Now);

var reminderGrain = client.GetGrain<IReminderGrain>(1);
await reminderGrain.Execute();

Console.WriteLine("待待 120 秒 ...");
Thread.Sleep(120000);

Console.WriteLine("Reminder 停止--" + DateTime.Now);
await reminderGrain.Cancel();

Console.ReadKey();