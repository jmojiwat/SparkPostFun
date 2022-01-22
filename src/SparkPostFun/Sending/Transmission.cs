namespace SparkPostFun.Sending;

public record Transmission
{
    public Transmission(Recipient recipient, InlineContent content)
    {
        var recipientList = ToRecipientList(recipient);
        Recipients = recipientList;
        Content = content;
    }

    public Transmission(IList<Recipient> recipients, InlineContent content)
    {
        Recipients = recipients;
        Content = content;
    }

    public Transmission(StoredRecipientList storedRecipientList, InlineContent content)
    {
        Recipients = storedRecipientList;
        Content = content;
    }

    public Transmission(Recipient recipient, StoredTemplateContent content)
    {
        var recipientList = ToRecipientList(recipient);
        Recipients = recipientList;
        Content = content;
    }

    public Transmission(IList<Recipient> recipients, StoredTemplateContent content)
    {
        Recipients = recipients;
        Content = content;
    }

    public Transmission(StoredRecipientList storedRecipientList, StoredTemplateContent content)
    {
        Recipients = storedRecipientList;
        Content = content;
    }

    public Transmission(Recipient recipient, AbTestContent content)
    {
        var recipientList = ToRecipientList(recipient);
        Recipients = recipientList;
        Content = content;
    }

    public Transmission(IList<Recipient> recipients, AbTestContent content)
    {
        Recipients = recipients;
        Content = content;
    }

    public Transmission(StoredRecipientList storedRecipientList, AbTestContent content)
    {
        Recipients = storedRecipientList;
        Content = content;
    }

    public Transmission(Recipient recipient, Rfc822TemplateContent content)
    {
        var recipientList = ToRecipientList(recipient);
        Recipients = recipientList;
        Content = content;
    }

    public Transmission(IList<Recipient> recipients, Rfc822TemplateContent content)
    {
        Recipients = recipients;
        Content = content;
    }

    public Transmission(StoredRecipientList storedRecipientList, Rfc822TemplateContent content)
    {
        Recipients = storedRecipientList;
        Content = content;
    }

    public TransmissionOptions Options { get; init; }
    public object Recipients { get; init; }
    public object Content { get; init; }
    public string CampaignId { get; init; }
    public string Description { get; init; }
    public IDictionary<string, object> Metadata { get; init; } = new Dictionary<string, object>();
    public IDictionary<string, object> SubstitutionData { get; init; } = new Dictionary<string, object>();
    public string ReturnPath { get; init; }

    internal static IList<Recipient> ToRecipientList(Recipient recipient)
    {
        var recipientList = new List<Recipient> { recipient };
        return recipientList;
    }
}