using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Popup.Responses;
using OnionPattern.Domain.IServices.Requests.Popup;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Popup
{
    public class DeletePopupByIdRequest : BaseServiceRequest<PopupEntity>, IDeletePopupByIdRequest
    {
        public DeletePopupByIdRequest(IRepository<PopupEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeletePopupByIdRequest

        public PopupResponse Execute(int id)
        {
            var popupResponse = new PopupResponse();
            try
            {
                Log.Information("Eliminando el Popup por Id:[{Id}]...", id);
                var toDelete = Repository.SingleOrDefault(popup => popup.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"Popup no encontrado por Id:[{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(popupResponse, exception, 404);
                }
                else
                {
                    Repository.Delete(toDelete);
                    popupResponse.StatusCode = 200;
                    Log.Information("Popup eliminado [{NewName}] por Id:[{Id}].", toDelete.Nombre, toDelete.Id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al elimnar el Popup. [{Message}].", exception.Message);
                HandleErrors(popupResponse, exception);
            }
            return popupResponse;
        }

        #endregion
    }
}
