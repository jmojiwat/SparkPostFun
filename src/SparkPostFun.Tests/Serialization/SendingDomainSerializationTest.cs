using System.Linq;
using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class SendingDomainSerializationTest
    {
        [Fact]
        public void CreateSendingDomain_response_returns_expected_result()
        {
            var json = "{                                                                                                                                                                                                                                               " +
                       "  \"results\": {                                                                                                                                                                                                                                " +
                       "    \"message\": \"Successfully Created domain.\",                                                                                                                                                                                              " +
                       "    \"domain\": \"example1.com\",                                                                                                                                                                                                               " +
                       "    \"dkim\": {                                                                                                                                                                                                                                 " +
                       "      \"public\": \"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQAB\", " +
                       "      \"selector\": \"scph0316\",                                                                                                                                                                                                               " +
                       "      \"signing_domain\": \"example1.com\",                                                                                                                                                                                                     " +
                       "      \"headers\": \"from:to:subject:date\"                                                                                                                                                                                                     " +
                       "    }                                                                                                                                                                                                                                           " +
                       "  }                                                                                                                                                                                                                                             " +
                       "}                                                                                                                                                                                                                                               ";

            var response = JsonSerializer.Deserialize<CreateSendingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Domain.Should().Be("example1.com");
            response.Results.Dkim.Selector.Should().Be("scph0316");
        }

        [Fact]
        public void VerifySendingDomain_response_returns_expected_result()
        {
            var json = "{                                                                                                                                                                                                                                                                      " +
                       "  \"results\": {                                                                                                                                                                                                                                                       " +
                       "    \"ownership_verified\": true,                                                                                                                                                                                                                                      " +
                       "    \"dns\": {                                                                                                                                                                                                                                                         " +
                       "      \"dkim_record\": \"k=rsa; h=sha256; p=MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQAB\" " +
                       "    },                                                                                                                                                                                                                                                                 " +
                       "    \"dkim_status\": \"valid\",                                                                                                                                                                                                                                        " +
                       "    \"cname_status\": \"unverified\",                                                                                                                                                                                                                                  " +
                       "    \"mx_status\": \"unverified\",                                                                                                                                                                                                                                     " +
                       "    \"compliance_status\": \"pending\",                                                                                                                                                                                                                                " +
                       "    \"spf_status\": \"unverified\",                                                                                                                                                                                                                                    " +
                       "    \"abuse_at_status\": \"unverified\",                                                                                                                                                                                                                               " +
                       "    \"postmaster_at_status\": \"unverified\",                                                                                                                                                                                                                          " +
                       "    \"verification_mailbox_status\": \"unverified\"                                                                                                                                                                                                                    " +
                       "  }                                                                                                                                                                                                                                                                    " +
                       "}                                                                                                                                                                                                                                                                      ";

            var response = JsonSerializer.Deserialize<VerifySendingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.OwnershipVerified.Should().Be(true);
            response.Results.Dns.DkimRecord.Should().Be("k=rsa; h=sha256; p=MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQAB");
        }

        [Fact]
        public void RetrieveSendingDomain_response_returns_expected_result()
        {
            var json = "{                                                                                                                                                                                                                                               " +
                       "  \"results\": {                                                                                                                                                                                                                                " +
                       "    \"tracking_domain\": \"click.example1.com\",                                                                                                                                                                                                " +
                       "    \"status\": {                                                                                                                                                                                                                               " +
                       "      \"ownership_verified\": false,                                                                                                                                                                                                            " +
                       "      \"spf_status\": \"unverified\",                                                                                                                                                                                                           " +
                       "      \"abuse_at_status\": \"unverified\",                                                                                                                                                                                                      " +
                       "      \"dkim_status\": \"unverified\",                                                                                                                                                                                                          " +
                       "      \"cname_status\": \"unverified\",                                                                                                                                                                                                         " +
                       "      \"mx_status\": \"pending\",                                                                                                                                                                                                               " +
                       "      \"compliance_status\": \"pending\",                                                                                                                                                                                                       " +
                       "      \"postmaster_at_status\": \"unverified\",                                                                                                                                                                                                 " +
                       "      \"verification_mailbox_status\": \"unverified\"                                                                                                                                                                                           " +
                       "    },                                                                                                                                                                                                                                          " +
                       "    \"dkim\": {                                                                                                                                                                                                                                 " +
                       "      \"headers\": \"from:to:subject:date\",                                                                                                                                                                                                    " +
                       "      \"public\": \"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQAB\", " +
                       "      \"selector\": \"hello_selector\"                                                                                                                                                                                                          " +
                       "    },                                                                                                                                                                                                                                          " +
                       "    \"shared_with_subaccounts\": false,                                                                                                                                                                                                         " +
                       "    \"is_default_bounce_domain\": false                                                                                                                                                                                                         " +
                       "  }                                                                                                                                                                                                                                             " +
                       "}                                                                                                                                                                                                                                               ";

            var response = JsonSerializer.Deserialize<RetrieveSendingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.TrackingDomain.Should().Be("click.example1.com");
            response.Results.Status.OwnershipVerified.Should().Be(false);
        }

        [Fact]
        public void UpdateSendingDomain_response_returns_expected_result()
        {
            var json = "{                                                  " +
                       "  \"results\": {                                   " +
                       "    \"message\": \"Successfully Updated Domain.\", " +
                       "    \"domain\": \"example1.com\"                   " +
                       "  }                                                " +
                       "}                                                  ";

            var response = JsonSerializer.Deserialize<UpdateSendingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Message.Should().Be("Successfully Updated Domain.");
            response.Results.Domain.Should().Be("example1.com");
        }

        [Fact]
        public void ListTrackingDomains_response_returns_expected_result()
        {
            var json = "{                                                       " +
                       "  \"results\": [                                        " +
                       "    {                                                   " +
                       "      \"domain\": \"example1.com\",                     " +
                       "      \"tracking_domain\": \"click.example1.com\",      " +
                       "      \"status\": {                                     " +
                       "        \"ownership_verified\": true,                   " +
                       "        \"spf_status\": \"unverified\",                 " +
                       "        \"abuse_at_status\": \"unverified\",            " +
                       "        \"dkim_status\": \"valid\",                     " +
                       "        \"cname_status\": \"valid\",                    " +
                       "        \"mx_status\": \"unverified\",                  " +
                       "        \"compliance_status\": \"valid\",               " +
                       "        \"postmaster_at_status\": \"unverified\",       " +
                       "        \"verification_mailbox_status\": \"valid\",     " +
                       "        \"verification_mailbox\": \"susan.calvin\"      " +
                       "      },                                                " +
                       "      \"shared_with_subaccounts\": false,               " +
                       "      \"is_default_bounce_domain\": false               " +
                       "    },                                                  " +
                       "    {                                                   " +
                       "      \"domain\": \"example2.com\",                     " +
                       "      \"status\": {                                     " +
                       "        \"ownership_verified\": true,                   " +
                       "        \"spf_status\": \"unverified\",                 " +
                       "        \"abuse_at_status\": \"unverified\",            " +
                       "        \"dkim_status\": \"valid\",                     " +
                       "        \"cname_status\": \"valid\",                    " +
                       "        \"mx_status\": \"unverified\",                  " +
                       "        \"compliance_status\": \"valid\",               " +
                       "        \"postmaster_at_status\": \"unverified\",       " +
                       "        \"verification_mailbox_status\": \"unverified\" " +
                       "      },                                                " +
                       "      \"shared_with_subaccounts\": false,               " +
                       "      \"is_default_bounce_domain\": false               " +
                       "    }                                                   " +
                       "  ]                                                     " +
                       "}                                                       ";

            var response = JsonSerializer.Deserialize<ListSendingDomainsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Count.Should().Be(2);
            response.Results.First().Domain.Should().Be("example1.com");
        }
    }
}