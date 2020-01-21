using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionPattern.Domain.Entities.Tab.Responses
{
    public class TabListResponse : IError, IListResponse
    {
        public IEnumerable<TabEntity> Tabs { get; set; }

        #region Implementation of IListResponse

        public int Count => Tabs?.Count() ?? 0;
        #endregion

        #region Implementation of IError
        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }
        #endregion

    }
}
