using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    internal static class TransmissionRecipientExtensions
    {
        internal static Recipient WithAddress(this Recipient @this, Address address) =>
            @this with { Address = address };

        internal static Recipient WithMetadata(this Recipient @this, IDictionary<string, object> metadata) =>
            @this with { Metadata = metadata };

        internal static Recipient WithReturnPath(this Recipient @this, string returnPath) =>
            @this with { ReturnPath = returnPath };

        internal static Recipient WithSubstitutionData(this Recipient @this, IDictionary<string, object> substitutionData) =>
            @this with { Metadata = substitutionData };

        internal static Recipient WithTags(this Recipient @this, IList<string> tags) =>
            @this with { Tags = tags };
    }
}