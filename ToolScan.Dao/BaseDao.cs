using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mehdime.Entity;
using ToolScan.Models;
using System.Data.Entity.Migrations;

namespace ToolScan.Dao
{
    public class BaseDao<T> where T:class
    {
        protected DbContext GetDb(IDbContextScope scope)
        {
            return scope.DbContexts.Get<ToolContext>();
        }
        protected DbContext GetDb(IDbContextReadOnlyScope scope)
        {
            return scope.DbContexts.Get<ToolContext>();
        }
        protected DbSet<T> GetDbSet(DbContext db)
        {
            return db.Set<T>();
        }
        public IDbContextScopeFactory _dbScopeFactory { get; set; }
        public List<T> GetList()
        {
            using(var scope =_dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                return dbSet.ToList();
            }
        }
        public int Create(T model)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                dbSet.Add(model);
                return db.SaveChanges();
            }
        }
        public int Create(List<T> models) {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                dbSet.AddRange(models);
                return db.SaveChanges();
            }
        }
        public int Edit(T model)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                dbSet.AddOrUpdate(model);
                return db.SaveChanges();
            }
        }
        public int Delete(T model)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                dbSet.Remove(model);
                return db.SaveChanges();
            }
        }
        public int Delete(List<T> model)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                dbSet.RemoveRange(model);
                return db.SaveChanges();
            }
        }
        public int Delete(params object[] KeyValues)
        {
            T model = GetById(KeyValues);
            if (model != null)
            {
                using (var scope = _dbScopeFactory.Create())
                {
                    var db = GetDb(scope);
                    var dbSet = GetDbSet(db);
                    dbSet.Remove(model);
                    return db.SaveChanges();
                }
            }
            return 0;
        }
        public T GetById(params object[] KeyValues)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                return dbSet.Find(KeyValues);
            }
        }
        public bool IsExist(object id)
        {
            return GetById(id) != null;
        }
    }
}
