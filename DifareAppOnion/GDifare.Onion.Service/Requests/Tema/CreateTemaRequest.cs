using AutoMapper;
using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.Entities.Tema.Requests;
using OnionPattern.Domain.Entities.Tema.Responses;
using OnionPattern.Domain.IServices.Requests.Tema;
using OnionPattern.Domain.Repository;
using Serilog;
using System;

namespace OnionPattern.Service.Requests.Tema
{
    public class CreateTemaRequest : BaseServiceRequest<TemaEntity>, ICreateTemaRequest
    {
        public CreateTemaRequest(IRepository<TemaEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreateTemaRequest

        public TemaResponse Execute(CreateTemaInput input)
        {
            var temaResponse = new TemaResponse();
            try
            {
                Log.Information("Creando Tema Con nombre [{NewName}]...", input?.Nombre);
                TemaEntity temaEntity = Mapper.Map<CreateTemaInput, TemaEntity>(input);
                temaEntity.FechaCreacion = DateTime.Now;
                temaResponse.Tema = Repository.Create(temaEntity);
                temaResponse.StatusCode = 200;
                Log.Information("Tema creado con el nombre [{NewName}] con el Id: [{Id}]", temaResponse.Tema.Nombre, temaResponse.Tema.Id);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al crear el Tema: [{NewName}].", input?.Nombre);
                HandleErrors(temaResponse, exception);
            }
            return temaResponse;
        }

        #endregion
    }
}
