using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Turning.Application.Features.ConversationTurns;

namespace Turning.API.Controllers;

/// <summary>
/// Endpoints HTTP para listar y registrar mensajes dentro de una sesión experimental.
/// </summary>
[ApiController]
[Authorize]
[Route("api/experiment-sessions/{sessionId:guid}/conversation-turns")]
[Produces("application/json")]
public sealed class ConversationTurnsController : ControllerBase
{
    private readonly IConversationTurnService _conversationTurnService;

    /// <summary>
    /// Constructor del controller de conversación.
    /// </summary>
    public ConversationTurnsController(IConversationTurnService conversationTurnService)
    {
        _conversationTurnService = conversationTurnService;
    }

    /// <summary>
    /// Lista la conversación persistida de una sesión autenticada.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ConversationTurnSnapshot>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ConversationTurnSnapshot>>> List(Guid sessionId, CancellationToken cancellationToken)
    {
        if (!TryResolveAuthenticatedUserId(out var userId))
        {
            return Unauthorized();
        }

        var turns = await _conversationTurnService.ListAsync(userId, sessionId, cancellationToken);
        return Ok(turns);
    }

    /// <summary>
    /// Registra un nuevo mensaje dentro de una sesión autenticada.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ConversationTurnSnapshot), StatusCodes.Status200OK)]
    public async Task<ActionResult<ConversationTurnSnapshot>> Add(Guid sessionId, [FromBody] AddConversationTurnRequest request, CancellationToken cancellationToken)
    {
        if (!TryResolveAuthenticatedUserId(out var userId))
        {
            return Unauthorized();
        }

        var turn = await _conversationTurnService.AddAsync(userId, sessionId, request, cancellationToken);
        return Ok(turn);
    }

    private bool TryResolveAuthenticatedUserId(out Guid userId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return Guid.TryParse(userIdClaim, out userId);
    }
}