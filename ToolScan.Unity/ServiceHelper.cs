using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolScan.IDao;
using ToolScan.Service;

namespace ToolScan.Unity
{
    public class ServiceHelper
    {
        #region 公共属性
        public static ToolService toolService { get; set; }
        #endregion
        static ServiceHelper() => SetService();
        public static void SetService()
        {
            toolService = new ToolService(AutofacContainer.GetInstance().GetObject<IToolDao>());
        }
    }
}
