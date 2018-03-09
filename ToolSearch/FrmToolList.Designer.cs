namespace ToolSearch
{
    partial class FrmToolList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToolList));
            this.dManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dLookFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ToolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Specification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TeManufactory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BroTimes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpiredDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // dManager
            // 
            this.dManager.Form = this;
            this.dManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.gridControl1.Size = new System.Drawing.Size(823, 563);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.Num,
            this.ToolName,
            this.Specification,
            this.TeManufactory,
            this.BroTimes,
            this.ExpDate,
            this.ExpiredDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsHint.ShowCellHints = false;
            this.gridView1.OptionsHint.ShowColumnHeaderHints = false;
            this.gridView1.OptionsHint.ShowFooterHints = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick_1);
            // 
            // Id
            // 
            this.Id.AppearanceHeader.Options.UseTextOptions = true;
            this.Id.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Id.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Id.Caption = "id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.AllowEdit = false;
            this.Id.OptionsColumn.AllowFocus = false;
            this.Id.OptionsColumn.ReadOnly = true;
            // 
            // Num
            // 
            this.Num.AppearanceHeader.Options.UseTextOptions = true;
            this.Num.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Num.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Num.Caption = "编号";
            this.Num.FieldName = "Num";
            this.Num.Name = "Num";
            this.Num.OptionsColumn.AllowEdit = false;
            this.Num.OptionsColumn.AllowFocus = false;
            this.Num.OptionsColumn.ReadOnly = true;
            this.Num.Visible = true;
            this.Num.VisibleIndex = 0;
            // 
            // ToolName
            // 
            this.ToolName.AppearanceHeader.Options.UseTextOptions = true;
            this.ToolName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ToolName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ToolName.Caption = "名称";
            this.ToolName.FieldName = "Name";
            this.ToolName.Name = "ToolName";
            this.ToolName.OptionsColumn.AllowEdit = false;
            this.ToolName.OptionsColumn.AllowFocus = false;
            this.ToolName.OptionsColumn.ReadOnly = true;
            this.ToolName.Visible = true;
            this.ToolName.VisibleIndex = 1;
            // 
            // Specification
            // 
            this.Specification.AppearanceHeader.Options.UseTextOptions = true;
            this.Specification.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Specification.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Specification.Caption = "规格";
            this.Specification.FieldName = "Specification";
            this.Specification.Name = "Specification";
            this.Specification.OptionsColumn.AllowEdit = false;
            this.Specification.OptionsColumn.AllowFocus = false;
            this.Specification.OptionsColumn.ReadOnly = true;
            this.Specification.Visible = true;
            this.Specification.VisibleIndex = 2;
            // 
            // TeManufactory
            // 
            this.TeManufactory.AppearanceHeader.Options.UseTextOptions = true;
            this.TeManufactory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TeManufactory.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TeManufactory.Caption = "制造商";
            this.TeManufactory.FieldName = "Manufactory";
            this.TeManufactory.Name = "TeManufactory";
            this.TeManufactory.OptionsColumn.AllowEdit = false;
            this.TeManufactory.OptionsColumn.AllowFocus = false;
            this.TeManufactory.OptionsColumn.ReadOnly = true;
            this.TeManufactory.Visible = true;
            this.TeManufactory.VisibleIndex = 3;
            // 
            // BroTimes
            // 
            this.BroTimes.Caption = "使用次数";
            this.BroTimes.FieldName = "BroTimes";
            this.BroTimes.Name = "BroTimes";
            this.BroTimes.OptionsColumn.AllowEdit = false;
            this.BroTimes.OptionsColumn.AllowFocus = false;
            this.BroTimes.OptionsColumn.ReadOnly = true;
            this.BroTimes.Visible = true;
            this.BroTimes.VisibleIndex = 4;
            // 
            // ExpDate
            // 
            this.ExpDate.AppearanceHeader.Options.UseTextOptions = true;
            this.ExpDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExpDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ExpDate.Caption = "试验到期日期";
            this.ExpDate.FieldName = "ExpDate";
            this.ExpDate.Name = "ExpDate";
            this.ExpDate.OptionsColumn.AllowEdit = false;
            this.ExpDate.OptionsColumn.AllowFocus = false;
            this.ExpDate.OptionsColumn.ReadOnly = true;
            this.ExpDate.Visible = true;
            this.ExpDate.VisibleIndex = 5;
            // 
            // ExpiredDate
            // 
            this.ExpiredDate.Caption = "使用年限";
            this.ExpiredDate.FieldName = "ExpiredDate";
            this.ExpiredDate.Name = "ExpiredDate";
            this.ExpiredDate.OptionsColumn.AllowEdit = false;
            this.ExpiredDate.OptionsColumn.AllowFocus = false;
            this.ExpiredDate.OptionsColumn.ReadOnly = true;
            this.ExpiredDate.Visible = true;
            this.ExpiredDate.VisibleIndex = 6;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.SuppressMouseEventOnOuterMouseClick = true;
            // 
            // FrmToolList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 563);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmToolList";
            this.Text = "工具列表";
            ((System.ComponentModel.ISupportInitialize)(this.dManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dManager;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel dLookFeel;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn Num;
        private DevExpress.XtraGrid.Columns.GridColumn ToolName;
        private DevExpress.XtraGrid.Columns.GridColumn Specification;
        private DevExpress.XtraGrid.Columns.GridColumn TeManufactory;
        private DevExpress.XtraGrid.Columns.GridColumn BroTimes;
        private DevExpress.XtraGrid.Columns.GridColumn ExpDate;
        private DevExpress.XtraGrid.Columns.GridColumn ExpiredDate;
    }
}