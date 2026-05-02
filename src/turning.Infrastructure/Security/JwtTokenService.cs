using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Turning.Application.Features.Auth;
using Turning.Application.Interfaces;
using Turning.Domain.Entities;

namespace Turning.Infrastructure.Security;

/// <summary>
/// Emite tokens JWT para usuarios autenticados.
/// </summary>
public sealed class JwtTokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Constructor del servicio JWT.
    /// </summary>
    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <inheritdoc />
    public AuthResult CreateToken(UserAccount userAccount)
    {
        var issuer = _configuration["Jwt:Issuer"] ?? "Turning.API";
        var audience = _configuration["Jwt:Audience"] ?? "Turning.Web";
        var signingKey = _configuration["Jwt:SigningKey"]
            ?? throw new InvalidOperationException("La configuración Jwt:SigningKey es obligatoria.");
        var expirationMinutes = int.TryParse(_configuration["Jwt:ExpirationMinutes"], out var parsedMinutes)
            ? parsedMinutes
            : 120;

        var expiresAtUtc = DateTime.UtcNow.AddMinutes(expirationMinutes);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userAccount.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, userAccount.Email),
            new(JwtRegisteredClaimNames.UniqueName, userAccount.FullName),
            new(ClaimTypes.NameIdentifier, userAccount.Id.ToString()),
            new(ClaimTypes.Name, userAccount.FullName),
            new(ClaimTypes.Email, userAccount.Email),
            new(ClaimTypes.Role, userAccount.Role)
        };

        var tokenDescriptor = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expiresAtUtc,
            signingCredentials: credentials);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return new AuthResult
        {
            AccessToken = accessToken,
            ExpiresAtUtc = expiresAtUtc,
            User = new AuthenticatedUser
            {
                Id = userAccount.Id,
                FullName = userAccount.FullName,
                Email = userAccount.Email,
                Role = userAccount.Role
            }
        };
    }
}