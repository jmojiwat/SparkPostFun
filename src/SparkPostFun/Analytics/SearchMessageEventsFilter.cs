using System;
using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record SearchMessageEventsFilter
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Cursor { get; set; }
        public int? PerPage { get; set; }
        public string Delimiter { get; set; }
        public IList<string> EventIds { get; set; } = new List<string>();
        public IList<string> Events { get; set; } = new List<string>();
        public IList<string> Recipients { get; set; } = new List<string>();
        public IList<string> RecipientDomains { get; set; } = new List<string>();
        public IList<string> FromAddresses { get; set; } = new List<string>();
        public IList<string> SendingDomains { get; set; } = new List<string>();
        public IList<string> Subjects { get; set; } = new List<string>();
        public IList<string> BounceClasses { get; set; } = new List<string>();
        public IList<string> Reasons { get; set; } = new List<string>();
        public IList<string> Campaigns { get; set; } = new List<string>();
        public IList<string> Templates { get; set; } = new List<string>();
        public IList<string> SendingIps { get; set; } = new List<string>();
        public IList<string> IpPools { get; set; } = new List<string>();
        public IList<string> Subaccounts { get; set; } = new List<string>();
        public IList<string> Messages { get; set; } = new List<string>();
        public IList<string> Transmissions { get; set; } = new List<string>();
        public IList<string> MailboxProviders { get; set; } = new List<string>();
        public IList<string> MailboxProviderRegions { get; set; } = new List<string>();
        public IList<string> AbTests { get; set; } = new List<string>();
        public IList<string> AbTestVersions { get; set; } = new List<string>();
    }
}