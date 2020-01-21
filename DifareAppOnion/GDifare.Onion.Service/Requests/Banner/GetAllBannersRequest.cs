using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Banner.Responses;
using OnionPattern.Domain.IServices.Requests.Banner;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Linq;

namespace OnionPattern.Service.Requests.Banner
{
    public class GetAllBannersRequest : BaseServiceRequest<BannerEntity>, IGetAllBannersRequest
    {
        public GetAllBannersRequest(IRepository<BannerEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        public BannerListResponse Execute()
        {
            Log.Information("Recuperando lista de Banners...");
            var bannerListResponse = new BannerListResponse();
            try
            {
                var banner = (Repository.GetAll())?.ToArray();

                if (banner == null || !banner.Any())
                {
                    var exception = new Exception("No hay banners devueltos.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(bannerListResponse, exception, 404);
                }
                else
                {
                    bannerListResponse = new BannerListResponse
                    {
                        Banners = banner,
                        StatusCode = 200
                    };
                    var count = banner.Length;
                    Log.Information("Devuelto [{Count}] Banners.", count);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener la lista de todos los banners.");
                HandleErrors(bannerListResponse, exception);
            }
            return bannerListResponse;
        }
    }
}
