﻿namespace SparkPostFun.Sending
{
    public record Attachment
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
    }
}