using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions.LanguageExt;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.TestCase;

public class InlineTest : IClassFixture<TestCaseEmailsFixture>
{
    private readonly TestCaseEmailsFixture fixture;

    public InlineTest(TestCaseEmailsFixture fixture)
    {
        this.fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task Inline_returns_expected_result()
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
        
        var senderAddress = new SenderAddress(fixture.FromAddress);
        var content = new InlineContent(senderAddress, "SparkPost online content example")
        {
            Text = "Greetings {{firstName or 'recipient'}}\nHello from C# land.",
            Html = "<html><body><h2>Greetings {{firstName or 'recipient'}}</h2><p>Hello from C# land.</p></body></html>"
        };
        
        var substitutionData = new Dictionary<string, object>
        {
            ["firstName"] = "Oh Ye Of Little Name"
        };
            
        var transmission = TransmissionExtensions.CreateTransmission(recipients, content)
            .WithSubstitutionData(substitutionData);
            
        var response = await fixture.Client.CreateTransmission(transmission);

        response.Should().BeRight();
    }
}