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

namespace ToolSearch
{
    public partial class FrmRemain : DevExpress.XtraEditors.XtraForm
    {
        public FrmRemain(List<string> list,string SkinName)
        {
            InitializeComponent();
            dLookAndFeel.LookAndFeel.SkinName = SkinName;
            StringBuilder str = new StringBuilder();
            foreach(var item in list)
            {
                str.Append(item);
                str.AppendLine();
            }
            richEditControl1.Text = str.ToString();
        }
    }
}