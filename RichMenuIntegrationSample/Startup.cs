using LineDC.Messaging;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


[assembly: FunctionsStartup(typeof(RichMenuIntegrationSample.Startup))]
namespace RichMenuIntegrationSample
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddSingleton<Settings>()
                .AddSingleton<LineBotApp>(s =>
                    new LineBotApp(LineMessagingClient.Create(s.GetService<Settings>().ChannelAccessToken), s.GetService<Settings>()));
        }               
    }
}
