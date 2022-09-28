using System.Collections.Specialized;
using System.Net;
using LanguageExt;

namespace SparkPostFun.Infrastructure
{
    public static class NameValueCollectionExtensions
    {
        public static string ToQueryString(NameValueCollection collection)
        {
            return collection.AllKeys
                .Map(key => $"{key}={WebUtility.UrlEncode(collection[key])}")
                .Apply(a => string.Join('&', a));

        }

    }
}