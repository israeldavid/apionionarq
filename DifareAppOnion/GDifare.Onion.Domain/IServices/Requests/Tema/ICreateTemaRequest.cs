using OnionPattern.Domain.Entities.Tema.Requests;
using OnionPattern.Domain.Entities.Tema.Responses;

namespace OnionPattern.Domain.IServices.Requests.Tema
{
    public interface ICreateTemaRequest
    {
        TemaResponse Execute(CreateTemaInput input);
    }
}
