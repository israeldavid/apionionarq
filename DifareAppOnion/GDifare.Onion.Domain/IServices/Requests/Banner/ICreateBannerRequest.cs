using OnionPattern.Domain.Entities.Banner.Requests;
using OnionPattern.Domain.Entities.Banner.Responses;

namespace OnionPattern.Domain.IServices.Requests.Banner
{
    public interface ICreateBannerRequest
    {
        BannerResponse Execute(CreateBannerInput input);
    }
}
