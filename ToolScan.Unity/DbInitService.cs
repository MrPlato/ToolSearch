using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolScan.Models;

namespace ToolScan.Unity
{
    public class DbInitService
    {
        public static void Init()
        {
            InitData.init();
        }
    }
}
