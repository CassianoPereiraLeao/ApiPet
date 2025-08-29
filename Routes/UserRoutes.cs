using Microsoft.AspNetCore.Mvc;
using newapi.domain.dtos;
using newapi.domain.requests;
using newapi.infra.interfaces;

namespace newapi.routes;

public static class UserRoute
{
    public static void UserRoutes(this WebApplication app)
    {
        var route = app.MapGroup("/");

        route.MapGet("/users", async () =>
        {
            return Results.Json(new { Id = "jdwndjiaw", Nome = "Usuário Exemplo" }, statusCode: 200);
        });
        route.MapGet("/users/{id}", ([FromBody] UserRequest userRequest) => "Implementar dps mó preguiça");
        route.MapPost("/users/login", ([FromBody] UserRequest userRequest) => "Implementar dps mó preguiça");
        route.MapPut("/users/{id}", ([FromBody] UserRequest userRequest) => "Implementar dps mó preguiça");
        route.MapDelete("/users/{id}", ([FromBody] UserRequest userRequest) => "Implementar dps mó preguiça");
    }
}
