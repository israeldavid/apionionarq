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
    public class GetBannerByIdRequest : BaseServiceRequest<BannerEntity>, IGetBannerByIdRequest
    {
        public GetBannerByIdRequest(IRepository<BannerEntity> repository, IRepositoryAggregate repositoryAggregate)
           : base(repository, repositoryAggregate) { }


        #region Implementation of IGetBannerByIdRequest

        public BannerResponse Execute(int id)
        {
            var bannerResponse = new BannerResponse();
            try
            {
                Log.Information("Recuperando banner por Id : [{Id}]", id);

                var banner = Repository.SingleOrDefault(g => g.Id == id);
                if (banner == null)
                {
                    var exception = new Exception($"banner no encontrado por  id : [{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(bannerResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    bannerResponse.Banner = banner;
                    bannerResponse.StatusCode = 200;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener banner por Id: [{Id}].", id);
                HandleErrors(bannerResponse, exception);
            }
            return bannerResponse;
        }

        #endregion

    }
}
