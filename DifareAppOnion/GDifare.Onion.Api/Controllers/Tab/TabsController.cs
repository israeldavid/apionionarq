using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Entities.Tab.Requests;
using OnionPattern.Domain.IServices.RequestAggregate;

namespace OnionPattern.Api.Controllers.Tab
{
    /// <inheritdoc />
    /// <summary>
    /// Tab Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class Tabs : BaseController
    {
        private readonly ITabRequestAggregate TabRequestAggregate;

        /// <inheritdoc />
        /// <summary>
        /// Tab Controller
        /// </summary>
        /// <param name="tabRequestAggregate"></param>
        public Tabs(ITabRequestAggregate tabRequestAggregate)
        {
            TabRequestAggregate = tabRequestAggregate ?? throw new ArgumentNullException(nameof(tabRequestAggregate));
        }
        /// <summary>
        /// Obtener todo los tabs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteAndHandleRequest(() => TabRequestAggregate.GetAllTabsRequest.Execute());
        }


        /// <summary>
        /// Obtener tab por Id
        /// </summary>
        /// <param name="id">Id of the Tab.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return ExecuteAndHandleRequest(() => TabRequestAggregate.GetTabByIdRequest.Execute(id));
        }

        /// <summary>
        /// Crear un nuevo tab
        /// </summary>
        /// <param name="tab">Informacion del tab</param>
        /// <returns>Tab Creado</returns>


        [HttpPost]
        public IActionResult Crear(CreateTabInput tab)
        {
            return ExecuteAndHandleRequest(() => TabRequestAggregate.CreateTabRequest.Execute(tab));
        }

        /// <summary>
        /// Actualiza la imagen del tab.
        /// </summary>
        /// <param name="input">Informacion a actualizar</param>
        /// <returns>Tab Actualizado</returns>
        [HttpPut]
        public IActionResult Put(UpdateTabInput input)
        {
            return ExecuteAndHandleRequest(() => TabRequestAggregate.UpdateTabRequest.Execute(input));
        }

        /// <summary>
        /// Elimina un tab por su Id
        /// </summary>
        /// <param name="id">Id de el tab</param>
        /// <returns>Tab eliminado</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return ExecuteAndHandleRequest(() => TabRequestAggregate.DeleteTabByIdRequest.Execute(id));
        }

    }
}