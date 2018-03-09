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
using ToolScan.Unity;
using ToolScan.Models;

namespace ToolSearch
{
    public partial class FrmToolList : DevExpress.XtraEditors.XtraForm
    {
        private ToolContext toolContext = new ToolContext();
        private delegate void GetExpDataDelegate();
        public FrmToolList(string SkinName)
        {
            InitializeComponent();
            GetExpDataAsync();
            dLookFeel.LookAndFeel.SkinName = SkinName;
        }

        private void GetExpDataAsync() {
            var list = toolContext.Tools.Where(c => !c.IsDelete).ToList();
            if (this.IsHandleCreated)
            {
                this.gridControl1.BeginInvoke(new Action(() =>
                {
                    gridControl1.DataSource = list;
                    gridControl1.Refresh();
                }));
            }
            else
            {
                gridControl1.DataSource = list;
                gridControl1.Refresh();
            }
        }

        private void gridView1_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var temp = (ToolsEntity)gridView1.GetFocusedRow();
            var tool = toolContext.Tools.Where(c => c.Id == temp.Id).FirstOrDefault();
            if (tool != null)
            {
                using (FrmToolEdit frm = new FrmToolEdit(tool, dLookFeel.LookAndFeel.ActiveSkinName))
                {
                    DialogResult ret = frm.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        GetExpDataDelegate del = new GetExpDataDelegate(GetExpDataAsync);
                        this.BeginInvoke(del);
                    }
                }
            }
        }
    }
}