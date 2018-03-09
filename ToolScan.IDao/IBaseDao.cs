using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace ToolScan.IDao
{
    public interface IBaseDao<T> where T:class
    {
        List<T> GetList();
        int Create(T model);
        int Create(List<T> models);
        int Edit(T model);
        int Delete(T model);
        int Delete(List<T> models);
        int Delete(params object[] keyValues);
        T GetById(params object[] KeyValues);
        bool IsExist(object id);
    }
}
