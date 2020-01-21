using OnionPattern.Domain.IServices.Requests.Tab;

namespace OnionPattern.Domain.IServices.RequestAggregate
{
    public interface ITabRequestAggregate
    {
        ICreateTabRequest CreateTabRequest { get; }
        IGetAllTabsRequest GetAllTabsRequest { get; }
        IGetTabByIdRequest GetTabByIdRequest { get; }
        IDeleteTabByIdRequest DeleteTabByIdRequest { get; }
        IUpdateTabRequest UpdateTabRequest { get; }
    }
}
