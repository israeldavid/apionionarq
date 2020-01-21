using AutoMapper;

namespace OnionPattern.Mapping
{
    public static class MappingProfileInitializer
    {
        public static void ConfigureMappings()
        {
            Mapper.Reset();
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            Mapper.Initialize(configuration =>
            {
                configuration.AddProfile<BannerMappingProfile>();
                configuration.AddProfile<MenuMappingProfile>();
                configuration.AddProfile<PopupMappingProfile>();
                configuration.AddProfile<TabMappingProfile>();
                configuration.AddProfile<TemaMappingProfile>();
            });
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            Mapper.AssertConfigurationIsValid();
        }
    }
}
