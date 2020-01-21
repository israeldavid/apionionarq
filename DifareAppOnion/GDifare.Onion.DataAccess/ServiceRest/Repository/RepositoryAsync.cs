using OnionPattern.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain;
using System.Net.Http;
using Newtonsoft.Json;
using OnionPattern.Domain.Entities.JsonPlaceHolder;

namespace OnionPattern.DataAccess.EF.Repository
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        //private readonly DbContext context;
        //private readonly DbSet<TEntity> dataSet;
        private IDataServiceAsync _dataServiceAsync;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="WebUrl"></param>
        public RepositoryAsync(Uri WebUrl)
        {
            //this.context = context ?? throw new ArgumentNullException(nameof(context));
            //dataSet = context.Set<TEntity>();

            _dataServiceAsync = new DataServiceAsync(WebUrl);
        }

        #region Implementation of IRepositoryAsync<TEntity>

        public async Task<IEnumerable<TEntity>> GetAllAsync(string requesturl)
        {
            IEnumerable<TEntity> data = new List<TEntity>();
            try
            {
                var requestUrl = _dataServiceAsync.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
           requesturl));
                data = await _dataServiceAsync.GetAsync<IEnumerable<TEntity>>(requestUrl);
                //dataSet.AsNoTracking();
                //var data = await Task.FromResult(dataSet.Where(f => true));

            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting records: {ex.Message}", ex);
            }
            return data;
        }



        //public async Task<TEntity> CreateAsync(TEntity entity)
        //{
        //    var createdEntity = await dataSet.AddAsync(entity);
        //    await SaveChangesAsync();
        //    return createdEntity.Entity;
        //}

        //public async Task<TEntity> UpdateAsync(TEntity entity)
        //{
        //    if (!dataSet.Local.Contains(entity)) { dataSet.Attach(entity); }
        //    context.Entry(entity).State = EntityState.Modified;
        //    await SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<TEntity> DeleteAsync(TEntity entity)
        //{
        //    var deleteEntity = dataSet.Remove(entity);
        //    await SaveChangesAsync();
        //    return deleteEntity.Entity;
        //}

        #endregion

        //private async Task<int> SaveChangesAsync()
        //{
        //    try
        //    {
        //        return await context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        throw new Exception($"Concurrency Error: {ex.Message}", ex);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        throw new Exception($"Database Update Error: {ex.Message}", ex);
        //    }
        //    catch (DbException ex)
        //    {
        //        throw new Exception($"Entity Validation Errors: {ex.Message}", ex);
        //    }
        //}
    }
}
