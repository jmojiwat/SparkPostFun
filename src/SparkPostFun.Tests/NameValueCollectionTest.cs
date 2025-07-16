using System;
using System.Collections.Specialized;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using Xunit;

namespace SparkPostFun.Tests;

public class NameValueCollectionTest
{
    [Fact]
    public void AddIfNotNull_returns_expected_result()
    {
        var collection = new NameValueCollection();
        const string key = "a";
        const bool o = true;

        NameValueCollectionExtensions.AddIfNotNull(key, o, collection);

        collection[key].Should().Be("true");
    }

    [Theory]
    [InlineData(true, "true")]
    [InlineData(false, "false")]
    [InlineData(null, null)]
    public void AddIfNotNull_with_bool_returns_expected_result1(bool? o, string expected)
    {
        var collection = new NameValueCollection();
        const string key = "a";
        NameValueCollectionExtensions.AddIfNotNull(key, o, collection);

        collection[key].Should().Be(expected);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("Hello", "Hello")]
    [InlineData(null, null)]
    public void AddIfNotNull_with_string_returns_expected_result1(string o, string expected)
    {
        var collection = new NameValueCollection();
        const string key = "a";
        NameValueCollectionExtensions.AddIfNotNull(key, o, collection);

        collection[key].Should().Be(expected);
    }

    [Fact]
    public void AddIfNotNull_with_valid_datetime_returns_expected_result()
    {
        var collection = new NameValueCollection();
        const string key = "a";
        var date = new DateTime(2025, 1, 1);
        NameValueCollectionExtensions.AddIfNotNull(key, date, collection);

        collection[key].Should().Be("2025-01-01");
    }

    /*
    [Fact]
    public void AddIfNotNull_with_null_datetime_returns_expected_result()
    {
        var collection = new NameValueCollection();
        const string key = "a";
        var date = new DateTime(2025, 1, 1);
        NameValueCollectionExtensions.AddIfNotNull(key, (DateTime)null, collection);

        collection[key].Should().Be("2025-01-01");
    }
*/
}