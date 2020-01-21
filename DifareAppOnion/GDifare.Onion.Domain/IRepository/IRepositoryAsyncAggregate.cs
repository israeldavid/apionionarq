using OnionPattern.Domain.Entities.Banner;
using OnionPattern.Domain.Entities.JsonPlaceHolder;

namespace OnionPattern.Domain.Repository
{
    public interface IRepositoryAsyncAggregate
    {
        IRepositoryAsync<UserEntity> Users { get; }
    }
}