using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Sending;
using Xunit;
using static SparkPostFun.Sending.TransmissionExtensions;


namespace SparkPostFun.Tests
{
    public class TransmissionTest
    {
        [Fact]
        public void Transmission_should_not_be_missing_recipients_list()
        {
            var recipient = new Recipient(new Address(string.Empty));
            var content = new InlineContent(new SenderAddress(string.Empty), string.Empty);
        
            var transmission = CreateTransmissionRequest(recipient, content);
        
            transmission.Recipients.Should().NotBeNull();
        }

        [Fact]
        public void Transmission_should_not_be_missing_content()
        {
            var recipient = new Recipient(new Address(string.Empty));
            var content = new InlineContent(new SenderAddress(string.Empty), string.Empty);
        
            var transmission = CreateTransmissionRequest(recipient, content);
        
            transmission.Content.Should().NotBeNull();
        }

        [Fact]
        public void Transmission_with_options_returns_correct_result1()
        {
            var options = new TransmissionOptions
            {
                ClickTracking = false,
                Transactional = true,
                IpPool = "my_ip_pool",
                InlineCss = true
            };


            var address = new Address("wilma@flintstone") { Name = "Wilma Flintstone" };
            var recipient = new Recipient(address);


            var transmission = CreateTransmissionRequest(recipient, new InlineContent(new SenderAddress(string.Empty), string.Empty))
                .WithOptions(options);

            using(new AssertionScope())
            {
                transmission.Should().NotBeNull();
                transmission.Options.Should().Be(options);
                transmission.Recipients.Should().NotBeNull();
                (transmission.Recipients as IList<Recipient>)?.Should().Contain(recipient);
            }
        }

        [Fact]
        public void Transmission_with_options_returns_correct_result()
        {
            var options = new TransmissionOptions
            {
                ClickTracking = false,
                Transactional = true,
                IpPool = "my_ip_pool",
                InlineCss = true
            };

            var address = new Address("wilma@flintstone.com") { Name = "Wilma Flintstone" };
            var recipient = new Recipient(address);

            var transmission = new TransmissionRequest(recipient, new InlineContent(new SenderAddress(string.Empty), string.Empty))
            {
                Options = options
            };

            using var scope = new AssertionScope();
            transmission.Should().NotBeNull();
            transmission.Options.Should().Be(options);
            transmission.Recipients.Should().Be(new List<Recipient> { recipient });
        }
    }
}