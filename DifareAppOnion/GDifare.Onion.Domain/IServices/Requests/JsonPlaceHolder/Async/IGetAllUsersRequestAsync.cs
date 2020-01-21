using OnionPattern.Domain.Entities.JsonPlaceHolder.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionPattern.Domain.IServices.Requests.JsonPlaceHolder.Async
{
    public interface IGetAllUsersRequestAsync
    {
        Task<UserListResponse> ExecuteAsync();
    }
}
