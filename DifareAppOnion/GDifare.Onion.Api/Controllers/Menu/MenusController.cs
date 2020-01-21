using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Entities.Menu.Requests;
using OnionPattern.Domain.IServices.RequestAggregate;

namespace OnionPattern.Api.Controllers.Menu
{
    /// <inheritdoc />
    /// <summary>
    /// Menu Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class Menus : BaseController
    {
        private readonly IMenuRequestAggregate MenuRequestAggregate;

        /// <inheritdoc />
        /// <summary>
        /// Menu Controller
        /// </summary>
        /// <param name="menuRequestAggregate"></param>
        public Menus(IMenuRequestAggregate menuRequestAggregate)
        {
            MenuRequestAggregate = menuRequestAggregate ?? throw new ArgumentNullException(nameof(menuRequestAggregate));
        }
        /// <summary>
        /// Obtener todo los menus.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteAndHandleRequest(() => MenuRequestAggregate.GetAllMenusRequest.Execute());
        }


        /// <summary>
        /// Obtener menu por Id
        /// </summary>
        /// <param name="id">Id of the Menu.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return ExecuteAndHandleRequest(() => MenuRequestAggregate.GetMenuByIdRequest.Execute(id));
        }

        /// <summary>
        /// Crear un nuevo menu
        /// </summary>
        /// <param name="menu">Informacion del menu</param>
        /// <returns>Menu Creado</returns>


        [HttpPost]
        public IActionResult Crear(CreateMenuInput menu)
        {
            return ExecuteAndHandleRequest(() => MenuRequestAggregate.CreateMenuRequest.Execute(menu));
        }

        /// <summary>
        /// Actualiza la imagen del menu.
        /// </summary>
        /// <param name="input">Informacion a actualizar</param>
        /// <returns>Menu Actualizado</returns>
        [HttpPut]
        public IActionResult Put(UpdateMenuInput input)
        {
            return ExecuteAndHandleRequest(() => MenuRequestAggregate.UpdateMenuRequest.Execute(input));
        }

        /// <summary>
        /// Elimina un menu por su Id
        /// </summary>
        /// <param name="id">Id de el menu</param>
        /// <returns>Menu eliminado</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return ExecuteAndHandleRequest(() => MenuRequestAggregate.DeleteMenuByIdRequest.Execute(id));
        }

    }
}