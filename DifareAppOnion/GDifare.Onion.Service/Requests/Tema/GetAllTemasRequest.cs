using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.Entities.Tema.Responses;
using OnionPattern.Domain.IServices.Requests.Tema;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Linq;

namespace OnionPattern.Service.Requests.Tema
{
    public class GetAllTemasRequest : BaseServiceRequest<TemaEntity>, IGetAllTemasRequest
    {
        public GetAllTemasRequest(IRepository<TemaEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        public TemaListResponse Execute()
        {
            Log.Information("Recuperando lista de Temas...");
            var temaListResponse = new TemaListResponse();
            try
            {
                var tema = (Repository.GetAll())?.ToArray();

                if (tema == null || !tema.Any())
                {
                    var exception = new Exception("No hay temas devueltos.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(temaListResponse, exception, 404);
                }
                else
                {
                    temaListResponse = new TemaListResponse
                    {
                        Temas = tema,
                        StatusCode = 200
                    };
                    var count = tema.Length;
                    Log.Information("Devuelto [{Count}] Temas.", count);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener la lista de todos los temas.");
                HandleErrors(temaListResponse, exception);
            }
            return temaListResponse;
        }
    }
}
