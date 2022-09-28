using System;

namespace SparkPostFun.Analytics
{
    public record BounceEvent
    {
        /// <summary>
        ///     Indicates whether or not amp format was enabled.
        /// </summary>
        public bool AmpEnabled { get; init; }

        /// <summary>
        ///     Classification code for a given message (see Bounce Classification Codes).
        /// </summary>
        public int BounceClass { get; init; }

        /// <summary>
        ///     Campaign of which this message was a part.
        /// </summary>
        public string CampaignId { get; init; }

        /// <summary>
        ///     Indicates whether or not click tracking was enabled.
        /// </summary>
        public bool ClickTracking { get; init; }

        /// <summary>
        ///     SparkPost-customer identifier through which this message was sent.
        /// </summary>
        public string CustomerId { get; init; }

        /// <summary>
        ///     Protocol by which SparkPost delivered this message.
        /// </summary>
        public string DeliveryMethod { get; init; }

        /// <summary>
        ///     Token of the device / application targeted by this PUSH notification message. Applies only when delv_method is gcm
        ///     or apn.
        /// </summary>
        public string DeviceToken { get; init; }

        /// <summary>
        ///     Error code by which the remote server described a failed delivery attempt.
        /// </summary>
        public string ErrorCode { get; init; }

        /// <summary>
        ///     Unique event identifier.
        /// </summary>
        public string EventId { get; init; }

        /// <summary>
        ///     Friendly sender or 'From' header in the original email.
        /// </summary>
        public string FriendlyFrom { get; init; }

        /// <summary>
        ///     Indicates whether or not initial open pixel tracking was enabled.
        /// </summary>
        public bool InitialPixel { get; init; }

        /// <summary>
        ///     Time at which this message was injected into SparkPost.
        /// </summary>
        public DateTime InjectionTime { get; init; }

        /// <summary>
        ///     IP address of the host to which SparkPost delivered this message; in engagement events, the IP address of the host
        ///     where the HTTP request originated.
        /// </summary>
        public string IpAddress { get; init; }

        /// <summary>
        ///     IP pool through which this message was sent.
        /// </summary>
        public string IpPool { get; init; }

        /// <summary>
        ///     Mailbox Provider of the recipient.
        /// </summary>
        public string MailboxProvider { get; init; }

        /// <summary>
        ///     Region of the Mailbox Provider.
        /// </summary>
        public string MailboxProviderRegion { get; init; }

        /// <summary>
        ///     SparkPost-cluster-wide unique identifier for this message.
        /// </summary>
        public string MessageId { get; init; }


        /// <summary>
        ///     Sender address used on this message's SMTP envelope.
        /// </summary>
        public string MessageFrom { get; init; }

        /// <summary>
        ///     Message's size in bytes.
        /// </summary>
        public string MessageSize { get; init; }

        /// <summary>
        ///     Number of failed attempts before this message was successfully delivered; when the first attempt succeeds, zero.
        /// </summary>
        public string NumberOfRetries { get; init; }

        /// <summary>
        ///     Indicates whether or not open tracking was enabled.
        /// </summary>
        public string OpenTracking { get; init; }

        /// <summary>
        ///     Metadata describing the message recipient.
        /// </summary>
        public string RecipientMetadata { get; init; }

        /// <summary>
        ///     Tags applied to the message which generated this event.
        /// </summary>
        public string RecipientTags { get; init; }

        /// <summary>
        ///     Lowercase version of recipient address used on this message's SMTP envelope.
        /// </summary>
        public string RecipientTo { get; init; }

        /// <summary>
        ///     Hashed version of recipient address used on this message's SMTP envelope.
        /// </summary>
        public string RecipientHash { get; init; }

        /// <summary>
        ///     Actual recipient address used on this message's SMTP envelope.
        /// </summary>
        public string RawRecipientTo { get; init; }

        /// <summary>
        ///     Indicates that a recipient address appeared in the Cc or Bcc header or the archive JSON array.
        /// </summary>
        public string RecipientType { get; init; }

        /// <summary>
        ///     Unmodified, exact response returned by the remote server due to a failed delivery attempt.
        /// </summary>
        public string RawReason { get; init; }

        /// <summary>
        ///     Canonicalized text of the response returned by the remote server due to a failed delivery attempt.
        /// </summary>
        public string Reason { get; init; }

        /// <summary>
        ///     Domain part of the recipient address used on this message's SMTP envelope.
        /// </summary>
        public string RecipientDomain { get; init; }

        /// <summary>
        ///     Protocol by which SparkPost received this message.
        /// </summary>
        public string ReceivingMethod { get; init; }

        /// <summary>
        ///     Domain receiving this message.
        /// </summary>
        public string RoutingDomain { get; init; }

        /// <summary>
        ///     Time at which the email was scheduled to be sent.
        /// </summary>
        public string ScheduledTime { get; init; }

        /// <summary>
        ///     Domain part of the sender or 'From' header in the original email.
        /// </summary>
        public string SendingDomain { get; init; }

        /// <summary>
        ///     IP address through which this message was sent.
        /// </summary>
        public string SendingIp { get; init; }

        /// <summary>
        ///     Data encoding used in the SMS message.
        /// </summary>
        public string SmsCoding { get; init; }

        /// <summary>
        ///     SMS destination address.
        /// </summary>
        public string SmsDestination { get; init; }

        /// <summary>
        ///     Destination numbering plan identification.
        /// </summary>
        public string SmsDestinationNpi { get; init; }

        /// <summary>
        ///     Type of number for the destination address.
        /// </summary>
        public string SmsDestinationTon { get; init; }

        /// <summary>
        ///     SMS source address.
        /// </summary>
        public string SmsSource { get; init; }

        /// <summary>
        ///     Source numbering plan identification.
        /// </summary>
        public string SmsSourceNpi { get; init; }

        /// <summary>
        ///     Type of number for the source address.
        /// </summary>
        public string sms_src_ton { get; init; }

        /// <summary>
        ///     Unique subaccount identifier.
        /// </summary>
        public string subaccount_id { get; init; }

        /// <summary>
        ///     Subject line from the email header.
        /// </summary>
        public string subject { get; init; }

        /// <summary>
        ///     Slug of the template used to construct this message.
        /// </summary>
        public string template_id { get; init; }

        /// <summary>
        ///     Version of the template used to construct this message.
        /// </summary>
        public string template_version { get; init; }

        /// <summary>
        ///     Event date and time, millisecond precision in UTC.
        /// </summary>
        public string timestamp { get; init; }

        /// <summary>
        ///     Indicates if the transmission was marked as transactional.
        /// </summary>
        public string transactional { get; init; }

        /// <summary>
        ///     Transmission which originated this message.
        /// </summary>
        public string transmission_id { get; init; }

        /// <summary>
        ///     Type of event this record describes.
        /// </summary>
        public string type { get; init; }

        /// <summary>
        ///     Human readable label for the event name.
        /// </summary>
        public string display_name { get; init; }

        /// <summary>
        ///     Human readable description of the event.
        /// </summary>
        public string event_description { get; init; }
    }
}