using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Banner.Requests;
using OnionPattern.Domain.Entities.Banner.Responses;
using OnionPattern.Domain.IServices.Requests.Banner;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Service.Requests.Banner
{
    public class UpdateBannerRequest : BaseServiceRequest<BannerEntity>, IUpdateBannerRequest
    {
        public UpdateBannerRequest(IRepository<BannerEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdateBannerTitleRequest

        public BannerResponse Execute(UpdateBannerInput input)
        {

            var bannerResponse = new BannerResponse();
            try
            {
                CheckInputValidity(input);

                Log.Information("Actualizando Banner por Id: [{Id}] con nuevo nombre: [{NewTitle}]...", input.Id, input.NombreNuevo);

                var bannerToUpdate = Repository.SingleOrDefault(banner => banner.Id == input.Id);
                if (bannerToUpdate == null)
                {
                    var exception = new Exception($"No se pudo encontrar el banner con el id: [{input.Id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(bannerResponse, exception, 404);
                    return bannerResponse;
                }

                bannerToUpdate.Nombre = input.NombreNuevo;
                bannerToUpdate.Base64 = input.Base64Nuevo;

                var updatedBanner = Repository.Update(bannerToUpdate);
                bannerResponse.Banner = updatedBanner;
                bannerResponse.StatusCode = 200;

                Log.Information("Actualizado con exito el banner con Id: [{Id}] con nuevo nombre [{NewTitle}].", input.Id, input.NombreNuevo);
            }
            catch (Exception exception)
            {
                Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                HandleErrors(bannerResponse, exception);
            }
            return bannerResponse;
        }

        #endregion

        private void CheckInputValidity(UpdateBannerInput input)
        {
            if (input == null) { throw new ArgumentNullException(nameof(input)); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} debe ser 1 or mayor."); }
            if (string.IsNullOrWhiteSpace(input.NombreNuevo)) { throw new ArgumentException($"Input {nameof(input.NombreNuevo)} no puede ser vacio."); }
            if (string.IsNullOrWhiteSpace(input.Base64Nuevo)) { throw new ArgumentException($"Input {nameof(input.Base64Nuevo)} no puede ser vacio."); }
        }
    }
}
