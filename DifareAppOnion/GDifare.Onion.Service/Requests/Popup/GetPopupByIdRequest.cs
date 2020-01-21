using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Popup.Responses;
using OnionPattern.Domain.IServices.Requests.Popup;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Popup
{
    public class GetPopupByIdRequest : BaseServiceRequest<PopupEntity>, IGetPopupByIdRequest
    {
        public GetPopupByIdRequest(IRepository<PopupEntity> repository, IRepositoryAggregate repositoryAggregate)
           : base(repository, repositoryAggregate) { }


        #region Implementation of IGetPopupByIdRequest

        public PopupResponse Execute(int id)
        {
            var popupResponse = new PopupResponse();
            try
            {
                Log.Information("Recuperando popup por Id : [{Id}]", id);

                var popup = Repository.SingleOrDefault(g => g.Id == id);
                if (popup == null)
                {
                    var exception = new Exception($"popup no encontrado por  id : [{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(popupResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    popupResponse.Popup = popup;
                    popupResponse.StatusCode = 200;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener popup por Id: [{Id}].", id);
                HandleErrors(popupResponse, exception);
            }
            return popupResponse;
        }

        #endregion

    }
}
