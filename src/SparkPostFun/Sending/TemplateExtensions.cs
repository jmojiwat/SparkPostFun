using System.Collections.Specialized;
using System.Text.Json;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;
using static SparkPostFun.ClientExtensions;
using static SparkPostFun.Infrastructure.NameValueCollectionExtensions;

namespace SparkPostFun.Sending
{
    public static class TemplateExtensions
    {
        public static Reader<SparkPostEnvironment, Task<Either<TemplateErrorResponse, CreateTemplateResponse>>> CreateTemplate(CreateTemplate request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates"
                select env.Client.Post(requestUrl, request)
                    .MapAsync(ToResponse<TemplateErrorResponse, CreateTemplateResponse>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<TemplateErrorResponse, CreateTemplateResponse>>> CreateRfc822Template(CreateRfc822Template request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates"
                select env.Client.Post(requestUrl, request)
                    .MapAsync(ToResponse<TemplateErrorResponse, CreateTemplateResponse>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteTemplate(string id)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}"
                select env.Client.Delete(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListTemplatesResponse>>> ListTemplates()
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates"
                select env.Client.Get<ListTemplatesResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListTemplatesResponse>>> ListTemplates(bool? draft, bool? sharedWithSubaccounts)
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

            var queryString = NameValueCollectionToQueryString(collection);
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates?{queryString}"
                select env.Client.Get<ListTemplatesResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, PreviewInlineTemplateResponse>>> PreviewInlineTemplate(PreviewInlineTemplate request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/utils/content-previewer"
                select env.Client.Post(requestUrl, request)
                    .MapAsync(ToResponse<PreviewInlineTemplateResponse>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, PreviewTemplateResponse>>> PreviewTemplate(string id, PreviewTemplate request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}/preview"
                select env.Client.Post(requestUrl, request)
                    .MapAsync(ToResponse<PreviewTemplateResponse>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, PreviewTemplateResponse>>> PreviewTemplate(string id, PreviewTemplate request, bool draft)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}/preview?draft={draft}"
                select env.Client.Post(requestUrl, request)
                    .MapAsync(ToResponse<PreviewTemplateResponse>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> PublishTemplateDraft(string id)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}"
                select env.Client.Put(requestUrl, new PublishTemplateDraft())
                    .MapAsync(ToResponse<Unit>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveTemplateResponse>>> RetrieveTemplate(string id)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}"
                select env.Client.Get<RetrieveTemplateResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveTemplateResponse>>> RetrieveTemplate(string id, bool draft)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}?draft={draft}"
                select env.Client.Get<RetrieveTemplateResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> UpdatePublishedTemplate(string id, UpdatePublishedTemplate request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}"
                select env.Client.Put(requestUrl, request)
                    .MapAsync(ToResponse<Unit>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> UpdatePublishedTemplate(string id, UpdatePublishedTemplate template, bool updatePublished)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}?update_published={updatePublished}"
                select env.Client.Put(requestUrl, template)
                    .MapAsync(ToResponse<Unit>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> UpdateTemplateDraft(string id, UpdateTemplate request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/templates/{id}"
                select env.Client.Put(requestUrl, request)
                    .MapAsync(ToResponse<Unit>);
        }


        public static SenderAddress ParseTemplateContentFrom(TemplateContent content)
        {
            return content.From switch
            {
                SenderAddress sender => sender,
                string email => new SenderAddress(email),
                JsonElement element => new SenderAddress(
                    element.GetProperty("email").GetString())
                {
                    Name = element.GetProperty("name").GetString()
                },
                _ => new SenderAddress(string.Empty)
            };
        }
    }
}