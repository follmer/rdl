using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mainWindow;
using System.IO;

namespace StatisticsForm {
	public partial class Statistics : Form {
		public Statistics() {
			InitializeComponent();
		}

		private String logsFilePath = AppDomain.CurrentDomain.BaseDirectory + "/logs/";

		private List<String> allBossStrings = new List<String>();

		private Dictionary<String, int> getTotalKillsLoggedPerBoss() {

			Dictionary<String, int> killsPerBoss = new Dictionary<String, int>();

			foreach (String s in allBossStrings) {

				if (File.Exists(logsFilePath + s + ".txt")) {

					var file = File.ReadAllLines(logsFilePath + s + ".txt");
					List<String> lines = new List<String>(file);
					killsPerBoss[s] = lines.Count;
				}
			}

			return killsPerBoss;

		}
		public int getTotalKills() {

			int sumOfKills = 0;

			Dictionary<String, int> kpb = getTotalKillsLoggedPerBoss();

			foreach (KeyValuePair<String, int> kv in kpb) {
				sumOfKills += kv.Value;
			}

			return sumOfKills;
		}
		private void totalDropsPerBoss() { }
		private void totalDrops() { }
		private void calculateDropPercent(String boss) {

			int totalBossKills = getTotalKillsLoggedPerBoss().Count;

			// REad through the boss log
			// create a map of <drop, #times dropped>
			// loop through the lines int he boss log
			// update the map as you go through

			// Make sure the log exists
			if (File.Exists(logsFilePath + boss + ".txt")) {

				// Create the map that will be used to store the drop counts
				Dictionary<String, int> items = new Dictionary<String, int>();

				// Get the lines from the file
				var file = File.ReadAllLines(logsFilePath + boss + ".txt");
				List<String> lines = new List<String>(file);

				// Used to keep track of the total # of drops
				int k = 0;

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

					// Split multi-drop drops on the comma (i.e. Zulrah has multidrops)
					String[] drops = lines[i].Split(',');

					// Loop through all the drops now
					for (int j = 0; j < drops.Length; j++) {

						// Add 1 to the total number of drops
						k++;
						
						// Trim all the drops
						drops[j] = drops[j].Trim();

						// If the item is already in the dict just increase the count
						if (items.ContainsKey(drops[j])) {
							items[drops[j]] = items[drops[j]] + 1;
						}
						else {
							items[drops[j]] = 1;
						}
					}
				}

				// Loop through the dictionary and display (print) each value count
				foreach (KeyValuePair<String, int> entry in items) {
					Console.WriteLine(entry.Key + ": " + entry.Value + "/" + k + " = Drop rate of " + ((((double) entry.Value / (double) k)) * 100) + "%");
				}

			}
			else {
				Console.WriteLine("Boss log does not exist");
			}


		}
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

		private void setAllBossStrings() {
			allBossStrings.Add("Armadyl");
			allBossStrings.Add("Bandos");
			allBossStrings.Add("Saradomin");
			allBossStrings.Add("Zamorak");
			allBossStrings.Add("Callisto");
			allBossStrings.Add("Chaos Elemental");
			allBossStrings.Add("Chaos Fanatic");
			allBossStrings.Add("Crazy Archaeologist");
			allBossStrings.Add("King Black Dragon");
			allBossStrings.Add("Scropia");
			allBossStrings.Add("Venenatis");
			allBossStrings.Add("Vet'ion");
			allBossStrings.Add("Abyssal Sire");
			allBossStrings.Add("Barrows");
			allBossStrings.Add("Cerberus");
			allBossStrings.Add("Corporeal Beast");
			allBossStrings.Add("Dagannoth Prime");
			allBossStrings.Add("Dagannoth Rex");
			allBossStrings.Add("Dagannoth Supreme");
			allBossStrings.Add("Giant Mole");
			allBossStrings.Add("Kalphite Queen");
			allBossStrings.Add("Kraken");
			allBossStrings.Add("Skotizo");
			allBossStrings.Add("Thermonuclear Smoke Devil");
			allBossStrings.Add("Zulrah");
		}
		private List<String> getAllBossStrings() {
			return allBossStrings;
		}

		
		private void Statistics_Load(object sender, EventArgs e) {
			setAllBossStrings();
			Console.WriteLine(getTotalKills());
			printDictionary(getTotalKillsLoggedPerBoss());

			calculateDropPercent("Zulrah");
		}

		private void printDictionary(Dictionary<String,int> dict) {
			Console.WriteLine("========= Dictionary contents =========");
			foreach (KeyValuePair<String, int> kvp in dict) {
				Console.WriteLine(kvp.Key + " => " + kvp.Value);
			}
			Console.WriteLine("=======================================");
		}
		/* Constructor */
		private void Stats() {
			Statistics s = new Statistics();
		}
	}
}