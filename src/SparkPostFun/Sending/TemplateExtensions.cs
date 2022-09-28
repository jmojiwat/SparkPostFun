using System.Text.Json;

namespace SparkPostFun.Sending
{
    public static class TemplateExtensions
    {
        public static SenderAddress ParseTemplateContentFrom(TemplateContent content) =>
            content.From switch
            {
                SenderAddress sender => sender,
                string email => new SenderAddress(email),
                JsonElement element => new SenderAddress(
                    element.GetProperty("email").GetString())
                {
                    Name = element.GetProperty("name").GetString()
                },
                _ => new SenderAddress(string.Empty)
            };
    }
}