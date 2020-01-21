using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Menu.Responses;
using OnionPattern.Domain.IServices.Requests.Menu;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Linq;

namespace OnionPattern.Service.Requests.Menu
{
    public class GetAllMenusRequest : BaseServiceRequest<MenuEntity>, IGetAllMenusRequest
    {
        public GetAllMenusRequest(IRepository<MenuEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        public MenuListResponse Execute()
        {
            Log.Information("Recuperando lista de Menus...");
            var menuListResponse = new MenuListResponse();
            try
            {
                var menu = (Repository.GetAll())?.ToArray();

                if (menu == null || !menu.Any())
                {
                    var exception = new Exception("No hay menus devueltos.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(menuListResponse, exception, 404);
                }
                else
                {
                    menuListResponse = new MenuListResponse
                    {
                        Menus = menu,
                        StatusCode = 200
                    };
                    var count = menu.Length;
                    Log.Information("Devuelto [{Count}] Menus.", count);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener la lista de todos los menus.");
                HandleErrors(menuListResponse, exception);
            }
            return menuListResponse;
        }
    }
}
