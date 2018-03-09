using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSearch.Models
{
    public class ToolCount
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public int InCount { get; set; }
        public int OutCount { get; set; }
        public Image imgResource{ get; set; }
    }
}
