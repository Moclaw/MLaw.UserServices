using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MLaw.UserServices.Application.Contracts
{
    public interface IBaseServices<TRequest, TResponse> : IApplicationService where TRequest : class where TResponse : class
    { /// <summary>
      /// Get all async entities
      /// </summary>
      /// <returns></returns>
        ValueTask<IEnumerable<TResponse>> GetAll();
        /// <summary>
        /// Get all async entities with pagination
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TResponse>> GetAll(int skip, int take);
        /// <summary>
        /// Get all async entities with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TResponse>> GetAll(Func<TRequest, bool> predicate);
        /// <summary>
        /// Get all async entities with predicate and pagination
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TResponse>> GetAll(Func<TRequest, bool> predicate, int skip, int take);
        /// <summary>
        /// Get entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TResponse> GetById(Guid id);
        /// <summary>
        /// Get list of entities by key async
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<TResponse>> GetListByKey(string key, string value);
        /// <summary>
        /// Insert list of entities with dto async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Add(IEnumerable<TRequest> entity);
        /// <summary>
        /// Insert entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TResponse> Add(TRequest entity);
        /// <summary>
        /// Update entity with dto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ValueTask<TResponse> Update(TRequest entity);
        /// <summary>
        /// Update list of entities async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<int> Update(IEnumerable<TRequest> entity);
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
        ValueTask<int> Delete(TRequest entity);
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
        ValueTask<int> Delete(IEnumerable<TRequest> entity);
        /// <summary>
        /// Disabled entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TResponse> Disabled(Guid id);
        /// <summary>
        /// Disabled entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TResponse> Disabled(TRequest entity);
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
        ValueTask<int> Disabled(IEnumerable<TRequest> entity);
        ValueTask<TResponse> Enabled(Guid id);
        /// <summary>
        /// Enabled entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValueTask<TResponse> Enabled(TRequest entity);
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
        ValueTask<int> Enabled(IEnumerable<TRequest> entity);

    }
}
