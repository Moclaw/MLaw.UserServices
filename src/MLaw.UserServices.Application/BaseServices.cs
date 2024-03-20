using Microsoft.Extensions.Logging;
using MLaw.UserServices.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLaw.UserServices
{
    public class BaseServices<TRequest, TResponse, TEntity, TDtos> : UserServicesAppService, IBaseServices<TRequest, TResponse> where TRequest : class where TResponse : class where TEntity : BaseEntities where TDtos : BaseDTO
    {
        private readonly IBaseRepository<TEntity, TDtos> _baseRepository;
        private readonly ILogger<BaseServices<TRequest, TResponse, TEntity, TDtos>> _logger;
        public BaseServices(IBaseRepository<TEntity, TDtos> baseRepository, ILogger<BaseServices<TRequest, TResponse, TEntity, TDtos>> logger)
        {
            _baseRepository = baseRepository;
            _logger = logger;
        }

        public async ValueTask<int> Add(IEnumerable<TRequest> entity)
        {
            try
            {
                var entities = ObjectMapper.Map<IEnumerable<TRequest>, IEnumerable<TEntity>>(entity);

                return await _baseRepository.Add(entities);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Add)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }

        public async ValueTask<TResponse> Add(TRequest entity)
        {
            try
            {
                var entities = ObjectMapper.Map<TRequest, TEntity>(entity);

                return ObjectMapper.Map<TEntity, TResponse>(await _baseRepository.Add(entities));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Add)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }

        public async ValueTask<int> Delete(Guid id)
        {
            try
            {
                return await _baseRepository.Delete(id);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Delete)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, id);

                throw;
            }
        }

        public async ValueTask<int> Delete(TRequest entity)
        {
            try
            {
                var entities = ObjectMapper.Map<TRequest, TEntity>(entity);

                return await _baseRepository.Delete(entities);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Delete)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }

        public async ValueTask<int> Delete(IEnumerable<Guid> id)
        {
            try
            {
                return await _baseRepository.Delete(id);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Delete)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, id);

                throw;
            }

        }

        public async ValueTask<int> Delete(IEnumerable<TRequest> entity)
        {
            try
            {
                var entities = ObjectMapper.Map<IEnumerable<TRequest>, IEnumerable<TEntity>>(entity);

                return await _baseRepository.Delete(entities);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Delete)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }

        }

        public async ValueTask<TResponse> Disabled(Guid id)
        {
            try
            {
                return ObjectMapper.Map<TEntity, TResponse>(await _baseRepository.Disabled(id));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Disabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, id);

                throw;
            }
        }

        public async ValueTask<TResponse> Disabled(TRequest entity)
        {
            try
            {
                var entities = ObjectMapper.Map<TRequest, TEntity>(entity);

                return ObjectMapper.Map<TEntity, TResponse>(await _baseRepository.Disabled(entities));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Disabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }

        public async ValueTask<int> Disabled(IEnumerable<Guid> id)
        {
            try
            {
                return await _baseRepository.Disabled(id);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Disabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, id);

                throw;
            }
        }

        public async ValueTask<int> Disabled(IEnumerable<TRequest> entity)
        {
            try
            {
                var entities = ObjectMapper.Map<IEnumerable<TRequest>, IEnumerable<TEntity>>(entity);

                return await _baseRepository.Disabled(entities);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Disabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }

        public async ValueTask<TResponse> Enabled(Guid id)
        {
            try
            {
                return ObjectMapper.Map<TEntity, TResponse>(await _baseRepository.Enabled(id));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Enabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, id);

                throw;
            }
        }

        public async ValueTask<TResponse> Enabled(TRequest entity)
        {
            try
            {
                var entities = ObjectMapper.Map<TRequest, TEntity>(entity);

                return ObjectMapper.Map<TEntity, TResponse>(await _baseRepository.Enabled(entities));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Enabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }

        public async ValueTask<int> Enabled(IEnumerable<Guid> id)
        {
            try
            {
                return await _baseRepository.Enabled(id);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Enabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, id);

                throw;
            }
        }

        public async ValueTask<int> Enabled(IEnumerable<TRequest> entity)
        {
            try
            {
                var entities = ObjectMapper.Map<IEnumerable<TRequest>, IEnumerable<TEntity>>(entity);

                return await _baseRepository.Enabled(entities);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Enabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }

        public async ValueTask<IEnumerable<TResponse>> GetAll()
        {
            try
            {
                return ObjectMapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(await _baseRepository.GetAll());
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(GetAll)}-Exception: " + "{Entity}";

                _logger.LogError(e, message);

                throw;
            }
        }

        public async ValueTask<IEnumerable<TResponse>> GetAll(int skip, int take)
        {
            try
            {
                return ObjectMapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(await _baseRepository.GetAll(skip, take));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(GetAll)}-Exception: " + "{Entity}";

                _logger.LogError(e, message);

                throw;
            }
        }

        public async ValueTask<IEnumerable<TResponse>> GetAll(Func<TRequest, bool> predicate)
        {
            try
            {
                var entities = ObjectMapper.Map<Func<TRequest, bool>, Func<TEntity, bool>>(predicate);

                return ObjectMapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(await _baseRepository.GetAll(entities));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(GetAll)}-Exception: " + "{Entity}";

                _logger.LogError(e, message);

                throw;
            }
        }

        public async ValueTask<IEnumerable<TResponse>> GetAll(Func<TRequest, bool> predicate, int skip, int take)
        {
            try
            {
                var entities = ObjectMapper.Map<Func<TRequest, bool>, Func<TEntity, bool>>(predicate);

                return ObjectMapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(await _baseRepository.GetAll(entities, skip, take));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(GetAll)}-Exception: " + "{Entity}";

                _logger.LogError(e, message);

                throw;
            }
        }

        public async ValueTask<TResponse> GetById(Guid id)
        {
            try
            {
                return ObjectMapper.Map<TEntity, TResponse>(await _baseRepository.GetById(id));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(GetById)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, id);

                throw;
            }
        }

        public async ValueTask<IEnumerable<TResponse>> GetListByKey(string key, string value)
        {
            try
            {
                return ObjectMapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(await _baseRepository.GetListByKey(key, value));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(GetListByKey)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, key, value);

                throw;
            }
        }

        public async ValueTask<TResponse> Update(TRequest entity)
        {
            try
            {
                var dto = ObjectMapper.Map<TRequest, TDtos>(entity);

                return ObjectMapper.Map<TEntity, TResponse>(await _baseRepository.Update(dto));
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Update)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }

        public async ValueTask<int> Update(IEnumerable<TRequest> entity)
        {
            try
            {
                var entities = ObjectMapper.Map<IEnumerable<TRequest>, IEnumerable<TEntity>>(entity);

                return await _baseRepository.Update(entities);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseServices<TRequest, TResponse, TEntity, TDtos>)}-{nameof(Update)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity);

                throw;
            }
        }
    }
}
