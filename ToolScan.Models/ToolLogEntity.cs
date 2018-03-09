using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScan.Models
{
    public class ToolLogEntity:BaseEntity
    {
        public int ToolId { get; set; }
        public byte Status { get; set; }
        [JsonIgnore]
        public virtual ToolsEntity Tools { get; set; }
    }
}
