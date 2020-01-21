using OnionPattern.Domain.Entities.Tab.Requests;
using OnionPattern.Domain.Entities.Tab.Responses;

namespace OnionPattern.Domain.IServices.Requests.Tab
{
    public interface ICreateTabRequest
    {
        TabResponse Execute(CreateTabInput input);
    }
}
