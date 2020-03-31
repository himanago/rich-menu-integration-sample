using System;

namespace RichMenuIntegrationSample
{
    public class Settings
    {
        public string ChannelSecret { get; } = Environment.GetEnvironmentVariable("ChannelSecret");
        public string ChannelAccessToken { get; } = Environment.GetEnvironmentVariable("ChannelAccessToken");
    }
}
