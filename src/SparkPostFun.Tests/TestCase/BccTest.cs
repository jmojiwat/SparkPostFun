using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions.LanguageExt;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.TestCase;

public class BccTest : IClassFixture<TestCaseEmailsFixture>
{
    private readonly TestCaseEmailsFixture fixture;

    public BccTest(TestCaseEmailsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Bcc_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new(new Address(fixture.ToAddress)),
            new(new Address(fixture.CcAddress))
            {
                Type = RecipientType.Cc
            },
            new(new Address(fixture.BccAddress))
            {
                Type = RecipientType.Bcc
            }
        };
        
        var senderAddress = new SenderAddress(fixture.FromAddress);
        const string subject = "SparkPost BCC / CC example";
        var content = new InlineContent(senderAddress, subject)
        {
            Text = "This message was sent To 1 recipient, 1 recipient was CC'd and 1 sneaky recipient was BCC'd."
        };
            
        var transmission = TransmissionExtensions.CreateTransmission(recipients, content);
            
        var response = await fixture.Client.CreateTransmission(transmission);

        response.Should().BeRight();
    }
}
