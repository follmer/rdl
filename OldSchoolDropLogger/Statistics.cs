using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using itemQuantityCreator;
using System.Diagnostics;
using OldSchoolDropLogger.Properties;
using System.Windows.Forms.DataVisualization.Charting;

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
		private List<PictureBox> allSplitsPictureBoxes;
		private List<Label> allUniquesLabels;
		private List<Label> allSplitsLabels;


		// Boss chart colors
		Dictionary<String, Color> bossChartColors = new Dictionary<string, Color>();

		/* End vars */


		public StringAlignment Center { get; private set; }

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
		private void setBossChartColors() {
			bossChartColors.Add("Abyssal Sire", ColorTranslator.FromHtml("#631408"));
			bossChartColors.Add("Raids", ColorTranslator.FromHtml("#838d8d"));
			bossChartColors.Add("Wintertodt", ColorTranslator.FromHtml("#dc6e38"));
			bossChartColors.Add("Chaos Elemental", ColorTranslator.FromHtml("#6d647d"));
			bossChartColors.Add("Dagannoth Kings", ColorTranslator.FromHtml("#7a7261"));
			bossChartColors.Add("Corporeal Beast", ColorTranslator.FromHtml("#554262"));
			bossChartColors.Add("Bandos", ColorTranslator.FromHtml("#617a61"));
			bossChartColors.Add("Kraken", ColorTranslator.FromHtml("#b59415"));
			bossChartColors.Add("Armadyl", ColorTranslator.FromHtml("#948a8a"));
			bossChartColors.Add("Zamorak", ColorTranslator.FromHtml("#b0492e"));
			bossChartColors.Add("Thermonuclear Smoke Devil", ColorTranslator.FromHtml("#788196"));
			bossChartColors.Add("Zulrah", ColorTranslator.FromHtml("#9dae15"));
			bossChartColors.Add("Giant Mole", ColorTranslator.FromHtml("#544838"));
			bossChartColors.Add("Vet'ion", ColorTranslator.FromHtml("#550853"));
			bossChartColors.Add("Venenatis", ColorTranslator.FromHtml("#591108"));
			bossChartColors.Add("Callisto", ColorTranslator.FromHtml("#373232"));
			bossChartColors.Add("Grotesque Guardians", ColorTranslator.FromHtml("#5b635b"));
			bossChartColors.Add("Kalphite Queen", ColorTranslator.FromHtml("#6f812f"));
			bossChartColors.Add("King Black Dragon", ColorTranslator.FromHtml("#3a3a2e"));
			bossChartColors.Add("Skotizo", ColorTranslator.FromHtml("#1d042b"));
			bossChartColors.Add("Scorpia", ColorTranslator.FromHtml("#464141"));
			bossChartColors.Add("Barrows", ColorTranslator.FromHtml("#4d4b33"));
			bossChartColors.Add("Cerberus", ColorTranslator.FromHtml("#3e0900"));
			bossChartColors.Add("Chaos Fanatic", ColorTranslator.FromHtml("#ececec"));
			bossChartColors.Add("Crazy Archaeologist", ColorTranslator.FromHtml("#6d5f32"));
			bossChartColors.Add("Saradomin", ColorTranslator.FromHtml("#dbcf98"));
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

			boss = prepareStringForResourceGrab(boss);

			if (Resources.ResourceManager.GetObject(boss + "_Uniques") != null) {

				String file = Resources.ResourceManager.GetString(boss + "_Uniques");
				List<String> drops = file.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

				return drops;
			}
			else {
				Console.WriteLine("[ERROR]: No unique file found for " + boss);
			}

			return null;
		}
		public List<String> getSplits() {

			if (Resources.ResourceManager.GetObject("Splits") != null) {

				String file = Resources.ResourceManager.GetString("Splits");
				List<String> splits = file.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

				return splits;
			}
			else {
				Console.WriteLine("[ERROR]: No splits file found.");
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
			putControlsIntoList();
			setBossChartColors();
		}

		private void labelSideNavigation_Click(object sender, EventArgs e) {

		}

		private void statisticsNavigationTree_AfterSelect(object sender, TreeViewEventArgs e) {

			String nodeName = statisticsNavigationTree.SelectedNode.Name;

			switch (nodeName) {
				case "nodeUniquesDryStreaks":
					displayStatUniquesDryStreaks();
					break;
				case "nodeUniquesTotalUniques":
					displayStatUniquesTotalUniques();
					break;
				case "nodeSplitsDryStreaks":
					displayStatSplitsDryStreaks();
					break;
				default:
					Console.WriteLine("Could not find a method to call for the selected node: " + nodeName);
					break;
			}
		}

		/* Displayed Statistics */
		private void displayStatUniquesTotalUniques() {

			labelViewingStatistic.Text = "Total Uniques";
			tt.SetToolTip(labelViewingStatistic, "The total number of uniques you have logged for each boss.");

			clearStatArea();
			clearCharts();

			List<String> bossStrings = getAllBossStrings();
			int bossNumber = 0;

			int totalUniquesForAllBosses = 0;


			foreach (String boss in bossStrings) {

				// get the uniques for the selected boss
				List<String> uniqueList = this.getUniquesFromBoss(boss);
				int numUniquesForBoss = 0;
				if (uniqueList != null) {
					numUniquesForBoss = uniqueList.Count;
				}

				Dictionary<String, int> uniquesAndAmounts = getUniquesAndUniqueAmountsForBoss(boss);
				if (uniquesAndAmounts == null) {
					Console.WriteLine("[ERROR]: displayStatUniquesTotalUniques(): call to getUniquesAndUniqueAmountsForBoss(" + boss + ") returned null.");
				}

				allUniquesPictureBoxes[bossNumber].BackgroundImage = getGeneralImageFromString(prepareStringForResourceGrab("Boss_" + boss));

				int sumOfUniques = 0;
				if (uniquesAndAmounts != null) {
					foreach (KeyValuePair<String, int> kp in uniquesAndAmounts) {
						sumOfUniques += kp.Value;
					}
				}
				
				allUniquesLabels[bossNumber].Text = sumOfUniques.ToString();
				tt.SetToolTip(allUniquesPictureBoxes[bossNumber], boss);

				totalUniquesForAllBosses += sumOfUniques;

				bossNumber++;
			}

			// format series
			clearCharts();

			chartUniques.Series.Add("chartUniquesData");
			chartUniques.Series["chartUniquesData"].ChartType = SeriesChartType.Doughnut;
			chartUniques.Series["chartUniquesData"].BorderDashStyle = ChartDashStyle.Solid;
			chartUniques.Series["chartUniquesData"].BorderColor = Color.DimGray;
			chartUniques.Series["chartUniquesData"].BorderWidth = 1;
			chartUniques.Series["chartUniquesData"].CustomProperties = "DoughnutRadius=50";
			
			// format legend
			chartUniques.Legends.Clear();
			chartUniques.Legends.Add("chartUniquesLegend");
			chartUniques.Legends["chartUniquesLegend"].LegendStyle = LegendStyle.Table;
			chartUniques.Legends["chartUniquesLegend"].Title = "Boss - Total Uniques";
			chartUniques.Legends["chartUniquesLegend"].BackColor = Color.Transparent;
			chartUniques.Legends["chartUniquesLegend"].TitleBackColor = Color.Transparent;
			chartUniques.Legends["chartUniquesLegend"].Title = "Boss";
			chartUniques.Legends["chartUniquesLegend"].Docking = Docking.Right;
			chartUniques.Legends["chartUniquesLegend"].Alignment = StringAlignment.Center;
			chartUniques.Legends["chartUniquesLegend"].ForeColor = Color.Silver;
			chartUniques.Legends["chartUniquesLegend"].TitleForeColor = Color.Silver;
			chartUniques.Legends["chartUniquesLegend"].BorderDashStyle = ChartDashStyle.NotSet;
			chartUniques.Legends["chartUniquesLegend"].TextWrapThreshold = 10;

			chartUniques.Size = new Size(378, 415);
			chartUniques.Location = new Point(622, 41);
			

			int i = 0;
			foreach (String boss in bossStrings) {

				Dictionary<String, int> uniquesAndAmounts = getUniquesAndUniqueAmountsForBoss(boss);

				int sumOfUniques = 0;
				if (uniquesAndAmounts != null) {
					foreach (KeyValuePair<String, int> kp in uniquesAndAmounts) {
						sumOfUniques += kp.Value;
					}
				}

				double percentOfUniquesFromThisBoss = 0.0;
				if (sumOfUniques != 0) {
					percentOfUniquesFromThisBoss = (double) sumOfUniques / (double) totalUniquesForAllBosses;
					chartUniques.Series["chartUniquesData"].Points.AddXY(sumOfUniques.ToString(), percentOfUniquesFromThisBoss);
					chartUniques.Series["chartUniquesData"].Points[i].LegendText = boss;
					chartUniques.Series["chartUniquesData"].Points[i].Color = bossChartColors[boss];

					if (bossChartColors[boss].GetBrightness() > 0.3) {
						chartUniques.Series["chartUniquesData"].Points[i].LabelForeColor = ColorTranslator.FromHtml("#000000");
					}
					else {
						chartUniques.Series["chartUniquesData"].Points[i].LabelForeColor = ColorTranslator.FromHtml("#dddddd");
					}
					
					

					i++;
				}
			}

			
			

			//Add some datapoints so the series. in this case you can pass the values to this method








			setNPictureBoxesAsVisible(bossStrings.Count);
			showNUniquesLabels(bossStrings.Count);

			// get the string names of all the bosses
			// put into list
			// loop through this list
			//		- grab all uniques for this boss
			//		- put boss on picture box and # uniques as label
		}
		private void displayStatUniquesDryStreaks() {
			
			labelViewingStatistic.Text = "Unique Dry Streaks";
			tt.SetToolTip(labelViewingStatistic, "The amount of kills dry you are since last receiving a unique (in your name), for each boss as well as in total.");

			clearStatArea();
			clearCharts();

			selectedStatisticsBoss = prepareStringForResourceGrab(selectedStatisticsBoss);

			Console.WriteLine("[DEBUG]: Statistics.displayStatUniquesDryStreaks()");

			// get the uniques for the selected boss
			List<String> uniqueList = this.getUniquesFromBoss(selectedStatisticsBoss);

			int numUniquesForBoss = 0;
			if (uniqueList != null) {
				numUniquesForBoss = uniqueList.Count;
			}

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
				int lastSeenUniqueKc = 0;

				if (kcList.Count > 0) {
					lastSeenUniqueKc = totalKillcount - kcList.Max();
				}

				// Create a new dictionary for us to store the uniques in
				Dictionary<String, int> uniqueDictionary = new Dictionary<String, int>();

				uniqueDictionary.Add("icon_any", lastSeenUniqueKc);
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
				setBackgroundImageFromUniqueList(uniqueDictionary);

			}

			// Show the correct number of pictureboxes equal to the number of uniques
			// + 1 since we are going to show a picturebox with the word "any" in it
			setNPictureBoxesAsVisible(numUniquesForBoss + 1);
			showNUniquesLabels(numUniquesForBoss + 1);
		}
		private void displayStatSplitsDryStreaks() {

			clearCharts();
			clearStatArea();

			labelViewingStatistic.Text = "Splits Dry Streaks";
			tt.SetToolTip(labelViewingStatistic, "The amount of kills dry you are since last receiving a split, for each boss as well as in total.");

			selectedStatisticsBoss = prepareStringForResourceGrab(selectedStatisticsBoss);

			Console.WriteLine("[DEBUG]: Statistics.displayStatSplitsDryStreaks()");

			// get the splits for the selected boss
			List<String> splitList = this.getSplits();

			Dictionary<String, int> splitDryStreaksList = new Dictionary<String, int>();
			Dictionary<String, int> lastSplitSeenForAllBosses = new Dictionary<String, int>();

			String mostRecentSplitItem = "";
			String mostRecentSplitBoss = "";
			int mostRecentSplitValue = -1;
			int mostRecentSplitKillcount = -1;

			// Make sure the splits aren't null
			if (splitList != null) {

				// Populate the dictionary first with 0 killcount
				List<String> bossStrings = getAllBossStrings();

				// Deal with time since last split (any)
				int totalSplitCount = splitList.Count;

				List<int> kcList = new List<int>();

				// Populate the list with all bosses before we proceed
				// so that no boss is left null
				foreach (String b in bossStrings) {
					splitDryStreaksList.Add(b, 0);
				}

				int currentSplit = 0;

				// loop through all the logged splits
				foreach (String line in splitList) {

					// [x] get the kc of the split and put it into the kc list to know when the last split for the boss we're on was
					// [x]- get the log file for the boss we're on
					// [x]	- get the count of this log file, i.e.   (90 - kcOfSplit) = split dry streak for current boss
					// [ ]			- put this split dry streak into the splitDryStreaksList
					// [ ] it would be cool for the any pb to say what the last drop was, from who, and what kc

					String boss = line.Substring(0, line.IndexOf(","));
					boss = boss.Substring(boss.IndexOf(".") + 2);

					String item = line.Substring(line.IndexOf(",") + 2, line.IndexOf("[") - line.IndexOf(",") - 3);

					String data = line.Substring(line.IndexOf("["));

					// Remove the [ and ] from the beginning and end of our data
					data = data.Substring(1, data.Length - 2);

					List<String> dataList = data.Split(',').ToList();

					int splitKc = -1;
					int splitAmount = -1;
					int numPeople = -1;
					int numAlts = -1;
					Boolean selfDrop = false;

					foreach (String s in dataList) {

						if (s.Substring(0, 3) == "kc=") {
							Int32.TryParse(s.Substring(3, s.Length - 3), out splitKc);

							int oldKc = 0;

							// Remove a key to prevent duplicates
							if (lastSplitSeenForAllBosses.ContainsKey(boss)) {
								oldKc = lastSplitSeenForAllBosses[boss];
								lastSplitSeenForAllBosses.Remove(boss);
							}

							// Make sure that the kc we're logging is the highest, this should never not happen
							// but just in case
							if (oldKc < splitKc) {
								lastSplitSeenForAllBosses.Add(boss, splitKc);
							}
							else {
								lastSplitSeenForAllBosses.Add(boss, oldKc);
							}
							
						}
						else if (s.Substring(0, 3) == "sn=") {
							Int32.TryParse(s.Substring(3, s.Length - 3), out splitAmount);
							selfDrop = false;
						}
						else if (s.Substring(0, 3) == "sy=") {
							Int32.TryParse(s.Substring(3, s.Length - 3), out splitAmount);
							selfDrop = true;
						}
						else if (s.Substring(0, 2) == "p=") {
							Int32.TryParse(s.Substring(2, s.Length - 2), out numPeople);
						}
						else if (s.Substring(0, 2) == "a=") {
							Int32.TryParse(s.Substring(2, s.Length - 2), out numAlts);
						}
						else {
							Console.WriteLine("Statistics.displayStatSplitsDryStreaks(): [ERROR]: Could not find a match for the split data logged.");
						}

						mostRecentSplitBoss = boss;
						mostRecentSplitItem = item;
						mostRecentSplitValue = splitAmount;
						mostRecentSplitKillcount = splitKc;
					}

					int numSplitsDry = 0;

					// Make sure the log file exists, if it doesn't and they have a split logged for the boss
					// then they fucked up somewhere but we have to handle it anyway ¯\_(ツ)_/¯
					if (Resources.ResourceManager.GetString(boss) != null) {

						String filename = Resources.ResourceManager.GetString(selectedStatisticsBoss);
						List<String> items = filename.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

						// Grab the total drops logged
						int logCount = items.Count;

						// Subtract to find the uniques dry they are
						numSplitsDry = lastSplitSeenForAllBosses[boss] - numSplitsDry;

						if (splitDryStreaksList.ContainsKey(boss)) {
							splitDryStreaksList.Remove(boss);
						}

						// Add the number of splits dry for that specific boss
						splitDryStreaksList.Add(boss, numSplitsDry);

					}
					else {
						Console.WriteLine("[ERROR]: No log file found for " + boss + "... somehow... ¯\\_(ツ)_/¯");
					}

					currentSplit++;
				}

				// Possibly unnecessary but it works so I'm leaving it
				String shortestDryForAllBossesText = "";
				int shortestDryForAllBosses = Int32.MaxValue;
				foreach (KeyValuePair<String, int> kp in lastSplitSeenForAllBosses) {
					if (kp.Value < shortestDryForAllBosses) {
						shortestDryForAllBosses = kp.Value;
						shortestDryForAllBossesText = kp.Key;
					}
				}

				// Need to copy over all the data from before since we also need to update
				// the value of the 'any' key
				Dictionary<String, int> streakCopy = new Dictionary<string, int>();
				streakCopy.Add("icon_any", shortestDryForAllBosses);
				foreach (KeyValuePair<String, int> kp in splitDryStreaksList) {
					streakCopy.Add(kp.Key, kp.Value);
				}

				setBackgroundImageFromSplitsList(streakCopy, mostRecentSplitBoss, mostRecentSplitKillcount, mostRecentSplitItem, mostRecentSplitValue);

				// Show the correct number of pictureboxes equal to the number of uniques
				// + 1 since we are going to show a picturebox with the word "any" in it
				setNGeneralPictureBoxesAsVisible(bossStrings.Count + 1, allSplitsPictureBoxes);
				setNGeneralLabelsAsVisible(bossStrings.Count + 1, allSplitsLabels);
			}
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
			else {
				
			}
		}

		private void setNGeneralPictureBoxesAsVisible(int n, List<PictureBox> pbList) {

			int numShowing = 0;

			for (int i = 0; i < pbList.Count; i++) {

				if (numShowing < n) {
					pbList[i].Visible = true;
				}
				else {
					pbList[i].Visible = false;
				}
				numShowing++;
			}
		}
		private void setNGeneralLabelsAsVisible(int n, List<Label> labelList) {

			int numShowing = 0;

			for (int i = 0; i < labelList.Count; i++) {

				if (numShowing < n) {
					labelList[i].Visible = true;
				}
				else {
					labelList[i].Visible = false;
				}
				numShowing++;
			}
		}
		private void showNUniquesLabels(int n) {

			Color c = ColorTranslator.FromHtml("#c0c0c0");
			// dark red = 78180e
			// light red = 8c3932
			// dark orange = ad562b
			// light orange = b76f15
			// dark yellow = cb9818
			// yellow = ffff00
			// silver = c0c0c0

			int numShowing = 0;

			for (int i = 0; i < allUniquesLabels.Count; i++) {

				if (numShowing < n) {
					allUniquesLabels[i].Visible = true;
					allUniquesLabels[i].ForeColor = c;
				}
				else {
					allUniquesLabels[i].Visible = false;
				}
				numShowing++;
			}
		}
		private void setNPictureBoxesAsVisible(int n) {

			int numShowing = 0;

			for (int i = 0; i < allUniquesPictureBoxes.Count; i++) {

				if (numShowing < n) {
					allUniquesPictureBoxes[i].Visible = true;
				}
				else {
					allUniquesPictureBoxes[i].Visible = false;
				}
				numShowing++;
			}
		}
		private void hideAllUniquesLables() {
			labelUniques0.Visible = false;

			for (int i = 0; i < allUniquesLabels.Count; i++) {
				allUniquesLabels[i].Visible = false;
			}
		}
		private void putControlsIntoList() {

			allUniquesPictureBoxes = new List<PictureBox>();
			Control[] c;
			for (int i = 0; i <= 27; i++) {
				c = this.Controls.Find("pictureBoxUniques" + i.ToString(), true);
				allUniquesPictureBoxes.Add((PictureBox)c[0]);
			}

			allUniquesLabels = new List<Label>();
			Control[] d;
			for (int i = 0; i <= 27; i++) {
				d = this.Controls.Find("labelUniques" + i.ToString(), true);
				allUniquesLabels.Add((Label)d[0]);
			}

			allSplitsPictureBoxes = new List<PictureBox>();
			Control[] e;
			for (int i = 1; i <= 27; i++) {
				e = this.Controls.Find("pictureBoxSplits" + i.ToString(), true);
				allSplitsPictureBoxes.Add((PictureBox)e[0]);
			}

			allSplitsLabels = new List<Label>();
			Control[] f;
			for (int i = 1; i <= 27; i++) {
				f = this.Controls.Find("labelSplits" + i.ToString(), true);
				allSplitsLabels.Add((Label)f[0]);
			}

		}

		private void setBackgroundImageFromUniqueList(Dictionary<String, int> uniqueDictionary) {

			List<String> keys = uniqueDictionary.Keys.ToList();
			List<int> values = uniqueDictionary.Values.ToList();

			for (int i = 0; i < uniqueDictionary.Count; i++) {

				Bitmap b = getUniqueImageFromString(uniqueDictionary.Keys.ToList()[i]);

				if (b != null) {
					allUniquesPictureBoxes[i].BackgroundImage = b;
					allUniquesLabels[i].Text = values[i].ToString();
					if (keys[i] == "icon_any") {
						tt.SetToolTip(allUniquesPictureBoxes[i], "Any unique");
					}
					else {
						tt.SetToolTip(allUniquesPictureBoxes[i], keys[i]);
					}
				}
				else {
					Console.WriteLine("setBackgroundImageFromUniqueList(): Bitmap request for " + keys[i] + " is null.");
				}
			}
		}

		private void setBackgroundImageFromSplitsList(Dictionary<String, int> splitDictionary, String mostRecentSplitBoss, int mostRecentSplitKillcount, String mostRecentSplitItem, int mostRecentSplitValue) {

			List<String> keys = splitDictionary.Keys.ToList();
			List<int> values = splitDictionary.Values.ToList();

			for (int i = 0; i < splitDictionary.Count; i++) {


				Bitmap b = getGeneralImageFromString(prepareStringForResourceGrab("Boss_" + splitDictionary.Keys.ToList()[i]));

				if (b != null) {
					allSplitsPictureBoxes[i].BackgroundImage = b;
					allSplitsLabels[i].Text = values[i].ToString();

					if (keys[i] == "icon_any") {
						//streakCopy, mostRecentSplitBoss, mostRecentSplitKillcount, mostRecentSplitItem, mostRecentSplitValue formatted += String.Format("{0:n0}", int.Parse(splitAmount)) + " gp";
						tt.SetToolTip(allSplitsPictureBoxes[i], "Last split was at " + mostRecentSplitBoss + Environment.NewLine +
						"	– kc: " + mostRecentSplitKillcount.ToString() + Environment.NewLine +
						"	– item: " + mostRecentSplitItem + Environment.NewLine +
						"	– split: " + String.Format("{0:n0}", mostRecentSplitValue) + "gp");
					}
					else {
						tt.SetToolTip(allSplitsPictureBoxes[i], keys[i]);
					}
				}
				else {
					Console.WriteLine("setBackgroundImageFromSplitsList(): Bitmap request for " + keys[i] + " is null.");
				}
			}
		}

		private Bitmap getGeneralImageFromString(String item) {
			item = runescapeCase(item);
			item = prepareStringForResourceGrab(item);
			if (Resources.ResourceManager.GetObject(item) != null) {
				return (Bitmap)Resources.ResourceManager.GetObject(item);
			}

			return null;
		}
		private Bitmap getUniqueImageFromString(String unique) {

			// Special case 
			if (unique == "icon_any") {

				return (Bitmap)Resources.icon_any;
			}

			// Remove the " x 1" from the end of the unique
			// Need to make sure that the unique doesn't have a quantity behind the " x " 
			// such as "Onyx bolts (e) x 175"
			// Handle this as well
			String qtyStr = unique.Substring(unique.IndexOf(" x ") + 3, unique.Length - unique.IndexOf(" x ") - 3);
			int itemQuantity = Int32.Parse(qtyStr);

			// If the quantity ended up being more than 1, we need to remove the " x " and then add back in the quantity
			if (itemQuantity > 1) {
				unique = unique.Substring(0, unique.IndexOf(" x "));
				unique += " " + qtyStr;
			}
			else {
				unique = unique.Substring(0, unique.IndexOf(" x "));
			}

			unique = prepareStringForResourceGrab(unique);

			if (Resources.ResourceManager.GetObject(unique) != null) {
				return (Bitmap)Resources.ResourceManager.GetObject(unique);
			}

			return null;
		}

		public String prepareStringForResourceGrab(String s) {
			s = s.Replace(" ", "_");
			s = s.Replace("'", "_");
			s = s.Replace("(", "_");
			s = s.Replace(")", "_");
			return s;
		}
		public String runescapeCase(String s) {
			s = s.ToLower();
			s = s.First().ToString().ToUpper() + s.Substring(1);
			return s;
		}

		private void StatisticsForm_Load(object sender, EventArgs e) {
			dropdownSelectedBoss.Text = "Abyssal Sire";
		}

		private Dictionary<String, int> getUniquesAndUniqueAmountsForBoss(String boss) {

			// Get the uniques for the boss
			List<String> uniqueList = this.getUniquesFromBoss(boss);

			if (uniqueList == null) {
				return null;
			}

			Dictionary<String, int> uniquesAndUniqueAmounts = new Dictionary<string, int>();

			// Make sure the boss's log file exists before trying to do anything
			if (Resources.ResourceManager.GetString(boss) != null) {

				String filename = Resources.ResourceManager.GetString(boss);
				List<String> items = filename.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

				// loop through all the logged items (all kc)
				foreach (String unique in uniqueList) {

					int timesUniqueHasBeenSeen = 0;
					// loop through the unique for this boss
					foreach (String line in items) {

						if (line.Contains(unique)) {
							timesUniqueHasBeenSeen++;
						}
					}
					uniquesAndUniqueAmounts.Add(unique, timesUniqueHasBeenSeen);
				}
			}
			else {
				foreach (String unique in uniqueList) {
					uniquesAndUniqueAmounts.Add(unique, 0);
				}
			}
			return uniquesAndUniqueAmounts;
		}

		private void clearCharts() {
			chartUniques.Series.Clear();
		}
		private void clearStatArea() {
			setNGeneralPictureBoxesAsVisible(0, allUniquesPictureBoxes);
			setNGeneralLabelsAsVisible(0, allUniquesLabels);
			setNGeneralPictureBoxesAsVisible(0, allSplitsPictureBoxes);
			setNGeneralLabelsAsVisible(0, allSplitsLabels);
		}
	}
}


