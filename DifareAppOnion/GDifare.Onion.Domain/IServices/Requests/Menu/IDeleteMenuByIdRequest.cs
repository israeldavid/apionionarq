using OnionPattern.Domain.Entities.Menu.Responses;

namespace OnionPattern.Domain.IServices.Requests.Menu
{
    public interface IDeleteMenuByIdRequest
    {
        MenuResponse Execute(int id);
    }
}
