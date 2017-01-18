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
		private String getCurrentBoss() {
			return "getCurrentBoss() incomplete";
		}
		public Dictionary<String, int> getItemQuantitiesFromBoss(string boss) {
			return totalDropsFromAllBosses[boss];
		}
		public Dictionary<String, Dictionary<String, int>> getTotalDropsFromAllBosses() {
			return totalDropsFromAllBosses;
		}

		private void setTotalDropsFromAllBosses() {

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

						// If there is more than one drop logged per kill (indicated by a , in the line)
						if (lines[i].Contains(',')) {

							// Split multi-drop drops on the comma (i.e. Zulrah has multidrops)
							String[] drops = lines[i].Split(',');

							for (int j = 0; j < drops.Length; j++) {

								// Trim all the drops
								drops[j] = drops[j].Trim();

								String drop = drops[j];

								int dropQuantity;

								try {
									// Guarantee correct log file format (fails only if modified by user)
									int.TryParse(drop.Split(' ')[drop.Split(' ').Length - 1], out dropQuantity);

									// Check if the boss exists yet in the dictionary
									if (totalDropsFromAllBosses.ContainsKey(boss)) {

										// Check if the drop exists yet in the dictionary
										if (totalDropsFromAllBosses[boss].ContainsKey(lines[i])) {

											// It already exists, so just increase the quantity
											totalDropsFromAllBosses[boss][drop] += dropQuantity;
										}
										else {

											// Drop doesn't exist in dictionary yet, so create an entry for it
											totalDropsFromAllBosses[boss].Add(drop, dropQuantity);
										}
									}
									else {

										// Boss doesn't exist in the dictionary, but Since the boss hadn't 
										// existed yet, the drop for that boss won't exist either
										// so create it too
										Dictionary<String, int> dropDict = new Dictionary<string, int>();
										dropDict.Add(drop, dropQuantity);

										totalDropsFromAllBosses.Add(boss, dropDict);

									}
								}
								catch (InvalidOperationException e) {
									Debug.WriteLine(e.ToString());
								}
							}
						}
						else {

							String drop = lines[i];

							int dropQuantity;

							try {
								// Guarantee correct log file format (fails only if modified by user)
								int.TryParse(drop.Split(' ')[drop.Split(' ').Length - 1], out dropQuantity);

								// Check if the boss exists yet in the dictionary
								if (totalDropsFromAllBosses.ContainsKey(boss)) {

									// Check if the drop exists yet in the dictionary
									if (totalDropsFromAllBosses[boss].ContainsKey(lines[i])) {

										// It already exists, so just increase the quantity
										totalDropsFromAllBosses[boss][drop] += dropQuantity;
									}
									else {

										// Drop doesn't exist in dictionary yet, so create an entry for it
										totalDropsFromAllBosses[boss].Add(drop, dropQuantity);
									}
								}
								else {

									// Boss doesn't exist in the dictionary, but Since the boss hadn't 
									// existed yet, the drop for that boss won't exist either
									// so create it too
									Dictionary<String, int> dropDict = new Dictionary<string, int>();
									dropDict.Add(drop, dropQuantity);

									totalDropsFromAllBosses.Add(boss, dropDict);

								}
							}
							catch (InvalidOperationException e) {
								Debug.WriteLine(e.ToString());
							}
						}
					}
				}
			}
		}
		private void updateTotalDropsForBoss(String boss) {
			
		}

		private void setAllBossStrings() {

			OldSchoolDropLogger f = OldSchoolDropLogger.instance;

			foreach (ToolStripMenuItem item in f.bossToolStripMenuItem.DropDownItems) {

				// Read each menustrip item and add to allBossStrings
				foreach (ToolStripMenuItem boss in item.DropDownItems) {
					allBossStrings.Add(boss.ToString());
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
		

		/* Helper functions */
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
			setTotalDropsFromAllBosses();
			print2LevelDictionary(totalDropsFromAllBosses);
			Console.WriteLine(totalDropsFromAllBosses["Zulrah"]["Chaos rune x 500"]);
		}
	}
}