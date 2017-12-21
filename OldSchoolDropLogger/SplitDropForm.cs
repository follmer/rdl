using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OldSchoolDropLogger.Properties;
using System.Reflection;
using System.Resources;

namespace splitDrop {
	public partial class SplitDropForm : Form {

		private stats.StatisticsForm stats = null;
		private Color highlightOrange = Color.FromArgb(179, 107, 0);

		public static SplitDropForm instance;
		private String splitsFileLocation = AppDomain.CurrentDomain.BaseDirectory + "/logs/Splits.txt";

		public SplitDropForm() {
			InitializeComponent();

			// Add click listener to each picturebox
			foreach (Control c in this.Controls) {
				if (c is PictureBox) c.Click += pictureBox_Click;
			}
			putAllPictureBoxesIntoList();

			String currentBoss = dropLogger.OldSchoolDropLogger.instance.getCurrentBoss();

			if (stats == null) {
				stats = new stats.StatisticsForm();
			}

			showUniques(currentBoss);

			int numUniques = stats.getUniquesFromBoss(currentBoss).Count;
			resizeSplitWindow(numUniques);


			String splitsFileLocation = System.IO.Directory.GetCurrentDirectory() + "/logs/Splits.txt";
			Console.WriteLine("[DEBUG]: " + splitsFileLocation);



		}

		private void showUniques(String boss) {

			int numUniques = stats.getUniquesFromBoss(boss).Count;

			switch (boss) {
				case "Armadyl":
					pictureBox1.BackgroundImage = Resources.Armadyl_helmet;
					pictureBox1.Tag = "Armadyl helmet x 1";
					pictureBox2.BackgroundImage = Resources.Armadyl_chestplate;
					pictureBox2.Tag = "Armadyl chestplate x 1";
					pictureBox3.BackgroundImage = Resources.Armadyl_chainskirt;
					pictureBox3.Tag = "Armadyl chainskirt x 1";
					pictureBox4.BackgroundImage = Resources.Armadyl_hilt;
					pictureBox4.Tag = "Armadyl hilt x 1";
					break;
				case "Bandos":
					pictureBox1.BackgroundImage = Resources.Bandos_chestplate;
					pictureBox1.Tag = "Bandos chestplate x 1";
					pictureBox2.BackgroundImage = Resources.Bandos_tassets;
					pictureBox2.Tag = "Bandos tassets x 1";
					pictureBox3.BackgroundImage = Resources.Bandos_boots;
					pictureBox3.Tag = "Bandos boots x 1";
					pictureBox4.BackgroundImage = Resources.Bandos_hilt;
					pictureBox4.Tag = "Bandos hilt x 1";
					break;
				case "Saradomin":
					pictureBox1.BackgroundImage = Resources.Saradomin_s_light;
					pictureBox1.Tag = "Saradomin's light x 1";
					pictureBox2.BackgroundImage = Resources.Saradomin_sword;
					pictureBox2.Tag = "Saradomin sword x 1";
					pictureBox3.BackgroundImage = Resources.Armadyl_crossbow;
					pictureBox3.Tag = "Armadyl crossbow x 1";
					pictureBox4.BackgroundImage = Resources.Saradomin_hilt;
					pictureBox4.Tag = "Saradomin hilt x 1";
					break;
				case "Zamorak":
					pictureBox1.BackgroundImage = Resources.Steam_battlestaff;
					pictureBox1.Tag = "Steam battlestaff x 1";
					pictureBox2.BackgroundImage = Resources.Staff_of_the_dead;
					pictureBox2.Tag = "Staff of the dead x 1";
					pictureBox3.BackgroundImage = Resources.Zamorakian_spear;
					pictureBox3.Tag = "Zamorakian spear x 1";
					pictureBox4.BackgroundImage = Resources.Zamorak_hilt;
					pictureBox4.Tag = "Zamorak hilt x 1";
					break;
				case "Barrows":
					// none
					break;
				case "Corporeal Beast":
					pictureBox1.BackgroundImage = Resources.Onyx_bolts__e__175;
					pictureBox1.Tag = "Onyx bolts (e) x 175";
					pictureBox2.BackgroundImage = Resources.Holy_elixir;
					pictureBox2.Tag = "Holy elixir x 1";
					pictureBox3.BackgroundImage = Resources.Spectral_sigil;
					pictureBox3.Tag = "Spectral sigil x 1";
					pictureBox4.BackgroundImage = Resources.Arcane_sigil;
					pictureBox4.Tag = "Arcane sigil x 1";
					pictureBox5.BackgroundImage = Resources.Elysian_sigil;
					pictureBox5.Tag = "Elysian sigil x 1";
					pictureBox6.BackgroundImage = Resources.Spirit_shield;
					pictureBox6.Tag = "Spirit shield x 1";
					break;
				case "Dagannoth Kings":
					pictureBox1.BackgroundImage = Resources.Warrior_ring;
					pictureBox1.Tag = "Warrior ring x 1";
					pictureBox2.BackgroundImage = Resources.Seers_ring;
					pictureBox2.Tag = "Seers ring x 1";
					pictureBox3.BackgroundImage = Resources.Archers_ring;
					pictureBox3.Tag = "Archers ring x 1";
					pictureBox4.BackgroundImage = Resources.Berserker_ring;
					pictureBox4.Tag = "Berserker ring x 1";
					break;
				case "Giant Mole":
					// none
					break;
				case "Kalphite Queen":
					pictureBox1.BackgroundImage = Resources.Dragon_2h_sword;
					pictureBox1.Tag = "Dragon 2h sword x 1";
					pictureBox2.BackgroundImage = Resources.Dragon_chainbody;
					pictureBox2.Tag = "Dragon chainbody x 1";
					break;
				case "Raids":
					pictureBox1.BackgroundImage = Resources.Dragon_thrownaxe_100;
					pictureBox1.Tag = "Dragon thrownaxe x 100";
					pictureBox2.BackgroundImage = Resources.Dragon_sword;
					pictureBox2.Tag = "Dragon sword x 1";
					pictureBox3.BackgroundImage = Resources.Dragon_harpoon;
					pictureBox3.Tag = "Dragon harpoon x 1";
					pictureBox4.BackgroundImage = Resources.Dinh_s_bulwark;
					pictureBox4.Tag = "Dinh's bulwark x 1";
					pictureBox5.BackgroundImage = Resources.Twisted_buckler;
					pictureBox5.Tag = "Twisted buckler x 1";
					pictureBox6.BackgroundImage = Resources.Arcane_prayer_scroll;
					pictureBox6.Tag = "Arcane prayer scroll x 1";
					pictureBox7.BackgroundImage = Resources.Ancestral_hat;
					pictureBox7.Tag = "Ancestral hat x 1";
					pictureBox8.BackgroundImage = Resources.Ancestral_robe_top;
					pictureBox8.Tag = "Ancestral robe top x 1";
					pictureBox9.BackgroundImage = Resources.Ancestral_robe_bottom;
					pictureBox9.Tag = "Ancestral robe bottom x 1";
					pictureBox10.BackgroundImage = Resources.Dragon_hunter_crossbow;
					pictureBox10.Tag = "Dragon hunter crossbow x 1";
					pictureBox11.BackgroundImage = Resources.Dexterous_prayer_scroll;
					pictureBox11.Tag = "Dexterous prayer scroll x 1";
					pictureBox12.BackgroundImage = Resources.Dragon_claws;
					pictureBox12.Tag = "Dragon claws x 1";
					pictureBox13.BackgroundImage = Resources.Elder_maul;
					pictureBox13.Tag = "Elder maul x 1";
					pictureBox14.BackgroundImage = Resources.Kodai_insignia;
					pictureBox14.Tag = "Kodai insignia x 1";
					pictureBox15.BackgroundImage = Resources.Twisted_bow;
					pictureBox15.Tag = "Twisted bow x 1";
					break;
				case "Skotizo":
					// none
					break;
				case "Wintertodt":
					// none
					break;
				case "Zulrah":
					// none
					break;
				case "Abyssal Sire":
					// none
					break;
				case "Cerberus":
					// none
					break;
				case "Grotesque Guardians":
					// none
					break;
				case "Kraken":
					// none
					break;
				case "Thermonuclear Smoke Devil":
					// none
					break;
				case "Callisto":
					pictureBox1.BackgroundImage = Resources.Dragon_pickaxe;
					pictureBox1.Tag = "Dragon pickaxe x 1";
					pictureBox2.BackgroundImage = Resources.Dragon_2h_sword;
					pictureBox2.Tag = "Dragon 2h sword x 1";
					pictureBox3.BackgroundImage = Resources.Tyrannical_ring;
					pictureBox3.Tag = "Tyrannical ring x 1";
					break;
				case "Chaos Elemental":
					// none
					break;
				case "Chaos Fanatic":
					pictureBox1.BackgroundImage = Resources.Odium_shard_1;
					pictureBox1.Tag = "Odium shard 1 x 1";
					pictureBox2.BackgroundImage = Resources.Malediction_shard_1;
					pictureBox2.Tag = "Malediction shard 1 x 1";
					break;
				case "Crazy Archaeologist":
					pictureBox1.BackgroundImage = Resources.Fedora;
					pictureBox1.Tag = "Fedora x 1";
					pictureBox2.BackgroundImage = Resources.Odium_shard_2;
					pictureBox2.Tag = "Odium shard 2 x 1";
					pictureBox3.BackgroundImage = Resources.Malediction_shard_2;
					pictureBox3.Tag = "Malediction shard 2 x 1";
					break;
				case "King Black Dragon":
					pictureBox1.BackgroundImage = Resources.Dragon_pickaxe;
					pictureBox1.Tag = "Dragon pickaxe x 1";
					pictureBox2.BackgroundImage = Resources.Draconic_visage;
					pictureBox2.Tag = "Draconic visage x 1";
					break;
				case "Scorpia":
					pictureBox1.BackgroundImage = Resources.Odium_shard_3;
					pictureBox1.Tag = "Odium shard 3 x 1";
					pictureBox2.BackgroundImage = Resources.Malediction_shard_3;
					pictureBox2.Tag = "Malediction shard 3 x 1";
					break;
				case "Venenatis":
					pictureBox1.BackgroundImage = Resources.Dragon_2h_sword;
					pictureBox1.Tag = "Dragon 2h sword x 1";
					pictureBox2.BackgroundImage = Resources.Dragon_pickaxe;
					pictureBox2.Tag = "Dragon pickaxe x 1";
					pictureBox3.BackgroundImage = Resources.Treasonous_ring;
					pictureBox3.Tag = "Treasonous ring x 1";
					break;
				case "Vet'ion":
					pictureBox1.BackgroundImage = Resources.Dragon_2h_sword;
					pictureBox1.Tag = "Dragon 2h sword x 1";
					pictureBox2.BackgroundImage = Resources.Dragon_pickaxe;
					pictureBox2.Tag = "Dragon pickaxe x 1";
					pictureBox3.BackgroundImage = Resources.Ring_of_the_gods;
					pictureBox3.Tag = "Ring of the gods x 1";
					break;
				default:
					Console.WriteLine("[ERROR]: Unable to find boss to show uniques for. (Boss = " + boss + ")");
					break;
			}
			resizeSplitWindow(numUniques);
		}

		private void buttonSplitOk_Click(object sender, EventArgs e) {

			if (getCurrentSelectedPictureBox() == null) return;

			String splitItem = getCurrentSelectedPictureBox().Tag.ToString();
			String splitAmountText = textBoxSplitAmount.Text;

			if (string.IsNullOrWhiteSpace(splitItem)) {
				return;
			}

			if (string.IsNullOrWhiteSpace(splitAmountText)) {
				return;
			}

			int splitAmount = Int32.Parse(splitAmountText);

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
			//int splitItemQuantity = 1;
			//if (splitItem == "Dragon thrownaxe x 100") splitItemQuantity = 100;

			if (dropInOwnName) {
				formattedSplit = currentBoss + " [" + currentBossKillcount.ToString() + " kc], " + splitItem + /*" x " + splitItemQuantity +*/ " [sy=" + splitAmountText + "]";

				pictureBoxTest.Tag = splitItem/* + " x " + splitItemQuantity.ToString()*/;
				dropLogger.OldSchoolDropLogger.instance.pictureBox_Click(pictureBoxTest, null);
			}
			else {
				formattedSplit = currentBoss + ", " + splitItem + /*" x " + splitItemQuantity + */" [sn=" + splitAmountText + "]";
			}
			// 3. Saradomin, Saradomin hilt x 1[sn = 20000000]
			// 4. Saradomin[3 kc], Armadyl crossbow[sy = 13850000]

			List<String> newLoggedSplits = alreadyLoggedSplits;

			newLoggedSplits.Add(formattedSplit);

			writeSplitsToFile(alreadyLoggedSplits);

			this.Close();

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

		private void resizeSplitWindow(int numberOfUniques) {

			int numberOfRowsHidden = 4;

			// calculate number of rows to hide
			int numberUniquesCopy = numberOfUniques;

			for (int i = 0; i < numberOfUniques; i++) {
				if (numberUniquesCopy > 0) {
					numberUniquesCopy -= 5;
					numberOfRowsHidden--;
				}
				else {
					break;
				}
			}

			int totalDistModifier = 35 * numberOfRowsHidden;

			if (numberOfUniques == 0) {
				this.Size = new Size(245, 292 - 105);
				labelSplitAmountText.Location = new Point(12, 162 - 105);
				textBoxSplitAmount.Location = new Point(87, 160 - 105);
				labelDropInYourNameText.Location = new Point(12, 192 - 105);
				panelYesNoRadio.Location = new Point(117, 187 - 105);
				buttonSplitOk.Location = new Point(36, 219 - 105);
				buttonSplitCancel.Location = new Point(117, 219 - 105);
			}
			else if (numberOfUniques <= 5) {
				this.Size = new Size(245, 292 - totalDistModifier);
				labelSplitAmountText.Location = new Point(12, 162 - totalDistModifier);
				textBoxSplitAmount.Location = new Point(87, 160 - totalDistModifier);
				labelDropInYourNameText.Location = new Point(12, 192 - totalDistModifier);
				panelYesNoRadio.Location = new Point(117, 187 - totalDistModifier);
				buttonSplitOk.Location = new Point(36, 219 - totalDistModifier);
				buttonSplitCancel.Location = new Point(117, 219 - totalDistModifier);
			}
			else if (numberOfUniques <= 10) {
				this.Size = new Size(245, 292 - totalDistModifier);
				labelSplitAmountText.Location = new Point(12, 162 - totalDistModifier);
				textBoxSplitAmount.Location = new Point(87, 160 - totalDistModifier);
				labelDropInYourNameText.Location = new Point(12, 192 - totalDistModifier);
				panelYesNoRadio.Location = new Point(117, 187 - totalDistModifier);
				buttonSplitOk.Location = new Point(36, 219 - totalDistModifier);
				buttonSplitCancel.Location = new Point(117, 219 - totalDistModifier);
			}
			else if (numberOfUniques <= 15) {
				this.Size = new Size(245, 292 - totalDistModifier);
				labelSplitAmountText.Location = new Point(12, 162 - totalDistModifier);
				textBoxSplitAmount.Location = new Point(87, 160 - totalDistModifier);
				labelDropInYourNameText.Location = new Point(12, 192 - totalDistModifier);
				panelYesNoRadio.Location = new Point(117, 187 - totalDistModifier);
				buttonSplitOk.Location = new Point(36, 219 - totalDistModifier);
				buttonSplitCancel.Location = new Point(117, 219 - totalDistModifier);
			}
			else if (numberOfUniques <= 20) {
				this.Size = new Size(245, 292 - totalDistModifier);
				labelSplitAmountText.Location = new Point(12, 162 - totalDistModifier);
				textBoxSplitAmount.Location = new Point(87, 160 - totalDistModifier);
				labelDropInYourNameText.Location = new Point(12, 192 - totalDistModifier);
				panelYesNoRadio.Location = new Point(117, 187 - totalDistModifier);
				buttonSplitOk.Location = new Point(36, 219 - totalDistModifier);
				buttonSplitCancel.Location = new Point(117, 219 - totalDistModifier);
			}

			setNPictureBoxesAsVisible(numberOfUniques);
		}

		private void setNPictureBoxesAsVisible(int n) {
			switch (n) {
				case 0:
					labelNoUniquesForBoss.Visible = true;
					buttonSplitOk.Enabled = false;
					textBoxSplitAmount.Enabled = false;
					radioButtonOwnDropNo.Enabled = false;
					radioButtonOwnDropYes.Enabled = false;
					pictureBox1.Visible = false;
					pictureBox2.Visible = false;
					pictureBox3.Visible = false;
					pictureBox4.Visible = false;
					pictureBox5.Visible = false;
					pictureBox6.Visible = false;
					pictureBox7.Visible = false;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 1:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = false;
					pictureBox3.Visible = false;
					pictureBox4.Visible = false;
					pictureBox5.Visible = false;
					pictureBox6.Visible = false;
					pictureBox7.Visible = false;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 2:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = false;
					pictureBox4.Visible = false;
					pictureBox5.Visible = false;
					pictureBox6.Visible = false;
					pictureBox7.Visible = false;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 3:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = false;
					pictureBox5.Visible = false;
					pictureBox6.Visible = false;
					pictureBox7.Visible = false;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 4:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = false;
					pictureBox6.Visible = false;
					pictureBox7.Visible = false;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 5:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = false;
					pictureBox7.Visible = false;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 6:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = false;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 7:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 8:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = false;
					pictureBox9.Visible = false;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 9:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = false;
					pictureBox11.Visible = false;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 10:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = true;
					pictureBox15.Visible = true;
					pictureBox16.Visible = true;
					pictureBox17.Visible = true;
					pictureBox18.Visible = true;
					pictureBox19.Visible = true;
					pictureBox20.Visible = true;
					break;
				case 11:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = false;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 12:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = false;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 13:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = false;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 14:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = true;
					pictureBox15.Visible = false;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 15:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = true;
					pictureBox15.Visible = true;
					pictureBox16.Visible = false;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 16:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = true;
					pictureBox15.Visible = true;
					pictureBox16.Visible = true;
					pictureBox17.Visible = false;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 17:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = true;
					pictureBox15.Visible = true;
					pictureBox16.Visible = true;
					pictureBox17.Visible = true;
					pictureBox18.Visible = false;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 18:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = true;
					pictureBox15.Visible = true;
					pictureBox16.Visible = true;
					pictureBox17.Visible = true;
					pictureBox18.Visible = true;
					pictureBox19.Visible = false;
					pictureBox20.Visible = false;
					break;
				case 19:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = true;
					pictureBox15.Visible = true;
					pictureBox16.Visible = true;
					pictureBox17.Visible = true;
					pictureBox18.Visible = true;
					pictureBox19.Visible = true;
					pictureBox20.Visible = false;
					break;
				case 20:
					labelNoUniquesForBoss.Visible = false;
					buttonSplitOk.Enabled = true;
					textBoxSplitAmount.Enabled = true;
					radioButtonOwnDropNo.Enabled = true;
					radioButtonOwnDropYes.Enabled = true;
					pictureBox1.Visible = true;
					pictureBox2.Visible = true;
					pictureBox3.Visible = true;
					pictureBox4.Visible = true;
					pictureBox5.Visible = true;
					pictureBox6.Visible = true;
					pictureBox7.Visible = true;
					pictureBox8.Visible = true;
					pictureBox9.Visible = true;
					pictureBox10.Visible = true;
					pictureBox11.Visible = true;
					pictureBox12.Visible = true;
					pictureBox13.Visible = true;
					pictureBox14.Visible = true;
					pictureBox15.Visible = true;
					pictureBox16.Visible = true;
					pictureBox17.Visible = true;
					pictureBox18.Visible = true;
					pictureBox19.Visible = true;
					pictureBox20.Visible = true;
					break;
			}
		}
		private PictureBox getCurrentSelectedPictureBox() {
			foreach (PictureBox p in allPictureBoxes) {
				if (p.BackColor == highlightOrange) {
					return p;
				}
			}
			return null;
		}
		private void pictureBox_Click(object sender, EventArgs e) {
			PictureBox pbSender = (PictureBox)sender;

			highlightPictureBox(pbSender);
		}
		private void highlightPictureBox(PictureBox pb, Boolean resetAll = true) {

			// Only reset the pictures if it is set - this will not reset pictures when control is held
			if (resetAll) {
				resetAllPictureBoxBackgroundColor();
			}

			// Still change the picture box that was clicked
			pb.BackColor = highlightOrange;
		}
		List<PictureBox> allPictureBoxes = new List<PictureBox>();
		private void putAllPictureBoxesIntoList() {
			// Put all pictureboxes into allPictureBoxes list
			Control[] c;
			for (int i = 1; i <= 20; i++) {
				c = this.Controls.Find("pictureBox" + i.ToString(), true);
				allPictureBoxes.Add((PictureBox)c[0]);
			}
		}
		private void resetAllPictureBoxBackgroundColor() {
			foreach (PictureBox p in allPictureBoxes) {
				p.BackColor = Color.Transparent;
			}
		}

		private void SplitDropForm_Load(object sender, EventArgs e) {
			this.Location = new Point(this.Owner.Location.X - 230, this.Owner.Location.Y);
		}
	}
}
