using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tema;

namespace OnionPattern.Domain.Repository
{
    public interface IRepositoryAggregate
    {
        IRepository<BannerEntity> Banners { get; }
        IRepository<MenuEntity> Menus { get; }
        IRepository<PopupEntity> Popups { get; }
        IRepository<TabEntity> Tabs { get; }
        IRepository<TemaEntity> Temas { get; }

    }
}