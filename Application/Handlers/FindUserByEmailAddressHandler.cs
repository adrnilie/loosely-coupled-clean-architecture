using Application.Contracts;
using Application.Contracts.Handlers;
using Application.Contracts.Queries;
using Domain.Entities;

namespace Application.Handlers;

internal sealed class FindUserByEmailAddressHandler : IFindUserByEmailAddressHandler
{
    private readonly IUsersRepository _usersRepository;

    public FindUserByEmailAddressHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<User?> Handle(FindUserByEmailAddress message, CancellationToken cancellationToken = new())
    {
        var user = await _usersRepository.FindUser(message.EmailAddress, cancellationToken);
        return user;
    }
}