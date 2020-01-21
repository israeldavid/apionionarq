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
    public class DeleteMenuByIdRequest : BaseServiceRequest<MenuEntity>, IDeleteMenuByIdRequest
    {
        public DeleteMenuByIdRequest(IRepository<MenuEntity> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeleteMenuByIdRequest

        public MenuResponse Execute(int id)
        {
            var menuResponse = new MenuResponse();
            try
            {
                Log.Information("Eliminando el Menu por Id:[{Id}]...", id);
                var toDelete = Repository.SingleOrDefault(menu => menu.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"Menu no encontrado por Id:[{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(menuResponse, exception, 404);
                }
                else
                {
                    Repository.Delete(toDelete);
                    menuResponse.StatusCode = 200;
                    Log.Information("Menu eliminado [{NewName}] por Id:[{Id}].", toDelete.Nombre, toDelete.Id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al elimnar el Menu. [{Message}].", exception.Message);
                HandleErrors(menuResponse, exception);
            }
            return menuResponse;
        }

        #endregion
    }
}
