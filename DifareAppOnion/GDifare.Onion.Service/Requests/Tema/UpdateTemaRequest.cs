using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.Entities.Tema.Requests;
using OnionPattern.Domain.Entities.Tema.Responses;
using OnionPattern.Domain.IServices.Requests.Tema;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Tema
{
    public class UpdateTemaRequest : BaseServiceRequest<TemaEntity>, IUpdateTemaRequest
    {
        public UpdateTemaRequest(IRepository<TemaEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdateTemaTitleRequest

        public TemaResponse Execute(UpdateTemaInput input)
        {

            var temaResponse = new TemaResponse();
            try
            {
                CheckInputValidity(input);

                Log.Information("Actualizando Tema por Id: [{Id}] con nuevo nombre: [{NewTitle}]...", input.Id, input.NombreNuevo);

                var temaToUpdate = Repository.SingleOrDefault(tema => tema.Id == input.Id);
                if (temaToUpdate == null)
                {
                    var exception = new Exception($"No se pudo encontrar el tema con el id: [{input.Id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(temaResponse, exception, 404);
                    return temaResponse;
                }

                temaToUpdate.Nombre = input.NombreNuevo;
                temaToUpdate.Descripcion = input.Descripcion;

                var updatedTema = Repository.Update(temaToUpdate);
                temaResponse.Tema = updatedTema;
                temaResponse.StatusCode = 200;

                Log.Information("Actualizado con exito el tema con Id: [{Id}] con nuevo nombre [{NewTitle}].", input.Id, input.NombreNuevo);
            }
            catch (Exception exception)
            {
                Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                HandleErrors(temaResponse, exception);
            }
            return temaResponse;
        }

        #endregion

        private void CheckInputValidity(UpdateTemaInput input)
        {
            if (input == null) { throw new ArgumentNullException(nameof(input)); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} debe ser 1 or mayor."); }
            if (string.IsNullOrWhiteSpace(input.NombreNuevo)) { throw new ArgumentException($"Input {nameof(input.NombreNuevo)} no puede ser vacio."); }
            if (string.IsNullOrWhiteSpace(input.Descripcion)) { throw new ArgumentException($"Input {nameof(input.Descripcion)} no puede ser vacio."); }
        }
    }
}
