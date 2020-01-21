using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tab.Responses;
using OnionPattern.Domain.IServices.Requests.Tab;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Tab
{
    public class DeleteTabByIdRequest : BaseServiceRequest<TabEntity>, IDeleteTabByIdRequest
    {
        public DeleteTabByIdRequest(IRepository<TabEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeleteTabByIdRequest

        public TabResponse Execute(int id)
        {
            var tabResponse = new TabResponse();
            try
            {
                Log.Information("Eliminando el Tab por Id:[{Id}]...", id);
                var toDelete = Repository.SingleOrDefault(tab => tab.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"Tab no encontrado por Id:[{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(tabResponse, exception, 404);
                }
                else
                {
                    Repository.Delete(toDelete);
                    tabResponse.StatusCode = 200;
                    Log.Information("Tab eliminado [{NewName}] por Id:[{Id}].", toDelete.Nombre, toDelete.Id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al elimnar el Tab. [{Message}].", exception.Message);
                HandleErrors(tabResponse, exception);
            }
            return tabResponse;
        }

        #endregion
    }
}
