using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions.LanguageExt;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.TestCase
{
    public class TemplateTest : IClassFixture<TestCaseEmailsFixture>
    {
        private readonly TestCaseEmailsFixture fixture;

        public TemplateTest(TestCaseEmailsFixture fixture)
        {
            this.fixture = fixture;
        }

        private class Order
        {
            public int OrderId { get; set; }
            public string Desc { get; set; }
            public int Total { get; set; }
        }

        [Fact]
        public async Task Template_returns_expected_result()
        {
            var address = new Address(fixture.ToAddress);
            var recipients = new List<Recipient>
            {
                new(address)
                {
                    SubstitutionData = new Dictionary<string, object>
                    {
                        ["firstName"] = "Jane"
                    }
                }
            };
            
            var returnPath = new SenderAddress(fixture.FromAddress);
        
            var content = new StoredTemplateContent("orderSummary")
            {
                UseDraftTemplate = true
            };
        
            var substitutionData = new Dictionary<string, object>
            {
                ["title"] = "Dr",
                ["firstName"] = "Rick",
                ["lastName"] = "Sanchez",
                ["orders"] = new List<Order>
                {
                    new() { OrderId = 101, Desc = "Tomatoes", Total = 5},
                    new() { OrderId = 271, Desc = "Entropy", Total = 314}
                }
            };
            
            var transmission = TransmissionExtensions.CreateTransmission(recipients, content)
                .WithSubstitutionData(substitutionData)
                .WithReturnPath(returnPath);
            
            var response = await fixture.Client.CreateTransmission(transmission);

            response.Should().BeRight();
        }
    }
}