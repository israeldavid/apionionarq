using AutoMapper;
using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Popup.Requests;
using OnionPattern.Domain.Entities.Popup.Responses;
using OnionPattern.Domain.IServices.Requests.Popup;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Service.Requests.Popup
{
    public class CreatePopupRequest : BaseServiceRequest<PopupEntity>, ICreatePopupRequest
    {
        public CreatePopupRequest(IRepository<PopupEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreatePopupRequest

        public PopupResponse Execute(CreatePopupInput input)
        {
            var popupResponse = new PopupResponse();
            try
            {
                Log.Information("Creando Popup Con nombre [{NewName}]...", input?.Nombre);
                byte[] imageBytes = Convert.FromBase64String(input?.Base64);
                PopupEntity popupEntity = Mapper.Map<CreatePopupInput, PopupEntity>(input);
                popupEntity.FechaCreacion = DateTime.Now;
                popupResponse.Popup = Repository.Create(popupEntity);
                popupResponse.StatusCode = 200;
                Log.Information("Popup creado con el nombre [{NewName}] con el Id: [{Id}]", popupResponse.Popup.Nombre, popupResponse.Popup.Id);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al crear el Popup: [{NewName}].", input?.Nombre);
                HandleErrors(popupResponse, exception);
            }
            return popupResponse;
        }

        #endregion
    }
}
