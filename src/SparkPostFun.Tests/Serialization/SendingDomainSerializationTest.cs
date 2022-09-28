using System.Linq;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class SendingDomainSerializationTest
    {
        [Fact]
        public void CreateSendingDomain_request_returns_expected_result()
        {
            var request = new CreateSendingDomain("example1.com")
            {
                TrackingDomain = "click.example1.com",
                SharedWithSubaccounts = false
            };
        
            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
            {
                "domain": "example1.com",
                "tracking_domain": "click.example1.com",
                "shared_with_subaccounts": false
            }        
            */
        
            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            using var scope = new AssertionScope();
            obj.GetProperty("domain").GetString().Should().Be("example1.com");
            obj.GetProperty("tracking_domain").GetString().Should().Be("click.example1.com");
            obj.GetProperty("shared_with_subaccounts").GetBoolean().Should().BeFalse();
        }
    
        [Fact]
        public void CreateSendingDomain_response_returns_expected_result()
        {
            const string json = "{                                                                                                                                                                                                                                               " +
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
        public void VerifySendingDomain_request_returns_expected_result()
        {
            var request = new VerifySendingDomain
            {
                DkimVerify = true
            };
        
            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
                {
                  "dkim_verify": true
                }
            */
        
            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            using var scope = new AssertionScope();
            obj.GetProperty("dkim_verify").GetBoolean().Should().BeTrue();
        }
    
        [Fact]
        public void VerifySendingDomain1_request_returns_expected_result()
        {
            var request = new VerifySendingDomain
            {
                VerificationMailboxVerify = true,
                VerificationMailbox = "susan.calvin"
            };
        
            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
                {
                  "verification_mailbox_verify": true,
                  "verification_mailbox": "susan.calvin"
                }
            */
        
            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            using var scope = new AssertionScope();
            obj.GetProperty("verification_mailbox_verify").GetBoolean().Should().BeTrue();
            obj.GetProperty("verification_mailbox").GetString().Should().Be("susan.calvin");
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
        public void UpdateSendingDomain_request_returns_expected_result()
        {
            var request = new UpdateSendingDomain
            {
                TrackingDomain = "click.example1.com",
                Dkim = new UpdateDkim(
                    "MIICXgIBAAKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQABAoGBAITb3BCRPBi5lGhHdn+1RgC7cjUQEbSb4eFHm+ULRwQ0UIPWHwiVWtptZ09usHq989fKp1g/PfcNzm8c78uTS6gCxfECweFCRK6EdO6cCCr1cfWvmBdSjzYhODUdQeyWZi2ozqd0FhGWoV4VHseh4iLj36DzleTLtOZj3FhAo1WJAkEA68T+KkGeDyWwvttYtuSiQCCTrXYAWTQnkIUxduCp7Ap6tVeIDn3TaXTj74UbEgaNgLhjG4bX//fdeDW6PaK9YwJBAM6xJmwHLPMgwNVjiz3u/6fhY3kaZTWcxtMkXCjh1QE82KzDwqyrCg7EFjTtFysSHCAZxXZMcivGl4TZLHnydJUCQQCx16+M+mAatuiCnvxlQUMuMiSTNK6Amzm45u9v53nlZeY3weYMYFdHdfe1pebMiwrT7MI9clKebz6svYJVmdtXAkApDAc8VuR3WB7TgdRKNWdyGJGfoD1PO1ZE4iinOcoKV+IT1UCY99Kkgg6C7j62n/8T5OpRBvd5eBPpHxP1F9BNAkEA5Nf2VO9lcTetksHdIeKK+F7sio6UZn0Rv7iUo3ALrN1D1cGfWIh/Y1g==",
                    "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQAB",
                    "hello_selector"),
                IsDefaultBounceDomain = true
            };
        
            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
                {
                  "tracking_domain": "click.example1.com",
                  "dkim": {
                    "private": "MIICXgIBAAKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQABAoGBAITb3BCRPBi5lGhHdn+1RgC7cjUQEbSb4eFHm+ULRwQ0UIPWHwiVWtptZ09usHq989fKp1g/PfcNzm8c78uTS6gCxfECweFCRK6EdO6cCCr1cfWvmBdSjzYhODUdQeyWZi2ozqd0FhGWoV4VHseh4iLj36DzleTLtOZj3FhAo1WJAkEA68T+KkGeDyWwvttYtuSiQCCTrXYAWTQnkIUxduCp7Ap6tVeIDn3TaXTj74UbEgaNgLhjG4bX//fdeDW6PaK9YwJBAM6xJmwHLPMgwNVjiz3u/6fhY3kaZTWcxtMkXCjh1QE82KzDwqyrCg7EFjTtFysSHCAZxXZMcivGl4TZLHnydJUCQQCx16+M+mAatuiCnvxlQUMuMiSTNK6Amzm45u9v53nlZeY3weYMYFdHdfe1pebMiwrT7MI9clKebz6svYJVmdtXAkApDAc8VuR3WB7TgdRKNWdyGJGfoD1PO1ZE4iinOcoKV+IT1UCY99Kkgg6C7j62n/8T5OpRBvd5eBPpHxP1F9BNAkEA5Nf2VO9lcTetksHdIeKK+F7sio6UZn0Rv7iUo3ALrN1D1cGfWIh/Y1g==",
                    "public": "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQAB",
                    "selector": "hello_selector"
                  },
                  "is_default_bounce_domain": true
                }
            */
        
            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            using var scope = new AssertionScope();
            obj.GetProperty("tracking_domain").GetString().Should().Be("click.example1.com");
            obj.GetProperty("dkim").GetProperty("private").GetString().Should().Be("MIICXgIBAAKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQABAoGBAITb3BCRPBi5lGhHdn+1RgC7cjUQEbSb4eFHm+ULRwQ0UIPWHwiVWtptZ09usHq989fKp1g/PfcNzm8c78uTS6gCxfECweFCRK6EdO6cCCr1cfWvmBdSjzYhODUdQeyWZi2ozqd0FhGWoV4VHseh4iLj36DzleTLtOZj3FhAo1WJAkEA68T+KkGeDyWwvttYtuSiQCCTrXYAWTQnkIUxduCp7Ap6tVeIDn3TaXTj74UbEgaNgLhjG4bX//fdeDW6PaK9YwJBAM6xJmwHLPMgwNVjiz3u/6fhY3kaZTWcxtMkXCjh1QE82KzDwqyrCg7EFjTtFysSHCAZxXZMcivGl4TZLHnydJUCQQCx16+M+mAatuiCnvxlQUMuMiSTNK6Amzm45u9v53nlZeY3weYMYFdHdfe1pebMiwrT7MI9clKebz6svYJVmdtXAkApDAc8VuR3WB7TgdRKNWdyGJGfoD1PO1ZE4iinOcoKV+IT1UCY99Kkgg6C7j62n/8T5OpRBvd5eBPpHxP1F9BNAkEA5Nf2VO9lcTetksHdIeKK+F7sio6UZn0Rv7iUo3ALrN1D1cGfWIh/Y1g==");
            obj.GetProperty("dkim").GetProperty("public").GetString().Should().Be("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+W6scd3XWwvC/hPRksfDYFi3ztgyS9OSqnnjtNQeDdTSD1DRx/xFar2wjmzxp2+SnJ5pspaF77VZveN3P/HVmXZVghr3asoV9WBx/uW1nDIUxU35L4juXiTwsMAbgMyh3NqIKTNKyMDy4P8vpEhtH1iv/BrwMdBjHDVCycB8WnwIDAQAB");
            obj.GetProperty("dkim").GetProperty("selector").GetString().Should().Be("hello_selector");
            obj.GetProperty("is_default_bounce_domain").GetBoolean().Should().BeTrue();
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