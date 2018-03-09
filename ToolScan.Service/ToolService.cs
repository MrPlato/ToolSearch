using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolScan.IDao;
using ToolScan.Models;

namespace ToolScan.Service
{
    public class ToolService:BaseService<ToolsEntity>
    {
        private readonly IToolDao toolDao;
        public ToolService(IToolDao toolDao) : base(toolDao)
        {
            this.toolDao = toolDao;
        }
    }
}
