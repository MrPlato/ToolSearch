using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolScan.IDao;

namespace ToolScan.Service
{
    public class BaseService<T> where T:class
    {
        private readonly IBaseDao<T> baseDao;
        public BaseService(IBaseDao<T> baseDao)
        {
            this.baseDao = baseDao;
        }
        public List<T> GetList()
        {
            return baseDao.GetList();
        }
        public Boolean Create(T model)
        {
            return baseDao.Create(model) > 0;
        }
        public Boolean Create(List<T> models)
        {
            return baseDao.Create(models) > 0;
        }
        public Boolean Edit(T model)
        {
            return baseDao.Edit(model) > 0;
        }
        public Boolean Delete(T model)
        {
            return baseDao.Delete(model) > 0;
        }
        public Boolean Delete(params object[] KeyValues)
        {
            return baseDao.Delete(KeyValues) > 0;
        }
        public Boolean Delete(List<T> models)
        {
            return baseDao.Delete(models) > 0;
        }
        public T GetById(params object[] KeyValues)
        {
            return baseDao.GetById(KeyValues);
        }
        public bool IsExist(object id)
        {
            return baseDao.IsExist(id);
        }
    }
}
