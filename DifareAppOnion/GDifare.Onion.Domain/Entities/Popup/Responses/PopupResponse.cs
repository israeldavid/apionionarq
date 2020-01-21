using OnionPattern.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Popup.Responses
{
    public class PopupResponse : IError
    {
        public PopupEntity Popup { get; set; }

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
