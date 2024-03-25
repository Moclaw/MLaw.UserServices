using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MLaw.UserServices
{
    public interface IBaseRepository<TEntity, TDto> : ITransientDependency where TEntity : BaseEntities where TDto : BaseDTO
    {
        /// <summary>
        /// Get all async entities
        /// </summary>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetAll();
        /// <summary>
        /// Get all async entities with pagination
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetAll(int skip, int take);
        /// <summary>
        /// Get all async entities with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> predicate);
        /// <summary>
        /// Get all async entities with predicate and pagination
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> predicate, int skip, int take);
        /// <summary>
        /// Get entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> GetById(Guid id);

        /// <summary>
        /// Get entity by key async
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>

        ValueTask<TEntity> GetByKey(string key, string value);

        /// <summary>
        /// Get list of entities by key async
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetListByKey(string key, string value);
        /// <summary>
        /// Insert entity with dto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ValueTask<TEntity> Add(TDto dto);
        /// <summary>
        /// Insert list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Add(IEnumerable<TEntity> entity);
        /// <summary>
        /// Insert list of entities with dto async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Add(IEnumerable<TDto> entity);
        /// <summary>
        /// Insert entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TEntity> Add(TEntity entity);
        /// <summary>
        /// Update entity with dto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ValueTask<TEntity> Update(TDto entity);
        /// <summary>
        /// Update list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Update(IEnumerable<TEntity> entity);
        /// <summary>
        /// Update list of entities with dto async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Update(IEnumerable<TDto> entity);
        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<int> Delete(Guid id);
        /// <summary>
        /// Delete entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Delete(TEntity entity);
        /// <summary>
        /// Delete list of entities by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<int> Delete(IEnumerable<Guid> id);
        /// <summary>
        /// Delete list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Delete(IEnumerable<TEntity> entity);
        /// <summary>
        /// Disabled entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> Disabled(Guid id);
        /// <summary>
        /// Disabled entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TEntity> Disabled(TEntity entity);
        /// <summary>
        /// Disabled async by list id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<int> Disabled(IEnumerable<Guid> id);
        /// <summary>
        /// Disabled list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Disabled(IEnumerable<TEntity> entity);
        ValueTask<TEntity> Enabled(Guid id);
        /// <summary>
        /// Enabled entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TEntity> Enabled(TEntity entity);
        /// <summary>
        /// Enabled list of entities by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<int> Enabled(IEnumerable<Guid> id);
        /// <summary>
        /// Enabled list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Enabled(IEnumerable<TEntity> entity);
    }
}
