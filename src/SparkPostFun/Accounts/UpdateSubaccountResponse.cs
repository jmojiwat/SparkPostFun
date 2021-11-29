namespace SparkPostFun.Accounts
{
    public record UpdateSubaccountResponse
    {
        public UpdateSubaccountResponseResult Results { get; init; } = new();
    }
}