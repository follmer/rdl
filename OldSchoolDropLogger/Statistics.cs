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

namespace StatisticsForm {
	public partial class Statistics : Form {

		/* Vars */
		public Dictionary<String, int> killsPerBoss;
		ToolTip tt = new ToolTip();
		ItemQuantityCreator iqc;
		//Dictionary<String, int> itemQuantities = new Dictionary<String, int>();
		private String logsFilePath = AppDomain.CurrentDomain.BaseDirectory + "/logs/";
		private List<String> allBossStrings = new List<String>();
		private Dictionary<String, Boolean> sidebarActiveStatistic = new Dictionary<String, Boolean>();
		public Dictionary<String, Dictionary<String, int>> totalDropsFromAllBosses;

		/* Getters & Setters */
		public Dictionary<String, int> getTotalKillsLoggedPerBoss() {
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

			Console.WriteLine("Statistics.getTotalKillsLoggedPerBoss()");

			return killsPerBoss;
		}
		private int getBossKills(String boss) {
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

			OldSchoolDropLogger f = OldSchoolDropLogger.instance;

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
		public Statistics() {
			Console.WriteLine("Statistics()");
			setAllBossStrings();
			getAllBossStrings();
			iqc = new ItemQuantityCreator();
			totalDropsFromAllBosses = new Dictionary<string, Dictionary<string, int>>();

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
	}
}