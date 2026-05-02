using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace turning.Web.Auth;

public sealed class AuthApiClient
{
    private readonly HttpClient _httpClient;
    private readonly AuthSession _authSession;

    public AuthApiClient(HttpClient httpClient, AuthSession authSession)
    {
        _httpClient = httpClient;
        _authSession = authSession;
    }

    public Task<AuthResultDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken = default)
    {
        return SendAsync<LoginRequestDto, AuthResultDto>("api/auth/login", request, cancellationToken);
    }

    public Task<AuthResultDto> RegisterAsync(RegisterRequestDto request, CancellationToken cancellationToken = default)
    {
        return SendAsync<RegisterRequestDto, AuthResultDto>("api/auth/register", request, cancellationToken);
    }

    public async Task<AuthenticatedUserDto> GetCurrentUserAsync(CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/auth/me");
        AttachAccessToken(request);

        using var response = await _httpClient.SendAsync(request, cancellationToken);
        return await ReadResponseAsync<AuthenticatedUserDto>(response, cancellationToken);
    }

    private void AttachAccessToken(HttpRequestMessage request)
    {
        if (!string.IsNullOrWhiteSpace(_authSession.AccessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authSession.AccessToken);
        }
    }

    private async Task<TResponse> SendAsync<TRequest, TResponse>(string uri, TRequest payload, CancellationToken cancellationToken)
    {
        using var response = await _httpClient.PostAsJsonAsync(uri, payload, cancellationToken);
        return await ReadResponseAsync<TResponse>(response, cancellationToken);
    }

    private static async Task<TResponse> ReadResponseAsync<TResponse>(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
            return result ?? throw new ApiException("La API devolvio una respuesta vacia.", response.StatusCode);
        }

        ApiErrorResponse? apiError = null;

        try
        {
            apiError = await response.Content.ReadFromJsonAsync<ApiErrorResponse>(cancellationToken: cancellationToken);
        }
        catch
        {
        }

        throw new ApiException(
            apiError?.Message ?? $"No fue posible completar la solicitud ({(int)response.StatusCode}).",
            response.StatusCode,
            apiError?.Details);
    }
}

public sealed class ApiException : Exception
{
    public ApiException(string message, HttpStatusCode statusCode, string? details = null)
        : base(message)
    {
        StatusCode = statusCode;
        Details = details;
    }

    public HttpStatusCode StatusCode { get; }

    public string? Details { get; }
}