using OnionPattern.Domain.Entities.Menu.Responses;

namespace OnionPattern.Domain.IServices.Requests.Menu
{
    public interface IGetAllMenusRequest
    {
        MenuListResponse Execute();
    }
}
