using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSearch.Models
{
    public class ToolLogDto:BaseDto
    {
        public int ToolId { get; set; }
        public MetalStatus Status { get; set; }
        public string StatusName
        {
            get
            {
                return Status.ToString();
            }
        }
    }
}
