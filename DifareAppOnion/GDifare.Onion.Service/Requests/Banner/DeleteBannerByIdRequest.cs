using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Banner.Responses;
using OnionPattern.Domain.IServices.Requests.Banner;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Service.Requests.Banner
{
    public class DeleteBannerByIdRequest : BaseServiceRequest<BannerEntity>, IDeleteBannerByIdRequest
    {
        public DeleteBannerByIdRequest(IRepository<BannerEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeleteBannerByIdRequest

        public BannerResponse Execute(int id)
        {
            var bannerResponse = new BannerResponse();
            try
            {
                Log.Information("Eliminando el Banner por Id:[{Id}]...", id);
                var toDelete = Repository.SingleOrDefault(banner => banner.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"Banner no encontrado por Id:[{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(bannerResponse, exception, 404);
                }
                else
                {
                    Repository.Delete(toDelete);
                    bannerResponse.StatusCode = 200;
                    Log.Information("Banner eliminado [{NewName}] por Id:[{Id}].", toDelete.Nombre, toDelete.Id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al elimnar el Banner. [{Message}].", exception.Message);
                HandleErrors(bannerResponse, exception);
            }
            return bannerResponse;
        }

        #endregion
    }
}
