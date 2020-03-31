using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace RichMenuIntegrationSample
{
    public class WebhookFunction
    {
        private LineBotApp LineBotApp { get; }

        public WebhookFunction(LineBotApp lineBotApp)
        {
            LineBotApp = lineBotApp;
        }

        [FunctionName(nameof(WebhookFunction))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            await LineBotApp.RunAsync(req.Headers["x-line-signature"], body);

            return new OkResult();
        }
    }
}
