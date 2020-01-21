using AutoMapper;
using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Menu.Requests;
using OnionPattern.Domain.Entities.Menu.Responses;
using OnionPattern.Domain.IServices.Requests.Menu;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Service.Requests.Menu
{
    public class CreateMenuRequest : BaseServiceRequest<MenuEntity>, ICreateMenuRequest
    {
        public CreateMenuRequest(IRepository<MenuEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreateMenuRequest

        public MenuResponse Execute(CreateMenuInput input)
        {
            var menuResponse = new MenuResponse();
            try
            {
                Log.Information("Creando Menu Con nombre [{NewName}]...", input?.Nombre);
                byte[] imageBytes = Convert.FromBase64String(input?.Base64);
                MenuEntity menuEntity = Mapper.Map<CreateMenuInput, MenuEntity>(input);
                menuEntity.FechaCreacion = DateTime.Now;
                menuResponse.Menu = Repository.Create(menuEntity);
                menuResponse.StatusCode = 200;
                Log.Information("Menu creado con el nombre [{NewName}] con el Id: [{Id}]", menuResponse.Menu.Nombre, menuResponse.Menu.Id);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al crear el Menu: [{NewName}].", input?.Nombre);
                HandleErrors(menuResponse, exception);
            }
            return menuResponse;
        }

        #endregion
    }
}
