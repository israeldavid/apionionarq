using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Entities.Tema.Requests;
using OnionPattern.Domain.IServices.RequestAggregate;

namespace OnionPattern.Api.Controllers.Tema
{
    /// <inheritdoc />
    /// <summary>
    /// Tema Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class Temas : BaseController
    {
        private readonly ITemaRequestAggregate TemaRequestAggregate;

        /// <inheritdoc />
        /// <summary>
        /// Tema Controller
        /// </summary>
        /// <param name="temaRequestAggregate"></param>
        public Temas(ITemaRequestAggregate temaRequestAggregate)
        {
            TemaRequestAggregate = temaRequestAggregate ?? throw new ArgumentNullException(nameof(temaRequestAggregate));
        }
        /// <summary>
        /// Obtener todo los temas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteAndHandleRequest(() => TemaRequestAggregate.GetAllTemasRequest.Execute());
        }

        /// <summary>
        /// Obtener archivo de temas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ArchivoScss")]
        public IActionResult GetArchivoScss()
        {
            return ExecuteAndHandleRequest(() => TemaRequestAggregate.GetAllTemasRequest.Execute());
        }

        /// <summary>
        /// Obtener tema por Id
        /// </summary>
        /// <param name="id">Id of the Tema.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return ExecuteAndHandleRequest(() => TemaRequestAggregate.GetTemaByIdRequest.Execute(id));
        }

        /// <summary>
        /// Crear un nuevo tema
        /// </summary>
        /// <param name="tema">Informacion del tema</param>
        /// <returns>Tema Creado</returns>


        [HttpPost]
        public IActionResult Crear(CreateTemaInput tema)
        {
            return ExecuteAndHandleRequest(() => TemaRequestAggregate.CreateTemaRequest.Execute(tema));
        }

        /// <summary>
        /// Actualiza la imagen del tema.
        /// </summary>
        /// <param name="input">Informacion a actualizar</param>
        /// <returns>Tema Actualizado</returns>
        [HttpPut]
        public IActionResult Put(UpdateTemaInput input)
        {
            return ExecuteAndHandleRequest(() => TemaRequestAggregate.UpdateTemaRequest.Execute(input));
        }

        /// <summary>
        /// Elimina un tema por su Id
        /// </summary>
        /// <param name="id">Id de el tema</param>
        /// <returns>Tema eliminado</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return ExecuteAndHandleRequest(() => TemaRequestAggregate.DeleteTemaByIdRequest.Execute(id));
        }

    }
}