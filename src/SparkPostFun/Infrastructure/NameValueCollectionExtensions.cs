using System;
using System.Collections.Specialized;
using System.Net;
using LanguageExt;

namespace SparkPostFun.Infrastructure;

public static class NameValueCollectionExtensions
{
    public static string NameValueCollectionToQueryString(NameValueCollection collection)
    {
        return collection.AllKeys
            .Map(key => $"{key}={WebUtility.UrlEncode(collection[key])}")
            .Apply(a => string.Join('&', a));
    }

    public static NameValueCollection AddIfNotNull(string key, string value, NameValueCollection collection)
    {
        if (value is not null)
        {
            collection.Add(key, value);
        }
        return collection;
    }

    public static NameValueCollection AddIfNotNull(string key, DateTime? value, NameValueCollection collection)
    {
        if (value is not null)
        {
            collection.Add(key, value.ToString());
        }
        return collection;
    }

    public static NameValueCollection AddIfNotNull(string key, bool? value, NameValueCollection collection)
    {
        if (value is not null)
        {
            collection.Add(key, value.ToString().ToLowerInvariant());
        }
        return collection;
    }

    public static NameValueCollection AddIfNotNull(string key, object value, NameValueCollection collection)
    {
        if (value is not null)
        {
            collection.Add(key, value.ToString());
        }
        return collection;
    }

}