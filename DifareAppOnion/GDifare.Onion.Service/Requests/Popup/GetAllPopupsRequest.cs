using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Popup.Responses;
using OnionPattern.Domain.IServices.Requests.Popup;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Linq;

namespace OnionPattern.Service.Requests.Popup
{
    public class GetAllPopupsRequest : BaseServiceRequest<PopupEntity>, IGetAllPopupsRequest
    {
        public GetAllPopupsRequest(IRepository<PopupEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        public PopupListResponse Execute()
        {
            Log.Information("Recuperando lista de Popups...");
            var popupListResponse = new PopupListResponse();
            try
            {
                var popup = (Repository.GetAll())?.ToArray();

                if (popup == null || !popup.Any())
                {
                    var exception = new Exception("No hay popups devueltos.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(popupListResponse, exception, 404);
                }
                else
                {
                    popupListResponse = new PopupListResponse
                    {
                        Popups = popup,
                        StatusCode = 200
                    };
                    var count = popup.Length;
                    Log.Information("Devuelto [{Count}] Popups.", count);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener la lista de todos los popups.");
                HandleErrors(popupListResponse, exception);
            }
            return popupListResponse;
        }
    }
}
