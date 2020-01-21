using AutoMapper;
using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Banner.Requests;
using OnionPattern.Domain.Entities.Banner.Responses;
using OnionPattern.Domain.IServices.Requests.Banner;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnionPattern.Service.Requests.Banner
{
    public class CreateBannerRequest : BaseServiceRequest<BannerEntity>, ICreateBannerRequest
    {
        public CreateBannerRequest(IRepository<BannerEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreateBannerRequest

        public BannerResponse Execute(CreateBannerInput input)
        {
            var bannerResponse = new BannerResponse();
            try
            {
                Log.Information("Creando Banner Con nombre [{NewName}]...", input?.Nombre);
                byte[] imageBytes = Convert.FromBase64String(input?.Base64);
                BannerEntity bannerEntity = Mapper.Map<CreateBannerInput, BannerEntity>(input);
                bannerEntity.FechaCreacion = DateTime.Now;
                bannerResponse.Banner = Repository.Create(bannerEntity);
                bannerResponse.StatusCode = 200;
                Log.Information("Banner creado con el nombre [{NewName}] con el Id: [{Id}]", bannerResponse.Banner.Nombre, bannerResponse.Banner.Id);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al crear el Banner: [{NewName}].", input?.Nombre);
                HandleErrors(bannerResponse, exception);
            }
            return bannerResponse;
        }

        #endregion
    }
}
