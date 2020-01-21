using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Entities.Banner.Requests;
using OnionPattern.Domain.IServices.RequestAggregate;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace OnionPattern.Api.Controllers.Banner
{
    /// <inheritdoc />
    /// <summary>
    /// Banner Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class Banners : BaseController
    {
        private readonly IBannerRequestAggregate BannerRequestAggregate;

        /// <inheritdoc />
        /// <summary>
        /// Banner Controller
        /// </summary>
        /// <param name="bannerRequestAggregate"></param>
        public Banners(IBannerRequestAggregate bannerRequestAggregate)
        {
            BannerRequestAggregate = bannerRequestAggregate ?? throw new ArgumentNullException(nameof(bannerRequestAggregate));
        }
        /// <summary>
        /// Obtener todo los banners.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteAndHandleRequest(() => BannerRequestAggregate.GetAllBannersRequest.Execute());
        }


        /// <summary>
        /// Obtener banner por Id
        /// </summary>
        /// <param name="id">Id of the Banner.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return ExecuteAndHandleRequest(() => BannerRequestAggregate.GetBannerByIdRequest.Execute(id));
        }

        /// <summary>
        /// Crear un nuevo banner
        /// </summary>
        /// <param name="banner">Informacion del banner</param>
        /// <returns>Banner Creado</returns>


        [HttpPost]
        public IActionResult Crear(CreateBannerInput banner)
        {
            return ExecuteAndHandleRequest(() => BannerRequestAggregate.CreateBannerRequest.Execute(banner));
        }

        /// <summary>
        /// Actualiza la imagen del banner.
        /// </summary>
        /// <param name="input">Informacion a actualizar</param>
        /// <returns>Banner Actualizado</returns>
        [HttpPut]
        public IActionResult Put(UpdateBannerInput input)
        {
            return ExecuteAndHandleRequest(() => BannerRequestAggregate.UpdateBannerRequest.Execute(input));
        }

        /// <summary>
        /// Elimina un banner por su Id
        /// </summary>
        /// <param name="id">Id de el banner</param>
        /// <returns>Banner eliminado</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return ExecuteAndHandleRequest(() => BannerRequestAggregate.DeleteBannerByIdRequest.Execute(id));
        }

    }
}