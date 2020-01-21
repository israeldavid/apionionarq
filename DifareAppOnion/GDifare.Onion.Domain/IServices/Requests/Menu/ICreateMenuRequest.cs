using OnionPattern.Domain.Entities.Menu.Requests;
using OnionPattern.Domain.Entities.Menu.Responses;

namespace OnionPattern.Domain.IServices.Requests.Menu
{
    public interface ICreateMenuRequest
    {
        MenuResponse Execute(CreateMenuInput input);
    }
}
