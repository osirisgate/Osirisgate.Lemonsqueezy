using Osirisgate.Lemonsqueezy;
using Osirisgate.Lemonsqueezy.Extensions;
using Osirisgate.Lemonsqueezy.Middleware;
using Osirisgate.Lemonsqueezy.Demo.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();

// ============================================================================
// Register Lemonsqueezy Client - Choose one of the following options:
// ============================================================================

// Option 1: AddLemonsqueezy() - Simple registration with API key from configuration (uses default options)
// builder.Services.AddLemonsqueezy();

// Option 2: AddLemonsqueezy(string apiKey) - Registration with explicit API key
// builder.Services.AddLemonsqueezy("your-api-key-here");

// Option 3: AddLemonsqueezy(LemonsqueezyClientOptions options) - Registration with explicit options object
// var options = LemonsqueezyClientOptions.From("your-api-key-here")
//     .WithBaseUrl("https://api.lemonsqueezy.com/v1/")
//     .WithTimeout(TimeSpan.FromSeconds(60))
//     .WithRetryCount(3);
// builder.Services.AddLemonsqueezy(options);

// Option 4: AddLemonsqueezyWithOptions() - Registration with full options from configuration
builder.Services.AddLemonsqueezyWithOptions();

// ============================================================================
// Register Webhook Validator - Choose one of the following options:
// ============================================================================

// Option 1: AddLemonsqueezyWebhookValidator() - Registration with webhook secret from configuration
builder.Services.AddLemonsqueezyWebhookValidator();

// Option 2: AddLemonsqueezyWebhookValidator(string webhookSecret) - Registration with explicit webhook secret
// builder.Services.AddLemonsqueezyWebhookValidator("your-webhook-secret-here");

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Register webhook validation middleware from SDK
// Option 1: Use default webhook path prefix "/webhooks"
// app.UseLemonsqueezyWebhookValidation();

// Option 2: Use custom path prefix to match endpoint group "/v1/webhooks"
app.UseLemonsqueezyWebhookValidation("/v1/webhooks");

// Map endpoints
app.MapLemonsqueezyEndpoints();

app.Run();
