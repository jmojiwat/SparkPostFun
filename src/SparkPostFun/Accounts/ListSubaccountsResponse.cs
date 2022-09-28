using System.Collections.Generic;

namespace SparkPostFun.Accounts
{
    public record ListSubaccountsResponse
    {
        public IList<ListSubaccountsResponseResult> Results { get; init; } = new List<ListSubaccountsResponseResult>();
    }
}