namespace SparkPostFun.Accounts
{
    public record CreateSubaccountResponse
    {
        public CreateSubaccountResponseResult Results { get; init; } = new();
    }
}