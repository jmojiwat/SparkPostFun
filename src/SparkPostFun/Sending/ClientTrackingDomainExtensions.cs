﻿using System.Collections.Specialized;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static SparkPostFun.Infrastructure.NameValueCollectionExtensions;

namespace SparkPostFun.Sending;

public static class ClientTrackingDomainExtensions
{
    public static Task<Either<ErrorResponse, CreateTrackingDomainResponse>> CreateTrackingDomain(this Client @this, CreateTrackingDomain request)
    {
        var requestUrl = $"/api/{@this.Version}/tracking-domains";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<CreateTrackingDomainResponse>);
    }

    public static Task<Either<ErrorResponse, Unit>> DeleteTrackingDomain(this Client @this, string domain)
    {
        var requestUrl = $"/api/{@this.Version}/tracking-domains/{domain}";
        return @this.Delete(requestUrl);
    }

    public static Task<Either<ErrorResponse, ListSendingDomainsResponse>> ListTrackingDomains(this Client @this) =>
        ListTrackingDomains(@this, null, null);

    public static Task<Either<ErrorResponse, ListSendingDomainsResponse>> ListTrackingDomains(this Client @this, bool? @default, IList<int> subaccounts)
    {
        var collection = new NameValueCollection();
        if (@default != null)
        {
            collection.Add("default", @default.ToString());
        }

        if (subaccounts != null)
        {
            collection.Add("subaccounts", string.Join(",", subaccounts));
        }

        var queryString = ToQueryString(collection);
        var requestUrl = $"/api/{@this.Version}/tracking-domains?{queryString}";
        return @this.Get<ListSendingDomainsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrieveTrackingDomainResponse>> RetrieveTrackingDomain(this Client @this, string domain)
    {
        var requestUrl = $"/api/{@this.Version}/tracking-domains/{domain}";
        return @this.Get<RetrieveTrackingDomainResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, UpdateTrackingDomainResponse>> UpdateTrackingDomain(this Client @this, string domain,
        UpdateTrackingDomain request)
    {
        var requestUrl = $"/api/{@this.Version}/tracking-domains/{domain}";
        return @this.Put(requestUrl, request)
            .MapAsync(ToResponse<UpdateTrackingDomainResponse>);
    }

    public static Task<Either<ErrorResponse, VerifyTrackingDomainResponse>> VerifyTrackingDomain(this Client @this, string domain)
    {
        var requestUrl = $"/api/{@this.Version}/tracking-domains/{domain}/verify";
        return @this.Post(requestUrl)
            .MapAsync(ToResponse<VerifyTrackingDomainResponse>);
    }
}