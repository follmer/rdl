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
		private void calculateDropPercent(String boss) { }
		private void estimatedGPGained(String boss) { }
		private void estimatedTotalGPGained() { }
		private void shortestTripTime(String boss) { }
		private void longestTripTime(String boss) { }
		private void averageTripTime(String boss) { }
		private void averageKillsPerTrip(String boss) { }
		private void averageGPPerKill(String boss) { }
		private void averageGPPerTrip(String boss) { }
		private void averageGPPerHour(String boss) { }
		private void totalTimeSpentAtBoss(String boss) { }

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