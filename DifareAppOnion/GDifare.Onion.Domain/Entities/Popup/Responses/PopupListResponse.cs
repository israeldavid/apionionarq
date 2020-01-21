using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionPattern.Domain.Entities.Popup.Responses
{
    public class PopupListResponse : IError, IListResponse
    {
        public IEnumerable<PopupEntity> Popups { get; set; }

        #region Implementation of IListResponse

        public int Count => Popups?.Count() ?? 0;
        #endregion

        #region Implementation of IError
        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }
        #endregion

    }
}
