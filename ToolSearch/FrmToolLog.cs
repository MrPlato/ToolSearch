using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ToolScan.Models;
using AutoMapper;
using ToolSearch.Models;

namespace ToolSearch
{
    public partial class FrmToolLog : DevExpress.XtraEditors.XtraForm
    {
        private ToolContext toolContext = new ToolContext();
        public FrmToolLog(string SkinName)
        {
            InitializeComponent();
            GetExpDate();
            dLookAndFeel.LookAndFeel.SkinName = SkinName;
        }

        private void GetExpDate()
        {
            var list = toolContext.ToolLog.Where(c => !c.IsDelete).ToList();
            var items = Mapper.Map<List<ToolLogEntity>, List<ToolLogDto>>(list);
            var res = items.Select(c => new ToolLogVo
            {
                Name = toolContext.Tools.Where(d => d.Id == c.ToolId).First().Name,
                CreateDateTime=c.CreateDateTime,
                Num=toolContext.Tools.Where(d=>d.Id==c.ToolId).First().Num,
                Status=c.StatusName
            }).ToList();
            gridControl1.DataSource = res;
        }
    }
}