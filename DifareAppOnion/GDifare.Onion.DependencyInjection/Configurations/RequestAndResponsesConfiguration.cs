using Microsoft.Extensions.DependencyInjection;
using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.JsonPlaceHolder;
using OnionPattern.Domain.Entities.Menu;
using OnionPattern.Domain.Entities.Popup;
using OnionPattern.Domain.Entities.Tab;
using OnionPattern.Domain.Entities.Tema;
using OnionPattern.Domain.IServices.RequestAggregate;
using OnionPattern.Domain.IServices.RequestAggregate.Async;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.RequestAgregate;
using OnionPattern.Service.RequestAgregate.Async;
using System;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class RequestAndResponsesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigureBannerRequestAggregates(services);
            ConfigureMenuRequestAggregates(services);
            ConfigurePopupRequestAggregates(services);
            ConfigureTabRequestAggregates(services);
            ConfigureTemaRequestAggregates(services);
            ConfigureUserRequestAggregates(services);
        }

        private static void ConfigureBannerRequestAggregates(IServiceCollection services)
        {
            services.AddTransient<IBannerRequestAggregate>(context =>
            {
                var (repository, repositoryAggregate) = GetRequestDependencies<BannerEntity>(context);
                return new BannerRequestAggregate(repository, repositoryAggregate);
            });
        }

        private static void ConfigureMenuRequestAggregates(IServiceCollection services)
        {
            services.AddTransient<IMenuRequestAggregate>(context =>
            {
                var (repository, repositoryAggregate) = GetRequestDependencies<MenuEntity>(context);
                return new MenuRequestAggregate(repository, repositoryAggregate);
            });
        }
        private static void ConfigurePopupRequestAggregates(IServiceCollection services)
        {
            services.AddTransient<IPopupRequestAggregate>(context =>
            {
                var (repository, repositoryAggregate) = GetRequestDependencies<PopupEntity>(context);
                return new PopupRequestAggregate(repository, repositoryAggregate);
            });
        }
        private static void ConfigureTabRequestAggregates(IServiceCollection services)
        {
            services.AddTransient<ITabRequestAggregate>(context =>
            {
                var (repository, repositoryAggregate) = GetRequestDependencies<TabEntity>(context);
                return new TabRequestAggregate(repository, repositoryAggregate);
            });
        }
        private static void ConfigureTemaRequestAggregates(IServiceCollection services)
        {
            services.AddTransient<ITemaRequestAggregate>(context =>
            {
                var (repository, repositoryAggregate) = GetRequestDependencies<TemaEntity>(context);
                return new TemaRequestAggregate(repository, repositoryAggregate);
            });
        }

        private static void ConfigureUserRequestAggregates(IServiceCollection services)
        {
            services.AddTransient<IUserRequestAggregateAsync>(context =>
            {
                var (repositoryAsync, repositoryAsyncAggregate) = GetRequestAsyncDependencies<UserEntity>(context);
                return new UserRequestAggregateAsync(repositoryAsync, repositoryAsyncAggregate);
            });
        }


        #region Get Dependency Methods

        private static (IRepository<TEntity> Repository, IRepositoryAggregate RepositoryAggregate) GetRequestDependencies<TEntity>(IServiceProvider context) where TEntity : class
        {
            var repository = context.GetService<IRepository<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAggregate>();

            return (repository, repositoryAggregate);
        }

        private static (IRepositoryAsync<TEntity> Repository, IRepositoryAsyncAggregate RepositoryAggregate) GetRequestAsyncDependencies<TEntity>(IServiceProvider context) where TEntity : class
        {
            var repository = context.GetService<IRepositoryAsync<TEntity>>();
            var repositoryAggregate = context.GetService<IRepositoryAsyncAggregate>();

            return (repository, repositoryAggregate);
        }

        #endregion Get Dependency Methods
    }
}
