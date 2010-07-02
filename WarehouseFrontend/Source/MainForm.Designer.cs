namespace WarehouseFrontend
{
    partial class MainForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView1 = new DevExpress.XtraCharts.SplineAreaSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView2 = new DevExpress.XtraCharts.SplineAreaSeriesView();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView3 = new DevExpress.XtraCharts.SplineAreaSeriesView();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.searchtabpage = new DevExpress.XtraTab.XtraTabPage();
            this.searchsite = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.searchButton = new DevExpress.XtraEditors.ButtonEdit();
            this.downloadbyid = new DevExpress.XtraEditors.ButtonEdit();
            this.searchResultsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.section = new DevExpress.XtraGrid.Columns.GridColumn();
            this.size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.seeds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.site = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.filterstabpage = new DevExpress.XtraTab.XtraTabPage();
            this.assigncategory = new DevExpress.XtraEditors.ButtonEdit();
            this.filterType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.refreshfilters = new DevExpress.XtraEditors.SimpleButton();
            this.addfilter = new DevExpress.XtraEditors.ButtonEdit();
            this.deletefilters = new DevExpress.XtraEditors.SimpleButton();
            this.filtersGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewFilters = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.selected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.filter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.category = new DevExpress.XtraGrid.Columns.GridColumn();
            this.type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statsTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.bwChartControl = new DevExpress.XtraCharts.ChartControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.totalsize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rlscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.getSiteStatsButton = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ulspeed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dlspeed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.freespace = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtorrentTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.hidecompleted = new DevExpress.XtraEditors.CheckEdit();
            this.refreshTorrents = new DevExpress.XtraEditors.SimpleButton();
            this.torrentsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewRtorrent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.torrentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.downloadSpeed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uploadSpeed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fileCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.torrentSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.percentDone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timeLeft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.notificationsTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.bwtimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.searchtabpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchsite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadbyid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSearch)).BeginInit();
            this.filterstabpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assigncategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addfilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFilters)).BeginInit();
            this.statsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bwChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSiteStatsButton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.rtorrentTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hidecompleted.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.torrentsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRtorrent)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.searchtabpage;
            this.xtraTabControl1.Size = new System.Drawing.Size(510, 411);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.searchtabpage,
            this.filterstabpage,
            this.statsTabPage,
            this.rtorrentTabPage,
            this.notificationsTabPage});
            // 
            // searchtabpage
            // 
            this.searchtabpage.Controls.Add(this.searchsite);
            this.searchtabpage.Controls.Add(this.label4);
            this.searchtabpage.Controls.Add(this.searchButton);
            this.searchtabpage.Controls.Add(this.downloadbyid);
            this.searchtabpage.Controls.Add(this.searchResultsGridControl);
            this.searchtabpage.Image = global::WarehouseFrontend.Properties.Resources.find;
            this.searchtabpage.Name = "searchtabpage";
            this.searchtabpage.Size = new System.Drawing.Size(503, 380);
            this.searchtabpage.Text = "search";
            // 
            // searchsite
            // 
            this.searchsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchsite.Location = new System.Drawing.Point(27, 336);
            this.searchsite.Name = "searchsite";
            this.searchsite.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchsite.Size = new System.Drawing.Size(132, 20);
            this.searchsite.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "site:";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(3, 359);
            this.searchButton.Name = "searchButton";
            this.searchButton.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "search", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.Default, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.searchButton.Size = new System.Drawing.Size(498, 20);
            this.searchButton.TabIndex = 3;
            this.searchButton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.searchButton_ButtonClick);
            // 
            // downloadbyid
            // 
            this.downloadbyid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadbyid.EditValue = "";
            this.downloadbyid.Location = new System.Drawing.Point(161, 336);
            this.downloadbyid.Name = "downloadbyid";
            this.downloadbyid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "dl by id", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.Default, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "dl by name", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.downloadbyid.Properties.Mask.BeepOnError = true;
            this.downloadbyid.Size = new System.Drawing.Size(340, 20);
            this.downloadbyid.TabIndex = 2;
            this.downloadbyid.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.downloadbyid_ButtonClick);
            // 
            // searchResultsGridControl
            // 
            this.searchResultsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResultsGridControl.Location = new System.Drawing.Point(2, 2);
            this.searchResultsGridControl.MainView = this.gridViewSearch;
            this.searchResultsGridControl.Name = "searchResultsGridControl";
            this.searchResultsGridControl.Size = new System.Drawing.Size(499, 332);
            this.searchResultsGridControl.TabIndex = 0;
            this.searchResultsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSearch});
            // 
            // gridViewSearch
            // 
            this.gridViewSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.name,
            this.section,
            this.size,
            this.date,
            this.seeds,
            this.site,
            this.id});
            this.gridViewSearch.GridControl = this.searchResultsGridControl;
            this.gridViewSearch.Name = "gridViewSearch";
            this.gridViewSearch.OptionsView.ShowGroupPanel = false;
            this.gridViewSearch.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewSearch_RowClick);
            this.gridViewSearch.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridViewSearch_CustomColumnSort);
            // 
            // name
            // 
            this.name.Caption = "name";
            this.name.FieldName = "name";
            this.name.Name = "name";
            this.name.OptionsColumn.AllowEdit = false;
            this.name.OptionsColumn.ReadOnly = true;
            this.name.Visible = true;
            this.name.VisibleIndex = 0;
            this.name.Width = 131;
            // 
            // section
            // 
            this.section.Caption = "section";
            this.section.FieldName = "section";
            this.section.Name = "section";
            this.section.OptionsColumn.AllowEdit = false;
            this.section.OptionsColumn.ReadOnly = true;
            this.section.Visible = true;
            this.section.VisibleIndex = 1;
            this.section.Width = 41;
            // 
            // size
            // 
            this.size.Caption = "size";
            this.size.FieldName = "sizeString";
            this.size.Name = "size";
            this.size.OptionsColumn.AllowEdit = false;
            this.size.OptionsColumn.ReadOnly = true;
            this.size.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.size.Visible = true;
            this.size.VisibleIndex = 2;
            this.size.Width = 50;
            // 
            // date
            // 
            this.date.Caption = "date";
            this.date.FieldName = "date";
            this.date.Name = "date";
            this.date.OptionsColumn.AllowEdit = false;
            this.date.OptionsColumn.ReadOnly = true;
            this.date.Visible = true;
            this.date.VisibleIndex = 3;
            this.date.Width = 72;
            // 
            // seeds
            // 
            this.seeds.Caption = "seeds";
            this.seeds.FieldName = "seederCount";
            this.seeds.Name = "seeds";
            this.seeds.OptionsColumn.AllowEdit = false;
            this.seeds.OptionsColumn.FixedWidth = true;
            this.seeds.OptionsColumn.ReadOnly = true;
            this.seeds.Visible = true;
            this.seeds.VisibleIndex = 4;
            this.seeds.Width = 55;
            // 
            // site
            // 
            this.site.Caption = "site";
            this.site.FieldName = "site";
            this.site.Name = "site";
            this.site.OptionsColumn.AllowEdit = false;
            this.site.OptionsColumn.ReadOnly = true;
            this.site.Visible = true;
            this.site.VisibleIndex = 5;
            this.site.Width = 68;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowEdit = false;
            this.id.OptionsColumn.ReadOnly = true;
            this.id.Visible = true;
            this.id.VisibleIndex = 6;
            this.id.Width = 61;
            // 
            // filterstabpage
            // 
            this.filterstabpage.Controls.Add(this.assigncategory);
            this.filterstabpage.Controls.Add(this.filterType);
            this.filterstabpage.Controls.Add(this.refreshfilters);
            this.filterstabpage.Controls.Add(this.addfilter);
            this.filterstabpage.Controls.Add(this.deletefilters);
            this.filterstabpage.Controls.Add(this.filtersGridControl);
            this.filterstabpage.Image = global::WarehouseFrontend.Properties.Resources.bullet_feed;
            this.filterstabpage.Name = "filterstabpage";
            this.filterstabpage.Size = new System.Drawing.Size(503, 380);
            this.filterstabpage.Text = "filters";
            // 
            // assigncategory
            // 
            this.assigncategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.assigncategory.Location = new System.Drawing.Point(99, 354);
            this.assigncategory.Name = "assigncategory";
            this.assigncategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "assign category to selected", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "delete category", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.assigncategory.Size = new System.Drawing.Size(401, 20);
            this.assigncategory.TabIndex = 5;
            this.assigncategory.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.assigncategory_ButtonClick);
            // 
            // filterType
            // 
            this.filterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterType.Location = new System.Drawing.Point(59, 328);
            this.filterType.Name = "filterType";
            this.filterType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.filterType.Size = new System.Drawing.Size(115, 20);
            this.filterType.TabIndex = 4;
            this.filterType.ToolTip = "filter type";
            // 
            // refreshfilters
            // 
            this.refreshfilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshfilters.Location = new System.Drawing.Point(2, 326);
            this.refreshfilters.Name = "refreshfilters";
            this.refreshfilters.Size = new System.Drawing.Size(51, 23);
            this.refreshfilters.TabIndex = 3;
            this.refreshfilters.Text = "refresh";
            this.refreshfilters.Click += new System.EventHandler(this.refreshfilters_Click);
            // 
            // addfilter
            // 
            this.addfilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addfilter.Location = new System.Drawing.Point(178, 328);
            this.addfilter.Name = "addfilter";
            this.addfilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "add filter", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.addfilter.Size = new System.Drawing.Size(322, 20);
            this.addfilter.TabIndex = 2;
            this.addfilter.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.addfilter_ButtonClick);
            // 
            // deletefilters
            // 
            this.deletefilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deletefilters.Location = new System.Drawing.Point(2, 353);
            this.deletefilters.Name = "deletefilters";
            this.deletefilters.Size = new System.Drawing.Size(91, 23);
            this.deletefilters.TabIndex = 1;
            this.deletefilters.Text = "delete selected";
            this.deletefilters.Click += new System.EventHandler(this.deletefilters_Click);
            // 
            // filtersGridControl
            // 
            this.filtersGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersGridControl.Location = new System.Drawing.Point(2, 2);
            this.filtersGridControl.MainView = this.gridViewFilters;
            this.filtersGridControl.Name = "filtersGridControl";
            this.filtersGridControl.Size = new System.Drawing.Size(499, 319);
            this.filtersGridControl.TabIndex = 0;
            this.filtersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFilters});
            // 
            // gridViewFilters
            // 
            this.gridViewFilters.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.selected,
            this.filter,
            this.category,
            this.type});
            this.gridViewFilters.GridControl = this.filtersGridControl;
            this.gridViewFilters.Name = "gridViewFilters";
            this.gridViewFilters.OptionsView.ShowGroupPanel = false;
            // 
            // selected
            // 
            this.selected.Caption = " ";
            this.selected.FieldName = "selected";
            this.selected.Name = "selected";
            this.selected.OptionsColumn.FixedWidth = true;
            this.selected.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.selected.Visible = true;
            this.selected.VisibleIndex = 0;
            this.selected.Width = 20;
            // 
            // filter
            // 
            this.filter.Caption = "filter";
            this.filter.FieldName = "filter";
            this.filter.Name = "filter";
            this.filter.OptionsColumn.AllowEdit = false;
            this.filter.OptionsColumn.ReadOnly = true;
            this.filter.Visible = true;
            this.filter.VisibleIndex = 1;
            this.filter.Width = 325;
            // 
            // category
            // 
            this.category.Caption = "category";
            this.category.FieldName = "category";
            this.category.Name = "category";
            this.category.OptionsColumn.AllowEdit = false;
            this.category.OptionsColumn.ReadOnly = true;
            this.category.Visible = true;
            this.category.VisibleIndex = 2;
            this.category.Width = 102;
            // 
            // type
            // 
            this.type.Caption = "type";
            this.type.FieldName = "type";
            this.type.Name = "type";
            this.type.OptionsColumn.AllowEdit = false;
            this.type.OptionsColumn.ReadOnly = true;
            this.type.Visible = true;
            this.type.VisibleIndex = 3;
            // 
            // statsTabPage
            // 
            this.statsTabPage.Controls.Add(this.bwChartControl);
            this.statsTabPage.Controls.Add(this.panelControl2);
            this.statsTabPage.Controls.Add(this.panelControl1);
            this.statsTabPage.Image = global::WarehouseFrontend.Properties.Resources.chart_curve;
            this.statsTabPage.Name = "statsTabPage";
            this.statsTabPage.Size = new System.Drawing.Size(503, 380);
            this.statsTabPage.Text = "status";
            // 
            // bwChartControl
            // 
            this.bwChartControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            xyDiagram1.AxisX.DateTimeGridAlignment = DevExpress.XtraCharts.DateTimeMeasurementUnit.Second;
            xyDiagram1.AxisX.DateTimeMeasureUnit = DevExpress.XtraCharts.DateTimeMeasurementUnit.Second;
            xyDiagram1.AxisX.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.MonthAndDay;
            xyDiagram1.AxisX.Label.Staggered = true;
            xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = false;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = false;
            xyDiagram1.AxisX.Visible = false;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            xyDiagram1.AxisY.NumericOptions.Precision = 1;
            xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisY.Title.Text = "mbit/s";
            xyDiagram1.AxisY.Title.Visible = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.bwChartControl.Diagram = xyDiagram1;
            this.bwChartControl.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.bwChartControl.Location = new System.Drawing.Point(3, 65);
            this.bwChartControl.Name = "bwChartControl";
            this.bwChartControl.PaletteName = "Mixed";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            pointSeriesLabel1.LineVisible = true;
            pointSeriesLabel1.Visible = false;
            series1.Label = pointSeriesLabel1;
            series1.Name = "download";
            splineAreaSeriesView1.MarkerOptions.Visible = false;
            series1.View = splineAreaSeriesView1;
            series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            pointSeriesLabel2.LineVisible = true;
            pointSeriesLabel2.Visible = false;
            series2.Label = pointSeriesLabel2;
            series2.Name = "upload";
            splineAreaSeriesView2.MarkerOptions.Visible = false;
            series2.View = splineAreaSeriesView2;
            this.bwChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            pointSeriesLabel3.LineVisible = true;
            this.bwChartControl.SeriesTemplate.Label = pointSeriesLabel3;
            splineAreaSeriesView3.Transparency = ((byte)(0));
            this.bwChartControl.SeriesTemplate.View = splineAreaSeriesView3;
            this.bwChartControl.Size = new System.Drawing.Size(497, 314);
            this.bwChartControl.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.pictureBox2);
            this.panelControl2.Controls.Add(this.totalsize);
            this.panelControl2.Controls.Add(this.label7);
            this.panelControl2.Controls.Add(this.rlscount);
            this.panelControl2.Controls.Add(this.label9);
            this.panelControl2.Controls.Add(this.getSiteStatsButton);
            this.panelControl2.Location = new System.Drawing.Point(221, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(249, 58);
            this.panelControl2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WarehouseFrontend.Properties.Resources.Scale;
            this.pictureBox2.Location = new System.Drawing.Point(5, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 32);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // totalsize
            // 
            this.totalsize.AutoSize = true;
            this.totalsize.Location = new System.Drawing.Point(139, 17);
            this.totalsize.Name = "totalsize";
            this.totalsize.Size = new System.Drawing.Size(0, 13);
            this.totalsize.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "total size:";
            // 
            // rlscount
            // 
            this.rlscount.AutoSize = true;
            this.rlscount.Location = new System.Drawing.Point(139, 4);
            this.rlscount.Name = "rlscount";
            this.rlscount.Size = new System.Drawing.Size(0, 13);
            this.rlscount.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "release count:";
            // 
            // getSiteStatsButton
            // 
            this.getSiteStatsButton.Location = new System.Drawing.Point(46, 34);
            this.getSiteStatsButton.Name = "getSiteStatsButton";
            this.getSiteStatsButton.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "get stats", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.getSiteStatsButton.Size = new System.Drawing.Size(199, 20);
            this.getSiteStatsButton.TabIndex = 1;
            this.getSiteStatsButton.TabStop = false;
            this.getSiteStatsButton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.getSiteStatsButton_ButtonClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Controls.Add(this.ulspeed);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.dlspeed);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.freespace);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(215, 58);
            this.panelControl1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WarehouseFrontend.Properties.Resources.ForkLift;
            this.pictureBox1.Location = new System.Drawing.Point(6, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ulspeed
            // 
            this.ulspeed.AutoSize = true;
            this.ulspeed.Location = new System.Drawing.Point(138, 36);
            this.ulspeed.Name = "ulspeed";
            this.ulspeed.Size = new System.Drawing.Size(0, 13);
            this.ulspeed.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "upload speed:";
            // 
            // dlspeed
            // 
            this.dlspeed.AutoSize = true;
            this.dlspeed.Location = new System.Drawing.Point(138, 23);
            this.dlspeed.Name = "dlspeed";
            this.dlspeed.Size = new System.Drawing.Size(0, 13);
            this.dlspeed.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "download speed:";
            // 
            // freespace
            // 
            this.freespace.AutoSize = true;
            this.freespace.Location = new System.Drawing.Point(138, 10);
            this.freespace.Name = "freespace";
            this.freespace.Size = new System.Drawing.Size(0, 13);
            this.freespace.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "free space:";
            // 
            // rtorrentTabPage
            // 
            this.rtorrentTabPage.Controls.Add(this.hidecompleted);
            this.rtorrentTabPage.Controls.Add(this.refreshTorrents);
            this.rtorrentTabPage.Controls.Add(this.torrentsGridControl);
            this.rtorrentTabPage.Image = global::WarehouseFrontend.Properties.Resources.lorry;
            this.rtorrentTabPage.Name = "rtorrentTabPage";
            this.rtorrentTabPage.Size = new System.Drawing.Size(503, 380);
            this.rtorrentTabPage.Text = "rtorrent";
            // 
            // hidecompleted
            // 
            this.hidecompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hidecompleted.EditValue = true;
            this.hidecompleted.Location = new System.Drawing.Point(3, 357);
            this.hidecompleted.Name = "hidecompleted";
            this.hidecompleted.Properties.Caption = "hide completed";
            this.hidecompleted.Size = new System.Drawing.Size(101, 19);
            this.hidecompleted.TabIndex = 2;
            this.hidecompleted.CheckedChanged += new System.EventHandler(this.hidecompleted_CheckedChanged);
            // 
            // refreshTorrents
            // 
            this.refreshTorrents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshTorrents.Location = new System.Drawing.Point(426, 354);
            this.refreshTorrents.Name = "refreshTorrents";
            this.refreshTorrents.Size = new System.Drawing.Size(75, 23);
            this.refreshTorrents.TabIndex = 1;
            this.refreshTorrents.Text = "refresh";
            this.refreshTorrents.Click += new System.EventHandler(this.refreshTorrents_Click);
            // 
            // torrentsGridControl
            // 
            this.torrentsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.torrentsGridControl.Location = new System.Drawing.Point(2, 2);
            this.torrentsGridControl.MainView = this.gridViewRtorrent;
            this.torrentsGridControl.Name = "torrentsGridControl";
            this.torrentsGridControl.Size = new System.Drawing.Size(499, 349);
            this.torrentsGridControl.TabIndex = 0;
            this.torrentsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRtorrent});
            // 
            // gridViewRtorrent
            // 
            this.gridViewRtorrent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.torrentName,
            this.downloadSpeed,
            this.uploadSpeed,
            this.fileCount,
            this.torrentSize,
            this.percentDone,
            this.timeLeft});
            this.gridViewRtorrent.GridControl = this.torrentsGridControl;
            this.gridViewRtorrent.Name = "gridViewRtorrent";
            this.gridViewRtorrent.OptionsView.ShowGroupPanel = false;
            this.gridViewRtorrent.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridViewRtorrent_CustomColumnSort);
            // 
            // torrentName
            // 
            this.torrentName.Caption = "name";
            this.torrentName.FieldName = "name";
            this.torrentName.Name = "torrentName";
            this.torrentName.OptionsColumn.AllowEdit = false;
            this.torrentName.OptionsColumn.ReadOnly = true;
            this.torrentName.Visible = true;
            this.torrentName.VisibleIndex = 0;
            this.torrentName.Width = 135;
            // 
            // downloadSpeed
            // 
            this.downloadSpeed.Caption = "dl (KiB/s)";
            this.downloadSpeed.FieldName = "downloadSpeedKiB";
            this.downloadSpeed.Name = "downloadSpeed";
            this.downloadSpeed.OptionsColumn.AllowEdit = false;
            this.downloadSpeed.OptionsColumn.ReadOnly = true;
            this.downloadSpeed.Visible = true;
            this.downloadSpeed.VisibleIndex = 1;
            this.downloadSpeed.Width = 62;
            // 
            // uploadSpeed
            // 
            this.uploadSpeed.Caption = "ul (KiB/s)";
            this.uploadSpeed.FieldName = "uploadSpeedKiB";
            this.uploadSpeed.Name = "uploadSpeed";
            this.uploadSpeed.OptionsColumn.AllowEdit = false;
            this.uploadSpeed.OptionsColumn.ReadOnly = true;
            this.uploadSpeed.Visible = true;
            this.uploadSpeed.VisibleIndex = 2;
            this.uploadSpeed.Width = 60;
            // 
            // fileCount
            // 
            this.fileCount.Caption = "files";
            this.fileCount.FieldName = "fileCount";
            this.fileCount.Name = "fileCount";
            this.fileCount.OptionsColumn.AllowEdit = false;
            this.fileCount.OptionsColumn.ReadOnly = true;
            this.fileCount.Visible = true;
            this.fileCount.VisibleIndex = 3;
            this.fileCount.Width = 38;
            // 
            // torrentSize
            // 
            this.torrentSize.Caption = "size";
            this.torrentSize.FieldName = "sizeString";
            this.torrentSize.Name = "torrentSize";
            this.torrentSize.OptionsColumn.AllowEdit = false;
            this.torrentSize.OptionsColumn.ReadOnly = true;
            this.torrentSize.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.torrentSize.Visible = true;
            this.torrentSize.VisibleIndex = 4;
            this.torrentSize.Width = 70;
            // 
            // percentDone
            // 
            this.percentDone.Caption = "%";
            this.percentDone.FieldName = "percentDone";
            this.percentDone.Name = "percentDone";
            this.percentDone.OptionsColumn.AllowEdit = false;
            this.percentDone.OptionsColumn.FixedWidth = true;
            this.percentDone.OptionsColumn.ReadOnly = true;
            this.percentDone.Visible = true;
            this.percentDone.VisibleIndex = 5;
            this.percentDone.Width = 42;
            // 
            // timeLeft
            // 
            this.timeLeft.Caption = "eta";
            this.timeLeft.FieldName = "timeLeft";
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.OptionsColumn.AllowEdit = false;
            this.timeLeft.OptionsColumn.FixedWidth = true;
            this.timeLeft.OptionsColumn.ReadOnly = true;
            this.timeLeft.Visible = true;
            this.timeLeft.VisibleIndex = 6;
            this.timeLeft.Width = 50;
            // 
            // notificationsTabPage
            // 
            this.notificationsTabPage.Image = global::WarehouseFrontend.Properties.Resources._new;
            this.notificationsTabPage.Name = "notificationsTabPage";
            this.notificationsTabPage.Size = new System.Drawing.Size(503, 380);
            this.notificationsTabPage.Text = "notifications";
            // 
            // bwtimer
            // 
            this.bwtimer.Interval = 2000;
            this.bwtimer.Tick += new System.EventHandler(this.bwtimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 416);
            this.Controls.Add(this.xtraTabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(498, 238);
            this.Name = "MainForm";
            this.Text = "warehouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.searchtabpage.ResumeLayout(false);
            this.searchtabpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchsite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadbyid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSearch)).EndInit();
            this.filterstabpage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assigncategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addfilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFilters)).EndInit();
            this.statsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bwChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSiteStatsButton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.rtorrentTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hidecompleted.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.torrentsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRtorrent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage filterstabpage;
        private DevExpress.XtraTab.XtraTabPage searchtabpage;
        private DevExpress.XtraGrid.GridControl filtersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFilters;
        private DevExpress.XtraGrid.Columns.GridColumn selected;
        private DevExpress.XtraGrid.Columns.GridColumn filter;
        private DevExpress.XtraEditors.SimpleButton deletefilters;
        private DevExpress.XtraGrid.GridControl searchResultsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSearch;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn section;
        private DevExpress.XtraGrid.Columns.GridColumn size;
        private DevExpress.XtraGrid.Columns.GridColumn date;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraTab.XtraTabPage statsTabPage;
        private DevExpress.XtraGrid.Columns.GridColumn category;
        private DevExpress.XtraEditors.ButtonEdit downloadbyid;
        private DevExpress.XtraEditors.ButtonEdit searchButton;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label ulspeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dlspeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label freespace;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label totalsize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label rlscount;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraCharts.ChartControl bwChartControl;
        private DevExpress.XtraEditors.ButtonEdit addfilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer bwtimer;
        private DevExpress.XtraEditors.SimpleButton refreshfilters;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ComboBoxEdit getSiteStatsButton;
        private DevExpress.XtraEditors.ComboBoxEdit searchsite;
        private DevExpress.XtraEditors.ComboBoxEdit filterType;
        private DevExpress.XtraGrid.Columns.GridColumn site;
        private DevExpress.XtraGrid.Columns.GridColumn type;
        private DevExpress.XtraTab.XtraTabPage rtorrentTabPage;
        private DevExpress.XtraGrid.GridControl torrentsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRtorrent;
        private DevExpress.XtraGrid.Columns.GridColumn torrentName;
        private DevExpress.XtraGrid.Columns.GridColumn downloadSpeed;
        private DevExpress.XtraGrid.Columns.GridColumn uploadSpeed;
        private DevExpress.XtraGrid.Columns.GridColumn fileCount;
        private DevExpress.XtraGrid.Columns.GridColumn torrentSize;
        private DevExpress.XtraGrid.Columns.GridColumn percentDone;
        private DevExpress.XtraEditors.SimpleButton refreshTorrents;
        private DevExpress.XtraEditors.ButtonEdit assigncategory;
        private DevExpress.XtraEditors.CheckEdit hidecompleted;
        private DevExpress.XtraGrid.Columns.GridColumn timeLeft;
        private DevExpress.XtraGrid.Columns.GridColumn seeds;
        private DevExpress.XtraTab.XtraTabPage notificationsTabPage;
    }
}

