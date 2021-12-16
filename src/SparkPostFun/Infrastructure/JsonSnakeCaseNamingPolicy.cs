using System.Text.Json;

namespace SparkPostFun.Infrastructure
{
    public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.SnakeCase();
    }
}