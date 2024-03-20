using GIIS.KafkaServices.EntityFrameworkCore.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Core;

namespace MLaw.UserServices
{
    public class BaseRepository<TEntity, TDto> : IBaseRepository<TEntity, TDto> where TEntity : BaseEntities where TDto : BaseDTO
    {
        private readonly IUserServicesDbContext _context;
        private readonly ILogger<BaseRepository<TEntity, TDto>> _logger;
        public BaseRepository(IUserServicesDbContext context, ILogger<BaseRepository<TEntity, TDto>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async ValueTask<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(GetAll)}-Exception";

                _logger.LogError(e, message);

                throw;
            }
        }

        public async ValueTask<IEnumerable<TEntity>> GetAll(int skip, int take)
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
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(GetAll)}-Exception: " + "{Skip}-{Take}";

                _logger.LogError(e, message, skip, take);

                throw;
            }
        }

        public async ValueTask<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> predicate)
        {
            try
            {
                return await new ValueTask<IEnumerable<TEntity>>(_context.Set<TEntity>()
                                                                         .AsNoTracking()
                                                                         .Where(predicate)
                                                                         .ToList());

            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(GetAll)}-Exception: " + "{Predicate}";

                _logger.LogError(e, message, predicate.ToString());

                throw;
            }

        }

        public async ValueTask<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> predicate, int skip, int take)
        {
            try
            {
                return await new ValueTask<IEnumerable<TEntity>>(_context.Set<TEntity>()
                                                                          .AsNoTracking()
                                                                          .Where(predicate).Skip(skip)
                                                                          .Take(take)
                                                                          .ToList());
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(GetAll)}-Exception: " + "{Predicate}-{Skip}-{Take}";

                _logger.LogError(e, message, predicate.ToString(), skip, take);

                throw;
            }

        }

        public async ValueTask<TEntity> GetById(Guid id)
        {
            try
            {
                return await _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(GetById)}-Exception: " + "{Id}";

                _logger.LogError(e, message, id);

                throw;
            }


        }

        public async ValueTask<IEnumerable<TEntity>> GetListByKey(string key, string value)
        {
            try
            {
                return await _context.Set<TEntity>()
                                     .AsNoTracking()
                                     .Where(x => x.GetType().GetProperty(key).GetValue(x).ToString() == value)
                                     .ToListAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(GetListByKey)}-Exception: " + "{Key}-{Value}";

                _logger.LogError(e, message, key, value);

                throw;
            }

        }

        public async ValueTask<TEntity> Add(TDto dto)
        {
            try
            {
                var dtoType = dto.GetType();
                var entityType = typeof(TEntity);
                var entity = Activator.CreateInstance(entityType);

                foreach (var property in dtoType.GetProperties())
                {
                    var entityProperty = entityType.GetProperty(property.Name);

                    if (entityProperty != null)
                    {
                        entityProperty.SetValue(entity, property.GetValue(dto));
                    }
                }

                var item = (TEntity)entity;
                item.CreatedAt = DateTime.UtcNow;

                await _context.Set<TEntity>().AddAsync(item);
                return (TEntity)entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Add)}-Exception: " + "{Dto}";

                _logger.LogError(e, message, dto.Serialize());

                throw;
            }
        }



        public async ValueTask<int> Add(IEnumerable<TEntity> entity)
        {
            try
            {
                await _context.Set<TEntity>().AddRangeAsync(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Add)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }
        }

        public async ValueTask<int> Add(IEnumerable<TDto> entity)
        {
            try
            {
                var dtoType = typeof(TDto);
                var entityType = typeof(TEntity);
                var entities = new List<TEntity>();

                foreach (var dto in entity)
                {
                    var entityInstance = Activator.CreateInstance(entityType);

                    foreach (var property in dtoType.GetProperties())
                    {
                        var entityProperty = entityType.GetProperty(property.Name);

                        if (entityProperty != null)
                        {
                            entityProperty.SetValue(entityInstance, property.GetValue(dto));
                        }
                    }

                    var item = (TEntity)entityInstance;
                    item.CreatedAt = DateTime.UtcNow;

                    entities.Add(item);
                }

                await _context.Set<TEntity>().AddRangeAsync(entities);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Add)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }

        }

        public async ValueTask<TEntity> Add(TEntity entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                await _context.Set<TEntity>().AddAsync(entity);
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Add)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }
        }

        public async ValueTask<int> Delete(Guid id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                _context.Set<TEntity>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Delete)}-Exception: " + "{Id}";

                _logger.LogError(e, message, id);

                throw;
            }

        }

        public async ValueTask<int> Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Delete)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }
        }

        public async ValueTask<int> Delete(IEnumerable<Guid> id)
        {
            try
            {
                var entities = await _context.Set<TEntity>().Where(x => id.Contains(x.Id)).ToListAsync();
                _context.Set<TEntity>().RemoveRange(entities);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Delete)}-Exception: " + "{Id}";

                _logger.LogError(e, message, id.Serialize());

                throw;
            }

        }

        public async ValueTask<int> Delete(IEnumerable<TEntity> entity)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Delete)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }
        }

        public async ValueTask<TEntity> Disabled(Guid id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Disabled)}-Exception: " + "{Id}";

                _logger.LogError(e, message, id);

                throw;
            }

        }

        public async ValueTask<TEntity> Disabled(TEntity entity)
        {
            try
            {
                var entityCheck = await _context.Set<TEntity>().FindAsync(entity.Id);
                entityCheck.IsDeleted = true;
                await _context.SaveChangesAsync();
                return entityCheck;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Disabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }

        }

        public async ValueTask<int> Disabled(IEnumerable<Guid> id)
        {
            try
            {
                var entities = await _context.Set<TEntity>().Where(x => id.Contains(x.Id)).ToListAsync();
                entities.ForEach(x => { x.IsDeleted = true; x.UpdatedAt = DateTime.UtcNow; });
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Disabled)}-Exception: " + "{Id}";

                _logger.LogError(e, message, id.Serialize());

                throw;
            }

        }

        public async ValueTask<int> Disabled(IEnumerable<TEntity> entity)
        {
            try
            {
                entity.ToList().ForEach(x => { x.IsDeleted = true; x.UpdatedAt = DateTime.UtcNow; });
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Disabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }
        }

        public async ValueTask<TEntity> Enabled(Guid id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Enabled)}-Exception: " + "{Id}";

                _logger.LogError(e, message, id);

                throw;
            }
        }

        public async ValueTask<TEntity> Enabled(TEntity entity)
        {
            try
            {
                var entityCheck = await _context.Set<TEntity>().FindAsync(entity.Id);
                entityCheck.IsDeleted = false;
                entityCheck.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return entityCheck;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Enabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }
        }

        public async ValueTask<int> Enabled(IEnumerable<Guid> id)
        {
            try
            {
                var entities = await _context.Set<TEntity>().Where(x => id.Contains(x.Id)).ToListAsync();
                entities.ForEach(x => { x.IsDeleted = false; x.UpdatedAt = DateTime.UtcNow; });
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Enabled)}-Exception: " + "{Id}";

                _logger.LogError(e, message, id.Serialize());

                throw;
            }
        }

        public async ValueTask<int> Enabled(IEnumerable<TEntity> entity)
        {
            try
            {

                entity.ToList().ForEach(x => { x.IsDeleted = false; x.UpdatedAt = DateTime.UtcNow; });
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Enabled)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }

        }


        public async ValueTask<TEntity> Update(TDto dto)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(dto.Id);
                var entityType = entity.GetType();

                foreach (var property in dto.GetType().GetProperties().Where(x => x.GetValue(dto).IsNotNull()))
                {
                    var entityProperty = entityType.GetProperty(property.Name);

                    if (entityProperty.PropertyType.IsClass)
                    {
                        continue;
                    }

                    if (entityProperty.IsNotNull() && entityProperty.CanWrite && property.GetValue(dto).IsNotNull())
                    {
                        entityProperty.SetValue(entity, property.GetValue(dto));
                    }
                }

                entity.UpdatedAt = DateTime.UtcNow;

                var entry = _context.Set<TEntity>().Update(entity);

                return await _context.SaveChangesAsync() > 0 ? entry.Entity : default;
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Update)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, dto.Serialize());

                throw;
            }
        }

        public async ValueTask<int> Update(IEnumerable<TEntity> entity)
        {
            try
            {
                entity.ToList().ForEach(x => x.UpdatedAt = DateTime.UtcNow);
                _context.Set<TEntity>().UpdateRange(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Update)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }

        }

        public async ValueTask<int> Update(IEnumerable<TDto> entity)
        {
            try
            {
                var entityType = typeof(TEntity);
                var entities = new List<TEntity>();

                foreach (var dto in entity)
                {
                    var entityInstance = await _context.Set<TEntity>().FindAsync(dto.Id);

                    foreach (var property in dto.GetType().GetProperties().Where(x => x.GetValue(dto).IsNotNull()))
                    {
                        var entityProperty = entityType.GetProperty(property.Name);

                        if (entityProperty.PropertyType.IsClass)
                        {
                            continue;
                        }

                        if (entityProperty.IsNotNull() && entityProperty.CanWrite && property.GetValue(dto).IsNotNull())
                        {
                            entityProperty.SetValue(entityInstance, property.GetValue(dto));
                        }
                    }

                    entityInstance.UpdatedAt = DateTime.UtcNow;

                    entities.Add(entityInstance);
                }

                _context.Set<TEntity>().UpdateRange(entities);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = $"{nameof(BaseRepository<TEntity, TDto>)}-{nameof(Update)}-Exception: " + "{Entity}";

                _logger.LogError(e, message, entity.Serialize());

                throw;
            }

        }
    }
}
