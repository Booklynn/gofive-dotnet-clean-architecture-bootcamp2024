using Application.Models.Auth;
using MediatR;

namespace Application.Features.Auth.Commands.CreateAccount;

public class CreateAccountCommand : IRequest<bool>
{
    public RegisterRequestDto Request { get; set; }
}
