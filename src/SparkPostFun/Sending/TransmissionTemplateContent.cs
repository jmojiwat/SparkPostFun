namespace SparkPostFun.Sending
{
    public record TransmissionTemplateContent
    {
        public string TemplateId { get; init; }
        public bool? UseDarftTemplate { get; init; }
    }
}