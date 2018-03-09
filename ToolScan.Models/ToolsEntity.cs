using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScan.Models
{
    public class ToolsEntity:BaseEntity
    {
        public string Num { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Manufactory { get; set; }
        public int BroTimes { get; set; }
        public DateTime ExpDate { get; set; }
        public byte Status { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime? BroDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<ToolLogEntity> ToolLog { get; set; }
    }
}
