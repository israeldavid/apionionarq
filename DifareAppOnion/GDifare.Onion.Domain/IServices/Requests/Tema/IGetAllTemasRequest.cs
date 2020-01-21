using OnionPattern.Domain.Entities.Tema.Responses;

namespace OnionPattern.Domain.IServices.Requests.Tema
{
    public interface IGetAllTemasRequest
    {
        TemaListResponse Execute();
    }
}
