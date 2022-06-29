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

Console.ReadKey();