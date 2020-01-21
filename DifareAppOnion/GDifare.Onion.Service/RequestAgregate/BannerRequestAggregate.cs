using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.IServices.RequestAggregate;
using OnionPattern.Domain.IServices.Requests.Banner;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests.Banner;


namespace OnionPattern.Service.RequestAgregate
{
    public class BannerRequestAggregate : BaseRequestAggregate<BannerEntity>, IBannerRequestAggregate
    {
        public BannerRequestAggregate(IRepository<BannerEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IBannerRequestAggregate

        private ICreateBannerRequest createBannerRequest;
        public ICreateBannerRequest CreateBannerRequest => createBannerRequest ??
            (createBannerRequest = new CreateBannerRequest(Repository, RepositoryAggregate));

        private IGetAllBannersRequest getAllBannersRequest;
        public IGetAllBannersRequest GetAllBannersRequest => getAllBannersRequest ??
            (getAllBannersRequest = new GetAllBannersRequest(Repository, RepositoryAggregate));

        private IGetBannerByIdRequest getBannerByIdRequest;
        public IGetBannerByIdRequest GetBannerByIdRequest => getBannerByIdRequest ?? (getBannerByIdRequest = new GetBannerByIdRequest(Repository, RepositoryAggregate));

        private IDeleteBannerByIdRequest deleteBannerByIdRequest;
        public IDeleteBannerByIdRequest DeleteBannerByIdRequest => deleteBannerByIdRequest ?? (deleteBannerByIdRequest = new DeleteBannerByIdRequest(Repository, RepositoryAggregate));

        private IUpdateBannerRequest updateBannerRequest;
        public IUpdateBannerRequest UpdateBannerRequest => updateBannerRequest ?? (updateBannerRequest = new UpdateBannerRequest(Repository, RepositoryAggregate));


        #endregion
    }
}
