using Application.Models.Auth;
using MediatR;

namespace Application.Features.Auth.Queries.GetJwtToken;

public class GetJwtTokenQuery : IRequest<LoginResponseDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
