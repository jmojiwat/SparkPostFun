using System.Runtime.CompilerServices;
using LanguageExt;

[assembly: InternalsVisibleTo("SparkPostFun.Tests")]

namespace SparkPostFun.Sending
{
    public static class TransmissionExtensions
    {
        public static CreateTransmission CreateTransmission() => new();

        public static CreateTransmission WithCampaignId(this CreateTransmission @this, string campaignId) =>
            @this with { CampaignId = campaignId };

        public static CreateTransmission
            WithContent(this CreateTransmission @this, InlineContent content) =>
            @this with { Content = content };

        public static CreateTransmission
            WithContent(this CreateTransmission @this, StoredTemplateContent content) =>
            @this with { Content = content };

        public static CreateTransmission
            WithContent(this CreateTransmission @this, AbTestContent content) =>
            @this with { Content = content };

        public static CreateTransmission
            WithContent(this CreateTransmission @this, Rfc822TemplateContent content) =>
            @this with { Content = content };

        public static CreateTransmission WithDescription(this CreateTransmission @this, string description) =>
            @this with { Description = description };

        public static CreateTransmission WithMetadata(this CreateTransmission @this,
            IDictionary<string, object> metadata) =>
            @this with { Metadata = metadata };

        public static CreateTransmission WithOptions(this CreateTransmission @this, TransmissionOptions options) =>
            @this with { Options = options };

        public static CreateTransmission WithRecipient(this CreateTransmission @this, Recipient recipient)
        {
            var recipientList = new TransmissionRecipientList();
            recipientList.Recipients.Add(recipient);
            return @this with { Recipients = recipientList };
        }

        public static CreateTransmission WithRecipients(this CreateTransmission @this, IList<Recipient> recipients) =>
            @this with { Recipients = recipients };

        public static CreateTransmission WithReturnPath(this CreateTransmission @this, string returnPath) =>
            @this with { ReturnPath = returnPath };

        public static CreateTransmission WithStoredRecipientList(this CreateTransmission @this,
            StoredRecipientList storedRecipientList) =>
            @this with { Recipients = storedRecipientList };

        public static CreateTransmission WithSubstitutionData(this CreateTransmission @this,
            IDictionary<string, object> substitutionData) =>
            @this with { SubstitutionData = substitutionData };

        internal static CreateTransmission ParseTransmission(CreateTransmission transmission)
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
            var parsedccRecipients = primaryRecipientEmail
                .Bind(e => ccRecipients.Map(ccr => ToCcOrBccTransmissionRecipient(e, ccr))).ToList();
            var parsedBccRecipients = primaryRecipientEmail
                .Bind(e => bccRecipients.Map(bcc => ToCcOrBccTransmissionRecipient(e, bcc))).ToList();

            var parsedRecipients = toRecipients.Concat(parsedccRecipients).Concat(parsedBccRecipients);
            var ccHeader = ccRecipients.Map(r => r.Address.Email).Apply(es => string.Join(",", es));
            return (parsedRecipients, ccHeader);
        }

        private static Recipient ToCcOrBccTransmissionRecipient(string primaryEmail, Recipient recipient) =>
            recipient with
            {
                Address = new Address
                {
                    Email = recipient.Address.Email,
                    Name = recipient.Address.Name,
                    HeaderTo = primaryEmail
                }
            };
    }
}