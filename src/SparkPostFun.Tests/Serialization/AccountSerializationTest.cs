using System;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Accounts;
using SparkPostFun.Infrastructure;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class AccountSerializationTest
    {
        [Fact]
        public void Account_request_returns_expected_result()
        {
            var account = new Account
            {
                CustomerId = 102938,
                CompanyName = "Example, Inc.",
                CountryCode = "US",
                AnniversaryDate = new DateTime(2019, 1, 11, 8, 0, 0),
                Created = new DateTime(2015, 1, 11, 8, 0, 0),
                Updated = new DateTime(2018, 4, 11, 8, 0, 0),
                Status = "active",
                StatusUpdated = new DateTime(2018, 4, 11, 8, 0, 0),
                StatusReasonCategory = string.Empty,
                TwoFactorAuthenticationRequired = false,
                ServiceLevel = "standard",
                Subscription = new AccountSubscription()
                {
                    Name = "500K",
                    Code = "500K-0817",
                    PlanVolume = 500000,
                    EffectiveDate = new DateTime(2018, 4, 11, 8, 0, 0),
                    SelfServe = true,
                    Type = "default"
                },
                Options = new AccountOptions
                {
                    SmtpTrackingDefault = true
                },
                Usage = new AccountUsage
                {
                    Timestamp = new DateTime(2018, 6, 26, 14, 48, 0),
                    Day = new AccountUsagePeriod
                    {
                        Limit = 50000,
                        Used = 8367,
                        Start = new DateTime(2018, 6, 25, 15, 0, 0),
                        End = new DateTime(2018, 6, 26, 15, 0, 0),
                    },
                    Month = new AccountUsagePeriod
                    {
                        Limit = 500000,
                        Used = 40321,
                        Start = new DateTime(2018, 6, 3, 8, 0, 0),
                        End = new DateTime(2018, 7, 3, 8, 0, 0),
                    }
                },
                Support = new AccountSupport
                {
                    Phone = false,
                    Online = true
                }
            };

            const string json = "{                                                     " +
                                "  \"customer_id\": 102938,                            " +
                                "  \"company_name\": \"Example, Inc.\",                " +
                                "  \"country_code\": \"US\",                           " +
                                "  \"anniversary_date\": \"2019-01-11T08:00:00.000Z\", " +
                                "  \"created\": \"2015-01-11T08:00:00.000Z\",          " +
                                "  \"updated\": \"2018-04-11T08:00:00.000Z\",          " +
                                "  \"status\": \"active\",                             " +
                                "  \"status_updated\": \"2018-04-11T08:00:00.000Z\",   " +
                                "  \"status_reason_category\": \"\",                   " +
                                "  \"tfa_required\": false,                            " +
                                "  \"service_level\": \"standard\",                    " +
                                "  \"subscription\": {                                 " +
                                "    \"name\": \"500K\",                               " +
                                "    \"code\": \"500K-0817\",                          " +
                                "    \"plan_volume\": 500000,                          " +
                                "    \"effective_date\": \"2018-04-11T08:00:00.000Z\", " +
                                "    \"self_serve\": true,                             " +
                                "    \"type\": \"default\"                             " +
                                "  },                                                  " +
                                "  \"options\": {                                      " +
                                "    \"smtp_tracking_default\": true                   " +
                                "  },                                                  " +
                                "  \"usage\": {                                        " +
                                "    \"timestamp\": \"2018-06-26T14:48:00.000Z\",      " +
                                "    \"day\": {                                        " +
                                "      \"limit\": 50000,                               " +
                                "      \"used\": 8367,                                 " +
                                "      \"start\": \"2018-06-25T15:00:00.000Z\",        " +
                                "      \"end\": \"2018-06-26T15:00:00.000Z\"           " +
                                "    },                                                " +
                                "    \"month\": {                                      " +
                                "      \"limit\": 500000,                              " +
                                "      \"used\": 40321,                                " +
                                "      \"start\": \"2018-06-03T08:00:00.000Z\",        " +
                                "      \"end\": \"2018-07-03T08:00:00.000Z\"           " +
                                "    }                                                 " +
                                "  },                                                  " +
                                "  \"support\": {                                      " +
                                "    \"phone\": false,                                 " +
                                "    \"online\": true                                  " +
                                "  }                                                   " +
                                "}                                                     ";

            var response = JsonSerializer.Deserialize<Account>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Should().BeEquivalentTo(account);
        }
        
            [Fact]
    public void UpdateAccount_request_returns_expected_result()
    {
        var request = new UpdateAccount
        {
            CompanyName = "SparkPost",
            Options = new AccountOptions
            {
                SmtpTrackingDefault = true
            }
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "company_name": "SparkPost",
              "options": {
                "smtp_tracking_default": true
              }
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("company_name").GetString().Should().Be("SparkPost");
        obj.GetProperty("options").GetProperty("smtp_tracking_default").GetBoolean().Should().BeTrue();
    }


        [Fact]
        public void RetrieveAccount_response_returns_expected_result()
        {
            const string json = "{                                                       " +
                                "  \"results\": {                                        " +
                                "    \"customer_id\": 102938,                            " +
                                "    \"company_name\": \"Example Inc\",                  " +
                                "    \"country_code\": \"US\",                           " +
                                "    \"anniversary_date\": \"2019-01-11T08:00:00.000Z\", " +
                                "    \"created\": \"2018-01-11T08:00:00.000Z\",          " +
                                "    \"updated\": \"2018-02-11T08:00:00.000Z\",          " +
                                "    \"status\": \"active\",                             " +
                                "    \"tfa_required\": false,                            " +
                                "    \"status_updated\": \"2018-12-21T13:21:41.442Z\",   " +
                                "    \"status_reason_category\": \"\",                   " +
                                "    \"subscription\": {                                 " +
                                "      \"code\": \"150K-0817\",                          " +
                                "      \"name\": \"150K\",                               " +
                                "      \"plan_volume\": 150000,                          " +
                                "      \"self_serve\": true,                             " +
                                "      \"type\": \"manual\"                              " +
                                "    },                                                  " +
                                "    \"support\": {                                      " +
                                "      \"online\": true,                                 " +
                                "      \"phone\": false                                  " +
                                "    },                                                  " +
                                "    \"pending_subscription\": {                         " +
                                "      \"code\": \"2.5M-0817\",                          " +
                                "      \"name\": \"2.5M\",                               " +
                                "      \"effective_date\": \"2017-04-11T00:00:00.000Z\"  " +
                                "    },                                                  " +
                                "    \"options\": {                                      " +
                                "      \"smtp_tracking_default\": false                  " +
                                "    },                                                  " +
                                "    \"usage\": {                                        " +
                                "      \"timestamp\": \"2016-03-17T05:19:00.932Z\",      " +
                                "      \"day\": {                                        " +
                                "        \"used\": 22003,                                " +
                                "        \"limit\": 50000,                               " +
                                "        \"start\": \"2016-03-16T05:30:00.932Z\",        " +
                                "        \"end\": \"2016-03-17T05:30:00.932Z\"           " +
                                "      },                                                " +
                                "      \"month\": {                                      " +
                                "        \"used\": 122596,                               " +
                                "        \"limit\": 1500000,                             " +
                                "        \"start\": \"2018-03-11T08:00:00.000Z\",        " +
                                "        \"end\": \"2016-04-11T08:00:00.000Z\"           " +
                                "      },                                                " +
                                "      \"sandbox\": {                                    " +
                                "        \"used\": 3,                                    " +
                                "        \"limit\": 5                                    " +
                                "      }                                                 " +
                                "    }                                                   " +
                                "  }                                                     " +
                                "}                                                       ";

            var response = JsonSerializer.Deserialize<RetrieveAccountResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.CustomerId.Should().Be(102938);
            response.Results.CompanyName.Should().Be("Example Inc");
            response.Results.CountryCode.Should().Be("US");
            response.Results.AnniversaryDate.Should().Be(new DateTime(2019, 1, 11, 8, 0, 0));
            response.Results.Created.Should().Be(new DateTime(2018, 1, 11, 8, 0, 0));
            response.Results.Updated.Should().Be(new DateTime(2018, 2, 11, 8, 0, 0));
            response.Results.Status.Should().Be("active");
            response.Results.TwoFactorAuthenticationRequired.Should().BeFalse();
            response.Results.StatusUpdated.Should().Be(new DateTime(2018, 12, 21, 13, 21, 41, 442));
            response.Results.StatusReasonCategory.Should().BeEmpty();
            
            response.Results.Subscription.Code.Should().Be("150K-0817");
            response.Results.Subscription.Name.Should().Be("150K");
            response.Results.Subscription.PlanVolume.Should().Be(150000);
            response.Results.Subscription.SelfServe.Should().BeTrue();
            response.Results.Subscription.Type.Should().Be("manual");
            
            response.Results.Support.Online.Should().BeTrue();
            response.Results.Support.Phone.Should().BeFalse();
            
            response.Results.PendingSubscription.Code.Should().Be("2.5M-0817");
            response.Results.PendingSubscription.Name.Should().Be("2.5M");
            response.Results.PendingSubscription.EffectiveDate.Should().Be(new DateTime(2017, 4, 11, 0, 0, 0));

            response.Results.Options.SmtpTrackingDefault.Should().BeFalse();
            
            response.Results.Usage.Timestamp.Should().Be(new DateTime(2016, 3, 17, 5, 19, 0, 932));
            response.Results.Usage.Day.Used.Should().Be(22003);
            response.Results.Usage.Day.Limit.Should().Be(50000);
            response.Results.Usage.Day.Start.Should().Be(new DateTime(2016, 3, 16, 5, 30, 0, 932));
            response.Results.Usage.Day.End.Should().Be(new DateTime(2016, 3, 17, 5, 30, 0, 932));
            response.Results.Usage.Month.Used.Should().Be(122596);
            response.Results.Usage.Month.Limit.Should().Be(1500000);
            response.Results.Usage.Month.Start.Should().Be(new DateTime(2018, 3, 11, 8, 0, 0));
            response.Results.Usage.Month.End.Should().Be(new DateTime(2016, 4, 11, 8, 0, 0));
            
            response.Results.Usage.Sandbox.Used.Should().Be(3);
            response.Results.Usage.Sandbox.Limit.Should().Be(5);
        }

        [Fact]
        public void UpdateAccount_response_returns_expected_result()
        {
            const string json = "{                  " +
                                "  \"results\": {   " +
                                "    \"message\": \"Account has been updated\" " +
                                "  }                " +
                                "}                  ";

            var response = JsonSerializer.Deserialize<UpdateAccountResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Message.Should().Be("Account has been updated");
        }
    }
}