using OnionPattern.Domain.Entities.Banner.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.IServices.Requests.Banner
{
    public interface IDeleteBannerByIdRequest
    {
        BannerResponse Execute(int id);
    }
}
