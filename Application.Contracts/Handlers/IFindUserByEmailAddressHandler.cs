using Application.Contracts.Queries;
using Domain.Entities;

namespace Application.Contracts.Handlers;

public interface IFindUserByEmailAddressHandler : IHandle<FindUserByEmailAddress, User?>
{
    
}