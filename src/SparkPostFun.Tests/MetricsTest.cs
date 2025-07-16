using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Analytics;
using Xunit;

namespace SparkPostFun.Tests
{
    public class MetricsTest
    {
        [Theory, MetricsAutoData]
        public async Task AdvancedQueryJsonSchema_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.AdvancedQueryJsonSchema()(env).IfFailThrow();

            response.Should().BeRight();
        }
    
        [Theory(Skip = "Available to Enterprise customers only"), MetricsAutoData]
        public async Task DiscoverabilityLinks_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.DiscoverabilityLinks()(env).IfFailThrow();

            response.Should().BeRight();
        }
    
        [Theory, MetricsAutoData]
        public async Task MetricsSummary_returns_expected_result(SparkPostEnvironment env)
        {
            var today = DateTime.Today;
            var metrics = new List<Metric> { Metric.CountAccepted };

            var response = await MetricsExtensions.MetricsSummary(today, metrics)(env).IfFailThrow();

            response.Should().BeRight();
        }

        [Theory, MetricsAutoData]
        public async Task IpPoolsMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.IpPoolsMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }

        [Theory, MetricsAutoData]
        public async Task SendingIpsMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.SendingIpsMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }

        [Theory, MetricsAutoData]
        public async Task MailboxProviderRegionsMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.MailboxProviderRegionsMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }

        [Theory, MetricsAutoData]
        public async Task MailboxProvidersMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.MailboxProvidersMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }
    
        [Theory, MetricsAutoData]
        public async Task CampaignsMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.CampaignsMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }

        [Theory, MetricsAutoData]
        public async Task TemplatesMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.TemplatesMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }
    
        [Theory, MetricsAutoData]
        public async Task DomainsMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.DomainsMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }
    
        [Theory, MetricsAutoData]
        public async Task SubjectCampaignsMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.SubjectCampaignsMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }

        [Theory, MetricsAutoData]
        public async Task SendingDomainsMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.SendingDomainsMetrics()(env).IfFailThrow();

            response.Should().BeRight();
        }

        [Theory, MetricsAutoData]
        public async Task InboxRateMetrics_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await MetricsExtensions.InboxRateMetrics(DateTime.Now)(env).IfFailThrow();

            response.Should().BeRight();
        }

        private class MetricsAutoDataAttribute() : AutoDataAttribute(() => new Fixture().Customize(new Customization()));

        private class Customization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Register(() =>
                {
                    var configuration = new ConfigurationBuilder()
                        .AddUserSecrets(Assembly.GetExecutingAssembly())
                        .Build();

                    var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
                    var httpClient = new HttpClient();

                    var env = SparkPostEnvironmentExtension.InitializeEnvironment(httpClient, apiKey);
                    return env;
                });
            }
        }

    }
}