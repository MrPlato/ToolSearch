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
using Impinj.OctaneSdk;
using DevExpress.XtraSplashScreen;
using ToolSearch.Models;
using ToolSearch.Utils;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Configuration;
using System.Threading;

namespace ToolSearch
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        private SpeedwayReader Reader = new SpeedwayReader();
        private bool eventFlag = false;
        private bool gpi1Status = false;
        private bool gpi2Status = false;
        private bool IsReaderStart = false;
        private List<string> tagsList = new List<string>();
        private ToolContext toolContext = new ToolContext();
        private int count = 0;
        System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        private delegate void TagsReportedDelegate(List<Tag> tags);
        private delegate void SetTagsInGridDelegate(List<string> tags);
        private delegate void GetExpData();
        private List<string> otherList = new List<string>();
        public FrmMain()
        {
            InitializeComponent();
            SetSkins();
            StartReader();
            tmr.Interval = 1500;
            tmr.Tick += Time_tick;
            GetExpDataAsync();
            GetExpiredData();
            lbOther.Visible = false;
        }
        /// <summary>
        /// 获取使用到期的工具
        /// </summary>
        private void GetExpiredData()
        {
            var date = DateTime.Now.AddMonths(1);
            var list = toolContext.Tools.Where(c => c.ExpiredDate < date && c.ExpiredDate > DateTime.Now && !c.IsDelete).OrderBy(c => c.ExpiredDate).ToList();
            if (this.IsHandleCreated)
            {
                this.gridControl3.BeginInvoke(new Action(() => {
                    gridControl3.DataSource = list;
                    gridControl3.Refresh();
                }));
            }
            else
            {
                gridControl3.DataSource = list;
                gridControl3.Refresh();
            }
        }
        /// <summary>
        /// 获取试验到期的工具
        /// </summary>
        private void GetExpDataAsync()
        {
            var date = DateTime.Now.AddDays(10);
            var list= toolContext.Tools.Where(c => c.ExpDate < date && c.ExpDate >= DateTime.Now&&!c.IsDelete).OrderBy
                (c=>c.ExpDate).ToList();
            if (this.IsHandleCreated)
            {
                this.gridControl2.BeginInvoke(new Action(() =>
                {
                    gridControl2.DataSource = list;
                    gridControl2.Refresh();
                }));
            }else
            {
                gridControl2.DataSource = list;
                gridControl2.Refresh();
            }
        }
        /// <summary>
        /// 设置外观皮肤
        /// </summary>
        private void SetSkins()
        {
            foreach(DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                reColor.Items.Add(skin.SkinName);
            }
            this.barColorItem.EditValueChanged +=barItemColor_EditValueChanged;
        }
        /// <summary>
        /// 检测外观皮肤改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barItemColor_EditValueChanged(object sender, EventArgs e)
        {
            dLookAndFeel.LookAndFeel.SkinName = barColorItem.EditValue.ToString();
        }
        /// <summary>
        /// 定时器事件 当柜门关闭后20秒后启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Time_tick(object sender, EventArgs e)
        {
            if (eventFlag)
            {
                if (tagsList.Count != count)
                    count = tagsList.Count;
                else
                {
                    if (gpi1Status && gpi2Status && eventFlag)
                    {
                        tmr.Stop();
                        Reader.TagsReported -= OnTagsReported;
                        eventFlag = false;
                        if (SplashScreenManager.Default != null)
                        {
                            SplashScreenManager.CloseForm();
                        }
                        SetTagsInGridDelegate del = new SetTagsInGridDelegate(getDatas);
                        this.BeginInvoke(del, tagsList);
                    }
                }
            }
        }
        /// <summary>
        /// 更新工具状态
        /// </summary>
        /// <param name="tools"></param>
        private void ToolArrange(List<ToolsEntity> tools)
        {
            var ids = tools.Select(c => c.Id).Distinct().ToArray();
            var InItems = toolContext.Tools.Where(c => ids.Contains(c.Id) && c.Status == 1&&!c.IsDelete).ToList();
            var OutItems = toolContext.Tools.Where(c => !ids.Contains(c.Id) && c.Status == 0&&!c.IsDelete).ToList();
            var logItems = new List<ToolLogEntity>();
            foreach(var item in InItems)
            {
                item.Status = 0;
                item.BroDate = DateTime.Now;
            }
            foreach(var item in OutItems)
            {
                item.Status = 1;
                item.BroDate = DateTime.Now;
                item.BroTimes += 1;
                ToolLogEntity temp = new ToolLogEntity
                {
                    ToolId = item.Id,
                    Status=1
                };
                logItems.Add(temp);
            }
            toolContext.Tools.AddOrUpdate(InItems.Concat(OutItems).ToArray());
            if (logItems.Any())
                toolContext.ToolLog.AddOrUpdate(logItems.ToArray());
        }
        /// <summary>
        /// 获取仓库工具信息并显示
        /// </summary>
        /// <param name="tags"></param>
        private void getDatas(List<string> tags)
        {
            var tempTag = tags.Count;
            var totalList = toolContext.Tools.Where(c=>!c.IsDelete).ToList();
            var InList = toolContext.Tools.Where(c => tags.Contains(c.Num)&&!c.IsDelete).ToList();
            Task.Factory.StartNew(()=> { ToolArrange(InList); });
            var list = (from c in totalList where tags.Contains(c.Num) group c by new { c.Name, c.Specification,c.Url } into g select new ToolCount { Name = g.Key.Name, Specification = g.Key.Specification, InCount = g.Count(), Url=g.Key.Url}).ToList();
            foreach (var item in list)
            {
                var allCount = totalList.Where(c => c.Name == item.Name && c.Specification == item.Specification&&c.Url==item.Url).Count();
                item.OutCount =allCount - item.InCount;
                item.imgResource = Image.FromFile(Application.StartupPath + @"\\Resources\\" + item.Url);
            }
            var remain = tempTag - InList.Count;
            if(remain>0)
            {
                otherList.Clear();
                var intag = InList.Select(c => c.Num);
                otherList.AddRange(tags.Except(intag).ToList());
            }
            this.lbOther.BeginInvoke(new Action(()=>
            {
                this.lbOther.Visible = remain > 0; 
            }));
            this.gridControl1.BeginInvoke(new Action(() => {
                this.gridControl1.DataSource = list;
                this.gridControl1.Refresh();
            }) );
            this.txtInCount.BeginInvoke(new Action(() => {
                this.txtInCount.Text = InList.Count.ToString();
            }));
            this.txtTotal.BeginInvoke(new Action(()=> {
                this.txtTotal.Text = totalList.Count.ToString();
            }));
            this.txtNoExist.BeginInvoke(new Action(()=> {
                this.txtNoExist.Text = remain.ToString();
            }));
            tagsList.Clear();
        }
        /// <summary>
        /// 启动射频设备
        /// </summary>
        private void StartReader()
        {
            try
            {
                var addr = ConfigurationManager.AppSettings["impinj"].ToString();
                Reader.Connect(addr);
                IsReaderStart = true;
                barButtonItem4.Enabled = false;
                Reader.ClearSettings();
                Settings settings = Reader.QueryFactorySettings();
                settings.Report.IncludeAntennaPortNumber = true;
                var x = settings.Gpis;
                foreach (var item in settings.Gpis)
                {
                    item.IsEnabled = true;
                }
                settings.Report.Mode = ReportMode.Individual;
                settings.AutoStart.Mode = AutoStartMode.GpiTrigger;
                settings.AutoStart.GpiPortNumber = 4;
                settings.AutoStart.GpiLevel = true;
                settings.AutoStop.Mode = AutoStopMode.GpiTrigger;
                settings.AutoStop.GpiPortNumber = 4;
                settings.AutoStop.GpiLevel = false;
                Reader.ApplySettings(settings);
                try
                {
                    if (!Reader.QueryStatus().IsSingulating)
                    {
                        Reader.Start();
                        Reader.Gpi1Changed += OnGpi1Change;
                        Reader.Gpi2Changed += OnGpi2Change;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            catch
            {
                XtraMessageBox.Show("无法连接到射频设备,请检查无误后重新开启程序");
                return;
            }
            finally
            {
                if (SplashScreenManager.Default != null)
                    SplashScreenManager.CloseForm();
            }
        }
        /// <summary>
        /// GPI1事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGpi2Change(object sender, GpiChangedEventArgs e)
        {
            SetEpcEvent(e, 2);
        }
        /// <summary>
        /// GPI2事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGpi1Change(object sender, GpiChangedEventArgs e)
        {
            SetEpcEvent(e, 1);
        }
        /// <summary>
        /// GPI事件触发后处理
        /// </summary>
        /// <param name="e"></param>
        /// <param name="Num"></param>
        private void SetEpcEvent(GpiChangedEventArgs e, int Num)
        {
            bool blnRes = false;
            if (e.State == GpioState.High)
            {
                blnRes = true;
            }
            else
            {
                blnRes = false;
            }
            switch (Num)
            {
                case 1:
                    gpi1Status = blnRes;
                    break;
                case 2:
                    gpi2Status = blnRes;
                    break;
            }
            if (gpi1Status && gpi2Status && !eventFlag)
            {
                eventFlag = true;
                Task.Factory.StartNew(updateCountingTime);
            }
            else
            {
                if (eventFlag)
                    PlusTagsEvent();
            }
        }

        private void updateCountingTime()
        {
            int tVal = 0;
            try
            {
                tVal = int.Parse(ConfigurationManager.AppSettings["timing"].ToString());
                if (tVal <= 1000)
                    Thread.Sleep(tVal);
                else
                {
                    int tmpVal = Convert.ToInt32(tVal / 1000);
                    for(int i=0;i<tmpVal;i++)
                    {
                        if (eventFlag)
                            Thread.Sleep(1000);
                        else
                            return;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("时间设置问题,请检查后重试");
                return;
            }
            Reader.TagsReported += OnTagsReported;
            tmr.Start();
            if (SplashScreenManager.Default == null)
                SplashScreenManager.ShowForm(this.FindForm(), typeof(FrmLoading), false, true);
        }

        private void PlusTagsEvent()
        {
            tmr.Stop();
            Reader.TagsReported -= OnTagsReported;
            eventFlag = false;
            count = 0;
            tagsList.Clear();
            if (SplashScreenManager.Default != null)
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void OnTagsReported(object sender, TagsReportedEventArgs e)
        {
            TagsReportedDelegate del =new  TagsReportedDelegate(UpdateTagsList);
            this.BeginInvoke(del, e.TagReport.Tags);
        }

        private void UpdateTagsList(List<Tag> tags)
        {
            foreach (var tag in tags)
            {
                if (tagsList != null && !tagsList.Exists(item => item.Equals(tag.Epc)))
                {
                    tagsList.Add(tag.Epc);
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Title = "选择要导入的文件";
            ofd.Multiselect = false;
            ofd.Filter = "Excel文件|*.xls";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string fileName = ofd.SafeFileName;
                if (filePath.EndsWith("xls"))
                {
                    string connectionStr = "Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source =" + filePath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";
                    DataSet ds = OleDbHelper.ExecuteDateSet(connectionStr, CommandType.Text, "select * from [Sheet1$]");
                    if (ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        List<ToolsEntity> tempList = new List<ToolsEntity>();
                        try
                        {
                            var x = dt.Rows.Count;
                            foreach (DataRow item in dt.Rows)
                            {
                                ToolsEntity temp = new ToolsEntity
                                {
                                    Manufactory = item[2].ToString(),
                                    Name = item[1].ToString(),
                                    Num = item[0].ToString(),
                                    Url = item[3].ToString(),
                                    Specification = item[4].ToString(),
                                    ExpDate = DateTime.Parse(item[5].ToString()),
                                    ExpiredDate=DateTime.Parse(item[7].ToString()),
                                    BroDate=DateTime.Now,
                                    Status=byte.Parse(item[6].ToString())
                                };
                                tempList.Add(temp);
                            }
                        }
                        catch
                        {
                            XtraMessageBox.Show("录入数据错误");
                            return;
                        }
                        toolContext.Tools.AddOrUpdate(tempList.ToArray());
                        toolContext.SaveChanges();
                    }
                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var temp = (ToolsEntity)gridView1.GetFocusedRow();
            var tool = toolContext.Tools.Where(c => c.Id == temp.Id&&!c.IsDelete).FirstOrDefault();
            if (tool != null)
            {
                using (FrmToolEdit frm = new FrmToolEdit(tool,dLookAndFeel.LookAndFeel.ActiveSkinName))
                {
                    DialogResult ret = frm.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        GetExpData del = new GetExpData(GetExpDataAsync);
                        this.BeginInvoke(del);
                        GetExpData del2 = new GetExpData(GetExpiredData);
                        this.BeginInvoke(del2);
                    }
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using(FrmToolList frm=new FrmToolList(dLookAndFeel.LookAndFeel.ActiveSkinName))
            {
                frm.ShowDialog();
                GetExpData del = new GetExpData(GetExpDataAsync);
                this.BeginInvoke(del);
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!IsReaderStart)
                StartReader();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using(FrmToolLog frm=new FrmToolLog(dLookAndFeel.LookAndFeel.ActiveSkinName))
            {
                frm.ShowDialog();
            }
        }

        private void lbOther_Click(object sender, EventArgs e)
        {
            using(FrmRemain frm=new FrmRemain(otherList, dLookAndFeel.LookAndFeel.ActiveSkinName))
            {
                frm.ShowDialog();
            }
        }
    }
}