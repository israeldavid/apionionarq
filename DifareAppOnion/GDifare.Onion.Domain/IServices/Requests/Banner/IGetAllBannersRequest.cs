using OnionPattern.Domain.Entities.Banner.Responses;

namespace OnionPattern.Domain.IServices.Requests.Banner
{
    public interface IGetAllBannersRequest
    {
        BannerListResponse Execute();
    }
}
