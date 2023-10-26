using Application.Contracts;
using Application.Contracts.Commands;
using Application.Contracts.Handlers;
using Domain.Entities;

namespace Application.Handlers;

internal sealed class CreateNewUserHandler : ICreateNewUserHandler
{
    private readonly IUsersRepository _usersRepository;

    public CreateNewUserHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<Guid> Handle(CreateNewUser message, CancellationToken cancellationToken = new())
    {
        var user = User.Create(message.FirstName, message.LastName, message.EmailAddress);
        await _usersRepository.CreateUser(user, cancellationToken);
        return user.Id;
    }
}