using AutoMapper;
using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Menu.Requests;

namespace OnionPattern.Mapping
{
    public class MenuMappingProfile : Profile
    {
        public MenuMappingProfile()
        {
            CreateMap<CreateMenuInput, MenuEntity>(MemberList.Source);
        }
    }
}
