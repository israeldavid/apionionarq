using AutoMapper;
using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tab.Requests;

namespace OnionPattern.Mapping
{
    public class TabMappingProfile : Profile
    {
        public TabMappingProfile()
        {
            CreateMap<CreateTabInput, TabEntity>(MemberList.Source);
        }
    }
}
