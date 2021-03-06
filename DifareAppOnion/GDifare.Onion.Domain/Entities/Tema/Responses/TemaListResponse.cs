﻿using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionPattern.Domain.Entities.Tema.Responses
{
    public class TemaListResponse : IError, IListResponse
    {
        public IEnumerable<TemaEntity> Temas { get; set; }

        #region Implementation of IListResponse

        public int Count => Temas?.Count() ?? 0;
        #endregion

        #region Implementation of IError
        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }
        #endregion

    }
}
