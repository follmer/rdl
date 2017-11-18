using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace splitDrop {
	public partial class SplitDropForm : Form {

		public static SplitDropForm instance;
		private String splitsFileLocation = AppDomain.CurrentDomain.BaseDirectory + "/logs/Splits.txt";

		public SplitDropForm() {
			InitializeComponent();

			ToolTip itemNameTooltip = new ToolTip();
			itemNameTooltip.SetToolTip(labelSplitDropItemName, "Please enter the item exactly as it appears in-game");
		}

		private void buttonSplitOk_Click(object sender, EventArgs e) {

			String splitItem = textBoxSplitDropName.Text;
			String splitAmountText = textBoxSplitAmount.Text;

			if (string.IsNullOrWhiteSpace(splitItem)) {
				Console.WriteLine("[DEBUG]: splitItem is empty or null");
				return;
			}

			if (string.IsNullOrWhiteSpace(splitAmountText)) {
				Console.WriteLine("[DEBUG]: splitAmountText is empty or null");
				return;
			}

			int splitAmount = Int32.Parse(splitAmountText);

			Console.WriteLine("[DEBUG]: splitItem = " + splitItem);
			Console.WriteLine("[DEBUG]: splitAmount = " + splitAmount);

			// if: 
			//		file does not exist, create it
			if (!System.IO.File.Exists(splitsFileLocation)) {
				System.IO.File.Create(splitsFileLocation);
			}

			List<String> alreadyLoggedSplits = getSplitsFromFile();
			String currentBoss = dropLogger.OldSchoolDropLogger.instance.getCurrentBoss();

			// add a new split to the list
			Boolean dropInOwnName = false;
			if (radioButtonOwnDropYes.Checked == true) {
				dropInOwnName = true;
			}

			int totalSplitsLogged = alreadyLoggedSplits.Count();
			String newTotalLogged = (totalSplitsLogged + 1).ToString();

			String formattedSplit = "";

			int currentBossKillcount = dropLogger.OldSchoolDropLogger.instance.getBossKillcount(currentBoss);
			int splitItemQuantity = 1;
			if (splitItem == "Dragon thrownaxe") splitItemQuantity = 100;

			if (dropInOwnName) {
				formattedSplit = currentBoss + " [" + currentBossKillcount.ToString() + " kc], " + splitItem + " x " + splitItemQuantity + " [sy=" + splitAmountText + "]";

				pictureBoxTest.Tag = splitItem + " x " + splitItemQuantity.ToString();
				dropLogger.OldSchoolDropLogger.instance.pictureBox_Click(pictureBoxTest, null);
			}
			else {
				formattedSplit = currentBoss + ", " + splitItem + " x " + splitItemQuantity + " [sn=" + splitAmountText + "]";
			}
			// 3. Saradomin, Saradomin hilt x 1[sn = 20000000]
			// 4. Saradomin[3 kc], Armadyl crossbow[sy = 13850000]

			List<String> newLoggedSplits = alreadyLoggedSplits;

			newLoggedSplits.Add(formattedSplit);

			writeSplitsToFile(alreadyLoggedSplits);

		}

		private void writeSplitsToFile(List<String> splitList) {

			String boss = dropLogger.OldSchoolDropLogger.instance.getCurrentBoss();

			TextWriter tw = new StreamWriter(splitsFileLocation, false);

			for (int i = 0; i < splitList.Count; i++) {
				tw.WriteLine((i + 1) + ". " + splitList[i]);
			}
			tw.Close();
		}

		private void buttonSplitCancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		private List<String> getSplitsFromFile() {

			List<String> loggedSplitItems = new List<String>();

			// If a log file exists for the given boss, tries to get the log file for that boss
			// and convert it to a list, stripping any preceeding numbers, periods, and whitespace
			try {
				var logsFile = File.ReadAllLines(splitsFileLocation);

				List<String> splitList = new List<String>(logsFile);

				// 1. Raids[1 kc], Twisted bow x 1[sy = 201470000]
				// 2. Raids[4 kc], Dexterous prayer scroll x 1[sn = 21000000]
				// 3. Saradomin, Saradomin hilt x 1[sn = 20000000]
				// 4. Saradomin[3 kc], Armadyl crossbow[sy = 13850000]

				for (int i = 0; i < splitList.Count; i++) {

					Console.WriteLine("[DEBUG]: getSplitsFromFile - LINE: " + splitList[i]);

					int periodIndexPlus2 = splitList[i].IndexOf(".") + 2; // + 2 to skip the period and the following space
					int longItemLength = splitList[i].Length;
					int shortItemLength = longItemLength - periodIndexPlus2;

					String item = splitList[i].Substring(periodIndexPlus2);
					loggedSplitItems.Add(item);
				}
			}
			catch (FileNotFoundException) { }

			return loggedSplitItems;
		}
	}
}
