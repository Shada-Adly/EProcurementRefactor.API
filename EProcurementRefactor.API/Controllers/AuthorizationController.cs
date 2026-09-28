using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.CQRS.Quieries;
using EProcurementRefactor.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EProcurementRefactor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(
        [FromBody] AdminLoginDto loginDto,
        CancellationToken cancellationToken)
        {
            var loginResponse = await _mediator.SendQueryAsync<AdminLoginQuery, LoginResponseDto>(
            new AdminLoginQuery(loginDto),
            cancellationToken);

            return Ok(loginResponse);
        }
    }
}
