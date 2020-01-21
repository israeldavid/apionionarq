using AutoMapper;
using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tab.Requests;
using OnionPattern.Domain.Entities.Tab.Responses;
using OnionPattern.Domain.IServices.Requests.Tab;
using OnionPattern.Domain.Repository;
using Serilog;
using System;


namespace OnionPattern.Service.Requests.Tab
{
    public class CreateTabRequest : BaseServiceRequest<TabEntity>, ICreateTabRequest
    {
        public CreateTabRequest(IRepository<TabEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreateTabRequest

        public TabResponse Execute(CreateTabInput input)
        {
            var tabResponse = new TabResponse();
            try
            {
                Log.Information("Creando Tab Con nombre [{NewName}]...", input?.Nombre);
                byte[] imageBytes = Convert.FromBase64String(input?.Base64);
                TabEntity tabEntity = Mapper.Map<CreateTabInput, TabEntity>(input);
                tabEntity.FechaCreacion = DateTime.Now;
                tabResponse.Tab = Repository.Create(tabEntity);
                tabResponse.StatusCode = 200;
                Log.Information("Tab creado con el nombre [{NewName}] con el Id: [{Id}]", tabResponse.Tab.Nombre, tabResponse.Tab.Id);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al crear el Tab: [{NewName}].", input?.Nombre);
                HandleErrors(tabResponse, exception);
            }
            return tabResponse;
        }

        #endregion
    }
}
