using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.IServices.RequestAggregate;
using OnionPattern.Domain.IServices.Requests.Tab;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests.Tab;


namespace OnionPattern.Service.RequestAgregate
{
    public class TabRequestAggregate : BaseRequestAggregate<TabEntity>, ITabRequestAggregate
    {
        public TabRequestAggregate(IRepository<TabEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of ITabRequestAggregate

        private ICreateTabRequest createTabRequest;
        public ICreateTabRequest CreateTabRequest => createTabRequest ??
            (createTabRequest = new CreateTabRequest(Repository, RepositoryAggregate));

        private IGetAllTabsRequest getAllTabsRequest;
        public IGetAllTabsRequest GetAllTabsRequest => getAllTabsRequest ??
            (getAllTabsRequest = new GetAllTabsRequest(Repository, RepositoryAggregate));

        private IGetTabByIdRequest getTabByIdRequest;
        public IGetTabByIdRequest GetTabByIdRequest => getTabByIdRequest ?? (getTabByIdRequest = new GetTabByIdRequest(Repository, RepositoryAggregate));

        private IDeleteTabByIdRequest deleteTabByIdRequest;
        public IDeleteTabByIdRequest DeleteTabByIdRequest => deleteTabByIdRequest ?? (deleteTabByIdRequest = new DeleteTabByIdRequest(Repository, RepositoryAggregate));

        private IUpdateTabRequest updateTabRequest;
        public IUpdateTabRequest UpdateTabRequest => updateTabRequest ?? (updateTabRequest = new UpdateTabRequest(Repository, RepositoryAggregate));


        #endregion
    }
}
