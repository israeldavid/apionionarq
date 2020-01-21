using OnionPattern.Domain.Entities.Tab.Responses;

namespace OnionPattern.Domain.IServices.Requests.Tab
{
    public interface IGetAllTabsRequest
    {
        TabListResponse Execute();
    }
}
