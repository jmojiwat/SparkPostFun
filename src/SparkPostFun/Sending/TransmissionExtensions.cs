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

    public static Transmission WithName(this Transmission @this, string name) =>
        @this with { Name = name };

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


    private static IEnumerable<Recipient> UpdateHeaderTo(IList<Recipient> recipients)
    {
        var (to, cc, bcc) = CategorizeRecipients(recipients);

        var firstToRecipientEmail = to.Map(r => r.Address.Email).HeadOrNone().IfNone("null");
        
        var ccRecipients = cc
            .Filter(r => r.Type == RecipientType.Cc)
            .Map(r => ToCcOrBccTransmissionRecipient(firstToRecipientEmail, r))
            .ToList();
        
        var bccRecipients = bcc
            .Filter(r => r.Type == RecipientType.Bcc)
            .Map(r => ToCcOrBccTransmissionRecipient(firstToRecipientEmail, r));
            
        return to.Concat(ccRecipients).Concat(bccRecipients);
    }
    
    internal static Transmission HandleCcAndBccRecipients(Transmission transmission)
    {
        return transmission.Recipients switch
        {
            IList<Recipient> recipients when transmission.Content is InlineContent content => transmission with
            {
                Recipients = UpdateHeaderTo(recipients), 
                Content = AddContentCcHeader(content, recipients)
            },
            IList<Recipient> recipients => transmission with
            {
                Recipients = UpdateHeaderTo(recipients)
            },
            _ => transmission
        };

    }
    
    private static (IList<Recipient>, IList<Recipient>, IList<Recipient>) CategorizeRecipients(IList<Recipient> recipients)
    {
        var toRecipients = recipients.Filter(r => r.Type == RecipientType.To).ToList();
        var ccRecipients = recipients.Filter(r => r.Type == RecipientType.Cc).ToList();
        var bccRecipients = recipients.Filter(r => r.Type == RecipientType.Bcc).ToList();
        
        return (toRecipients, ccRecipients, bccRecipients);
    }

    private static InlineContent AddContentCcHeader(InlineContent content, IEnumerable<Recipient> recipients)
    {
        var ccRecipients = recipients.Filter(r => r.Type == RecipientType.Cc).ToList();
        
        if(ccRecipients.Any())
        {
            var ccHeader = ccRecipients.Map(r => r.Address.Email).Apply(es => string.Join(',', es));
            var contentWithHeaders = content.Headers == null
                ? content with { Headers = new Dictionary<string, string>() } 
                : content;
            
            contentWithHeaders.Headers["CC"] = ccHeader;

            return contentWithHeaders; 
        }
        else
        {
            return content;
        }
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