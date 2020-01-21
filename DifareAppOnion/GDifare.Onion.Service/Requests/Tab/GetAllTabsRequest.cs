using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tab.Responses;
using OnionPattern.Domain.IServices.Requests.Tab;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Linq;

namespace OnionPattern.Service.Requests.Tab
{
    public class GetAllTabsRequest : BaseServiceRequest<TabEntity>, IGetAllTabsRequest
    {
        public GetAllTabsRequest(IRepository<TabEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        public TabListResponse Execute()
        {
            Log.Information("Recuperando lista de Tabs...");
            var tabListResponse = new TabListResponse();
            try
            {
                var tab = (Repository.GetAll())?.ToArray();

                if (tab == null || !tab.Any())
                {
                    var exception = new Exception("No hay tabs devueltos.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(tabListResponse, exception, 404);
                }
                else
                {
                    tabListResponse = new TabListResponse
                    {
                        Tabs = tab,
                        StatusCode = 200
                    };
                    var count = tab.Length;
                    Log.Information("Devuelto [{Count}] Tabs.", count);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener la lista de todos los tabs.");
                HandleErrors(tabListResponse, exception);
            }
            return tabListResponse;
        }
    }
}
