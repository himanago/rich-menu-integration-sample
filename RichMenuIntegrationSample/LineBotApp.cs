using LineDC.Messaging;
using LineDC.Messaging.Messages;
using LineDC.Messaging.Webhooks;
using LineDC.Messaging.Webhooks.Events;
using Newtonsoft.Json;
using RichMenuIntegrationSample.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichMenuIntegrationSample
{
    public class LineBotApp : WebhookApplication
    {
        private ILineMessagingClient LineMessagingClient { get; }

        public LineBotApp(ILineMessagingClient lineMessagingClient, Settings settings)
            : base(lineMessagingClient, settings.ChannelSecret)
        {
            LineMessagingClient = lineMessagingClient;
        }

        protected override async Task OnPostbackAsync(PostbackEvent ev)
        {
            // Postback で送信されたデータを共通のモデルクラスに変換
            var animal = JsonConvert.DeserializeObject<Animal>(ev.Postback.Data);

            // icon / nickname switch を使用して返信
            await LineMessagingClient.ReplyMessageAsync(ev.ReplyToken, new List<ISendMessage>
            {
                new TextMessage(
                    animal.Sound, null,
                    new Sender(animal.Name, $"{Environment.GetEnvironmentVariable("ImageBaseUrl")}/{animal.IconFileName}"))
            });
        }
    }
}
