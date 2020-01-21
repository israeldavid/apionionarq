using OnionPattern.Domain.IServices.Requests.Banner;

namespace OnionPattern.Domain.IServices.RequestAggregate
{
    public interface IBannerRequestAggregate
    {
        ICreateBannerRequest CreateBannerRequest { get; }
        IGetAllBannersRequest GetAllBannersRequest { get; }
        IGetBannerByIdRequest GetBannerByIdRequest { get; }
        IDeleteBannerByIdRequest DeleteBannerByIdRequest { get; }
        IUpdateBannerRequest UpdateBannerRequest { get; }
    }
}
