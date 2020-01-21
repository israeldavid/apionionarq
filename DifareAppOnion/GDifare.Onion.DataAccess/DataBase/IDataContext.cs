using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tema;

namespace OnionPattern.DataAccess.EF
{
    public interface IDataContext
    {
        DbSet<BannerEntity> Banners { get; set; }
        DbSet<MenuEntity> Menus { get; set; }
        DbSet<PopupEntity> Popups { get; set; }
        DbSet<TabEntity> Tabs { get; set; }
        DbSet<TemaEntity> Temas { get; set; }

    }
}