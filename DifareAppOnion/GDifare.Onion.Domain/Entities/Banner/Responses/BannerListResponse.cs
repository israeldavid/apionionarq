using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionPattern.Domain.Entities.Banner.Responses
{
    public class BannerListResponse : IError, IListResponse
    {
        public IEnumerable<BannerEntity> Banners { get; set; }

        #region Implementation of IListResponse

        public int Count => Banners?.Count() ?? 0;
        #endregion

        #region Implementation of IError
        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }
        #endregion

    }
}
