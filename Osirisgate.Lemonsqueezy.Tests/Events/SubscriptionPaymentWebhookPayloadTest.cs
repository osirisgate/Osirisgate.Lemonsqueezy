using System.Security.Cryptography;
using System.Text;
using Osirisgate.Lemonsqueezy.Events;
using Osirisgate.Lemonsqueezy.Events.Payloads;
using Osirisgate.Lemonsqueezy.Events.Payloads.Subscription;
using Osirisgate.Lemonsqueezy.Events.Webhook;

namespace Osirisgate.Lemonsqueezy.Tests.Events;

public sealed class SubscriptionPaymentWebhookPayloadTest
{
    private const string TestWebhookPayload = @"{
  ""data"": {
    ""id"": ""4225708"",
    ""type"": ""subscription-invoices"",
    ""links"": {
      ""self"": ""https://api.lemonsqueezy.com/v1/subscription-invoices/4225708""
    },
    ""attributes"": {
      ""tax"": 0,
      ""urls"": {
        ""invoice_url"": ""https://app.lemonsqueezy.com/my-orders/450d5f10-0cff-4075-934b-47a58ef2370b/subscription-invoice/4225708?expires=1765919608&signature=529b0f6c3489e61c8892ef3f6e1780c64bd7032c57ea1f1cb9847dd9fae78166""
      },
      ""total"": 9999,
      ""status"": ""paid"",
      ""tax_usd"": 0,
      ""currency"": ""EUR"",
      ""refunded"": false,
      ""store_id"": 178624,
      ""subtotal"": 9999,
      ""test_mode"": true,
      ""total_usd"": 11527,
      ""user_name"": ""Ulrich Geraud"",
      ""card_brand"": ""visa"",
      ""created_at"": ""2025-08-20T20:12:46.000000Z"",
      ""updated_at"": ""2025-08-20T21:15:01.000000Z"",
      ""user_email"": ""ulrich.geraud@test.com"",
      ""customer_id"": 6079070,
      ""refunded_at"": null,
      ""subtotal_usd"": 11527,
      ""currency_rate"": ""1.15283476"",
      ""tax_formatted"": ""€0.00"",
      ""tax_inclusive"": false,
      ""billing_reason"": ""renewal"",
      ""card_last_four"": ""4242"",
      ""discount_total"": 0,
      ""refunded_amount"": 0,
      ""subscription_id"": 1285570,
      ""total_formatted"": ""€99.99"",
      ""status_formatted"": ""Paid"",
      ""discount_total_usd"": 0,
      ""subtotal_formatted"": ""€99.99"",
      ""refunded_amount_usd"": 0,
      ""discount_total_formatted"": ""€0.00"",
      ""refunded_amount_formatted"": ""€0.00""
    },
    ""relationships"": {
      ""store"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscription-invoices/4225708/relationships/store"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscription-invoices/4225708/store""
        }
      },
      ""customer"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscription-invoices/4225708/relationships/customer"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscription-invoices/4225708/customer""
        }
      },
      ""subscription"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscription-invoices/4225708/relationships/subscription"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscription-invoices/4225708/subscription""
        }
      }
    }
  },
  ""meta"": {
    ""test_mode"": true,
    ""event_name"": ""subscription_payment_success"",
    ""webhook_id"": ""ad3b339f-80f2-4bf9-ba0c-e8d7ef58f736"",
    ""custom_data"": {
      ""user_id"": ""6079070"",
      ""quantity"": ""1"",
      ""store_id"": ""178624"",
      ""product_id"": ""urn:custom:product:637cda98bc62cb9f"",
      ""is_subscription"": ""true"",
      ""custom_user_id"": ""urn:custom:user:637dca10f0f19fea""
    }
  }
}";

    [Fact]
    public void TestCanDeserializeSubscriptionPaymentWebhookPayload()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload);

        Assert.NotNull(payload);
        Assert.IsType<SubscriptionPaymentWebhookPayload>(payload);
    }

    [Fact]
    public void TestWebhookPayloadMetaIsCorrect()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionPaymentWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Meta);
        Assert.Equal("subscription_payment_success", payload.Meta.EventName);
        Assert.True(payload.Meta.TestMode);
        Assert.Equal("ad3b339f-80f2-4bf9-ba0c-e8d7ef58f736", payload.Meta.WebhookId);
        Assert.NotNull(payload.Meta.CustomData);
        Assert.Equal(6, payload.Meta.CustomData.Count);

        var userId = payload.Meta.CustomData["user_id"]?.ToString() ?? "";
        var quantity = payload.Meta.CustomData["quantity"]?.ToString() ?? "";
        var storeId = payload.Meta.CustomData["store_id"]?.ToString() ?? "";
        var productId = payload.Meta.CustomData["product_id"]?.ToString() ?? "";
        var isSubscription = payload.Meta.CustomData["is_subscription"]?.ToString() ?? "";
        var customUserId = payload.Meta.CustomData["custom_user_id"]?.ToString() ?? "";

        Assert.Equal("6079070", userId);
        Assert.Equal("1", quantity);
        Assert.Equal("178624", storeId);
        Assert.Equal("urn:custom:product:637cda98bc62cb9f", productId);
        Assert.Equal("true", isSubscription);
        Assert.Equal("urn:custom:user:637dca10f0f19fea", customUserId);
    }

    [Fact]
    public void TestWebhookPayloadDataIsCorrect()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionPaymentWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.Equal("4225708", payload.Data.Id);
        Assert.Equal("subscription-invoices", payload.Data.Type);
        Assert.NotNull(payload.Data.Attributes);
        Assert.Equal(9999, payload.Data.Attributes.Total);
        Assert.Equal("EUR", payload.Data.Attributes.Currency);
        Assert.Equal("paid", payload.Data.Attributes.Status);
        Assert.Equal(178624, payload.Data.Attributes.StoreId);
        Assert.Equal(6079070, payload.Data.Attributes.CustomerId);
        Assert.Equal(1285570, payload.Data.Attributes.SubscriptionId);
        Assert.Equal("Ulrich Geraud", payload.Data.Attributes.UserName);
        Assert.Equal("ulrich.geraud@test.com", payload.Data.Attributes.UserEmail);
        Assert.True(payload.Data.Attributes.TestMode);
        Assert.False(payload.Data.Attributes.Refunded);
        Assert.Equal("visa", payload.Data.Attributes.CardBrand);
        Assert.Equal("4242", payload.Data.Attributes.CardLastFour);
        Assert.Equal("renewal", payload.Data.Attributes.BillingReason);
    }

    [Fact]
    public void TestGetEventTypeFromPayload()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload);
        var eventType = payload.GetEventType();

        Assert.Equal(WebhookEvent.SubscriptionPaymentSuccess, eventType);
        Assert.Equal("subscription_payment_success", eventType.GetValue());
    }

    [Fact]
    public void TestGetEventTypeFromRawBodyWithoutFullDeserialization()
    {
        var eventType = WebhookPayloadDeserializer.GetEventTypeFromRawBody(TestWebhookPayload);

        Assert.Equal(WebhookEvent.SubscriptionPaymentSuccess, eventType);
        Assert.Equal("subscription_payment_success", eventType.GetValue());
    }

    [Fact]
    public void TestGetEventTypeFromRawBodyWithConditionalDeserialization()
    {
        var eventType = WebhookPayloadDeserializer.GetEventTypeFromRawBody(TestWebhookPayload);

        if (eventType.IsEventType(
            WebhookEvent.SubscriptionPaymentSuccess,
            WebhookEvent.SubscriptionPaymentFailed,
            WebhookEvent.SubscriptionPaymentRecovered,
            WebhookEvent.SubscriptionPaymentRefunded))
        {
            var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload);
            Assert.NotNull(payload);
            Assert.IsType<SubscriptionPaymentWebhookPayload>(payload);
        }
        else
        {
            Assert.Fail("Event type should be a payment event");
        }
    }

    [Fact]
    public void TestCanValidateWebhookSignature()
    {
        const string signingSecret = "test-secret-key";
        var rawBody = TestWebhookPayload;

        var secretBytes = Encoding.UTF8.GetBytes(signingSecret);
        using var hmac = new HMACSHA256(secretBytes);
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawBody));
        var expectedSignature = Convert.ToHexString(hashBytes).ToLowerInvariant();

        var validator = new WebhookSignatureValidator(signingSecret);
        var isValid = validator.ValidateSignature(rawBody, expectedSignature);

        Assert.True(isValid);
    }

    [Fact]
    public void TestCanValidateWebhookSignatureWithStaticMethod()
    {
        const string signingSecret = "test-secret-key";
        var rawBody = TestWebhookPayload;

        var secretBytes = Encoding.UTF8.GetBytes(signingSecret);
        using var hmac = new HMACSHA256(secretBytes);
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawBody));
        var expectedSignature = Convert.ToHexString(hashBytes).ToLowerInvariant();

        var isValid = WebhookSignatureStaticValidator.ValidateSignature(rawBody, expectedSignature, signingSecret);

        Assert.True(isValid);
    }

    [Fact]
    public void TestInvalidSignatureReturnsFalse()
    {
        const string signingSecret = "test-secret-key";
        var rawBody = TestWebhookPayload;
        var invalidSignature = "invalid-signature";

        var validator = new WebhookSignatureValidator(signingSecret);
        var isValid = validator.ValidateSignature(rawBody, invalidSignature);

        Assert.False(isValid);
    }

    [Fact]
    public void TestCanValidateWebhookSignatureWithBytes()
    {
        const string signingSecret = "test-secret-key";
        var rawBodyBytes = Encoding.UTF8.GetBytes(TestWebhookPayload);

        var secretBytes = Encoding.UTF8.GetBytes(signingSecret);
        using var hmac = new HMACSHA256(secretBytes);
        var hashBytes = hmac.ComputeHash(rawBodyBytes);
        var expectedSignature = Convert.ToHexString(hashBytes).ToLowerInvariant();

        var validator = new WebhookSignatureValidator(signingSecret);
        var isValid = validator.ValidateSignature(rawBodyBytes, expectedSignature);

        Assert.True(isValid);
    }

    [Fact]
    public void TestWebhookPayloadDeserializationWithDifferentEventTypes()
    {
        var subscriptionPaymentFailedPayload = TestWebhookPayload.Replace(
            "\"event_name\": \"subscription_payment_success\"",
            "\"event_name\": \"subscription_payment_failed\""
        );

        var payload = WebhookPayloadDeserializer.Deserialize(subscriptionPaymentFailedPayload);
        Assert.NotNull(payload);
        Assert.IsType<SubscriptionPaymentWebhookPayload>(payload);
        Assert.Equal("subscription_payment_failed", payload.Meta.EventName);

        var subscriptionPaymentRecoveredPayload = TestWebhookPayload.Replace(
            "\"event_name\": \"subscription_payment_success\"",
            "\"event_name\": \"subscription_payment_recovered\""
        );

        var payload2 = WebhookPayloadDeserializer.Deserialize(subscriptionPaymentRecoveredPayload);
        Assert.NotNull(payload2);
        Assert.IsType<SubscriptionPaymentWebhookPayload>(payload2);
        Assert.Equal("subscription_payment_recovered", payload2.Meta.EventName);

        var subscriptionPaymentRefundedPayload = TestWebhookPayload.Replace(
            "\"event_name\": \"subscription_payment_success\"",
            "\"event_name\": \"subscription_payment_refunded\""
        );

        var payload3 = WebhookPayloadDeserializer.Deserialize(subscriptionPaymentRefundedPayload);
        Assert.NotNull(payload3);
        Assert.IsType<SubscriptionPaymentWebhookPayload>(payload3);
        Assert.Equal("subscription_payment_refunded", payload3.Meta.EventName);
    }

    [Fact]
    public void TestWebhookPayloadRelationshipsAreDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionPaymentWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.RelationShips);
        Assert.NotNull(payload.Data.RelationShips.Store);
        Assert.NotNull(payload.Data.RelationShips.Customer);
        Assert.NotNull(payload.Data.RelationShips.Subscription);
    }

    [Fact]
    public void TestWebhookPayloadLinksAreDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionPaymentWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.Links);
        Assert.Equal("https://api.lemonsqueezy.com/v1/subscription-invoices/4225708", payload.Data.Links.Self);
    }

    [Fact]
    public void TestWebhookPayloadUrlsAreDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionPaymentWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.Attributes);
        Assert.NotNull(payload.Data.Attributes.Urls);
        Assert.NotNull(payload.Data.Attributes.Urls.InvoiceUrl);
        Assert.Contains("subscription-invoice", payload.Data.Attributes.Urls.InvoiceUrl);
    }

    [Fact]
    public void TestWebhookPayloadBillingReasonIsDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionPaymentWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.Attributes);
        Assert.Equal("renewal", payload.Data.Attributes.BillingReason);
    }
}
