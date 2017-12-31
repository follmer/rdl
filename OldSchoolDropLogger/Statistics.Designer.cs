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
			this.labelSplits28 = new System.Windows.Forms.Label();
			this.labelSplits27 = new System.Windows.Forms.Label();
			this.labelSplits26 = new System.Windows.Forms.Label();
			this.labelSplits25 = new System.Windows.Forms.Label();
			this.labelSplits24 = new System.Windows.Forms.Label();
			this.labelSplits23 = new System.Windows.Forms.Label();
			this.labelSplits22 = new System.Windows.Forms.Label();
			this.pictureBoxSplits28 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits27 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits26 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits25 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits24 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits23 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits22 = new System.Windows.Forms.PictureBox();
			this.labelSplits21 = new System.Windows.Forms.Label();
			this.labelSplits20 = new System.Windows.Forms.Label();
			this.labelSplits19 = new System.Windows.Forms.Label();
			this.labelSplits18 = new System.Windows.Forms.Label();
			this.labelSplits17 = new System.Windows.Forms.Label();
			this.labelSplits16 = new System.Windows.Forms.Label();
			this.labelSplits15 = new System.Windows.Forms.Label();
			this.labelSplits14 = new System.Windows.Forms.Label();
			this.labelSplits13 = new System.Windows.Forms.Label();
			this.labelSplits12 = new System.Windows.Forms.Label();
			this.labelSplits11 = new System.Windows.Forms.Label();
			this.labelSplits10 = new System.Windows.Forms.Label();
			this.labelSplits9 = new System.Windows.Forms.Label();
			this.labelSplits8 = new System.Windows.Forms.Label();
			this.labelSplits7 = new System.Windows.Forms.Label();
			this.labelSplits6 = new System.Windows.Forms.Label();
			this.labelSplits5 = new System.Windows.Forms.Label();
			this.labelSplits4 = new System.Windows.Forms.Label();
			this.labelSplits3 = new System.Windows.Forms.Label();
			this.labelSplits2 = new System.Windows.Forms.Label();
			this.labelSplits1 = new System.Windows.Forms.Label();
			this.pictureBoxSplits21 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits20 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits19 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits18 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits17 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits16 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits15 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits14 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits13 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits12 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits11 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits10 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits9 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits8 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits7 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits6 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits5 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits4 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits3 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits2 = new System.Windows.Forms.PictureBox();
			this.pictureBoxSplits1 = new System.Windows.Forms.PictureBox();
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits28)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits27)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits26)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits25)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits24)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits23)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits22)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits21)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits20)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits19)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits18)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits17)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits16)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits15)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits14)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits13)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits1)).BeginInit();
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
			treeNode6.Name = "nodeSplitsDryStreaks";
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
			this.pictureBoxUniques0.BackgroundImage = global::OldSchoolDropLogger.Properties.Resources.icon_any;
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
			// labelSplits28
			// 
			this.labelSplits28.AutoSize = true;
			this.labelSplits28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits28.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits28.Location = new System.Drawing.Point(578, 400);
			this.labelSplits28.Name = "labelSplits28";
			this.labelSplits28.Size = new System.Drawing.Size(14, 15);
			this.labelSplits28.TabIndex = 1070;
			this.labelSplits28.Text = "0";
			this.labelSplits28.Visible = false;
			// 
			// labelSplits27
			// 
			this.labelSplits27.AutoSize = true;
			this.labelSplits27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits27.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits27.Location = new System.Drawing.Point(578, 346);
			this.labelSplits27.Name = "labelSplits27";
			this.labelSplits27.Size = new System.Drawing.Size(14, 15);
			this.labelSplits27.TabIndex = 1069;
			this.labelSplits27.Text = "0";
			this.labelSplits27.Visible = false;
			// 
			// labelSplits26
			// 
			this.labelSplits26.AutoSize = true;
			this.labelSplits26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits26.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits26.Location = new System.Drawing.Point(578, 292);
			this.labelSplits26.Name = "labelSplits26";
			this.labelSplits26.Size = new System.Drawing.Size(14, 15);
			this.labelSplits26.TabIndex = 1068;
			this.labelSplits26.Text = "0";
			this.labelSplits26.Visible = false;
			// 
			// labelSplits25
			// 
			this.labelSplits25.AutoSize = true;
			this.labelSplits25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits25.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits25.Location = new System.Drawing.Point(578, 238);
			this.labelSplits25.Name = "labelSplits25";
			this.labelSplits25.Size = new System.Drawing.Size(14, 15);
			this.labelSplits25.TabIndex = 1067;
			this.labelSplits25.Text = "0";
			this.labelSplits25.Visible = false;
			// 
			// labelSplits24
			// 
			this.labelSplits24.AutoSize = true;
			this.labelSplits24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits24.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits24.Location = new System.Drawing.Point(578, 184);
			this.labelSplits24.Name = "labelSplits24";
			this.labelSplits24.Size = new System.Drawing.Size(14, 15);
			this.labelSplits24.TabIndex = 1066;
			this.labelSplits24.Text = "0";
			this.labelSplits24.Visible = false;
			// 
			// labelSplits23
			// 
			this.labelSplits23.AutoSize = true;
			this.labelSplits23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits23.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits23.Location = new System.Drawing.Point(578, 130);
			this.labelSplits23.Name = "labelSplits23";
			this.labelSplits23.Size = new System.Drawing.Size(14, 15);
			this.labelSplits23.TabIndex = 1065;
			this.labelSplits23.Text = "0";
			this.labelSplits23.Visible = false;
			// 
			// labelSplits22
			// 
			this.labelSplits22.AutoSize = true;
			this.labelSplits22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits22.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits22.Location = new System.Drawing.Point(578, 76);
			this.labelSplits22.Name = "labelSplits22";
			this.labelSplits22.Size = new System.Drawing.Size(14, 15);
			this.labelSplits22.TabIndex = 1064;
			this.labelSplits22.Text = "0";
			this.labelSplits22.Visible = false;
			// 
			// pictureBoxSplits28
			// 
			this.pictureBoxSplits28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits28.Location = new System.Drawing.Point(536, 390);
			this.pictureBoxSplits28.Name = "pictureBoxSplits28";
			this.pictureBoxSplits28.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits28.TabIndex = 1063;
			this.pictureBoxSplits28.TabStop = false;
			// 
			// pictureBoxSplits27
			// 
			this.pictureBoxSplits27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits27.Location = new System.Drawing.Point(536, 336);
			this.pictureBoxSplits27.Name = "pictureBoxSplits27";
			this.pictureBoxSplits27.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits27.TabIndex = 1062;
			this.pictureBoxSplits27.TabStop = false;
			// 
			// pictureBoxSplits26
			// 
			this.pictureBoxSplits26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits26.Location = new System.Drawing.Point(536, 282);
			this.pictureBoxSplits26.Name = "pictureBoxSplits26";
			this.pictureBoxSplits26.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits26.TabIndex = 1061;
			this.pictureBoxSplits26.TabStop = false;
			// 
			// pictureBoxSplits25
			// 
			this.pictureBoxSplits25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits25.Location = new System.Drawing.Point(536, 228);
			this.pictureBoxSplits25.Name = "pictureBoxSplits25";
			this.pictureBoxSplits25.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits25.TabIndex = 1060;
			this.pictureBoxSplits25.TabStop = false;
			// 
			// pictureBoxSplits24
			// 
			this.pictureBoxSplits24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits24.Location = new System.Drawing.Point(536, 174);
			this.pictureBoxSplits24.Name = "pictureBoxSplits24";
			this.pictureBoxSplits24.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits24.TabIndex = 1059;
			this.pictureBoxSplits24.TabStop = false;
			// 
			// pictureBoxSplits23
			// 
			this.pictureBoxSplits23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits23.Location = new System.Drawing.Point(536, 120);
			this.pictureBoxSplits23.Name = "pictureBoxSplits23";
			this.pictureBoxSplits23.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits23.TabIndex = 1058;
			this.pictureBoxSplits23.TabStop = false;
			// 
			// pictureBoxSplits22
			// 
			this.pictureBoxSplits22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits22.Location = new System.Drawing.Point(536, 66);
			this.pictureBoxSplits22.Name = "pictureBoxSplits22";
			this.pictureBoxSplits22.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits22.TabIndex = 1057;
			this.pictureBoxSplits22.TabStop = false;
			// 
			// labelSplits21
			// 
			this.labelSplits21.AutoSize = true;
			this.labelSplits21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits21.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits21.Location = new System.Drawing.Point(469, 400);
			this.labelSplits21.Name = "labelSplits21";
			this.labelSplits21.Size = new System.Drawing.Size(14, 15);
			this.labelSplits21.TabIndex = 1056;
			this.labelSplits21.Text = "0";
			this.labelSplits21.Visible = false;
			// 
			// labelSplits20
			// 
			this.labelSplits20.AutoSize = true;
			this.labelSplits20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits20.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits20.Location = new System.Drawing.Point(469, 346);
			this.labelSplits20.Name = "labelSplits20";
			this.labelSplits20.Size = new System.Drawing.Size(14, 15);
			this.labelSplits20.TabIndex = 1055;
			this.labelSplits20.Text = "0";
			this.labelSplits20.Visible = false;
			// 
			// labelSplits19
			// 
			this.labelSplits19.AutoSize = true;
			this.labelSplits19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits19.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits19.Location = new System.Drawing.Point(469, 292);
			this.labelSplits19.Name = "labelSplits19";
			this.labelSplits19.Size = new System.Drawing.Size(14, 15);
			this.labelSplits19.TabIndex = 1054;
			this.labelSplits19.Text = "0";
			this.labelSplits19.Visible = false;
			// 
			// labelSplits18
			// 
			this.labelSplits18.AutoSize = true;
			this.labelSplits18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits18.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits18.Location = new System.Drawing.Point(469, 238);
			this.labelSplits18.Name = "labelSplits18";
			this.labelSplits18.Size = new System.Drawing.Size(14, 15);
			this.labelSplits18.TabIndex = 1053;
			this.labelSplits18.Text = "0";
			this.labelSplits18.Visible = false;
			// 
			// labelSplits17
			// 
			this.labelSplits17.AutoSize = true;
			this.labelSplits17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits17.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits17.Location = new System.Drawing.Point(469, 184);
			this.labelSplits17.Name = "labelSplits17";
			this.labelSplits17.Size = new System.Drawing.Size(14, 15);
			this.labelSplits17.TabIndex = 1052;
			this.labelSplits17.Text = "0";
			this.labelSplits17.Visible = false;
			// 
			// labelSplits16
			// 
			this.labelSplits16.AutoSize = true;
			this.labelSplits16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits16.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits16.Location = new System.Drawing.Point(469, 130);
			this.labelSplits16.Name = "labelSplits16";
			this.labelSplits16.Size = new System.Drawing.Size(14, 15);
			this.labelSplits16.TabIndex = 1051;
			this.labelSplits16.Text = "0";
			this.labelSplits16.Visible = false;
			// 
			// labelSplits15
			// 
			this.labelSplits15.AutoSize = true;
			this.labelSplits15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits15.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits15.Location = new System.Drawing.Point(469, 76);
			this.labelSplits15.Name = "labelSplits15";
			this.labelSplits15.Size = new System.Drawing.Size(14, 15);
			this.labelSplits15.TabIndex = 1050;
			this.labelSplits15.Text = "0";
			this.labelSplits15.Visible = false;
			// 
			// labelSplits14
			// 
			this.labelSplits14.AutoSize = true;
			this.labelSplits14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits14.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits14.Location = new System.Drawing.Point(360, 400);
			this.labelSplits14.Name = "labelSplits14";
			this.labelSplits14.Size = new System.Drawing.Size(14, 15);
			this.labelSplits14.TabIndex = 1049;
			this.labelSplits14.Text = "0";
			this.labelSplits14.Visible = false;
			// 
			// labelSplits13
			// 
			this.labelSplits13.AutoSize = true;
			this.labelSplits13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits13.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits13.Location = new System.Drawing.Point(360, 346);
			this.labelSplits13.Name = "labelSplits13";
			this.labelSplits13.Size = new System.Drawing.Size(14, 15);
			this.labelSplits13.TabIndex = 1048;
			this.labelSplits13.Text = "0";
			this.labelSplits13.Visible = false;
			// 
			// labelSplits12
			// 
			this.labelSplits12.AutoSize = true;
			this.labelSplits12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits12.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits12.Location = new System.Drawing.Point(360, 292);
			this.labelSplits12.Name = "labelSplits12";
			this.labelSplits12.Size = new System.Drawing.Size(14, 15);
			this.labelSplits12.TabIndex = 1047;
			this.labelSplits12.Text = "0";
			this.labelSplits12.Visible = false;
			// 
			// labelSplits11
			// 
			this.labelSplits11.AutoSize = true;
			this.labelSplits11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits11.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits11.Location = new System.Drawing.Point(360, 238);
			this.labelSplits11.Name = "labelSplits11";
			this.labelSplits11.Size = new System.Drawing.Size(14, 15);
			this.labelSplits11.TabIndex = 1046;
			this.labelSplits11.Text = "0";
			this.labelSplits11.Visible = false;
			// 
			// labelSplits10
			// 
			this.labelSplits10.AutoSize = true;
			this.labelSplits10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits10.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits10.Location = new System.Drawing.Point(360, 184);
			this.labelSplits10.Name = "labelSplits10";
			this.labelSplits10.Size = new System.Drawing.Size(14, 15);
			this.labelSplits10.TabIndex = 1045;
			this.labelSplits10.Text = "0";
			this.labelSplits10.Visible = false;
			// 
			// labelSplits9
			// 
			this.labelSplits9.AutoSize = true;
			this.labelSplits9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits9.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits9.Location = new System.Drawing.Point(360, 130);
			this.labelSplits9.Name = "labelSplits9";
			this.labelSplits9.Size = new System.Drawing.Size(14, 15);
			this.labelSplits9.TabIndex = 1044;
			this.labelSplits9.Text = "0";
			this.labelSplits9.Visible = false;
			// 
			// labelSplits8
			// 
			this.labelSplits8.AutoSize = true;
			this.labelSplits8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits8.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits8.Location = new System.Drawing.Point(360, 76);
			this.labelSplits8.Name = "labelSplits8";
			this.labelSplits8.Size = new System.Drawing.Size(14, 15);
			this.labelSplits8.TabIndex = 1043;
			this.labelSplits8.Text = "0";
			this.labelSplits8.Visible = false;
			// 
			// labelSplits7
			// 
			this.labelSplits7.AutoSize = true;
			this.labelSplits7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits7.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits7.Location = new System.Drawing.Point(251, 400);
			this.labelSplits7.Name = "labelSplits7";
			this.labelSplits7.Size = new System.Drawing.Size(14, 15);
			this.labelSplits7.TabIndex = 1042;
			this.labelSplits7.Text = "0";
			this.labelSplits7.Visible = false;
			// 
			// labelSplits6
			// 
			this.labelSplits6.AutoSize = true;
			this.labelSplits6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits6.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits6.Location = new System.Drawing.Point(251, 346);
			this.labelSplits6.Name = "labelSplits6";
			this.labelSplits6.Size = new System.Drawing.Size(14, 15);
			this.labelSplits6.TabIndex = 1041;
			this.labelSplits6.Text = "0";
			this.labelSplits6.Visible = false;
			// 
			// labelSplits5
			// 
			this.labelSplits5.AutoSize = true;
			this.labelSplits5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits5.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits5.Location = new System.Drawing.Point(251, 292);
			this.labelSplits5.Name = "labelSplits5";
			this.labelSplits5.Size = new System.Drawing.Size(14, 15);
			this.labelSplits5.TabIndex = 1040;
			this.labelSplits5.Text = "0";
			this.labelSplits5.Visible = false;
			// 
			// labelSplits4
			// 
			this.labelSplits4.AutoSize = true;
			this.labelSplits4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits4.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits4.Location = new System.Drawing.Point(251, 238);
			this.labelSplits4.Name = "labelSplits4";
			this.labelSplits4.Size = new System.Drawing.Size(14, 15);
			this.labelSplits4.TabIndex = 1039;
			this.labelSplits4.Text = "0";
			this.labelSplits4.Visible = false;
			// 
			// labelSplits3
			// 
			this.labelSplits3.AutoSize = true;
			this.labelSplits3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits3.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits3.Location = new System.Drawing.Point(251, 184);
			this.labelSplits3.Name = "labelSplits3";
			this.labelSplits3.Size = new System.Drawing.Size(14, 15);
			this.labelSplits3.TabIndex = 1038;
			this.labelSplits3.Text = "0";
			this.labelSplits3.Visible = false;
			// 
			// labelSplits2
			// 
			this.labelSplits2.AutoSize = true;
			this.labelSplits2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits2.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits2.Location = new System.Drawing.Point(251, 130);
			this.labelSplits2.Name = "labelSplits2";
			this.labelSplits2.Size = new System.Drawing.Size(14, 15);
			this.labelSplits2.TabIndex = 1037;
			this.labelSplits2.Text = "0";
			this.labelSplits2.Visible = false;
			// 
			// labelSplits1
			// 
			this.labelSplits1.AutoSize = true;
			this.labelSplits1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSplits1.ForeColor = System.Drawing.Color.Silver;
			this.labelSplits1.Location = new System.Drawing.Point(251, 76);
			this.labelSplits1.Name = "labelSplits1";
			this.labelSplits1.Size = new System.Drawing.Size(14, 15);
			this.labelSplits1.TabIndex = 1036;
			this.labelSplits1.Text = "0";
			this.labelSplits1.Visible = false;
			// 
			// pictureBoxSplits21
			// 
			this.pictureBoxSplits21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits21.Location = new System.Drawing.Point(427, 390);
			this.pictureBoxSplits21.Name = "pictureBoxSplits21";
			this.pictureBoxSplits21.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits21.TabIndex = 1035;
			this.pictureBoxSplits21.TabStop = false;
			// 
			// pictureBoxSplits20
			// 
			this.pictureBoxSplits20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits20.Location = new System.Drawing.Point(427, 336);
			this.pictureBoxSplits20.Name = "pictureBoxSplits20";
			this.pictureBoxSplits20.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits20.TabIndex = 1034;
			this.pictureBoxSplits20.TabStop = false;
			// 
			// pictureBoxSplits19
			// 
			this.pictureBoxSplits19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits19.Location = new System.Drawing.Point(427, 282);
			this.pictureBoxSplits19.Name = "pictureBoxSplits19";
			this.pictureBoxSplits19.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits19.TabIndex = 1033;
			this.pictureBoxSplits19.TabStop = false;
			// 
			// pictureBoxSplits18
			// 
			this.pictureBoxSplits18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits18.Location = new System.Drawing.Point(427, 228);
			this.pictureBoxSplits18.Name = "pictureBoxSplits18";
			this.pictureBoxSplits18.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits18.TabIndex = 1032;
			this.pictureBoxSplits18.TabStop = false;
			// 
			// pictureBoxSplits17
			// 
			this.pictureBoxSplits17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits17.Location = new System.Drawing.Point(427, 174);
			this.pictureBoxSplits17.Name = "pictureBoxSplits17";
			this.pictureBoxSplits17.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits17.TabIndex = 1031;
			this.pictureBoxSplits17.TabStop = false;
			// 
			// pictureBoxSplits16
			// 
			this.pictureBoxSplits16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits16.Location = new System.Drawing.Point(427, 120);
			this.pictureBoxSplits16.Name = "pictureBoxSplits16";
			this.pictureBoxSplits16.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits16.TabIndex = 1030;
			this.pictureBoxSplits16.TabStop = false;
			// 
			// pictureBoxSplits15
			// 
			this.pictureBoxSplits15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits15.Location = new System.Drawing.Point(427, 66);
			this.pictureBoxSplits15.Name = "pictureBoxSplits15";
			this.pictureBoxSplits15.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits15.TabIndex = 1029;
			this.pictureBoxSplits15.TabStop = false;
			// 
			// pictureBoxSplits14
			// 
			this.pictureBoxSplits14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits14.Location = new System.Drawing.Point(318, 390);
			this.pictureBoxSplits14.Name = "pictureBoxSplits14";
			this.pictureBoxSplits14.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits14.TabIndex = 1028;
			this.pictureBoxSplits14.TabStop = false;
			// 
			// pictureBoxSplits13
			// 
			this.pictureBoxSplits13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits13.Location = new System.Drawing.Point(318, 336);
			this.pictureBoxSplits13.Name = "pictureBoxSplits13";
			this.pictureBoxSplits13.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits13.TabIndex = 1027;
			this.pictureBoxSplits13.TabStop = false;
			// 
			// pictureBoxSplits12
			// 
			this.pictureBoxSplits12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits12.Location = new System.Drawing.Point(318, 282);
			this.pictureBoxSplits12.Name = "pictureBoxSplits12";
			this.pictureBoxSplits12.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits12.TabIndex = 1026;
			this.pictureBoxSplits12.TabStop = false;
			// 
			// pictureBoxSplits11
			// 
			this.pictureBoxSplits11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits11.Location = new System.Drawing.Point(318, 228);
			this.pictureBoxSplits11.Name = "pictureBoxSplits11";
			this.pictureBoxSplits11.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits11.TabIndex = 1025;
			this.pictureBoxSplits11.TabStop = false;
			// 
			// pictureBoxSplits10
			// 
			this.pictureBoxSplits10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits10.Location = new System.Drawing.Point(318, 174);
			this.pictureBoxSplits10.Name = "pictureBoxSplits10";
			this.pictureBoxSplits10.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits10.TabIndex = 1024;
			this.pictureBoxSplits10.TabStop = false;
			// 
			// pictureBoxSplits9
			// 
			this.pictureBoxSplits9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits9.Location = new System.Drawing.Point(318, 120);
			this.pictureBoxSplits9.Name = "pictureBoxSplits9";
			this.pictureBoxSplits9.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits9.TabIndex = 1023;
			this.pictureBoxSplits9.TabStop = false;
			// 
			// pictureBoxSplits8
			// 
			this.pictureBoxSplits8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits8.Location = new System.Drawing.Point(318, 66);
			this.pictureBoxSplits8.Name = "pictureBoxSplits8";
			this.pictureBoxSplits8.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits8.TabIndex = 1022;
			this.pictureBoxSplits8.TabStop = false;
			// 
			// pictureBoxSplits7
			// 
			this.pictureBoxSplits7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits7.Location = new System.Drawing.Point(209, 390);
			this.pictureBoxSplits7.Name = "pictureBoxSplits7";
			this.pictureBoxSplits7.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits7.TabIndex = 1021;
			this.pictureBoxSplits7.TabStop = false;
			// 
			// pictureBoxSplits6
			// 
			this.pictureBoxSplits6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits6.Location = new System.Drawing.Point(209, 336);
			this.pictureBoxSplits6.Name = "pictureBoxSplits6";
			this.pictureBoxSplits6.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits6.TabIndex = 1020;
			this.pictureBoxSplits6.TabStop = false;
			// 
			// pictureBoxSplits5
			// 
			this.pictureBoxSplits5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits5.Location = new System.Drawing.Point(209, 282);
			this.pictureBoxSplits5.Name = "pictureBoxSplits5";
			this.pictureBoxSplits5.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits5.TabIndex = 1019;
			this.pictureBoxSplits5.TabStop = false;
			// 
			// pictureBoxSplits4
			// 
			this.pictureBoxSplits4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits4.Location = new System.Drawing.Point(209, 228);
			this.pictureBoxSplits4.Name = "pictureBoxSplits4";
			this.pictureBoxSplits4.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits4.TabIndex = 1018;
			this.pictureBoxSplits4.TabStop = false;
			// 
			// pictureBoxSplits3
			// 
			this.pictureBoxSplits3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits3.Location = new System.Drawing.Point(209, 174);
			this.pictureBoxSplits3.Name = "pictureBoxSplits3";
			this.pictureBoxSplits3.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits3.TabIndex = 1017;
			this.pictureBoxSplits3.TabStop = false;
			// 
			// pictureBoxSplits2
			// 
			this.pictureBoxSplits2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits2.Location = new System.Drawing.Point(209, 120);
			this.pictureBoxSplits2.Name = "pictureBoxSplits2";
			this.pictureBoxSplits2.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits2.TabIndex = 1016;
			this.pictureBoxSplits2.TabStop = false;
			// 
			// pictureBoxSplits1
			// 
			this.pictureBoxSplits1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSplits1.Location = new System.Drawing.Point(209, 66);
			this.pictureBoxSplits1.Name = "pictureBoxSplits1";
			this.pictureBoxSplits1.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxSplits1.TabIndex = 1015;
			this.pictureBoxSplits1.TabStop = false;
			this.pictureBoxSplits1.Visible = false;
			// 
			// StatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(1001, 455);
			this.Controls.Add(this.labelSplits28);
			this.Controls.Add(this.labelSplits27);
			this.Controls.Add(this.labelSplits26);
			this.Controls.Add(this.labelSplits25);
			this.Controls.Add(this.labelSplits24);
			this.Controls.Add(this.labelSplits23);
			this.Controls.Add(this.labelSplits22);
			this.Controls.Add(this.pictureBoxSplits28);
			this.Controls.Add(this.pictureBoxSplits27);
			this.Controls.Add(this.pictureBoxSplits26);
			this.Controls.Add(this.pictureBoxSplits25);
			this.Controls.Add(this.pictureBoxSplits24);
			this.Controls.Add(this.pictureBoxSplits23);
			this.Controls.Add(this.pictureBoxSplits22);
			this.Controls.Add(this.labelSplits21);
			this.Controls.Add(this.labelSplits20);
			this.Controls.Add(this.labelSplits19);
			this.Controls.Add(this.labelSplits18);
			this.Controls.Add(this.labelSplits17);
			this.Controls.Add(this.labelSplits16);
			this.Controls.Add(this.labelSplits15);
			this.Controls.Add(this.labelSplits14);
			this.Controls.Add(this.labelSplits13);
			this.Controls.Add(this.labelSplits12);
			this.Controls.Add(this.labelSplits11);
			this.Controls.Add(this.labelSplits10);
			this.Controls.Add(this.labelSplits9);
			this.Controls.Add(this.labelSplits8);
			this.Controls.Add(this.labelSplits7);
			this.Controls.Add(this.labelSplits6);
			this.Controls.Add(this.labelSplits5);
			this.Controls.Add(this.labelSplits4);
			this.Controls.Add(this.labelSplits3);
			this.Controls.Add(this.labelSplits2);
			this.Controls.Add(this.labelSplits1);
			this.Controls.Add(this.pictureBoxSplits21);
			this.Controls.Add(this.pictureBoxSplits20);
			this.Controls.Add(this.pictureBoxSplits19);
			this.Controls.Add(this.pictureBoxSplits18);
			this.Controls.Add(this.pictureBoxSplits17);
			this.Controls.Add(this.pictureBoxSplits16);
			this.Controls.Add(this.pictureBoxSplits15);
			this.Controls.Add(this.pictureBoxSplits14);
			this.Controls.Add(this.pictureBoxSplits13);
			this.Controls.Add(this.pictureBoxSplits12);
			this.Controls.Add(this.pictureBoxSplits11);
			this.Controls.Add(this.pictureBoxSplits10);
			this.Controls.Add(this.pictureBoxSplits9);
			this.Controls.Add(this.pictureBoxSplits8);
			this.Controls.Add(this.pictureBoxSplits7);
			this.Controls.Add(this.pictureBoxSplits6);
			this.Controls.Add(this.pictureBoxSplits5);
			this.Controls.Add(this.pictureBoxSplits4);
			this.Controls.Add(this.pictureBoxSplits3);
			this.Controls.Add(this.pictureBoxSplits2);
			this.Controls.Add(this.pictureBoxSplits1);
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits28)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits27)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits26)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits25)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits24)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits23)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits22)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits21)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits20)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits19)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits18)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits17)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits16)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits15)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits14)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits13)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplits1)).EndInit();
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
		private Label labelSplits28;
		private Label labelSplits27;
		private Label labelSplits26;
		private Label labelSplits25;
		private Label labelSplits24;
		private Label labelSplits23;
		private Label labelSplits22;
		private PictureBox pictureBoxSplits28;
		private PictureBox pictureBoxSplits27;
		private PictureBox pictureBoxSplits26;
		private PictureBox pictureBoxSplits25;
		private PictureBox pictureBoxSplits24;
		private PictureBox pictureBoxSplits23;
		private PictureBox pictureBoxSplits22;
		private Label labelSplits21;
		private Label labelSplits20;
		private Label labelSplits19;
		private Label labelSplits18;
		private Label labelSplits17;
		private Label labelSplits16;
		private Label labelSplits15;
		private Label labelSplits14;
		private Label labelSplits13;
		private Label labelSplits12;
		private Label labelSplits11;
		private Label labelSplits10;
		private Label labelSplits9;
		private Label labelSplits8;
		private Label labelSplits7;
		private Label labelSplits6;
		private Label labelSplits5;
		private Label labelSplits4;
		private Label labelSplits3;
		private Label labelSplits2;
		private Label labelSplits1;
		private PictureBox pictureBoxSplits21;
		private PictureBox pictureBoxSplits20;
		private PictureBox pictureBoxSplits19;
		private PictureBox pictureBoxSplits18;
		private PictureBox pictureBoxSplits17;
		private PictureBox pictureBoxSplits16;
		private PictureBox pictureBoxSplits15;
		private PictureBox pictureBoxSplits14;
		private PictureBox pictureBoxSplits13;
		private PictureBox pictureBoxSplits12;
		private PictureBox pictureBoxSplits11;
		private PictureBox pictureBoxSplits10;
		private PictureBox pictureBoxSplits9;
		private PictureBox pictureBoxSplits8;
		private PictureBox pictureBoxSplits7;
		private PictureBox pictureBoxSplits6;
		private PictureBox pictureBoxSplits5;
		private PictureBox pictureBoxSplits4;
		private PictureBox pictureBoxSplits3;
		private PictureBox pictureBoxSplits2;
		private PictureBox pictureBoxSplits1;
	}
}