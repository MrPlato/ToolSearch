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
using System.IO;
using System.Data.Entity.Migrations;

namespace ToolSearch
{
    public partial class FrmToolEdit : DevExpress.XtraEditors.XtraForm
    {
        ToolsEntity tool, bindingTool;
        ToolContext toolContext = new ToolContext();
        public FrmToolEdit()
        {
            InitializeComponent();
        }
        public FrmToolEdit(ToolsEntity tools, string skinName)
        {
            InitializeComponent();
            this.tool = tools;
            this.bindingTool = tools;
            teName.DataBindings.Add("Text", bindingTool, "Name");
            teNumber.DataBindings.Add("Text", bindingTool, "Num");
            teSpec.DataBindings.Add("Text", bindingTool, "Specification");
            teManu.DataBindings.Add("Text", bindingTool, "Manufactory");
            teExpDate.DataBindings.Add("EditValue", bindingTool, "ExpDate");
            DtExpiredDate.DataBindings.Add("EditValue", bindingTool, "ExpiredDate");
            pePhoto.Image = Image.FromFile(Application.StartupPath + @"\\Resources\\" + bindingTool.Url);
            UpdateCaption();
            dLookAndFeel.LookAndFeel.SkinName = skinName;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Title = "选择图片";
            ofd.Multiselect = false;
            ofd.Filter = "图片文件|*.jpg;*.jpeg; *.png";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string fileName = ofd.SafeFileName;
                if (File.Exists(Application.StartupPath + @"\\Resources\\" + fileName))
                {
                    try
                    {
                        File.Delete(Application.StartupPath + @"\\Resources\\" + fileName);
                        File.Copy(filePath, Application.StartupPath + @"\\Resources\\" + fileName);
                    }
                    catch (Exception)
                    {
                    }
                }
                
                bindingTool.Url = fileName;
                pePhoto.Image = Image.FromFile(Application.StartupPath + @"\\Resources\\" + fileName);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            bindingTool.Num = teNumber.Text;
            bindingTool.Name = teName.Text;
            bindingTool.Specification = teSpec.Text;
            bindingTool.Manufactory = teManu.Text;
            bindingTool.ExpDate = DateTime.Parse(teExpDate.Text);
            bindingTool.ExpiredDate = DateTime.Parse(DtExpiredDate.Text);
                
            toolContext.Tools.AddOrUpdate(bindingTool);
            toolContext.SaveChanges();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            bindingTool.IsDelete = true;
            bindingTool.BroDate = DateTime.Now;
            bindingTool.Status = 2;
            ToolLogEntity tool = new ToolLogEntity
            {
                Status = 2,
                ToolId = bindingTool.Id,
            };
            toolContext.Tools.AddOrUpdate(bindingTool);
            toolContext.ToolLog.AddOrUpdate(tool);
            toolContext.SaveChanges();
        }

        private void UpdateCaption()
        {
            Text = bindingTool.Name;
        }
    }
}