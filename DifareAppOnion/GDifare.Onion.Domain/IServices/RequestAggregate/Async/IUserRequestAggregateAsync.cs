using OnionPattern.Domain.IServices.Requests.JsonPlaceHolder.Async;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.IServices.RequestAggregate.Async
{
    public interface IUserRequestAggregateAsync
    {
        IGetAllUsersRequestAsync GetAllUsersRequestAsync { get; }
    }
}
