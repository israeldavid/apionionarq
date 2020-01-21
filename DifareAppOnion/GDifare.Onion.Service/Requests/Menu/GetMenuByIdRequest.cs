using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Menu.Responses;
using OnionPattern.Domain.IServices.Requests.Menu;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Service.Requests.Menu
{
    public class GetMenuByIdRequest : BaseServiceRequest<MenuEntity>, IGetMenuByIdRequest
    {
        public GetMenuByIdRequest(IRepository<MenuEntity> repository, IRepositoryAggregate repositoryAggregate)
           : base(repository, repositoryAggregate) { }


        #region Implementation of IGetMenuByIdRequest

        public MenuResponse Execute(int id)
        {
            var menuResponse = new MenuResponse();
            try
            {
                Log.Information("Recuperando menu por Id : [{Id}]", id);

                var menu = Repository.SingleOrDefault(g => g.Id == id);
                if (menu == null)
                {
                    var exception = new Exception($"menu no encontrado por  id : [{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(menuResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    menuResponse.Menu = menu;
                    menuResponse.StatusCode = 200;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener menu por Id: [{Id}].", id);
                HandleErrors(menuResponse, exception);
            }
            return menuResponse;
        }

        #endregion

    }
}
