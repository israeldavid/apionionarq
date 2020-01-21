using AutoMapper;
using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Popup.Requests;

namespace OnionPattern.Mapping
{
    public class PopupMappingProfile : Profile
    {
        public PopupMappingProfile()
        {
            CreateMap<CreatePopupInput, PopupEntity>(MemberList.Source);
        }
    }
}
