using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tab.Responses;
using OnionPattern.Domain.IServices.Requests.Tab;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Tab
{
    public class GetTabByIdRequest : BaseServiceRequest<TabEntity>, IGetTabByIdRequest
    {
        public GetTabByIdRequest(IRepository<TabEntity> repository, IRepositoryAggregate repositoryAggregate)
           : base(repository, repositoryAggregate) { }


        #region Implementation of IGetTabByIdRequest

        public TabResponse Execute(int id)
        {
            var tabResponse = new TabResponse();
            try
            {
                Log.Information("Recuperando tab por Id : [{Id}]", id);

                var tab = Repository.SingleOrDefault(g => g.Id == id);
                if (tab == null)
                {
                    var exception = new Exception($"tab no encontrado por  id : [{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(tabResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    tabResponse.Tab = tab;
                    tabResponse.StatusCode = 200;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener tab por Id: [{Id}].", id);
                HandleErrors(tabResponse, exception);
            }
            return tabResponse;
        }

        #endregion

    }
}
