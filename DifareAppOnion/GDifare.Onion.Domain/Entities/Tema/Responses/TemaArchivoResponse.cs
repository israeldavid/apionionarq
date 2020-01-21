using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionPattern.Domain.Entities.Tema.Responses
{
    public class TemaArchivoResponse : IError
    {
        public IEnumerable<TemaEntity> Temas { get; set; }



        #region Implementation of IError
        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }
        #endregion

    }
}
