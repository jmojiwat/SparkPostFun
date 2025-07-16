using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;
using static SparkPostFun.ClientExtensions;

[assembly: InternalsVisibleTo("SparkPostFun.Tests")]

namespace SparkPostFun.Sending;

public static class TransmissionExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateTransmissionResponse>>>
        CreateTransmission(TransmissionRequest request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/transmissions/"
            let requestWithParsedRecipients = HandleCcAndBccRecipients(request)
            select env.Client.Post(requestUrl, requestWithParsedRecipients)
                .MapAsync(ToResponse<CreateTransmissionResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateTransmissionResponse>>>
        CreateTransmission(TransmissionRequest request, int maximumRecipientErrors)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/transmissions/?{maximumRecipientErrors}"
            let requestWithParsedRecipients = HandleCcAndBccRecipients(request)
            select env.Client.Post(requestUrl, requestWithParsedRecipients)
                .MapAsync(ToResponse<CreateTransmissionResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>>
        DeleteScheduledTransmissionsByCampaign(string campaignId)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/transmissions?campaign_id={campaignId}"
            select env.Client.Delete(requestUrl);
    }

    public static TransmissionRequest CreateTransmissionRequest(Recipient recipient, InlineContent content)
    {
        return new TransmissionRequest(recipient, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(IList<Recipient> recipients, InlineContent content)
    {
        return new TransmissionRequest(recipients, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(StoredRecipientList storedRecipientList,
        InlineContent content)
    {
        return new TransmissionRequest(storedRecipientList, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(Recipient recipient, StoredTemplateContent content)
    {
        return new TransmissionRequest(recipient, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(IList<Recipient> recipients,
        StoredTemplateContent content)
    {
        return new TransmissionRequest(recipients, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(StoredRecipientList storedRecipientList,
        StoredTemplateContent content)
    {
        return new TransmissionRequest(storedRecipientList, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(Recipient recipient, AbTestContent content)
    {
        return new TransmissionRequest(recipient, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(IList<Recipient> recipients, AbTestContent content)
    {
        return new TransmissionRequest(recipients, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(StoredRecipientList storedRecipientList,
        AbTestContent content)
    {
        return new TransmissionRequest(storedRecipientList, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(Recipient recipient, Rfc822TemplateContent content)
    {
        return new TransmissionRequest(recipient, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(IList<Recipient> recipients,
        Rfc822TemplateContent content)
    {
        return new TransmissionRequest(recipients, content);
    }

    public static TransmissionRequest CreateTransmissionRequest(StoredRecipientList storedRecipientList,
        Rfc822TemplateContent content)
    {
        return new TransmissionRequest(storedRecipientList, content);
    }

    public static TransmissionRequest WithCampaignId(this TransmissionRequest @this, string campaignId)
    {
        return @this with { CampaignId = campaignId };
    }

    public static TransmissionRequest
        WithContent(this TransmissionRequest @this, InlineContent content)
    {
        return @this with { Content = content };
    }

    public static TransmissionRequest
        WithContent(this TransmissionRequest @this, StoredTemplateContent content)
    {
        return @this with { Content = content };
    }

    public static TransmissionRequest
        WithContent(this TransmissionRequest @this, AbTestContent content)
    {
        return @this with { Content = content };
    }

    public static TransmissionRequest
        WithContent(this TransmissionRequest @this, Rfc822TemplateContent content)
    {
        return @this with { Content = content };
    }

    public static TransmissionRequest WithDescription(this TransmissionRequest @this, string description)
    {
        return @this with { Description = description };
    }

    public static TransmissionRequest WithMetadata(this TransmissionRequest @this,
        IDictionary<string, object> metadata)
    {
        return @this with { Metadata = metadata };
    }

    public static TransmissionRequest WithName(this TransmissionRequest @this, string name)
    {
        return @this with { Name = name };
    }

    public static TransmissionRequest WithOptions(this TransmissionRequest @this, TransmissionOptions options)
    {
        return @this with { Options = options };
    }

    public static TransmissionRequest WithRecipient(this TransmissionRequest @this, Recipient recipient)
    {
        var recipientList = TransmissionRequest.ToRecipientList(recipient);
        return @this with { Recipients = recipientList };
    }

    public static TransmissionRequest WithRecipients(this TransmissionRequest @this, IList<Recipient> recipients)
    {
        return @this with { Recipients = recipients };
    }

    public static TransmissionRequest WithReturnPath(this TransmissionRequest @this, string returnPath)
    {
        return @this with { ReturnPath = returnPath };
    }

    public static TransmissionRequest WithReturnPath(this TransmissionRequest @this, SenderAddress senderAddress)
    {
        return string.IsNullOrEmpty(senderAddress.Name)
            ? @this with { ReturnPath = senderAddress.Email }
            : @this with { ReturnPath = $"{senderAddress.Name} <{senderAddress.Email}>" };
    }

    public static TransmissionRequest WithStoredRecipientList(this TransmissionRequest @this,
        StoredRecipientList storedRecipientList)
    {
        return @this with { Recipients = storedRecipientList };
    }

    public static TransmissionRequest WithSubstitutionData(this TransmissionRequest @this,
        IDictionary<string, object> substitutionData)
    {
        return @this with { SubstitutionData = substitutionData };
    }


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

    internal static TransmissionRequest HandleCcAndBccRecipients(TransmissionRequest transmissionRequest)
    {
        return transmissionRequest.Recipients switch
        {
            IList<Recipient> recipients when transmissionRequest.Content is InlineContent content => transmissionRequest
                with
                {
                    Recipients = UpdateHeaderTo(recipients),
                    Content = AddContentCcHeader(content, recipients)
                },
            IList<Recipient> recipients => transmissionRequest with
            {
                Recipients = UpdateHeaderTo(recipients)
            },
            _ => transmissionRequest
        };
    }

    private static (IList<Recipient>, IList<Recipient>, IList<Recipient>) CategorizeRecipients(
        IList<Recipient> recipients)
    {
        var toRecipients = recipients.Filter(r => r.Type == RecipientType.To).ToList();
        var ccRecipients = recipients.Filter(r => r.Type == RecipientType.Cc).ToList();
        var bccRecipients = recipients.Filter(r => r.Type == RecipientType.Bcc).ToList();

        return (toRecipients, ccRecipients, bccRecipients);
    }

    private static InlineContent AddContentCcHeader(InlineContent content, IEnumerable<Recipient> recipients)
    {
        var ccRecipients = recipients.Filter(r => r.Type == RecipientType.Cc).ToList();

        if (ccRecipients.Any())
        {
            var ccHeader = ccRecipients.Map(r => r.Address.Email).Apply(es => string.Join(',', es));
            var contentWithHeaders = content.Headers == null
                ? content with { Headers = new Dictionary<string, string>() }
                : content;

            contentWithHeaders.Headers["CC"] = ccHeader;

            return contentWithHeaders;
        }

        return content;
    }

    private static Recipient ToCcOrBccTransmissionRecipient(string primaryEmail, Recipient recipient)
    {
        return recipient with
        {
            Address = recipient.Address with { HeaderTo = primaryEmail }
        };
    }
}