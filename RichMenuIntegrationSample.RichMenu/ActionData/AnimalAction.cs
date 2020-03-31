using Newtonsoft.Json;
using RichMenuIntegrationSample.Models;

namespace XamlRichMenuMaker.ActionData
{
    public static class AnimalAction
    {
        public static string Cat { get; } = JsonConvert.SerializeObject(new Animal
        {
            Name = "ねこ",
            Sound = "にゃーん",
            IconFileName = "cat.png"           
        });

        public static string Dog { get; } = JsonConvert.SerializeObject(new Animal
        {
            Name = "いぬ",
            Sound = "わんわん",
            IconFileName = "dog.png"
        });
    }
}
