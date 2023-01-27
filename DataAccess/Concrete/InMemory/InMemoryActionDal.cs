using Core.Entities.Concrete;
using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryActionDal : IInMemoryActionDal
    {
        public async void Add(Entities.Concrete.Action entity)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async void Update(Entities.Concrete.Action entity)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
        public async void Delete(Entities.Concrete.Action entity)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<Entities.Concrete.Action> Get(Expression<Func<Entities.Concrete.Action, bool>> filter)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                return await context.Set<Entities.Concrete.Action>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<Entities.Concrete.Action>> GetAll(Expression<Func<Entities.Concrete.Action, bool>> filter = null)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                return filter == null ? await context.Set<Entities.Concrete.Action>().ToListAsync() : await context.Set<Entities.Concrete.Action>().Where(filter).ToListAsync();
            }
        }

        public async Task<Entities.Concrete.Action> GetById(Expression<Func<Entities.Concrete.Action, bool>> filter)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                return await context.Set<Entities.Concrete.Action>().SingleOrDefaultAsync(filter);
            }
        }

        
    }
}
