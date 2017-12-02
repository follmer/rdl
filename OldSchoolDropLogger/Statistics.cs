using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using itemQuantityCreator;
using dropLogger;
using System.Diagnostics;

namespace stats {
	public partial class StatisticsForm : Form {

		/* Vars */
		public Dictionary<String, int> killsPerBoss;
		ToolTip tt = new ToolTip();
		ItemQuantityCreator iqc;
		//Dictionary<String, int> itemQuantities = new Dictionary<String, int>();
		private String logsFilePath = AppDomain.CurrentDomain.BaseDirectory + "/logs/";
		private List<String> allBossStrings = new List<String>();
		private Dictionary<String, Boolean> sidebarActiveStatistic = new Dictionary<String, Boolean>();
		private TreeView treeView1;
		private Label labelSideNavigation;
		private Panel panel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private Button button1;
		public Dictionary<String, Dictionary<String, int>> totalDropsFromAllBosses;

		/* Getters & Setters */
		public Dictionary<String, int> getTotalKillsLoggedPerBoss() {
			return killsPerBoss;
		}
		public Dictionary<String, int> setTotalKillsLoggedPerBoss() {
			killsPerBoss = new Dictionary<String, int>();

			foreach (String s in allBossStrings) {
				if (File.Exists(logsFilePath + s + ".txt")) {

					var file = File.ReadAllLines(logsFilePath + s + ".txt");
					List<String> lines = new List<String>(file);
					killsPerBoss[s] = lines.Count;
				}
				else {
					killsPerBoss[s] = 0;
				}
			}

			Console.WriteLine("Statistics.setTotalKillsLoggedPerBoss()");

			return killsPerBoss;
		}
		public int getBossKills(String boss) {
			return killsPerBoss[boss];
		}
		public int getTotalKills() {

			int sumOfKills = 0;

			Dictionary<String, int> kpb = getTotalKillsLoggedPerBoss();

			foreach (KeyValuePair<String, int> kv in kpb) {
				sumOfKills += kv.Value;
			}

			return sumOfKills;
		}
		/*private int getItemQuantity(String item) {
			if (itemQuantities.ContainsKey(item)) {
				return itemQuantities[item];
			}
			else return 0;
		}*/
		private List<String> getAllBossStrings() {
			return allBossStrings;
		}
		public List<String> getUniquesFromBoss(string boss) {

			if (File.Exists(logsFilePath + boss + " Uniques.txt")) {

				// Get the lines from the file
				var file = File.ReadAllLines(logsFilePath + boss + " Uniques.txt");

				// Convert the lines in the file to a list
				List<String> drops = new List<String>(file);

				return drops;
			}
			else {
				Console.WriteLine("[ERROR]: " + boss + " Uniques.txt at path: " + logsFilePath + " does not exist.");
			}

			return null;
		}
		private String getCurrentBoss() {
			return "getCurrentBoss() incomplete";
		}
		public Dictionary<String, int> getItemQuantitiesFromBoss(string boss) {
			if (totalDropsFromAllBosses.ContainsKey(boss)) {
				return totalDropsFromAllBosses[boss];
			}

			return null;
		}
		public Dictionary<String, Dictionary<String, int>> getTotalDropsFromAllBosses() {
			return totalDropsFromAllBosses;
		}
		private void clearDropsFromAllBosses() {
			Dictionary<String, Dictionary<String, int>> temp = totalDropsFromAllBosses;
			foreach (KeyValuePair<String, Dictionary<String, int>> dict in totalDropsFromAllBosses.ToArray()) {

				String boss = dict.Key;

				foreach (KeyValuePair<String, int> kvp in totalDropsFromAllBosses[dict.Key].ToArray()) {
					
					String item = kvp.Key;

					totalDropsFromAllBosses[boss][item] = 0;
				}
			}
		}
		public void setTotalDropsFromAllBosses() {

			if (!isClassInitialized()) return; 
			// Otherwise the class is already created and the function keeps adding to the quantity, giving us incorrect quantities
			clearDropsFromAllBosses();

			foreach (String boss in getAllBossStrings()) {

				if (File.Exists(logsFilePath + boss + ".txt")) {

					// Get the lines from the file
					var file = File.ReadAllLines(logsFilePath + boss + ".txt");
					List<String> lines = new List<String>(file);

					// Loop through the lines in the file
					for (int i = 0; i < lines.Count; i++) {
						
						// Trim the leading number (i.e. 104.) from the string
						// OR
						// Trim the leading space from " RDT:"
						if (lines[i].Contains(".")) {
							lines[i] = lines[i].Substring(lines[i].IndexOf(".") + 2);
						}
						else if (lines[i].Contains(":")) {
							lines[i] = lines[i].Substring(lines[i].IndexOf(":") + 1);
						}


						// Split drop on the comma - will do nothing if the drop isn't a multidrop,
						// but will count all multidrops correctly
						String[] drops = lines[i].Split(',');
						
						for (int j = 0; j < drops.Length; j++) {

							// Trim all the drops
							drops[j] = drops[j].Trim();

							String drop = drops[j];

							int dropQuantity = 0;

							// If the drop is variable, it is indicated by [v]. This needs to be removed
							// and the item substrung to not include the "x <quantity>". Quantity will be kept
							// since a custom quantity needs to be added to the drop rather than just +1
							if (drop.Contains("[v]")) {
								int xIndex = drop.IndexOf(" x ");

								String ssDrop = drop.Substring(0, xIndex);

								// Where to start counting the quantity
								int qtyStart = xIndex + 3;

								try {

									// -1 to stay in bounds of string and -3 to remove '[v]' = -4
									bool smallerThan32Bit = int.TryParse(drop.Substring(qtyStart, drop.Length - qtyStart - 4), out dropQuantity);

									// Number logged was > 2147m
									// TODO check this logic
									if (!smallerThan32Bit) {
										dropQuantity = 2147000000;
									}

									// Special case for rdt
									if (ssDrop.Contains("RDT:")) {
										ssDrop = "RDT x 1";
										dropQuantity = 1;
									}

									// Check if the previously logged quantities + the new quantity that we are logging is > 2147m
									long checkMaxIntWhenAdded;
									checkMaxIntWhenAdded = (long) totalDropsFromAllBosses[boss][ssDrop] + dropQuantity;

									if (checkMaxIntWhenAdded > 2147000000 || checkMaxIntWhenAdded < 0) {
										totalDropsFromAllBosses[boss][ssDrop] = 2147000000;
									}
									else {
										totalDropsFromAllBosses[boss][ssDrop] += dropQuantity;
									}
									
								}
								catch (InvalidOperationException e) {
									Debug.WriteLine(e.ToString());
								}
							}
							else {

								try {

									// Guarantee correct log file format (fails only if modified by user)
									int.TryParse(drop.Split(' ')[drop.Split(' ').Length - 1], out dropQuantity);
									if (drop.Contains("RDT:")) {
										drop = "RDT x 1";
										dropQuantity = 1;
									}

									//Console.WriteLine("\n=============== DEBUG ================");
									//Console.WriteLine("Drop: " + drop);
									//Console.WriteLine("=============== DEBUG ================\n");

									if (totalDropsFromAllBosses[boss][drop] + dropQuantity >= 2147000000) {
										totalDropsFromAllBosses[boss][drop] = 2147000000;
									}
									else {
										totalDropsFromAllBosses[boss][drop] += dropQuantity;
									}
								}
								catch (InvalidOperationException e) {
									Debug.WriteLine("Drop log file has incorrect format. \n\n" + e.ToString());
								}
							}
						}
					}
				}
			}
		}
		private void setAllBossStrings() {

			dropLogger.OldSchoolDropLogger f = dropLogger.OldSchoolDropLogger.instance;

			foreach (ToolStripMenuItem item in f.bossToolStripMenuItem.DropDownItems) {

				// Read each menustrip item and add to allBossStrings
				foreach (ToolStripMenuItem boss in item.DropDownItems) {
					allBossStrings.Add(boss.ToString());
				}
			}

			allBossStrings.Sort();
		}
		private void createAllDropsWithZeroQuantity() {

			foreach (String boss in getAllBossStrings()) {

				if (File.Exists(logsFilePath + boss + " Drops.txt")) {

					// Get the lines from the file
					var file = File.ReadAllLines(logsFilePath + boss + " Drops.txt");
					List<String> lines = new List<String>(file);

					Dictionary<String, int> noQtyDict = new Dictionary<string, int>();

					// Loop through the lines in the file
					for (int i = 0; i < lines.Count; i++) {
						if (!noQtyDict.ContainsKey(lines[i])) {
							noQtyDict.Add(lines[i], 0);
						}
					}
					totalDropsFromAllBosses.Add(boss, noQtyDict);
				}
			}
		}
		

		/* Class functions */
		private void totalDropsPerBoss() { }
		private void totalDrops() { }
		private void estimatedGPGained(String boss) { }
		private void estimatedTotalGPGained() { }
		// Leave for possible later implementation
		//private void shortestTripTime(String boss) { }
		//private void longestTripTime(String boss) { }
		//private void averageTripTime(String boss) { }
		//private void averageKillsPerTrip(String boss) { }
		private void averageGPPerKill(String boss) { }
		//private void averageGPPerTrip(String boss) { }
		//private void averageGPPerHour(String boss) { }
		//private void totalTimeSpentAtBoss(String boss) { }
		private void overlayItemQuantityOnPictureBox(int quantity, PaintEventArgs e) {
			e.Graphics.DrawImage(iqc.createQuantityImage(quantity), new Point(9, 2));
		}
		private void updateTotalDropsForBoss(String boss) {

		}


		/* Helper functions */
		private void printList(List<String> list) {
			Console.WriteLine("========= List contents ==========");
			foreach (String item in list) {
				Console.WriteLine(item);
			}
			Console.WriteLine("==================================");
		}
		private void printDictionary(Dictionary<String, int> dict) {
			Console.WriteLine("========= Dictionary contents =========");
			foreach (KeyValuePair<String, int> kvp in dict) {
				Console.WriteLine(kvp.Key + " => " + kvp.Value);
			}
			Console.WriteLine("=======================================");
		}
		private void print2LevelDictionary(Dictionary<String, Dictionary<String, int>> dict) {
			Console.WriteLine("========= Dictionary contents =========");
			foreach (KeyValuePair<String, Dictionary<String, int>> dd in dict) {

				foreach (KeyValuePair<String, int> kvp in dict[dd.Key]) {

					Console.WriteLine(kvp.Key + " => " + kvp.Value);
				}
			}
			Console.WriteLine("=======================================");
		}
		public Boolean isClassInitialized() {

			if (this != null) {
				return true;
			}
			return false;
		}



		/* Constructor */
		public StatisticsForm() {
			InitializeComponent();
			Console.WriteLine("Statistics()");
			setAllBossStrings();
			getAllBossStrings();
			iqc = new ItemQuantityCreator();
			totalDropsFromAllBosses = new Dictionary<string, Dictionary<string, int>>();

			setTotalKillsLoggedPerBoss();
			print2LevelDictionary(totalDropsFromAllBosses);


			//TODO:
			// [x] rewrite code so that at the very beginning a quantity of 0 is set for all items for existing bosses
			// Add code when drop is logged and written to file: if drop is of variable quantity, add [v] to the end of the drop in the file
			//				so that it can be distinguised when adding total drops
			//
			//				Test cases:
			//							 Runite bolts x 999999
			//							 Runite bolts x 9999, Runite crossbow x 1
			//							 Runite crossbow x 1, Runite bolts x 99999
			//
			// [ ] De-highlight picturebox when viewing total loot
			// [ ] When you log a drop then view the totalLootLogged, the most recent drop isn't included in the quantity
			// - maybe fix how totalDropsFromAllBosses is accessed, would be nice to just do totalDropsFromAllBosses["Zulrah"]["Chaos rune"]
			//			- instead of having to type the "x 500" etc
			// - need to explore the function in stats that creates the picturebox image overlay rather than doing it manually
			// - finish adding the dropViewer (currently on Armadyl)
			// - Work on updateTotalDropsFromBoss so that when you log a drop and go to view all drops it is counted there

			createAllDropsWithZeroQuantity();
			setTotalDropsFromAllBosses();
		}

		private void InitializeComponent() {
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Total Uniques");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Uniques", new System.Windows.Forms.TreeNode[] {
            treeNode1});
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Drops");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node2");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Splits", new System.Windows.Forms.TreeNode[] {
            treeNode4});
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("GP");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Kill Count");
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.labelSideNavigation = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView1.ForeColor = System.Drawing.Color.Silver;
			this.treeView1.Location = new System.Drawing.Point(-1, 41);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "childNodeTotalUniques";
			treeNode1.Text = "Total Uniques";
			treeNode2.Name = "rootNodeUniques";
			treeNode2.Text = "Uniques";
			treeNode3.Name = "rootNodeDrops";
			treeNode3.Text = "Drops";
			treeNode4.Name = "Node2";
			treeNode4.Text = "Node2";
			treeNode5.Name = "rootNodeSplits";
			treeNode5.Text = "Splits";
			treeNode6.Name = "rootNodeGP";
			treeNode6.Text = "GP";
			treeNode7.Name = "rootNodeKillCount";
			treeNode7.Text = "Kill Count";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode5,
            treeNode6,
            treeNode7});
			this.treeView1.Size = new System.Drawing.Size(134, 415);
			this.treeView1.TabIndex = 74;
			// 
			// labelSideNavigation
			// 
			this.labelSideNavigation.AutoSize = true;
			this.labelSideNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.labelSideNavigation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSideNavigation.Location = new System.Drawing.Point(29, 11);
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
			this.panel1.Size = new System.Drawing.Size(134, 40);
			this.panel1.TabIndex = 76;
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(261, 61);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(300, 300);
			this.chart1.TabIndex = 77;
			this.chart1.Text = "chart1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(652, 240);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 78;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// StatisticsForm
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
			this.ClientSize = new System.Drawing.Size(851, 455);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.treeView1);
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StatisticsForm";
			this.Text = "Statistics";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		private void button1_Click(object sender, EventArgs e) {
			//reset your chart series and legends
			chart1.Series.Clear();
			chart1.Legends.Clear();

			//Add a new Legend(if needed) and do some formating
			chart1.Legends.Add("MyLegend");
			chart1.Legends[0].LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Table;
			chart1.Legends[0].Alignment = StringAlignment.Center;
			chart1.Legends[0].Title = "MyTitle";
			chart1.Legends[0].BorderColor = Color.Black;

			//Add a new chart-series
			string seriesname = "MySeriesName";
			chart1.Series.Add(seriesname);
			//set the chart-type to "Pie"
			chart1.Series[seriesname].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

			//Add some datapoints so the series. in this case you can pass the values to this method
			chart1.Series[seriesname].Points.AddXY("MyPointName", 20);
			chart1.Series[seriesname].Points.AddXY("MyPointName1", 40);
			chart1.Series[seriesname].Points.AddXY("MyPointName2", 60);
			chart1.Series[seriesname].Points.AddXY("MyPointName3", 100);
			chart1.Series[seriesname].Points.AddXY("MyPointName4", 80);
		}

		private void labelSideNavigation_Click(object sender, EventArgs e) {

		}
	}
}