using Microsoft.AspNetCore.Mvc;
using newapi.domain.requests;
using newapi.domain.interfaces;

namespace newapi.routes;

public static class UserRoute
{
    public static void UserRoutes(this WebApplication app)
    {
        var route = app.MapGroup("/api/users");

        route.MapGet("/", async (IUserService userService) =>
        {
            var user = await userService.GetAllUsers();
            if (user.Success == false)
            {
                return Results.Json(new { user.Success, Error = user.GetErrors() }, statusCode: 400);
            }
            return Results.Json(new { Id = "jdwndjiaw", Nome = "Usuário Exemplo" }, statusCode: 200);
        });

        route.MapGet("/{id}", () => "Implementar dps mó preguiça");

        route.MapPost("/login", ([FromBody] UserRequest userRequest, IUserService userService) => "Implementar dps mó preguiça");

        route.MapPut("/{id}", ([FromBody] UserRequest userRequest) => "Implementar dps mó preguiça");

        route.MapDelete("/{id}", ([FromBody] UserRequest userRequest) => "Implementar dps mó preguiça");
    }
}
