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
        public void Add(Entities.Concrete.Action entity)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Entities.Concrete.Action entity)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Entities.Concrete.Action entity)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Entities.Concrete.Action Get(Expression<Func<Entities.Concrete.Action, bool>> filter)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                return context.Set<Entities.Concrete.Action>().SingleOrDefault(filter);
            }
        }

        public List<Entities.Concrete.Action> GetAll(Expression<Func<Entities.Concrete.Action, bool>> filter = null)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                return filter == null ? context.Set<Entities.Concrete.Action>().ToList() : context.Set<Entities.Concrete.Action>().Where(filter).ToList();
            }
        }

        public Entities.Concrete.Action GetById(Expression<Func<Entities.Concrete.Action, bool>> filter)
        {
            using (ActionInMemoryDatabase context = new ActionInMemoryDatabase())
            {
                return context.Set<Entities.Concrete.Action>().SingleOrDefault(filter);
            }
        }

        
    }
}
