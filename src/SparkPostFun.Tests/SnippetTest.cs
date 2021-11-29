using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests
{
    public class SnippetTest
    {
        [Fact]
        public async Task Create_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var request = new CreateSnippet
            {
                Id = "hello-test",
                Content = new SnippetContent
                {
                    Text = "Hello"
                }
            };
            var response = await client.CreateSnippet(request);

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(s => s.Results.Id.Should().NotBeEmpty());
        }

        [Fact]
        public async Task Retrieve_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.ListSnippets();

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(s => s.Results.Should().BeEmpty());
        }

        [Fact]
        public async Task Update_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.ListSnippets();

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(s => s.Results.Should().BeEmpty());
        }

        [Fact]
        public async Task Delete_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.ListSnippets();

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(s => s.Results.Should().BeEmpty());
        }



        [Fact]
        public async Task List_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.ListSnippets();

            using var scope = new AssertionScope();
            response.Should().BeRight(s => s.Results.Should().BeEmpty());
        }

        [Fact]
        public async Task Create_Retrieve_Update_List_Delete_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var createRequest = new CreateSnippet
            {
                Id = "hello-test1",
                Content = new SnippetContent
                {
                    Text = "Hello",
                    Html = "<p>Hello</p>"
                }
            };
            var createResponse = await client.CreateSnippet(createRequest);

            createResponse.Should().BeRight(s => s.Results.Id.Should().NotBeEmpty());

            var retrieveResponse = await client.RetrieveSnippet("hello-test1");

            retrieveResponse.Should().BeRight();

            var updateRequest = new UpdateSnippet
            {
            };

        }
    }
}