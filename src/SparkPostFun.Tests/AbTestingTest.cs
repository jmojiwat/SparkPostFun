using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests
{
    public class AbTestingTest
    {
        [Fact]
        public async Task Retrieve_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.RetrieveTemplate("my-first-email");

        }
    }
}