using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScan.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsDelete { get; set; }
        public BaseEntity()
        {
            IsDelete = false;
            CreateDateTime = DateTime.Now;
        }
    }
}
