# SparkPostFun is a C# Library for SparkPost

SparkPostFun is a functional style C# library using [LanguageExt](https://github.com/louthy/language-ext) for [SparkPost API](https://developers.sparkpost.com/api/).

## Installation
To install via NuGet, run the following command in the [Package Manager Console](http://docs.nuget.org/consume/package-manager-console):
```
PM> Install-Package SparkPostFun
```
## Usage

All client calls returns ```Task<Either<TError, TResponse>>```.

```cs
...

var content = new StoredTemplateContent
{
    TemplateId = "black_friday",
    UseDraftTemplate = true
};

var substitutionData = new Dictionary<string, object>
{
    ["discount"] = "25%"
};

var recipient = new Recipient
{
    Address = new Address { Email = "wilma@flintstone.com", Name = "Wilma Flintstone" },
    SubstitutionData = new Dictionary<string, object>
    {
        ["first_name"] = "Wilma",
        ["last_name"] = "Flintstone"
    }
};

var transmission = TransmissionExtensions.CreateTransmission()
    .WithContent(content)
    .WithSubstitutionData(substitutionData)
    .WithRecipient(recipient);

var response = await client.CreateTransmission(transmission);

response.Match(
  success => ...,
  fail => ...);
```

However, there are extension method helpers that can wrap the client return type if you prefer a more idiomatic approach.

```cs
...
var response = await ResponseExtensions.Wrap(client.CreateTransmission(transmission));

if(response.StatusCode == HttpStatusCode.OK) {
  ...
}
```

To use this extension method helpers, you also need to install the ```SparkPostFun.ResponseWrappers``` NuGet package.

