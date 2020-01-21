using OnionPattern.Domain.IServices.Requests.Tema;

namespace OnionPattern.Domain.IServices.RequestAggregate
{
    public interface ITemaRequestAggregate
    {
        ICreateTemaRequest CreateTemaRequest { get; }
        IGetAllTemasRequest GetAllTemasRequest { get; }
        IGetArchivoTemasRequest GetArchivoTemasRequest { get; }
        IGetTemaByIdRequest GetTemaByIdRequest { get; }
        IDeleteTemaByIdRequest DeleteTemaByIdRequest { get; }
        IUpdateTemaRequest UpdateTemaRequest { get; }
    }
}
