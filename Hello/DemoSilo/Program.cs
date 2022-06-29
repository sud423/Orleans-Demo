// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Logging;
using DemoGrains;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

// 配置 host
using var host = new SiloHostBuilder()
    //对单个本地 silo 使用 localhost 集群
    .UseLocalhostClustering()
    //配置集群Id 和 服务Id
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "dev";
        options.ServiceId = "YldDemoService";
    })
    //应用程序部分：只需引用我们使用的 Grains 实现
    .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(HelloGrain).Assembly).WithReferences())
    //配置日志输出到控制台
    .ConfigureLogging(logging => logging.AddConsole())
    //创建 silo
    .Build();

// 启动 host
await host.StartAsync();

Console.WriteLine("\n\n 按 Enter 终止...\n\n");
Console.ReadLine();

await host.StopAsync();

