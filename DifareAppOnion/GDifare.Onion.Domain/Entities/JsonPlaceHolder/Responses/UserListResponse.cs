using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionPattern.Domain.Entities.JsonPlaceHolder.Responses
{
    public class UserListResponse : IError, IListResponse
    {
        public IEnumerable<UserEntity> Users { get; set; }

        #region Implementation of IListResponse

        public int Count => Users?.Count() ?? 0;
        #endregion

        #region Implementation of IError
        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }
        #endregion
    }
}
