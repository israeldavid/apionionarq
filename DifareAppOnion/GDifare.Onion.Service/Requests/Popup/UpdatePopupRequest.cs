using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Popup.Requests;
using OnionPattern.Domain.Entities.Popup.Responses;
using OnionPattern.Domain.IServices.Requests.Popup;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Popup
{
    public class UpdatePopupRequest : BaseServiceRequest<PopupEntity>, IUpdatePopupRequest
    {
        public UpdatePopupRequest(IRepository<PopupEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdatePopupTitleRequest

        public PopupResponse Execute(UpdatePopupInput input)
        {

            var popupResponse = new PopupResponse();
            try
            {
                CheckInputValidity(input);

                Log.Information("Actualizando Popup por Id: [{Id}] con nuevo nombre: [{NewTitle}]...", input.Id, input.NombreNuevo);

                var popupToUpdate = Repository.SingleOrDefault(popup => popup.Id == input.Id);
                if (popupToUpdate == null)
                {
                    var exception = new Exception($"No se pudo encontrar el popup con el id: [{input.Id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(popupResponse, exception, 404);
                    return popupResponse;
                }

                popupToUpdate.Nombre = input.NombreNuevo;
                popupToUpdate.Base64 = input.Base64Nuevo;

                var updatedPopup = Repository.Update(popupToUpdate);
                popupResponse.Popup = updatedPopup;
                popupResponse.StatusCode = 200;

                Log.Information("Actualizado con exito el popup con Id: [{Id}] con nuevo nombre [{NewTitle}].", input.Id, input.NombreNuevo);
            }
            catch (Exception exception)
            {
                Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                HandleErrors(popupResponse, exception);
            }
            return popupResponse;
        }

        #endregion

        private void CheckInputValidity(UpdatePopupInput input)
        {
            if (input == null) { throw new ArgumentNullException(nameof(input)); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} debe ser 1 or mayor."); }
            if (string.IsNullOrWhiteSpace(input.NombreNuevo)) { throw new ArgumentException($"Input {nameof(input.NombreNuevo)} no puede ser vacio."); }
            if (string.IsNullOrWhiteSpace(input.Base64Nuevo)) { throw new ArgumentException($"Input {nameof(input.Base64Nuevo)} no puede ser vacio."); }
        }
    }
}
