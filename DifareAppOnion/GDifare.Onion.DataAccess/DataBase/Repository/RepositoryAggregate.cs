using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.DataAccess.EF.Repository
{
    public class RepositoryAggregate : IRepositoryAggregate
    {
        private readonly DbContext dbContext;

        public RepositoryAggregate(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private IRepository<BannerEntity> banners;
        public IRepository<BannerEntity> Banners => banners ?? (banners = new Repository<BannerEntity>(dbContext));

        private IRepository<MenuEntity> menus;
        public IRepository<MenuEntity> Menus => menus ?? (menus = new Repository<MenuEntity>(dbContext));

        private IRepository<PopupEntity> popups;
        public IRepository<PopupEntity> Popups => popups ?? (popups = new Repository<PopupEntity>(dbContext));

        private IRepository<TabEntity> tabs;
        public IRepository<TabEntity> Tabs => tabs ?? (tabs = new Repository<TabEntity>(dbContext));

        private IRepository<TemaEntity> temas;
        public IRepository<TemaEntity> Temas => temas ?? (temas = new Repository<TemaEntity>(dbContext));

    }
}
