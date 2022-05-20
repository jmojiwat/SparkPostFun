using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Analytics;
using Xunit;

namespace SparkPostFun.Tests;

public class MetricsTest
{
    [Theory, MetricsAutoData]
    public async Task AdvancedQueryJsonSchema_returns_expected_result(Client client)
    {
        var response = await client.AdvancedQueryJsonSchema();

        response.Should().BeRight();
    }
    
    [Theory(Skip = "Available to Enterprise customers only"), MetricsAutoData]
    public async Task DiscoverabilityLinks_returns_expected_result(Client client)
    {
        var response = await client.DiscoverabilityLinks();

        response.Should().BeRight();
    }
    
    /*
    [Theory, MetricsAutoData]
    public async Task MetricsSummary_returns_expected_result(Client client)
    {
        var response = await client.MetricsSummary();

        response.Should().BeRight();
    }
    */

    [Theory, MetricsAutoData]
    public async Task IpPoolsMetrics_returns_expected_result(Client client)
    {
        var response = await client.IpPoolsMetrics();

        response.Should().BeRight();
    }

    [Theory, MetricsAutoData]
    public async Task SendingIpsMetrics_returns_expected_result(Client client)
    {
        var response = await client.SendingIpsMetrics();

        response.Should().BeRight();
    }

    [Theory, MetricsAutoData]
    public async Task MailboxProviderRegionsMetrics_returns_expected_result(Client client)
    {
        var response = await client.MailboxProviderRegionsMetrics();

        response.Should().BeRight();
    }

    [Theory, MetricsAutoData]
    public async Task MailboxProvidersMetrics_returns_expected_result(Client client)
    {
        var response = await client.MailboxProvidersMetrics();

        response.Should().BeRight();
    }
    
    [Theory, MetricsAutoData]
    public async Task CampaignsMetrics_returns_expected_result(Client client)
    {
        var response = await client.CampaignsMetrics();

        response.Should().BeRight();
    }

    [Theory, MetricsAutoData]
    public async Task TemplatesMetrics_returns_expected_result(Client client)
    {
        var response = await client.TemplatesMetrics();

        response.Should().BeRight();
    }
    
    [Theory, MetricsAutoData]
    public async Task DomainsMetrics_returns_expected_result(Client client)
    {
        var response = await client.DomainsMetrics();

        response.Should().BeRight();
    }
    
    [Theory, MetricsAutoData]
    public async Task SubjectCampaignsMetrics_returns_expected_result(Client client)
    {
        var response = await client.SubjectCampaignsMetrics();

        response.Should().BeRight();
    }

    [Theory, MetricsAutoData]
    public async Task SendingDomainsMetrics_returns_expected_result(Client client)
    {
        var response = await client.SendingDomainsMetrics();

        response.Should().BeRight();
    }

    [Theory, MetricsAutoData]
    public async Task InboxRateMetrics_returns_expected_result(Client client)
    {
        var response = await client.InboxRateMetrics(DateTime.Now);

        response.Should().BeRight();
    }

    private class MetricsAutoDataAttribute : AutoDataAttribute
    {
        public MetricsAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
        {
        }
    }

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
                var client = new Client(httpClient, apiKey);
                return client;
            });
        }
    }

}