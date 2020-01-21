using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tema;

namespace OnionPattern.DataAccess.EF
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<BannerEntity> Banners { get; set; }
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<PopupEntity> Popups { get; set; }
        public DbSet<TabEntity> Tabs { get; set; }
        public DbSet<TemaEntity> Temas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BannerEntity>().ToTable(nameof(BannerEntity)).Property(g => g.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MenuEntity>().ToTable(nameof(MenuEntity)).Property(g => g.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PopupEntity>().ToTable(nameof(PopupEntity)).Property(g => g.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TabEntity>().ToTable(nameof(TabEntity)).Property(g => g.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TemaEntity>().ToTable(nameof(TemaEntity)).Property(g => g.Id).ValueGeneratedOnAdd();

        }
    }
}
