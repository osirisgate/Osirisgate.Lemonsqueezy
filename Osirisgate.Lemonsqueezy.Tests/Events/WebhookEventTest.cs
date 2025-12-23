using Osirisgate.Lemonsqueezy.Events;

namespace Osirisgate.Lemonsqueezy.Tests.Events;

public sealed class WebhookEventTest
{
    [Fact]
    public void TestIsEventType_WithSingleMatchingType_ReturnsTrue()
    {
        var eventType = WebhookEvent.SubscriptionPaymentSuccess;
        
        var result = eventType.IsEventType(WebhookEvent.SubscriptionPaymentSuccess);
        
        Assert.True(result);
    }

    [Fact]
    public void TestIsEventType_WithSingleNonMatchingType_ReturnsFalse()
    {
        var eventType = WebhookEvent.SubscriptionPaymentSuccess;
        
        var result = eventType.IsEventType(WebhookEvent.SubscriptionPaymentFailed);
        
        Assert.False(result);
    }

    [Fact]
    public void TestIsEventType_WithMultipleTypes_WhenEventMatchesOne_ReturnsTrue()
    {
        var eventType = WebhookEvent.SubscriptionCreated;
        
        var result = eventType.IsEventType(
            WebhookEvent.SubscriptionCreated,
            WebhookEvent.SubscriptionUpdated,
            WebhookEvent.SubscriptionCancelled
        );
        
        Assert.True(result);
    }

    [Fact]
    public void TestIsEventType_WithMultipleTypes_WhenEventMatchesNone_ReturnsFalse()
    {
        var eventType = WebhookEvent.OrderCreated;
        
        var result = eventType.IsEventType(
            WebhookEvent.SubscriptionCreated,
            WebhookEvent.SubscriptionUpdated,
            WebhookEvent.SubscriptionCancelled
        );
        
        Assert.False(result);
    }

    [Fact]
    public void TestIsEventType_WithPaymentEvents_ReturnsTrue()
    {
        var eventType = WebhookEvent.SubscriptionPaymentFailed;
        
        var result = eventType.IsEventType(
            WebhookEvent.SubscriptionPaymentSuccess,
            WebhookEvent.SubscriptionPaymentFailed,
            WebhookEvent.SubscriptionPaymentRecovered,
            WebhookEvent.SubscriptionPaymentRefunded
        );
        
        Assert.True(result);
    }

    [Fact]
    public void TestIsEventType_WithOrderEvents_ReturnsTrue()
    {
        var eventType = WebhookEvent.OrderRefunded;
        
        var result = eventType.IsEventType(
            WebhookEvent.OrderCreated,
            WebhookEvent.OrderRefunded
        );
        
        Assert.True(result);
    }

    [Fact]
    public void TestIsEventType_WithLicenseKeyEvents_ReturnsTrue()
    {
        var eventType = WebhookEvent.LicenseKeyUpdated;
        
        var result = eventType.IsEventType(
            WebhookEvent.LicenseKeyCreated,
            WebhookEvent.LicenseKeyUpdated
        );
        
        Assert.True(result);
    }

    [Fact]
    public void TestIsEventType_WithSubscriptionLifecycleEvents_ReturnsTrue()
    {
        var eventType = WebhookEvent.SubscriptionResumed;
        
        var result = eventType.IsEventType(
            WebhookEvent.SubscriptionCreated,
            WebhookEvent.SubscriptionUpdated,
            WebhookEvent.SubscriptionCancelled,
            WebhookEvent.SubscriptionResumed,
            WebhookEvent.SubscriptionExpired,
            WebhookEvent.SubscriptionPaused,
            WebhookEvent.SubscriptionUnpaused
        );
        
        Assert.True(result);
    }

    [Fact]
    public void TestIsEventType_WithAffiliateEvent_ReturnsTrue()
    {
        var eventType = WebhookEvent.AffiliateActivated;
        
        var result = eventType.IsEventType(WebhookEvent.AffiliateActivated);
        
        Assert.True(result);
    }

    [Fact]
    public void TestIsEventType_WithEmptyParamsArray_ReturnsFalse()
    {
        var eventType = WebhookEvent.SubscriptionPaymentSuccess;
        
        var result = eventType.IsEventType();
        
        Assert.False(result);
    }
}
