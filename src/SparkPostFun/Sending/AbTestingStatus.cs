using System.Text.Json.Serialization;

namespace SparkPostFun.Sending;

public enum AbTestingStatus
{
    Draft,
    Scheduled,
    Running,
    Cancelled,
    Completed
}