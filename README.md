# SparkPostFun is a C# Library for SparkPost

SparkPostFun is a functional style C# library using [LanguageExt](https://github.com/louthy/language-ext) for [SparkPost API](https://developers.sparkpost.com/api/).

## Features
- All client calls returns ```Task<Either<TError, TResponse>>``` monad.
- Invalid states unrepresentable - required fields are obvious when constructing requests.
- Immutable data.
- Doesn't throw exceptions.

## Installation
To install via NuGet, run the following command in the [Package Manager Console](http://docs.nuget.org/consume/package-manager-console):
```
PM> Install-Package SparkPostFun
```
## Usage


```cs
var content = new StoredTemplateContent("black_friday")
{
    UseDraftTemplate = true
};

var substitutionData = new Dictionary<string, object>
{
    ["discount"] = "25%"
};

var recipient = new Recipient(new Address("wilma@flintstone.com") { Name = "Wilma Flintstone" })
{
    SubstitutionData = new Dictionary<string, object>
    {
        ["first_name"] = "Wilma",
        ["last_name"] = "Flintstone"
    }
};

var transmission = TransmissionExtensions.CreateTransmission(recipient, content)
    .WithSubstitutionData(substitutionData);

var response = await client.CreateTransmission(transmission);

response.Match(
  success => ...,
  fail => ...);
```
