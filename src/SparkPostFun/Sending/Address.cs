using System.Text.Json.Serialization;

namespace SparkPostFun.Sending;

public record Address(string Email)
{
    public string Name { get; init; }
    
    [JsonInclude]
    public string HeaderTo { get; internal init; }
}