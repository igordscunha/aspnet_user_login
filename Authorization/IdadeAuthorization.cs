using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

namespace login_usuario.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var dataNascimentoClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if(dataNascimentoClaim is null) 
            return Task.CompletedTask;

        var dataNascimento = Convert.ToDateTime(dataNascimentoClaim);

        var idadeUsuario = DateTime.Today.Year - dataNascimento.Year;

        if (dataNascimento > DateTime.Today.AddYears(-idadeUsuario)) 
            idadeUsuario--;

        if (idadeUsuario >= requirement.Idade)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }

}
