using System.Text.RegularExpressions;

namespace SparkPostFun.Infrastructure
{
    public static class StringExtensions
    {
        public static string SnakeCase(this string input)
        {
            return Regex.Replace(
                Regex.Replace(
                    Regex.Replace(input, @"([\p{Lu}]+)([\p{Lu}][\p{Ll}])", "$1_$2"), @"([\p{Ll}\d])([\p{Lu}])", "$1_$2"), @"[-\s]", "_").ToLower();
        }
        
        public static string PascalCase(this string input)
        {   
            return Regex.Replace(input, "(?:^|_| +)(.)", match => match.Groups[1].Value.ToUpper());
        }
    }
}