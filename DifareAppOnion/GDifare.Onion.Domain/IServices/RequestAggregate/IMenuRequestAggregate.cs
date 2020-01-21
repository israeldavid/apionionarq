using OnionPattern.Domain.IServices.Requests.Menu;

namespace OnionPattern.Domain.IServices.RequestAggregate
{
    public interface IMenuRequestAggregate
    {
        ICreateMenuRequest CreateMenuRequest { get; }
        IGetAllMenusRequest GetAllMenusRequest { get; }
        IGetMenuByIdRequest GetMenuByIdRequest { get; }
        IDeleteMenuByIdRequest DeleteMenuByIdRequest { get; }
        IUpdateMenuRequest UpdateMenuRequest { get; }
    }
}
