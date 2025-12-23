using System.Security.Cryptography;
using System.Text;
using Osirisgate.Lemonsqueezy.Events;
using Osirisgate.Lemonsqueezy.Events.Payloads;
using Osirisgate.Lemonsqueezy.Events.Payloads.Order;
using Osirisgate.Lemonsqueezy.Events.Webhook;

namespace Osirisgate.Lemonsqueezy.Tests.Events;

public sealed class OrderWebhookPayloadTest
{
    private const string TestWebhookPayload = @"{
  ""data"": {
    ""id"": ""5783087"",
    ""type"": ""orders"",
    ""links"": {
      ""self"": ""https://api.lemonsqueezy.com/v1/orders/5783087""
    },
    ""attributes"": {
      ""tax"": 0,
      ""urls"": {
        ""receipt"": ""https://app.lemonsqueezy.com/my-orders/cb5b9d22-17cb-4f52-81be-efd56cd91afc?expires=1765915150&signature=fbb5d25fe41fafc719b22e2f1193be668052a1aad995f461182245934f07a60c""
      },
      ""total"": 499,
      ""status"": ""paid"",
      ""tax_usd"": 0,
      ""currency"": ""EUR"",
      ""refunded"": false,
      ""store_id"": 178624,
      ""subtotal"": 499,
      ""tax_name"": ""VAT"",
      ""tax_rate"": ""0.00"",
      ""setup_fee"": 0,
      ""test_mode"": true,
      ""total_usd"": 575,
      ""user_name"": ""Ulrich Geraud"",
      ""created_at"": ""2025-06-22T12:54:56.000000Z"",
      ""identifier"": ""cb5b9d22-17cb-4f52-81be-efd56cd91afc"",
      ""updated_at"": ""2025-06-22T12:55:57.000000Z"",
      ""user_email"": ""ulrich.geraud@test.com"",
      ""customer_id"": 6079070,
      ""refunded_at"": null,
      ""order_number"": 17862436,
      ""subtotal_usd"": 575,
      ""currency_rate"": ""1.15244947"",
      ""setup_fee_usd"": 0,
      ""tax_formatted"": ""€0.00"",
      ""tax_inclusive"": false,
      ""discount_total"": 0,
      ""refunded_amount"": 0,
      ""total_formatted"": ""€4.99"",
      ""first_order_item"": {
        ""id"": 5720338,
        ""price"": 499,
        ""order_id"": 5783087,
        ""price_id"": 1282113,
        ""quantity"": 1,
        ""test_mode"": true,
        ""created_at"": ""2025-06-22T12:54:57.000000Z"",
        ""product_id"": 537071,
        ""updated_at"": ""2025-06-22T12:54:57.000000Z"",
        ""variant_id"": 829873,
        ""product_name"": ""pack.500.name"",
        ""variant_name"": ""Default""
      },
      ""status_formatted"": ""Paid"",
      ""discount_total_usd"": 0,
      ""subtotal_formatted"": ""€4.99"",
      ""refunded_amount_usd"": 0,
      ""setup_fee_formatted"": ""€0.00"",
      ""discount_total_formatted"": ""€0.00"",
      ""refunded_amount_formatted"": ""€0.00""
    },
    ""relationships"": {
      ""store"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/orders/5783087/relationships/store"",
          ""related"": ""https://api.lemonsqueezy.com/v1/orders/5783087/store""
        }
      },
      ""customer"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/orders/5783087/relationships/customer"",
          ""related"": ""https://api.lemonsqueezy.com/v1/orders/5783087/customer""
        }
      },
      ""order-items"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/orders/5783087/relationships/order-items"",
          ""related"": ""https://api.lemonsqueezy.com/v1/orders/5783087/order-items""
        }
      },
      ""license-keys"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/orders/5783087/relationships/license-keys"",
          ""related"": ""https://api.lemonsqueezy.com/v1/orders/5783087/license-keys""
        }
      },
      ""subscriptions"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/orders/5783087/relationships/subscriptions"",
          ""related"": ""https://api.lemonsqueezy.com/v1/orders/5783087/subscriptions""
        }
      },
      ""discount-redemptions"": {
        ""links"": {
          ""self"": ""https://api.lemonsqueezy.com/v1/orders/5783087/relationships/discount-redemptions"",
          ""related"": ""https://api.lemonsqueezy.com/v1/orders/5783087/discount-redemptions""
        }
      }
    }
  },
  ""meta"": {
    ""test_mode"": true,
    ""event_name"": ""order_created"",
    ""webhook_id"": ""f7fa3416-30f7-4ba7-b8b0-f4cb5df8307c"",
    ""custom_data"": {
      ""user_id"": ""6079070"",
      ""quantity"": ""1"",
      ""store_id"": ""178624"",
      ""product_id"": ""urn:custom:product:637ceb069ac409d3"",
      ""is_subscription"": ""false"",
      ""custom_user_id"": ""urn:custom:user:637dca10f0f19fea""
    }
  }
}";

    [Fact]
    public void TestCanDeserializeOrderWebhookPayload()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload);

        Assert.NotNull(payload);
        Assert.IsType<OrderWebhookPayload>(payload);
    }

    [Fact]
    public void TestWebhookPayloadMetaIsCorrect()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as OrderWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Meta);
        Assert.Equal("order_created", payload.Meta.EventName);
        Assert.True(payload.Meta.TestMode);
        Assert.Equal("f7fa3416-30f7-4ba7-b8b0-f4cb5df8307c", payload.Meta.WebhookId);
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
        Assert.Equal("urn:custom:product:637ceb069ac409d3", productId);
        Assert.Equal("false", isSubscription);
        Assert.Equal("urn:custom:user:637dca10f0f19fea", customUserId);
    }

    [Fact]
    public void TestWebhookPayloadDataIsCorrect()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as OrderWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.Equal("5783087", payload.Data.Id);
        Assert.Equal("orders", payload.Data.Type);
        Assert.NotNull(payload.Data.Attributes);
        Assert.Equal(499, payload.Data.Attributes.Total);
        Assert.Equal("EUR", payload.Data.Attributes.Currency);
        Assert.Equal("paid", payload.Data.Attributes.Status);
        Assert.Equal(178624, payload.Data.Attributes.StoreId);
        Assert.Equal(6079070, payload.Data.Attributes.CustomerId);
        Assert.Equal("Ulrich Geraud", payload.Data.Attributes.UserName);
        Assert.Equal("ulrich.geraud@test.com", payload.Data.Attributes.UserEmail);
        Assert.True(payload.Data.Attributes.TestMode);
        Assert.False(payload.Data.Attributes.Refunded);
    }

    [Fact]
    public void TestGetEventTypeFromPayload()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload);
        var eventType = payload.GetEventType();

        Assert.Equal(WebhookEvent.OrderCreated, eventType);
        Assert.Equal("order_created", eventType.GetValue());
    }

    [Fact]
    public void TestGetEventTypeFromRawBodyWithoutFullDeserialization()
    {
        var eventType = WebhookPayloadDeserializer.GetEventTypeFromRawBody(TestWebhookPayload);

        Assert.Equal(WebhookEvent.OrderCreated, eventType);
        Assert.Equal("order_created", eventType.GetValue());
    }

    [Fact]
    public void TestGetEventTypeFromRawBodyPerformanceOptimization()
    {
        var eventType = WebhookPayloadDeserializer.GetEventTypeFromRawBody(TestWebhookPayload);

        if (eventType.IsEventType(WebhookEvent.OrderCreated, WebhookEvent.OrderRefunded))
        {
            var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload);
            Assert.NotNull(payload);
            Assert.IsType<OrderWebhookPayload>(payload);
        }
        else
        {
            Assert.Fail("Event type should be OrderCreated");
        }
    }

    [Fact]
    public void TestCanValidateWebhookSignature()
    {
        const string signingSecret = "test-secret-key";
        var rawBody = TestWebhookPayload;

        // Compute the expected signature
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

        // Compute the expected signature
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
        var orderRefundedPayload = TestWebhookPayload.Replace(
            "\"event_name\": \"order_created\"",
            "\"event_name\": \"order_refunded\""
        );

        var payload = WebhookPayloadDeserializer.Deserialize(orderRefundedPayload);
        Assert.NotNull(payload);
        Assert.IsType<OrderWebhookPayload>(payload);
        Assert.Equal("order_refunded", payload.Meta.EventName);
    }

    [Fact]
    public void TestWebhookPayloadRelationshipsAreDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as OrderWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.RelationShips);
        Assert.NotNull(payload.Data.RelationShips.Store);
        Assert.NotNull(payload.Data.RelationShips.Customer);
        Assert.NotNull(payload.Data.RelationShips.OrderItems);
        Assert.NotNull(payload.Data.RelationShips.LicenseKeys);
        Assert.NotNull(payload.Data.RelationShips.Subscriptions);
        Assert.NotNull(payload.Data.RelationShips.DiscountRedemptions);
    }

    [Fact]
    public void TestWebhookPayloadLinksAreDeserialized()
    {
        var payload = WebhookPayloadDeserializer.Deserialize(TestWebhookPayload) as OrderWebhookPayload;

        Assert.NotNull(payload);
        Assert.NotNull(payload.Data);
        Assert.NotNull(payload.Data.Links);
        Assert.Equal("https://api.lemonsqueezy.com/v1/orders/5783087", payload.Data.Links.Self);
    }
}
