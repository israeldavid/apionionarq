using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tab.Requests;
using OnionPattern.Domain.Entities.Tab.Responses;
using OnionPattern.Domain.IServices.Requests.Tab;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Tab
{
    public class UpdateTabRequest : BaseServiceRequest<TabEntity>, IUpdateTabRequest
    {
        public UpdateTabRequest(IRepository<TabEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdateTabTitleRequest

        public TabResponse Execute(UpdateTabInput input)
        {

            var tabResponse = new TabResponse();
            try
            {
                CheckInputValidity(input);

                Log.Information("Actualizando Tab por Id: [{Id}] con nuevo nombre: [{NewTitle}]...", input.Id, input.NombreNuevo);

                var tabToUpdate = Repository.SingleOrDefault(tab => tab.Id == input.Id);
                if (tabToUpdate == null)
                {
                    var exception = new Exception($"No se pudo encontrar el tab con el id: [{input.Id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(tabResponse, exception, 404);
                    return tabResponse;
                }

                tabToUpdate.Nombre = input.NombreNuevo;
                tabToUpdate.Base64 = input.Base64Nuevo;

                var updatedTab = Repository.Update(tabToUpdate);
                tabResponse.Tab = updatedTab;
                tabResponse.StatusCode = 200;

                Log.Information("Actualizado con exito el tab con Id: [{Id}] con nuevo nombre [{NewTitle}].", input.Id, input.NombreNuevo);
            }
            catch (Exception exception)
            {
                Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                HandleErrors(tabResponse, exception);
            }
            return tabResponse;
        }

        #endregion

        private void CheckInputValidity(UpdateTabInput input)
        {
            if (input == null) { throw new ArgumentNullException(nameof(input)); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} debe ser 1 or mayor."); }
            if (string.IsNullOrWhiteSpace(input.NombreNuevo)) { throw new ArgumentException($"Input {nameof(input.NombreNuevo)} no puede ser vacio."); }
            if (string.IsNullOrWhiteSpace(input.Base64Nuevo)) { throw new ArgumentException($"Input {nameof(input.Base64Nuevo)} no puede ser vacio."); }
        }
    }
}
