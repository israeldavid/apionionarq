using OnionPattern.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Tema.Responses
{
    public class TemaResponse : IError
    {
        public TemaEntity Tema { get; set; }

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
