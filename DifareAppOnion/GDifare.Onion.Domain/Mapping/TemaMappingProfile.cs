using AutoMapper;
using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.Entities.Tema.Requests;

namespace OnionPattern.Mapping
{
    public class TemaMappingProfile : Profile
    {
        public TemaMappingProfile()
        {
            CreateMap<CreateTemaInput, TemaEntity>(MemberList.Source);
        }
    }
}
