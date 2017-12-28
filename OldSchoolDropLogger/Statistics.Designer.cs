using System.Windows.Forms;

namespace stats {
	partial class StatisticsForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Total Uniques");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Expected Personal Uniques");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Dry Streaks");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Uniques", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Drops");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Dry Streaks");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Splits", new System.Windows.Forms.TreeNode[] {
            treeNode6});
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("GP Per Hour");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("GP", new System.Windows.Forms.TreeNode[] {
            treeNode8});
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Kill Count");
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 4D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 7D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 6D);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
			this.statisticsNavigationTree = new System.Windows.Forms.TreeView();
			this.labelSideNavigation = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelViewingStatistic = new System.Windows.Forms.Label();
			this.dropdownSelectedBoss = new System.Windows.Forms.ComboBox();
			this.labelStatisticsBossSelected = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBoxUniques0 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques2 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques3 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques4 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques5 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques6 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques13 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques12 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques11 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques10 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques9 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques8 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques7 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques20 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques19 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques18 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques17 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques16 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques15 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques14 = new System.Windows.Forms.PictureBox();
			this.labelUniques0 = new System.Windows.Forms.Label();
			this.labelUniques1 = new System.Windows.Forms.Label();
			this.labelUniques2 = new System.Windows.Forms.Label();
			this.labelUniques5 = new System.Windows.Forms.Label();
			this.labelUniques4 = new System.Windows.Forms.Label();
			this.labelUniques3 = new System.Windows.Forms.Label();
			this.labelUniques6 = new System.Windows.Forms.Label();
			this.labelUniques13 = new System.Windows.Forms.Label();
			this.labelUniques12 = new System.Windows.Forms.Label();
			this.labelUniques11 = new System.Windows.Forms.Label();
			this.labelUniques10 = new System.Windows.Forms.Label();
			this.labelUniques9 = new System.Windows.Forms.Label();
			this.labelUniques8 = new System.Windows.Forms.Label();
			this.labelUniques7 = new System.Windows.Forms.Label();
			this.labelUniques20 = new System.Windows.Forms.Label();
			this.labelUniques19 = new System.Windows.Forms.Label();
			this.labelUniques18 = new System.Windows.Forms.Label();
			this.labelUniques17 = new System.Windows.Forms.Label();
			this.labelUniques16 = new System.Windows.Forms.Label();
			this.labelUniques15 = new System.Windows.Forms.Label();
			this.labelUniques14 = new System.Windows.Forms.Label();
			this.labelUniques27 = new System.Windows.Forms.Label();
			this.labelUniques26 = new System.Windows.Forms.Label();
			this.labelUniques25 = new System.Windows.Forms.Label();
			this.labelUniques24 = new System.Windows.Forms.Label();
			this.labelUniques23 = new System.Windows.Forms.Label();
			this.labelUniques22 = new System.Windows.Forms.Label();
			this.labelUniques21 = new System.Windows.Forms.Label();
			this.pictureBoxUniques27 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques26 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques25 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques24 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques23 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques22 = new System.Windows.Forms.PictureBox();
			this.pictureBoxUniques21 = new System.Windows.Forms.PictureBox();
			this.chartUniques = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques0)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques13)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques20)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques19)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques18)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques17)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques16)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques15)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques14)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques27)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques26)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques25)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques24)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques23)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques22)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques21)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartUniques)).BeginInit();
			this.SuspendLayout();
			// 
			// statisticsNavigationTree
			// 
			this.statisticsNavigationTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.statisticsNavigationTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.statisticsNavigationTree.ForeColor = System.Drawing.Color.Silver;
			this.statisticsNavigationTree.Location = new System.Drawing.Point(-1, 41);
			this.statisticsNavigationTree.Name = "statisticsNavigationTree";
			treeNode1.Name = "nodeUniquesTotalUniques";
			treeNode1.Text = "Total Uniques";
			treeNode2.Name = "Node1";
			treeNode2.Text = "Expected Personal Uniques";
			treeNode3.Name = "nodeUniquesDryStreaks";
			treeNode3.Text = "Dry Streaks";
			treeNode4.Name = "rootNodeUniques";
			treeNode4.Text = "Uniques";
			treeNode5.Name = "rootNodeDrops";
			treeNode5.Text = "Drops";
			treeNode6.Name = "Node2";
			treeNode6.Text = "Dry Streaks";
			treeNode7.Name = "rootNodeSplits";
			treeNode7.Text = "Splits";
			treeNode8.Name = "Node0";
			treeNode8.Text = "GP Per Hour";
			treeNode9.Name = "rootNodeGP";
			treeNode9.Text = "GP";
			treeNode10.Name = "rootNodeKillCount";
			treeNode10.Text = "Kill Count";
			this.statisticsNavigationTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode7,
            treeNode9,
            treeNode10});
			this.statisticsNavigationTree.Size = new System.Drawing.Size(179, 415);
			this.statisticsNavigationTree.TabIndex = 999;
			this.statisticsNavigationTree.TabStop = false;
			this.statisticsNavigationTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.statisticsNavigationTree_AfterSelect);
			// 
			// labelSideNavigation
			// 
			this.labelSideNavigation.AutoSize = true;
			this.labelSideNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.labelSideNavigation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSideNavigation.Location = new System.Drawing.Point(48, 12);
			this.labelSideNavigation.Name = "labelSideNavigation";
			this.labelSideNavigation.Size = new System.Drawing.Size(73, 16);
			this.labelSideNavigation.TabIndex = 75;
			this.labelSideNavigation.Text = "Navigation";
			this.labelSideNavigation.Click += new System.EventHandler(this.labelSideNavigation_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.panel1.Controls.Add(this.labelSideNavigation);
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(179, 40);
			this.panel1.TabIndex = 76;
			// 
			// labelViewingStatistic
			// 
			this.labelViewingStatistic.AutoSize = true;
			this.labelViewingStatistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelViewingStatistic.Location = new System.Drawing.Point(298, 12);
			this.labelViewingStatistic.Name = "labelViewingStatistic";
			this.labelViewingStatistic.Size = new System.Drawing.Size(132, 16);
			this.labelViewingStatistic.TabIndex = 79;
			this.labelViewingStatistic.Text = "No Statistic Selected";
			this.labelViewingStatistic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// dropdownSelectedBoss
			// 
			this.dropdownSelectedBoss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.dropdownSelectedBoss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dropdownSelectedBoss.ForeColor = System.Drawing.Color.Silver;
			this.dropdownSelectedBoss.FormattingEnabled = true;
			this.dropdownSelectedBoss.Items.AddRange(new object[] {
            "Abyssal Sire",
            "Armadyl",
            "Bandos",
            "Barrows",
            "Callisto",
            "Cerberus",
            "Chaos Elemental",
            "Chaos Fanatic",
            "Corporeal Beast",
            "Crazy Archaeologist",
            "Dagannoth Kings",
            "Giant Mole",
            "Grotesque Guardians",
            "Kalphite Queen",
            "King Black Dragon",
            "Kraken",
            "Raids",
            "Saradomin",
            "Scorpia",
            "Skotizo",
            "Thermy",
            "Venenatis",
            "Vet\'ion",
            "Wintertodt",
            "Zamorak",
            "Zulrah"});
			this.dropdownSelectedBoss.Location = new System.Drawing.Point(689, 10);
			this.dropdownSelectedBoss.MaxDropDownItems = 64;
			this.dropdownSelectedBoss.Name = "dropdownSelectedBoss";
			this.dropdownSelectedBoss.Size = new System.Drawing.Size(121, 21);
			this.dropdownSelectedBoss.Sorted = true;
			this.dropdownSelectedBoss.TabIndex = 80;
			this.dropdownSelectedBoss.SelectedIndexChanged += new System.EventHandler(this.dropdownSelectedBoss_SelectedIndexChanged);
			// 
			// labelStatisticsBossSelected
			// 
			this.labelStatisticsBossSelected.AutoSize = true;
			this.labelStatisticsBossSelected.Location = new System.Drawing.Point(654, 13);
			this.labelStatisticsBossSelected.Name = "labelStatisticsBossSelected";
			this.labelStatisticsBossSelected.Size = new System.Drawing.Size(33, 13);
			this.labelStatisticsBossSelected.TabIndex = 81;
			this.labelStatisticsBossSelected.Text = "Boss:";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.panel2.Controls.Add(this.labelViewingStatistic);
			this.panel2.Controls.Add(this.labelStatisticsBossSelected);
			this.panel2.Controls.Add(this.dropdownSelectedBoss);
			this.panel2.Location = new System.Drawing.Point(179, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(821, 40);
			this.panel2.TabIndex = 77;
			// 
			// pictureBoxUniques0
			// 
			this.pictureBoxUniques0.BackgroundImage = global::OldSchoolDropLogger.Properties.Resources.uniques_icon_any;
			this.pictureBoxUniques0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques0.Location = new System.Drawing.Point(209, 66);
			this.pictureBoxUniques0.Name = "pictureBoxUniques0";
			this.pictureBoxUniques0.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques0.TabIndex = 78;
			this.pictureBoxUniques0.TabStop = false;
			this.pictureBoxUniques0.Visible = false;
			// 
			// pictureBoxUniques1
			// 
			this.pictureBoxUniques1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques1.Location = new System.Drawing.Point(209, 120);
			this.pictureBoxUniques1.Name = "pictureBoxUniques1";
			this.pictureBoxUniques1.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques1.TabIndex = 79;
			this.pictureBoxUniques1.TabStop = false;
			// 
			// pictureBoxUniques2
			// 
			this.pictureBoxUniques2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques2.Location = new System.Drawing.Point(209, 174);
			this.pictureBoxUniques2.Name = "pictureBoxUniques2";
			this.pictureBoxUniques2.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques2.TabIndex = 80;
			this.pictureBoxUniques2.TabStop = false;
			// 
			// pictureBoxUniques3
			// 
			this.pictureBoxUniques3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques3.Location = new System.Drawing.Point(209, 228);
			this.pictureBoxUniques3.Name = "pictureBoxUniques3";
			this.pictureBoxUniques3.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques3.TabIndex = 81;
			this.pictureBoxUniques3.TabStop = false;
			// 
			// pictureBoxUniques4
			// 
			this.pictureBoxUniques4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques4.Location = new System.Drawing.Point(209, 282);
			this.pictureBoxUniques4.Name = "pictureBoxUniques4";
			this.pictureBoxUniques4.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques4.TabIndex = 82;
			this.pictureBoxUniques4.TabStop = false;
			// 
			// pictureBoxUniques5
			// 
			this.pictureBoxUniques5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques5.Location = new System.Drawing.Point(209, 336);
			this.pictureBoxUniques5.Name = "pictureBoxUniques5";
			this.pictureBoxUniques5.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques5.TabIndex = 83;
			this.pictureBoxUniques5.TabStop = false;
			// 
			// pictureBoxUniques6
			// 
			this.pictureBoxUniques6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques6.Location = new System.Drawing.Point(209, 390);
			this.pictureBoxUniques6.Name = "pictureBoxUniques6";
			this.pictureBoxUniques6.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques6.TabIndex = 84;
			this.pictureBoxUniques6.TabStop = false;
			// 
			// pictureBoxUniques13
			// 
			this.pictureBoxUniques13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques13.Location = new System.Drawing.Point(318, 390);
			this.pictureBoxUniques13.Name = "pictureBoxUniques13";
			this.pictureBoxUniques13.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques13.TabIndex = 91;
			this.pictureBoxUniques13.TabStop = false;
			// 
			// pictureBoxUniques12
			// 
			this.pictureBoxUniques12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques12.Location = new System.Drawing.Point(318, 336);
			this.pictureBoxUniques12.Name = "pictureBoxUniques12";
			this.pictureBoxUniques12.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques12.TabIndex = 90;
			this.pictureBoxUniques12.TabStop = false;
			// 
			// pictureBoxUniques11
			// 
			this.pictureBoxUniques11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques11.Location = new System.Drawing.Point(318, 282);
			this.pictureBoxUniques11.Name = "pictureBoxUniques11";
			this.pictureBoxUniques11.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques11.TabIndex = 89;
			this.pictureBoxUniques11.TabStop = false;
			// 
			// pictureBoxUniques10
			// 
			this.pictureBoxUniques10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques10.Location = new System.Drawing.Point(318, 228);
			this.pictureBoxUniques10.Name = "pictureBoxUniques10";
			this.pictureBoxUniques10.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques10.TabIndex = 88;
			this.pictureBoxUniques10.TabStop = false;
			// 
			// pictureBoxUniques9
			// 
			this.pictureBoxUniques9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques9.Location = new System.Drawing.Point(318, 174);
			this.pictureBoxUniques9.Name = "pictureBoxUniques9";
			this.pictureBoxUniques9.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques9.TabIndex = 87;
			this.pictureBoxUniques9.TabStop = false;
			// 
			// pictureBoxUniques8
			// 
			this.pictureBoxUniques8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques8.Location = new System.Drawing.Point(318, 120);
			this.pictureBoxUniques8.Name = "pictureBoxUniques8";
			this.pictureBoxUniques8.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques8.TabIndex = 86;
			this.pictureBoxUniques8.TabStop = false;
			// 
			// pictureBoxUniques7
			// 
			this.pictureBoxUniques7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques7.Location = new System.Drawing.Point(318, 66);
			this.pictureBoxUniques7.Name = "pictureBoxUniques7";
			this.pictureBoxUniques7.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques7.TabIndex = 85;
			this.pictureBoxUniques7.TabStop = false;
			// 
			// pictureBoxUniques20
			// 
			this.pictureBoxUniques20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques20.Location = new System.Drawing.Point(427, 390);
			this.pictureBoxUniques20.Name = "pictureBoxUniques20";
			this.pictureBoxUniques20.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques20.TabIndex = 98;
			this.pictureBoxUniques20.TabStop = false;
			// 
			// pictureBoxUniques19
			// 
			this.pictureBoxUniques19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques19.Location = new System.Drawing.Point(427, 336);
			this.pictureBoxUniques19.Name = "pictureBoxUniques19";
			this.pictureBoxUniques19.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques19.TabIndex = 97;
			this.pictureBoxUniques19.TabStop = false;
			// 
			// pictureBoxUniques18
			// 
			this.pictureBoxUniques18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques18.Location = new System.Drawing.Point(427, 282);
			this.pictureBoxUniques18.Name = "pictureBoxUniques18";
			this.pictureBoxUniques18.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques18.TabIndex = 96;
			this.pictureBoxUniques18.TabStop = false;
			// 
			// pictureBoxUniques17
			// 
			this.pictureBoxUniques17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques17.Location = new System.Drawing.Point(427, 228);
			this.pictureBoxUniques17.Name = "pictureBoxUniques17";
			this.pictureBoxUniques17.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques17.TabIndex = 95;
			this.pictureBoxUniques17.TabStop = false;
			// 
			// pictureBoxUniques16
			// 
			this.pictureBoxUniques16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques16.Location = new System.Drawing.Point(427, 174);
			this.pictureBoxUniques16.Name = "pictureBoxUniques16";
			this.pictureBoxUniques16.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques16.TabIndex = 94;
			this.pictureBoxUniques16.TabStop = false;
			// 
			// pictureBoxUniques15
			// 
			this.pictureBoxUniques15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques15.Location = new System.Drawing.Point(427, 120);
			this.pictureBoxUniques15.Name = "pictureBoxUniques15";
			this.pictureBoxUniques15.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques15.TabIndex = 93;
			this.pictureBoxUniques15.TabStop = false;
			// 
			// pictureBoxUniques14
			// 
			this.pictureBoxUniques14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques14.Location = new System.Drawing.Point(427, 66);
			this.pictureBoxUniques14.Name = "pictureBoxUniques14";
			this.pictureBoxUniques14.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques14.TabIndex = 92;
			this.pictureBoxUniques14.TabStop = false;
			// 
			// labelUniques0
			// 
			this.labelUniques0.AutoSize = true;
			this.labelUniques0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques0.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques0.Location = new System.Drawing.Point(251, 76);
			this.labelUniques0.Name = "labelUniques0";
			this.labelUniques0.Size = new System.Drawing.Size(14, 15);
			this.labelUniques0.TabIndex = 99;
			this.labelUniques0.Text = "0";
			this.labelUniques0.Visible = false;
			// 
			// labelUniques1
			// 
			this.labelUniques1.AutoSize = true;
			this.labelUniques1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques1.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques1.Location = new System.Drawing.Point(251, 130);
			this.labelUniques1.Name = "labelUniques1";
			this.labelUniques1.Size = new System.Drawing.Size(14, 15);
			this.labelUniques1.TabIndex = 100;
			this.labelUniques1.Text = "0";
			this.labelUniques1.Visible = false;
			// 
			// labelUniques2
			// 
			this.labelUniques2.AutoSize = true;
			this.labelUniques2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques2.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques2.Location = new System.Drawing.Point(251, 184);
			this.labelUniques2.Name = "labelUniques2";
			this.labelUniques2.Size = new System.Drawing.Size(14, 15);
			this.labelUniques2.TabIndex = 101;
			this.labelUniques2.Text = "0";
			this.labelUniques2.Visible = false;
			// 
			// labelUniques5
			// 
			this.labelUniques5.AutoSize = true;
			this.labelUniques5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques5.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques5.Location = new System.Drawing.Point(251, 346);
			this.labelUniques5.Name = "labelUniques5";
			this.labelUniques5.Size = new System.Drawing.Size(14, 15);
			this.labelUniques5.TabIndex = 104;
			this.labelUniques5.Text = "0";
			this.labelUniques5.Visible = false;
			// 
			// labelUniques4
			// 
			this.labelUniques4.AutoSize = true;
			this.labelUniques4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques4.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques4.Location = new System.Drawing.Point(251, 292);
			this.labelUniques4.Name = "labelUniques4";
			this.labelUniques4.Size = new System.Drawing.Size(14, 15);
			this.labelUniques4.TabIndex = 103;
			this.labelUniques4.Text = "0";
			this.labelUniques4.Visible = false;
			// 
			// labelUniques3
			// 
			this.labelUniques3.AutoSize = true;
			this.labelUniques3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques3.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques3.Location = new System.Drawing.Point(251, 238);
			this.labelUniques3.Name = "labelUniques3";
			this.labelUniques3.Size = new System.Drawing.Size(14, 15);
			this.labelUniques3.TabIndex = 102;
			this.labelUniques3.Text = "0";
			this.labelUniques3.Visible = false;
			// 
			// labelUniques6
			// 
			this.labelUniques6.AutoSize = true;
			this.labelUniques6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques6.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques6.Location = new System.Drawing.Point(251, 400);
			this.labelUniques6.Name = "labelUniques6";
			this.labelUniques6.Size = new System.Drawing.Size(14, 15);
			this.labelUniques6.TabIndex = 105;
			this.labelUniques6.Text = "0";
			this.labelUniques6.Visible = false;
			// 
			// labelUniques13
			// 
			this.labelUniques13.AutoSize = true;
			this.labelUniques13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques13.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques13.Location = new System.Drawing.Point(360, 400);
			this.labelUniques13.Name = "labelUniques13";
			this.labelUniques13.Size = new System.Drawing.Size(14, 15);
			this.labelUniques13.TabIndex = 112;
			this.labelUniques13.Text = "0";
			this.labelUniques13.Visible = false;
			// 
			// labelUniques12
			// 
			this.labelUniques12.AutoSize = true;
			this.labelUniques12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques12.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques12.Location = new System.Drawing.Point(360, 346);
			this.labelUniques12.Name = "labelUniques12";
			this.labelUniques12.Size = new System.Drawing.Size(14, 15);
			this.labelUniques12.TabIndex = 111;
			this.labelUniques12.Text = "0";
			this.labelUniques12.Visible = false;
			// 
			// labelUniques11
			// 
			this.labelUniques11.AutoSize = true;
			this.labelUniques11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques11.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques11.Location = new System.Drawing.Point(360, 292);
			this.labelUniques11.Name = "labelUniques11";
			this.labelUniques11.Size = new System.Drawing.Size(14, 15);
			this.labelUniques11.TabIndex = 110;
			this.labelUniques11.Text = "0";
			this.labelUniques11.Visible = false;
			// 
			// labelUniques10
			// 
			this.labelUniques10.AutoSize = true;
			this.labelUniques10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques10.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques10.Location = new System.Drawing.Point(360, 238);
			this.labelUniques10.Name = "labelUniques10";
			this.labelUniques10.Size = new System.Drawing.Size(14, 15);
			this.labelUniques10.TabIndex = 109;
			this.labelUniques10.Text = "0";
			this.labelUniques10.Visible = false;
			// 
			// labelUniques9
			// 
			this.labelUniques9.AutoSize = true;
			this.labelUniques9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques9.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques9.Location = new System.Drawing.Point(360, 184);
			this.labelUniques9.Name = "labelUniques9";
			this.labelUniques9.Size = new System.Drawing.Size(14, 15);
			this.labelUniques9.TabIndex = 108;
			this.labelUniques9.Text = "0";
			this.labelUniques9.Visible = false;
			// 
			// labelUniques8
			// 
			this.labelUniques8.AutoSize = true;
			this.labelUniques8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques8.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques8.Location = new System.Drawing.Point(360, 130);
			this.labelUniques8.Name = "labelUniques8";
			this.labelUniques8.Size = new System.Drawing.Size(14, 15);
			this.labelUniques8.TabIndex = 107;
			this.labelUniques8.Text = "0";
			this.labelUniques8.Visible = false;
			// 
			// labelUniques7
			// 
			this.labelUniques7.AutoSize = true;
			this.labelUniques7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques7.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques7.Location = new System.Drawing.Point(360, 76);
			this.labelUniques7.Name = "labelUniques7";
			this.labelUniques7.Size = new System.Drawing.Size(14, 15);
			this.labelUniques7.TabIndex = 106;
			this.labelUniques7.Text = "0";
			this.labelUniques7.Visible = false;
			// 
			// labelUniques20
			// 
			this.labelUniques20.AutoSize = true;
			this.labelUniques20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques20.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques20.Location = new System.Drawing.Point(469, 400);
			this.labelUniques20.Name = "labelUniques20";
			this.labelUniques20.Size = new System.Drawing.Size(14, 15);
			this.labelUniques20.TabIndex = 119;
			this.labelUniques20.Text = "0";
			this.labelUniques20.Visible = false;
			// 
			// labelUniques19
			// 
			this.labelUniques19.AutoSize = true;
			this.labelUniques19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques19.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques19.Location = new System.Drawing.Point(469, 346);
			this.labelUniques19.Name = "labelUniques19";
			this.labelUniques19.Size = new System.Drawing.Size(14, 15);
			this.labelUniques19.TabIndex = 118;
			this.labelUniques19.Text = "0";
			this.labelUniques19.Visible = false;
			// 
			// labelUniques18
			// 
			this.labelUniques18.AutoSize = true;
			this.labelUniques18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques18.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques18.Location = new System.Drawing.Point(469, 292);
			this.labelUniques18.Name = "labelUniques18";
			this.labelUniques18.Size = new System.Drawing.Size(14, 15);
			this.labelUniques18.TabIndex = 117;
			this.labelUniques18.Text = "0";
			this.labelUniques18.Visible = false;
			// 
			// labelUniques17
			// 
			this.labelUniques17.AutoSize = true;
			this.labelUniques17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques17.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques17.Location = new System.Drawing.Point(469, 238);
			this.labelUniques17.Name = "labelUniques17";
			this.labelUniques17.Size = new System.Drawing.Size(14, 15);
			this.labelUniques17.TabIndex = 116;
			this.labelUniques17.Text = "0";
			this.labelUniques17.Visible = false;
			// 
			// labelUniques16
			// 
			this.labelUniques16.AutoSize = true;
			this.labelUniques16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques16.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques16.Location = new System.Drawing.Point(469, 184);
			this.labelUniques16.Name = "labelUniques16";
			this.labelUniques16.Size = new System.Drawing.Size(14, 15);
			this.labelUniques16.TabIndex = 115;
			this.labelUniques16.Text = "0";
			this.labelUniques16.Visible = false;
			// 
			// labelUniques15
			// 
			this.labelUniques15.AutoSize = true;
			this.labelUniques15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques15.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques15.Location = new System.Drawing.Point(469, 130);
			this.labelUniques15.Name = "labelUniques15";
			this.labelUniques15.Size = new System.Drawing.Size(14, 15);
			this.labelUniques15.TabIndex = 114;
			this.labelUniques15.Text = "0";
			this.labelUniques15.Visible = false;
			// 
			// labelUniques14
			// 
			this.labelUniques14.AutoSize = true;
			this.labelUniques14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques14.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques14.Location = new System.Drawing.Point(469, 76);
			this.labelUniques14.Name = "labelUniques14";
			this.labelUniques14.Size = new System.Drawing.Size(14, 15);
			this.labelUniques14.TabIndex = 113;
			this.labelUniques14.Text = "0";
			this.labelUniques14.Visible = false;
			// 
			// labelUniques27
			// 
			this.labelUniques27.AutoSize = true;
			this.labelUniques27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques27.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques27.Location = new System.Drawing.Point(578, 400);
			this.labelUniques27.Name = "labelUniques27";
			this.labelUniques27.Size = new System.Drawing.Size(14, 15);
			this.labelUniques27.TabIndex = 133;
			this.labelUniques27.Text = "0";
			this.labelUniques27.Visible = false;
			// 
			// labelUniques26
			// 
			this.labelUniques26.AutoSize = true;
			this.labelUniques26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques26.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques26.Location = new System.Drawing.Point(578, 346);
			this.labelUniques26.Name = "labelUniques26";
			this.labelUniques26.Size = new System.Drawing.Size(14, 15);
			this.labelUniques26.TabIndex = 132;
			this.labelUniques26.Text = "0";
			this.labelUniques26.Visible = false;
			// 
			// labelUniques25
			// 
			this.labelUniques25.AutoSize = true;
			this.labelUniques25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques25.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques25.Location = new System.Drawing.Point(578, 292);
			this.labelUniques25.Name = "labelUniques25";
			this.labelUniques25.Size = new System.Drawing.Size(14, 15);
			this.labelUniques25.TabIndex = 131;
			this.labelUniques25.Text = "0";
			this.labelUniques25.Visible = false;
			// 
			// labelUniques24
			// 
			this.labelUniques24.AutoSize = true;
			this.labelUniques24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques24.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques24.Location = new System.Drawing.Point(578, 238);
			this.labelUniques24.Name = "labelUniques24";
			this.labelUniques24.Size = new System.Drawing.Size(14, 15);
			this.labelUniques24.TabIndex = 130;
			this.labelUniques24.Text = "0";
			this.labelUniques24.Visible = false;
			// 
			// labelUniques23
			// 
			this.labelUniques23.AutoSize = true;
			this.labelUniques23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques23.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques23.Location = new System.Drawing.Point(578, 184);
			this.labelUniques23.Name = "labelUniques23";
			this.labelUniques23.Size = new System.Drawing.Size(14, 15);
			this.labelUniques23.TabIndex = 129;
			this.labelUniques23.Text = "0";
			this.labelUniques23.Visible = false;
			// 
			// labelUniques22
			// 
			this.labelUniques22.AutoSize = true;
			this.labelUniques22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques22.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques22.Location = new System.Drawing.Point(578, 130);
			this.labelUniques22.Name = "labelUniques22";
			this.labelUniques22.Size = new System.Drawing.Size(14, 15);
			this.labelUniques22.TabIndex = 128;
			this.labelUniques22.Text = "0";
			this.labelUniques22.Visible = false;
			// 
			// labelUniques21
			// 
			this.labelUniques21.AutoSize = true;
			this.labelUniques21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniques21.ForeColor = System.Drawing.Color.Silver;
			this.labelUniques21.Location = new System.Drawing.Point(578, 76);
			this.labelUniques21.Name = "labelUniques21";
			this.labelUniques21.Size = new System.Drawing.Size(14, 15);
			this.labelUniques21.TabIndex = 127;
			this.labelUniques21.Text = "0";
			this.labelUniques21.Visible = false;
			// 
			// pictureBoxUniques27
			// 
			this.pictureBoxUniques27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques27.Location = new System.Drawing.Point(536, 390);
			this.pictureBoxUniques27.Name = "pictureBoxUniques27";
			this.pictureBoxUniques27.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques27.TabIndex = 126;
			this.pictureBoxUniques27.TabStop = false;
			// 
			// pictureBoxUniques26
			// 
			this.pictureBoxUniques26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques26.Location = new System.Drawing.Point(536, 336);
			this.pictureBoxUniques26.Name = "pictureBoxUniques26";
			this.pictureBoxUniques26.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques26.TabIndex = 125;
			this.pictureBoxUniques26.TabStop = false;
			// 
			// pictureBoxUniques25
			// 
			this.pictureBoxUniques25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques25.Location = new System.Drawing.Point(536, 282);
			this.pictureBoxUniques25.Name = "pictureBoxUniques25";
			this.pictureBoxUniques25.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques25.TabIndex = 124;
			this.pictureBoxUniques25.TabStop = false;
			// 
			// pictureBoxUniques24
			// 
			this.pictureBoxUniques24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques24.Location = new System.Drawing.Point(536, 228);
			this.pictureBoxUniques24.Name = "pictureBoxUniques24";
			this.pictureBoxUniques24.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques24.TabIndex = 123;
			this.pictureBoxUniques24.TabStop = false;
			// 
			// pictureBoxUniques23
			// 
			this.pictureBoxUniques23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques23.Location = new System.Drawing.Point(536, 174);
			this.pictureBoxUniques23.Name = "pictureBoxUniques23";
			this.pictureBoxUniques23.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques23.TabIndex = 122;
			this.pictureBoxUniques23.TabStop = false;
			// 
			// pictureBoxUniques22
			// 
			this.pictureBoxUniques22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques22.Location = new System.Drawing.Point(536, 120);
			this.pictureBoxUniques22.Name = "pictureBoxUniques22";
			this.pictureBoxUniques22.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques22.TabIndex = 121;
			this.pictureBoxUniques22.TabStop = false;
			// 
			// pictureBoxUniques21
			// 
			this.pictureBoxUniques21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques21.Location = new System.Drawing.Point(536, 66);
			this.pictureBoxUniques21.Name = "pictureBoxUniques21";
			this.pictureBoxUniques21.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques21.TabIndex = 120;
			this.pictureBoxUniques21.TabStop = false;
			// 
			// chartUniques
			// 
			this.chartUniques.BackColor = System.Drawing.Color.Transparent;
			chartArea1.BackColor = System.Drawing.Color.Transparent;
			chartArea1.Name = "chartUniques";
			this.chartUniques.ChartAreas.Add(chartArea1);
			legend1.Alignment = System.Drawing.StringAlignment.Center;
			legend1.BackColor = System.Drawing.Color.Transparent;
			legend1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			legend1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
			legend1.ForeColor = System.Drawing.Color.Silver;
			legend1.Name = "chartUniquesLegend";
			legend1.Title = "Boss";
			legend1.TitleBackColor = System.Drawing.Color.Transparent;
			legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			legend1.TitleForeColor = System.Drawing.Color.Silver;
			legend1.TitleSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.GradientLine;
			legend1.TitleSeparatorColor = System.Drawing.Color.Silver;
			this.chartUniques.Legends.Add(legend1);
			this.chartUniques.Location = new System.Drawing.Point(598, 41);
			this.chartUniques.Name = "chartUniques";
			series1.BorderColor = System.Drawing.Color.DimGray;
			series1.BorderWidth = 3;
			series1.ChartArea = "chartUniques";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
			series1.Color = System.Drawing.Color.White;
			series1.CustomProperties = "DoughnutRadius=50";
			series1.Legend = "chartUniquesLegend";
			series1.Name = "chartUniquesData";
			dataPoint1.Color = System.Drawing.Color.White;
			dataPoint1.Label = "test\\ntest";
			dataPoint1.LabelBackColor = System.Drawing.Color.Transparent;
			dataPoint1.LabelBorderColor = System.Drawing.Color.White;
			dataPoint1.LabelForeColor = System.Drawing.Color.Black;
			dataPoint1.LegendText = "t";
			dataPoint1.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			dataPoint1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			dataPoint1.MarkerImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			dataPoint1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
			series1.Points.Add(dataPoint1);
			series1.Points.Add(dataPoint2);
			series1.Points.Add(dataPoint3);
			series1.Points.Add(dataPoint4);
			series1.Points.Add(dataPoint5);
			series1.Points.Add(dataPoint6);
			this.chartUniques.Series.Add(series1);
			this.chartUniques.Size = new System.Drawing.Size(402, 415);
			this.chartUniques.TabIndex = 1014;
			this.chartUniques.Text = "chartUniques";
			// 
			// StatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(1001, 455);
			this.Controls.Add(this.chartUniques);
			this.Controls.Add(this.labelUniques27);
			this.Controls.Add(this.labelUniques26);
			this.Controls.Add(this.labelUniques25);
			this.Controls.Add(this.labelUniques24);
			this.Controls.Add(this.labelUniques23);
			this.Controls.Add(this.labelUniques22);
			this.Controls.Add(this.labelUniques21);
			this.Controls.Add(this.pictureBoxUniques27);
			this.Controls.Add(this.pictureBoxUniques26);
			this.Controls.Add(this.pictureBoxUniques25);
			this.Controls.Add(this.pictureBoxUniques24);
			this.Controls.Add(this.pictureBoxUniques23);
			this.Controls.Add(this.pictureBoxUniques22);
			this.Controls.Add(this.pictureBoxUniques21);
			this.Controls.Add(this.labelUniques20);
			this.Controls.Add(this.labelUniques19);
			this.Controls.Add(this.labelUniques18);
			this.Controls.Add(this.labelUniques17);
			this.Controls.Add(this.labelUniques16);
			this.Controls.Add(this.labelUniques15);
			this.Controls.Add(this.labelUniques14);
			this.Controls.Add(this.labelUniques13);
			this.Controls.Add(this.labelUniques12);
			this.Controls.Add(this.labelUniques11);
			this.Controls.Add(this.labelUniques10);
			this.Controls.Add(this.labelUniques9);
			this.Controls.Add(this.labelUniques8);
			this.Controls.Add(this.labelUniques7);
			this.Controls.Add(this.labelUniques6);
			this.Controls.Add(this.labelUniques5);
			this.Controls.Add(this.labelUniques4);
			this.Controls.Add(this.labelUniques3);
			this.Controls.Add(this.labelUniques2);
			this.Controls.Add(this.labelUniques1);
			this.Controls.Add(this.labelUniques0);
			this.Controls.Add(this.pictureBoxUniques20);
			this.Controls.Add(this.pictureBoxUniques19);
			this.Controls.Add(this.pictureBoxUniques18);
			this.Controls.Add(this.pictureBoxUniques17);
			this.Controls.Add(this.pictureBoxUniques16);
			this.Controls.Add(this.pictureBoxUniques15);
			this.Controls.Add(this.pictureBoxUniques14);
			this.Controls.Add(this.pictureBoxUniques13);
			this.Controls.Add(this.pictureBoxUniques12);
			this.Controls.Add(this.pictureBoxUniques11);
			this.Controls.Add(this.pictureBoxUniques10);
			this.Controls.Add(this.pictureBoxUniques9);
			this.Controls.Add(this.pictureBoxUniques8);
			this.Controls.Add(this.pictureBoxUniques7);
			this.Controls.Add(this.pictureBoxUniques6);
			this.Controls.Add(this.pictureBoxUniques5);
			this.Controls.Add(this.pictureBoxUniques4);
			this.Controls.Add(this.pictureBoxUniques3);
			this.Controls.Add(this.pictureBoxUniques2);
			this.Controls.Add(this.pictureBoxUniques1);
			this.Controls.Add(this.pictureBoxUniques0);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statisticsNavigationTree);
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StatisticsForm";
			this.Text = "Statistics";
			this.Load += new System.EventHandler(this.StatisticsForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques0)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques13)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques20)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques19)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques18)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques17)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques16)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques15)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques14)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques27)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques26)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques25)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques24)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques23)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques22)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniques21)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartUniques)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private TreeView statisticsNavigationTree;
		private Label labelSideNavigation;
		private Panel panel1;
		private Label labelViewingStatistic;
		private ComboBox dropdownSelectedBoss;
		private Label labelStatisticsBossSelected;
		private Panel panel2;
		private PictureBox pictureBoxUniques0;
		private PictureBox pictureBoxUniques1;
		private PictureBox pictureBoxUniques2;
		private PictureBox pictureBoxUniques3;
		private PictureBox pictureBoxUniques4;
		private PictureBox pictureBoxUniques5;
		private PictureBox pictureBoxUniques6;
		private PictureBox pictureBoxUniques13;
		private PictureBox pictureBoxUniques12;
		private PictureBox pictureBoxUniques11;
		private PictureBox pictureBoxUniques10;
		private PictureBox pictureBoxUniques9;
		private PictureBox pictureBoxUniques8;
		private PictureBox pictureBoxUniques7;
		private PictureBox pictureBoxUniques20;
		private PictureBox pictureBoxUniques19;
		private PictureBox pictureBoxUniques18;
		private PictureBox pictureBoxUniques17;
		private PictureBox pictureBoxUniques16;
		private PictureBox pictureBoxUniques15;
		private PictureBox pictureBoxUniques14;
		private Label labelUniques0;
		private Label labelUniques1;
		private Label labelUniques2;
		private Label labelUniques5;
		private Label labelUniques4;
		private Label labelUniques3;
		private Label labelUniques6;
		private Label labelUniques13;
		private Label labelUniques12;
		private Label labelUniques11;
		private Label labelUniques10;
		private Label labelUniques9;
		private Label labelUniques8;
		private Label labelUniques7;
		private Label labelUniques20;
		private Label labelUniques19;
		private Label labelUniques18;
		private Label labelUniques17;
		private Label labelUniques16;
		private Label labelUniques15;
		private Label labelUniques14;
		private Label labelUniques27;
		private Label labelUniques26;
		private Label labelUniques25;
		private Label labelUniques24;
		private Label labelUniques23;
		private Label labelUniques22;
		private Label labelUniques21;
		private PictureBox pictureBoxUniques27;
		private PictureBox pictureBoxUniques26;
		private PictureBox pictureBoxUniques25;
		private PictureBox pictureBoxUniques24;
		private PictureBox pictureBoxUniques23;
		private PictureBox pictureBoxUniques22;
		private PictureBox pictureBoxUniques21;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartUniques;
	}
}