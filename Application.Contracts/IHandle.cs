namespace Application.Contracts;

public interface IHandle<in TIn, TOut> 
    where TIn : class
{
    Task<TOut> Handle(TIn message, CancellationToken cancellationToken = new());
}

public interface IHandle<in TIn>
    where TIn : class
{
    Task Handle(TIn message, CancellationToken cancellationToken = new());
}