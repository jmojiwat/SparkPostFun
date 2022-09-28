using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Accounts;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests
{
    public class AccountTest
    {
        [Theory, AccountAutoData]
        public async Task RetrieveAccount_returns_expected_result(Client client)
        {
            var result = await client.RetrieveAccount("usage");
        
            result.Should().BeRight();
        }

        private class AccountAutoDataAttribute : AutoDataAttribute
        {
            public AccountAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
            {
            }
        }

        private class Customization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                var configuration = new ConfigurationBuilder()
                    .AddUserSecrets(GetExecutingAssembly())
                    .Build();
            
                var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
                var httpClient = new HttpClient();
                var client = new Client(httpClient, apiKey);

                fixture.Register(() => client);
            }
        }
    }
}

