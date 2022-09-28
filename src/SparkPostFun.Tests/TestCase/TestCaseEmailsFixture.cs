using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace SparkPostFun.Tests.TestCase
{
    public class TestCaseEmailsFixture : IDisposable
    {
        public TestCaseEmailsFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.Load("SparkPostFun.Tests"))
                .Build();

            FromAddress = configuration.GetSection("TestCaseEmails:FromAddress").Value;
            ToAddress = configuration.GetSection("TestCaseEmails:ToAddress").Value;
            CcAddress = configuration.GetSection("TestCaseEmails:CcAddress").Value;
            BccAddress = configuration.GetSection("TestCaseEmails:BccAddress").Value;

            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var httpClient = new HttpClient();
            var client = new Client(httpClient, apiKey);

            Client = client;

        }

        public string BccAddress { get; }

        public string CcAddress { get; }

        public string ToAddress { get; }

        public string FromAddress { get; }

        public Client Client { get; }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}