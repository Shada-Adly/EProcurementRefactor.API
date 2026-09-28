namespace EProcurementRefactor.Application.Common.Mediator
{
    public interface ICommandRequest { }
    public interface ICommandRequest<out TResponse> { }
}