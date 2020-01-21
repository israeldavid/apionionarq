using OnionPattern.Domain.Entities.JsonPlaceHolder;
using OnionPattern.Domain.Entities.JsonPlaceHolder.Responses;
using OnionPattern.Domain.IServices.Requests.JsonPlaceHolder.Async;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Threading.Tasks;
using System.Linq;




namespace OnionPattern.Service.Requests.JsonPlaceHolder.Async
{
    public class GetAllUsersRequestAsync : BaseServiceRequestAsync<UserEntity>, IGetAllUsersRequestAsync
    {
        public GetAllUsersRequestAsync(IRepositoryAsync<UserEntity> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
            : base(repositoryAsync, repositoryAsyncAggregate) { }

        public async Task<UserListResponse> ExecuteAsync()
        {
            Log.Information("Recuperando lista de Usuarios...");
            var userListResponse = new UserListResponse();
            try
            {
                var user = (await Repository.GetAllAsync("users"))?.ToArray();

                if (user == null || !user.Any())
                {
                    var exception = new Exception("No hay usuarios devueltos.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(userListResponse, exception, 404);
                }
                else
                {
                    userListResponse = new UserListResponse
                    {
                        Users = user,
                        StatusCode = 200
                    };
                    var count = user.Length;
                    Log.Information("Devuelto [{Count}] Usuarios.", count);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error al obtener la lista de todos los usuarios.");
                HandleErrors(userListResponse, exception);
            }
            return userListResponse;
        }
    }
}
