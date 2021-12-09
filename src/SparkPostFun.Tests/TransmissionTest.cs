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
            var transmission = CreateTransmission();
            transmission.Recipients.Should().NotBeNull();
        }

        [Fact]
        public void Transmission_should_not_be_missing_content()
        {
            var transmission = CreateTransmission();
            transmission.Content.Should().NotBeNull();
        }

        [Fact]
        public void Transmission_should_not_be_missing_metadata()
        {
            var transmission = CreateTransmission();
            transmission.Metadata.Should().NotBeNull();
        }

        [Fact]
        public void Transmission_should_not_be_missing_substition_data()
        {
            var transmission = CreateTransmission();
            transmission.SubstitutionData.Should().NotBeNull();
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

            var recipient = new Recipient { Address = new Address { Name = "Jacob Mojiwat", Email = "jmojiwat@gmail.com" } };
            var receipientList = new TransmissionRecipientList();
            receipientList.Recipients.Add(recipient);


            var transmission = CreateTransmission()
                .WithOptions(options)
                .WithRecipient(recipient);

            using(new AssertionScope())
            {
                transmission.Should().NotBeNull();
                transmission.Options.Should().Be(options);
                transmission.Recipients.Should().Be(receipientList);
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

            var receipientList = new TransmissionRecipientList();
            receipientList.Recipients.Add(new Recipient { Address = new Address { Name = "Jacob Mojiwat", Email = "jmojiwat@gmail.com" }});

            var transmission = new CreateTransmission { Options = options, Recipients = receipientList };

            using(new AssertionScope())
            {
                transmission.Should().NotBeNull();
                transmission.Options.Should().Be(options);
                transmission.Recipients.Should().Be(receipientList);
            }
        }

        [Fact]
        public void Create_returns_correct_result()
        {
            var transmission = CreateTransmission();

            transmission.Should().NotBeNull();
        }
    }
}