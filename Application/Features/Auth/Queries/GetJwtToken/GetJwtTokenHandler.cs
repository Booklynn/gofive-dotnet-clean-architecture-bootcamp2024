using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Auth.Queries.GetJwtToken;

public class GetJwtTokenHandler(UserManager<IdentityUser> userManager, IConfiguration configuration) : IRequestHandler<GetJwtTokenQuery, LoginResponseDto>
{
    readonly UserManager<IdentityUser> userManager = userManager;
    readonly IConfiguration configuration = configuration;

    public async Task<LoginResponseDto> Handle(GetJwtTokenQuery request, CancellationToken cancellationToken) {
        var identityUser = await userManager.FindByEmailAsync(request.Email);
        if (identityUser is null) {
            return null;
        }

        var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, request.Password);
        if (checkPasswordResult is false) {
            return null;
        }

        var roles = await userManager.GetRolesAsync(identityUser);

        var token = GenereateJwtToken(identityUser, roles);

        var response = new LoginResponseDto {
            Email = identityUser.Email,
            Roles = roles.ToList(),
            Token = token
        };

        return response;
    }

    public string GenereateJwtToken(IdentityUser identityUser, IList<string> roles) {
        var claims = new List<Claim> {
            new(ClaimTypes.Email, identityUser.Email)
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
