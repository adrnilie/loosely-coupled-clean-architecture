using Application.Contracts;
using Application.Contracts.Commands;
using Application.Contracts.Handlers;
using Application.Contracts.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Modules;

public static class UsersModule
{
    public static void AddUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app
            .MapGet("/users", GetAllUsers)
            .WithDescription("Retrieves all users")
            .WithName(nameof(GetAllUsers))
            .WithDisplayName(nameof(GetAllUsers))
            .WithOpenApi();

        app
            .MapPost("/users", CreateUser)
            .WithDescription("Creates a new user")
            .WithName(nameof(CreateUser))
            .WithDisplayName(nameof(CreateUser))
            .WithOpenApi();

        app
            .MapPost("/users/{emailAddress}", FindUserByEmailAddress)
            .WithDescription("Finds a user by given email address")
            .WithName(nameof(FindUserByEmailAddress))
            .WithDisplayName(nameof(FindUserByEmailAddress))
            .WithOpenApi();
    }

    private static async Task<IResult> GetAllUsers([FromServices]IUsersRepository usersRepository, CancellationToken cancellationToken = new())
    {
        var users = await usersRepository.GetUsers(cancellationToken);
        return Results.Ok(users);
    }

    private static async Task<IResult> CreateUser(
        [FromBody] CreateNewUser command,
        [FromServices] ICreateNewUserHandler createNewUserHandler, 
        CancellationToken cancellationToken = new())
    {
        var userId = await createNewUserHandler.Handle(command, cancellationToken);
        return Results.Ok(userId);
    }

    private static async Task<IResult> FindUserByEmailAddress([FromRoute] string emailAddress, [FromServices]IFindUserByEmailAddressHandler findUserHandler, CancellationToken cancellationToken = new())
    {
        var query = new FindUserByEmailAddress(emailAddress);
        var user = await findUserHandler.Handle(query, cancellationToken);
        return Results.Ok(user);
    }
}