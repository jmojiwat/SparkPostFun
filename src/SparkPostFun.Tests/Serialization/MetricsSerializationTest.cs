using System;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Analytics;
using SparkPostFun.Infrastructure;
using Xunit;

namespace SparkPostFun.Tests.Serialization;

public class MetricsSerializationTest
{
    [Fact]
    public void AdvancedQueryJsonSchema_response_returns_expected_result()
    {
        const string json = "{                                                                                   " +
                            "      \"results\": {                                                                " +
                            "          \"$schema\": \"http://json-schema.org/draft-07/schema\",                  " +
                            "          \"$id\": \"root\",                                                        " +
                            "          \"type\": \"object\",                                                     " +
                            "          \"title\": \"The root schema\",                                           " +
                            "          \"description\": \"The root schema comprises the entire JSON document.\", " +
                            "          \"default\": {},                                                          " +
                            "          \"required\": [                                                           " +
                            "              \"groupings\"                                                         " +
                            "          ],                                                                        " +
                            "          \"properties\": {                                                         " +
                            "          },                                                                        " +
                            "          \"additionalProperties\": false,                                          " +
                            "          \"$defs\": {                                                              " +
                            "              \"groupings\": {                                                      " +
                            "              },                                                                    " +
                            "              \"filters\": {                                                        " +
                            "              },                                                                    " +
                            "              \"logicalOperators\": {                                               " +
                            "              }                                                                     " +
                            "          }                                                                         " +
                            "      }                                                                             " +
                            "}                                                                                   ";

        var response = JsonSerializer.Deserialize<AdvancedQueryJsonSchemaResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results.ToString().Should().Contain("groupings");
    }

    [Fact]
    public void DiscoverabilityLinks_response_returns_expected_result()
    {
        const string json = "{                                                                 " +
                   "    \"results\": {},                                              " +
                   "    \"links\": [                                                  " +
                   "        {                                                         " +
                   "           \"href\": \"/api/v1/metrics/\",                        " +
                   "           \"rel\": \"\",                                         " +
                   "           \"method\": \"GET\"                                    " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/campaigns\",                " +
                   "          \"rel\": \"campaigns\",                                 " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/deliverability\",           " +
                   "          \"rel\": \"deliverability\",                            " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/domains\",                  " +
                   "          \"rel\": \"domains\",                                   " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/binding-groups\",           " +
                   "          \"rel\": \"binding-groups\",                            " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/bindings\",                 " +
                   "          \"rel\": \"bindings\",                                  " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/ip-pools\",                 " +
                   "          \"rel\": \"ip-pools\",                                  " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/mailbox-provider-regions\", " +
                   "          \"rel\": \"mailbox-provider-regions\",                  " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/mailbox-providers\",        " +
                   "          \"rel\": \"mailbox-providers\",                         " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/sending-ips\",              " +
                   "          \"rel\": \"sending-ips\",                               " +
                   "          \"method\": \"GET\"                                     " +
                   "        },                                                        " +
                   "        {                                                         " +
                   "          \"href\": \"/api/v1/metrics/subject-campaigns\",        " +
                   "          \"rel\": \"subject-campaigns\",                         " +
                   "          \"method\": \"GET\"                                     " +
                   "        }                                                         " +
                   "    ]                                                             " +
                   "}                                                                 ";

        var response = JsonSerializer.Deserialize<DiscoverabilityLinksResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results.Should().NotBeNull();
        response.Links[0].Href.Should().Be("/api/v1/metrics/");
        response.Links[0].Rel.Should().BeEmpty();
        response.Links[0].Method.Should().Be("GET");
    }

    [Fact]
    public void MetricsSummary_response_returns_expected_result()
    {
        const string json = "{                                                   " +
                   "  \"results\": [                                    " +
                   "    {                                               " +
                   "      \"count_targeted\": 34432,                    " +
                   "      \"count_injected\": 32323,                    " +
                   "      \"count_rejected\": 2343,                     " +
                   "      \"count_sent\": 34344                         " +
                   "    }                                               " +
                   "  ],                                                " +
                   "  \"links\": [                                      " +
                   "    {                                               " +
                   "      \"href\": \"/api/v1/metrics/deliverability\", " +
                   "      \"rel\": \"deliverability\",                  " +
                   "      \"method\": \"GET\"                           " +
                   "    }                                               " +
                   "  ]                                                 " +
                   "}                                                   ";

        var response = JsonSerializer.Deserialize<MetricsSummaryResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response!.Results.Count.Should().Be(1);
        response.Results[0].CountTargeted.Should().Be(34432);
        response.Results[0].CountInjected.Should().Be(32323);
        response.Results[0].CountRejected.Should().Be(2343);
        response.Results[0].CountSent.Should().Be(34344);
        response.Links[0].Href.Should().Be("/api/v1/metrics/deliverability");
        response.Links[0].Rel.Should().Be("deliverability");
        response.Links[0].Method.Should().Be("GET");
    }

    [Fact]
    public void MetricsByRecipientDomain_response_returns_expected_result()
    {
        const string json = "{                                " +
                   "  \"results\": [                 " +
                   "    {                            " +
                   "      \"domain\": \"aol.com\",   " +
                   "      \"count_targeted\": 34432, " +
                   "      \"count_injected\": 32323, " +
                   "      \"count_rejected\": 2343,  " +
                   "      \"count_sent\": 34344      " +
                   "    },                           " +
                   "    {                            " +
                   "      \"domain\": \"foo.net\",   " +
                   "      \"count_targeted\": 34432, " +
                   "      \"count_injected\": 32323, " +
                   "      \"count_rejected\": 2343,  " +
                   "      \"count_sent\": 34344      " +
                   "    }                            " +
                   "  ]                              " +
                   "}                                ";

        var response = JsonSerializer.Deserialize<MetricsByRecipientDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response!.Results.Count.Should().Be(2);
        response.Results[0].Domain.Should().Be("aol.com");
        response.Results[0].CountTargeted.Should().Be(34432);
        response.Results[0].CountInjected.Should().Be(32323);
        response.Results[0].CountRejected.Should().Be(2343);
        response.Results[0].CountSent.Should().Be(34344);
    }

    [Fact]
    public void MetricsBySendingIp_response_returns_expected_result()
    {
        const string json = "{                                       " +
                   "  \"results\": [                        " +
                   "    {                                   " +
                   "      \"sending_ip\": \"sending-ip-0\", " +
                   "      \"count_targeted\": 34432,        " +
                   "      \"count_injected\": 32323,        " +
                   "      \"count_rejected\": 2343,         " +
                   "      \"count_sent\": 34344             " +
                   "    },                                  " +
                   "    {                                   " +
                   "      \"sending_ip\": \"sending-ip-1\", " +
                   "      \"count_targeted\": 34432,        " +
                   "      \"count_injected\": 32323,        " +
                   "      \"count_rejected\": 2343,         " +
                   "      \"count_sent\": 34344             " +
                   "    }                                   " +
                   "  ]                                     " +
                   "}                                       ";

        var response = JsonSerializer.Deserialize<MetricsBySendingIpResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response!.Results[0].SendingIp.Should().Be("sending-ip-0");
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void MetricsByIpPool_response_returns_expected_result()
    {
        const string json = "{                                 " +
                   "  \"results\": [                  " +
                   "    {                             " +
                   "      \"ip_pool\": \"ip-pool-0\", " +
                   "      \"count_targeted\": 34432,  " +
                   "      \"count_injected\": 32323,  " +
                   "      \"count_rejected\": 2343,   " +
                   "      \"count_sent\": 34344       " +
                   "    },                            " +
                   "    {                             " +
                   "      \"ip_pool\": \"ip-pool-1\", " +
                   "      \"count_targeted\": 34432,  " +
                   "      \"count_injected\": 32323,  " +
                   "      \"count_rejected\": 2343,   " +
                   "      \"count_sent\": 34344       " +
                   "    }                             " +
                   "  ]                               " +
                   "}                                 ";

        var response = JsonSerializer.Deserialize<MetricsByIpPoolResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].IpPool.Should().Be("ip-pool-0");
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void MetricsBySendingDomain_response_returns_expected_result()
    {
        const string json = "{                                             " +
                   "  \"results\": [                              " +
                   "    {                                         " +
                   "      \"count_targeted\": 34432,              " +
                   "      \"count_injected\": 32323,              " +
                   "      \"count_rejected\": 2343,               " +
                   "      \"count_sent\": 34344,                  " +
                   "      \"sending_domain\": \"foo.example.com\" " +
                   "    },                                        " +
                   "    {                                         " +
                   "      \"count_targeted\": 34432,              " +
                   "      \"count_injected\": 32323,              " +
                   "      \"count_rejected\": 2343,               " +
                   "      \"count_sent\": 34344,                  " +
                   "      \"sending_domain\": \"bar.example.com\" " +
                   "    },                                        " +
                   "    {                                         " +
                   "      \"count_targeted\": 34432,              " +
                   "      \"count_injected\": 32323,              " +
                   "      \"count_rejected\": 2343,               " +
                   "      \"count_sent\": 34344,                  " +
                   "      \"sending_domain\": \"bat.example.com\" " +
                   "    },                                        " +
                   "    {                                         " +
                   "      \"count_targeted\": 34432,              " +
                   "      \"count_injected\": 32323,              " +
                   "      \"count_rejected\": 2343,               " +
                   "      \"count_sent\": 34344,                  " +
                   "      \"sending_domain\": \"baz.example.com\" " +
                   "    }                                         " +
                   "  ]                                           " +
                   "}                                             ";

        var response = JsonSerializer.Deserialize<MetricsBySendingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].CountTargeted.Should().Be(34432);
        response.Results[0].CountInjected.Should().Be(32323);
        response.Results[0].CountRejected.Should().Be(2343);
        response.Results[0].CountSent.Should().Be(34344);
        response.Results[0].SendingDomain.Should().Be("foo.example.com");
        response.Results.Count.Should().Be(4);
    }

    [Fact]
    public void MetricsBySubaccount_response_returns_expected_result()
    {
        const string json = "{                                " +
                   "  \"results\": [                 " +
                   "    {                            " +
                   "      \"count_targeted\": 34432, " +
                   "      \"count_injected\": 32323, " +
                   "      \"count_rejected\": 2343,  " +
                   "      \"count_sent\": 34344,     " +
                   "      \"subaccount_id\": 0       " +
                   "    },                           " +
                   "    {                            " +
                   "      \"count_targeted\": 34432, " +
                   "      \"count_injected\": 32323, " +
                   "      \"count_rejected\": 2343,  " +
                   "      \"count_sent\": 34344,     " +
                   "      \"subaccount_id\": 123     " +
                   "    },                           " +
                   "    {                            " +
                   "      \"count_targeted\": 34432, " +
                   "      \"count_injected\": 32323, " +
                   "      \"count_rejected\": 2343,  " +
                   "      \"count_sent\": 34344,     " +
                   "      \"subaccount_id\": 125     " +
                   "    },                           " +
                   "    {                            " +
                   "      \"count_targeted\": 34432, " +
                   "      \"count_injected\": 32323, " +
                   "      \"count_rejected\": 2343,  " +
                   "      \"count_sent\": 34344,     " +
                   "      \"subaccount_id\": 127     " +
                   "    }                            " +
                   "  ]                              " +
                   "}                                ";

        var response = JsonSerializer.Deserialize<MetricsBySubaccountResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].CountTargeted.Should().Be(34432);
        response.Results[0].CountInjected.Should().Be(32323);
        response.Results[0].CountRejected.Should().Be(2343);
        response.Results[0].CountSent.Should().Be(34344);
        response.Results[0].SubaccountId.Should().Be(0);
        response.Results.Count.Should().Be(4);
    }

    [Fact]
    public void MetricsByCampaign_response_returns_expected_result()
    {
        const string json = "{                                      " +
                   "  \"results\": [                       " +
                   "    {                                  " +
                   "      \"campaign_id\": \"campaign-0\", " +
                   "      \"count_targeted\": 34432,       " +
                   "      \"count_injected\": 32323,       " +
                   "      \"count_rejected\": 2343,        " +
                   "      \"count_sent\": 34344            " +
                   "    },                                 " +
                   "    {                                  " +
                   "      \"campaign_id\": \"campaign-1\", " +
                   "      \"count_targeted\": 34432,       " +
                   "      \"count_injected\": 32323,       " +
                   "      \"count_rejected\": 2343,        " +
                   "      \"count_sent\": 34344            " +
                   "    }                                  " +
                   "  ]                                    " +
                   "}                                      ";

        var response = JsonSerializer.Deserialize<MetricsByCampaignResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].CampaignId.Should().Be("campaign-0");
        response.Results[0].CountTargeted.Should().Be(34432);
        response.Results[0].CountInjected.Should().Be(32323);
        response.Results[0].CountRejected.Should().Be(2343);
        response.Results[0].CountSent.Should().Be(34344);
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void MetricsByTemplate_response_returns_expected_result()
    {
        const string json = "{                                      " +
                   "  \"results\": [                       " +
                   "    {                                  " +
                   "      \"template_id\": \"template-0\", " +
                   "      \"count_targeted\": 34432,       " +
                   "      \"count_injected\": 32323,       " +
                   "      \"count_rejected\": 2343,        " +
                   "      \"count_sent\": 34344            " +
                   "    },                                 " +
                   "    {                                  " +
                   "      \"template_id\": \"template-1\", " +
                   "      \"count_targeted\": 34432,       " +
                   "      \"count_injected\": 32323,       " +
                   "      \"count_rejected\": 2343,        " +
                   "      \"count_sent\": 34344            " +
                   "    }                                  " +
                   "  ]                                    " +
                   "}                                      ";

        var response = JsonSerializer.Deserialize<MetricsByTemplateResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].TemplateId.Should().Be("template-0");
        response.Results[0].CountTargeted.Should().Be(34432);
        response.Results[0].CountInjected.Should().Be(32323);
        response.Results[0].CountRejected.Should().Be(2343);
        response.Results[0].CountSent.Should().Be(34344);
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void MetricsBySubjectCampaign_response_returns_expected_result()
    {
        const string json = "{                                                                 " +
                   "  \"results\": [                                                  " +
                   "    {                                                             " +
                   "      \"count_inbox_panel\": 564,                                 " +
                   "      \"count_spam_panel\": 49,                                   " +
                   "      \"count_inbox_seed\": 0,                                    " +
                   "      \"count_spam_seed\": 0,                                     " +
                   "      \"count_moved_to_inbox\": 2,                                " +
                   "      \"count_moved_to_spam\": 1,                                 " +
                   "      \"subject_campaign\": \"[REDACTED] say yes to this deal\"   " +
                   "    },                                                            " +
                   "    {                                                             " +
                   "      \"count_inbox_panel\": 527,                                 " +
                   "      \"count_spam_panel\": 19,                                   " +
                   "      \"count_inbox_seed\": 0,                                    " +
                   "      \"count_spam_seed\": 0,                                     " +
                   "      \"count_moved_to_inbox\": 0,                                " +
                   "      \"count_moved_to_spam\": 2,                                 " +
                   "      \"subject_campaign\": \"Re: [REDACTED] (Action Requested)\" " +
                   "    }                                                             " +
                   "  ]                                                               " +
                   "}                                                                 ";

        var response = JsonSerializer.Deserialize<MetricsBySubjectCampaignResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].CountInboxPanel.Should().Be(564);
        response.Results[0].CountSpamPanel.Should().Be(49);
        response.Results[0].CountInboxSeed.Should().Be(0);
        response.Results[0].CountSpamSeed.Should().Be(0);
        response.Results[0].CountMovedToInbox.Should().Be(2);
        response.Results[0].CountMovedToSpam.Should().Be(1);
        response.Results[0].SubjectCampaign.Should().Be("[REDACTED] say yes to this deal");
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void MetricsByWatchedDomain_response_returns_expected_result()
    {
        const string json = "{                                        " +
                   "  \"results\": [                         " +
                   "    {                                    " +
                   "      \"watched_domain\": \"aol.com\",   " +
                   "      \"count_targeted\": 34432,         " +
                   "      \"count_injected\": 32323,         " +
                   "      \"count_rejected\": 2343,          " +
                   "      \"count_sent\": 34344              " +
                   "    },                                   " +
                   "    {                                    " +
                   "      \"watched_domain\": \"gmail.com\", " +
                   "      \"count_targeted\": 34432,         " +
                   "      \"count_injected\": 32323,         " +
                   "      \"count_rejected\": 2343,          " +
                   "      \"count_sent\": 34344              " +
                   "    }                                    " +
                   "  ]                                      " +
                   "}                                        ";

        var response = JsonSerializer.Deserialize<MetricsByWatchedDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].WatchedDomain.Should().Be("aol.com");
        response.Results[0].CountTargeted.Should().Be(34432);
        response.Results[0].CountInjected.Should().Be(32323);
        response.Results[0].CountRejected.Should().Be(2343);
        response.Results[0].CountSent.Should().Be(34344);
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void MetricsByMailboxProvider_response_returns_expected_result()
    {
        const string json = "{                                                        " +
                   "  \"results\": [                                         " +
                   "    {                                                    " +
                   "      \"count_injected\": 109849,                        " +
                   "      \"count_targeted\": 110923,                        " +
                   "      \"count_rejected\": 1074,                          " +
                   "      \"count_sent\": 107610,                            " +
                   "      \"mailbox_provider\": \"Verizon Media Group\"      " +
                   "    },                                                   " +
                   "    {                                                    " +
                   "      \"count_injected\": 102555,                        " +
                   "      \"count_targeted\": 103519,                        " +
                   "      \"count_rejected\": 964,                           " +
                   "      \"count_sent\": 100301,                            " +
                   "      \"mailbox_provider\": \"Gmail\"                    " +
                   "    },                                                   " +
                   "    {                                                    " +
                   "      \"count_injected\": 53595,                         " +
                   "      \"count_targeted\": 54102,                         " +
                   "      \"count_rejected\": 507,                           " +
                   "      \"count_sent\": 52385,                             " +
                   "      \"mailbox_provider\": \"Hotmail / Outlook\"        " +
                   "    },                                                   " +
                   "    {                                                    " +
                   "      \"count_injected\": 16808,                         " +
                   "      \"count_targeted\": 16962,                         " +
                   "      \"count_rejected\": 154,                           " +
                   "      \"count_sent\": 16468,                             " +
                   "      \"mailbox_provider\": \"Free.fr\"                  " +
                   "    },                                                   " +
                   "    {                                                    " +
                   "      \"count_injected\": 7511,                          " +
                   "      \"count_targeted\": 7576,                          " +
                   "      \"count_rejected\": 65,                            " +
                   "      \"count_sent\": 7534,                              " +
                   "      \"mailbox_provider\": \"Educational Institution\"  " +
                   "    }                                                    " +
                   "  ]                                                      " +
                   "}                                                        ";

        var response = JsonSerializer.Deserialize<MetricsByMailboxProviderResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].CountInjected.Should().Be(109849);
        response.Results[0].CountTargeted.Should().Be(110923);
        response.Results[0].CountRejected.Should().Be(1074);
        response.Results[0].CountSent.Should().Be(107610);
        response.Results[0].MailboxProvider.Should().Be("Verizon Media Group");
        response.Results.Count.Should().Be(5);
    }

    [Fact]
    public void MetricsByMailboxProviderRegion_response_returns_expected_result()
    {
        const string json = "{                                                             " +
                   "  \"results\": [                                              " +
                   "    {                                                         " +
                   "      \"count_injected\": 109849,                             " +
                   "      \"count_targeted\": 110923,                             " +
                   "      \"count_rejected\": 1074,                               " +
                   "      \"count_sent\": 107610,                                 " +
                   "      \"mailbox_provider_region\": \"Global\"                 " +
                   "    },                                                        " +
                   "    {                                                         " +
                   "      \"count_injected\": 102555,                             " +
                   "      \"count_targeted\": 103519,                             " +
                   "      \"count_rejected\": 964,                                " +
                   "      \"count_sent\": 100301,                                 " +
                   "      \"mailbox_provider_region\": \"Africa - South Africa\"  " +
                   "    },                                                        " +
                   "    {                                                         " +
                   "      \"count_injected\": 53595,                              " +
                   "      \"count_targeted\": 54102,                              " +
                   "      \"count_rejected\": 507,                                " +
                   "      \"count_sent\": 52385,                                  " +
                   "      \"mailbox_provider_region\": \"South America - Brazil\" " +
                   "    },                                                        " +
                   "    {                                                         " +
                   "      \"count_injected\": 16808,                              " +
                   "      \"count_targeted\": 16962,                              " +
                   "      \"count_rejected\": 154,                                " +
                   "      \"count_sent\": 16468,                                  " +
                   "      \"mailbox_provider_region\": \"APAC - Taiwan\"          " +
                   "    },                                                        " +
                   "    {                                                         " +
                   "      \"count_injected\": 7511,                               " +
                   "      \"count_targeted\": 7576,                               " +
                   "      \"count_rejected\": 65,                                 " +
                   "      \"count_sent\": 7534,                                   " +
                   "      \"mailbox_provider_region\": \"Europe - Sweden\"        " +
                   "    }                                                         " +
                   "  ]                                                           " +
                   "}                                                             ";

        var response = JsonSerializer.Deserialize<MetricsByMailboxProviderRegionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].CountInjected.Should().Be(109849);
        response.Results[0].CountTargeted.Should().Be(110923);
        response.Results[0].CountRejected.Should().Be(1074);
        response.Results[0].CountSent.Should().Be(107610);
        response.Results[0].MailboxProviderRegion.Should().Be("Global");
        response.Results.Count.Should().Be(5);
    }

    [Fact]
    public void TimeSeriesMetrics_response_returns_expected_result()
    {
        const string json = "{                                                      " +
                   "  \"results\": [                                       " +
                   "    {                                                  " +
                   "      \"count_accepted\": 217489,                      " +
                   "      \"count_admin_bounce\": 295,                     " +
                   "      \"count_block_bounce\": 16789,                   " +
                   "      \"count_bounce\": 24176,                         " +
                   "      \"count_clicked\": 16319,                        " +
                   "      \"count_delayed\": 61224,                        " +
                   "      \"count_delayed_first\": 5115,                   " +
                   "      \"count_delivered\": 219916,                     " +
                   "      \"count_delivered_first\": 18171,                " +
                   "      \"count_delivered_subsequent\": 201745,          " +
                   "      \"count_generation_failed\": 609,                " +
                   "      \"count_generation_rejection\": 635,             " +
                   "      \"count_hard_bounce\": 4296,                     " +
                   "      \"count_inband_bounce\": 21777,                  " +
                   "      \"count_initial_rendered\": 139690,              " +
                   "      \"count_injected\": 246682,                      " +
                   "      \"count_outofband_bounce\": 2399,                " +
                   "      \"count_policy_rejection\": 1072,                " +
                   "      \"count_rejected\": 2316,                        " +
                   "      \"count_rendered\": 128385,                      " +
                   "      \"count_sent\": 241693,                          " +
                   "      \"count_soft_bounce\": 1961,                     " +
                   "      \"count_spam_complaint\": 3,                     " +
                   "      \"count_targeted\": 248998,                      " +
                   "      \"count_undetermined_bounce\": 1130,             " +
                   "      \"count_unique_clicked\": 9123,                  " +
                   "      \"count_unique_confirmed_opened\": 81140,        " +
                   "      \"count_unique_initial_rendered\": 81140,        " +
                   "      \"count_unique_rendered\": 69643,                " +
                   "      \"count_unsubscribe\": 1,                        " +
                   "      \"total_delivery_time_first\": 90854824,         " +
                   "      \"total_delivery_time_subsequent\": 1008767467,  " +
                   "      \"total_msg_volume\": 1111464137,                " +
                   "      \"ts\": \"2020-10-04T00:00:00-04:00\"            " +
                   "    },                                                 " +
                   "    {                                                  " +
                   "      \"count_accepted\": 143977,                      " +
                   "      \"count_admin_bounce\": 202,                     " +
                   "      \"count_block_bounce\": 11176,                   " +
                   "      \"count_bounce\": 16120,                         " +
                   "      \"count_clicked\": 10687,                        " +
                   "      \"count_delayed\": 40527,                        " +
                   "      \"count_delayed_first\": 3499,                   " +
                   "      \"count_delivered\": 145617,                     " +
                   "      \"count_delivered_first\": 12169,                " +
                   "      \"count_delivered_subsequent\": 133448,          " +
                   "      \"count_generation_failed\": 404,                " +
                   "      \"count_generation_rejection\": 417,             " +
                   "      \"count_hard_bounce\": 2817,                     " +
                   "      \"count_inband_bounce\": 14501,                  " +
                   "      \"count_initial_rendered\": 92769,               " +
                   "      \"count_injected\": 163372,                      " +
                   "      \"count_outofband_bounce\": 1619,                " +
                   "      \"count_policy_rejection\": 728,                 " +
                   "      \"count_rejected\": 1549,                        " +
                   "      \"count_rendered\": 85483,                       " +
                   "      \"count_sent\": 160118,                          " +
                   "      \"count_soft_bounce\": 1357,                     " +
                   "      \"count_spam_complaint\": 2,                     " +
                   "      \"count_targeted\": 164921,                      " +
                   "      \"count_undetermined_bounce\": 770,              " +
                   "      \"count_unique_clicked\": 5999,                  " +
                   "      \"count_unique_confirmed_opened\": 55592,        " +
                   "      \"count_unique_initial_rendered\": 55592,        " +
                   "      \"count_unique_rendered\": 48206,                " +
                   "      \"count_unsubscribe\": 3,                        " +
                   "      \"total_delivery_time_first\": 60928506,         " +
                   "      \"total_delivery_time_subsequent\": 665233402,   " +
                   "      \"total_msg_volume\": 736088556,                 " +
                   "      \"ts\": \"2020-10-05T00:00:00-04:00\"            " +
                   "    }                                                  " +
                   "  ]                                                    " +
                   "}                                                      ";

        var response = JsonSerializer.Deserialize<TimeSeriesMetricsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].CountAccepted.Should().Be(217489);
        response.Results[0].CountAdminBounce.Should().Be(295);
        response.Results[0].CountBlockBounce.Should().Be(16789);
        response.Results[0].Timestamp.Should().Be(new DateTime(2020, 10, 4, 12, 0, 0, 0));
        response.Results.Count.Should().Be(2);
    }
    
        [Fact]
    public void BounceReasonMetrics_response_returns_expected_result()
    {
        const string json = "{                                                                                  " +
                   "  \"results\": [                                                                   " +
                   "    {                                                                              " +
                   "      \"reason\": \"Some Fake Reason\",                                            " +
                   "      \"bounce_class_name\": \"Undetermined\",                                     " +
                   "      \"bounce_class_description\": \"The response text could not be identified\", " +
                   "      \"bounce_category_id\": 0,                                                   " +
                   "      \"bounce_category_name\": \"Undetermined\",                                  " +
                   "      \"classification_id\": 1,                                                    " +
                   "      \"count_inband_bounce\": 119,                                                " +
                   "      \"count_outofband_bounce\": 118,                                             " +
                   "      \"count_bounce\": 237                                                        " +
                   "    },                                                                             " +
                   "    {                                                                              " +
                   "      \"reason\": \"Some Fake Reason\",                                            " +
                   "      \"bounce_class_name\": \"Invalid Recipient\",                                " +
                   "      \"bounce_class_description\": \"The recipient is invalid\",                  " +
                   "      \"bounce_category_id\": 1,                                                   " +
                   "      \"bounce_category_name\": \"Hard\",                                          " +
                   "      \"classification_id\": 10,                                                   " +
                   "      \"count_inband_bounce\": 133,                                                " +
                   "      \"count_outofband_bounce\": 126,                                             " +
                   "      \"count_bounce\": 259                                                        " +
                   "    }                                                                              " +
                   "  ]                                                                                " +
                   "}                                                                                  ";

        var response = JsonSerializer.Deserialize<BounceReasonMetricsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].Reason.Should().Be("Some Fake Reason");
        response.Results[0].BounceClassName.Should().Be("Undetermined");
        response.Results[0].BounceClassDescription.Should().Be("The response text could not be identified");
        response.Results[0].BounceCategoryId.Should().Be(0);
        response.Results[0].BounceCategoryName.Should().Be("Undetermined");
        response.Results[0].ClassificationId.Should().Be(1);
        response.Results[0].CountInbandBounce.Should().Be(119);
        response.Results[0].CountOutofbandBounce.Should().Be(118);
        response.Results[0].CountBounce.Should().Be(237);
        response.Results.Count.Should().Be(2);
    }

        [Fact]
    public void BounceReasonMetricsByDomain_response_returns_expected_result()
    {
        const string json = "{                                                                                  " +
                   "  \"results\": [                                                                   " +
                   "    {                                                                              " +
                   "      \"reason\": \"Some Fake Reason\",                                            " +
                   "      \"domain\": \"example.com\",                                                 " +
                   "      \"bounce_class_name\": \"Undetermined\",                                     " +
                   "      \"bounce_class_description\": \"The response text could not be identified\", " +
                   "      \"bounce_category_id\": 0,                                                   " +
                   "      \"bounce_category_name\": \"Undetermined\",                                  " +
                   "      \"classification_id\": 1,                                                    " +
                   "      \"count_inband_bounce\": 119,                                                " +
                   "      \"count_outofband_bounce\": 118,                                             " +
                   "      \"count_bounce\": 237                                                        " +
                   "    },                                                                             " +
                   "    {                                                                              " +
                   "      \"reason\": \"Some Fake Reason\",                                            " +
                   "      \"domain\": \"aol.com\",                                                     " +
                   "      \"bounce_class_name\": \"Invalid Recipient\",                                " +
                   "      \"bounce_class_description\": \"The recipient is invalid\",                  " +
                   "      \"bounce_category_id\": 1,                                                   " +
                   "      \"bounce_category_name\": \"Hard\",                                          " +
                   "      \"classification_id\": 10,                                                   " +
                   "      \"count_inband_bounce\": 133,                                                " +
                   "      \"count_outofband_bounce\": 126,                                             " +
                   "      \"count_bounce\": 259                                                        " +
                   "    }                                                                              " +
                   "  ]                                                                                " +
                   "}                                                                                  ";

        var response = JsonSerializer.Deserialize<BounceReasonMetricsByDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].Reason.Should().Be("Some Fake Reason");
        response.Results[0].Domain.Should().Be("example.com");
        response.Results[0].BounceClassName.Should().Be("Undetermined");
        response.Results[0].BounceClassDescription.Should().Be("The response text could not be identified");
        response.Results[0].BounceCategoryId.Should().Be(0);
        response.Results[0].BounceCategoryName.Should().Be("Undetermined");
        response.Results[0].ClassificationId.Should().Be(1);
        response.Results[0].CountInbandBounce.Should().Be(119);
        response.Results[0].CountOutofbandBounce.Should().Be(118);
        response.Results[0].CountBounce.Should().Be(237);
        response.Results.Count.Should().Be(2);
    }

        [Fact]
    public void BounceClassificationMetrics_response_returns_expected_result()
    {
        const string json = "{                                                                                   " +
                   "  \"results\": [                                                                    " +
                   "    {                                                                               " +
                   "      \"bounce_class_name\": \"Undetermined\",                                      " +
                   "      \"bounce_class_description\": \"The response text could not be identified\",  " +
                   "      \"bounce_category_name\": \"Undetermined\",                                   " +
                   "      \"count_bounce\": 226,                                                        " +
                   "      \"count_inband_bounce\": 205,                                                 " +
                   "      \"count_outofband_bounce\": 21,                                               " +
                   "      \"classification_id\": 1                                                      " +
                   "    },                                                                              " +
                   "    {                                                                               " +
                   "      \"bounce_class_name\": \"Invalid Recipient\",                                 " +
                   "      \"bounce_class_description\": \"The recipient is invalid\",                   " +
                   "      \"bounce_category_name\": \"Hard\",                                           " +
                   "      \"count_bounce\": 249,                                                        " +
                   "      \"count_inband_bounce\": 224,                                                 " +
                   "      \"count_outofband_bounce\": 25,                                               " +
                   "      \"classification_id\": 10                                                     " +
                   "    }                                                                               " +
                   "  ]                                                                                 " +
                   "}                                                                                   ";

        var response = JsonSerializer.Deserialize<BounceClassificationMetricsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].BounceClassName.Should().Be("Undetermined");
        response.Results[0].BounceClassDescription.Should().Be("The response text could not be identified");
        response.Results[0].BounceCategoryName.Should().Be("Undetermined");
        response.Results[0].CountBounce.Should().Be(226);
        response.Results[0].CountInbandBounce.Should().Be(205);
        response.Results[0].CountOutofbandBounce.Should().Be(21);
        response.Results[0].ClassificationId.Should().Be(1);
        response.Results.Count.Should().Be(2);
    }

        [Fact]
    public void RejectionReasonMetrics_response_returns_expected_result()
    {
        const string json = "{                                                  " +
                   "  \"results\": [                                   " +
                   "    {                                              " +
                   "      \"reason\": \"520 rejection message\",       " +
                   "      \"count_rejected\": 30,                      " +
                   "      \"rejection_category_id\": 2,                " +
                   "      \"rejection_type\": \"Generation Rejection\" " +
                   "    },                                             " +
                   "    {                                              " +
                   "      \"reason\": \"503 rejection message\",       " +
                   "      \"count_rejected\": 24,                      " +
                   "      \"rejection_category_id\": 1,                " +
                   "      \"rejection_type\": \"Policy Rejection\"     " +
                   "    }                                              " +
                   "  ]                                                " +
                   "}                                                  ";

        var response = JsonSerializer.Deserialize<RejectionReasonMetricsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].Reason.Should().Be("520 rejection message");
        response.Results[0].CountRejected.Should().Be(30);
        response.Results[0].RejectionCategoryId.Should().Be(2);
        response.Results[0].RejectionType.Should().Be("Generation Rejection");
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void RejectionReasonMetricsByDomain_response_returns_expected_result()
    {
        const string json = "{                                                  " +
                   "  \"results\": [                                   " +
                   "    {                                              " +
                   "      \"reason\": \"520 rejection message\",       " +
                   "      \"domain\": \"example.com\",       " +
                   "      \"count_rejected\": 30,                      " +
                   "      \"rejection_category_id\": 2,                " +
                   "      \"rejection_type\": \"Generation Rejection\" " +
                   "    },                                             " +
                   "    {                                              " +
                   "      \"reason\": \"503 rejection message\",       " +
                   "      \"domain\": \"aol.com\",       " +
                   "      \"count_rejected\": 24,                      " +
                   "      \"rejection_category_id\": 1,                " +
                   "      \"rejection_type\": \"Policy Rejection\"     " +
                   "    }                                              " +
                   "  ]                                                " +
                   "}                                                  ";

        var response = JsonSerializer.Deserialize<RejectionReasonMetricsByDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].Reason.Should().Be("520 rejection message");
        response.Results[0].Domain.Should().Be("example.com");
        response.Results[0].CountRejected.Should().Be(30);
        response.Results[0].RejectionCategoryId.Should().Be(2);
        response.Results[0].RejectionType.Should().Be("Generation Rejection");
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void DelayReasonMetrics_response_returns_expected_result()
    {
        const string json = "{                                               " +
                   "  \"results\": [                                " +
                   "    {                                           " +
                   "      \"reason\": \"400 fake tempfail reason\", " +
                   "      \"count_delayed\": 200,                   " +
                   "      \"count_delayed_first\": 100              " +
                   "    },                                          " +
                   "    {                                           " +
                   "      \"reason\": \"425 fake tempfail reason\", " +
                   "      \"count_delayed\": 100,                   " +
                   "      \"count_delayed_first\": 50               " +
                   "    }                                           " +
                   "  ]                                             " +
                   "}                                               ";

        var response = JsonSerializer.Deserialize<DelayReasonMetricsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].Reason.Should().Be("400 fake tempfail reason");
        response.Results[0].CountDelayed.Should().Be(200);
        response.Results[0].CountDelayedFirst.Should().Be(100);
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void DelayReasonMetricsByDomain_response_returns_expected_result()
    {
        const string json = "{                                               " +
                   "  \"results\": [                                " +
                   "    {                                           " +
                   "      \"reason\": \"400 fake tempfail reason\", " +
                   "      \"domain\": \"example.com\", " +
                   "      \"count_delayed\": 200,                   " +
                   "      \"count_delayed_first\": 100              " +
                   "    },                                          " +
                   "    {                                           " +
                   "      \"reason\": \"425 fake tempfail reason\", " +
                   "      \"domain\": \"aol.com\", " +
                   "      \"count_delayed\": 100,                   " +
                   "      \"count_delayed_first\": 50               " +
                   "    }                                           " +
                   "  ]                                             " +
                   "}                                               ";

        var response = JsonSerializer.Deserialize<DelayReasonMetricsByDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].Reason.Should().Be("400 fake tempfail reason");
        response.Results[0].Domain.Should().Be("example.com");
        response.Results[0].CountDelayed.Should().Be(200);
        response.Results[0].CountDelayedFirst.Should().Be(100);
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void EngagementDetails_response_returns_expected_result()
    {
        const string json = "{                                         " +
                   "  \"results\": [                          " +
                   "    {                                     " +
                   "      \"link_name\": \"top banner link\", " +
                   "      \"count_clicked\": 123,             " +
                   "      \"count_raw_clicked\": 456          " +
                   "    },                                    " +
                   "    {                                     " +
                   "      \"link_name\": \"Raw URL\",         " +
                   "      \"count_clicked\": 123,             " +
                   "      \"count_raw_clicked\": 456          " +
                   "    }                                     " +
                   "  ]                                       " +
                   "}                                         ";

        var response = JsonSerializer.Deserialize<EngagementDetailsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].LinkName.Should().Be("top banner link");
        response.Results[0].CountClicked.Should().Be(123);
        response.Results[0].CountRawClicked.Should().Be(456);
        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void DeliveriesByAttempt_response_returns_expected_result()
    {
        const string json = "{                              " +
                   "  \"results\": [               " +
                   "    {                          " +
                   "      \"attempt\": \"1\",      " +
                   "      \"count_delivered\": 100 " +
                   "    },                         " +
                   "    {                          " +
                   "      \"attempt\": \"2\",      " +
                   "      \"count_delivered\": 150 " +
                   "    }                          " +
                   "  ]                            " +
                   "}                              ";

        var response = JsonSerializer.Deserialize<DeliveriesByAttemptResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response.Results[0].Attempt.Should().Be("1");
        response.Results[0].CountDelivered.Should().Be(100);
        response.Results.Count.Should().Be(2);
    }


}