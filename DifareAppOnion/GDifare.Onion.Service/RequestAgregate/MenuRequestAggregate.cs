using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.IServices.RequestAggregate;
using OnionPattern.Domain.IServices.Requests.Menu;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests.Menu;


namespace OnionPattern.Service.RequestAgregate
{
    public class MenuRequestAggregate : BaseRequestAggregate<MenuEntity>, IMenuRequestAggregate
    {
        public MenuRequestAggregate(IRepository<MenuEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IMenuRequestAggregate

        private ICreateMenuRequest createMenuRequest;
        public ICreateMenuRequest CreateMenuRequest => createMenuRequest ??
            (createMenuRequest = new CreateMenuRequest(Repository, RepositoryAggregate));

        private IGetAllMenusRequest getAllMenusRequest;
        public IGetAllMenusRequest GetAllMenusRequest => getAllMenusRequest ??
            (getAllMenusRequest = new GetAllMenusRequest(Repository, RepositoryAggregate));

        private IGetMenuByIdRequest getMenuByIdRequest;
        public IGetMenuByIdRequest GetMenuByIdRequest => getMenuByIdRequest ?? (getMenuByIdRequest = new GetMenuByIdRequest(Repository, RepositoryAggregate));

        private IDeleteMenuByIdRequest deleteMenuByIdRequest;
        public IDeleteMenuByIdRequest DeleteMenuByIdRequest => deleteMenuByIdRequest ?? (deleteMenuByIdRequest = new DeleteMenuByIdRequest(Repository, RepositoryAggregate));

        private IUpdateMenuRequest updateMenuRequest;
        public IUpdateMenuRequest UpdateMenuRequest => updateMenuRequest ?? (updateMenuRequest = new UpdateMenuRequest(Repository, RepositoryAggregate));


        #endregion
    }
}
