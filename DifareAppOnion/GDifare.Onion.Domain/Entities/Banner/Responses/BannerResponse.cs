using OnionPattern.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Banner.Responses
{
    public class BannerResponse : IError
    {
        public BannerEntity Banner { get; set; }

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
