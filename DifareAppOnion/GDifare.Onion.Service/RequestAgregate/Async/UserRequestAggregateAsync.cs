using OnionPattern.Domain.Entities.JsonPlaceHolder;
using OnionPattern.Domain.IServices.RequestAggregate.Async;
using OnionPattern.Domain.IServices.Requests.JsonPlaceHolder.Async;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests.JsonPlaceHolder.Async;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Service.RequestAgregate.Async
{
    public class UserRequestAggregateAsync : BaseRequestAsyncAggregate<UserEntity>, IUserRequestAggregateAsync
    {
        public UserRequestAggregateAsync(IRepositoryAsync<UserEntity> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
           : base(repositoryAsync, repositoryAsyncAggregate) { }

        #region Implementation of IGameRequestAggregate

        private IGetAllUsersRequestAsync getAllUsersRequestAsync;
        public IGetAllUsersRequestAsync GetAllUsersRequestAsync => getAllUsersRequestAsync ??
                                                                   (getAllUsersRequestAsync = new GetAllUsersRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        #endregion
    }
}
