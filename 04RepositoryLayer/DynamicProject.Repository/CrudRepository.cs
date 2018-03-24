using System;
using System.Collections.Generic;
using System.Linq;
using DynamicProject.Model;
using DynamicProject.Repository.Helper;
using DynamicProject.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DynamicProject.Repository
{
    public class CrudRepository<TModel> : ICrudRepository<TModel> where TModel : BaseModel
    {
        private DbContext _applicationContex;
        private DbSet<TModel> _table;
        public CrudRepository( IDbContextFactory<IDomainModelContext> dbContextFactory)
        {
            _applicationContex = dbContextFactory.DbContext;
            _table = dbContextFactory.Set<TModel>();
        }

        public TModel Create(TModel model)
        {
           var newRecord = _table.Add(model).Entity;
           _applicationContex.SaveChanges();
           return newRecord;
        }

        public TModel Get(int id)
        {
            return _table.Find(id);
        }

        public List<TModel> GetAll()
        {
            return _table.ToList();
        }
    }
}
