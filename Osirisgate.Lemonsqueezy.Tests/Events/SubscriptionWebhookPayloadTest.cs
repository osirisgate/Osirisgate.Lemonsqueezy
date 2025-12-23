using System.Security.Cryptography;
using System.Text;
using Osirisgate.Lemonsqueezy.Events;
using Osirisgate.Lemonsqueezy.Events.Payloads;
using Osirisgate.Lemonsqueezy.Events.Payloads.Subscription;
using Osirisgate.Lemonsqueezy.Events.Webhook;

namespace Osirisgate.Lemonsqueezy.Tests.Events;

public sealed class SubscriptionWebhookPayloadTest
{
    private const string TestWebhookPayload = @"{
  ""data"": {
    ""id"": ""1285570"",
    ""type"": ""subscriptions"",
    ""links"": {
      ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570""
    },
    ""attributes"": {
      ""urls"": {
        ""customer_portal"": ""https://custom.lemonsqueezy.com/billing?expires=1765919311&test_mode=1&user=5072986&signature=202b6133aa52ae3d92f03ae39bda3c07742f4a8cd51884b21586a9fde0fcfd8a"",
        ""update_payment_method"": ""https://custom.lemonsqueezy.com/subscription/1285570/payment-details?expires=1765919311&signature=7a3eadb5d5f054663bcd2a896b5e7eacfbed3cfaeef3cd9c8445fc1d81fe56da"",
        ""customer_portal_update_subscription"": ""https://custom.lemonsqueezy.com/billing/1285570/update?expires=1765919311&user=5072986&signature=240d715010026238ab3d6ed38ca55e3f0058fef50fc9dd37dd16bb2ef5ffa1ac""
      },
      ""pause"": null,
      ""status"": ""expired"",
      ""ends_at"": ""2025-09-18T20:34:39.000000Z"",
      ""order_id"": 5774043,
      ""store_id"": 178624,
      ""cancelled"": true,
      ""renews_at"": ""2025-09-20T20:11:43.000000Z"",
      ""test_mode"": true,
      ""user_name"": ""Ulrich Geraud"",
      ""card_brand"": ""visa"",
      ""created_at"": ""2025-06-20T20:11:44.000000Z"",
      ""product_id"": 537079,
      ""updated_at"": ""2025-09-18T20:34:39.000000Z"",
      ""user_email"": ""ulrich.geraud@test.com"",
      ""variant_id"": 829881,
      ""customer_id"": 6079070,
      ""product_name"": ""business_month.plan_name"",
      ""variant_name"": ""Default"",
      ""order_item_id"": 5711397,
      ""trial_ends_at"": null,
      ""billing_anchor"": 20,
      ""card_last_four"": ""4242"",
      ""status_formatted"": ""Expired"",
      ""payment_processor"": ""stripe"",
      ""first_subscription_item"": {
        ""id"": 2685467,
        ""price_id"": 1332810,
        ""quantity"": 1,
        ""created_at"": ""2025-06-20T20:11:50.000000Z"",
        ""updated_at"": ""2025-08-20T20:12:46.000000Z"",
        ""is_usage_based"": false,
        ""subscription_id"": 1285570
      }
    },
    ""relationships"": {
      ""order"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/relationships/order"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/order""
        }
      },
      ""store"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/relationships/store"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/store""
        }
      },
      ""product"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/relationships/product"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/product""
        }
      },
      ""variant"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/relationships/variant"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/variant""
        }
      },
      ""customer"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/relationships/customer"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/customer""
        }
      },
      ""order-item"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/relationships/order-item"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/order-item""
        }
      },
      ""subscription-items"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/relationships/subscription-items"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/subscription-items""
        }
      },
      ""subscription-invoices"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/relationships/subscription-invoices"",
          ""related"": ""https://api.lemonsqueezy.com/v1/subscriptions/1285570/subscription-invoices""
        }
      }
    }
  },
  ""meta"": {
    ""test_mode"": true,
    ""event_name"": ""subscription_cancelled"",
    ""webhook_id"": ""ee9d6030-2969-4aeb-ae6c-0881566eaabd"",
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
    public void TestCanDeserializeSubscriptionWebhookPayload()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload);

        Assert.NotNull(payload);
        Assert.IsType<SubscriptionWebhookPayload>(payload);
    }

    [Fact]
    public void TestWebhookPayloadMetaIsCorrect()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Meta);
        Assert.Equal("subscription_cancelled", payload.Meta.EventName);
        Assert.True(payload.Meta.TestMode);
        Assert.Equal("ee9d6030-2969-4aeb-ae6c-0881566eaabd", payload.Meta.WebhookId);
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
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.Equal("1285570", payload.Data.Id);
        Assert.Equal("subscriptions", payload.Data.Type);
        Assert.NotNull(payload.Data.Attributes);
        Assert.Equal("expired", payload.Data.Attributes.Status);
        Assert.Equal(178624, payload.Data.Attributes.StoreId);
        Assert.Equal(6079070, payload.Data.Attributes.CustomerId);
        Assert.Equal(5774043, payload.Data.Attributes.OrderId);
        Assert.Equal("Ulrich Geraud", payload.Data.Attributes.UserName);
        Assert.Equal("ulrich.geraud@test.com", payload.Data.Attributes.UserEmail);
        Assert.True(payload.Data.Attributes.TestMode);
        Assert.True(payload.Data.Attributes.Cancelled);
        Assert.Equal("visa", payload.Data.Attributes.CardBrand);
        Assert.Equal("4242", payload.Data.Attributes.CardLastFour);
        Assert.Equal("stripe", payload.Data.Attributes.PaymentProcessor);
        Assert.Equal(20, payload.Data.Attributes.BillingAnchor);
    }

    [Fact]
    public void TestGetEventTypeFromPayload()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload);
        var eventType = payload.GetEventType();

        Assert.Equal(WebhookEvent.SubscriptionCancelled, eventType);
        Assert.Equal("subscription_cancelled", eventType.GetValue());
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
        var subscriptionCreatedPayload = TestWebhookPayload.Replace(
            "\"event_name\": \"subscription_cancelled\"",
            "\"event_name\": \"subscription_created\""
        );

        var payload = WebhookPayloadDeserializer.Deserialize(subscriptionCreatedPayload);
        Assert.NotNull(payload);
        Assert.IsType<SubscriptionWebhookPayload>(payload);
        Assert.Equal("subscription_created", payload.Meta.EventName);

        var subscriptionUpdatedPayload = TestWebhookPayload.Replace(
            "\"event_name\": \"subscription_cancelled\"",
            "\"event_name\": \"subscription_updated\""
        );

        var payload2 = WebhookPayloadDeserializer.Deserialize(subscriptionUpdatedPayload);
        Assert.NotNull(payload2);
        Assert.IsType<SubscriptionWebhookPayload>(payload2);
        Assert.Equal("subscription_updated", payload2.Meta.EventName);
    }

    [Fact]
    public void TestWebhookPayloadRelationshipsAreDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.RelationShips);
        Assert.NotNull(payload.Data.RelationShips.Order);
        Assert.NotNull(payload.Data.RelationShips.Store);
        Assert.NotNull(payload.Data.RelationShips.Product);
        Assert.NotNull(payload.Data.RelationShips.Variant);
        Assert.NotNull(payload.Data.RelationShips.Customer);
        Assert.NotNull(payload.Data.RelationShips.OrderItem);
        Assert.NotNull(payload.Data.RelationShips.SubscriptionItems);
        Assert.NotNull(payload.Data.RelationShips.SubscriptionInvoices);
    }

    [Fact]
    public void TestWebhookPayloadLinksAreDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.Links);
        Assert.Equal("https://api.lemonsqueezy.com/v1/subscriptions/1285570", payload.Data.Links.Self);
    }

    [Fact]
    public void TestWebhookPayloadUrlsAreDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.Attributes);
        Assert.NotNull(payload.Data.Attributes.Urls);
        Assert.NotNull(payload.Data.Attributes.Urls.CustomerPortal);
        Assert.NotNull(payload.Data.Attributes.Urls.UpdatePaymentMethod);
        Assert.NotNull(payload.Data.Attributes.Urls.CustomerPortalUpdateSubscription);
        Assert.Contains("billing", payload.Data.Attributes.Urls.CustomerPortal);
        Assert.Contains("payment-details", payload.Data.Attributes.Urls.UpdatePaymentMethod);
        Assert.Contains("update", payload.Data.Attributes.Urls.CustomerPortalUpdateSubscription);
    }

    [Fact]
    public void TestWebhookPayloadFirstSubscriptionItemIsDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as SubscriptionWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.Attributes);
        Assert.NotNull(payload.Data.Attributes.FirstSubscriptionItem);
        Assert.Equal(2685467, payload.Data.Attributes.FirstSubscriptionItem.Id);
        Assert.Equal(1332810, payload.Data.Attributes.FirstSubscriptionItem.PriceId);
        Assert.Equal(1, payload.Data.Attributes.FirstSubscriptionItem.Quantity);
        Assert.Equal(1285570, payload.Data.Attributes.FirstSubscriptionItem.SubscriptionId);
    }
}
