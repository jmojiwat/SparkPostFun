namespace SparkPostFun.Receiving;

public record RelayWebhookMatch(string Domain)
{
    public static string Protocol => "SMTP";
}
