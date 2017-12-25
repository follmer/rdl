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
			this.statisticsNavigationTree = new System.Windows.Forms.TreeView();
			this.labelSideNavigation = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelViewingStatistic = new System.Windows.Forms.Label();
			this.dropdownSelectedBoss = new System.Windows.Forms.ComboBox();
			this.labelStatisticsBossSelected = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBoxUniquesAny = new System.Windows.Forms.PictureBox();
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
			this.labelUniquesAny = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniquesAny)).BeginInit();
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
			this.SuspendLayout();
			// 
			// statisticsNavigationTree
			// 
			this.statisticsNavigationTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.statisticsNavigationTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.statisticsNavigationTree.ForeColor = System.Drawing.Color.Silver;
			this.statisticsNavigationTree.Location = new System.Drawing.Point(-1, 41);
			this.statisticsNavigationTree.Name = "statisticsNavigationTree";
			treeNode1.Name = "childNodeTotalUniques";
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
			this.statisticsNavigationTree.TabIndex = 74;
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
			this.labelViewingStatistic.Location = new System.Drawing.Point(260, 12);
			this.labelViewingStatistic.Name = "labelViewingStatistic";
			this.labelViewingStatistic.Size = new System.Drawing.Size(124, 16);
			this.labelViewingStatistic.TabIndex = 79;
			this.labelViewingStatistic.Text = "Unique Dry Streaks";
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
			this.dropdownSelectedBoss.Location = new System.Drawing.Point(539, 10);
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
			this.labelStatisticsBossSelected.Location = new System.Drawing.Point(504, 13);
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
			this.panel2.Size = new System.Drawing.Size(673, 40);
			this.panel2.TabIndex = 77;
			// 
			// pictureBoxUniquesAny
			// 
			this.pictureBoxUniquesAny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniquesAny.Location = new System.Drawing.Point(209, 66);
			this.pictureBoxUniquesAny.Name = "pictureBoxUniquesAny";
			this.pictureBoxUniquesAny.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniquesAny.TabIndex = 78;
			this.pictureBoxUniquesAny.TabStop = false;
			// 
			// pictureBoxUniques1
			// 
			this.pictureBoxUniques1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques1.Location = new System.Drawing.Point(209, 120);
			this.pictureBoxUniques1.Name = "pictureBoxUniques1";
			this.pictureBoxUniques1.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques1.TabIndex = 79;
			this.pictureBoxUniques1.TabStop = false;
			// 
			// pictureBoxUniques2
			// 
			this.pictureBoxUniques2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques2.Location = new System.Drawing.Point(209, 174);
			this.pictureBoxUniques2.Name = "pictureBoxUniques2";
			this.pictureBoxUniques2.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques2.TabIndex = 80;
			this.pictureBoxUniques2.TabStop = false;
			// 
			// pictureBoxUniques3
			// 
			this.pictureBoxUniques3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques3.Location = new System.Drawing.Point(209, 228);
			this.pictureBoxUniques3.Name = "pictureBoxUniques3";
			this.pictureBoxUniques3.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques3.TabIndex = 81;
			this.pictureBoxUniques3.TabStop = false;
			// 
			// pictureBoxUniques4
			// 
			this.pictureBoxUniques4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques4.Location = new System.Drawing.Point(209, 282);
			this.pictureBoxUniques4.Name = "pictureBoxUniques4";
			this.pictureBoxUniques4.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques4.TabIndex = 82;
			this.pictureBoxUniques4.TabStop = false;
			// 
			// pictureBoxUniques5
			// 
			this.pictureBoxUniques5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques5.Location = new System.Drawing.Point(209, 336);
			this.pictureBoxUniques5.Name = "pictureBoxUniques5";
			this.pictureBoxUniques5.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques5.TabIndex = 83;
			this.pictureBoxUniques5.TabStop = false;
			// 
			// pictureBoxUniques6
			// 
			this.pictureBoxUniques6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques6.Location = new System.Drawing.Point(209, 390);
			this.pictureBoxUniques6.Name = "pictureBoxUniques6";
			this.pictureBoxUniques6.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques6.TabIndex = 84;
			this.pictureBoxUniques6.TabStop = false;
			// 
			// pictureBoxUniques13
			// 
			this.pictureBoxUniques13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques13.Location = new System.Drawing.Point(428, 390);
			this.pictureBoxUniques13.Name = "pictureBoxUniques13";
			this.pictureBoxUniques13.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques13.TabIndex = 91;
			this.pictureBoxUniques13.TabStop = false;
			// 
			// pictureBoxUniques12
			// 
			this.pictureBoxUniques12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques12.Location = new System.Drawing.Point(428, 336);
			this.pictureBoxUniques12.Name = "pictureBoxUniques12";
			this.pictureBoxUniques12.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques12.TabIndex = 90;
			this.pictureBoxUniques12.TabStop = false;
			// 
			// pictureBoxUniques11
			// 
			this.pictureBoxUniques11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques11.Location = new System.Drawing.Point(428, 282);
			this.pictureBoxUniques11.Name = "pictureBoxUniques11";
			this.pictureBoxUniques11.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques11.TabIndex = 89;
			this.pictureBoxUniques11.TabStop = false;
			// 
			// pictureBoxUniques10
			// 
			this.pictureBoxUniques10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques10.Location = new System.Drawing.Point(428, 228);
			this.pictureBoxUniques10.Name = "pictureBoxUniques10";
			this.pictureBoxUniques10.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques10.TabIndex = 88;
			this.pictureBoxUniques10.TabStop = false;
			// 
			// pictureBoxUniques9
			// 
			this.pictureBoxUniques9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques9.Location = new System.Drawing.Point(428, 174);
			this.pictureBoxUniques9.Name = "pictureBoxUniques9";
			this.pictureBoxUniques9.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques9.TabIndex = 87;
			this.pictureBoxUniques9.TabStop = false;
			// 
			// pictureBoxUniques8
			// 
			this.pictureBoxUniques8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques8.Location = new System.Drawing.Point(428, 120);
			this.pictureBoxUniques8.Name = "pictureBoxUniques8";
			this.pictureBoxUniques8.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques8.TabIndex = 86;
			this.pictureBoxUniques8.TabStop = false;
			// 
			// pictureBoxUniques7
			// 
			this.pictureBoxUniques7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques7.Location = new System.Drawing.Point(428, 66);
			this.pictureBoxUniques7.Name = "pictureBoxUniques7";
			this.pictureBoxUniques7.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques7.TabIndex = 85;
			this.pictureBoxUniques7.TabStop = false;
			// 
			// pictureBoxUniques20
			// 
			this.pictureBoxUniques20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques20.Location = new System.Drawing.Point(647, 390);
			this.pictureBoxUniques20.Name = "pictureBoxUniques20";
			this.pictureBoxUniques20.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques20.TabIndex = 98;
			this.pictureBoxUniques20.TabStop = false;
			// 
			// pictureBoxUniques19
			// 
			this.pictureBoxUniques19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques19.Location = new System.Drawing.Point(647, 336);
			this.pictureBoxUniques19.Name = "pictureBoxUniques19";
			this.pictureBoxUniques19.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques19.TabIndex = 97;
			this.pictureBoxUniques19.TabStop = false;
			// 
			// pictureBoxUniques18
			// 
			this.pictureBoxUniques18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques18.Location = new System.Drawing.Point(647, 282);
			this.pictureBoxUniques18.Name = "pictureBoxUniques18";
			this.pictureBoxUniques18.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques18.TabIndex = 96;
			this.pictureBoxUniques18.TabStop = false;
			// 
			// pictureBoxUniques17
			// 
			this.pictureBoxUniques17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques17.Location = new System.Drawing.Point(647, 228);
			this.pictureBoxUniques17.Name = "pictureBoxUniques17";
			this.pictureBoxUniques17.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques17.TabIndex = 95;
			this.pictureBoxUniques17.TabStop = false;
			// 
			// pictureBoxUniques16
			// 
			this.pictureBoxUniques16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques16.Location = new System.Drawing.Point(647, 174);
			this.pictureBoxUniques16.Name = "pictureBoxUniques16";
			this.pictureBoxUniques16.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques16.TabIndex = 94;
			this.pictureBoxUniques16.TabStop = false;
			// 
			// pictureBoxUniques15
			// 
			this.pictureBoxUniques15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques15.Location = new System.Drawing.Point(647, 120);
			this.pictureBoxUniques15.Name = "pictureBoxUniques15";
			this.pictureBoxUniques15.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques15.TabIndex = 93;
			this.pictureBoxUniques15.TabStop = false;
			// 
			// pictureBoxUniques14
			// 
			this.pictureBoxUniques14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxUniques14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxUniques14.Location = new System.Drawing.Point(647, 66);
			this.pictureBoxUniques14.Name = "pictureBoxUniques14";
			this.pictureBoxUniques14.Size = new System.Drawing.Size(35, 35);
			this.pictureBoxUniques14.TabIndex = 92;
			this.pictureBoxUniques14.TabStop = false;
			// 
			// labelUniquesAny
			// 
			this.labelUniquesAny.AutoSize = true;
			this.labelUniquesAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUniquesAny.ForeColor = System.Drawing.Color.Silver;
			this.labelUniquesAny.Location = new System.Drawing.Point(251, 76);
			this.labelUniquesAny.Name = "labelUniquesAny";
			this.labelUniquesAny.Size = new System.Drawing.Size(14, 15);
			this.labelUniquesAny.TabIndex = 99;
			this.labelUniquesAny.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Silver;
			this.label1.Location = new System.Drawing.Point(251, 130);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 15);
			this.label1.TabIndex = 100;
			this.label1.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Silver;
			this.label2.Location = new System.Drawing.Point(251, 184);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 15);
			this.label2.TabIndex = 101;
			this.label2.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Silver;
			this.label3.Location = new System.Drawing.Point(251, 346);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 15);
			this.label3.TabIndex = 104;
			this.label3.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Silver;
			this.label4.Location = new System.Drawing.Point(251, 292);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(14, 15);
			this.label4.TabIndex = 103;
			this.label4.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Silver;
			this.label5.Location = new System.Drawing.Point(251, 238);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 15);
			this.label5.TabIndex = 102;
			this.label5.Text = "0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.Silver;
			this.label6.Location = new System.Drawing.Point(251, 400);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 15);
			this.label6.TabIndex = 105;
			this.label6.Text = "0";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Silver;
			this.label7.Location = new System.Drawing.Point(470, 400);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 15);
			this.label7.TabIndex = 112;
			this.label7.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.Silver;
			this.label8.Location = new System.Drawing.Point(470, 346);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(14, 15);
			this.label8.TabIndex = 111;
			this.label8.Text = "0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.Silver;
			this.label9.Location = new System.Drawing.Point(470, 292);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(14, 15);
			this.label9.TabIndex = 110;
			this.label9.Text = "0";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.Silver;
			this.label10.Location = new System.Drawing.Point(470, 238);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(14, 15);
			this.label10.TabIndex = 109;
			this.label10.Text = "0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Silver;
			this.label11.Location = new System.Drawing.Point(470, 184);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(14, 15);
			this.label11.TabIndex = 108;
			this.label11.Text = "0";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.Silver;
			this.label12.Location = new System.Drawing.Point(470, 130);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(14, 15);
			this.label12.TabIndex = 107;
			this.label12.Text = "0";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.Silver;
			this.label13.Location = new System.Drawing.Point(470, 76);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(14, 15);
			this.label13.TabIndex = 106;
			this.label13.Text = "0";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.Silver;
			this.label14.Location = new System.Drawing.Point(689, 400);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(14, 15);
			this.label14.TabIndex = 119;
			this.label14.Text = "0";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.ForeColor = System.Drawing.Color.Silver;
			this.label15.Location = new System.Drawing.Point(689, 346);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(14, 15);
			this.label15.TabIndex = 118;
			this.label15.Text = "0";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.Color.Silver;
			this.label16.Location = new System.Drawing.Point(689, 292);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(14, 15);
			this.label16.TabIndex = 117;
			this.label16.Text = "0";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.ForeColor = System.Drawing.Color.Silver;
			this.label17.Location = new System.Drawing.Point(689, 238);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(14, 15);
			this.label17.TabIndex = 116;
			this.label17.Text = "0";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.Silver;
			this.label18.Location = new System.Drawing.Point(689, 184);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(14, 15);
			this.label18.TabIndex = 115;
			this.label18.Text = "0";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.ForeColor = System.Drawing.Color.Silver;
			this.label19.Location = new System.Drawing.Point(689, 130);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(14, 15);
			this.label19.TabIndex = 114;
			this.label19.Text = "0";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.ForeColor = System.Drawing.Color.Silver;
			this.label20.Location = new System.Drawing.Point(689, 76);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(14, 15);
			this.label20.TabIndex = 113;
			this.label20.Text = "0";
			// 
			// StatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(851, 455);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelUniquesAny);
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
			this.Controls.Add(this.pictureBoxUniquesAny);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statisticsNavigationTree);
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "StatisticsForm";
			this.Text = "Statistics";
			this.Load += new System.EventHandler(this.StatisticsForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUniquesAny)).EndInit();
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
		private PictureBox pictureBoxUniquesAny;
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
		private Label labelUniquesAny;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label11;
		private Label label12;
		private Label label13;
		private Label label14;
		private Label label15;
		private Label label16;
		private Label label17;
		private Label label18;
		private Label label19;
		private Label label20;
	}
}