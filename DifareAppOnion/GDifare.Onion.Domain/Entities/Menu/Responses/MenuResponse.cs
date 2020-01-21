using OnionPattern.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Menu.Responses
{
    public class MenuResponse : IError
    {
        public MenuEntity Menu { get; set; }

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
