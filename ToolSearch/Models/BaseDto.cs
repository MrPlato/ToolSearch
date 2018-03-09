using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSearch.Models
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsDelete { get; set; }
        public BaseDto()
        {
            CreateDateTime = DateTime.Now;
            IsDelete = false;
        }
    }
}
