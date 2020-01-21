using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.IServices.RequestAggregate;
using OnionPattern.Domain.IServices.Requests.Tema;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests.Tema;


namespace OnionPattern.Service.RequestAgregate
{
    public class TemaRequestAggregate : BaseRequestAggregate<TemaEntity>, ITemaRequestAggregate
    {
        public TemaRequestAggregate(IRepository<TemaEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of ITemaRequestAggregate

        private ICreateTemaRequest createTemaRequest;
        public ICreateTemaRequest CreateTemaRequest => createTemaRequest ??
            (createTemaRequest = new CreateTemaRequest(Repository, RepositoryAggregate));

        private IGetAllTemasRequest getAllTemasRequest;
        public IGetAllTemasRequest GetAllTemasRequest => getAllTemasRequest ??
            (getAllTemasRequest = new GetAllTemasRequest(Repository, RepositoryAggregate));

        private IGetArchivoTemasRequest getArchivoTemasRequest;
        public IGetArchivoTemasRequest GetArchivoTemasRequest => getArchivoTemasRequest ??
            (getArchivoTemasRequest = new GetArchivoTemasRequest(Repository, RepositoryAggregate));

        private IGetTemaByIdRequest getTemaByIdRequest;
        public IGetTemaByIdRequest GetTemaByIdRequest => getTemaByIdRequest ?? (getTemaByIdRequest = new GetTemaByIdRequest(Repository, RepositoryAggregate));

        private IDeleteTemaByIdRequest deleteTemaByIdRequest;
        public IDeleteTemaByIdRequest DeleteTemaByIdRequest => deleteTemaByIdRequest ?? (deleteTemaByIdRequest = new DeleteTemaByIdRequest(Repository, RepositoryAggregate));

        private IUpdateTemaRequest updateTemaRequest;
        public IUpdateTemaRequest UpdateTemaRequest => updateTemaRequest ?? (updateTemaRequest = new UpdateTemaRequest(Repository, RepositoryAggregate));


        #endregion
    }
}
