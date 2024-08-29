using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands.CreateAccount;

public class CreateAccountHandler(UserManager<IdentityUser> userManager) : IRequestHandler<CreateAccountCommand, bool>
{
    readonly UserManager<IdentityUser> userManager = userManager;

    public async Task<bool> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        var user = new IdentityUser {
            UserName = command.Request.Email.Trim(),
            Email = command.Request.Email.Trim()
        };

        var identityResult = await userManager.CreateAsync(user, command.Request.Password);
        if (identityResult.Succeeded is false)
        {
            return false;
        }

        identityResult = await userManager.AddToRolesAsync(user, ["reader", "writer"]);
        if (identityResult.Succeeded is false)
        {
            return false;
        }

        return true;
    }
}
