using GIIS.KafkaServices.EntityFrameworkCore.DbContext;
using GIIS.KafkaServices.EntityFrameworkCore.DbContext.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace MLaw.UserServices
{
    public class BaseRepository<TEntity, TDto> : IBaseRepository<TEntity, TDto> where TEntity : BaseEntities where TDto : BaseDTOs
    {
        private readonly IUserServicesDbContext _context;
        private readonly ILogger<BaseRepository<TEntity, TDto>> _logger;
        public BaseRepository(IUserServicesDbContext context, ILogger<BaseRepository<TEntity, TDto>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int Delete(Guid id)
        {
            try
            {
                var entity = _context.Set<TEntity>().Find(id);
                if (entity != null)
                {
                    _context.Set<TEntity>().Remove(entity);
                    return _context.SaveChanges();
                }
                return 0;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Delete)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public int Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Delete)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public int Delete(List<Guid> id)
        {
            try
            {
                var entity = _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .Where(x => id.Contains(x.Id)).ToList();
                if (entity != null)
                {
                    _context.Set<TEntity>().RemoveRange(entity);
                    return _context.SaveChanges();
                }
                return 0;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Delete)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public int Delete(List<TEntity> entity)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(entity);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Delete)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<int> DeleteAsync(Guid id)
        {
            try
            {
                var entity = _context.Set<TEntity>().FindAsync(id);
                if (entity.IsCompleted && entity.Result != null)
                {
                    _context.Set<TEntity>().Remove(entity.Result);
                    return await _context.SaveChangesAsync();
                }
                return default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(DeleteAsync)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public async ValueTask<int> DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(DeleteAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<int> DeleteAsync(List<Guid> id)
        {
            try
            {
                var entity = _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .Where(x => id.Contains(x.Id)).ToList();
                if (entity != null)
                {
                    _context.Set<TEntity>().RemoveRange(entity);
                    return await _context.SaveChangesAsync();
                }
                return default;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(DeleteAsync)} - Error");
                throw;
            }
        }

        public async ValueTask<int> DeleteAsync(List<TEntity> entity)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(DeleteAsync)} - Error");
                throw;
            }
        }

        public TEntity Disabled(Guid id)
        {
            try
            {
                var entity = _context.Set<TEntity>().Find(id);
                if (entity != null)
                {
                    entity.IsDeleted = true;
                    _context.Set<TEntity>().Update(entity);
                    _context.SaveChanges();
                    return entity;
                }
                return null;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Disabled)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public TEntity Disabled(TEntity entity)
        {
            try
            {
                entity.IsDeleted = true;
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Disabled)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public int Disabled(List<Guid> id)
        {
            try
            {
                var entity = _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .Where(x => id.Contains(x.Id)).ToList();
                if (entity != null)
                {
                    entity.ForEach(x => x.IsDeleted = true);
                    _context.Set<TEntity>().UpdateRange(entity);
                    return _context.SaveChanges();
                }
                return 0;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Disabled)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public int Disabled(List<TEntity> entity)
        {
            try
            {
                entity.ForEach(x => x.IsDeleted = true);
                _context.Set<TEntity>().UpdateRange(entity);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Disabled)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<TEntity> DisabledAsync(Guid id)
        {
            try
            {
                var entity = _context.Set<TEntity>().FindAsync(id);
                if (entity.IsCompleted && entity.Result != null)
                {
                    entity.Result.IsDeleted = true;
                    var result = _context.Set<TEntity>().Update(entity.Result);
                    return await _context.SaveChangesAsync() > 0 ? result.Entity : default;
                }
                return default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(DisabledAsync)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public async ValueTask<TEntity> DisabledAsync(TEntity entity)
        {
            try
            {
                entity.IsDeleted = true;
                var result = _context.Set<TEntity>().Update(entity);
                return await _context.SaveChangesAsync() > 0 ? result.Entity : default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(DisabledAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<int> DisabledAsync(List<Guid> id)
        {
            try
            {
                var entity = _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .Where(x => id.Contains(x.Id)).ToList();
                if (entity != null)
                {
                    entity.ForEach(x => x.IsDeleted = true);
                    _context.Set<TEntity>().UpdateRange(entity);
                    return await _context.SaveChangesAsync();
                }
                return default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(DisabledAsync)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public async ValueTask<int> DisabledAsync(List<TEntity> entity)
        {
            try
            {
                entity.ForEach(x => x.IsDeleted = true);
                _context.Set<TEntity>().UpdateRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(DisabledAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public TEntity Enabled(Guid id)
        {
            try
            {
                var entity = _context.Set<TEntity>().Find(id);
                if (entity != null)
                {
                    entity.IsDeleted = false;
                    _context.Set<TEntity>().Update(entity);
                    _context.SaveChanges();
                    return entity;
                }
                return null;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Enabled)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public TEntity Enabled(TEntity entity)
        {
            try
            {
                entity.IsDeleted = false;
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Enabled)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public int Enabled(List<Guid> id)
        {
            try
            {
                var entity = _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .Where(x => id.Contains(x.Id)).ToList();
                if (entity != null)
                {
                    entity.ForEach(x => x.IsDeleted = false);
                    _context.Set<TEntity>().UpdateRange(entity);
                    return _context.SaveChanges();
                }
                return 0;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Enabled)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public int Enabled(List<TEntity> entity)
        {
            try
            {
                entity.ForEach(x => x.IsDeleted = false);
                _context.Set<TEntity>().UpdateRange(entity);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Enabled)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<TEntity> EnabledAsync(Guid id)
        {
            try
            {
                var entity = _context.Set<TEntity>().FindAsync(id);
                if (entity.IsCompleted && entity.Result != null)
                {
                    entity.Result.IsDeleted = false;
                    var result = _context.Set<TEntity>().Update(entity.Result);
                    return await _context.SaveChangesAsync() > 0 ? result.Entity : default;
                }
                return default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(EnabledAsync)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public async ValueTask<TEntity> EnabledAsync(TEntity entity)
        {
            try
            {
                entity.IsDeleted = false;
                var result = _context.Set<TEntity>().Update(entity);
                return await _context.SaveChangesAsync() > 0 ? result.Entity : default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(EnabledAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<int> EnabledAsync(List<Guid> id)
        {
            try
            {
                var entity = _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .Where(x => id.Contains(x.Id)).ToList();
                if (entity != null)
                {
                    entity.ForEach(x => x.IsDeleted = false);
                    _context.Set<TEntity>().UpdateRange(entity);
                    return await _context.SaveChangesAsync();
                }
                return default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(EnabledAsync)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public async ValueTask<int> EnabledAsync(List<TEntity> entity)
        {
            try
            {
                entity.ForEach(x => x.IsDeleted = false);
                _context.Set<TEntity>().UpdateRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(EnabledAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>()
                               .AsNoTracking()
                               .ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetAll)} - Error");
                throw;
            }
        }

        public IEnumerable<TEntity> GetAll(int skip, int take)
        {
            try
            {
                return _context.Set<TEntity>()
                               .AsNoTracking()
                               .Skip(skip)
                               .Take(take)
                               .ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetAll)} - Error");
                throw;
            }
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            try
            {
                return _context.Set<TEntity>()
                               .AsNoTracking()
                               .Where(predicate).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetAll)} - Error");
                throw;
            }
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate, int skip, int take)
        {
            try
            {
                return _context.Set<TEntity>()
                               .AsNoTracking()
                               .Where(predicate)
                               .Skip(skip)
                               .Take(take)
                               .ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetAll)} - Error");
                throw;
            }
        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetAllAsync)} - Error");
                throw;
            }
        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync(int skip, int take)
        {
            try
            {
                return await _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .Skip(skip)
                                     .Take(take)
                                     .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetAllAsync)} - Error");
                throw;
            }
        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await ValueTask.FromResult(_context.Set<TEntity>().AsNoTracking().Where(predicate).ToList());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetAllAsync)} - Error");
                throw;
            }

        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> predicate, int skip, int take)
        {
            try
            {
                return await ValueTask.FromResult(_context.Set<TEntity>()
                                                          .AsNoTracking()
                                                          .Where(predicate)
                                                          .Skip(skip)
                                                          .Take(take)
                                                          .ToList());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetAllAsync)} - Error");
                throw;
            }
        }

        public TEntity GetById(Guid id)
        {
            try
            {
                return _context.Set<TEntity>()
                               .AsNoTracking()
                               .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetById)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public IEnumerable<TEntity> GetById(List<Guid> id)
        {
            try
            {
                return _context.Set<TEntity>()
                               .AsNoTracking()
                               .Where(x => id.Contains(x.Id))
                               .ToList();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetById)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public async ValueTask<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetByIdAsync)}" + " - Error: {Id}";
                _logger.LogError(e, message, id);
                throw;
            }
        }

        public IEnumerable<TEntity> GetListByKey(string key, string value)
        {
            try
            {
                return _context.Set<TEntity>()
                               .AsNoTracking()
                               .Where(x => EF.Property<string>(x, key) == value)
                               .ToList();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetListByKey)}" + " - Error: {Key} - {Value}";
                _logger.LogError(e, message, key, value);
                throw;
            }
        }

        public async ValueTask<IEnumerable<TEntity>> GetListByKeyAsync(string key, string value)
        {
            try
            {
                return await ValueTask.FromResult(_context.Set<TEntity>()
                                                          .AsNoTracking()
                                                          .Where(x => EF.Property<string>(x, key) == value)
                                                          .ToList());
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(GetListByKeyAsync)}" + " - Error: {Key} - {Value}";
                _logger.LogError(e, message, key, value);
                throw;
            }
        }

        public TEntity Insert(TDto dto)
        {
            try
            {
                var entity = _context.Find<TEntity>(dto.Id);

                var entityType = entity.GetType();
                var dtoType = dto.GetType();

                var properties = entityType.GetProperties();
                foreach (var property in properties)
                {
                    var dtoProperty = dtoType.GetProperty(property.Name);
                    if (dtoProperty != null && dtoProperty.CanWrite && property.CanRead)
                    {
                        property.SetValue(entity, dtoProperty.GetValue(dto));
                    }
                }
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Insert)}" + " - Error: {Dto}";
                _logger.LogError(e, message, dto);
                throw;
            }
        }

        public int Insert(List<TEntity> entity)
        {
            try
            {
                _context.Set<TEntity>().AddRange(entity);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Insert)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public TEntity Insert(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Insert)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<TEntity> InsertAsync(TDto dto)
        {
            try
            {
                var entity = _context.Find<TEntity>(dto.Id);

                var entityType = entity.GetType();
                var dtoType = dto.GetType();

                var properties = entityType.GetProperties();
                foreach (var property in properties)
                {
                    var dtoProperty = dtoType.GetProperty(property.Name);
                    if (dtoProperty != null && dtoProperty.CanWrite && property.CanRead)
                    {
                        property.SetValue(entity, dtoProperty.GetValue(dto));
                    }
                }
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(InsertAsync)}" + " - Error: {Dto}";
                _logger.LogError(e, message, dto);
                throw;
            }
        }

        public async ValueTask<int> InsertAsync(List<TEntity> entity)
        {
            try
            {
                _context.Set<TEntity>().AddRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(InsertAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<int> InsertAsync(List<TDto> entities)
        {
            try
            {
                var entity = _context.Find<TEntity>(entities.FirstOrDefault().Id);

                var entityType = entity.GetType();
                var dtoType = entities.FirstOrDefault().GetType();

                var properties = entityType.GetProperties();
                foreach (var property in properties)
                {
                    var dtoProperty = dtoType.GetProperty(property.Name);
                    if (dtoProperty != null && dtoProperty.CanWrite && property.CanRead)
                    {
                        property.SetValue(entity, dtoProperty.GetValue(entities.FirstOrDefault()));
                    }
                }
                _context.Set<TEntity>().Update(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(InsertAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entities);
                throw;
            }
          
        }

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(InsertAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public TEntity Update(TDto dto)
        {
            try
            {
                var entity = _context.Find<TEntity>(dto.Id);

                var entityType = entity.GetType();
                var dtoType = dto.GetType();

                var properties = entityType.GetProperties();
                foreach (var property in properties)
                {
                    var dtoProperty = dtoType.GetProperty(property.Name);
                    if (dtoProperty != null && dtoProperty.CanWrite && property.CanRead && property.Name != nameof(BaseEntities.Id))
                    {
                        property.SetValue(entity, dtoProperty.GetValue(dto));
                    }
                }
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Update)}" + " - Error: {Dto}";
                _logger.LogError(e, message, dto);
                throw;
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Update)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public int Update(List<TEntity> entity)
        {
            try
            {
                _context.Set<TEntity>().UpdateRange(entity);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(Update)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<TEntity> UpdateAsync(TDto dto)
        {
            try
            {
                var entity = _context.Find<TEntity>(dto.Id);

                var entityType = entity.GetType();
                var dtoType = entity.GetType();

                var properties = entityType.GetProperties();
                foreach (var property in properties)
                {
                    var dtoProperty = dtoType.GetProperty(property.Name);
                    if (dtoProperty != null && dtoProperty.CanWrite && property.CanRead && property.Name != nameof(BaseEntities.Id))
                    {
                        property.SetValue(entity, dtoProperty.GetValue(entity));
                    }
                }
                _context.Set<TEntity>().Update(entity);
                return await _context.SaveChangesAsync() > 0 ? entity : default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(UpdateAsync)}" + " - Error: {Dto}";
                _logger.LogError(e, message, dto);
                throw;
            }
        }

        public async ValueTask<int> UpdateAsync(List<TEntity> entity)
        {
            try
            {
                _context.Set<TEntity>().UpdateRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(UpdateAsync)}" + " - Error: {Entity}";
                _logger.LogError(e, message, entity);
                throw;
            }
        }

        public async ValueTask<int> UpdateAsync(List<TDto> dtos)
        {
            try
            {
                foreach (var dto in dtos)
                {
                    var entity = _context.Find<TEntity>(dto.Id);

                    var entityType = entity.GetType();
                    var dtoType = dto.GetType();

                    var properties = entityType.GetProperties();
                    foreach (var property in properties)
                    {
                        var dtoProperty = dtoType.GetProperty(property.Name);
                        if (dtoProperty != null && dtoProperty.CanWrite && property.CanRead && property.Name != nameof(BaseEntities.Id))
                        {
                            property.SetValue(entity, dtoProperty.GetValue(dto));
                        }
                    }
                    _context.Set<TEntity>().Update(entity);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)} - {nameof(UpdateAsync)}" + " - Error: {Dto}";
                _logger.LogError(e, message, dtos);
                throw;
            }
        }
    }
}
