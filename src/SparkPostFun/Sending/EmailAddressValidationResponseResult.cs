namespace SparkPostFun.Sending
{
    public record EmailAddressValidationResponseResult
    {
        public bool Valid { get; init; }
        public RecipientValidationResult? Result { get; init; }
        public int DeliveryConfidence { get; init; }
        public RecipientValidationReason? Reason { get; init; }
        public bool IsRole { get; init; }
        public bool IsDisposable { get; init; }
        public bool IsFree { get; init; }
        public string DidYouMean { get; init; }
    }
}