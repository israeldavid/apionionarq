using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionPattern.Domain.Entities.Menu.Responses
{
    public class MenuListResponse : IError, IListResponse
    {
        public IEnumerable<MenuEntity> Menus { get; set; }

        #region Implementation of IListResponse

        public int Count => Menus?.Count() ?? 0;
        #endregion

        #region Implementation of IError
        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }
        #endregion

    }
}
