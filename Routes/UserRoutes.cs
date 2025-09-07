using Microsoft.AspNetCore.Mvc;
using newapi.domain.requests;
using newapi.domain.interfaces;
using newapi.domain.dtos;
using Microsoft.AspNetCore.Authorization;
using newapi.ownedtypes;

namespace newapi.routes;

public static class UserRoute
{
    public static void UserRoutes(this WebApplication app, string jwtToken)
    {
        var route = app.MapGroup("/api/users");

        route.MapGet("/", async ([FromQuery] int? page, IUserService userService) =>
        {
            var response = await userService.GetAllUsers(page, jwtToken);
            if (!response.Success)
            {
                return Results.Json(new { errors = response.GetErrors() }, statusCode: 400);
            }

            return Results.Json(new { users = response.UsersResponse }, statusCode: 200);
        }).RequireAuthorization()
        .RequireAuthorization(new AuthorizeAttribute { Roles = "adm" })
        .WithTags("Users");

        route.MapGet("/{id}", async ([FromRoute] string id, IUserService userService) =>
        {
            var response = await userService.GetUserById(Guid.Parse(id), jwtToken);
            if (!response.Success)
            {
                return Results.Json(new { errors = response.GetErrors() }, statusCode: 400);
            }
            return Results.Json(new { user = response.User }, statusCode: 200);
        }).RequireAuthorization()
        .RequireAuthorization(new AuthorizeAttribute { Roles = "adm" })
        .WithTags("Users");

        route.MapPost("/login", async ([FromBody] UserRequest userRequest, IUserService userService) =>
        {
            var user = new UserDTO(userRequest.Name,
                userRequest.Email,
                userRequest.Password,
                "user"
                );

            var response = await userService.CreateUser(user, jwtToken);
            if (!response.Success)
            {
                return Results.Json(new { errors = response.GetErrors() }, statusCode: 400);
            }
            
            return Results.Json(new { createdUser = response.User }, statusCode: 201);
        }).RequireAuthorization()
        .RequireAuthorization(new AuthorizeAttribute { Roles = "adm" })
        .WithTags("Users");

        route.MapPut("/{id}", async ([FromRoute] string id, [FromBody] UserRequest userRequest, IUserService userService) =>
        {
            var user = new UserDTO(
                userRequest.Name,
                userRequest.Email,
                userRequest.Password,
                "user"
            );

            var response = await userService.UpdateUser(Guid.Parse(id), user, jwtToken);
            if (!response.Success)
            {
                return Results.Json(new { errors = response.GetErrors() }, statusCode: 400);
            }

            return Results.Json(new { updatedUser = response.User }, statusCode: 200);
        }).WithTags("Users");

        route.MapDelete("/{id}", ([FromRoute] string id) =>
        {
            throw new NotImplementedException();
        }).RequireAuthorization()
        .RequireAuthorization(new AuthorizeAttribute{ Roles = "adm" })
        .WithTags("Users");
    }
}
