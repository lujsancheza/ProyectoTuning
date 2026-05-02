namespace turning.Web.Auth;

public sealed class AuthSession
{
    public string? AccessToken { get; private set; }

    public void SetAccessToken(string? accessToken)
    {
        AccessToken = string.IsNullOrWhiteSpace(accessToken) ? null : accessToken;
    }
}