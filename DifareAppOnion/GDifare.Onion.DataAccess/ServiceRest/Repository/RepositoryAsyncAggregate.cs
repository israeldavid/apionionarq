using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.JsonPlaceHolder;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.DataAccess.EF.Repository
{
    public class RepositoryAsyncAggregate : IRepositoryAsyncAggregate
    {
        private readonly DbContext dbContext;

        public RepositoryAsyncAggregate(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IRepositoryAsync<UserEntity> Users => throw new NotImplementedException();

        //private IRepositoryAsync<BannerEntity> banners;
        //public IRepositoryAsync<BannerEntity> Banners => banners ?? (banners = new RepositoryAsync<BannerEntity>(dbContext));


    }
}
