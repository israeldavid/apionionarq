using OnionPattern.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Tab.Responses
{
    public class TabResponse : IError
    {
        public TabEntity Tab { get; set; }

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
