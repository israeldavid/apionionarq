using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.IServices.RequestAggregate;
using OnionPattern.Domain.IServices.Requests.Popup;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests.Popup;


namespace OnionPattern.Service.RequestAgregate
{
    public class PopupRequestAggregate : BaseRequestAggregate<PopupEntity>, IPopupRequestAggregate
    {
        public PopupRequestAggregate(IRepository<PopupEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IPopupRequestAggregate

        private ICreatePopupRequest createPopupRequest;
        public ICreatePopupRequest CreatePopupRequest => createPopupRequest ??
            (createPopupRequest = new CreatePopupRequest(Repository, RepositoryAggregate));

        private IGetAllPopupsRequest getAllPopupsRequest;
        public IGetAllPopupsRequest GetAllPopupsRequest => getAllPopupsRequest ??
            (getAllPopupsRequest = new GetAllPopupsRequest(Repository, RepositoryAggregate));

        private IGetPopupByIdRequest getPopupByIdRequest;
        public IGetPopupByIdRequest GetPopupByIdRequest => getPopupByIdRequest ?? (getPopupByIdRequest = new GetPopupByIdRequest(Repository, RepositoryAggregate));

        private IDeletePopupByIdRequest deletePopupByIdRequest;
        public IDeletePopupByIdRequest DeletePopupByIdRequest => deletePopupByIdRequest ?? (deletePopupByIdRequest = new DeletePopupByIdRequest(Repository, RepositoryAggregate));

        private IUpdatePopupRequest updatePopupRequest;
        public IUpdatePopupRequest UpdatePopupRequest => updatePopupRequest ?? (updatePopupRequest = new UpdatePopupRequest(Repository, RepositoryAggregate));


        #endregion
    }
}
