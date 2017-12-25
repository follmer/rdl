using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using itemQuantityCreator;
using System.Diagnostics;
using OldSchoolDropLogger.Properties;

namespace stats {
	public partial class StatisticsForm : Form {

		/* Vars */
		public Dictionary<String, int> killsPerBoss;
		ToolTip tt = new ToolTip();
		ItemQuantityCreator iqc;
		//Dictionary<String, int> itemQuantities = new Dictionary<String, int>();
		private String logsFilePath = Directory.GetCurrentDirectory() + "/logs/";
		private List<String> allBossStrings = new List<String>();
		private Dictionary<String, Boolean> sidebarActiveStatistic = new Dictionary<String, Boolean>();
		public Dictionary<String, Dictionary<String, int>> totalDropsFromAllBosses;
		private String selectedStatisticsBoss = "Abyssal Sire";
		private List<PictureBox> allUniquesPictureBoxes;

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
									checkMaxIntWhenAdded = (long)totalDropsFromAllBosses[boss][ssDrop] + dropQuantity;

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

			Console.WriteLine("[DEBUG]: " + logsFilePath + "Kraken" + " Drops.txt");

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
			putUniquesPictureBoxesIntoList();
		}

		private void button1_Click(object sender, EventArgs e) {
			//reset your chart series and legends
			//chart1.Series.Clear();
			//chart1.Legends.Clear();

			////Add a new Legend(if needed) and do some formating
			//chart1.Legends.Add("MyLegend");
			//chart1.Legends[0].LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Table;
			//chart1.Legends[0].Alignment = StringAlignment.Center;
			//chart1.Legends[0].Title = "MyTitle";
			//chart1.Legends[0].BorderColor = Color.Black;

			////Add a new chart-series
			//string seriesname = "MySeriesName";
			//chart1.Series.Add(seriesname);
			////set the chart-type to "Pie"
			//chart1.Series[seriesname].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

			////Add some datapoints so the series. in this case you can pass the values to this method
			//chart1.Series[seriesname].Points.AddXY("MyPointName", 20);
			//chart1.Series[seriesname].Points.AddXY("MyPointName1", 40);
			//chart1.Series[seriesname].Points.AddXY("MyPointName2", 60);
			//chart1.Series[seriesname].Points.AddXY("MyPointName3", 100);
			//chart1.Series[seriesname].Points.AddXY("MyPointName4", 80);
		}

		private void labelSideNavigation_Click(object sender, EventArgs e) {

		}

		private void statisticsNavigationTree_AfterSelect(object sender, TreeViewEventArgs e) {

			String nodeName = statisticsNavigationTree.SelectedNode.Name;

			switch (statisticsNavigationTree.SelectedNode.Name) {
				case "nodeUniquesDryStreaks":
					displayStatUniquesDryStreaks();
					break;
				default:
					Console.WriteLine("Could not find a method to call for the selected node: " + nodeName);
					break;
			}
		}

		private void displayStatUniquesDryStreaks() {
			Console.WriteLine("[DEBUG]: Statistics.displayStatUniquesDryStreaks()");

			// get the uniques for the selected boss
			List<String> uniqueList = this.getUniquesFromBoss(selectedStatisticsBoss);
			int numUniquesForBoss = uniqueList.Count;


			// Make sure the boss's log file exists before trying to do anything
			if (Resources.ResourceManager.GetString(selectedStatisticsBoss) != null) {

				String filename = Resources.ResourceManager.GetString(selectedStatisticsBoss);
				List<String> items = filename.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

				// Deal with time since last unique (any)
				int totalKillcount = items.Count;
				List<int> kcList = new List<int>();
				int kc = 1;

				// loop through all the logged items (all kc)
				foreach (String line in items) {

					// loop through the unique for this boss
					foreach (String unique in uniqueList) {
						if (line.Contains(unique)) {
							kcList.Add(kc);
						}
					}
					kc++;
				}

				// The max of the list gives us the most recent killcount that we received a unique on.
				// Subtract from the total killcount to find the # dry for any unique
				int lastSeenUniqueKc = totalKillcount - kcList.Max();

				// Display the data for the ANY picture box
				pictureBoxUniquesAny.Image = iqc.createQuantityImage(totalKillcount);

				Console.WriteLine("Total kc: " + totalKillcount);
				Console.WriteLine("max kc in list: " + kcList.Max());
				Console.WriteLine();
				Console.WriteLine("Kc dry of a unique: " + lastSeenUniqueKc);
				Console.WriteLine();



				// Create a new dictionary for us to store the uniques in
				Dictionary<String, int> uniqueDictionary = new Dictionary<String, int>();

				// Fill the uniqueDictionary with the highest dry streak first, then we will
				// update it if we found that we got a drop later on (below)
				foreach (String unique in uniqueList) {
					uniqueDictionary.Add(unique, totalKillcount);
				}

				// Search for a specific unique dry streak
				foreach (String unique in uniqueList) {

					int specificKc = 1;
					int x = items.LastIndexOf(unique);

					foreach (String line in items) {
						if (line.Contains(unique)) {
							// Remove a key if it already exists to update it
							if (uniqueDictionary.ContainsKey(unique)) {
								uniqueDictionary.Remove(unique);
							}
							uniqueDictionary.Add(unique, totalKillcount - specificKc);
						}
						specificKc++;
					}
				}

				// Display the correct picturebox images for the uniques
				// Display the specific dry streaks
				setBackgroundImageFromUniqueList(uniqueDictionary);
			}


			// Show the correct number of pictureboxes equal to the number of uniques
			// + 1 since we are going to show a picturebox with the word "any" in it
			setNPictureBoxesAsVisible(numUniquesForBoss + 1);
		}

		private void dropdownSelectedBoss_SelectedIndexChanged(object sender, EventArgs e) {
			if (dropdownSelectedBoss.SelectedItem.ToString() == "Thermy") {
				selectedStatisticsBoss = "Thermonuclear Smoke Devil";
			}
			else {
				selectedStatisticsBoss = dropdownSelectedBoss.SelectedItem.ToString();
			}

			updateCurrentStatistic();
		}

		private void updateCurrentStatistic() {

			if (labelViewingStatistic.Text == "Unique Dry Streaks") {
				displayStatUniquesDryStreaks();
			}
		}

		private void putUniquesPictureBoxesIntoList() {

			allUniquesPictureBoxes = new List<PictureBox>();

			Control[] c;
			for (int i = 1; i <= 20; i++) {
				c = this.Controls.Find("pictureBoxUniques" + i.ToString(), true);
				allUniquesPictureBoxes.Add((PictureBox)c[0]);
			}
		}

		private void setBackgroundImageFromUniqueList(Dictionary<String, int> uniqueDictionary) {

			for (int i = 0; i < uniqueDictionary.Count; i++) {

				Bitmap b = getUniqueImageFromString(uniqueDictionary.Keys.ToList()[i]);
				Bitmap q = iqc.createQuantityImage(uniqueDictionary.Values.ToList()[i]);

				if (b == null) {
					Console.WriteLine("b is null");
				}
				else {
					Console.WriteLine("not null");

					//allUniquesPictureBoxes[i].BackgroundImage = Resources.Abyssal_orphan;

					allUniquesPictureBoxes[i].BackgroundImage = b;
					allUniquesPictureBoxes[i].Image = q;
				}

			}
		}

		private void setNPictureBoxesAsVisible(int n) {
			switch (n) {
				case 0:
					pictureBoxUniquesAny.Visible = false;
					pictureBoxUniques1.Visible = false;
					pictureBoxUniques2.Visible = false;
					pictureBoxUniques3.Visible = false;
					pictureBoxUniques4.Visible = false;
					pictureBoxUniques5.Visible = false;
					pictureBoxUniques6.Visible = false;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 1:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = false;
					pictureBoxUniques2.Visible = false;
					pictureBoxUniques3.Visible = false;
					pictureBoxUniques4.Visible = false;
					pictureBoxUniques5.Visible = false;
					pictureBoxUniques6.Visible = false;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 2:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = false;
					pictureBoxUniques3.Visible = false;
					pictureBoxUniques4.Visible = false;
					pictureBoxUniques5.Visible = false;
					pictureBoxUniques6.Visible = false;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 3:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = false;
					pictureBoxUniques4.Visible = false;
					pictureBoxUniques5.Visible = false;
					pictureBoxUniques6.Visible = false;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 4:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = false;
					pictureBoxUniques5.Visible = false;
					pictureBoxUniques6.Visible = false;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 5:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = false;
					pictureBoxUniques6.Visible = false;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 6:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = false;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 7:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 8:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = false;
					pictureBoxUniques8.Visible = false;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 9:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = false;
					pictureBoxUniques10.Visible = false;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 10:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = true;
					pictureBoxUniques15.Visible = true;
					pictureBoxUniques16.Visible = true;
					pictureBoxUniques17.Visible = true;
					pictureBoxUniques18.Visible = true;
					pictureBoxUniques19.Visible = true;
					pictureBoxUniques20.Visible = false;
					break;
				case 11:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = false;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 12:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = false;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 13:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = false;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 14:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = false;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 15:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = true;
					pictureBoxUniques15.Visible = false;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 16:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = true;
					pictureBoxUniques15.Visible = true;
					pictureBoxUniques16.Visible = false;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 17:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = true;
					pictureBoxUniques15.Visible = true;
					pictureBoxUniques16.Visible = true;
					pictureBoxUniques17.Visible = false;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 18:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = true;
					pictureBoxUniques15.Visible = true;
					pictureBoxUniques16.Visible = true;
					pictureBoxUniques17.Visible = true;
					pictureBoxUniques18.Visible = false;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 19:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = true;
					pictureBoxUniques15.Visible = true;
					pictureBoxUniques16.Visible = true;
					pictureBoxUniques17.Visible = true;
					pictureBoxUniques18.Visible = true;
					pictureBoxUniques19.Visible = false;
					pictureBoxUniques20.Visible = false;
					break;
				case 20:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = true;
					pictureBoxUniques15.Visible = true;
					pictureBoxUniques16.Visible = true;
					pictureBoxUniques17.Visible = true;
					pictureBoxUniques18.Visible = true;
					pictureBoxUniques19.Visible = true;
					pictureBoxUniques20.Visible = false;
					break;
				case 21:
					pictureBoxUniquesAny.Visible = true;
					pictureBoxUniques1.Visible = true;
					pictureBoxUniques2.Visible = true;
					pictureBoxUniques3.Visible = true;
					pictureBoxUniques4.Visible = true;
					pictureBoxUniques5.Visible = true;
					pictureBoxUniques6.Visible = true;
					pictureBoxUniques7.Visible = true;
					pictureBoxUniques8.Visible = true;
					pictureBoxUniques9.Visible = true;
					pictureBoxUniques10.Visible = true;
					pictureBoxUniques11.Visible = true;
					pictureBoxUniques12.Visible = true;
					pictureBoxUniques13.Visible = true;
					pictureBoxUniques14.Visible = true;
					pictureBoxUniques15.Visible = true;
					pictureBoxUniques16.Visible = true;
					pictureBoxUniques17.Visible = true;
					pictureBoxUniques18.Visible = true;
					pictureBoxUniques19.Visible = true;
					pictureBoxUniques20.Visible = true;
					break;
			}
		}
		private Bitmap getUniqueImageFromString(String unique) {
			Console.WriteLine("getUniqueImageFromString(): " + unique);

			// Remove the " x 1" from the end of the unique
			unique = unique.Substring(0, unique.IndexOf(" x "));
			Console.WriteLine(unique);
			unique = prepareStringForResourceGrab(unique);

			if (Resources.ResourceManager.GetObject(unique) != null) {
				Console.WriteLine("found image-------------------------------");
				return (Bitmap)Resources.ResourceManager.GetObject(unique);
			}

			return null;
		}

		public String prepareStringForResourceGrab(String s) {

			s = s.Replace(" ", "_");
			s = s.Replace("'", "_");
			return s;
		}

		private void StatisticsForm_Load(object sender, EventArgs e) {

		}
	}
}


