using Microsoft.JSInterop;

namespace turning.Web.Auth;

public sealed class BrowserTokenStore
{
    private const string AccessTokenKey = "turning.access-token";
    private readonly IJSRuntime _jsRuntime;

    public BrowserTokenStore(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public Task<string?> GetAsync()
    {
        return _jsRuntime.InvokeAsync<string?>("turningAuthStorage.get", AccessTokenKey).AsTask();
    }

    public Task SetAsync(string accessToken)
    {
        return _jsRuntime.InvokeVoidAsync("turningAuthStorage.set", AccessTokenKey, accessToken).AsTask();
    }

    public Task RemoveAsync()
    {
        return _jsRuntime.InvokeVoidAsync("turningAuthStorage.remove", AccessTokenKey).AsTask();
    }
}