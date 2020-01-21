using AutoMapper;
using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Banner.Requests;

namespace OnionPattern.Mapping
{
    public class BannerMappingProfile : Profile
    {
        public BannerMappingProfile()
        {
            CreateMap<CreateBannerInput, BannerEntity>(MemberList.Source);
        }
    }
}
