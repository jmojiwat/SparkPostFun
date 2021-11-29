using System.Text.Json;

namespace SparkPostFun.Infrastructure
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.SnakeCase();
    }
}