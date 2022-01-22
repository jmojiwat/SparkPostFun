using System.Runtime.CompilerServices;
using LanguageExt;

[assembly: InternalsVisibleTo("SparkPostFun.Tests")]

namespace SparkPostFun.Sending;

public static class TransmissionExtensions
{
    public static Transmission CreateTransmission(Recipient recipient, InlineContent content) => new(recipient, content);

    public static Transmission CreateTransmission(IList<Recipient> recipients, InlineContent content) => new(recipients, content);

    public static Transmission CreateTransmission(StoredRecipientList storedRecipientList, InlineContent content) => new(storedRecipientList, content);

    public static Transmission CreateTransmission(Recipient recipient, StoredTemplateContent content) => new(recipient, content);

    public static Transmission CreateTransmission(IList<Recipient> recipients, StoredTemplateContent content) => new(recipients, content);

    public static Transmission CreateTransmission(StoredRecipientList storedRecipientList, StoredTemplateContent content) => new(storedRecipientList, content);

    public static Transmission CreateTransmission(Recipient recipient, AbTestContent content) => new(recipient, content);

    public static Transmission CreateTransmission(IList<Recipient> recipients, AbTestContent content) => new(recipients, content);

    public static Transmission CreateTransmission(StoredRecipientList storedRecipientList, AbTestContent content) => new(storedRecipientList, content);

    public static Transmission CreateTransmission(Recipient recipient, Rfc822TemplateContent content) => new(recipient, content);

    public static Transmission CreateTransmission(IList<Recipient> recipients, Rfc822TemplateContent content) => new(recipients, content);

    public static Transmission CreateTransmission(StoredRecipientList storedRecipientList, Rfc822TemplateContent content) => new(storedRecipientList, content);

    public static Transmission WithCampaignId(this Transmission @this, string campaignId) =>
        @this with { CampaignId = campaignId };

    public static Transmission
        WithContent(this Transmission @this, InlineContent content) =>
        @this with { Content = content };

    public static Transmission
        WithContent(this Transmission @this, StoredTemplateContent content) =>
        @this with { Content = content };

    public static Transmission
        WithContent(this Transmission @this, AbTestContent content) =>
        @this with { Content = content };

    public static Transmission
        WithContent(this Transmission @this, Rfc822TemplateContent content) =>
        @this with { Content = content };

    public static Transmission WithDescription(this Transmission @this, string description) =>
        @this with { Description = description };

    public static Transmission WithMetadata(this Transmission @this,
        IDictionary<string, object> metadata) =>
        @this with { Metadata = metadata };

    public static Transmission WithOptions(this Transmission @this, TransmissionOptions options) =>
        @this with { Options = options };

    public static Transmission WithRecipient(this Transmission @this, Recipient recipient)
    {
        var recipientList = Transmission.ToRecipientList(recipient);
        return @this with { Recipients = recipientList };
    }

    public static Transmission WithRecipients(this Transmission @this, IList<Recipient> recipients) =>
        @this with { Recipients = recipients };

    public static Transmission WithReturnPath(this Transmission @this, string returnPath)
    {
        return @this with { ReturnPath = returnPath };
    }

    public static Transmission WithReturnPath(this Transmission @this, SenderAddress senderAddress)
    {
        return string.IsNullOrEmpty(senderAddress.Name)
            ? @this with { ReturnPath = senderAddress.Email }
            : @this with { ReturnPath = $"{senderAddress.Name} <{senderAddress.Email}>" };
    }

    public static Transmission WithStoredRecipientList(this Transmission @this,
        StoredRecipientList storedRecipientList) =>
        @this with { Recipients = storedRecipientList };

    public static Transmission WithSubstitutionData(this Transmission @this,
        IDictionary<string, object> substitutionData) =>
        @this with { SubstitutionData = substitutionData };

    internal static Transmission ParseTransmission(Transmission transmission)
    {
        if (transmission.Recipients is IList<Recipient> recipients)
        {
            var (parsedRecipients, ccHeader) = CategorizeRecipients(recipients);

            switch (transmission.Content)
            {
                case InlineContent content when !string.IsNullOrEmpty(ccHeader):
                {
                    if (content.Headers.ContainsKey("cc"))
                    {
                        content.Headers["cc"] = ccHeader;
                    }
                    else
                    {
                        content.Headers.Add("cc", ccHeader);
                    }

                    break;
                }
            }

            return transmission with { Recipients = parsedRecipients };
        }

        return transmission;
    }

    private static (IEnumerable<Recipient> recipients, string ccHeader) CategorizeRecipients(
        IList<Recipient> recipients)
    {
        var toRecipients = recipients.Filter(r => r.Type == RecipientType.To).ToList();
        var ccRecipients = recipients.Filter(r => r.Type == RecipientType.Cc);
        var bccRecipients = recipients.Filter(r => r.Type == RecipientType.Bcc);

        var primaryRecipientEmail = toRecipients.Map(r => r.Address.Email).HeadOrNone();
        var parsedCcRecipients = primaryRecipientEmail
            .Bind(e => ccRecipients.Map(ccr => ToCcOrBccTransmissionRecipient(e, ccr))).ToList();
        var parsedBccRecipients = primaryRecipientEmail
            .Bind(e => bccRecipients.Map(bcc => ToCcOrBccTransmissionRecipient(e, bcc))).ToList();

        var parsedRecipients = toRecipients.Concat(parsedCcRecipients).Concat(parsedBccRecipients);
        var ccHeader = ccRecipients.Map(r => r.Address.Email).Apply(es => string.Join(",", es));
        return (parsedRecipients, ccHeader);
    }

    private static Recipient ToCcOrBccTransmissionRecipient(string primaryEmail, Recipient recipient) =>
        recipient with
        {
            Address = new Address(recipient.Address.Email)
            {
                Name = recipient.Address.Name,
                HeaderTo = primaryEmail
            }
        };
}