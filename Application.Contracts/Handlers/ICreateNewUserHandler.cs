using Application.Contracts.Commands;

namespace Application.Contracts.Handlers;

public interface ICreateNewUserHandler : IHandle<CreateNewUser, Guid>
{
    
}