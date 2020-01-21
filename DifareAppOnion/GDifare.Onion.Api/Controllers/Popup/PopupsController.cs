using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Entities.Popup.Requests;
using OnionPattern.Domain.IServices.RequestAggregate;

namespace OnionPattern.Api.Controllers.Popup
{
    /// <inheritdoc />
    /// <summary>
    /// Popup Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class Popups : BaseController
    {
        private readonly IPopupRequestAggregate PopupRequestAggregate;

        /// <inheritdoc />
        /// <summary>
        /// Popup Controller
        /// </summary>
        /// <param name="popupRequestAggregate"></param>
        public Popups(IPopupRequestAggregate popupRequestAggregate)
        {
            PopupRequestAggregate = popupRequestAggregate ?? throw new ArgumentNullException(nameof(popupRequestAggregate));
        }
        /// <summary>
        /// Obtener todo los popups.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteAndHandleRequest(() => PopupRequestAggregate.GetAllPopupsRequest.Execute());
        }


        /// <summary>
        /// Obtener popup por Id
        /// </summary>
        /// <param name="id">Id of the Popup.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return ExecuteAndHandleRequest(() => PopupRequestAggregate.GetPopupByIdRequest.Execute(id));
        }

        /// <summary>
        /// Crear un nuevo popup
        /// </summary>
        /// <param name="popup">Informacion del popup</param>
        /// <returns>Popup Creado</returns>


        [HttpPost]
        public IActionResult Crear(CreatePopupInput popup)
        {
            return ExecuteAndHandleRequest(() => PopupRequestAggregate.CreatePopupRequest.Execute(popup));
        }

        /// <summary>
        /// Actualiza la imagen del popup.
        /// </summary>
        /// <param name="input">Informacion a actualizar</param>
        /// <returns>Popup Actualizado</returns>
        [HttpPut]
        public IActionResult Put(UpdatePopupInput input)
        {
            return ExecuteAndHandleRequest(() => PopupRequestAggregate.UpdatePopupRequest.Execute(input));
        }

        /// <summary>
        /// Elimina un popup por su Id
        /// </summary>
        /// <param name="id">Id de el popup</param>
        /// <returns>Popup eliminado</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return ExecuteAndHandleRequest(() => PopupRequestAggregate.DeletePopupByIdRequest.Execute(id));
        }

    }
}