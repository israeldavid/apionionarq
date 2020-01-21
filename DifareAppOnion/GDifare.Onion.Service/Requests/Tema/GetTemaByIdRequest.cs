using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.Entities.Tema.Responses;
using OnionPattern.Domain.IServices.Requests.Tema;
using OnionPattern.Domain.Repository;
using Serilog;
using System;

namespace OnionPattern.Service.Requests.Tema
{
    public class GetTemaByIdRequest : BaseServiceRequest<TemaEntity>, IGetTemaByIdRequest
    {
        public GetTemaByIdRequest(IRepository<TemaEntity> repository, IRepositoryAggregate repositoryAggregate)
           : base(repository, repositoryAggregate) { }


        #region Implementation of IGetTemaByIdRequest

        public TemaResponse Execute(int id)
        {
            var temaResponse = new TemaResponse();
            try
            {
                Log.Information("Recuperando tema por Id : [{Id}]", id);

                var tema = Repository.SingleOrDefault(g => g.Id == id);
                if (tema == null)
                {
                    var exception = new Exception($"tema no encontrado por  id : [{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(temaResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    temaResponse.Tema = tema;
                    temaResponse.StatusCode = 200;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener tema por Id: [{Id}].", id);
                HandleErrors(temaResponse, exception);
            }
            return temaResponse;
        }

        #endregion

    }
}
