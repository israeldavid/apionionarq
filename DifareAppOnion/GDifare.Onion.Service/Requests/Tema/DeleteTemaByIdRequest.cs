using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.Entities.Tema.Responses;
using OnionPattern.Domain.IServices.Requests.Tema;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Tema
{
    public class DeleteTemaByIdRequest : BaseServiceRequest<TemaEntity>, IDeleteTemaByIdRequest
    {
        public DeleteTemaByIdRequest(IRepository<TemaEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeleteTemaByIdRequest

        public TemaResponse Execute(int id)
        {
            var temaResponse = new TemaResponse();
            try
            {
                Log.Information("Eliminando el Tema por Id:[{Id}]...", id);
                var toDelete = Repository.SingleOrDefault(tema => tema.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"Tema no encontrado por Id:[{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(temaResponse, exception, 404);
                }
                else
                {
                    Repository.Delete(toDelete);
                    temaResponse.StatusCode = 200;
                    Log.Information("Tema eliminado [{NewName}] por Id:[{Id}].", toDelete.Nombre, toDelete.Id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al elimnar el Tema. [{Message}].", exception.Message);
                HandleErrors(temaResponse, exception);
            }
            return temaResponse;
        }

        #endregion
    }
}
