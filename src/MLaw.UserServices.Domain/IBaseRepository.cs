using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MLaw.UserServices
{
    public interface IBaseRepository<TEntity, TDto> : ITransientDependency where TEntity : BaseEntities where TDto : BaseDTOs
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Get all entities with pagination
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(int skip, int take);
        /// <summary>
        /// Get all entities with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);
        /// <summary>
        /// Get all entities with predicate and pagination
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate, int skip, int take);
        /// <summary>
        /// Get all async entities
        /// </summary>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// Get all async entities with pagination
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetAllAsync(int skip, int take);
        /// <summary>
        /// Get all async entities with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> predicate);
        /// <summary>
        /// Get all async entities with predicate and pagination
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> predicate, int skip, int take);
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(Guid id);
        /// <summary>
        /// Get list of entities by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetById(List<Guid> id);
        /// <summary>
        /// Get entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> GetByIdAsync(Guid id);
        /// <summary>
        /// Get list of entities by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetListByKey(string key, string value);
        /// <summary>
        /// Get list of entities by key async
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TEntity>> GetListByKeyAsync(string key, string value);
        /// <summary>
        /// Insert entity with dto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TEntity Insert(TDto dto);
        /// <summary>
        /// Insert list of entities
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(List<TEntity> entity);
        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Insert(TEntity entity);
        /// <summary>
        /// insert entity with dto async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TEntity> InsertAsync(TDto dto);
        /// <summary>
        /// Insert list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> InsertAsync(List<TEntity> entity);
        /// <summary>
        /// Insert list of entities with dto async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> InsertAsync(List<TDto> entity);
        /// <summary>
        /// Insert entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TEntity> InsertAsync(TEntity entity);
        /// <summary>
        /// Update entity with dto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TEntity Update(TDto dto);
        /// <summary>
        /// Update list of entities
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);
        /// <summary>
        /// Update list of entities
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(List<TEntity> entity);
        /// <summary>
        /// Update entity with dto async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TEntity> UpdateAsync(TDto entity);
        /// <summary>
        /// Update list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> UpdateAsync(List<TEntity> entity);
        /// <summary>
        /// Update list of entities with dto async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> UpdateAsync(List<TDto> entity);
        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(Guid id);
        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(TEntity entity);
        /// <summary>
        /// Delete list of entities by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(List<Guid> id);
        /// <summary>
        /// Delete list of entities
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(List<TEntity> entity);
        /// <summary>
        /// Delete entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<int> DeleteAsync(Guid id);
        /// <summary>
        /// Delete entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> DeleteAsync(TEntity entity);
        /// <summary>
        /// Delete list of entities by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<int> DeleteAsync(List<Guid> id);
        /// <summary>
        /// Delete list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> DeleteAsync(List<TEntity> entity);
        /// <summary>
        /// Disabled entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Disabled(Guid id);
        /// <summary>
        /// Disabled entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Disabled(TEntity entity);
        /// <summary>
        /// Disabled list of entities by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Disabled(List<Guid> id);
        /// <summary>
        /// Disabled list of entities
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Disabled(List<TEntity> entity);
        /// <summary>
        /// Disabled entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> DisabledAsync(Guid id);
        /// <summary>
        /// Disabled entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TEntity> DisabledAsync(TEntity entity);
        /// <summary>
        /// Disabled async by list id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<int> DisabledAsync(List<Guid> id);
        /// <summary>
        /// Disabled list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> DisabledAsync(List<TEntity> entity);
        /// <summary>
        /// Enabled entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Enabled(Guid id);
        /// <summary>
        /// Enabled entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Enabled(TEntity entity);
        /// <summary>
        /// Enabled list of entities by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Enabled(List<Guid> id);
        /// <summary>
        /// Enabled list of entities
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Enabled(List<TEntity> entity);
        /// <summary>
        /// Enabled entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> EnabledAsync(Guid id);
        /// <summary>
        /// Enabled entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TEntity> EnabledAsync(TEntity entity);
        /// <summary>
        /// Enabled list of entities by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<int> EnabledAsync(List<Guid> id);
        /// <summary>
        /// Enabled list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> EnabledAsync(List<TEntity> entity);
    }
}
