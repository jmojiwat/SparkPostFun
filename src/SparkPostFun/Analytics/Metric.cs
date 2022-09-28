namespace SparkPostFun.Analytics
{
    public enum Metric
    {
        CountInjected,
        CountBounce,
        CountRejected,
        CountDelivered,
        CountDelieveredFirst,
        CountDeliveredSubsequent,
        TotalDeliveryTimeFirst,
        TotalDeliveryTimeSubsequent,
        TotalMessageVolume,
        CountPolicyRejection,
        CountGenerationRejection,
        CountGenerationFailed,
        CountInbandBounce,
        CountOutofbandBounce,
        CountSoftBounce,
        CountHardBounce,
        CountBlockBounce,
        CountAdminBounce,
        CountUndeterminedBounce,
        CountDelayed,
        CountDelayedFirst,
        CountRendered,
        CountUniqueRendered,
        CountUniqueConfirmedOpened,
        CountClicked,
        CountUniqueClicked,
        CountTargeted,
        CountSent,
        CountAccepted,
        CountSpamComplaint,
        CountInboxPanel,
        CountSpamPanel,
        CountInboxSeed,
        CountSpamSeed,
        CountMovedToInbox,
        CountMovedToSpam,
    }
}

/*public class Metric
{
    private readonly string value;

    private Metric(string value)
    {
        this.value = value;
    }

    public static Metric CountInjected = new Metric("count_injected");
    public static Metric CountBounce = new Metric("count_bounce");
    public static Metric CountRejected = new Metric("count_rejected");
    
    public static Metric CountDelivered = new Metric("count_delivered");
    public static Metric CountDelieveredFirst = new Metric("count_delivered_first");
    
    public static Metric CountDeliveredSubsequent = new Metric("count_delivered_subsequent");
    public static Metric TotalDeliveryTimeFirst = new Metric("total_delivery_time_first");
    
    public static Metric TotalDeliveryTimeSubsequent = new Metric("total_delivery_time_subsequent");
    public static Metric TotalMessageVolume = new Metric("total_msg_volume");
    
    public static Metric CountPolicyRejection = new Metric("count_policy_rejection");
    public static Metric CountGenerationRejection = new Metric("count_generation_rejection");
    
    public static Metric CountGenerationFailed = new Metric("count_generation_failed");
    public static Metric CountInbandBounce = new Metric("count_inband_bounce");
    
    public static Metric CountOutofbandBounce = new Metric("count_outofband_bounce");
    public static Metric CountSoftBounce = new Metric("count_soft_bounce");
    public static Metric CountHardBounce = new Metric("count_hard_bounce");
    
    public static Metric CountBlockBounce = new Metric("count_block_bounce");
    public static Metric CountAdminBounce = new Metric("count_admin_bounce");
    
    public static Metric CountUndeterminedBounce = new Metric("count_undetermined_bounce");
    public static Metric CountDelayed = new Metric("count_delayed");
    public static Metric CountDelayedFirst = new Metric("count_delayed_first");
    
    public static Metric CountRendered = new Metric("count_rendered");
    public static Metric CountUniqueRendered = new Metric("count_unique_rendered");
    
    public static Metric CountUniqueConfirmedOpened = new Metric("count_unique_confirmed_opened");
    public static Metric CountClicked = new Metric("count_clicked");
    
    public static Metric CountUniqueClicked = new Metric("count_unique_clicked");
    public static Metric CountTargeted = new Metric("count_targeted");
    public static Metric CountSent = new Metric("count_sent");
    public static Metric CountAccepted = new Metric("count_accepted");
    
    public static Metric CountSpamComplaint = new Metric("count_spam_complaint");
    public static Metric CountInboxPanel = new Metric("count_inbox_panel");
    public static Metric CountSpamPanel = new Metric("count_spam_panel");
    
    public static Metric CountInboxSeed = new Metric("count_inbox_seed");
    public static Metric CountSpamSeed = new Metric("count_spam_seed");
    public static Metric CountMovedToInbox = new Metric("count_moved_to_inbox");
    
    public static Metric CountMovedToSpam = new Metric("count_moved_to_spam");

    public override string ToString() => value;
}*/