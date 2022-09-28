using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions.LanguageExt;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.TestCase
{
    public class CcTest : IClassFixture<TestCaseEmailsFixture>
    {
        private readonly TestCaseEmailsFixture fixture;

        public CcTest(TestCaseEmailsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Cc_returns_expected_result()
        {
            var recipients = new List<Recipient>
            {
                new(new Address(fixture.ToAddress)),
                new(new Address(fixture.CcAddress))
                {
                    Type = RecipientType.Cc
                }
            };
            var senderAddress = new SenderAddress(fixture.FromAddress);
            var subject = "SparkPost CC example";
            var content = new InlineContent(senderAddress, subject)
            {
                Text = "This message was sent To 1 recipient, 1 recipient was CC'd."
            };
            
            var transmission = TransmissionExtensions.CreateTransmission(recipients, content);
            
            var response = await fixture.Client.CreateTransmission(transmission);

            response.Should().BeRight();
        }
    }
}