using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionPattern.DataAccess.EF;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Configurations;
using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.JsonPlaceHolder;
using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var connectionStrings = serviceProvider.GetService<IOptions<ConnectionStringsConfiguration>>();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("Onion.Pattern");
            });
            services.AddScoped<DbContext>(provider => provider.GetService<DataContext>());

            ConfigureNonAsync(services);
            ConfigureAsync(services);
        }

        private static void ConfigureNonAsync(IServiceCollection services)
        {
            services.AddTransient<IRepository<BannerEntity>, Repository<BannerEntity>>(InitializeRepository<BannerEntity>());
            services.AddTransient<IRepository<MenuEntity>, Repository<MenuEntity>>(InitializeRepository<MenuEntity>());
            services.AddTransient<IRepository<PopupEntity>, Repository<PopupEntity>>(InitializeRepository<PopupEntity>());
            services.AddTransient<IRepository<TabEntity>, Repository<TabEntity>>(InitializeRepository<TabEntity>());
            services.AddTransient<IRepository<TemaEntity>, Repository<TemaEntity>>(InitializeRepository<TemaEntity>());
            services.AddTransient<IRepositoryAggregate, RepositoryAggregate>();
        }

        private static void ConfigureAsync(IServiceCollection services)
        {
            services.AddTransient<IRepositoryAsync<UserEntity>, RepositoryAsync<UserEntity>>(InitializeRepositoryAsync<UserEntity>());
            services.AddTransient<IRepositoryAsyncAggregate, RepositoryAsyncAggregate>();
        }

        private static Func<IServiceProvider, Repository<TEntity>> InitializeRepository<TEntity>() where TEntity : class
        {
            return context =>
            {
                DbContext dbContext = context.GetService<DataContext>();
                return new Repository<TEntity>(dbContext);
            };
        }

        private static Func<IServiceProvider, RepositoryAsync<TEntity>> InitializeRepositoryAsync<TEntity>() where TEntity : class
        {
            return context =>
            {
                Uri WebUrl = new Uri("https://jsonplaceholder.typicode.com/");
                return new RepositoryAsync<TEntity>(WebUrl);
            };
        }
    }
}
