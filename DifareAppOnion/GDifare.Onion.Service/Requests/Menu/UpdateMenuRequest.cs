using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Menu.Requests;
using OnionPattern.Domain.Entities.Menu.Responses;
using OnionPattern.Domain.IServices.Requests.Menu;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Service.Requests.Menu
{
    public class UpdateMenuRequest : BaseServiceRequest<MenuEntity>, IUpdateMenuRequest
    {
        public UpdateMenuRequest(IRepository<MenuEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdateMenuTitleRequest

        public MenuResponse Execute(UpdateMenuInput input)
        {

            var menuResponse = new MenuResponse();
            try
            {
                CheckInputValidity(input);

                Log.Information("Actualizando Menu por Id: [{Id}] con nuevo nombre: [{NewTitle}]...", input.Id, input.NombreNuevo);

                var menuToUpdate = Repository.SingleOrDefault(menu => menu.Id == input.Id);
                if (menuToUpdate == null)
                {
                    var exception = new Exception($"No se pudo encontrar el menu con el id: [{input.Id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(menuResponse, exception, 404);
                    return menuResponse;
                }

                menuToUpdate.Nombre = input.NombreNuevo;
                menuToUpdate.Base64 = input.Base64Nuevo;

                var updatedMenu = Repository.Update(menuToUpdate);
                menuResponse.Menu = updatedMenu;
                menuResponse.StatusCode = 200;

                Log.Information("Actualizado con exito el menu con Id: [{Id}] con nuevo nombre [{NewTitle}].", input.Id, input.NombreNuevo);
            }
            catch (Exception exception)
            {
                Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                HandleErrors(menuResponse, exception);
            }
            return menuResponse;
        }

        #endregion

        private void CheckInputValidity(UpdateMenuInput input)
        {
            if (input == null) { throw new ArgumentNullException(nameof(input)); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} debe ser 1 or mayor."); }
            if (string.IsNullOrWhiteSpace(input.NombreNuevo)) { throw new ArgumentException($"Input {nameof(input.NombreNuevo)} no puede ser vacio."); }
            if (string.IsNullOrWhiteSpace(input.Base64Nuevo)) { throw new ArgumentException($"Input {nameof(input.Base64Nuevo)} no puede ser vacio."); }
        }
    }
}
