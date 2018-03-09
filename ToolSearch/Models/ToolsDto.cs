using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSearch.Models
{
    public class ToolsDto:BaseDto
    {
        public string Num { get; set; }
        public string Url { get; set; }
        public string Specification{get;set;}
        public string Manufacotry { get; set; }
        public int BroTimes { get; set; }
        public DateTime ExpDate { get; set; }
        public MetalStatus Status { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string StatusName
        {
            get { return Status.ToString(); }
        }
        public DateTime? BroDate { get; set; }
    }

}
