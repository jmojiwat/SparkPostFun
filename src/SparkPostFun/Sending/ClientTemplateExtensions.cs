﻿using System.Collections.Specialized;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static SparkPostFun.Infrastructure.NameValueCollectionExtensions;

namespace SparkPostFun.Sending;

public static class ClientTemplateExtensions
{
    public static Task<Either<TemplateErrorResponse, CreateTemplateResponse>> CreateTemplate(this Client @this, CreateTemplate request)
    {
        var requestUrl = $"/api/{@this.Version}/templates";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<TemplateErrorResponse, CreateTemplateResponse>);
    }

    public static Task<Either<TemplateErrorResponse, CreateTemplateResponse>> CreateRfc822Template(this Client @this, CreateRfc822Template request)
    {
        var requestUrl = $"/api/{@this.Version}/templates";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<TemplateErrorResponse, CreateTemplateResponse>);
    }

    public static Task<Either<ErrorResponse, Unit>> DeleteTemplate(this Client @this, string id)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}";
        return @this.Delete(requestUrl);
    }

    public static Task<Either<ErrorResponse, ListTemplatesResponse>> ListTemplates(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/templates";
        return @this.Get<ListTemplatesResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, ListTemplatesResponse>> ListTemplates(this Client @this, bool? draft, bool? sharedWithSubaccounts)
    {
        var collection = new NameValueCollection();
        if (draft != null)
        {
            collection.Add("draft", draft.ToString());
        }

        if (sharedWithSubaccounts != null)
        {
            collection.Add("shared_with_subaccounts", sharedWithSubaccounts.ToString());
        }

        var queryString = ToQueryString(collection);
        var requestUrl = $"/api/{@this.Version}/templates?{queryString}";
        return @this.Get<ListTemplatesResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, PreviewInlineTemplateResponse>> PreviewInlineTemplate(this Client @this, PreviewInlineTemplate request)
    {
        var requestUrl = $"/api/{@this.Version}/utils/content-previewer";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<PreviewInlineTemplateResponse>);
    }

    public static Task<Either<ErrorResponse, PreviewTemplateResponse>> PreviewTemplate(this Client @this, string id, PreviewTemplate request)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}/preview";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<PreviewTemplateResponse>);
    }

    public static Task<Either<ErrorResponse, PreviewTemplateResponse>> PreviewTemplate(this Client @this, string id, PreviewTemplate request, bool draft)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}/preview?draft={draft}";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<PreviewTemplateResponse>);
    }

    public static Task<Either<ErrorResponse, Unit>> PublishTemplateDraft(this Client @this, string id)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}";
        return @this.Put(requestUrl, new PublishTemplateDraft())
            .MapAsync(ToResponse<Unit>);
    }

    public static Task<Either<ErrorResponse, RetrieveTemplateResponse>> RetrieveTemplate(this Client @this, string id)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}";
        return @this.Get<RetrieveTemplateResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrieveTemplateResponse>> RetrieveTemplate(this Client @this, string id, bool draft)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}?draft={draft}";
        return @this.Get<RetrieveTemplateResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, Unit>> UpdatePublishedTemplate(this Client @this, string id, UpdatePublishedTemplate request)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}";
        return @this.Put(requestUrl, request)
            .MapAsync(ToResponse<Unit>);
    }

    public static Task<Either<ErrorResponse, Unit>> UpdatePublishedTemplate(this Client @this, string id, UpdatePublishedTemplate template,
        bool updatePublished)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}?update_published={updatePublished}";
        return @this.Put(requestUrl, template)
            .MapAsync(ToResponse<Unit>);
    }

    public static Task<Either<ErrorResponse, Unit>> UpdateTemplateDraft(this Client @this, string id, UpdateTemplate request)
    {
        var requestUrl = $"/api/{@this.Version}/templates/{id}";
        return @this.Put(requestUrl, request)
            .MapAsync(ToResponse<Unit>);
    }
}