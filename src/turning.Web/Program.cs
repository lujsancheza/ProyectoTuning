using Microsoft.AspNetCore.Components.Authorization;
using turning.Web.Auth;
using turning.Web.Components;
using turning.Web.ExperimentSessions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthSession>();
builder.Services.AddScoped<BrowserTokenStore>();
builder.Services.AddScoped<TokenAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(static serviceProvider => serviceProvider.GetRequiredService<TokenAuthenticationStateProvider>());
builder.Services.AddHttpClient<AuthApiClient>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var configuredBaseUrl = EnsureTrailingSlash(configuration["Api:BaseUrl"] ?? "https://localhost:5001");
    client.BaseAddress = new Uri(configuredBaseUrl, UriKind.Absolute);
});
builder.Services.AddHttpClient<ExperimentSessionApiClient>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var configuredBaseUrl = EnsureTrailingSlash(configuration["Api:BaseUrl"] ?? "https://localhost:5001");
    client.BaseAddress = new Uri(configuredBaseUrl, UriKind.Absolute);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static string EnsureTrailingSlash(string value)
{
    return value.EndsWith("/", StringComparison.Ordinal) ? value : $"{value}/";
}
