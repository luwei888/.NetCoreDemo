using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NetCoreDemo
{
    public class Program
    {
        /// <summary>
        /// Main方法，程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            CreateWebHostBuilder(args) //调用下面的方法，返回一个IWebHostBuilder对象
                .Build()//用上面创建的IWebHostBuilder对象创建一个IWebHost
                        //Runs a web application and block the calling thread until host shutdown.
                .Run();//Run9()为IWebHost扩展方法运行web程序换句话说就是启动一个一直运行监听http请求的任务
        }
        //使用默认的配置信息来初始化一个新的IWebHostBuilder实例
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)//使用默认的配置信息来初始化一个新的IWebHostBuilder实例
            .ConfigureAppConfiguration((hostingtext, config) =>
            {
                var env = hostingtext.HostingEnvironment;

                config.AddJsonFile("appsettings.json", true, true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                      .AddJsonFile("Content.json", false, false)
                      .AddEnvironmentVariables();
            })
            .UseStartup<Startup>();//为Web Host指定了Startup类
    }
}
