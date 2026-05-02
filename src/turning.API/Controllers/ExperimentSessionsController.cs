using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Turning.Application.Features.ExperimentSessions;

namespace Turning.API.Controllers;

/// <summary>
/// Endpoints para bootstrap y consulta de sesiones experimentales.
/// </summary>
[ApiController]
[Authorize]
[Route("api/experiment-sessions")]
[Produces("application/json")]
public sealed class ExperimentSessionsController : ControllerBase
{
    private readonly IExperimentSessionService _experimentSessionService;

    /// <summary>
    /// Constructor del controller de sesiones experimentales.
    /// </summary>
    public ExperimentSessionsController(IExperimentSessionService experimentSessionService)
    {
        _experimentSessionService = experimentSessionService;
    }

    /// <summary>
    /// Crea una sesión experimental inicial para el usuario autenticado.
    /// </summary>
    [HttpPost("bootstrap")]
    [ProducesResponseType(typeof(ExperimentSessionSnapshot), StatusCodes.Status200OK)]
    public async Task<ActionResult<ExperimentSessionSnapshot>> Bootstrap([FromBody] CreateExperimentSessionRequest? request, CancellationToken cancellationToken)
    {
        if (!TryResolveAuthenticatedUserId(out var userId))
        {
            return Unauthorized();
        }

        var snapshot = await _experimentSessionService.CreateBootstrapSessionAsync(userId, request, cancellationToken);
        return Ok(snapshot);
    }

    /// <summary>
    /// Devuelve la sesión experimental más reciente del usuario autenticado.
    /// </summary>
    [HttpGet("latest")]
    [ProducesResponseType(typeof(ExperimentSessionSnapshot), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExperimentSessionSnapshot>> GetLatest(CancellationToken cancellationToken)
    {
        if (!TryResolveAuthenticatedUserId(out var userId))
        {
            return Unauthorized();
        }

        var snapshot = await _experimentSessionService.GetLatestSessionAsync(userId, cancellationToken);
        return snapshot is null ? NotFound() : Ok(snapshot);
    }

    private bool TryResolveAuthenticatedUserId(out Guid userId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return Guid.TryParse(userIdClaim, out userId);
    }
}