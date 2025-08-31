using Microsoft.AspNetCore.Mvc;
using newapi.domain.requests;
using newapi.domain.interfaces;
using newapi.domain.dtos;

namespace newapi.routes;

public static class UserRoute
{
    public static void UserRoutes(this WebApplication app)
    {
        var route = app.MapGroup("/api/users");

        route.MapGet("/", async ([FromQuery] int? page,IUserService userService) =>
        {
            var response = await userService.GetAllUsers(page);
            if (response.Success == false)
            {
                return Results.Json(new { errors = response.GetErrors() }, statusCode: 400);
            }
            return Results.Json(new { users = response.UsersResponse}, statusCode: 200);
        }).WithTags("Users");

        route.MapGet("/{id}", ([FromRoute] string id) => "Implementar dps mó preguiça").WithTags("Users");

        route.MapPost("/login", async ([FromBody] UserRequest userRequest, IUserService userService) =>
        {
            var user = new UserDTO(userRequest.Name,
                userRequest.Email,
                userRequest.Password);

            var response = await userService.CreateUser(user);
            if (response.Success == false)
            {
                return Results.Json(new { errors = response.GetErrors() }, statusCode: 400);
            }
            
            return Results.Json(new { createdUser = response.User }, statusCode: 201);
        }).WithTags("Users");

        route.MapPut("/{id}", ([FromRoute] string id,[FromBody] UserRequest userRequest) => "Implementar dps mó preguiça").WithTags("Users");

        route.MapDelete("/{id}", ([FromRoute] string id) =>
        {
            throw new NotImplementedException();
        }).WithTags("Users");
    }
}
