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

namespace StatisticsForm {
	public partial class Statistics : Form {

		// Create an instance of this that can be passed to other forms
		public static Statistics instance;

		Dictionary<String, int> killsPerBoss;

		ToolTip tt = new ToolTip();

		ItemQuantityCreator iqc;

		Dictionary<String, int> itemQuantities = new Dictionary<String, int>();

		private String logsFilePath = AppDomain.CurrentDomain.BaseDirectory + "/logs/";

		private List<String> allBossStrings = new List<String>();

		// =========== End Vars ===========

		public Dictionary<String, int> getTotalKillsLoggedPerBoss() {
			Console.WriteLine("test");
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
		private void totalDropsPerBoss() { }
		private void totalDrops() { }

		private void setItemQuantities(String boss) {

			int totalBossKills = getTotalKillsLoggedPerBoss().Count;

			// REad through the boss log
			// create a map of <drop, #times dropped>
			// loop through the lines int he boss log
			// update the map as you go through

			// Make sure the log exists
			if (File.Exists(logsFilePath + boss + ".txt")) {

				// Create the map that will be used to store the drop counts

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
						if (itemQuantities.ContainsKey(drops[j])) {
							itemQuantities[drops[j]] = itemQuantities[drops[j]] + 1;
						}
						else {
							itemQuantities[drops[j]] = 1;
						}
					}
				}
			}
			else {
				Console.WriteLine("Boss log does not exist");
			}
		}
		private int getItemQuantity(String item) {
			if (itemQuantities.ContainsKey(item)) {
				return itemQuantities[item];
			}
			else return 0;
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

			dropLogger.OldSchoolDropLogger f = dropLogger.OldSchoolDropLogger.instance;

			foreach (ToolStripMenuItem item in f.bossToolStripMenuItem.DropDownItems) {

				// Read each menustrip item and add to allBossStrings
				foreach (ToolStripMenuItem boss in item.DropDownItems) {
					allBossStrings.Add(boss.ToString());
				}
			}
		}
		private List<String> getAllBossStrings() {
			return allBossStrings;
		}



		private void printDictionary(Dictionary<String, int> dict) {
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



		private String getCurrentBoss() {
			return labelCurrentStatisticsFor.Text.Split(':')[1].Trim();
		}

		private void overlayItemQuantityOnPictureBox(int quantity, PaintEventArgs e) {
			e.Graphics.DrawImage(iqc.createQuantityImage(quantity), new Point(9, 2));
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e) {
			if (pictureBox1.Visible == true) {
				overlayItemQuantityOnPictureBox(getItemQuantity(pictureBox1.Tag.ToString()), e);
				Console.WriteLine("\n Overlaying " + getItemQuantity(pictureBox1.Tag.ToString()));
			}
		}
		private void pictureBox2_Paint(object sender, PaintEventArgs e) {
			if (pictureBox2.Visible == true) {
				overlayItemQuantityOnPictureBox(getItemQuantity(pictureBox2.Tag.ToString()), e);
				Console.WriteLine("\n Overlaying " + getItemQuantity(pictureBox2.Tag.ToString()));
			}
		}


		private void Statistics_Load(object sender, EventArgs e) {
			setAllBossStrings();
			Console.WriteLine(getTotalKills());
			printDictionary(getTotalKillsLoggedPerBoss());



			setItemQuantities("Zulrah");

			getAllBossStrings();
		}
		/* Constructor */
		public Statistics() {
			InitializeComponent();
			killsPerBoss = getTotalKillsLoggedPerBoss();
			iqc = new ItemQuantityCreator();

			instance = this;

			connectPictureBoxEventHandlers();
		}

	}
}