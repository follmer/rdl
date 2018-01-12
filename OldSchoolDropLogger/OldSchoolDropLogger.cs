using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using rareDropTable;
using splitDrop;
using Config;
using itemQuantityCreator;
using OldSchoolDropLogger.Properties;

namespace dropLogger {
	public partial class OldSchoolDropLogger : Form {

		ItemQuantityCreator iqc;
		private stats.StatisticsForm stats = null;
		
		private String selectedDagannothKing = "Dagannoth Prime";
		private String selectedDagannothKingLoot = "Dagannoth Prime";
		private String logsFilePath = AppDomain.CurrentDomain.BaseDirectory + "/logs/";
		private String viewingDropsFromBoss = "";
		private String lastBossViewed = "";

		private List<String> listboxItemsList = new List<String>();

		private Color highlightOrange = Color.FromArgb(179, 107, 0);

		private String activeSidebarWindow = null;

		// Timer declarations
		readonly int ARMADYL_RESPAWN_TIME = 90;
		readonly int BANDOS_RESPAWN_TIME = 90;
		readonly int SARADOMIN_RESPAWN_TIME = 90;
		readonly int ZAMORAK_RESPAWN_TIME = 90;
		readonly int CALLISTO_RESPAWN_TIME = -1;
		readonly int CHAOS_ELEMENTAL_RESPAWN_TIME = 150;
		readonly int CHAOS_FANATIC_RESPAWN_TIME = 10;
		readonly int CRAZY_ARCHAEOLOGIST_RESPAWN_TIME = 10;
		readonly int KING_BLACK_DRAGON_RESPAWN_TIME = 10;
		readonly int SCORPIA_RESPAWN_TIME = 10;
		readonly int VENENATIS_RESPAWN_TIME = -1;
		readonly int VETION_RESPAWN_TIME = -1;
		readonly int DAGANNOTH_PRIME_RESPAWN_TIME = 90;
		readonly int DAGANNOTH_REX_RESPAWN_TIME = 90;
		readonly int DAGANNOTH_SUPREME_RESPAWN_TIME = 90;
		readonly int GIANT_MOLE_RESPAWN_TIME = 10;
		readonly int KALPHITE_QUEEN_RESPAWN_TIME = -1;
		readonly int THERMONUCLEAR_SMOKE_DEVIL_RESPAWN_TIME = -1;

		// Create an instance of this class so data can be passed to it from other forms
		public static OldSchoolDropLogger instance;

		private List<PictureBox> allPictureBoxes = new List<PictureBox>();

		private Boolean isStatisticsInstantiated = false;

		private String sidebarViewingLootFromBoss = "";

		/* Getters and Setters */
		private void setSelectedDagannothKing(String king) {
			selectedDagannothKing = king;
		}
		private String getSelectedDagannothKing() {
			return selectedDagannothKing;
		}
		private void setSelectedDagannothKingLoot(String king) {
			selectedDagannothKingLoot = king;
		}
		private String getSelectedDagannothKingLoot() {
			return selectedDagannothKingLoot;
		}
		public int getBossKillcount(String boss) {
			if (stats == null) {
				stats = new stats.StatisticsForm();
			}
			return stats.getBossKills(boss);
		}
		public List<String> getSplitsFromFile() {
			List<String> loggedSplitItems = new List<String>();

			// If a log file exists for the given boss, tries to get the log file for that boss
			// and convert it to a list, stripping any preceeding numbers, periods, and whitespace
			try {

				String splitsFileLocation = AppDomain.CurrentDomain.BaseDirectory + "/logs/Splits.txt";
				Console.WriteLine("[DEBUG]: " + splitsFileLocation);
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

		public String getCurrentBoss() {
			return labelCurrentLogFor.Text.Replace("Current log for: ", "").Trim();
		}
		private String getViewingDropsFromBoss() {
			return viewingDropsFromBoss;
		}
		private void setViewingDropsFromBoss(String boss) {
			viewingDropsFromBoss = boss;
		}

		/* Menu strip handlers */
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}
		private void twitterToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("https://twitter.com/Im_Hess");
		}

		private void armadylToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + armadylToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_crossbow;
			pictureBox1.Tag = "Rune crossbow x 1";
			pictureBox2.BackgroundImage = Resources.Rune_sword;
			pictureBox2.Tag = "Rune sword x 1";
			pictureBox3.BackgroundImage = Resources.Runite_bolts_5;
			pictureBox3.Tag = "Varies; Runite bolts";
			pictureBox4.BackgroundImage = Resources.Rune_arrow_5;
			pictureBox4.Tag = "Varies; Rune arrow";
			pictureBox5.BackgroundImage = Resources.Dragon_bolts__e__5;
			pictureBox5.Tag = "Varies; Dragon bolts (e)";
			pictureBox6.BackgroundImage = Resources.Mind_rune;
			pictureBox6.Tag = "Varies; Mind rune";
			pictureBox7.BackgroundImage = Resources.Coins_10000;
			pictureBox7.Tag = "Varies; Coins";
			pictureBox8.BackgroundImage = Resources.Dwarf_weed_noted_generic;
			pictureBox8.Tag = "Varies; Dwarf weed";
			pictureBox9.BackgroundImage = Resources.Dwarf_weed_seed_3;
			pictureBox9.Tag = "Dwarf weed seed x 3";
			pictureBox10.BackgroundImage = Resources.Yew_seed_1;
			pictureBox10.Tag = "Yew seed x 1";
			pictureBox11.BackgroundImage = Resources.Ranging_potion__3_;
			pictureBox11.Tag = "Ranging potion (3) x 3";
			pictureBox12.BackgroundImage = Resources.Super_defence__3_;
			pictureBox12.Tag = "Super defence (3) x 3";
			pictureBox13.BackgroundImage = Resources.Crystal_key;
			pictureBox13.Tag = "Crystal key x 1";
			pictureBox14.BackgroundImage = Resources.Black_d_hide_body;
			pictureBox14.Tag = "Black d'hide body x 1";
			pictureBox15.BackgroundImage = Resources.Long_bone;
			pictureBox15.Tag = "Long bone x 1";
			pictureBox16.BackgroundImage = Resources.Curved_bone;
			pictureBox16.Tag = "Curved bone x 1";
			pictureBox17.BackgroundImage = Resources.Godsword_shard_1;
			pictureBox17.Tag = "Godsword shard 1 x 1";
			pictureBox18.BackgroundImage = Resources.Godsword_shard_2;
			pictureBox18.Tag = "Godsword shard 2 x 1";
			pictureBox19.BackgroundImage = Resources.Godsword_shard_3;
			pictureBox19.Tag = "Godsword shard 3 x 1";
			pictureBox20.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox20.Tag = "Elite clue scroll x 1";
			pictureBox21.BackgroundImage = Resources.Armadyl_helmet;
			pictureBox21.Tag = "Armadyl helmet x 1";
			pictureBox22.BackgroundImage = Resources.Armadyl_chestplate;
			pictureBox22.Tag = "Armadyl chestplate x 1";
			pictureBox23.BackgroundImage = Resources.Armadyl_chainskirt;
			pictureBox23.Tag = "Armadyl chainskirt x 1";
			pictureBox24.BackgroundImage = Resources.Armadyl_hilt;
			pictureBox24.Tag = "Armadyl hilt x 1";
			pictureBox25.BackgroundImage = Resources.Pet_kree_arra;
			pictureBox25.Tag = "Pet kree'arra x 1";
			pictureBox26.BackgroundImage = Resources.RDT;
			pictureBox26.Tag = "RDT";
			setNPictureBoxesToVisible(26);
			setNPictureBoxesToEnabled(26);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void bandosToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + bandosToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_2h_sword;
			pictureBox1.Tag = "Rune 2h sword x 1";
			pictureBox2.BackgroundImage = Resources.Rune_pickaxe;
			pictureBox2.Tag = "Rune pickaxe x 1";
			pictureBox3.BackgroundImage = Resources.Rune_longsword;
			pictureBox3.Tag = "Rune longsword x 1";
			pictureBox4.BackgroundImage = Resources.Rune_sword;
			pictureBox4.Tag = "Rune sword x 1";
			pictureBox5.BackgroundImage = Resources.Rune_platebody;
			pictureBox5.Tag = "Rune platebody x 1";
			pictureBox6.BackgroundImage = Resources.Nature_rune;
			pictureBox6.Tag = "Varies; Nature rune";
			pictureBox7.BackgroundImage = Resources.Adamantite_ore_noted_generic;
			pictureBox7.Tag = "Varies; Adamantite ore";
			pictureBox8.BackgroundImage = Resources.Coal_noted_generic;
			pictureBox8.Tag = "Varies; Coal";
			pictureBox9.BackgroundImage = Resources.Magic_logs_noted_generic;
			pictureBox9.Tag = "Varies; Magic logs";
			pictureBox10.BackgroundImage = Resources.Snapdragon_seed_1;
			pictureBox10.Tag = "Snapdragon seed x 1";
			pictureBox11.BackgroundImage = Resources.Grimy_snapdragon_noted_3;
			pictureBox11.Tag = "Grimy snapdragon x 3";
			pictureBox12.BackgroundImage = Resources.Super_restore__4_;
			pictureBox12.Tag = "Super restore (4) x 3";
			pictureBox13.BackgroundImage = Resources.Coins_10000;
			pictureBox13.Tag = "Varies; Coins";
			pictureBox14.BackgroundImage = Resources.Long_bone;
			pictureBox14.Tag = "Long bone x 1";
			pictureBox15.BackgroundImage = Resources.Curved_bone;
			pictureBox15.Tag = "Curved bone x 1";
			pictureBox16.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox16.Tag = "Elite clue scroll x 1";
			pictureBox17.BackgroundImage = Resources.Godsword_shard_1;
			pictureBox17.Tag = "Godsword shard 1 x 1";
			pictureBox18.BackgroundImage = Resources.Godsword_shard_2;
			pictureBox18.Tag = "Godsword shard 2 x 1";
			pictureBox19.BackgroundImage = Resources.Godsword_shard_3;
			pictureBox19.Tag = "Godsword shard 3 x 1";
			pictureBox20.BackgroundImage = Resources.Bandos_chestplate;
			pictureBox20.Tag = "Bandos chestplate x 1";
			pictureBox21.BackgroundImage = Resources.Bandos_tassets;
			pictureBox21.Tag = "Bandos tassets x 1";
			pictureBox22.BackgroundImage = Resources.Bandos_boots;
			pictureBox22.Tag = "Bandos boots x 1";
			pictureBox23.BackgroundImage = Resources.Bandos_hilt;
			pictureBox23.Tag = "Bandos hilt x 1";
			pictureBox24.BackgroundImage = Resources.Pet_general_graardor;
			pictureBox24.Tag = "Pet general graardor x 1";
			pictureBox25.BackgroundImage = Resources.RDT;
			pictureBox25.Tag = "RDT";
			setNPictureBoxesToVisible(25);
			setNPictureBoxesToEnabled(25);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void saradominToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + saradominToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_dart;
			pictureBox1.Tag = "Varies; Rune dart";
			pictureBox2.BackgroundImage = Resources.Rune_sword;
			pictureBox2.Tag = "Rune sword x 1";
			pictureBox3.BackgroundImage = Resources.Adamant_platebody;
			pictureBox3.Tag = "Adamant platebody x 1";
			pictureBox4.BackgroundImage = Resources.Rune_plateskirt;
			pictureBox4.Tag = "Rune plateskirt x 1";
			pictureBox5.BackgroundImage = Resources.Rune_kiteshield;
			pictureBox5.Tag = "Rune kiteshield x 1";
			pictureBox6.BackgroundImage = Resources.Law_rune;
			pictureBox6.Tag = "Varies; Law rune";
			pictureBox7.BackgroundImage = Resources.Ranarr_seed_2;
			pictureBox7.Tag = "Ranarr seed x 2";
			pictureBox8.BackgroundImage = Resources.Magic_seed_1;
			pictureBox8.Tag = "Magic seed x 1";
			pictureBox9.BackgroundImage = Resources.Diamond_noted_6;
			pictureBox9.Tag = "Diamond x 6";
			pictureBox10.BackgroundImage = Resources.Grimy_ranarr_weed;
			pictureBox10.Tag = "Grimy ranarr weed x 5";
			pictureBox11.BackgroundImage = Resources.Prayer_potion__4_;
			pictureBox11.Tag = "Prayer potion (4) x 3";
			pictureBox12.BackgroundImage = Resources.Saradomin_brew__3_;
			pictureBox12.Tag = "Saradomin brew (3) x 3";
			pictureBox13.BackgroundImage = Resources.Super_restore__4_;
			pictureBox13.Tag = "Super restore (4) x 3";
			pictureBox14.BackgroundImage = Resources.Super_defence__4_;
			pictureBox14.Tag = "Super defence (4) x 3";
			pictureBox15.BackgroundImage = Resources.Magic_potion__3_;
			pictureBox15.Tag = "Magic potion (3) x 3";
			pictureBox16.BackgroundImage = Resources.Coins_10000;
			pictureBox16.Tag = "Varies; Coins";
			pictureBox17.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox17.Tag = "Elite clue scroll x 1";
			pictureBox18.BackgroundImage = Resources.Godsword_shard_1;
			pictureBox18.Tag = "Godsword shard 1 x 1";
			pictureBox19.BackgroundImage = Resources.Godsword_shard_2;
			pictureBox19.Tag = "Godsword shard 2 x 1";
			pictureBox20.BackgroundImage = Resources.Godsword_shard_3;
			pictureBox20.Tag = "Godsword shard 3 x 1";
			pictureBox21.BackgroundImage = Resources.Saradomin_s_light;
			pictureBox21.Tag = "Saradomin's light x 1";
			pictureBox22.BackgroundImage = Resources.Saradomin_sword;
			pictureBox22.Tag = "Saradomin sword x 1";
			pictureBox23.BackgroundImage = Resources.Armadyl_crossbow;
			pictureBox23.Tag = "Armadyl crossbow x 1";
			pictureBox24.BackgroundImage = Resources.Saradomin_hilt;
			pictureBox24.Tag = "Saradomin hilt x 1";
			pictureBox25.BackgroundImage = Resources.Pet_zilyana;
			pictureBox25.Tag = "Pet zilyana x 1";
			pictureBox26.BackgroundImage = Resources.RDT;
			pictureBox26.Tag = "RDT";
			setNPictureBoxesToVisible(26);
			setNPictureBoxesToEnabled(26);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void zamorakToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + zamorakToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_sword;
			pictureBox1.Tag = "Rune sword x 1";
			pictureBox2.BackgroundImage = Resources.Rune_scimitar;
			pictureBox2.Tag = "Rune scimitar x 1";
			pictureBox3.BackgroundImage = Resources.Dragon_dagger__p___;
			pictureBox3.Tag = "Dragon dagger (p++) x 1";
			pictureBox4.BackgroundImage = Resources.Adamant_arrow_5;
			pictureBox4.Tag = "Varies; Adamant arrow";
			pictureBox5.BackgroundImage = Resources.Adamant_platebody;
			pictureBox5.Tag = "Adamant platebody x 1";
			pictureBox6.BackgroundImage = Resources.Rune_platelegs;
			pictureBox6.Tag = "Rune platelegs x 1";
			pictureBox7.BackgroundImage = Resources.Lantadyme_seed_3;
			pictureBox7.Tag = "Lantadyme seed x 3";
			pictureBox8.BackgroundImage = Resources.Grimy_lantadyme_noted_generic;
			pictureBox8.Tag = "Varies; Grimy lantadyme";
			pictureBox9.BackgroundImage = Resources.Super_attack__3_;
			pictureBox9.Tag = "Super attack (3) x 3";
			pictureBox10.BackgroundImage = Resources.Super_strength__3_;
			pictureBox10.Tag = "Super strength (3) x 3";
			pictureBox11.BackgroundImage = Resources.Super_restore__3_;
			pictureBox11.Tag = "Super restore (3) x 3";
			pictureBox12.BackgroundImage = Resources.Zamorak_brew__3_;
			pictureBox12.Tag = "Zamorak brew (3) x 3";
			pictureBox13.BackgroundImage = Resources.Death_rune;
			pictureBox13.Tag = "Varies; Death rune";
			pictureBox14.BackgroundImage = Resources.Blood_rune;
			pictureBox14.Tag = "Varies; Blood rune";
			pictureBox15.BackgroundImage = Resources.Coins_10000;
			pictureBox15.Tag = "Varies; Coins";
			pictureBox16.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox16.Tag = "Elite clue scroll x 1";
			pictureBox17.BackgroundImage = Resources.Godsword_shard_1;
			pictureBox17.Tag = "Godsword shard 1 x 1";
			pictureBox18.BackgroundImage = Resources.Godsword_shard_2;
			pictureBox18.Tag = "Godsword shard 2 x 1";
			pictureBox19.BackgroundImage = Resources.Godsword_shard_3;
			pictureBox19.Tag = "Godsword shard 3 x 1";
			pictureBox20.BackgroundImage = Resources.Steam_battlestaff;
			pictureBox20.Tag = "Steam battlestaff x 1";
			pictureBox21.BackgroundImage = Resources.Staff_of_the_dead;
			pictureBox21.Tag = "Staff of the dead x 1";
			pictureBox22.BackgroundImage = Resources.Zamorakian_spear;
			pictureBox22.Tag = "Zamorakian spear x 1";
			pictureBox23.BackgroundImage = Resources.Zamorak_hilt;
			pictureBox23.Tag = "Zamorak hilt x 1";
			pictureBox24.BackgroundImage = Resources.Pet_k_ril_tsutsaroth;
			pictureBox24.Tag = "Pet k'ril tsutsaroth x 1";
			pictureBox25.BackgroundImage = Resources.RDT;
			pictureBox25.Tag = "RDT";
			setNPictureBoxesToVisible(25);
			setNPictureBoxesToEnabled(25);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void callistoToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + callistoToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_pickaxe;
			pictureBox1.Tag = "Rune pickaxe x 1";
			pictureBox2.BackgroundImage = Resources.Rune_2h_sword;
			pictureBox2.Tag = "Rune 2h sword x 1";
			pictureBox3.BackgroundImage = Resources.Soul_rune_250;
			pictureBox3.Tag = "Soul rune x 250";
			pictureBox4.BackgroundImage = Resources.Death_rune_300;
			pictureBox4.Tag = "Death rune x 300";
			pictureBox5.BackgroundImage = Resources.Chaos_rune_400;
			pictureBox5.Tag = "Chaos rune x 400";
			pictureBox6.BackgroundImage = Resources.Blood_rune_200;
			pictureBox6.Tag = "Blood rune x 200";
			pictureBox7.BackgroundImage = Resources.Mahogany_logs_noted_400;
			pictureBox7.Tag = "Mahogany logs x 400";
			pictureBox8.BackgroundImage = Resources.Magic_logs_noted_100;
			pictureBox8.Tag = "Magic logs x 100";
			pictureBox9.BackgroundImage = Resources.Ranarr_seed_5;
			pictureBox9.Tag = "Ranarr seed x 5";
			pictureBox10.BackgroundImage = Resources.Snapdragon_seed_3;
			pictureBox10.Tag = "Snapdragon seed x 3";
			pictureBox11.BackgroundImage = Resources.Palm_tree_seed_1;
			pictureBox11.Tag = "Palm tree seed x 1";
			pictureBox12.BackgroundImage = Resources.Yew_seed_1;
			pictureBox12.Tag = "Yew seed x 1";
			pictureBox13.BackgroundImage = Resources.Magic_seed_1;
			pictureBox13.Tag = "Magic seed x 1";
			pictureBox14.BackgroundImage = Resources.Grimy_toadflax_noted_100;
			pictureBox14.Tag = "Grimy toadflax x 100";
			pictureBox15.BackgroundImage = Resources.Dark_fishing_bait_375;
			pictureBox15.Tag = "Dark fishing bait x 375";
			pictureBox16.BackgroundImage = Resources.Dark_crab;
			pictureBox16.Tag = "Dark crab x 8";
			pictureBox17.BackgroundImage = Resources.Super_restore__4_;
			pictureBox17.Tag = "Super restore (4) x 3";
			pictureBox18.BackgroundImage = Resources.Mysterious_emblem;
			pictureBox18.Tag = "Mysterious emblem x 1";
			pictureBox19.BackgroundImage = Resources.Limpwurt_root_noted_50;
			pictureBox19.Tag = "Limpwurt root x 50";
			pictureBox20.BackgroundImage = Resources.Coconut_noted_60;
			pictureBox20.Tag = "Coconut x 60";
			pictureBox21.BackgroundImage = Resources.Crushed_nest_noted_75;
			pictureBox21.Tag = "Crushed nest x 75";
			pictureBox22.BackgroundImage = Resources.Supercompost_noted_100;
			pictureBox22.Tag = "Supercompost x 100";
			pictureBox23.BackgroundImage = Resources.Cannonball_250;
			pictureBox23.Tag = "Cannonball x 250";
			pictureBox24.BackgroundImage = Resources.Red_dragonhide_noted_75;
			pictureBox24.Tag = "Red dragonhide x 75";
			pictureBox25.BackgroundImage = Resources.Uncut_ruby_noted_20;
			pictureBox25.Tag = "Uncut ruby x 20";
			pictureBox26.BackgroundImage = Resources.Uncut_diamond_noted_10;
			pictureBox26.Tag = "Uncut diamond x 10";
			pictureBox27.BackgroundImage = Resources.Uncut_dragonstone;
			pictureBox27.Tag = "Uncut dragonstone x 1";
			pictureBox28.BackgroundImage = Resources.Coins_10000;
			pictureBox28.Tag = "Varies; Coins";
			pictureBox29.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox29.Tag = "Elite clue scroll x 1";
			pictureBox30.BackgroundImage = Resources.Dragon_pickaxe;
			pictureBox30.Tag = "Dragon pickaxe x 1";
			pictureBox31.BackgroundImage = Resources.Dragon_2h_sword;
			pictureBox31.Tag = "Dragon 2h sword x 1";
			pictureBox32.BackgroundImage = Resources.Tyrannical_ring;
			pictureBox32.Tag = "Tyrannical ring x 1";
			pictureBox33.BackgroundImage = Resources.Callisto_cub;
			pictureBox33.Tag = "Callisto cub x 1";
			pictureBox34.BackgroundImage = Resources.RDT;
			pictureBox34.Tag = "RDT";
			setNPictureBoxesToVisible(34);
			setNPictureBoxesToEnabled(34);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void chaosElementalToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + chaosElementalToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Mithril_dart_300;
			pictureBox1.Tag = "Mithril dart x 300";
			pictureBox2.BackgroundImage = Resources.Rune_arrow_150;
			pictureBox2.Tag = "Rune arrow x 150";
			pictureBox3.BackgroundImage = Resources.Chaos_rune_250;
			pictureBox3.Tag = "Chaos rune x 250";
			pictureBox4.BackgroundImage = Resources.Air_rune_500;
			pictureBox4.Tag = "Air rune x 500";
			pictureBox5.BackgroundImage = Resources.Death_rune_125;
			pictureBox5.Tag = "Death rune x 125";
			pictureBox6.BackgroundImage = Resources.Blood_rune_75;
			pictureBox6.Tag = "Blood rune x 75";
			pictureBox7.BackgroundImage = Resources.Anchovy_pizza;
			pictureBox7.Tag = "Anchovy pizza x 3";
			pictureBox8.BackgroundImage = Resources.Tuna;
			pictureBox8.Tag = "Tuna x 5";
			pictureBox9.BackgroundImage = Resources.Grimy_guam_leaf;
			pictureBox9.Tag = "Varies; Grimy guam leaf";
			pictureBox10.BackgroundImage = Resources.Grimy_marrentill;
			pictureBox10.Tag = "Varies; Grimy marrentill";
			pictureBox11.BackgroundImage = Resources.Grimy_tarromin;
			pictureBox11.Tag = "Varies; Grimy tarromin";
			pictureBox12.BackgroundImage = Resources.Grimy_harralander;
			pictureBox12.Tag = "Varies; Grimy harralander";
			pictureBox13.BackgroundImage = Resources.Grimy_ranarr_weed;
			pictureBox13.Tag = "Varies; Grimy ranarr weed";
			pictureBox14.BackgroundImage = Resources.Grimy_irit_leaf;
			pictureBox14.Tag = "Varies; Grimy irit leaf";
			pictureBox15.BackgroundImage = Resources.Grimy_avantoe;
			pictureBox15.Tag = "Varies; Grimy avantoe";
			pictureBox16.BackgroundImage = Resources.Grimy_kwuarm;
			pictureBox16.Tag = "Varies; Grimy kwuarm";
			pictureBox17.BackgroundImage = Resources.Grimy_cadantine;
			pictureBox17.Tag = "Varies; Grimy cadantine";
			pictureBox18.BackgroundImage = Resources.Grimy_lantadyme;
			pictureBox18.Tag = "Varies; Grimy lantadyme";
			pictureBox19.BackgroundImage = Resources.Grimy_dwarf_weed;
			pictureBox19.Tag = "Varies; Grimy dwarf weed";
			pictureBox20.BackgroundImage = Resources.Super_attack__4_;
			pictureBox20.Tag = "Super attack (4) x 1";
			pictureBox21.BackgroundImage = Resources.Super_strength__4_;
			pictureBox21.Tag = "Super strength (4) x 1";
			pictureBox22.BackgroundImage = Resources.Super_defence__4_;
			pictureBox22.Tag = "Super defence (4) x 1";
			pictureBox23.BackgroundImage = Resources.Weapon_poison_____;
			pictureBox23.Tag = "Weapon poison (++) x 1";
			pictureBox24.BackgroundImage = Resources.Antidote____4_;
			pictureBox24.Tag = "Antidote++ (4) x 1";
			pictureBox25.BackgroundImage = Resources.Strange_fruit_noted_10;
			pictureBox25.Tag = "Strange fruit x 10";
			pictureBox26.BackgroundImage = Resources.Bones;
			pictureBox26.Tag = "Bones x 4";
			pictureBox27.BackgroundImage = Resources.Bat_bones;
			pictureBox27.Tag = "Bat bones x 5";
			pictureBox28.BackgroundImage = Resources.Big_bones;
			pictureBox28.Tag = "Big bones x 3";
			pictureBox29.BackgroundImage = Resources.Babydragon_bones;
			pictureBox29.Tag = "Babydragon bones x 2";
			pictureBox30.BackgroundImage = Resources.Dragon_bones;
			pictureBox30.Tag = "Dragon bones x 1";
			pictureBox31.BackgroundImage = Resources.Coins_7500;
			pictureBox31.Tag = "Coins 7500 x 1";
			pictureBox32.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox32.Tag = "Elite clue scroll x 1";
			pictureBox33.BackgroundImage = Resources.Pet_chaos_elemental;
			pictureBox33.Tag = "Pet chaos elemental x 1";
			pictureBox34.BackgroundImage = Resources.RDT;
			pictureBox34.Tag = "RDT";
			setNPictureBoxesToVisible(34);
			setNPictureBoxesToEnabled(34);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void chaosFanaticToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + chaosFanaticToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Fire_rune_250;
			pictureBox1.Tag = "Fire rune x 250";
			pictureBox2.BackgroundImage = Resources.Smoke_rune_30;
			pictureBox2.Tag = "Smoke rune x 30";
			pictureBox3.BackgroundImage = Resources.Chaos_rune_175;
			pictureBox3.Tag = "Chaos rune x 175";
			pictureBox4.BackgroundImage = Resources.Blood_rune_50;
			pictureBox4.Tag = "Blood rune x 50";
			pictureBox5.BackgroundImage = Resources.Pure_essence_noted_250;
			pictureBox5.Tag = "Pur essence x 250";
			pictureBox6.BackgroundImage = Resources.Uncut_sapphire_noted_4;
			pictureBox6.Tag = "Uncut sapphire x 4";
			pictureBox7.BackgroundImage = Resources.Uncut_emerald_noted_6;
			pictureBox7.Tag = "Uncut emerald x 6";
			pictureBox8.BackgroundImage = Resources.Ring_of_life;
			pictureBox8.Tag = "Ring of life x 1";
			pictureBox9.BackgroundImage = Resources.Chaos_talisman;
			pictureBox9.Tag = "Chaos talisman x 1";
			pictureBox10.BackgroundImage = Resources.Nature_talisman;
			pictureBox10.Tag = "Nature talisman x 1";
			pictureBox11.BackgroundImage = Resources.Zamorak_robe__top_;
			pictureBox11.Tag = "Zamorak robe (top) x 1";
			pictureBox12.BackgroundImage = Resources.Zamorak_robe__bottom_;
			pictureBox12.Tag = "Zamorak robe (bottom) x 1";
			pictureBox13.BackgroundImage = Resources.Splitbark_body;
			pictureBox13.Tag = "Splitbark body x 1";
			pictureBox14.BackgroundImage = Resources.Splitbark_legs;
			pictureBox14.Tag = "Splitbark legs x 1";
			pictureBox15.BackgroundImage = Resources.Prayer_potion__4_;
			pictureBox15.Tag = "Prayer potion (4) x 1";
			pictureBox16.BackgroundImage = Resources.Grimy_lantadyme_noted_4;
			pictureBox16.Tag = "Grimy lantadyme x 4";
			pictureBox17.BackgroundImage = Resources.Anchovy_pizza_noted_8;
			pictureBox17.Tag = "Anchovy pizza x 8";
			pictureBox18.BackgroundImage = Resources.Monkfish;
			pictureBox18.Tag = "Monkfish x 3";
			pictureBox19.BackgroundImage = Resources.Shark;
			pictureBox19.Tag = "Shark x 1";
			pictureBox20.BackgroundImage = Resources.Battlestaff_noted_5;
			pictureBox20.Tag = "Battlestaff x 5";
			pictureBox21.BackgroundImage = Resources.Wine_of_zamorak_noted_10;
			pictureBox21.Tag = "Wine of zamorak x 10";
			pictureBox22.BackgroundImage = Resources.Coins_1000;
			pictureBox22.Tag = "Varies; Coins";
			pictureBox23.BackgroundImage = Resources.Sinister_key;
			pictureBox23.Tag = "Sinister key x 1";
			pictureBox24.BackgroundImage = Resources.Mysterious_emblem;
			pictureBox24.Tag = "Mysterious emblem x 1";
			pictureBox25.BackgroundImage = Resources.Ancient_staff;
			pictureBox25.Tag = "Ancient staff x 1";
			pictureBox26.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox26.Tag = "Elite clue scroll x 1";
			pictureBox27.BackgroundImage = Resources.Odium_shard_1;
			pictureBox27.Tag = "Odium shard 1 x 1";
			pictureBox28.BackgroundImage = Resources.Malediction_shard_1;
			pictureBox28.Tag = "Malediction shard 1 x 1";
			pictureBox29.BackgroundImage = Resources.Pet_chaos_elemental;
			pictureBox29.Tag = "Pet chaos elemental x 1";
			pictureBox30.BackgroundImage = Resources.RDT;
			pictureBox30.Tag = "RDT";
			setNPictureBoxesToVisible(30);
			setNPictureBoxesToEnabled(30);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void crazyArchaeologistToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + crazyArchaeologistToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_crossbow;
			pictureBox1.Tag = "Rune crossbow x 2";
			pictureBox2.BackgroundImage = Resources.Rune_knife_10;
			pictureBox2.Tag = "Rune knife x 10";
			pictureBox3.BackgroundImage = Resources.Amulet_of_power;
			pictureBox3.Tag = "Amulet of power x 1";
			pictureBox4.BackgroundImage = Resources.Mud_rune_30;
			pictureBox4.Tag = "Mud rune x 30";
			pictureBox5.BackgroundImage = Resources.Potato_with_cheese;
			pictureBox5.Tag = "Potato with cheese x 3";
			pictureBox6.BackgroundImage = Resources.Anchovy_pizza_noted_8;
			pictureBox6.Tag = "Anchovy pizza x 8";
			pictureBox7.BackgroundImage = Resources.Shark;
			pictureBox7.Tag = "Shark x 1";
			pictureBox8.BackgroundImage = Resources.Prayer_potion__4_;
			pictureBox8.Tag = "Prayer potion (4) x 1";
			pictureBox9.BackgroundImage = Resources.Uncut_sapphire_noted_4;
			pictureBox9.Tag = "Uncut sapphire x 4";
			pictureBox10.BackgroundImage = Resources.Uncut_emerald_noted_6;
			pictureBox10.Tag = "Uncut emerald x 6";
			pictureBox11.BackgroundImage = Resources.Silver_ore_noted_40;
			pictureBox11.Tag = "Silver ore x 40";
			pictureBox12.BackgroundImage = Resources.Muddy_key;
			pictureBox12.Tag = "Muddy key x 1";
			pictureBox13.BackgroundImage = Resources.Rusty_sword;
			pictureBox13.Tag = "Rusty sword x 1";
			pictureBox14.BackgroundImage = Resources.Grimy_dwarf_weed_noted_4;
			pictureBox14.Tag = "Grimy dwarf weed x 4";
			pictureBox15.BackgroundImage = Resources.White_berries_noted_10;
			pictureBox15.Tag = "White berries x 10";
			pictureBox16.BackgroundImage = Resources.Cannonball_150;
			pictureBox16.Tag = "Cannonball x 150";
			pictureBox17.BackgroundImage = Resources.Red_d_hide_body;
			pictureBox17.Tag = "Red d'hide body x 1";
			pictureBox18.BackgroundImage = Resources.Red_dragonhide_noted_10;
			pictureBox18.Tag = "Red dragonhide x 10";
			pictureBox19.BackgroundImage = Resources.Coins_1000;
			pictureBox19.Tag = "Varies; Coins";
			pictureBox20.BackgroundImage = Resources.Onyx_bolt_tips_12;
			pictureBox20.Tag = "Onyx bolt tips x 12";
			pictureBox21.BackgroundImage = Resources.Mysterious_emblem;
			pictureBox21.Tag = "Mysterious emblem x 1";
			pictureBox22.BackgroundImage = Resources.Dragon_arrow_75;
			pictureBox22.Tag = "Dragon arrow x 75";
			pictureBox23.BackgroundImage = Resources.Long_bone;
			pictureBox23.Tag = "Long bone x 1";
			pictureBox24.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox24.Tag = "Elite clue scroll x 1";
			pictureBox25.BackgroundImage = Resources.Fedora;
			pictureBox25.Tag = "Fedora x 1";
			pictureBox26.BackgroundImage = Resources.Odium_shard_2;
			pictureBox26.Tag = "Odium shard 2 x 1";
			pictureBox27.BackgroundImage = Resources.Malediction_shard_2;
			pictureBox27.Tag = "Malediction shard 2 x 1";
			pictureBox28.BackgroundImage = Resources.RDT;
			pictureBox28.Tag = "RDT";
			setNPictureBoxesToVisible(28);
			setNPictureBoxesToEnabled(28);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void kingBlackDragonToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + kingBlackDragonToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_longsword;
			pictureBox1.Tag = "Rune longsword x 1";
			pictureBox2.BackgroundImage = Resources.Adamant_platebody;
			pictureBox2.Tag = "Adamant platebody x 1";
			pictureBox3.BackgroundImage = Resources.Adamant_kiteshield;
			pictureBox3.Tag = "Adamant kiteshield x 1";
			pictureBox4.BackgroundImage = Resources.Iron_arrow_690;
			pictureBox4.Tag = "Iron arrow x 690";
			pictureBox5.BackgroundImage = Resources.Runite_bolts_5;
			pictureBox5.Tag = "Varies; Runite bolts";
			pictureBox6.BackgroundImage = Resources.Dragon_dart_tips_generic;
			pictureBox6.Tag = "Varies; Dragon dart tips";
			pictureBox7.BackgroundImage = Resources.Dragon_arrowtips_5;
			pictureBox7.Tag = "Varies; Dragon arrowtips";
			pictureBox8.BackgroundImage = Resources.Dragon_javelin_heads_15;
			pictureBox8.Tag = "Dragon javelin heads x 15";
			pictureBox9.BackgroundImage = Resources.Fire_rune_300;
			pictureBox9.Tag = "Fire rune x 300";
			pictureBox10.BackgroundImage = Resources.Air_rune_300;
			pictureBox10.Tag = "Air rune x 300";
			pictureBox11.BackgroundImage = Resources.Blood_rune_30;
			pictureBox11.Tag = "Blood rune x 30";
			pictureBox12.BackgroundImage = Resources.Law_rune_30;
			pictureBox12.Tag = "Law rune x 30";
			pictureBox13.BackgroundImage = Resources.Amulet_of_power;
			pictureBox13.Tag = "Amulet of power x 1";
			pictureBox14.BackgroundImage = Resources.Yew_logs_noted_150;
			pictureBox14.Tag = "Yew logs x 150";
			pictureBox15.BackgroundImage = Resources.Shark;
			pictureBox15.Tag = "Shark x 4";
			pictureBox16.BackgroundImage = Resources.Gold_ore_noted_100;
			pictureBox16.Tag = "Gold ore x 100";
			pictureBox17.BackgroundImage = Resources.Runite_limbs;
			pictureBox17.Tag = "Runite limbs x 1";
			pictureBox18.BackgroundImage = Resources.Adamantite_bar;
			pictureBox18.Tag = "Adamantite bar x 3";
			pictureBox19.BackgroundImage = Resources.Runite_bar;
			pictureBox19.Tag = "Runite bar x 1";
			pictureBox20.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox20.Tag = "Elite clue scroll x 1";
			pictureBox21.BackgroundImage = Resources.Dragon_med_helm;
			pictureBox21.Tag = "Dragon med helm x 1";
			pictureBox22.BackgroundImage = Resources.Kbd_heads;
			pictureBox22.Tag = "Kbd heads x 1";
			pictureBox23.BackgroundImage = Resources.Dragon_pickaxe;
			pictureBox23.Tag = "Dragon pickaxe x 1";
			pictureBox24.BackgroundImage = Resources.Draconic_visage;
			pictureBox24.Tag = "Draconic visage x 1";
			pictureBox25.BackgroundImage = Resources.Prince_black_dragon;
			pictureBox25.Tag = "Prince black dragon x 1";
			pictureBox26.BackgroundImage = Resources.RDT;
			pictureBox26.Tag = "RDT";
			setNPictureBoxesToVisible(26);
			setNPictureBoxesToEnabled(26);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void scorpiaToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + scorpiaToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_scimitar;
			pictureBox1.Tag = "Rune scimitar x 1";
			pictureBox2.BackgroundImage = Resources.Rune_sword;
			pictureBox2.Tag = "Rune sword x 1";
			pictureBox3.BackgroundImage = Resources.Rune_warhammer;
			pictureBox3.Tag = "Rune warhammer x 1";
			pictureBox4.BackgroundImage = Resources.Rune_2h_sword;
			pictureBox4.Tag = "Rune 2h sword x 1";
			pictureBox5.BackgroundImage = Resources.Rune_spear;
			pictureBox5.Tag = "Rune spear x 1";
			pictureBox6.BackgroundImage = Resources.Rune_pickaxe;
			pictureBox6.Tag = "Rune pickaxe x 1";
			pictureBox7.BackgroundImage = Resources.Rune_chainbody;
			pictureBox7.Tag = "Rune chainbody x 1";
			pictureBox8.BackgroundImage = Resources.Phoenix_necklace;
			pictureBox8.Tag = "Phoenix necklace x 1";
			pictureBox9.BackgroundImage = Resources.Dust_rune_30;
			pictureBox9.Tag = "Dust rune x 30";
			pictureBox10.BackgroundImage = Resources.Uncut_sapphire_noted_4;
			pictureBox10.Tag = "Uncut sapphire x 4";
			pictureBox11.BackgroundImage = Resources.Uncut_emerald_noted_6;
			pictureBox11.Tag = "Uncut emerald x 6";
			pictureBox12.BackgroundImage = Resources.Coins_1000;
			pictureBox12.Tag = "Varies; Coins";
			pictureBox13.BackgroundImage = Resources.Admiral_pie;
			pictureBox13.Tag = "Admiral pie x 3";
			pictureBox14.BackgroundImage = Resources.Anchovy_pizza_noted_8;
			pictureBox14.Tag = "Anchovy pizza x 8";
			pictureBox15.BackgroundImage = Resources.Shark;
			pictureBox15.Tag = "Shark x 1";
			pictureBox16.BackgroundImage = Resources.Cactus_spine_noted_10;
			pictureBox16.Tag = "Cactus spine x 10";
			pictureBox17.BackgroundImage = Resources.Prayer_potion__4_;
			pictureBox17.Tag = "Prayer potion (4) x 1";
			pictureBox18.BackgroundImage = Resources.Superantipoison__4_;
			pictureBox18.Tag = "Superantipoison (4) x 1";
			pictureBox19.BackgroundImage = Resources.Ensouled_scorpion_head;
			pictureBox19.Tag = "Ensouled scorpion head x 1";
			pictureBox20.BackgroundImage = Resources.Bucket_of_sand_noted_25;
			pictureBox20.Tag = "Bucket of sand x 25";
			pictureBox21.BackgroundImage = Resources.Kwuarm_noted_4;
			pictureBox21.Tag = "Kwuarm x 4";
			pictureBox22.BackgroundImage = Resources.Mysterious_emblem;
			pictureBox22.Tag = "Mysterious emblem x 1";
			pictureBox23.BackgroundImage = Resources.Dragon_scimitar;
			pictureBox23.Tag = "Dragon scimitar x 1";
			pictureBox24.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox24.Tag = "Elite clue scroll x 1";
			pictureBox25.BackgroundImage = Resources.Odium_shard_3;
			pictureBox25.Tag = "Odium shard 3 x 1";
			pictureBox26.BackgroundImage = Resources.Malediction_shard_3;
			pictureBox26.Tag = "Malediction shard 3 x 1";
			pictureBox27.BackgroundImage = Resources.Scorpia_s_offspring;
			pictureBox27.Tag = "Scorpia's offspring x 1";
			pictureBox28.BackgroundImage = Resources.RDT;
			pictureBox28.Tag = "RDT";
			setNPictureBoxesToVisible(28);
			setNPictureBoxesToEnabled(28);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void venenatisToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + venenatisToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_pickaxe;
			pictureBox1.Tag = "Rune pickaxe x 1";
			pictureBox2.BackgroundImage = Resources.Rune_2h_sword;
			pictureBox2.Tag = "Rune 2h sword x 1";
			pictureBox3.BackgroundImage = Resources.Rune_knife_60;
			pictureBox3.Tag = "Rune knife x 60";
			pictureBox4.BackgroundImage = Resources.Diamond_bolts__e__100;
			pictureBox4.Tag = "Diamond bolts (e) x 100";
			pictureBox5.BackgroundImage = Resources.Cannonball_250;
			pictureBox5.Tag = "Cannonball x 250";
			pictureBox6.BackgroundImage = Resources.Chaos_rune_400;
			pictureBox6.Tag = "Chaos rune x 400";
			pictureBox7.BackgroundImage = Resources.Death_rune_300;
			pictureBox7.Tag = "Death rune x 300";
			pictureBox8.BackgroundImage = Resources.Blood_rune_200;
			pictureBox8.Tag = "Blood rune x 200";
			pictureBox9.BackgroundImage = Resources.Dark_fishing_bait_375;
			pictureBox9.Tag = "Dark fishing bait x 375";
			pictureBox10.BackgroundImage = Resources.Dark_crab;
			pictureBox10.Tag = "Dark crab x 8";
			pictureBox11.BackgroundImage = Resources.Supercompost_noted_100;
			pictureBox11.Tag = "Supercompost x 100";
			pictureBox12.BackgroundImage = Resources.Unicorn_horn_noted_100;
			pictureBox12.Tag = "Unicorn horn x 100";
			pictureBox13.BackgroundImage = Resources.Red_spiders__eggs_noted_500;
			pictureBox13.Tag = "Red spiders' eggs x 500";
			pictureBox14.BackgroundImage = Resources.Uncut_ruby_noted_20;
			pictureBox14.Tag = "Uncut ruby x 20";
			pictureBox15.BackgroundImage = Resources.Uncut_diamond_noted_10;
			pictureBox15.Tag = "Uncut diamond x 10";
			pictureBox16.BackgroundImage = Resources.Uncut_dragonstone;
			pictureBox16.Tag = "Uncut dragonstone x 1";
			pictureBox17.BackgroundImage = Resources.Gold_ore_noted_300;
			pictureBox17.Tag = "Gold ore x 300";
			pictureBox18.BackgroundImage = Resources.Limpwurt_root_noted_50;
			pictureBox18.Tag = "Limpwurt root x 50";
			pictureBox19.BackgroundImage = Resources.Grimy_snapdragon_noted_100;
			pictureBox19.Tag = "Grimy snapdragon x 100";
			pictureBox20.BackgroundImage = Resources.Antidote____4__noted_10;
			pictureBox20.Tag = "Antidote++ (4) x 10";
			pictureBox21.BackgroundImage = Resources.Super_restore__4_;
			pictureBox21.Tag = "Super restore (4) x 3";
			pictureBox22.BackgroundImage = Resources.Palm_tree_seed_1;
			pictureBox22.Tag = "Palm tree seed x 1";
			pictureBox23.BackgroundImage = Resources.Yew_seed_1;
			pictureBox23.Tag = "Yew seed x 1";
			pictureBox24.BackgroundImage = Resources.Magic_seed_1;
			pictureBox24.Tag = "Magic seed x 1";
			pictureBox25.BackgroundImage = Resources.Magic_logs_noted_100;
			pictureBox25.Tag = "Magic logs x 100";
			pictureBox26.BackgroundImage = Resources.Coins_10000;
			pictureBox26.Tag = "Varies; Coins";
			pictureBox27.BackgroundImage = Resources.Mysterious_emblem;
			pictureBox27.Tag = "Mysterious emblem x 1";
			pictureBox28.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox28.Tag = "Elite clue scroll x 1";
			pictureBox29.BackgroundImage = Resources.Onyx_bolt_tips_60;
			pictureBox29.Tag = "Onyx bolt tips x 60";
			pictureBox30.BackgroundImage = Resources.Dragon_2h_sword;
			pictureBox30.Tag = "Dragon 2h sword x 1";
			pictureBox31.BackgroundImage = Resources.Dragon_pickaxe;
			pictureBox31.Tag = "Dragon pickaxe x 1";
			pictureBox32.BackgroundImage = Resources.Treasonous_ring;
			pictureBox32.Tag = "Treasonous ring x 1";
			pictureBox33.BackgroundImage = Resources.Venenatis_spiderling;
			pictureBox33.Tag = "Venanitis spiderling x 1";
			pictureBox34.BackgroundImage = Resources.RDT;
			pictureBox34.Tag = "RDT";
			setNPictureBoxesToVisible(34);
			setNPictureBoxesToEnabled(34);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void vetionToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + vetionToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_pickaxe;
			pictureBox1.Tag = "Rune pickaxe x 1";
			pictureBox2.BackgroundImage = Resources.Rune_2h_sword;
			pictureBox2.Tag = "Rune 2h sword x 1";
			pictureBox3.BackgroundImage = Resources.Ancient_staff;
			pictureBox3.Tag = "Ancient staff x 1";
			pictureBox4.BackgroundImage = Resources.Gold_ore_noted_300;
			pictureBox4.Tag = "Gold ore x 300";
			pictureBox5.BackgroundImage = Resources.Magic_logs_noted_100;
			pictureBox5.Tag = "Magic logs x 100";
			pictureBox6.BackgroundImage = Resources.Chaos_rune_400;
			pictureBox6.Tag = "Chaos rune x 400";
			pictureBox7.BackgroundImage = Resources.Death_rune_300;
			pictureBox7.Tag = "Death rune x 300";
			pictureBox8.BackgroundImage = Resources.Blood_rune_200;
			pictureBox8.Tag = "Blood rune x 200";
			pictureBox9.BackgroundImage = Resources.Dark_fishing_bait_375;
			pictureBox9.Tag = "Dark fishing bait x 375";
			pictureBox10.BackgroundImage = Resources.Dark_crab;
			pictureBox10.Tag = "Dark crab x 8";
			pictureBox11.BackgroundImage = Resources.Supercompost_noted_100;
			pictureBox11.Tag = "Supercompost x 100";
			pictureBox12.BackgroundImage = Resources.Limpwurt_root_noted_50;
			pictureBox12.Tag = "Limpwurt root x 50";
			pictureBox13.BackgroundImage = Resources.Dragon_bones_noted_100;
			pictureBox13.Tag = "Dragon bones x 100";
			pictureBox14.BackgroundImage = Resources.Uncut_ruby_noted_20;
			pictureBox14.Tag = "Uncut ruby x 20";
			pictureBox15.BackgroundImage = Resources.Uncut_diamond_noted_10;
			pictureBox15.Tag = "Uncut diamond x 10";
			pictureBox16.BackgroundImage = Resources.Uncut_dragonstone;
			pictureBox16.Tag = "Uncut dragonstone x 1";
			pictureBox17.BackgroundImage = Resources.Oak_plank_noted_300;
			pictureBox17.Tag = "Oak plank x 300";
			pictureBox18.BackgroundImage = Resources.Mort_myre_fungus_noted_200;
			pictureBox18.Tag = "Mort myre fungus x 200";
			pictureBox19.BackgroundImage = Resources.Grimy_ranarr_weed_noted_100;
			pictureBox19.Tag = "Grimy ranarr weed x 100";
			pictureBox20.BackgroundImage = Resources.Sanfew_serum__4__noted_10;
			pictureBox20.Tag = "Sanfew serum (4) x 10";
			pictureBox21.BackgroundImage = Resources.Super_restore__4_;
			pictureBox21.Tag = "Super restore (4) x 3";
			pictureBox22.BackgroundImage = Resources.Palm_tree_seed_1;
			pictureBox22.Tag = "Palm tree seed x 1";
			pictureBox23.BackgroundImage = Resources.Yew_seed_1;
			pictureBox23.Tag = "Yew seed x 1";
			pictureBox24.BackgroundImage = Resources.Magic_seed_1;
			pictureBox24.Tag = "Magic seed x 1";
			pictureBox25.BackgroundImage = Resources.Ogre_coffin_key_noted_10;
			pictureBox25.Tag = "Ogre coffin key x 10";
			pictureBox26.BackgroundImage = Resources.Cannonball_250;
			pictureBox26.Tag = "Cannonball x 250";
			pictureBox27.BackgroundImage = Resources.Coins_10000;
			pictureBox27.Tag = "Varies; ";
			pictureBox28.BackgroundImage = Resources.Mysterious_emblem;
			pictureBox28.Tag = "Mysterious emblem x 1";
			pictureBox29.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox29.Tag = "Elite clue scroll x 1";
			pictureBox30.BackgroundImage = Resources.Dragon_2h_sword;
			pictureBox30.Tag = "Dragon 2h sword x 1";
			pictureBox31.BackgroundImage = Resources.Dragon_pickaxe;
			pictureBox31.Tag = "Dragon pickaxe x 1";
			pictureBox32.BackgroundImage = Resources.Ring_of_the_gods;
			pictureBox32.Tag = "Ring of the gods x 1";
			pictureBox33.BackgroundImage = Resources.Long_bone;
			pictureBox33.Tag = "Long bone x 1";
			pictureBox34.BackgroundImage = Resources.Curved_bone;
			pictureBox34.Tag = "Curved bone x 1";
			pictureBox35.BackgroundImage = Resources.Vet_ion_jr;
			pictureBox35.Tag = "Vet'ion jr x 1";
			pictureBox36.BackgroundImage = Resources.RDT;
			pictureBox36.Tag = "RDT";
			setNPictureBoxesToVisible(36);
			setNPictureBoxesToEnabled(36);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void abyssalSireToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + abyssalSireToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_sword_noted_3;
			pictureBox1.Tag = "Rune sword x 3";
			pictureBox2.BackgroundImage = Resources.Rune_full_helm_noted_3;
			pictureBox2.Tag = "Rune full helm x 3";
			pictureBox3.BackgroundImage = Resources.Rune_platebody_noted_2;
			pictureBox3.Tag = "Rune platebody x 2";
			pictureBox4.BackgroundImage = Resources.Rune_kiteshield_noted_2;
			pictureBox4.Tag = "Rune kiteshield x 2";
			pictureBox5.BackgroundImage = Resources.Battlestaff_noted_10;
			pictureBox5.Tag = "Battlestaff x 10";
			pictureBox6.BackgroundImage = Resources.Air_battlestaff_noted_6;
			pictureBox6.Tag = "Air battlestaff x 6";
			pictureBox7.BackgroundImage = Resources.Mystic_air_staff_noted_2;
			pictureBox7.Tag = "Mystic air staff x 2";
			pictureBox8.BackgroundImage = Resources.Mystic_lava_staff_noted_2;
			pictureBox8.Tag = "Mystic lava staff x 2";
			pictureBox9.BackgroundImage = Resources.Cosmic_rune_350;
			pictureBox9.Tag = "Cosmic rune x 350";
			pictureBox10.BackgroundImage = Resources.Law_rune_250;
			pictureBox10.Tag = "Law rune x 250";
			pictureBox11.BackgroundImage = Resources.Death_rune;
			pictureBox11.Tag = "Varies; Death rune";
			pictureBox12.BackgroundImage = Resources.Blood_rune;
			pictureBox12.Tag = "Varies; Blood rune";
			pictureBox13.BackgroundImage = Resources.Soul_rune;
			pictureBox13.Tag = "Varies; Soul rune";
			pictureBox14.BackgroundImage = Resources.Pure_essence_noted_600;
			pictureBox14.Tag = "Pure essence x 600";
			pictureBox15.BackgroundImage = Resources.Earth_orb_noted_generic;
			pictureBox15.Tag = "Varies; Earth orb";
			pictureBox16.BackgroundImage = Resources.Magic_logs_noted_generic;
			pictureBox16.Tag = "Varies; Magic logs";
			pictureBox17.BackgroundImage = Resources.Ranarr_seed_2;
			pictureBox17.Tag = "Ranarr seed x 2";
			pictureBox18.BackgroundImage = Resources.Snapdragon_seed_2;
			pictureBox18.Tag = "Snapdragon seed x 2";
			pictureBox19.BackgroundImage = Resources.Torstol_seed_2;
			pictureBox19.Tag = "Torstol seed x 2";
			pictureBox20.BackgroundImage = Resources.Watermelon_seed_30;
			pictureBox20.Tag = "Watermelon seed x 30";
			pictureBox21.BackgroundImage = Resources.Papaya_tree_seed_2;
			pictureBox21.Tag = "Papaya tree seed x 2";
			pictureBox22.BackgroundImage = Resources.Palm_tree_seed_2;
			pictureBox22.Tag = "Palm tree seed x 2";
			pictureBox23.BackgroundImage = Resources.Willow_seed_2;
			pictureBox23.Tag = "Willow seed x 2";
			pictureBox24.BackgroundImage = Resources.Maple_seed_2;
			pictureBox24.Tag = "Maple seed x 2";
			pictureBox25.BackgroundImage = Resources.Yew_seed_2;
			pictureBox25.Tag = "Yew seed x 2";
			pictureBox26.BackgroundImage = Resources.Magic_seed_2;
			pictureBox26.Tag = "Magic seed x 2";
			pictureBox27.BackgroundImage = Resources.Spirit_seed_2;
			pictureBox27.Tag = "Spirit seed x 2";
			pictureBox28.BackgroundImage = Resources.Grimy_kwuarm_noted_25;
			pictureBox28.Tag = "Grimy kwuarm x 25";
			pictureBox29.BackgroundImage = Resources.Grimy_lantadyme_noted_25;
			pictureBox29.Tag = "Grimy lantadyme x 25";
			pictureBox30.BackgroundImage = Resources.Grimy_cadantine_noted_25;
			pictureBox30.Tag = "Grimy cadantine x 25";
			pictureBox31.BackgroundImage = Resources.Grimy_dwarf_weed_noted_25;
			pictureBox31.Tag = "Grimy dwarf weed x 25";
			pictureBox32.BackgroundImage = Resources.Chilli_potato;
			pictureBox32.Tag = "Chili potato x 10";
			pictureBox33.BackgroundImage = Resources.Saradomin_brew__3_;
			pictureBox33.Tag = "Saradomin brew (3) x 6";
			pictureBox34.BackgroundImage = Resources.Super_restore__4_;
			pictureBox34.Tag = "Super restore (4) x 4";
			pictureBox35.BackgroundImage = Resources.Coal_noted_generic;
			pictureBox35.Tag = "Varies; Coal";
			pictureBox36.BackgroundImage = Resources.Runite_ore_noted_6;
			pictureBox36.Tag = "Runite ore x 6";
			pictureBox37.BackgroundImage = Resources.Runite_bar_noted_5;
			pictureBox37.Tag = "Runite bar x 5";
			pictureBox38.BackgroundImage = Resources.Jug_of_water_noted_generic;
			pictureBox38.Tag = "Varies; Jug of water";
			pictureBox39.BackgroundImage = Resources.Binding_necklace_noted_25;
			pictureBox39.Tag = "Binding necklace x 25";
			pictureBox40.BackgroundImage = Resources.Air_talisman;
			pictureBox40.Tag = "Air talisman x 1";
			pictureBox41.BackgroundImage = Resources.Water_talisman;
			pictureBox41.Tag = "Water talisman x 1";
			pictureBox42.BackgroundImage = Resources.Fire_talisman;
			pictureBox42.Tag = "Fire talisman x 1";
			pictureBox43.BackgroundImage = Resources.Earth_talisman;
			pictureBox43.Tag = "Earth talisman x 1";
			pictureBox44.BackgroundImage = Resources.Mind_talisman;
			pictureBox44.Tag = "Mind talisman x 1";
			pictureBox45.BackgroundImage = Resources.Body_talisman;
			pictureBox45.Tag = "Body talisman x 1";
			pictureBox46.BackgroundImage = Resources.Cosmic_talisman;
			pictureBox46.Tag = "Cosmic talisman x 1";
			pictureBox47.BackgroundImage = Resources.Nature_talisman;
			pictureBox47.Tag = "Nature talisman x 1";
			pictureBox48.BackgroundImage = Resources.Chaos_talisman;
			pictureBox48.Tag = "Chaos talisman x 1";
			pictureBox49.BackgroundImage = Resources.Cannonball_300;
			pictureBox49.Tag = "Cannonball x 300";
			pictureBox50.BackgroundImage = Resources.Uncut_diamond_noted_15;
			pictureBox50.Tag = "Uncut diamond x 15";
			pictureBox51.BackgroundImage = Resources.Coins_10000;
			pictureBox51.Tag = "Varies; Coins";
			pictureBox52.BackgroundImage = Resources.Onyx_bolt_tips_10;
			pictureBox52.Tag = "Onyx bolt tips x 10";
			pictureBox53.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox53.Tag = "Elite clue scroll x 1";
			pictureBox54.BackgroundImage = Resources.Unsired;
			pictureBox54.Tag = "Unsired x 1";
			pictureBox55.BackgroundImage = Resources.RDT;
			pictureBox55.Tag = "RDT";
			setNPictureBoxesToVisible(55);
			setNPictureBoxesToEnabled(55);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void barrowsToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + barrowsToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Ahrim_s_hood;
			pictureBox1.Tag = "Ahrim's hood x 1";
			pictureBox2.BackgroundImage = Resources.Karil_s_coif;
			pictureBox2.Tag = "Karil's coif x 1";
			pictureBox3.BackgroundImage = Resources.Dharok_s_helm;
			pictureBox3.Tag = "Dharok's helm x 1";
			pictureBox4.BackgroundImage = Resources.Guthan_s_helm;
			pictureBox4.Tag = "Guthan's helm x 1";
			pictureBox5.BackgroundImage = Resources.Torag_s_helm;
			pictureBox5.Tag = "Torag's helm x 1";
			pictureBox6.BackgroundImage = Resources.Verac_s_helm;
			pictureBox6.Tag = "Verac's helm x 1";
			pictureBox7.BackgroundImage = Resources.Mind_rune;
			pictureBox7.Tag = "Varies; Mind rune";
			pictureBox8.BackgroundImage = Resources.Chaos_rune;
			pictureBox8.Tag = "Varies; Chaos rune";
			pictureBox9.BackgroundImage = Resources.Ahrim_s_robetop;
			pictureBox9.Tag = "Ahrim's robetop x 1";
			pictureBox10.BackgroundImage = Resources.Karil_s_leathertop;
			pictureBox10.Tag = "Karil's leathertop x 1";
			pictureBox11.BackgroundImage = Resources.Dharok_s_platebody;
			pictureBox11.Tag = "Dharok's platebody x 1";
			pictureBox12.BackgroundImage = Resources.Guthan_s_platebody;
			pictureBox12.Tag = "Guthan's platebody x 1";
			pictureBox13.BackgroundImage = Resources.Torag_s_platebody;
			pictureBox13.Tag = "Torag's platebody x 1";
			pictureBox14.BackgroundImage = Resources.Verac_s_brassard;
			pictureBox14.Tag = "Verac's brassard x 1";
			pictureBox15.BackgroundImage = Resources.Death_rune;
			pictureBox15.Tag = "Varies; Death rune";
			pictureBox16.BackgroundImage = Resources.Blood_rune;
			pictureBox16.Tag = "Varies; Blood rune";
			pictureBox17.BackgroundImage = Resources.Ahrim_s_robeskirt;
			pictureBox17.Tag = "Ahrim's robeskirt x 1";
			pictureBox18.BackgroundImage = Resources.Karil_s_leatherskirt;
			pictureBox18.Tag = "Karil's leatherskirt x 1";
			pictureBox19.BackgroundImage = Resources.Dharok_s_platelegs;
			pictureBox19.Tag = "Dharok's platelegs x 1";
			pictureBox20.BackgroundImage = Resources.Guthan_s_chainskirt;
			pictureBox20.Tag = "Guthan's chainskirt x 1";
			pictureBox21.BackgroundImage = Resources.Torag_s_platelegs;
			pictureBox21.Tag = "Torag's platelegs x 1";
			pictureBox22.BackgroundImage = Resources.Verac_s_plateskirt;
			pictureBox22.Tag = "Verac's plateskirt x 1";
			pictureBox23.BackgroundImage = Resources.Loop_half_of_key;
			pictureBox23.Tag = "Loop half of key x 1";
			pictureBox24.BackgroundImage = Resources.Tooth_half_of_key;
			pictureBox24.Tag = "Tooth half of key x 1";
			pictureBox25.BackgroundImage = Resources.Ahrim_s_staff;
			pictureBox25.Tag = "Ahrim's staff x 1";
			pictureBox26.BackgroundImage = Resources.Karil_s_crossbow;
			pictureBox26.Tag = "Karil's crossbow x 1";
			pictureBox27.BackgroundImage = Resources.Dharok_s_greataxe;
			pictureBox27.Tag = "Dharok's greataxe x 1";
			pictureBox28.BackgroundImage = Resources.Guthan_s_warspear;
			pictureBox28.Tag = "Guthan's warspear x 1";
			pictureBox29.BackgroundImage = Resources.Torag_s_hammers;
			pictureBox29.Tag = "Torag's hammers x 1";
			pictureBox30.BackgroundImage = Resources.Verac_s_flail;
			pictureBox30.Tag = "Verac's flail x 1";
			pictureBox31.BackgroundImage = Resources.Coins_1000;
			pictureBox31.Tag = "Varies; Coins";
			pictureBox32.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox32.Tag = "Elite clue scroll x 1";
			pictureBox33.BackgroundImage = Resources.Dragon_med_helm;
			pictureBox33.Tag = "Dragon med helm x 1";
			pictureBox34.BackgroundImage = Resources.Bolt_rack_5;
			pictureBox34.Tag = "Varies; Bolt rack";
			setNPictureBoxesToVisible(34);
			setNPictureBoxesToEnabled(34);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void cerberusToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + cerberusToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_2h_sword;
			pictureBox1.Tag = "Rune 2h sword x 1";
			pictureBox2.BackgroundImage = Resources.Rune_halberd;
			pictureBox2.Tag = "Rune halberd x 1";
			pictureBox3.BackgroundImage = Resources.Rune_axe;
			pictureBox3.Tag = "Rune axe x 1";
			pictureBox4.BackgroundImage = Resources.Rune_pickaxe;
			pictureBox4.Tag = "Rune pickaxe x 1";
			pictureBox5.BackgroundImage = Resources.Rune_full_helm;
			pictureBox5.Tag = "Rune full helm x 1";
			pictureBox6.BackgroundImage = Resources.Rune_platebody;
			pictureBox6.Tag = "Rune platebody x 1";
			pictureBox7.BackgroundImage = Resources.Rune_chainbody;
			pictureBox7.Tag = "Rune chainbody x 1";
			pictureBox8.BackgroundImage = Resources.Black_d_hide_body;
			pictureBox8.Tag = "Black d'hide body x 1";
			pictureBox9.BackgroundImage = Resources.Battlestaff_noted_6;
			pictureBox9.Tag = "Battlestaff x 6";
			pictureBox10.BackgroundImage = Resources.Lava_battlestaff;
			pictureBox10.Tag = "Lava battlestaff x 1";
			pictureBox11.BackgroundImage = Resources.Pure_essence_noted_300;
			pictureBox11.Tag = "Pure essence x 300";
			pictureBox12.BackgroundImage = Resources.Fire_rune_300;
			pictureBox12.Tag = "Fire rune x 300";
			pictureBox13.BackgroundImage = Resources.Death_rune_100;
			pictureBox13.Tag = "Death rune x 100";
			pictureBox14.BackgroundImage = Resources.Blood_rune_60;
			pictureBox14.Tag = "Blood rune x 60";
			pictureBox15.BackgroundImage = Resources.Soul_rune_100;
			pictureBox15.Tag = "Soul rune x 100";
			pictureBox16.BackgroundImage = Resources.Runite_bolts__unf__40;
			pictureBox16.Tag = "Runite bolts (unf) x 40";
			pictureBox17.BackgroundImage = Resources.Cannonball_50;
			pictureBox17.Tag = "Cannonball x 50";
			pictureBox18.BackgroundImage = Resources.Torstol_seed_3;
			pictureBox18.Tag = "Torstol seed x 3";
			pictureBox19.BackgroundImage = Resources.Grimy_torstol_noted_6;
			pictureBox19.Tag = "Grimy torstol x 6";
			pictureBox20.BackgroundImage = Resources.Super_restore__4_;
			pictureBox20.Tag = "Super restore (4) x 2";
			pictureBox21.BackgroundImage = Resources.Coal_noted_120;
			pictureBox21.Tag = "Coal x 120";
			pictureBox22.BackgroundImage = Resources.Runite_ore_noted_5;
			pictureBox22.Tag = "Runite ore x 5";
			pictureBox23.BackgroundImage = Resources.Wine_of_zamorak_noted_15;
			pictureBox23.Tag = "Wine of zamorak x 15";
			pictureBox24.BackgroundImage = Resources.Unholy_symbol;
			pictureBox24.Tag = "Unholy symbol x 1";
			pictureBox25.BackgroundImage = Resources.Ashes_noted_50;
			pictureBox25.Tag = "Ashes x 50";
			pictureBox26.BackgroundImage = Resources.Summer_pie;
			pictureBox26.Tag = "Summer pie x 3";
			pictureBox27.BackgroundImage = Resources.Dragon_bones_noted_20;
			pictureBox27.Tag = "Dragon bones x 20";
			pictureBox28.BackgroundImage = Resources.Fire_orb_noted_20;
			pictureBox28.Tag = "Fire orb x 20";
			pictureBox29.BackgroundImage = Resources.Uncut_diamond_noted_5;
			pictureBox29.Tag = "Uncut diamond x 5";
			pictureBox30.BackgroundImage = Resources.Coins_10000;
			pictureBox30.Tag = "Varies; Coins";
			pictureBox31.BackgroundImage = Resources.Key_master_teleport_3;
			pictureBox31.Tag = "Key master teleport x 3";
			pictureBox32.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox32.Tag = "Elite clue scroll x 1";
			pictureBox33.BackgroundImage = Resources.Smouldering_stone;
			pictureBox33.Tag = "Smouldering stone x 1";
			pictureBox34.BackgroundImage = Resources.Pegasian_crystal;
			pictureBox34.Tag = "Pegasian crystal x 1";
			pictureBox35.BackgroundImage = Resources.Eternal_crystal;
			pictureBox35.Tag = "Eternal crystal x 1";
			pictureBox36.BackgroundImage = Resources.Primordial_crystal;
			pictureBox36.Tag = "Primordial crystal x 1";
			pictureBox37.BackgroundImage = Resources.Jar_of_souls;
			pictureBox37.Tag = "Jar of souls x 1";
			pictureBox38.BackgroundImage = Resources.Hellpuppy;
			pictureBox38.Tag = "Hellpuppy x 1";
			pictureBox39.BackgroundImage = Resources.RDT;
			pictureBox39.Tag = "RDT";
			setNPictureBoxesToVisible(39);
			setNPictureBoxesToEnabled(39);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void corporealBeastToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + corporealBeastToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Adamant_arrow_750;
			pictureBox1.Tag = "Adamant arrow x 750";
			pictureBox2.BackgroundImage = Resources.Runite_bolts_250;
			pictureBox2.Tag = "Runite bolts x 250";
			pictureBox3.BackgroundImage = Resources.Cannonball_2000;
			pictureBox3.Tag = "Cannonball x 2000";
			pictureBox4.BackgroundImage = Resources.Mystic_air_staff;
			pictureBox4.Tag = "Mystic air staff x 1";
			pictureBox5.BackgroundImage = Resources.Mystic_water_staff;
			pictureBox5.Tag = "Mystic water staff x 1";
			pictureBox6.BackgroundImage = Resources.Mystic_earth_staff;
			pictureBox6.Tag = "Mystic earth staff x 1";
			pictureBox7.BackgroundImage = Resources.Mystic_fire_staff;
			pictureBox7.Tag = "Mystic fire staff x 1";
			pictureBox8.BackgroundImage = Resources.Nature_talisman;
			pictureBox8.Tag = "Varies; Nature talisman";
			pictureBox9.BackgroundImage = Resources.Uncut_sapphire;
			pictureBox9.Tag = "Varies; Uncut sapphire";
			pictureBox10.BackgroundImage = Resources.Uncut_emerald;
			pictureBox10.Tag = "Varies; Uncut emerald";
			pictureBox11.BackgroundImage = Resources.Uncut_ruby;
			pictureBox11.Tag = "Varies; Uncut ruby";
			pictureBox12.BackgroundImage = Resources.Uncut_diamond;
			pictureBox12.Tag = "Varies; Uncut diamond";
			pictureBox13.BackgroundImage = Resources.Mystic_robe_top__blue_;
			pictureBox13.Tag = "Mystic robe top (blue) x 1";
			pictureBox14.BackgroundImage = Resources.Mystic_robe_bottom__blue_;
			pictureBox14.Tag = "Mystic robe bottom (blue) x 1";
			pictureBox15.BackgroundImage = Resources.Mahogany_logs_noted_150;
			pictureBox15.Tag = "Mahogany logs x 150";
			pictureBox16.BackgroundImage = Resources.Magic_logs_noted_75;
			pictureBox16.Tag = "Magic logs x 75";
			pictureBox17.BackgroundImage = Resources.Pure_essence_noted_2500;
			pictureBox17.Tag = "Pure essence x 2500";
			pictureBox18.BackgroundImage = Resources.Law_rune_250;
			pictureBox18.Tag = "Law rune x 250";
			pictureBox19.BackgroundImage = Resources.Cosmic_rune_500;
			pictureBox19.Tag = "Cosmic rune x 500";
			pictureBox20.BackgroundImage = Resources.Death_rune_300;
			pictureBox20.Tag = "Death rune x 300";
			pictureBox21.BackgroundImage = Resources.Soul_rune_250;
			pictureBox21.Tag = "Soul rune x 250";
			pictureBox22.BackgroundImage = Resources.Adamantite_bar_noted_35;
			pictureBox22.Tag = "Adamantite bar x 35";
			pictureBox23.BackgroundImage = Resources.Adamantite_ore_noted_125;
			pictureBox23.Tag = "Adamantite ore x 125";
			pictureBox24.BackgroundImage = Resources.Runite_ore_noted_20;
			pictureBox24.Tag = "Runite ore x 20";
			pictureBox25.BackgroundImage = Resources.Teak_plank_noted_100;
			pictureBox25.Tag = "Teak plank x 100";
			pictureBox26.BackgroundImage = Resources.Green_dragonhide_noted_100;
			pictureBox26.Tag = "Green dragonhide x 100";
			pictureBox27.BackgroundImage = Resources.Raw_shark_noted_70;
			pictureBox27.Tag = "Raw shark x 70";
			pictureBox28.BackgroundImage = Resources.White_berries_noted_120;
			pictureBox28.Tag = "White berries x 120";
			pictureBox29.BackgroundImage = Resources.Desert_goat_horn_noted_120;
			pictureBox29.Tag = "Desert goat horn x 120";
			pictureBox30.BackgroundImage = Resources.Antidote____4__noted_40;
			pictureBox30.Tag = "Antidote++ (4) x 40";
			pictureBox31.BackgroundImage = Resources.Watermelon_seed_24;
			pictureBox31.Tag = "Watermelon seed x 24";
			pictureBox32.BackgroundImage = Resources.Ranarr_seed_10;
			pictureBox32.Tag = "Ranarr seed x 10";
			pictureBox33.BackgroundImage = Resources.Tuna_potato;
			pictureBox33.Tag = "Tuna potato x 30";
			pictureBox34.BackgroundImage = Resources.Coins_10000;
			pictureBox34.Tag = "Varies; Coins";
			pictureBox35.BackgroundImage = Resources.Shield_left_half;
			pictureBox35.Tag = "Shield left half x 1";
			pictureBox36.BackgroundImage = Resources.Dragon_spear;
			pictureBox36.Tag = "Dragon spear x 1";
			pictureBox37.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox37.Tag = "Elite clue scroll x 1";
			pictureBox38.BackgroundImage = Resources.Onyx_bolts__e__175;
			pictureBox38.Tag = "Onyx bolts (e) x 175";
			pictureBox39.BackgroundImage = Resources.Holy_elixir;
			pictureBox39.Tag = "Holy elixir x 1";
			pictureBox40.BackgroundImage = Resources.Spirit_shield;
			pictureBox40.Tag = "Spirit shield x 1";
			pictureBox41.BackgroundImage = Resources.Spectral_sigil;
			pictureBox41.Tag = "Spectral sigil x 1";
			pictureBox42.BackgroundImage = Resources.Arcane_sigil;
			pictureBox42.Tag = "Arcane sigil x 1";
			pictureBox43.BackgroundImage = Resources.Elysian_sigil;
			pictureBox43.Tag = "Elysian sigil x 1";
			pictureBox44.BackgroundImage = Resources.Pet_dark_core;
			pictureBox44.Tag = "Pet dark core x 1";
			setNPictureBoxesToVisible(44);
			setNPictureBoxesToEnabled(44);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void dagannothKingsToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + dagannothKingsToolStripMenuItem.Text;
			highlightPictureBox(pictureBoxDagannothPrime);
			if (selectedDagannothKing == "Dagannoth Prime") {
				pictureBox1.BackgroundImage = Resources.Battlestaff_noted_generic;
				pictureBox1.Tag = "Varies; Battlestaff";
				pictureBox2.BackgroundImage = Resources.Air_battlestaff;
				pictureBox2.Tag = "Air battlestaff x 1";
				pictureBox3.BackgroundImage = Resources.Water_battlestaff;
				pictureBox3.Tag = "Water battlestaff x 1";
				pictureBox4.BackgroundImage = Resources.Earth_battlestaff;
				pictureBox4.Tag = "Earth battlestaff x 1";
				pictureBox5.BackgroundImage = Resources.Pure_essence_noted_150;
				pictureBox5.Tag = "Pure essence x 150";
				pictureBox6.BackgroundImage = Resources.Air_rune_155;
				pictureBox6.Tag = "Air rune x 155";
				pictureBox7.BackgroundImage = Resources.Mud_rune_32;
				pictureBox7.Tag = "Mud rune x 32";
				pictureBox8.BackgroundImage = Resources.Death_rune_generic;
				pictureBox8.Tag = "Varies; Death rune";
				pictureBox9.BackgroundImage = Resources.Ensouled_dagannoth_head;
				pictureBox9.Tag = "Ensouled dagannoth head x 1";
				pictureBox10.BackgroundImage = Resources.Air_talisman;
				pictureBox10.Tag = "Varies; Air talisman";
				pictureBox11.BackgroundImage = Resources.Water_talisman;
				pictureBox11.Tag = "Varies; Water talisman";
				pictureBox12.BackgroundImage = Resources.Earth_talisman;
				pictureBox12.Tag = "Varies; Earth talisman";
				pictureBox13.BackgroundImage = Resources.Grimy_ranarr_weed;
				pictureBox13.Tag = "Grimy ranarr weed x 1";
				pictureBox14.BackgroundImage = Resources.Belladonna_seed_1;
				pictureBox14.Tag = "Belladonna seed x 1";
				pictureBox15.BackgroundImage = Resources.Cactus_seed_1;
				pictureBox15.Tag = "Cactus seed x 1";
				pictureBox16.BackgroundImage = Resources.Poison_ivy_seed_1;
				pictureBox16.Tag = "Poison ivy seed x 1";
				pictureBox17.BackgroundImage = Resources.Irit_seed_1;
				pictureBox17.Tag = "Irit seed x 1";
				pictureBox18.BackgroundImage = Resources.Toadflax_seed_1;
				pictureBox18.Tag = "Toadflax seed x 1";
				pictureBox19.BackgroundImage = Resources.Avantoe_seed_1;
				pictureBox19.Tag = "Avantoe seed x 1";
				pictureBox20.BackgroundImage = Resources.Kwuarm_seed_1;
				pictureBox20.Tag = "Kwuarm seed x 1"; 
				pictureBox21.BackgroundImage = Resources.Snapdragon_seed_1;
				pictureBox21.Tag = "Snapdragon seed x 1";
				pictureBox22.BackgroundImage = Resources.Cadantine_seed_1;
				pictureBox22.Tag = "Cadantine seed x 1";
				pictureBox23.BackgroundImage = Resources.Lantadyme_seed_1;
				pictureBox23.Tag = "Lantadyme seed x 1";
				pictureBox24.BackgroundImage = Resources.Dwarf_weed_seed_1;
				pictureBox24.Tag = "Dwarf weed seed x 1";
				pictureBox25.BackgroundImage = Resources.Fremennik_shield;
				pictureBox25.Tag = "Fremennik shield x 1";
				pictureBox26.BackgroundImage = Resources.Fremennik_helm;
				pictureBox26.Tag = "Fremennik helm x 1";
				pictureBox27.BackgroundImage = Resources.Skeletal_top;
				pictureBox27.Tag = "Skeletal top x 1";
				pictureBox28.BackgroundImage = Resources.Skeletal_bottoms;
				pictureBox28.Tag = "Skeletal bottoms x 1";
				pictureBox29.BackgroundImage = Resources.Farseer_helm;
				pictureBox29.Tag = "Farseer helm x 1";
				pictureBox30.BackgroundImage = Resources.Coins_1000;
				pictureBox30.Tag = "Varies; Coins";
				pictureBox31.BackgroundImage = Resources.Hard_clue_scroll;
				pictureBox31.Tag = "Hard clue scroll x 1";
				pictureBox32.BackgroundImage = Resources.Elite_clue_scroll;
				pictureBox32.Tag = "Elite clue scroll x 1";
				pictureBox33.BackgroundImage = Resources.Dragon_axe;
				pictureBox33.Tag = "Dragon axe x 1";
				pictureBox34.BackgroundImage = Resources.Mud_battlestaff;
				pictureBox34.Tag = "Mud battlestaff x 1";
				pictureBox35.BackgroundImage = Resources.Seers_ring;
				pictureBox35.Tag = "Seers ring x 1";
				pictureBox36.BackgroundImage = Resources.Pet_dagannoth_prime;
				pictureBox36.Tag = "Pet dagannoth prime x 1";
				pictureBox37.BackgroundImage = Resources.RDT;
				pictureBox37.Tag = "RDT";
				setNPictureBoxesToVisible(37, "Dagannoth Kings");
				setNPictureBoxesToEnabled(37);
				removeAllItemQuantityOverlays();
				resetAllPictureBoxBackgroundColor();
			}
			if (selectedDagannothKing == "Dagannoth Rex") {
				pictureBox1.BackgroundImage = Resources.Mithril_warhammer;
				pictureBox1.Tag = "Mithril warhammer x 1";
				pictureBox2.BackgroundImage = Resources.Mithril_2h_sword;
				pictureBox2.Tag = "Mithril 2h sword x 1";
				pictureBox3.BackgroundImage = Resources.Mithril_pickaxe;
				pictureBox3.Tag = "Mithril pickaxe x 1";
				pictureBox4.BackgroundImage = Resources.Adamant_axe;
				pictureBox4.Tag = "Adamant axe x 1";
				pictureBox5.BackgroundImage = Resources.Rune_battleaxe;
				pictureBox5.Tag = "Rune battleaxe x 1";
				pictureBox6.BackgroundImage = Resources.Rune_axe;
				pictureBox6.Tag = "Rune axe x 1";
				pictureBox7.BackgroundImage = Resources.Fremennik_blade;
				pictureBox7.Tag = "Fremennik blade x 1";
				pictureBox8.BackgroundImage = Resources.Fremennik_helm;
				pictureBox8.Tag = "Fremennik helm x 1";
				pictureBox9.BackgroundImage = Resources.Super_attack__2_;
				pictureBox9.Tag = "Super attack (2) x 1";
				pictureBox10.BackgroundImage = Resources.Super_strength__2_;
				pictureBox10.Tag = "Super strength (2) x 1";
				pictureBox11.BackgroundImage = Resources.Super_defence__2_;
				pictureBox11.Tag = "Super defence (2) x 1";
				pictureBox12.BackgroundImage = Resources.Prayer_potion__2_;
				pictureBox12.Tag = "Prayer potion (2) x 1";
				pictureBox13.BackgroundImage = Resources.Antifire_potion__2_;
				pictureBox13.Tag = "Antifire potion (2) x 1";
				pictureBox14.BackgroundImage = Resources.Zamorak_brew__2_;
				pictureBox14.Tag = "Zamorak brew (2) x 1";
				pictureBox15.BackgroundImage = Resources.Fremennik_shield;
				pictureBox15.Tag = "Fremennik shield x 1";
				pictureBox16.BackgroundImage = Resources.Steel_kiteshield;
				pictureBox16.Tag = "Steel kiteshield x 1";
				pictureBox17.BackgroundImage = Resources.Air_talisman;
				pictureBox17.Tag = "Air talisman x 1";
				pictureBox18.BackgroundImage = Resources.Fire_talisman;
				pictureBox18.Tag = "Fire talisman x 1";
				pictureBox19.BackgroundImage = Resources.Water_talisman;
				pictureBox19.Tag = "Water talisman x 1";
				pictureBox20.BackgroundImage = Resources.Earth_talisman;
				pictureBox20.Tag = "Earth talisman x 1";
				pictureBox21.BackgroundImage = Resources.Mind_talisman;
				pictureBox21.Tag = "Mind talisman x 1";
				pictureBox22.BackgroundImage = Resources.Body_talisman;
				pictureBox22.Tag = "Body talisman x 1";
				pictureBox23.BackgroundImage = Resources.Cosmic_talisman;
				pictureBox23.Tag = "Cosmic talisman x 1";
				pictureBox24.BackgroundImage = Resources.Steel_platebody;
				pictureBox24.Tag = "Steel platebody x 1";
				pictureBox25.BackgroundImage = Resources.Grimy_ranarr_weed;
				pictureBox25.Tag = "Grimy ranarr weed x 1";
				pictureBox26.BackgroundImage = Resources.Ensouled_dagannoth_head;
				pictureBox26.Tag = "Ensouled dagannoth head x 1";
				pictureBox27.BackgroundImage = Resources.Iron_ore_noted_150;
				pictureBox27.Tag = "Iron ore x 150";
				pictureBox28.BackgroundImage = Resources.Coal_noted_100;
				pictureBox28.Tag = "Coal x 100";
				pictureBox29.BackgroundImage = Resources.Mithril_ore_noted_25;
				pictureBox29.Tag = "Mithril ore x 25";
				pictureBox30.BackgroundImage = Resources.Steel_bar_noted_generic;
				pictureBox30.Tag = "Varies; Steel bar";
				pictureBox31.BackgroundImage = Resources.Adamantite_bar;
				pictureBox31.Tag = "Adamantite bar x 1";
				pictureBox32.BackgroundImage = Resources.Adamant_platebody;
				pictureBox32.Tag = "Adamant platebody x 1";
				pictureBox33.BackgroundImage = Resources.Bass;
				pictureBox33.Tag = "Bass x 5";
				pictureBox34.BackgroundImage = Resources.Swordfish;
				pictureBox34.Tag = "Swordfish x 5";
				pictureBox35.BackgroundImage = Resources.Shark;
				pictureBox35.Tag = "Shark x 5";
				pictureBox36.BackgroundImage = Resources.Coins_1000;
				pictureBox36.Tag = "Varies; Coins";
				pictureBox37.BackgroundImage = Resources.Ring_of_life;
				pictureBox37.Tag = "Ring of life x 1";
				pictureBox38.BackgroundImage = Resources.Rock_shell_plate;
				pictureBox38.Tag = "Rock-shell plate x 1";
				pictureBox39.BackgroundImage = Resources.Rock_shell_legs;
				pictureBox39.Tag = "Rock-shell legs x 1";
				pictureBox40.BackgroundImage = Resources.Hard_clue_scroll;
				pictureBox40.Tag = "Hard clue scroll x 1";
				pictureBox41.BackgroundImage = Resources.Elite_clue_scroll;
				pictureBox41.Tag = "Elite clue scroll x 1";
				pictureBox42.BackgroundImage = Resources.Dragon_axe;
				pictureBox42.Tag = "Dragon axe x 1";
				pictureBox43.BackgroundImage = Resources.Warrior_ring;
				pictureBox43.Tag = "Warrior ring x 1";
				pictureBox44.BackgroundImage = Resources.Berserker_ring;
				pictureBox44.Tag = "Berserker ring x 1";
				pictureBox45.BackgroundImage = Resources.Pet_dagannoth_rex;
				pictureBox45.Tag = "Pet dagannoth x 1";
				pictureBox46.BackgroundImage = Resources.RDT;
				pictureBox46.Tag = "RDT";
				setNPictureBoxesToVisible(46, "Dagannoth Kings");
				setNPictureBoxesToEnabled(46);
				removeAllItemQuantityOverlays();
				resetAllPictureBoxBackgroundColor();
			}
			if (selectedDagannothKing == "Dagannoth Supreme") {
				pictureBox1.BackgroundImage = Resources.Iron_arrow_5;
				pictureBox1.Tag = "Varies; Iron arrow";
				pictureBox2.BackgroundImage = Resources.Steel_arrow_5;
				pictureBox2.Tag = "Varies; Steel arrow";
				pictureBox3.BackgroundImage = Resources.Iron_knife;
				pictureBox3.Tag = "Varies; Iron knife";
				pictureBox4.BackgroundImage = Resources.Steel_knife;
				pictureBox4.Tag = "Varies; Steel knife";
				pictureBox5.BackgroundImage = Resources.Mithril_knife;
				pictureBox5.Tag = "Varies; Mithril knife";
				pictureBox6.BackgroundImage = Resources.Rune_thrownaxe;
				pictureBox6.Tag = "Varies; Rune thrownaxe";
				pictureBox7.BackgroundImage = Resources.Rune_javelin;
				pictureBox7.Tag = "Varies; Rune javelin";
				pictureBox8.BackgroundImage = Resources.Runite_bolts_5;
				pictureBox8.Tag = "Varies; Runite bolts";
				pictureBox9.BackgroundImage = Resources.Runite_limbs;
				pictureBox9.Tag = "Runite limbs x 1";
				pictureBox10.BackgroundImage = Resources.Adamant_axe;
				pictureBox10.Tag = "Adamant axe x 1";
				pictureBox11.BackgroundImage = Resources.Belladonna_seed_1;
				pictureBox11.Tag = "Belladonna seed x 1";
				pictureBox12.BackgroundImage = Resources.Cactus_seed_1;
				pictureBox12.Tag = "Cactus seed x 1";
				pictureBox13.BackgroundImage = Resources.Poison_ivy_seed_1;
				pictureBox13.Tag = "Poison ivy seed x 1";
				pictureBox14.BackgroundImage = Resources.Irit_seed_1;
				pictureBox14.Tag = "Irit seed x 1";
				pictureBox15.BackgroundImage = Resources.Toadflax_seed_1;
				pictureBox15.Tag = "Toadflax seed x 1";
				pictureBox16.BackgroundImage = Resources.Avantoe_seed_1;
				pictureBox16.Tag = "Avantoe seed x 1";
				pictureBox17.BackgroundImage = Resources.Kwuarm_seed_1;
				pictureBox17.Tag = "Kwuarm seed x 1";
				pictureBox18.BackgroundImage = Resources.Cadantine_seed_1;
				pictureBox18.Tag = "Cadantine seed x 1";
				pictureBox19.BackgroundImage = Resources.Lantadyme_seed_1;
				pictureBox19.Tag = "Lantadyme seed x 1";
				pictureBox20.BackgroundImage = Resources.Dwarf_weed_seed_1;
				pictureBox20.Tag = "Dwarf weed seed x 1";
				pictureBox21.BackgroundImage = Resources.Torstol_seed_1;
				pictureBox21.Tag = "Torstol seed x 1";
				pictureBox22.BackgroundImage = Resources.Coins_1000;
				pictureBox22.Tag = "Varies; Coins";
				pictureBox23.BackgroundImage = Resources.Opal_bolt_tips_5;
				pictureBox23.Tag = "Varies; Opal bolt tips";
				pictureBox24.BackgroundImage = Resources.Oyster_pearls;
				pictureBox24.Tag = "Oyster pearls x 1";
				pictureBox25.BackgroundImage = Resources.Shark;
				pictureBox25.Tag = "Shark x 5";
				pictureBox26.BackgroundImage = Resources.Maple_logs_noted_generic;
				pictureBox26.Tag = "Varies; Maple logs";
				pictureBox27.BackgroundImage = Resources.Yew_logs_noted_generic;
				pictureBox27.Tag = "Varies; Yew logs";
				pictureBox28.BackgroundImage = Resources.Grimy_ranarr_weed;
				pictureBox28.Tag = "Grimy ranarr weed x 1";
				pictureBox29.BackgroundImage = Resources.Ensouled_dagannoth_head;
				pictureBox29.Tag = "Ensouled dagannoth head x 1";
				pictureBox30.BackgroundImage = Resources.Feather;
				pictureBox30.Tag = "Varies; Feather";
				pictureBox31.BackgroundImage = Resources.Red_d_hide_vamb;
				pictureBox31.Tag = "Red d'hide vamb x 1";
				pictureBox32.BackgroundImage = Resources.Fremennik_shield;
				pictureBox32.Tag = "Fremennik shield x 1";
				pictureBox33.BackgroundImage = Resources.Fremennik_helm;
				pictureBox33.Tag = "Fremennik helm x 1";
				pictureBox34.BackgroundImage = Resources.Spined_body;
				pictureBox34.Tag = "Spined body x 1";
				pictureBox35.BackgroundImage = Resources.Spined_chaps;
				pictureBox35.Tag = "Spined chaps x 1";
				pictureBox36.BackgroundImage = Resources.Archer_helm;
				pictureBox36.Tag = "Archer helm x 1";
				pictureBox37.BackgroundImage = Resources.Hard_clue_scroll;
				pictureBox37.Tag = "Hard clue scroll x 1";
				pictureBox38.BackgroundImage = Resources.Elite_clue_scroll;
				pictureBox38.Tag = "Elite clue scroll x 1";
				pictureBox39.BackgroundImage = Resources.Seercull;
				pictureBox39.Tag = "Seercull x 1";
				pictureBox40.BackgroundImage = Resources.Dragon_axe;
				pictureBox40.Tag = "Dragon axe x 1";
				pictureBox41.BackgroundImage = Resources.Archers_ring;
				pictureBox41.Tag = "Archers ring x 1";
				pictureBox42.BackgroundImage = Resources.Pet_dagannoth_supreme;
				pictureBox42.Tag = "Pet dagannoth supreme x 1";
				pictureBox43.BackgroundImage = Resources.RDT;
				pictureBox43.Tag = "RDT";
				setNPictureBoxesToVisible(43, "Dagannoth Kings");
				setNPictureBoxesToEnabled(43);
				removeAllItemQuantityOverlays();
				resetAllPictureBoxBackgroundColor();

			}
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void giantMoleToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + giantMoleToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Mithril_battleaxe;
			pictureBox1.Tag = "Mithril battleaxe x 1";
			pictureBox2.BackgroundImage = Resources.Mithril_axe;
			pictureBox2.Tag = "Mithril axe x 1";
			pictureBox3.BackgroundImage = Resources.Adamant_longsword;
			pictureBox3.Tag = "Adamant longsword x 1";
			pictureBox4.BackgroundImage = Resources.Mithril_platebody;
			pictureBox4.Tag = "Mithril platebody x 1";
			pictureBox5.BackgroundImage = Resources.Rune_med_helm;
			pictureBox5.Tag = "Rune med helm x 1";
			pictureBox6.BackgroundImage = Resources.Iron_arrow_690;
			pictureBox6.Tag = "Iron arrow x 690";
			pictureBox7.BackgroundImage = Resources.Mithril_bar;
			pictureBox7.Tag = "Mithril bar x 1";
			pictureBox8.BackgroundImage = Resources.Iron_ore_noted_100;
			pictureBox8.Tag = "Iron ore x 100";
			pictureBox9.BackgroundImage = Resources.Amulet_of_strength;
			pictureBox9.Tag = "Amulet of strength x 1";
			pictureBox10.BackgroundImage = Resources.Law_rune_15;
			pictureBox10.Tag = "Law rune x 15";
			pictureBox11.BackgroundImage = Resources.Air_rune_105;
			pictureBox11.Tag = "Air rune x 105";
			pictureBox12.BackgroundImage = Resources.Fire_rune_105;
			pictureBox12.Tag = "Fire rune x 105";
			pictureBox13.BackgroundImage = Resources.Blood_rune_15;
			pictureBox13.Tag = "Blood rune x 15";
			pictureBox14.BackgroundImage = Resources.Death_rune_7;
			pictureBox14.Tag = "Death rune x 7";
			pictureBox15.BackgroundImage = Resources.Oyster_pearls;
			pictureBox15.Tag = "Oyster pearls x 1";
			pictureBox16.BackgroundImage = Resources.Shark;
			pictureBox16.Tag = "Shark x 4";
			pictureBox17.BackgroundImage = Resources.Yew_logs_noted_100;
			pictureBox17.Tag = "Yew logs x 100";
			pictureBox18.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox18.Tag = "Elite clue scroll x 1";
			pictureBox19.BackgroundImage = Resources.Long_bone;
			pictureBox19.Tag = "Long bone x 1";
			pictureBox20.BackgroundImage = Resources.Curved_bone;
			pictureBox20.Tag = "Curved bone x 1";
			pictureBox21.BackgroundImage = Resources.Baby_mole;
			pictureBox21.Tag = "Baby mole x 1";
			pictureBox22.BackgroundImage = Resources.RDT;
			pictureBox22.Tag = "RDT";
			setNPictureBoxesToVisible(22);
			setNPictureBoxesToEnabled(22);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void grotesqueGuardiansToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + grotesqueGuardiansToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Chaos_rune;
			pictureBox1.Tag = "Varies; Chaos rune";
			pictureBox2.BackgroundImage = Resources.Death_rune;
			pictureBox2.Tag = "Varies; Death rune";
			pictureBox3.BackgroundImage = Resources.Diamond_bolt_tips_5;
			pictureBox3.Tag = "Varies; Diamond bolt tips";
			pictureBox4.BackgroundImage = Resources.Dragon_bolt_tips_5;
			pictureBox4.Tag = "Varies; Dragon bolt tips";
			pictureBox5.BackgroundImage = Resources.Onyx_bolt_tips_5;
			pictureBox5.Tag = "Varies; Onyx bolt tips";
			pictureBox6.BackgroundImage = Resources.Dragon_dart_tips_generic;
			pictureBox6.Tag = "Varies; Dragon dart tips";
			pictureBox7.BackgroundImage = Resources.Dragon_arrowtips_5;
			pictureBox7.Tag = "Varies; Dragon arrowtips";
			pictureBox8.BackgroundImage = Resources.Prayer_potion__4_;
			pictureBox8.Tag = "Prayer potion (4) x 1";
			pictureBox9.BackgroundImage = Resources.Coal_noted_generic;
			pictureBox9.Tag = "Varies; Coal";
			pictureBox10.BackgroundImage = Resources.Gold_ore_noted_generic;
			pictureBox10.Tag = "Varies; Gold ore";
			pictureBox11.BackgroundImage = Resources.Runite_ore_noted_generic;
			pictureBox11.Tag = "Varies; Runite ore";
			pictureBox12.BackgroundImage = Resources.Gold_bar_noted_generic;
			pictureBox12.Tag = "Varies; Gold bar";
			pictureBox13.BackgroundImage = Resources.Mithril_bar_noted_generic;
			pictureBox13.Tag = "Varies; Mithril bar";
			pictureBox14.BackgroundImage = Resources.Adamantite_bar_noted_generic;
			pictureBox14.Tag = "Varies; Adamantite bar";
			pictureBox15.BackgroundImage = Resources.Runite_bar_noted_generic;
			pictureBox15.Tag = "Varies; Runite bar";
			pictureBox16.BackgroundImage = Resources.Saradomin_brew__4_;
			pictureBox16.Tag = "Saradomin brew (4) x 2";
			pictureBox17.BackgroundImage = Resources.Rune_pickaxe;
			pictureBox17.Tag = "Rune pickaxe x 1";
			pictureBox18.BackgroundImage = Resources.Rune_battleaxe;
			pictureBox18.Tag = "Rune battleaxe x 1";
			pictureBox19.BackgroundImage = Resources.Rune_2h_sword;
			pictureBox19.Tag = "Rune 2h sword x 1";
			pictureBox20.BackgroundImage = Resources.Rune_full_helm;
			pictureBox20.Tag = "Rune full helm x 1";
			pictureBox21.BackgroundImage = Resources.Rune_platelegs;
			pictureBox21.Tag = "Rune platelegs x 1";
			pictureBox22.BackgroundImage = Resources.Dragon_longsword;
			pictureBox22.Tag = "Dragon longsword x 1";
			pictureBox23.BackgroundImage = Resources.Dragon_med_helm;
			pictureBox23.Tag = "Dragon med helm x 1";
			pictureBox24.BackgroundImage = Resources.Scb_range_magic_potion__2_;
			pictureBox24.Tag = "Super combat potion (2) x 1, ranging potion (2) x 1, magic potion (2) x 1";
			pictureBox25.BackgroundImage = Resources.Adamant_boots;
			pictureBox25.Tag = "Adamant boots x 1";
			pictureBox26.BackgroundImage = Resources.Mushroom_potato;
			pictureBox26.Tag = "Mushroom potato x 5";
			pictureBox27.BackgroundImage = Resources.Crystal_key;
			pictureBox27.Tag = "Crystal key x 1";
			pictureBox28.BackgroundImage = Resources.Granite_maul;
			pictureBox28.Tag = "Granite maul x 1";
			pictureBox29.BackgroundImage = Resources.Granite_gloves;
			pictureBox29.Tag = "Granite gloves x 1";
			pictureBox30.BackgroundImage = Resources.Granite_ring;
			pictureBox30.Tag = "Granite ring x 1";
			pictureBox31.BackgroundImage = Resources.Granite_hammer;
			pictureBox31.Tag = "Granite hammer x 1";
			pictureBox32.BackgroundImage = Resources.Black_tourmaline_core;
			pictureBox32.Tag = "Black tourmaline core x 1";
			pictureBox33.BackgroundImage = Resources.Coins_10000;
			pictureBox33.Tag = "Varies; Coins";
			pictureBox34.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox34.Tag = "Elite clue scroll x 1";
			pictureBox35.BackgroundImage = Resources.Jar_of_stone;
			pictureBox35.Tag = "Jar of stone x 1";
			pictureBox36.BackgroundImage = Resources.Noon;
			pictureBox36.Tag = "Noon x 1";
			setNPictureBoxesToVisible(36);
			setNPictureBoxesToEnabled(36);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void kalphiteQueenToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + kalphiteQueenToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Battlestaff_noted_10;
			pictureBox1.Tag = "Battlestaff x 10";
			pictureBox2.BackgroundImage = Resources.Lava_battlestaff;
			pictureBox2.Tag = "Lava battlestaff x 1";
			pictureBox3.BackgroundImage = Resources.Mithril_arrow_500;
			pictureBox3.Tag = "Mithril arrow x 500";
			pictureBox4.BackgroundImage = Resources.Rune_arrow_250;
			pictureBox4.Tag = "Rune arrow x 250";
			pictureBox5.BackgroundImage = Resources.Rune_knife__p____25;
			pictureBox5.Tag = "Rune knife (p++) x 25";
			pictureBox6.BackgroundImage = Resources.Red_d_hide_body;
			pictureBox6.Tag = "Red d'hide body x 1";
			pictureBox7.BackgroundImage = Resources.Rune_chainbody;
			pictureBox7.Tag = "Rune chainbody x 1";
			pictureBox8.BackgroundImage = Resources.Grapes_noted_100;
			pictureBox8.Tag = "Grapes x 100";
			pictureBox9.BackgroundImage = Resources.Super_combat_potion__2_;
			pictureBox9.Tag = "Super combat potion (2) x 1";
			pictureBox10.BackgroundImage = Resources.Superantipoison__2_;
			pictureBox10.Tag = "Superantipoison (2) x 1";
			pictureBox11.BackgroundImage = Resources.Ranging_potion__3_;
			pictureBox11.Tag = "Ranging potion (3) x 1";
			pictureBox12.BackgroundImage = Resources.Saradomin_brew__4_;
			pictureBox12.Tag = "Saradomin brew (4) x 1";
			pictureBox13.BackgroundImage = Resources.Super_restore__4_;
			pictureBox13.Tag = "Super restore (4) x 1";
			pictureBox14.BackgroundImage = Resources.Prayer_potion__4_;
			pictureBox14.Tag = "Prayer potion (4) x 2";
			pictureBox15.BackgroundImage = Resources.Weapon_poison______noted_5;
			pictureBox15.Tag = "Weapon poison (++) x 5";
			pictureBox16.BackgroundImage = Resources.Wine_of_zamorak_noted_60;
			pictureBox16.Tag = "Wine of zamokak x 60";
			pictureBox17.BackgroundImage = Resources.Uncut_emerald_noted_25;
			pictureBox17.Tag = "Uncut emerald x 25";
			pictureBox18.BackgroundImage = Resources.Uncut_ruby_noted_25;
			pictureBox18.Tag = "Uncut ruby x 25";
			pictureBox19.BackgroundImage = Resources.Uncut_diamond_noted_25;
			pictureBox19.Tag = "Uncut diamond x 25";
			pictureBox20.BackgroundImage = Resources.Watermelon_seed_25;
			pictureBox20.Tag = "Watermelon seed x 25";
			pictureBox21.BackgroundImage = Resources.Torstol_seed_2;
			pictureBox21.Tag = "Torstol seed x 2";
			pictureBox22.BackgroundImage = Resources.Papaya_tree_seed_2;
			pictureBox22.Tag = "Papaya tree seed x 2";
			pictureBox23.BackgroundImage = Resources.Palm_tree_seed_2;
			pictureBox23.Tag = "Palm tree seed x 2";
			pictureBox24.BackgroundImage = Resources.Magic_seed_2;
			pictureBox24.Tag = "Magic seed x 2";
			pictureBox25.BackgroundImage = Resources.Blood_rune_100;
			pictureBox25.Tag = "Blood rune x 100";
			pictureBox26.BackgroundImage = Resources.Death_rune_150;
			pictureBox26.Tag = "Death rune x 150";
			pictureBox27.BackgroundImage = Resources.Potato_cactus_noted_100;
			pictureBox27.Tag = "Potato cactus x 100";
			pictureBox28.BackgroundImage = Resources.Magic_logs_noted_60;
			pictureBox28.Tag = "Magic logs x 60";
			pictureBox29.BackgroundImage = Resources.Toadflax_noted_25;
			pictureBox29.Tag = "Toadflax x 25";
			pictureBox30.BackgroundImage = Resources.Ranarr_weed_noted_25;
			pictureBox30.Tag = "Ranarr weed x 25";
			pictureBox31.BackgroundImage = Resources.Snapdragon_noted_25;
			pictureBox31.Tag = "Snapdragon x 25";
			pictureBox32.BackgroundImage = Resources.Torstol_noted_25;
			pictureBox32.Tag = "Torstol x 25";
			pictureBox33.BackgroundImage = Resources.Runite_bar_noted_3;
			pictureBox33.Tag = "Runite bar x 3";
			pictureBox34.BackgroundImage = Resources.Bucket_of_sand_noted_100;
			pictureBox34.Tag = "Bucket of sand x 100";
			pictureBox35.BackgroundImage = Resources.Cactus_spine_noted_10;
			pictureBox35.Tag = "Cactus spine x 10";
			pictureBox36.BackgroundImage = Resources.Gold_ore_noted_250;
			pictureBox36.Tag = "Gold ore x 250";
			pictureBox37.BackgroundImage = Resources.Ensouled_kalphite_head;
			pictureBox37.Tag = "Ensouled kalphite head x 1";
			pictureBox38.BackgroundImage = Resources.Monkfish;
			pictureBox38.Tag = "Monkfish x 3";
			pictureBox39.BackgroundImage = Resources.Shark;
			pictureBox39.Tag = "Shark x 2";
			pictureBox40.BackgroundImage = Resources.Dark_crab;
			pictureBox40.Tag = "Dark crab x 2";
			pictureBox41.BackgroundImage = Resources.Coins_10000;
			pictureBox41.Tag = "Varies; Coins";
			pictureBox42.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox42.Tag = "Elite clue scroll x 1";
			pictureBox43.BackgroundImage = Resources.Dragon_2h_sword;
			pictureBox43.Tag = "Dragon 2h sword x 1";
			pictureBox44.BackgroundImage = Resources.Dragon_chainbody;
			pictureBox44.Tag = "Dragon chainbody x 1";
			pictureBox45.BackgroundImage = Resources.Kq_head;
			pictureBox45.Tag = "Kq head x 1";
			pictureBox46.BackgroundImage = Resources.Jar_of_sand;
			pictureBox46.Tag = "Jar of sand x 1";
			pictureBox47.BackgroundImage = Resources.Kalphite_princess;
			pictureBox47.Tag = "Kalphite princess x 1";
			pictureBox48.BackgroundImage = Resources.RDT;
			pictureBox48.Tag = "RDT";
			setNPictureBoxesToVisible(48);
			setNPictureBoxesToEnabled(48);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void krakenToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + krakenToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_warhammer;
			pictureBox1.Tag = "Rune warhammer x 1";
			pictureBox2.BackgroundImage = Resources.Rune_longsword;
			pictureBox2.Tag = "Rune longsword x 1";
			pictureBox3.BackgroundImage = Resources.Mystic_water_staff;
			pictureBox3.Tag = "Mystic water staff x 1";
			pictureBox4.BackgroundImage = Resources.Mystic_robe_top__blue_;
			pictureBox4.Tag = "Mystic robe top (blue) x 1";
			pictureBox5.BackgroundImage = Resources.Mystic_robe_bottom__blue_;
			pictureBox5.Tag = "Mystic robe bottom (blue) x 1";
			pictureBox6.BackgroundImage = Resources.Harpoon;
			pictureBox6.Tag = "Harpoon x 1";
			pictureBox7.BackgroundImage = Resources.Seaweed_noted_125;
			pictureBox7.Tag = "Seaweed x 125";
			pictureBox8.BackgroundImage = Resources.Battlestaff_noted_10;
			pictureBox8.Tag = "Battlestaff x 10";
			pictureBox9.BackgroundImage = Resources.Water_rune_400;
			pictureBox9.Tag = "Water rune x 400";
			pictureBox10.BackgroundImage = Resources.Mist_rune_100;
			pictureBox10.Tag = "Mist rune x 100";
			pictureBox11.BackgroundImage = Resources.Chaos_rune_250;
			pictureBox11.Tag = "Chaos rune x 250";
			pictureBox12.BackgroundImage = Resources.Death_rune_150;
			pictureBox12.Tag = "Death rune x 150";
			pictureBox13.BackgroundImage = Resources.Blood_rune_60;
			pictureBox13.Tag = "Blood rune x 60";
			pictureBox14.BackgroundImage = Resources.Soul_rune_50;
			pictureBox14.Tag = "Soul rune x 50";
			pictureBox15.BackgroundImage = Resources.Unpowered_orb_noted_50;
			pictureBox15.Tag = "Unpowered orb x 50";
			pictureBox16.BackgroundImage = Resources.Diamond_noted_8;
			pictureBox16.Tag = "Diamond x 8";
			pictureBox17.BackgroundImage = Resources.Oak_plank_noted_60;
			pictureBox17.Tag = "Oak plank x 60";
			pictureBox18.BackgroundImage = Resources.Raw_shark_noted_50;
			pictureBox18.Tag = "Raw shark x 50";
			pictureBox19.BackgroundImage = Resources.Raw_monkfish_noted_100;
			pictureBox19.Tag = "Raw monkfish x 100";
			pictureBox20.BackgroundImage = Resources.Runite_bar;
			pictureBox20.Tag = "Runite bar x 2";
			pictureBox21.BackgroundImage = Resources.Grimy_snapdragon_noted_6;
			pictureBox21.Tag = "Grimy snapdragon x 6";
			pictureBox22.BackgroundImage = Resources.Shark;
			pictureBox22.Tag = "Shark x 5";
			pictureBox23.BackgroundImage = Resources.Edible_seaweed;
			pictureBox23.Tag = "Edible seaweed x 5";
			pictureBox24.BackgroundImage = Resources.Bucket;
			pictureBox24.Tag = "Bucket x 1";
			pictureBox25.BackgroundImage = Resources.Sanfew_serum__4_;
			pictureBox25.Tag = "Sanfew serum (4) x 2";
			pictureBox26.BackgroundImage = Resources.Crystal_key;
			pictureBox26.Tag = "Crystal key x 1";
			pictureBox27.BackgroundImage = Resources.Rusty_sword;
			pictureBox27.Tag = "Rusty sword x 1";
			pictureBox28.BackgroundImage = Resources.Antidote____4__noted_2;
			pictureBox28.Tag = "Antidote++ (4) x 2";
			pictureBox29.BackgroundImage = Resources.Watermelon_seed_24;
			pictureBox29.Tag = "Watermelon seed x 24";
			pictureBox30.BackgroundImage = Resources.Torstol_seed_2;
			pictureBox30.Tag = "Torstol seed x 2";
			pictureBox31.BackgroundImage = Resources.Magic_seed_1;
			pictureBox31.Tag = "Magic seed x 1";
			pictureBox32.BackgroundImage = Resources.Pirate_boots;
			pictureBox32.Tag = "Pirate boots x 1";
			pictureBox33.BackgroundImage = Resources.Coins_10000;
			pictureBox33.Tag = "Varies; Coins";
			pictureBox34.BackgroundImage = Resources.Dragonstone_ring;
			pictureBox34.Tag = "Dragonstone ring x 1";
			pictureBox35.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox35.Tag = "Elite clue scroll x 1";
			pictureBox36.BackgroundImage = Resources.Trident_of_the_seas__full_;
			pictureBox36.Tag = "Trident of the seas (full) x 1";
			pictureBox37.BackgroundImage = Resources.Kraken_tentacle;
			pictureBox37.Tag = "Kraken tentacle x 1";
			pictureBox38.BackgroundImage = Resources.Jar_of_dirt;
			pictureBox38.Tag = "Jar of dirt x 1";
			pictureBox39.BackgroundImage = Resources.Pet_kraken;
			pictureBox39.Tag = "Pet kraken x 1";
			pictureBox40.BackgroundImage = Resources.RDT;
			pictureBox40.Tag = "RDT";
			setNPictureBoxesToVisible(40);
			setNPictureBoxesToEnabled(40);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void raidsToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + raidsToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Death_rune;
			pictureBox1.Tag = "Varies; Death rune";
			pictureBox2.BackgroundImage = Resources.Blood_rune;
			pictureBox2.Tag = "Varies; Blood rune";
			pictureBox3.BackgroundImage = Resources.Soul_rune;
			pictureBox3.Tag = "Varies; Soul rune";
			pictureBox4.BackgroundImage = Resources.Rune_arrow_generic;
			pictureBox4.Tag = "Varies; Rune arrow";
			pictureBox5.BackgroundImage = Resources.Dragon_arrow_generic;
			pictureBox5.Tag = "Varies; Dragon arrow";
			pictureBox6.BackgroundImage = Resources.Grimy_toadflax_noted_generic;
			pictureBox6.Tag = "Varies; Grimy toadflax";
			pictureBox7.BackgroundImage = Resources.Grimy_ranarr_weed_noted_generic;
			pictureBox7.Tag = "Varies; Grimy ranarr weed";
			pictureBox8.BackgroundImage = Resources.Grimy_irit_leaf_noted_generic;
			pictureBox8.Tag = "Varies; Grimy irit leaf";
			pictureBox9.BackgroundImage = Resources.Grimy_avantoe_noted_generic;
			pictureBox9.Tag = "Varies; Grimy avantoe";
			pictureBox10.BackgroundImage = Resources.Grimy_kwuarm_noted_generic;
			pictureBox10.Tag = "Varies; Grimy kwuarm";
			pictureBox11.BackgroundImage = Resources.Grimy_snapdragon_noted_generic;
			pictureBox11.Tag = "Varies; Grimy snapdragon";
			pictureBox12.BackgroundImage = Resources.Grimy_cadantine_noted_generic;
			pictureBox12.Tag = "Varies; Grimy cadantine";
			pictureBox13.BackgroundImage = Resources.Grimy_lantadyme_noted_generic;
			pictureBox13.Tag = "Varies; Grimy lantadyme";
			pictureBox14.BackgroundImage = Resources.Grimy_dwarf_weed_noted_generic;
			pictureBox14.Tag = "Varies; Grimy dwarf weed";
			pictureBox15.BackgroundImage = Resources.Grimy_torstol_noted_generic;
			pictureBox15.Tag = "Varies; Grimy torstol";
			pictureBox16.BackgroundImage = Resources.Silver_ore_noted_generic;
			pictureBox16.Tag = "Varies; Silver ore";
			pictureBox17.BackgroundImage = Resources.Coal_noted_generic;
			pictureBox17.Tag = "Varies; Coal";
			pictureBox18.BackgroundImage = Resources.Gold_ore_noted_generic;
			pictureBox18.Tag = "Varies; Gold ore";
			pictureBox19.BackgroundImage = Resources.Mithril_ore_noted_generic;
			pictureBox19.Tag = "Varies; Mithril ore";
			pictureBox20.BackgroundImage = Resources.Adamantite_ore_noted_generic;
			pictureBox20.Tag = "Varies; Adamantite ore";
			pictureBox21.BackgroundImage = Resources.Runite_ore_noted_generic;
			pictureBox21.Tag = "Varies; Runite ore";
			pictureBox22.BackgroundImage = Resources.Uncut_sapphire_noted_generic;
			pictureBox22.Tag = "Varies; Uncut sapphire";
			pictureBox23.BackgroundImage = Resources.Uncut_emerald_noted_generic;
			pictureBox23.Tag = "Varies; Uncut emerald";
			pictureBox24.BackgroundImage = Resources.Uncut_ruby_noted_generic;
			pictureBox24.Tag = "Varies; Uncut ruby";
			pictureBox25.BackgroundImage = Resources.Uncut_diamond_noted_generic;
			pictureBox25.Tag = "Varies; Uncut diamond";
			pictureBox26.BackgroundImage = Resources.Lizardman_fang_generic;
			pictureBox26.Tag = "Varies; Lizardman fang";
			pictureBox27.BackgroundImage = Resources.Pure_essence_noted_generic;
			pictureBox27.Tag = "Varies; Pure essence";
			pictureBox28.BackgroundImage = Resources.Saltpetre_noted_generic;
			pictureBox28.Tag = "Varies; Saltpetre";
			pictureBox29.BackgroundImage = Resources.Teak_plank_noted_generic;
			pictureBox29.Tag = "Varies; Teak plank";
			pictureBox30.BackgroundImage = Resources.Mahogany_plank_noted_generic;
			pictureBox30.Tag = "Varies; Mahogany plank";
			pictureBox31.BackgroundImage = Resources.Dynamite_noted_generic;
			pictureBox31.Tag = "Varies; Dynamite";
			pictureBox32.BackgroundImage = Resources.Torn_prayer_scroll;
			pictureBox32.Tag = "Torn prayer scroll x 1";
			pictureBox33.BackgroundImage = Resources.Ancient_tablet;
			pictureBox33.Tag = "Ancient tablet x 1";
			pictureBox34.BackgroundImage = Resources.Dark_relic;
			pictureBox34.Tag = "Dark relic x 1";
			pictureBox35.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox35.Tag = "Elite clue scroll x 1";
			pictureBox36.BackgroundImage = Resources.Arcane_prayer_scroll;
			pictureBox36.Tag = "Arcane prayer scroll x 1";
			pictureBox37.BackgroundImage = Resources.Dexterous_prayer_scroll;
			pictureBox37.Tag = "Dexterous prayer scroll x 1";
			pictureBox38.BackgroundImage = Resources.Dragon_sword;
			pictureBox38.Tag = "Dragon sword x 1";
			pictureBox39.BackgroundImage = Resources.Dragon_thrownaxe_100;
			pictureBox39.Tag = "Dragon thrownaxe x 100";
			pictureBox40.BackgroundImage = Resources.Twisted_buckler;
			pictureBox40.Tag = "Twisted buckler x 1";
			pictureBox41.BackgroundImage = Resources.Dragon_hunter_crossbow;
			pictureBox41.Tag = "Dragon hunter crossbow x 1";
			pictureBox42.BackgroundImage = Resources.Dinh_s_bulwark;
			pictureBox42.Tag = "Dinh's bulwark x 1";
			pictureBox43.BackgroundImage = Resources.Ancestral_hat;
			pictureBox43.Tag = "Ancestral hat x 1";
			pictureBox44.BackgroundImage = Resources.Ancestral_robe_top;
			pictureBox44.Tag = "Ancestral robe top x 1";
			pictureBox45.BackgroundImage = Resources.Ancestral_robe_bottom;
			pictureBox45.Tag = "Ancestral robe bottom x 1";
			pictureBox46.BackgroundImage = Resources.Dragon_claws;
			pictureBox46.Tag = "Dragon claws x 1";
			pictureBox47.BackgroundImage = Resources.Elder_maul;
			pictureBox47.Tag = "Elder maul x 1";
			pictureBox48.BackgroundImage = Resources.Kodai_insignia;
			pictureBox48.Tag = "Kodai insignia x 1";
			pictureBox49.BackgroundImage = Resources.Twisted_bow;
			pictureBox49.Tag = "Twisted bow x 1";
			pictureBox50.BackgroundImage = Resources.Olmlet;
			pictureBox50.Tag = "Olmlet x 1";
			setNPictureBoxesToVisible(50);
			setNPictureBoxesToEnabled(50);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void skotizoToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + skotizoToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Death_rune_500;
			pictureBox1.Tag = "Death rune x 500";
			pictureBox2.BackgroundImage = Resources.Soul_rune_450;
			pictureBox2.Tag = "Soul rune x 450";
			pictureBox3.BackgroundImage = Resources.Blood_rune_450;
			pictureBox3.Tag = "Blood rune x 450";
			pictureBox4.BackgroundImage = Resources.Rune_platebody_noted_3;
			pictureBox4.Tag = "Rune platebody x 3";
			pictureBox5.BackgroundImage = Resources.Rune_kiteshield_noted_3;
			pictureBox5.Tag = "Rune kiteshield x 3";
			pictureBox6.BackgroundImage = Resources.Rune_platelegs_noted_3;
			pictureBox6.Tag = "Rune platelegs x 3";
			pictureBox7.BackgroundImage = Resources.Rune_plateskirt_noted_3;
			pictureBox7.Tag = "Rune plateskirt x 3";
			pictureBox8.BackgroundImage = Resources.Grimy_ranarr_weed_noted_40;
			pictureBox8.Tag = "Grimy ranarr weed x 40";
			pictureBox9.BackgroundImage = Resources.Grimy_snapdragon_noted_20;
			pictureBox9.Tag = "Grimy snapdragon x 20";
			pictureBox10.BackgroundImage = Resources.Grimy_torstol_noted_20;
			pictureBox10.Tag = "Grimy torstol x 20";
			pictureBox11.BackgroundImage = Resources.Battlestaff_noted_25;
			pictureBox11.Tag = "Battlestaff x 25";
			pictureBox12.BackgroundImage = Resources.Uncut_dragonstone_noted_10;
			pictureBox12.Tag = "Uncut dragonstone x 10";
			pictureBox13.BackgroundImage = Resources.Adamantite_ore_noted_75;
			pictureBox13.Tag = "Adamantite ore x 75";
			pictureBox14.BackgroundImage = Resources.Runite_bar_noted_20;
			pictureBox14.Tag = "Runite bar x 20";
			pictureBox15.BackgroundImage = Resources.Raw_anglerfish_noted_60;
			pictureBox15.Tag = "Raw anglerfish x 60";
			pictureBox16.BackgroundImage = Resources.Mahogany_plank_noted_150;
			pictureBox16.Tag = "Mahogany plank x 150";
			pictureBox17.BackgroundImage = Resources.Shield_left_half;
			pictureBox17.Tag = "Shield left half x 1";
			pictureBox18.BackgroundImage = Resources.Dark_totem_base;
			pictureBox18.Tag = "Dark totem base x 1";
			pictureBox19.BackgroundImage = Resources.Dark_totem_middle;
			pictureBox19.Tag = "Dark totem middle x 1";
			pictureBox20.BackgroundImage = Resources.Dark_totem_top;
			pictureBox20.Tag = "Dark totem top x 1";
			pictureBox21.BackgroundImage = Resources.Dark_totem;
			pictureBox21.Tag = "Dark totem x 1";
			pictureBox22.BackgroundImage = Resources.Onyx_bolt_tips_40;
			pictureBox22.Tag = "Onyx bolt tips x 40";
			pictureBox23.BackgroundImage = Resources.Uncut_onyx;
			pictureBox23.Tag = "Uncut onyx x 1";
			pictureBox24.BackgroundImage = Resources.Hard_clue_scroll;
			pictureBox24.Tag = "Hard clue scroll x 1";
			pictureBox25.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox25.Tag = "Elite clue scroll x 1";
			pictureBox26.BackgroundImage = Resources.Jar_of_darkness;
			pictureBox26.Tag = "Jar of darkness x 1";
			setNPictureBoxesToVisible(26);
			setNPictureBoxesToEnabled(26);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void thermonuclearSmokeDevilToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + thermonuclearSmokeDevilToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_dagger;
			pictureBox1.Tag = "Rune dagger x 1";
			pictureBox2.BackgroundImage = Resources.Rune_scimitar;
			pictureBox2.Tag = "Rune scimitar x 1";
			pictureBox3.BackgroundImage = Resources.Rune_battleaxe;
			pictureBox3.Tag = "Rune battleaxe x 1";
			pictureBox4.BackgroundImage = Resources.Mystic_air_staff;
			pictureBox4.Tag = "Mystic air staff x 1";
			pictureBox5.BackgroundImage = Resources.Mystic_fire_staff;
			pictureBox5.Tag = "Mystic fire staff x 1";
			pictureBox6.BackgroundImage = Resources.Dragon_scimitar;
			pictureBox6.Tag = "Dragon scimitar x 1";
			pictureBox7.BackgroundImage = Resources.Fire_talisman;
			pictureBox7.Tag = "Fire talisman x 1";
			pictureBox8.BackgroundImage = Resources.Ancient_staff;
			pictureBox8.Tag = "Ancient staff x 1";
			pictureBox9.BackgroundImage = Resources.Red_d_hide_body;
			pictureBox9.Tag = "Red d'hide body x 1";
			pictureBox10.BackgroundImage = Resources.Rune_chainbody;
			pictureBox10.Tag = "Rune chainbody x 1";
			pictureBox11.BackgroundImage = Resources.Smoke_rune_100;
			pictureBox11.Tag = "Smoke rune x 100";
			pictureBox12.BackgroundImage = Resources.Air_rune_300;
			pictureBox12.Tag = "Air rune x 300";
			pictureBox13.BackgroundImage = Resources.Soul_rune_60;
			pictureBox13.Tag = "Soul rune x 60";
			pictureBox14.BackgroundImage = Resources.Rune_knife__p____50;
			pictureBox14.Tag = "Rune knife (p++) x 50";
			pictureBox15.BackgroundImage = Resources.Rune_arrow_100;
			pictureBox15.Tag = "Rune arrow x 100";
			pictureBox16.BackgroundImage = Resources.Snapdragon_seed_2;
			pictureBox16.Tag = "Snapdragon seed x 2";
			pictureBox17.BackgroundImage = Resources.Magic_seed_1;
			pictureBox17.Tag = "Magic seed x 1";
			pictureBox18.BackgroundImage = Resources.Pure_essence_noted_300;
			pictureBox18.Tag = "Pure essence x 300";
			pictureBox19.BackgroundImage = Resources.Desert_goat_horn_noted_50;
			pictureBox19.Tag = "Desert goat horn x 50";
			pictureBox20.BackgroundImage = Resources.Molten_glass_noted_100;
			pictureBox20.Tag = "Molten glass x 100";
			pictureBox21.BackgroundImage = Resources.Mithril_bar_noted_20;
			pictureBox21.Tag = "Mithril bar x 20";
			pictureBox22.BackgroundImage = Resources.Grimy_toadflax_noted_15;
			pictureBox22.Tag = "Grimy toadflax x 15";
			pictureBox23.BackgroundImage = Resources.Coal_noted_150;
			pictureBox23.Tag = "Coal x 150";
			pictureBox24.BackgroundImage = Resources.Gold_ore_noted_200;
			pictureBox24.Tag = "Gold ore x 200";
			pictureBox25.BackgroundImage = Resources.Onyx_bolt_tips_12;
			pictureBox25.Tag = "Onyx bolt tips x 12";
			pictureBox26.BackgroundImage = Resources.Grapes_noted_100;
			pictureBox26.Tag = "Grapes x 100";
			pictureBox27.BackgroundImage = Resources.Diamond_noted_10;
			pictureBox27.Tag = "Diamond x 10";
			pictureBox28.BackgroundImage = Resources.Magic_logs_noted_20;
			pictureBox28.Tag = "Magic logs x 20";
			pictureBox29.BackgroundImage = Resources.Ugthanki_kebab;
			pictureBox29.Tag = "Ugthanki kebab x 3";
			pictureBox30.BackgroundImage = Resources.Tuna_potato;
			pictureBox30.Tag = "Tuna potato x 3";
			pictureBox31.BackgroundImage = Resources.Prayer_potion__4_;
			pictureBox31.Tag = "Prayer potion (4) x 2";
			pictureBox32.BackgroundImage = Resources.Sanfew_serum__4_;
			pictureBox32.Tag = "Sanfew serum (4) x 2";
			pictureBox33.BackgroundImage = Resources.Tinderbox;
			pictureBox33.Tag = "Tinderbox x 1";
			pictureBox34.BackgroundImage = Resources.Coins_10000;
			pictureBox34.Tag = "Varies; Coins";
			pictureBox35.BackgroundImage = Resources.Bullseye_lantern__unlit_;
			pictureBox35.Tag = "Bullseye lantern (unlit) x 1";
			pictureBox36.BackgroundImage = Resources.Dragonstone_ring;
			pictureBox36.Tag = "Dragonstone ring x 1";
			pictureBox37.BackgroundImage = Resources.Crystal_key;
			pictureBox37.Tag = "Crystal key x 1";
			pictureBox38.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox38.Tag = "Elite clue scroll x 1";
			pictureBox39.BackgroundImage = Resources.Smoke_battlestaff;
			pictureBox39.Tag = "Smoke battlestaff x 1";
			pictureBox40.BackgroundImage = Resources.Occult_necklace;
			pictureBox40.Tag = "Occult necklace x 1";
			pictureBox41.BackgroundImage = Resources.Dragon_chainbody;
			pictureBox41.Tag = "Dragon chainbody x 1";
			pictureBox42.BackgroundImage = Resources.Pet_smoke_devil;
			pictureBox42.Tag = "Pet smoke devil x 1";
			pictureBox43.BackgroundImage = Resources.RDT;
			pictureBox43.Tag = "RDT";
			setNPictureBoxesToVisible(43);
			setNPictureBoxesToEnabled(43);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void vorkathToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + vorkathToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Rune_longsword;
			pictureBox1.Tag = "Varies; Rune longsword";
			pictureBox2.BackgroundImage = Resources.Dragon_battleaxe;
			pictureBox2.Tag = "Dragon battleaxe x 1";
			pictureBox3.BackgroundImage = Resources.Dragon_longsword;
			pictureBox3.Tag = "Dragon longsword x 1";
			pictureBox4.BackgroundImage = Resources.Dragon_platelegs;
			pictureBox4.Tag = "Dragon platelegs x 1";
			pictureBox5.BackgroundImage = Resources.Dragon_plateskirt;
			pictureBox5.Tag = "Dragon plateskirt x 1";
			pictureBox6.BackgroundImage = Resources.Death_rune_generic;
			pictureBox6.Tag = "Varies; Death rune";
			pictureBox7.BackgroundImage = Resources.Chaos_rune_generic;
			pictureBox7.Tag = "Varies; Chaos rune";
			pictureBox8.BackgroundImage = Resources.Wrath_rune_generic;
			pictureBox8.Tag = "Varies; Wrath rune";
			pictureBox9.BackgroundImage = Resources.Rune_kiteshield;
			pictureBox9.Tag = "Varies; Rune kiteshield";
			pictureBox10.BackgroundImage = Resources.Sapphire_bolt_tips_generic;
			pictureBox10.Tag = "Varies; Sapphire bolt tips";
			pictureBox11.BackgroundImage = Resources.Emerald_bolt_tips_generic;
			pictureBox11.Tag = "Varies; Emerald bolt tips";
			pictureBox12.BackgroundImage = Resources.Ruby_bolt_tips_generic;
			pictureBox12.Tag = "Varies; Ruby bolt tips";
			pictureBox13.BackgroundImage = Resources.Diamond_bolt_tips_generic;
			pictureBox13.Tag = "Varies; Diamond bolt tips";
			pictureBox14.BackgroundImage = Resources.Amethyst_bolt_tips_generic;
			pictureBox14.Tag = "Varies; Amethyst bolt tips";
			pictureBox15.BackgroundImage = Resources.Dragon_bolt_tips_generic;
			pictureBox15.Tag = "Varies; Dragon bolt tips";
			pictureBox16.BackgroundImage = Resources.Onyx_bolt_tips_generic;
			pictureBox16.Tag = "Varies; Onyx bolt tips";
			pictureBox17.BackgroundImage = Resources.Rune_dart_tips_generic;
			pictureBox17.Tag = "Varies; Rune dart tips";
			pictureBox18.BackgroundImage = Resources.Dragon_dart_tips_generic;
			pictureBox18.Tag = "Varies; Dragon dart tips";
			pictureBox19.BackgroundImage = Resources.Dragon_arrowtips_generic;
			pictureBox19.Tag = "Varies; Dragon arrowtips";
			pictureBox20.BackgroundImage = Resources.Dragon_bolts__unf__generic;
			pictureBox20.Tag = "Varies; Dragon bolts (unf)";
			pictureBox21.BackgroundImage = Resources.Diamond_noted_generic;
			pictureBox21.Tag = "Varies; Diamond";
			pictureBox22.BackgroundImage = Resources.Dragonstone_noted_generic;
			pictureBox22.Tag = "Varies; Dragonstone";
			pictureBox23.BackgroundImage = Resources.Adamantite_bar_noted_generic;
			pictureBox23.Tag = "Varies; Adamantite bar";
			pictureBox24.BackgroundImage = Resources.Adamantite_ore_noted_generic;
			pictureBox24.Tag = "Varies; Adamantite ore";
			pictureBox25.BackgroundImage = Resources.Green_dragonhide_noted_generic;
			pictureBox25.Tag = "Varies; Green dragonhide";
			pictureBox26.BackgroundImage = Resources.Blue_dragonhide_noted_generic;
			pictureBox26.Tag = "Varies; Blue dragonhide";
			pictureBox27.BackgroundImage = Resources.Red_dragonhide_noted_generic;
			pictureBox27.Tag = "Varies; Red dragonhide";
			pictureBox28.BackgroundImage = Resources.Black_dragonhide_noted_generic;
			pictureBox28.Tag = "Varies; Black dragonhide";
			pictureBox29.BackgroundImage = Resources.Battlestaff_noted_generic;
			pictureBox29.Tag = "Varies; Battlestaff";
			pictureBox30.BackgroundImage = Resources.Dragon_bones_noted_generic;
			pictureBox30.Tag = "Varies; Dragon bones";
			pictureBox31.BackgroundImage = Resources.Grapes_noted_generic;
			pictureBox31.Tag = "Varies; Grapes";
			pictureBox32.BackgroundImage = Resources.Manta_ray_noted_generic;
			pictureBox32.Tag = "Varies; Manta ray";
			pictureBox33.BackgroundImage = Resources.Magic_logs_noted_50;
			pictureBox33.Tag = "Magic logs x 50";
			pictureBox34.BackgroundImage = Resources.Crushed_nest_noted_generic;
			pictureBox34.Tag = "Varies; Crushed nest";

			//pictureBo334.BackgroundImage = Resources.Prayer_potion__4__noted_generic;
			//pictureBo334.Tag = "Varies; Prayer potion (4)";
			//pictureBox35.BackgroundImage = Resources.Antifire_potion__4__noted_generic;
			//pictureBox35.Tag = "Varies; Antifire potion (4)";
			pictureBox35.BackgroundImage = Resources.Ranarr_seed_generic;
			pictureBox35.Tag = "Varies; Ranarr seed";
			pictureBox36.BackgroundImage = Resources.Snapdragon_seed_generic;
			pictureBox36.Tag = "Varies; Snapdragon seed";
			pictureBox37.BackgroundImage = Resources.Torstol_seed_generic;
			pictureBox37.Tag = "Varies; Torstol seed";
			pictureBox38.BackgroundImage = Resources.Watermelon_seed_15;
			pictureBox38.Tag = "Watermelon seed x 15";
			pictureBox39.BackgroundImage = Resources.Teak_seed_generic;
			pictureBox39.Tag = "Varies; Teak seed";
			pictureBox40.BackgroundImage = Resources.Mahogany_seed_generic;
			pictureBox40.Tag = "Varies; Mahogany seed";
			pictureBox41.BackgroundImage = Resources.Papaya_tree_seed_generic;
			pictureBox41.Tag = "Varies; Papaya tree seed";
			pictureBox42.BackgroundImage = Resources.Palm_tree_seed_generic;
			pictureBox42.Tag = "Varies; Palm tree seed";
			pictureBox43.BackgroundImage = Resources.Calquat_tree_seed_generic;
			pictureBox43.Tag = "Varies; Calquat tree seed";
			pictureBox44.BackgroundImage = Resources.Willow_seed_generic;
			pictureBox44.Tag = "Varies; Willow seed";
			pictureBox45.BackgroundImage = Resources.Maple_seed_generic;
			pictureBox45.Tag = "Varies; Maple seed";
			pictureBox46.BackgroundImage = Resources.Yew_seed_generic;
			pictureBox46.Tag = "Varies; Yew seed";
			pictureBox47.BackgroundImage = Resources.Magic_seed_generic;
			pictureBox47.Tag = "Varies; Magic seed";
			pictureBox48.BackgroundImage = Resources.Spirit_seed_generic;
			pictureBox48.Tag = "Varies; Spirit seed";
			pictureBox49.BackgroundImage = Resources.Coins_10000;
			pictureBox49.Tag = "Varies; Coins";
			pictureBox50.BackgroundImage = Resources.Wrath_talisman;
			pictureBox50.Tag = "Wrath talisman x 1";
			pictureBox51.BackgroundImage = Resources.Superior_dragon_bones;
			pictureBox51.Tag = "Varies; Superior dragon bones";
			pictureBox52.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox52.Tag = "Elite clue scroll x 1";
			pictureBox53.BackgroundImage = Resources.Vorkath_s_head;
			pictureBox53.Tag = "Vorkath's head x 1";
			pictureBox54.BackgroundImage = Resources.Dragonbone_necklace;
			pictureBox54.Tag = "Dragonbone necklace x 1";
			pictureBox55.BackgroundImage = Resources.Draconic_visage;
			pictureBox55.Tag = "Draconic x 1";
			pictureBox56.BackgroundImage = Resources.Skeletal_visage;
			pictureBox56.Tag = "Skeletal visage x 1";
			pictureBox57.BackgroundImage = Resources.Jar_of_decay;
			pictureBox57.Tag = "Jar of decay x 1";
			pictureBox58.BackgroundImage = Resources.Vorki;
			pictureBox58.Tag = "Vorki x 1";
			pictureBox59.BackgroundImage = Resources.RDT;
			pictureBox59.Tag = "RDT";
			
			setNPictureBoxesToVisible(59);
			setNPictureBoxesToEnabled(59);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void wintertodtToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + wintertodtToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Oak_logs_noted_generic;
			pictureBox1.Tag = "Varies; Oak logs";
			pictureBox2.BackgroundImage = Resources.Willow_logs_noted_generic;
			pictureBox2.Tag = "Varies; Willow logs";
			pictureBox3.BackgroundImage = Resources.Maple_logs_noted_generic;
			pictureBox3.Tag = "Varies; Maple logs";
			pictureBox4.BackgroundImage = Resources.Teak_logs_noted_generic;
			pictureBox4.Tag = "Varies; Teak logs";
			pictureBox5.BackgroundImage = Resources.Mahogany_logs_noted_generic;
			pictureBox5.Tag = "Varies; Mahogany logs";
			pictureBox6.BackgroundImage = Resources.Yew_logs_noted_generic;
			pictureBox6.Tag = "Varies; Yew logs";
			pictureBox7.BackgroundImage = Resources.Magic_logs_noted_generic;
			pictureBox7.Tag = "Varies; Magic logs";
			pictureBox8.BackgroundImage = Resources.Pure_essence_noted_generic;
			pictureBox8.Tag = "Varies; Pure essence";
			pictureBox9.BackgroundImage = Resources.Uncut_sapphire_noted_generic;
			pictureBox9.Tag = "Varies; Uncut sapphire";
			pictureBox10.BackgroundImage = Resources.Uncut_emerald_noted_generic;
			pictureBox10.Tag = "Varies; Uncut emerald";
			pictureBox11.BackgroundImage = Resources.Uncut_ruby_noted_generic;
			pictureBox11.Tag = "Varies; Uncut ruby";
			pictureBox12.BackgroundImage = Resources.Uncut_diamond_noted_generic;
			pictureBox12.Tag = "Varies; Uncut diamond";
			pictureBox13.BackgroundImage = Resources.Coal_noted_generic;
			pictureBox13.Tag = "Varies; Coal";
			pictureBox14.BackgroundImage = Resources.Iron_ore_noted_generic;
			pictureBox14.Tag = "Varies; Iron ore";
			pictureBox15.BackgroundImage = Resources.Silver_ore_noted_generic;
			pictureBox15.Tag = "Varies; Silver ore";
			pictureBox16.BackgroundImage = Resources.Gold_ore_noted_generic;
			pictureBox16.Tag = "Varies; Gold ore";
			pictureBox17.BackgroundImage = Resources.Mithril_ore_noted_generic;
			pictureBox17.Tag = "Varies; Mithril ore";
			pictureBox18.BackgroundImage = Resources.Adamantite_ore_noted_generic;
			pictureBox18.Tag = "Varies; Adamantite ore";
			pictureBox19.BackgroundImage = Resources.Runite_ore_noted_generic;
			pictureBox19.Tag = "Varies; Runite ore";
			pictureBox20.BackgroundImage = Resources.Grimy_guam_leaf_noted_generic;
			pictureBox20.Tag = "Varies; Grimy guam leaf";
			pictureBox21.BackgroundImage = Resources.Grimy_marrentill_noted_generic;
			pictureBox21.Tag = "Varies; Grimy marrentill";
			pictureBox22.BackgroundImage = Resources.Grimy_harralander_noted_generic;
			pictureBox22.Tag = "Varies; Grimy harralander";
			pictureBox23.BackgroundImage = Resources.Grimy_ranarr_weed_noted_generic;
			pictureBox23.Tag = "Varies; Grimy ranarr weed";
			pictureBox24.BackgroundImage = Resources.Grimy_avantoe_noted_generic;
			pictureBox24.Tag = "Varies; Grimy avantoe";
			pictureBox25.BackgroundImage = Resources.Grimy_cadantine_noted_generic;
			pictureBox25.Tag = "Varies; Grimy cadantine";
			pictureBox26.BackgroundImage = Resources.Grimy_torstol_noted_generic;
			pictureBox26.Tag = "Varies; Grimy torstol";
			pictureBox27.BackgroundImage = Resources.Tarromin_seed_1;
			pictureBox27.Tag = "Varies; Tarromin seed";
			pictureBox28.BackgroundImage = Resources.Harralander_seed_1;
			pictureBox28.Tag = "Varies; Harralander seed";
			pictureBox29.BackgroundImage = Resources.Toadflax_seed_1;
			pictureBox29.Tag = "Varies; Toadflax seed";
			pictureBox30.BackgroundImage = Resources.Ranarr_seed_1;
			pictureBox30.Tag = "Varies; Ranarr seed";
			pictureBox31.BackgroundImage = Resources.Snapdragon_seed_1;
			pictureBox31.Tag = "Varies; Snapdragon seed";
			pictureBox32.BackgroundImage = Resources.Watermelon_seed_1;
			pictureBox32.Tag = "Varies; Watermelon seed";
			pictureBox33.BackgroundImage = Resources.Banana_tree_seed_1;
			pictureBox33.Tag = "Varies; Banana tree seed";
			pictureBox34.BackgroundImage = Resources.Acorn_1;
			pictureBox34.Tag = "Acorn x 1";
			pictureBox35.BackgroundImage = Resources.Willow_seed_1;
			pictureBox35.Tag = "Varies; Willow seed";
			pictureBox36.BackgroundImage = Resources.Maple_seed_1;
			pictureBox36.Tag = "Varies; Maple seed";
			pictureBox37.BackgroundImage = Resources.Yew_seed_1;
			pictureBox37.Tag = "Varies; Yew seed";
			pictureBox38.BackgroundImage = Resources.Magic_seed_1;
			pictureBox38.Tag = "Magic seed x 1";
			pictureBox39.BackgroundImage = Resources.Spirit_seed_1;
			pictureBox39.Tag = "Spirit seed x 1";
			pictureBox40.BackgroundImage = Resources.Raw_anchovies_noted_generic;
			pictureBox40.Tag = "Varies; Raw anchovies";
			pictureBox41.BackgroundImage = Resources.Raw_trout_noted_generic;
			pictureBox41.Tag = "Varies; Raw trout";
			pictureBox42.BackgroundImage = Resources.Raw_salmon_noted_generic;
			pictureBox42.Tag = "Varies; Raw salmon";
			pictureBox43.BackgroundImage = Resources.Raw_lobster_noted_generic;
			pictureBox43.Tag = "Varies; Raw lobster";
			pictureBox44.BackgroundImage = Resources.Raw_tuna_noted_generic;
			pictureBox44.Tag = "Varies; Raw tuna";
			pictureBox45.BackgroundImage = Resources.Raw_swordfish_noted_generic;
			pictureBox45.Tag = "Varies; Raw swordfish";
			pictureBox46.BackgroundImage = Resources.Raw_shark_noted_generic;
			pictureBox46.Tag = "Varies; Raw shark";
			pictureBox47.BackgroundImage = Resources.Saltpetre_noted_generic;
			pictureBox47.Tag = "Varies; Saltpetre";
			pictureBox48.BackgroundImage = Resources.Limestone_noted_generic;
			pictureBox48.Tag = "Varies; Limestone";
			pictureBox49.BackgroundImage = Resources.Dynamite_noted_generic;
			pictureBox49.Tag = "Varies; Dynamite";
			pictureBox50.BackgroundImage = Resources.Coins_1000;
			pictureBox50.Tag = "Varies; Coins";
			pictureBox51.BackgroundImage = Resources.Burnt_page;
			pictureBox51.Tag = "Varies; Burnt page";
			pictureBox52.BackgroundImage = Resources.Bruma_torch;
			pictureBox52.Tag = "Bruma torch x 1";
			pictureBox53.BackgroundImage = Resources.Pyromancer_hood;
			pictureBox53.Tag = "Pyromancer hood x 1";
			pictureBox54.BackgroundImage = Resources.Pyromancer_garb;
			pictureBox54.Tag = "Pyromancer garb x 1";
			pictureBox55.BackgroundImage = Resources.Pyromancer_robe;
			pictureBox55.Tag = "Pyromancer robe x 1";
			pictureBox56.BackgroundImage = Resources.Pyromancer_boots;
			pictureBox56.Tag = "Pyromancer boots x 1";
			pictureBox57.BackgroundImage = Resources.Warm_gloves;
			pictureBox57.Tag = "Warm gloves x 1";
			pictureBox58.BackgroundImage = Resources.Tome_of_fire__empty_;
			pictureBox58.Tag = "Tome of fire (empty) x 1";
			pictureBox59.BackgroundImage = Resources.Phoenix;
			pictureBox59.Tag = "Phoenix x 1";
			pictureBox60.BackgroundImage = Resources.RDT;
			pictureBox60.Tag = "RDT";
			setNPictureBoxesToVisible(60);
			setNPictureBoxesToEnabled(60);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}
		private void zulrahToolStripMenuItem_Click(object sender, EventArgs e) {
			lastBossViewed = getCurrentBoss();
			labelCurrentLogFor.Text = "Current log for: " + zulrahToolStripMenuItem.Text;
			pictureBox1.BackgroundImage = Resources.Pure_essence_noted_1500;
			pictureBox1.Tag = "Pure essence x 1500";
			pictureBox2.BackgroundImage = Resources.Law_rune_200;
			pictureBox2.Tag = "Law rune x 200";
			pictureBox3.BackgroundImage = Resources.Chaos_rune_500;
			pictureBox3.Tag = "Chaos rune x 500";
			pictureBox4.BackgroundImage = Resources.Death_rune_300;
			pictureBox4.Tag = "Death rune x 300";
			pictureBox5.BackgroundImage = Resources.Toadflax_noted_25;
			pictureBox5.Tag = "Toadflax x 25";
			pictureBox6.BackgroundImage = Resources.Snapdragon_noted_10;
			pictureBox6.Tag = "Snapdragon x 10";
			pictureBox7.BackgroundImage = Resources.Dwarf_weed_noted_30;
			pictureBox7.Tag = "Dwarf weed x 30";
			pictureBox8.BackgroundImage = Resources.Torstol_noted_10;
			pictureBox8.Tag = "Torstol x 10";
			pictureBox9.BackgroundImage = Resources.Toadflax_seed_2;
			pictureBox9.Tag = "Toadflax seed x 2";
			pictureBox10.BackgroundImage = Resources.Snapdragon_seed_1;
			pictureBox10.Tag = "Snapdragon seed x 1";
			pictureBox11.BackgroundImage = Resources.Dwarf_weed_seed_2;
			pictureBox11.Tag = "Dwarf weed seed x 2";
			pictureBox12.BackgroundImage = Resources.Torstol_seed_1;
			pictureBox12.Tag = "Torstol seed x 1";
			pictureBox13.BackgroundImage = Resources.Papaya_tree_seed_3;
			pictureBox13.Tag = "Papaya tree seed x 3";
			pictureBox14.BackgroundImage = Resources.Palm_tree_seed_1;
			pictureBox14.Tag = "Palm tree seed x 1";
			pictureBox15.BackgroundImage = Resources.Magic_seed_1;
			pictureBox15.Tag = "Magic seed x 1";
			pictureBox16.BackgroundImage = Resources.Calquat_tree_seed_2;
			pictureBox16.Tag = "Calquat seed x 2";
			pictureBox17.BackgroundImage = Resources.Spirit_seed_1;
			pictureBox17.Tag = "Spirit seed x 1";
			pictureBox18.BackgroundImage = Resources.Crystal_seed;
			pictureBox18.Tag = "Crystal seed x 1";
			pictureBox19.BackgroundImage = Resources.Flax_noted_1000;
			pictureBox19.Tag = "Flax x 1000";
			pictureBox20.BackgroundImage = Resources.Snakeskin_noted_35;
			pictureBox20.Tag = "Snakeskin x 35";
			pictureBox21.BackgroundImage = Resources.Dragon_bolt_tips_12;
			pictureBox21.Tag = "Dragon bolt tips x 12";
			pictureBox22.BackgroundImage = Resources.Yew_logs_noted_35;
			pictureBox22.Tag = "Yew logs x 35";
			pictureBox23.BackgroundImage = Resources.Coal_noted_200;
			pictureBox23.Tag = "Coal x 200";
			pictureBox24.BackgroundImage = Resources.Runite_ore_noted_2;
			pictureBox24.Tag = "Runite ore x 2";
			pictureBox25.BackgroundImage = Resources.Adamantite_bar_noted_20;
			pictureBox25.Tag = "Adamantite bar x 20";
			pictureBox26.BackgroundImage = Resources.Mahogany_logs_noted_50;
			pictureBox26.Tag = "Mahogany logs x 50";
			pictureBox27.BackgroundImage = Resources.Dragon_bones_noted_12;
			pictureBox27.Tag = "Dragon bones x 12";
			pictureBox28.BackgroundImage = Resources.Coconut_noted_20;
			pictureBox28.Tag = "Coconut x 20";
			pictureBox29.BackgroundImage = Resources.Grapes_noted_250;
			pictureBox29.Tag = "Grapes x 250";
			pictureBox30.BackgroundImage = Resources.Zul_andra_teleport_4;
			pictureBox30.Tag = "Zul-andra teleport x 4";
			pictureBox31.BackgroundImage = Resources.Zulrah_s_scales_500;
			pictureBox31.Tag = "Zulrah's scales x 500";
			pictureBox32.BackgroundImage = Resources.Battlestaff_noted_10;
			pictureBox32.Tag = "Battlestaff x 10";
			pictureBox33.BackgroundImage = Resources.Antidote____4__noted_10;
			pictureBox33.Tag = "Antidote++ (4) x 10";
			pictureBox34.BackgroundImage = Resources.Manta_ray_noted_35;
			pictureBox34.Tag = "Manta ray x 35";
			pictureBox35.BackgroundImage = Resources.Swamp_tar_1000;
			pictureBox35.Tag = "Swamp tar x 1000";
			pictureBox36.BackgroundImage = Resources.Crushed_nest_noted_10;
			pictureBox36.Tag = "Crushed nest x 10";
			pictureBox37.BackgroundImage = Resources.Serpentine_visage;
			pictureBox37.Tag = "Serpentine visage x 1";
			pictureBox38.BackgroundImage = Resources.Magic_fang;
			pictureBox38.Tag = "Magic fang x 1";
			pictureBox39.BackgroundImage = Resources.Tanzanite_fang;
			pictureBox39.Tag = "Tanzanite fang x 1";
			pictureBox40.BackgroundImage = Resources.Uncut_onyx;
			pictureBox40.Tag = "Uncut onyx x 1";
			pictureBox41.BackgroundImage = Resources.Dragon_med_helm;
			pictureBox41.Tag = "Dragon med helm x 1";
			pictureBox42.BackgroundImage = Resources.Dragon_halberd;
			pictureBox42.Tag = "Dragon halberd x 1";
			pictureBox43.BackgroundImage = Resources.Elite_clue_scroll;
			pictureBox43.Tag = "Elite clue scroll x 1";
			pictureBox44.BackgroundImage = Resources.Tanzanite_mutagen;
			pictureBox44.Tag = "Tanzanite mutagen x 1";
			pictureBox45.BackgroundImage = Resources.Magma_mutagen;
			pictureBox45.Tag = "Magma mutagen x 1";
			pictureBox46.BackgroundImage = Resources.Jar_of_swamp;
			pictureBox46.Tag = "Jar of swamp x 1";
			pictureBox47.BackgroundImage = Resources.Pet_snakeling;
			pictureBox47.Tag = "Pet snakeling x 1";
			pictureBox48.BackgroundImage = Resources.RDT;
			pictureBox48.Tag = "RDT";
			setNPictureBoxesToVisible(48);
			setNPictureBoxesToEnabled(48);
			removeAllItemQuantityOverlays();
			resetItemDropListBox(lastBossViewed);
			resetAllPictureBoxBackgroundColor();
			updateSidebarWindow();
		}

		private void pictureBoxDagannothPrime_Click(object sender, EventArgs e) {
			pictureBoxDagannothPrime.Click += pictureBoxDagannothPrime_Click;
			setSelectedDagannothKing("Dagannoth Prime");
			dagannothKingsToolStripMenuItem.PerformClick();
			highlightPictureBox(pictureBoxDagannothPrime);
		}
		private void pictureBoxDagannothRex_Click(object sender, EventArgs e) {
			pictureBoxDagannothRex.Click += pictureBoxDagannothRex_Click;
			setSelectedDagannothKing("Dagannoth Rex");
			dagannothKingsToolStripMenuItem.PerformClick();
			highlightPictureBox(pictureBoxDagannothRex);
		}
		private void pictureBoxDagannothSupreme_Click(object sender, EventArgs e) {
			pictureBoxDagannothSupreme.Click += pictureBoxDagannothSupreme_Click;
			setSelectedDagannothKing("Dagannoth Supreme");
			dagannothKingsToolStripMenuItem.PerformClick();
			highlightPictureBox(pictureBoxDagannothSupreme);
		}
		private void pictureBoxDagannothPrimeLoot_Click(object sender, EventArgs e) {
			pictureBoxDagannothPrimeLoot.Click += pictureBoxDagannothPrimeLoot_Click;
			setSelectedDagannothKingLoot("Dagannoth Prime");
			displayTotalLootFromBoss("Dagannoth Kings");
			highlightPictureBox(pictureBoxDagannothPrimeLoot);
		}
		private void pictureBoxDagannothRexLoot_Click(object sender, EventArgs e) {
			pictureBoxDagannothRexLoot.Click += pictureBoxDagannothRexLoot_Click;
			setSelectedDagannothKingLoot("Dagannoth Rex");
			displayTotalLootFromBoss("Dagannoth Kings");
			highlightPictureBox(pictureBoxDagannothRexLoot);
		}
		private void pictureBoxDagannothSupremeLoot_Click(object sender, EventArgs e) {
			pictureBoxDagannothSupremeLoot.Click += pictureBoxDagannothSupremeLoot_Click;
			setSelectedDagannothKingLoot("Dagannoth Supreme");
			displayTotalLootFromBoss("Dagannoth Kings");
			highlightPictureBox(pictureBoxDagannothSupremeLoot);
		}

		public void highlightPictureBox(PictureBox pb, Boolean resetAll = true) {
			pb.BackColor = highlightOrange;

			if (pb.Name == "pictureBoxDagannothPrime" ||
				pb.Name == "pictureBoxDagannothRex" ||
				pb.Name == "pictureBoxDagannothSupreme") {

				pictureBoxDagannothPrime.BackColor = Color.Transparent;
				pictureBoxDagannothRex.BackColor = Color.Transparent;
				pictureBoxDagannothSupreme.BackColor = Color.Transparent;
				pb.BackColor = Color.FromArgb(192, 255, 192);
			}
			else if (pb.Name == "pictureBoxDagannothPrimeLoot" ||
				pb.Name == "pictureBoxDagannothRexLoot" ||
				pb.Name == "pictureBoxDagannothSupremeLoot") {

				pictureBoxDagannothPrimeLoot.BackColor = Color.Transparent;
				pictureBoxDagannothRexLoot.BackColor = Color.Transparent;
				pictureBoxDagannothSupremeLoot.BackColor = Color.Transparent;
				pb.BackColor = Color.FromArgb(192, 255, 192);
			}
			else {

				// Only reset the pictures if it is set - this will not reset pictures when control is held
				if (resetAll) {
					resetAllPictureBoxBackgroundColor();
				}

				// Still change the picture box that was clicked
				pb.BackColor = highlightOrange;
			}
		}
		private List<PictureBox> getHighlightedPictureBox() {
			List<PictureBox> hpb = new List<PictureBox>();
			foreach (var pb in this.Controls.OfType<PictureBox>()) {
				if (pb.BackColor == highlightOrange) {
					hpb.Add(pb);
				}
			}
			return hpb;
		}
		public void pictureBox_Click(object sender, EventArgs e) {
			
			Boolean isControlPressed = false;
			Boolean firstItemVaries = false;
			PictureBox pbSender = (PictureBox)sender;
			
			if (Control.ModifierKeys == Keys.Control) { isControlPressed = true; }

			// Deselect item from sidebar
			if (activeSidebarWindow == "BossKillCounts") {
				listBoxSidebar.ClearSelected();
			}

			// PictureBoxes to switch between the dagannoth kings behave differently,
			// don't want to do anything besides show the new items
			if (pbSender.Name == "pictureBoxDagannothPrime" ||
				pbSender.Name == "pictureBoxDagannothRex" ||
				pbSender.Name == "pictureBoxDagannothSupreme") {
				return;
			}
			else if (pbSender.Name == "pictureBoxDagannothPrimeLoot" ||
				pbSender.Name == "pictureBoxDagannothRexLoot" ||
				pbSender.Name == "pictureBoxDagannothSupremeLoot") {
				return;
			}

			String unloggedItem = unloggedItem = pbSender.Tag.ToString();

			// Open new window and handle RDT drops
			if (pbSender.Tag.ToString() == "RDT") {

				// Check if RDT is already open, if not, open it
				if (!isFormOpen("RareDropTableForm")) {
					RareDropTableForm rdt = new RareDropTableForm();
					// TODO give specific coordinates to where the RDT window opens
					//rdt.StartPosition = FormStartPosition.CenterParent;
					rdt.Show(this);
				}
			}

			// Else so RDT and "Varies" case don't occur together - never will unless RDT is updated with varying item amounts
			// Handle items that drop varying amounts
			else if (pbSender.Tag.ToString().Length > 5 && pbSender.Tag.ToString().Substring(0, 6) == "Varies") {
				PictureBox pb = (PictureBox)sender;

				// Used to fix an issue where an item that varies being logged first would add 2 to the boss kc
				firstItemVaries = true;

				// Get the tag of the selected item
				String item = pb.Tag.ToString().Substring(pb.Tag.ToString().IndexOf(";") + 2);
				if (isControlPressed) {
					highlightPictureBox(pbSender, false);
				}
				else {
					highlightPictureBox(pbSender);
				}
				
				labelAddCustomDrop.Text = "Enter amount:";

				// Use the retrieved tag and prepare it for the user to just enter a number after
				String preparedItem = item + " x ";

				// Handle control clicking of these items that have to be manually entered
				// Handled by placing a comma at the beginning of the string so when the "add custom drop" button is clicked
				// it knows where to place the item based on if that comma is there or not
				if (isControlPressed) {
					preparedItem = ", " + preparedItem;
					firstItemVaries = false;
				}
				textboxCustomDrop.Text = preparedItem;

				// Focus on the text box, set the cursor to the end, and deselect the text
				this.ActiveControl = textboxCustomDrop;
				textboxCustomDrop.SelectionStart = textboxCustomDrop.Text.Length;
				textboxCustomDrop.SelectionLength = 0;
			}

			// Prevent logging 'RDT' when RDT form is opened
			else {

				// NEW
				// Before modifying the string, add it to our list of items
				listboxItemsList.Add(unloggedItem);

				if (isControlPressed) {
					
					// Highlight all pictureboxes that are control clicked along with original; resetAll = false
					highlightPictureBox(pbSender, false);

					// Make sure there is at least one item to add a control clicked item to since it will have to be removed
					if (listboxItemsList.Count <= 1) { return; }

					List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());

					// Get second to last item from the listboxItemsList (second to last since the ctrl-clicked item was already added)
					String lastItemInListBoxItemsList = loggedItems[loggedItems.Count - 1];

					// Remove last item (it was control clicked) and also remove the one before it, since two items are needed to ctrl click
					// non-ctrl-clicked item
					listboxItemsList.RemoveAt(listboxItemsList.Count - 2);
					// ctrl-clicked item
					listboxItemsList.RemoveAt(listboxItemsList.Count - 1);

					// Create the new string to add
					String concatenatedItems = lastItemInListBoxItemsList + ", " + unloggedItem;

					// Add the new item to the listboxItemsList
					listboxItemsList.Add(concatenatedItems);

					/* File writing */
					// Write new item to file
					

					// Need to remove the standalone item from the file and then re-add the concatenated items in
					loggedItems.RemoveAt(loggedItems.Count - 1);
					loggedItems = addItemToLoggedItems(loggedItems, concatenatedItems);
					writeLoggedItemsToFile(loggedItems, getCurrentBoss());
					/* End file writing */

				}
				else {
					// Change background color of PictureBox
					highlightPictureBox(pbSender);

					// Only to show correctly in the ListBox
					// given tag				produced string
					// --------------			-----------------
					// Rune battleaxe			1. Rune battleaxe
					prepareAndAddItemToListBox(unloggedItem);

					// Write new item to file
					List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());
					loggedItems = addItemToLoggedItems(loggedItems, unloggedItem);
					writeLoggedItemsToFile(loggedItems, getCurrentBoss());
					

				}
			}

			if (firstItemVaries == true) {
				// don't update the sidebar killcounts when this happens
				// the bug is that the kc gets updated when the picturebox is clicked, although a varying item
				// has not been entered yet, so the kc is being updated not only then, but also when the 
				// varying item is actually entered
				// this prevents this from happening
			}
			else {
				updateSidebarBossKillcounts("added", isControlPressed);
			}
			
			// Update the list box
			updateSidebarWindow();
			updateListBox();
		}

		private void updateSidebarWindow() {

			switch (activeSidebarWindow) {
				case "BossDropRates":
					showSidebarBossDroprates();
					break;
				case "BossUniques":
					showSidebarBossUniques();
					break;
				case "BossSplits":
					showSidebarBossSplits();
					break;
				case "BossKillCounts":
					showSidebarBossKillcounts();
					break;
				case "BossTimers":
					showSidebarBossTimers();
					break;
			}
		}
		
		private void updateListBox() {

			// Clear list box to prepare to rewrite all strings
			itemDropListBox.Items.Clear();

			// Write the updated list to the list box
			foreach (String item in listboxItemsList) {
				prepareAndAddItemToListBox(item);

			}

			if (itemDropListBox.Items.Count >= 1) {
				itemDropListBox.SetSelected(itemDropListBox.Items.Count - 1, true);
			}

		}

		private void prepareAndAddItemToListBox(String item, Boolean isMultipleItems = false) {

			// Get the number of lines that are not 'real' - only a continuation of the lines above
			int continuedItemLines = 0;
			foreach (String x in itemDropListBox.Items) {
				if (x.IndexOf(".") == -1) { continuedItemLines++; }
			}

			// Prepend with a "#. ", and don't increase the line number for the lines mentioned above
			String preparedString = item;
			if (isMultipleItems == false) {
				preparedString = (itemDropListBox.Items.Count + 1 - continuedItemLines) + ". " + item;
			}

			// Use length to make sure the string doesn't go outside the bounds of the list box
			int itemDropListBoxWidth = itemDropListBox.Width;

			// If the string is too large for one line in the list box
			if (TextRenderer.MeasureText(preparedString, itemDropListBox.Font).Width >= itemDropListBoxWidth) {

				// Get length of prepared string in pixels to compare with listbox width
				int preparedStringLength = TextRenderer.MeasureText(preparedString, itemDropListBox.Font).Width;

				List<String> brokenStrings = new List<String>();

				String lineSoFar = "";

				// Start from the left of the string, parsing each word. If the length of the word becomes larger
				// than the listbox can hold, it is place into a 'buffer' (List<String>) and the word is removed
				// from the prepared string. This continues until all of the string has been broken into
				// appropriate amounts where each line will now fit into the list box
				// - 20 to not cut off any text in the box
				while (preparedStringLength >= (itemDropListBoxWidth - 20)) {

					// Gets the first word (text before the space character) and adds it to the string so far
					int spaceIndex = preparedString.IndexOf(" ");
					lineSoFar += preparedString.Substring(0, spaceIndex + 1);

					// Removes the word from the leftover string
					preparedString = preparedString.Substring(spaceIndex + 1);

					// - 20 to keep strings from going out of bounds
					// If the line goes out of bounds, add it to the 'buffer' and move on
					if (TextRenderer.MeasureText(lineSoFar, itemDropListBox.Font).Width >= itemDropListBoxWidth - 20) {
						brokenStrings.Add(lineSoFar);
						lineSoFar = "";
					}
					// If we ran out of spaces, add the string in the current 'buffer' as well as the last word
					else if (spaceIndex == -1) {
						lineSoFar += preparedString;
						brokenStrings.Add(lineSoFar);
						break;
					}
				}

				// Add each of the lines now to the list box
				foreach (String s in brokenStrings) {
					itemDropListBox.Items.Add(s);
				}
			}
			else {
				// Add prepared string to list box
				itemDropListBox.Items.Add(preparedString);
			}
		}

		private Boolean isFormOpen(String f) {
			var k = Application.OpenForms.Cast<Form>().Select(g => g.Name);
			List<String> forms = k.ToList();
			if (forms.Contains(f)) {
				return true;
			}
			return false;
		}

		private void keyPressedHandler(object sender, KeyEventArgs e) {
			Console.Write("OldSchoolDropLogger.keyPressedHandler():");
			if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) && this.ActiveControl == textboxCustomDrop) {
				e.SuppressKeyPress = true;
				buttonAddCustomDrop.Click += buttonAddCustomDrop_Click;	
			}
		}

		void oldSchoolDropLoggerForm_KeyPress(object sender, KeyPressEventArgs e) {
			Console.Write("OldSchoolDropLogger.oldSchoolDropLoggerForm_KeyPress():");
		}

		private void buttonAddCustomDrop_Click(object sender, EventArgs e) {

			String unloggedItem = textboxCustomDrop.Text;

			if (unloggedItem == "" || unloggedItem == null) return;

			Console.WriteLine("OldSchoolDropLogger.buttonAddCustomDrop_Click():");

			// If there is a comma as the first character in the submitted string, we know that it was
			// control-clicked so it needs to be added to the previous item rather than a new line
			if (unloggedItem.IndexOf(",") == 0) {

				// Make sure there is at least one item to add a control clicked item to since it will have to be removed
				if (listboxItemsList.Count <= 0) { return; }

				List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());

				// Remove the item previously logged so we can replace it with itself + the control-clicked item
				listboxItemsList.RemoveAt(listboxItemsList.Count - 1);

				String concatenatedItems = "";

				concatenatedItems = loggedItems[loggedItems.Count - 1] + unloggedItem + " [v]";

				// Add the new item to the listboxItemsList
				listboxItemsList.Add(concatenatedItems);

				/* File writing */
				// Write new item to file

				// Need to remove the standalone item from the file and then re-add the concatenated items in
				loggedItems.RemoveAt(loggedItems.Count - 1);

				// Add [v] since it is a varied item - this will help in the future when dealing with showing total loot
				loggedItems = addItemToLoggedItems(loggedItems, (concatenatedItems));
				writeLoggedItemsToFile(loggedItems, getCurrentBoss());
				/* End file writing */
			}
			else {

				listboxItemsList.Add(unloggedItem + "");
				//listboxItemsList.Add(unloggedItem + " [v]");

				// Prepare the item and add to list box
				prepareAndAddItemToListBox(unloggedItem);

				// Write new item to file
				List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());

				// Add [v] since it is a varied item - this will help in the future when dealing with showing total loot
				loggedItems = addItemToLoggedItems(loggedItems, unloggedItem + " [v]");
				writeLoggedItemsToFile(loggedItems, getCurrentBoss());

				// Only update the killcounts if the drop logged a new kill (control clicking shouldn't increase the boss kills)
				updateSidebarBossKillcounts();
			}
			// Clear text box
			textboxCustomDrop.Text = "";

			updateListBox();
			
		}
		private void buttonUndoLastDrop_Click(object sender, EventArgs e) {

			// Can't remove items that aren't there
			if (itemDropListBox.Items.Count == 0) return;
			String lastItem = itemDropListBox.Items[itemDropListBox.Items.Count - 1].ToString();
			List<String> itemList = getLoggedItemsFromFile(getCurrentBoss());
			removeLastLoggedItem(itemList, lastItem);
			writeLoggedItemsToFile(itemList, getCurrentBoss());

			if (activeSidebarWindow == "") {

			}
			updateSidebarBossKillcounts("removed");
		}
		private void buttonSplitDrop_Click(object sender, EventArgs e) {
			if (!isFormOpen("SplitDropForm")) {
				SplitDropForm sdf = new SplitDropForm();
				// TODO give specific coordinates to where the sdf window opens
				//sdf.StartPosition = FormStartPosition.CenterParent;
				sdf.Show(this);
			}
		}

		// Unused
		private void saveTripToFile(String boss, String item) {
			int lineCount = 0;
			bool fileExists = false;
			String lastItem = itemDropListBox.Items[itemDropListBox.Items.Count].ToString();
			int periodIndex = lastItem.IndexOf(".") + 2;
			int itemStringLength = lastItem.Length - periodIndex;
			String trimmedItem = lastItem.Substring(periodIndex, itemStringLength);
			if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/logs/" + boss + ".txt")) {
				lineCount = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/logs/" + boss + ".txt").Count();
				fileExists = true;
			}
			else {
				lineCount = 1;
				fileExists = false;
			}

			if (fileExists == true) {
				File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "/logs/" + boss + ".txt", (lineCount + 1) + ". " + item + Environment.NewLine);
			}
			else {
				File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "/logs/" + boss + ".txt", (lineCount) + ". " + item + Environment.NewLine);
			}
		}

		// Adding logged items to files
		private List<String> getLoggedItemsFromFile(String boss) {

			List<String> loggedItems = new List<String>();

			// If a log file exists for the given boss, tries to get the log file for that boss
			// and convert it to a list, stripping any preceeding numbers, periods, and whitespace
			try {
				var logsFile = File.ReadAllLines(logsFilePath + "/" + boss + ".txt");
				List<String> loggedItemsList = new List<String>(logsFile);


				// Read in item						Produced item
				// -----------------				-------------
				// 5. Rune battleaxe				Rune Battleaxe
				for (int i = 0; i < loggedItemsList.Count; i++) {
					int periodIndexPlus2 = loggedItemsList[i].IndexOf(".") + 2; // + 2 to skip the period and the following space
					int longItemLength = loggedItemsList[i].Length;
					int shortItemLength = longItemLength - periodIndexPlus2;

					String item = loggedItemsList[i].Substring(periodIndexPlus2);
					loggedItems.Add(item);
				}
			}
			catch (FileNotFoundException) { }

			return loggedItems;
		}
		public List<String> addItemToLoggedItems(List<String> loggedItems, String item) {

			loggedItems.Add(item);
			return loggedItems;
		}
		public void removeLastLoggedItem(List<String> loggedItems, String itemToRemove) {

			listboxItemsList.RemoveAt(listboxItemsList.Count - 1);

			updateListBox();

			// Then remove the item from the list aka the file
			if (loggedItems.Count >= 1) {
				loggedItems.RemoveAt(loggedItems.Count - 1);
			}
		}
		public void writeLoggedItemsToFile(List<String> loggedItems, String boss) {

			TextWriter tw = new StreamWriter(logsFilePath + "/" + boss + ".txt", false);

			for (int i = 0; i < loggedItems.Count; i++) {
				tw.WriteLine((i + 1) + ". " + loggedItems[i]);
			}
			tw.Close();
		}

		private void resetAllPictureBoxBackgroundColor() {
			foreach (PictureBox p in allPictureBoxes) {
				p.BackColor = Color.Transparent;
			}
		}
		private void resetItemDropListBox(String lastBossSeen) {
			Console.WriteLine("now showing: " + getCurrentBoss());
			Console.WriteLine("last seen: " + lastBossViewed);
			if (getCurrentBoss() == lastBossViewed) {
				return;
			}

			listboxItemsList.Clear();
			itemDropListBox.Items.Clear();
		}

		private Boolean bossChanged() {
			if (getCurrentBoss() == lastBossViewed) {
				return false;
			}

			return true;
		}

		private void buttonToggleSidePanel_Click(object sender, EventArgs e) {
			if (panelSidePanel.Visible == true) {
				panelSidePanel.Visible = false;
				OldSchoolDropLogger.instance.Size = new Size(490, 434);
				buttonToggleSidePanel.Location = new Point(440, 30);
				buttonToggleSidePanel.Text = "❯❯";
			}
			else {
				panelSidePanel.Visible = true;
				OldSchoolDropLogger.instance.Size = new Size(700, 434);
				buttonToggleSidePanel.Location = new Point(650, 30);
				buttonToggleSidePanel.Text = "❮❮";
			}
		}

		private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e) {
			if (alwaysOnTopToolStripMenuItem.Checked == false) {
				this.TopMost = true;
				alwaysOnTopToolStripMenuItem.Checked = true;
			}
			else {
				this.TopMost = false;
				alwaysOnTopToolStripMenuItem.Checked = false;
			}
		}

		private void recalculateSidebar() {

		}

		/* Sidebar button clicks */
		private void listBoxSidebar_SelectedIndexChanged(object sender, EventArgs e) {

			if (activeSidebarWindow == "BossDropRates") return;
			if (activeSidebarWindow == "BossUniques") return;
			if (activeSidebarWindow == "BossSplits") return;

			if (listBoxSidebar.SelectedIndex == -1) {
				Console.WriteLine("listBoxSidebar_SelectedIndexChanged(): No item selected");
			}


			Console.WriteLine("OldSchoolDropLogger.listBoxSidebar_SelectedIndexChanged()");

			if (listBoxSidebar.SelectedItem == null) return;

			string bossClicked = listBoxSidebar.SelectedItem.ToString().Split(':')[0];

			//if (bossClicked == getCurrentBoss()) {
			//	return;
			//}

			resetAllPictureBoxBackgroundColor();

			sidebarViewingLootFromBoss = bossClicked;
			displayTotalLootFromBoss(bossClicked);
		}

		private void buttonSideBarBossKillcounts_Click(object sender, EventArgs e) {
			showSidebarBossKillcounts();
		}
		private void buttonSideBarDropRates_Click(object sender, EventArgs e) {
			showSidebarBossDroprates();
		}
		private void buttonSideBarTimers_Click(object sender, EventArgs e) {
			showSidebarBossTimers();
		}
		private void buttonSideBarUniqueDrops_Click(object sender, EventArgs e) {
			showSidebarBossUniques();
		}
		private void buttonSidebarItemSplits_Click(object sender, EventArgs e) {
			showSidebarBossSplits();
		}
		private void showSidebarBossTimers() {
			listBoxSidebar.Items.Clear();
			labelSidebarTitle.Text = "Timers";
			setSidebarBossTimersToVisible(true);
		}
		private void showSidebarBossDroprates() {
			// Don't keep repopulating the BossKillcounts table if the data is already displaying
			if (activeSidebarWindow == "BossDropRates" && (bossChanged() == false)) return;

			activeSidebarWindow = "BossDropRates";
			setSidebarBossTimersToVisible(false);
			labelSidebarTitle.Text = "Drop rates";

			Console.WriteLine("OldSchoolDropLogger.buttonSideBarBossDroprates_Click():");

			Dictionary<String, int> allDropsFromBoss = stats.getItemQuantitiesFromBoss(getCurrentBoss());

			if (allDropsFromBoss == null) {
				listBoxSidebar.Items.Clear();
				listBoxSidebar.Items.Add("");
				listBoxSidebar.Items.Add("No drops logged for " + getCurrentBoss());
				Console.WriteLine("No drops logged for boss " + getCurrentBoss());
				return;
			}

			double totalDrops = 0;

			// Calculate the number of total drops logged
			foreach (KeyValuePair<String, int> drop in allDropsFromBoss) {

				bool variableDrop = false;

				// Grab the quantity the item is dropped in, i.e.
				// Law rune x 200 -> get 200
				int len = drop.Key.ToString().Split(' ').Length;
				int qty = -1;
				int.TryParse(drop.Key.ToString().Split(' ')[len - 1], out qty);

				// Check if the drop contains a number, if it doesn't, the drop is variable ([v])
				if (!drop.Key.Any(char.IsDigit)) {
					variableDrop = true;
				}

				// Shouldn't ever hit this please
				if (qty == -1) {
					Console.WriteLine("================== ERROR: qty = -1 ==================");
				}

				// Calculate how many times the drop was actually dropped
				// i.e. if the total drop quantity was 1000, but the drop string is in 
				// increments of 200, we know that the numberOfTimesDropped = 5 since
				// 5 * 200 = 1000.
				int numberOfTimesDropped = 0;
				if (qty != 0) {
					numberOfTimesDropped = drop.Value / qty;

					// Update the total number of drops
					//totalDrops += numberOfTimesDropped;
				}
				else {
					// Since it's a variable drop we need to access the file and see how many
					// times it was logged in order to get the drop rate
					if (variableDrop) {
						List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());

						totalDrops = loggedItems.Count;

						//foreach (String s in loggedItems) {

						//	Console.WriteLine("checking " + drop.Key + " with " + s);
						//	if (s.Contains(drop.Key)) {
						//		if (s.Contains(',')) {
						//			totalDrops += 2;
						//		}
						//		else {
						//			totalDrops += 1;
						//		}
						//			// Update the total number of drops
						//			totalDrops += 1;
						//	}
						//}
					}
				}
			}

			// Since Zulrah drops two items at a time
			if (getCurrentBoss() == "Zulrah" || getCurrentBoss() == "Raids") {
				//totalDrops /= 2;
			}

			List<String> unsortedList = new List<String>();

			foreach (KeyValuePair<String, int> drop in allDropsFromBoss) {

				bool variableDrop = false;

				// Grab the quantity of the drop first, i.e.
				// Law rune x 200 -> get 200
				int len = drop.Key.ToString().Split(' ').Length;
				int qty = -1;
				int.TryParse(drop.Key.ToString().Split(' ')[len - 1], out qty);

				// Check if the drop contains a number, if it doesn't, the drop is variable ([v])
				if (!drop.Key.Any(char.IsDigit)) {
					variableDrop = true;
				}

				if (qty == -1) {
					Console.WriteLine("============= qty -1");
				}

				// Calculate how many times the drop was actually dropped
				int numberOfTimesDropped = 0;
				if (qty != 0) {
					numberOfTimesDropped = drop.Value / qty;
				}
				else {
					// Since it's a variable drop we need to access the file and see how many
					// times it was logged in order to get the drop rate
					if (variableDrop) {
						List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());

						totalDrops = loggedItems.Count;


						foreach (String s in loggedItems) {

							//	Console.WriteLine("checking " + drop.Key + " with " + s);
							if (s.Contains(drop.Key)) {

								numberOfTimesDropped += 1;

								//		if (s.Contains(',')) {
								//			totalDrops += 2;
								//		}
								//		else {
								//			totalDrops += 1;
								//		}
								//			// Update the total number of drops
								//			totalDrops += 1;
							}
						}
					}
				}

				double dec = Math.Round((double)numberOfTimesDropped / (double)totalDrops, 2);
				double reduced = Math.Round((double)numberOfTimesDropped / (double)totalDrops, 1);

				String item = "";

				// Prepare the string to show as a ratio, deal with drops of 0 quantity first
				if (numberOfTimesDropped == 0) {

					// non reduced
					//item = drop.Key + " – 0:" + totalDrops;

					// reduced
					//item = drop.Key + " – 0:" + reduced;

					// decimal:
					// Remove the x 1 from the end of the string
					item = drop.Key;
					int endOfDropIndex = item.IndexOf(" x ");
					if (endOfDropIndex > 0) {
						item = item.Substring(0, endOfDropIndex);
					}
					item = item + " – 0.00%";
				}
				else {

					// non reduced:
					//item = drop.Key + " – " + numberOfTimesDropped + ":" + totalDrops;

					// reduced
					//item = drop.Key + " – 1:" + reduced;

					// decimal:
					item = drop.Key;
					int endOfDropIndex = item.IndexOf(" x ");
					if (endOfDropIndex > 0) {
						item = item.Substring(0, endOfDropIndex);
					}
					item = item + " – " + dec + "% ";
				}

				if (item == "") {
					Console.WriteLine("============================= showSidebarBossDroprates() ERROR ========================");
				}

				unsortedList.Add(item);
			}

			listBoxSidebar.Items.Clear();

			unsortedList.Sort();

			// Add the sorted items
			foreach (String s in unsortedList) {
				listBoxSidebar.Items.Add(s);
			}

			isStatisticsInstantiated = true;
		}
		private void showSidebarBossKillcounts() {

			// Don't keep repopulating the BossKillcounts table if the data is already displaying
			if (activeSidebarWindow == "BossKillCounts") return;
			setSidebarBossTimersToVisible(false);
			labelSidebarTitle.Text = "Kill counts";
			activeSidebarWindow = "BossKillCounts";

			Console.WriteLine("OldSchoolDropLogger.buttonSideBarBossKillcounts_Click():");

			listBoxSidebar.Items.Clear();

			Dictionary<String, int> totalKillsPerBoss = stats.getTotalKillsLoggedPerBoss();

			// Loop through each boss and display the killcounts for each 
			foreach (KeyValuePair<String, int> boss in totalKillsPerBoss) {
				string bosskc = boss.Value.ToString();

				// Shorten killcounts if they get too big
				if (int.Parse(bosskc) >= 100000) bosskc = "100k+";

				listBoxSidebar.Items.Add(boss.Key + ": " + bosskc);
			}

			isStatisticsInstantiated = true;
		}
		private void showSidebarBossUniques() {
			//if (activeSidebarWindow == "BossUniques") return;
			setSidebarBossTimersToVisible(false);
			labelSidebarTitle.Text = "Unique drops";
			activeSidebarWindow = "BossUniques";

			Dictionary<String, int> allDropsFromBoss = stats.getItemQuantitiesFromBoss(getCurrentBoss());

			if (allDropsFromBoss == null) {
				listBoxSidebar.Items.Clear();
				listBoxSidebar.Items.Add("");
				listBoxSidebar.Items.Add("No drops logged for " + getCurrentBoss());
				Console.WriteLine("showSidebarBossUniques(): No drops logged for boss " + getCurrentBoss());
				return;
			}

			List<String> uniqueList = stats.getUniquesFromBoss(getCurrentBoss());

			Dictionary<String, int> uniqueAmounts = new Dictionary<string, int>();

			foreach (KeyValuePair<String, int> drop in allDropsFromBoss) {

				// Check if the current drop is a unique
				if (uniqueList.Contains(drop.Key)) {

					// Add unique and quantity to dict
					if (drop.Key == "Dragon thrownaxe x 100") {
						if (drop.Value > 0) {
							uniqueAmounts.Add(drop.Key, 1);
						}
						else {
							uniqueAmounts.Add(drop.Key, 0);
						}
					}
					else {
						uniqueAmounts.Add(drop.Key, drop.Value);
					}
				}
			}

			// Add total kills and drop rates to textbox
			listBoxSidebar.Items.Clear();

			// Get total number of uniques
			int uniquesCount = 0;
			foreach (KeyValuePair<String, int> unique in uniqueAmounts) {
				uniquesCount += unique.Value;
			}

			listBoxSidebar.Items.Add("Total uniques – " + uniquesCount);

			int totalBossKills = stats.getTotalKillsLoggedPerBoss()[getCurrentBoss()];
			listBoxSidebar.Items.Add("Total kills – " + totalBossKills);

			// Calculate unique drop ratedecimalVar.ToString ("0.##"); // returns "0"  when decimalVar == 0
			double uniqueDropRate = ((double) uniquesCount / (double) totalBossKills);
			String formattedDropRate = uniqueDropRate.ToString("0.00");
			listBoxSidebar.Items.Add("Unique drop rate – " + formattedDropRate + "%");

			// Line spacer
			listBoxSidebar.Items.Add("");

			uniqueList.Sort();

			// Add uniques to textbox
			foreach (String unique in uniqueList) {

				// Get unique count, if it exists
				if (uniqueAmounts.Keys.Contains(unique)) {

					// Remove the x 1 from the end of the string
					int endOfDropIndex = unique.IndexOf(" x ");
					String subUnique = unique.Substring(0, endOfDropIndex);

					listBoxSidebar.Items.Add(subUnique + " – " + uniqueAmounts[unique]);
				}
				else {
					listBoxSidebar.Items.Add(unique + " – 0");
				}
			}
		}
		private void showSidebarBossSplits() {

			//if (activeSidebarWindow == "BossSplits") return;
			setSidebarBossTimersToVisible(false);
			labelSidebarTitle.Text = "Split drops";
			activeSidebarWindow = "BossSplits";

			listBoxSidebar.Items.Clear();

			List<String> splits = getSplitsFromFile();

			int personalSplits = 0;
			int totalSplitAmount = 0;

			List<String> formattedList = new List<string>();

			int splitNumber = 0;
			foreach (String line in splits) {

				if (line.Substring(0, line.IndexOf(",")).Contains(getCurrentBoss())) {

					int commaIndex = line.IndexOf(",");

					// Raids [54 kc], Twisted buckler x 1 [sy=1]
					String precom = line.Substring(0, commaIndex);
					String postcom = line.Substring(commaIndex);

					// check if drop is in own name by checking if there is a 'sy' in the second part of the string
					// if there is, log the kc, otherwise nothing

					String kc = null;
					// drop is in our name
					if (postcom.Contains("[sy=")) {
						int kcBracketIndex1 = precom.IndexOf("[");
						int kcBracketIndex2 = precom.IndexOf("]");

						kc = precom.Substring(kcBracketIndex1 + 1, kcBracketIndex2 - kcBracketIndex1 - 3 /* to remove the bracket and the "kc" */);

						personalSplits++;
					}

					int splitBracketIndex1 = postcom.IndexOf("[");
					int splitBracketIndex2 = postcom.IndexOf("]");
					int xIndex = postcom.IndexOf(" x ");

					String splitAmount = postcom.Substring(splitBracketIndex1 + 4 /* 1 + 3 characters "sn=" */, splitBracketIndex2 - splitBracketIndex1 - 4 /* to make up for the + 4 from earlier*/);
					totalSplitAmount += int.Parse(splitAmount);

					//                          + 1 so the numbering of the items in the box starts at 1. instead of 0.
					String item = ((splitNumber + 1).ToString()) + ". " + postcom.Substring(2, xIndex - 2) + ", ";

					// Add in the split amount
					String formatted = item; 
					formatted += String.Format("{0:n0}", int.Parse(splitAmount)) + " gp";

					if (kc != null) {
						formatted += " (" + kc + " kc)";
					}

					formattedList.Add(formatted);

					splitNumber++;

				}
			}


			double avgSplitAmount = 0;

			if (splitNumber != 0) {
				avgSplitAmount = totalSplitAmount / splitNumber;
			}

			listBoxSidebar.Items.Add("Total splits – " + String.Format("{0:n0}", splitNumber));
			listBoxSidebar.Items.Add("Personal splits – " + String.Format("{0:n0}", personalSplits));
			listBoxSidebar.Items.Add("Total split value – " + String.Format("{0:n0}", totalSplitAmount) + " gp");
			listBoxSidebar.Items.Add("Avg split value – " + String.Format("{0:n0}", avgSplitAmount) + " gp");
			listBoxSidebar.Items.Add("");

			// Add all splits to the listbox
			foreach (String split in formattedList) {
				listBoxSidebar.Items.Add(split);
			}
		}
		private void updateSidebarBossKillcounts(String itemAddedOrRemoved = "added", Boolean ctrlPressed = false) {

			Console.WriteLine("updateSidebarBossKillCounts()");

			Console.WriteLine("pressed: " + ctrlPressed);

			int lineContainingBoss = -1;
			int index = -1;
			int kc = 0;

			for (int i = 0; i < listBoxSidebar.Items.Count; i++) {

				if (listBoxSidebar.Items[i].ToString().Contains(getCurrentBoss())) {

					lineContainingBoss = i;

					String entry = listBoxSidebar.Items[i].ToString();

					String[] entryArr = entry.Split(' ');

					int.TryParse(entry, out index);

					int updateKillcount = 0;
					int.TryParse(entryArr[entryArr.Length - 1], out updateKillcount);

					if (itemAddedOrRemoved == "added") {
						if (ctrlPressed == false) {
							kc = updateKillcount + 1;
						}
						else {
							kc = updateKillcount;
						}
					}
					else {
						kc = updateKillcount - 1;
					}

					break;
				}
			}

			if (index != -1) {
				listBoxSidebar.Items[lineContainingBoss] = getCurrentBoss() + ": " + kc;
			}
		}
		

		private void displayTotalLootFromBoss(string boss) {

			Console.WriteLine("OldSchoolDropLogger.displayTotalLootFromBoss()");

			iqc = new ItemQuantityCreator();

			// Make sure all drops are up to date so when we display them it's the correct amount
			stats.setTotalDropsFromAllBosses();

			Dictionary<String, int> allItemQuantitiesFromCurrentBoss = stats.getItemQuantitiesFromBoss(boss);

			switch (boss) {
				case "Armadyl":
					pictureBox1.BackgroundImage = Resources.Rune_crossbow;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune crossbow x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_sword;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune sword x 1"]);
					pictureBox3.BackgroundImage = Resources.Runite_bolts_5;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bolts"]);
					pictureBox4.BackgroundImage = Resources.Rune_arrow_5;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune arrow"]);
					pictureBox5.BackgroundImage = Resources.Dragon_bolts__e__5;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bolts (e)"]);
					pictureBox6.BackgroundImage = Resources.Mind_rune;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mind rune"]);
					pictureBox7.BackgroundImage = Resources.Coins_10000;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox8.BackgroundImage = Resources.Dwarf_weed_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dwarf weed"]);
					pictureBox9.BackgroundImage = Resources.Dwarf_weed_seed_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dwarf weed seed x 3"]);
					pictureBox10.BackgroundImage = Resources.Yew_seed_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew seed x 1"]);
					pictureBox11.BackgroundImage = Resources.Ranging_potion__3_;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranging potion (3) x 3"]);
					pictureBox12.BackgroundImage = Resources.Super_defence__3_;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super defence (3) x 3"]);
					pictureBox13.BackgroundImage = Resources.Crystal_key;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Crystal key x 1"]);
					pictureBox14.BackgroundImage = Resources.Black_d_hide_body;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Black d'hide body x 1"]);
					pictureBox15.BackgroundImage = Resources.Long_bone;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Long bone x 1"]);
					pictureBox16.BackgroundImage = Resources.Curved_bone;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Curved bone x 1"]);
					pictureBox17.BackgroundImage = Resources.Godsword_shard_1;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 1 x 1"]);
					pictureBox18.BackgroundImage = Resources.Godsword_shard_2;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 2 x 1"]);
					pictureBox19.BackgroundImage = Resources.Godsword_shard_3;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 3 x 1"]);
					pictureBox20.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox21.BackgroundImage = Resources.Armadyl_helmet;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Armadyl helmet x 1"]);
					pictureBox22.BackgroundImage = Resources.Armadyl_chestplate;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Armadyl chestplate x 1"]);
					pictureBox23.BackgroundImage = Resources.Armadyl_chainskirt;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Armadyl chainskirt x 1"]);
					pictureBox24.BackgroundImage = Resources.Armadyl_hilt;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Armadyl hilt x 1"]);
					pictureBox25.BackgroundImage = Resources.Pet_kree_arra;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet kree'arra x 1"]);
					pictureBox26.BackgroundImage = Resources.RDT;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);
					setNPictureBoxesToVisible(26);
					setNPictureBoxesToDisabled(26);
					break;

				case "Bandos":
					pictureBox1.BackgroundImage = Resources.Rune_2h_sword;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune 2h sword x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_pickaxe;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune pickaxe x 1"]);
					pictureBox3.BackgroundImage = Resources.Rune_longsword;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune longsword x 1"]);
					pictureBox4.BackgroundImage = Resources.Rune_sword;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune sword x 1"]);
					pictureBox5.BackgroundImage = Resources.Rune_platebody;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune platebody x 1"]);
					pictureBox6.BackgroundImage = Resources.Nature_rune;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Nature rune"]);
					pictureBox7.BackgroundImage = Resources.Adamantite_ore_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite ore"]);
					pictureBox8.BackgroundImage = Resources.Coal_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal"]);
					pictureBox9.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs"]);
					pictureBox10.BackgroundImage = Resources.Snapdragon_seed_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon seed x 1"]);
					pictureBox11.BackgroundImage = Resources.Grimy_snapdragon_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy snapdragon x 3"]);
					pictureBox12.BackgroundImage = Resources.Super_restore__4_;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (4) x 3"]);
					pictureBox13.BackgroundImage = Resources.Coins_10000;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox14.BackgroundImage = Resources.Long_bone;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Long bone x 1"]);
					pictureBox15.BackgroundImage = Resources.Curved_bone;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Curved bone x 1"]);
					pictureBox16.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox17.BackgroundImage = Resources.Godsword_shard_1;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 1 x 1"]);
					pictureBox18.BackgroundImage = Resources.Godsword_shard_2;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 2 x 1"]);
					pictureBox19.BackgroundImage = Resources.Godsword_shard_3;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 3 x 1"]);
					pictureBox20.BackgroundImage = Resources.Bandos_chestplate;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bandos chestplate x 1"]);
					pictureBox21.BackgroundImage = Resources.Bandos_tassets;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bandos tassets x 1"]);
					pictureBox22.BackgroundImage = Resources.Bandos_boots;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bandos boots x 1"]);
					pictureBox23.BackgroundImage = Resources.Bandos_hilt;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bandos hilt x 1"]);
					pictureBox24.BackgroundImage = Resources.Pet_general_graardor;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet general graardor x 1"]);
					pictureBox25.BackgroundImage = Resources.RDT;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(25);
					setNPictureBoxesToDisabled(25);
					break;

				case "Saradomin":
					pictureBox1.BackgroundImage = Resources.Rune_dart;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune dart"]);
					pictureBox2.BackgroundImage = Resources.Rune_sword;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune sword x 1"]);
					pictureBox3.BackgroundImage = Resources.Adamant_platebody;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant platebody x 1"]);
					pictureBox4.BackgroundImage = Resources.Rune_plateskirt;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune plateskirt x 1"]);
					pictureBox5.BackgroundImage = Resources.Rune_kiteshield;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune kiteshield x 1"]);
					pictureBox6.BackgroundImage = Resources.Law_rune;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Law rune"]);
					pictureBox7.BackgroundImage = Resources.Ranarr_seed_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranarr seed x 2"]);
					pictureBox8.BackgroundImage = Resources.Magic_seed_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 1"]);
					pictureBox9.BackgroundImage = Resources.Diamond_noted_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Diamond x 6"]);
					pictureBox10.BackgroundImage = Resources.Grimy_ranarr_weed;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed x 5"]);
					pictureBox11.BackgroundImage = Resources.Prayer_potion__4_;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prayer potion (4) x 3"]);
					pictureBox12.BackgroundImage = Resources.Saradomin_brew__3_;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saradomin brew (3) x 3"]);
					pictureBox13.BackgroundImage = Resources.Super_restore__4_;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (4) x 3"]);
					pictureBox14.BackgroundImage = Resources.Super_defence__4_;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super defence (4) x 3"]);
					pictureBox15.BackgroundImage = Resources.Magic_potion__3_;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic potion (3) x 3"]);
					pictureBox16.BackgroundImage = Resources.Coins_10000;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox17.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox18.BackgroundImage = Resources.Godsword_shard_1;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 1 x 1"]);
					pictureBox19.BackgroundImage = Resources.Godsword_shard_2;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 2 x 1"]);
					pictureBox20.BackgroundImage = Resources.Godsword_shard_3;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 3 x 1"]);
					pictureBox21.BackgroundImage = Resources.Saradomin_s_light;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saradomin's light x 1"]);
					pictureBox22.BackgroundImage = Resources.Saradomin_sword;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saradomin sword x 1"]);
					pictureBox23.BackgroundImage = Resources.Armadyl_crossbow;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Armadyl crossbow x 1"]);
					pictureBox24.BackgroundImage = Resources.Saradomin_hilt;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saradomin hilt x 1"]);
					pictureBox25.BackgroundImage = Resources.Pet_zilyana;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet zilyana x 1"]);
					pictureBox26.BackgroundImage = Resources.RDT;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(26);
					setNPictureBoxesToDisabled(26);
					break;

				case "Zamorak":
					pictureBox1.BackgroundImage = Resources.Rune_sword;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune sword x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_scimitar;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune scimitar x 1"]);
					pictureBox3.BackgroundImage = Resources.Dragon_dagger__p___;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon dagger (p++) x 1"]);
					pictureBox4.BackgroundImage = Resources.Adamant_arrow_5;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant arrows"]);
					pictureBox5.BackgroundImage = Resources.Adamant_platebody;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant platebody x 1"]);
					pictureBox6.BackgroundImage = Resources.Rune_platelegs;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune platelegs x 1"]);
					pictureBox7.BackgroundImage = Resources.Lantadyme_seed_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Lantadyme seed x 3"]);
					pictureBox8.BackgroundImage = Resources.Grimy_lantadyme_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy lantadyme"]);
					pictureBox9.BackgroundImage = Resources.Super_attack__3_;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super attack (3) x 3"]);
					pictureBox10.BackgroundImage = Resources.Super_strength__3_;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super strength (3) x 3"]);
					pictureBox11.BackgroundImage = Resources.Super_restore__3_;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (3) x 3"]);
					pictureBox12.BackgroundImage = Resources.Zamorak_brew__3_;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Zamorak brew (3) x 3"]);
					pictureBox13.BackgroundImage = Resources.Death_rune;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune"]);
					pictureBox14.BackgroundImage = Resources.Blood_rune;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune"]);
					pictureBox15.BackgroundImage = Resources.Coins_10000;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox16.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox17.BackgroundImage = Resources.Godsword_shard_1;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 1 x 1"]);
					pictureBox18.BackgroundImage = Resources.Godsword_shard_2;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 2 x 1"]);
					pictureBox19.BackgroundImage = Resources.Godsword_shard_3;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Godsword shard 3 x 1"]);
					pictureBox20.BackgroundImage = Resources.Steam_battlestaff;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Steam battlestaff x 1"]);
					pictureBox21.BackgroundImage = Resources.Staff_of_the_dead;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Staff of the dead x 1"]);
					pictureBox22.BackgroundImage = Resources.Zamorakian_spear;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Zamorakian spear x 1"]);
					pictureBox23.BackgroundImage = Resources.Zamorak_hilt;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Zamorak hilt x 1"]);
					pictureBox24.BackgroundImage = Resources.Pet_k_ril_tsutsaroth;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet k'ril tsutsaroth x 1"]);
					pictureBox25.BackgroundImage = Resources.RDT;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(25);
					setNPictureBoxesToDisabled(25);
					break;

				case "Callisto":
					pictureBox1.BackgroundImage = Resources.Rune_pickaxe;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune pickaxe x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_2h_sword;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune 2h sword x 1"]);
					pictureBox3.BackgroundImage = Resources.Soul_rune;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Soul rune x 250"]);
					pictureBox4.BackgroundImage = Resources.Death_rune;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 300"]);
					pictureBox5.BackgroundImage = Resources.Chaos_rune;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune x 400"]);
					pictureBox6.BackgroundImage = Resources.Blood_rune;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 200"]);
					pictureBox7.BackgroundImage = Resources.Mahogany_logs_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mahogany logs x 400"]);
					pictureBox8.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs x 100"]);
					pictureBox9.BackgroundImage = Resources.Ranarr_seed_5;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranarr seed x 5"]);
					pictureBox10.BackgroundImage = Resources.Snapdragon_seed_3;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon seed x 3"]);
					pictureBox11.BackgroundImage = Resources.Palm_tree_seed_1;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Palm tree seed x 1"]);
					pictureBox12.BackgroundImage = Resources.Yew_seed_1;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew seed x 1"]);
					pictureBox13.BackgroundImage = Resources.Magic_seed_1;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 1"]);
					pictureBox14.BackgroundImage = Resources.Grimy_toadflax_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy toadflax x 100"]);
					pictureBox15.BackgroundImage = Resources.Dark_fishing_bait_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark fishing bait x 375"]);
					pictureBox16.BackgroundImage = Resources.Dark_crab;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark crab x 8"]);
					pictureBox17.BackgroundImage = Resources.Super_restore__4_;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (4) x 3"]);
					pictureBox18.BackgroundImage = Resources.Mysterious_emblem;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mysterious emblem x 1"]);
					pictureBox19.BackgroundImage = Resources.Limpwurt_root_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Limpwurt root x 50"]);
					pictureBox20.BackgroundImage = Resources.Coconut_noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coconut x 60"]);
					pictureBox21.BackgroundImage = Resources.Crushed_nest_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Crushed birds nest x 75"]);
					pictureBox22.BackgroundImage = Resources.Supercompost_noted_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Supercompost x 100"]);
					pictureBox23.BackgroundImage = Resources.Cannonball_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cannonball x 250"]);
					pictureBox24.BackgroundImage = Resources.Red_dragonhide_noted_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Red dragonhide x 75"]);
					pictureBox25.BackgroundImage = Resources.Uncut_ruby_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut ruby x 20"]);
					pictureBox26.BackgroundImage = Resources.Uncut_diamond_noted_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond x 10"]);
					pictureBox27.BackgroundImage = Resources.Uncut_dragonstone;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut dragonstone x 1"]);
					pictureBox28.BackgroundImage = Resources.Coins_10000;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox29.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox30.BackgroundImage = Resources.Dragon_pickaxe;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon pickaxe x 1"]);
					pictureBox31.BackgroundImage = Resources.Dragon_2h_sword;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon 2h sword x 1"]);
					pictureBox32.BackgroundImage = Resources.Tyrannical_ring;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tyrannical ring x 1"]);
					pictureBox33.BackgroundImage = Resources.Callisto_cub;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Callisto cub x 1"]);
					pictureBox34.BackgroundImage = Resources.RDT;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(34);
					setNPictureBoxesToDisabled(34);
					break;

				case "Chaos Elemental":
					pictureBox1.BackgroundImage = Resources.Mithril_dart_generic;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril dart x 300"]);
					pictureBox2.BackgroundImage = Resources.Rune_arrow_5;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune arrow x 150"]);
					pictureBox3.BackgroundImage = Resources.Chaos_rune;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune x 250"]);
					pictureBox4.BackgroundImage = Resources.Air_rune;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air rune x 500"]);
					pictureBox5.BackgroundImage = Resources.Death_rune;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 125"]);
					pictureBox6.BackgroundImage = Resources.Blood_rune;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 75"]);
					pictureBox7.BackgroundImage = Resources.Anchovy_pizza;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Anchovy pizza x 3"]);
					pictureBox8.BackgroundImage = Resources.Tuna;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tuna x 5"]);
					pictureBox9.BackgroundImage = Resources.Grimy_guam_leaf;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy guam leaf"]);
					pictureBox10.BackgroundImage = Resources.Grimy_marrentill;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy marrentil"]);
					pictureBox11.BackgroundImage = Resources.Grimy_tarromin;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy tarromin"]);
					pictureBox12.BackgroundImage = Resources.Grimy_harralander;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy harralander"]);
					pictureBox13.BackgroundImage = Resources.Grimy_ranarr_weed;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed"]);
					pictureBox14.BackgroundImage = Resources.Grimy_irit_leaf;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy irit leaf"]);
					pictureBox15.BackgroundImage = Resources.Grimy_avantoe;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy avantoe"]);
					pictureBox16.BackgroundImage = Resources.Grimy_kwuarm;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy kwuarm"]);
					pictureBox17.BackgroundImage = Resources.Grimy_cadantine;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy snapdragon"]);
					pictureBox18.BackgroundImage = Resources.Grimy_lantadyme;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy lantadyme"]);
					pictureBox19.BackgroundImage = Resources.Grimy_dwarf_weed;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy dwarf weed"]);
					pictureBox20.BackgroundImage = Resources.Super_attack__4_;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super attack (4) x 1"]);
					pictureBox21.BackgroundImage = Resources.Super_strength__4_;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super strength (4) x 1"]);
					pictureBox22.BackgroundImage = Resources.Super_defence__4_;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super defence (4) x 1"]);
					pictureBox23.BackgroundImage = Resources.Weapon_poison_____;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Weapon poison (++) x 1"]);
					pictureBox24.BackgroundImage = Resources.Antidote____4__noted_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Antidote++ (4) x 1"]);
					pictureBox25.BackgroundImage = Resources.Strange_fruit_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Strange fruit x 10"]);
					pictureBox26.BackgroundImage = Resources.Bones;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bones x 4"]);
					pictureBox27.BackgroundImage = Resources.Bat_bones;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bat bones x 5"]);
					pictureBox28.BackgroundImage = Resources.Big_bones;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Big bones x 3"]);
					pictureBox29.BackgroundImage = Resources.Babydragon_bones;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Babydragon bones x 2"]);
					pictureBox30.BackgroundImage = Resources.Dragon_bones;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bones x 1"]);
					pictureBox31.BackgroundImage = Resources.Coins_10000;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins x 7500"]);
					pictureBox32.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox33.BackgroundImage = Resources.Pet_chaos_elemental;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet chaos elemental x 1"]);
					pictureBox34.BackgroundImage = Resources.RDT;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(34);
					setNPictureBoxesToDisabled(34);
					break;

				case "Chaos Fanatic":
					pictureBox1.BackgroundImage = Resources.Fire_rune;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fire rune x 250"]);
					pictureBox2.BackgroundImage = Resources.Smoke_rune;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Smoke rune x 30"]);
					pictureBox3.BackgroundImage = Resources.Chaos_rune;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune x 175"]);
					pictureBox4.BackgroundImage = Resources.Blood_rune;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 50"]);
					pictureBox5.BackgroundImage = Resources.Pure_essence_noted_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence x 250"]);
					pictureBox6.BackgroundImage = Resources.Uncut_sapphire_noted_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut sapphire x 4"]);
					pictureBox7.BackgroundImage = Resources.Uncut_emerald_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut emerald x 6"]);
					pictureBox8.BackgroundImage = Resources.Ring_of_life;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ring of life x 1"]);
					pictureBox9.BackgroundImage = Resources.Chaos_talisman;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos talisman x 1"]);
					pictureBox10.BackgroundImage = Resources.Nature_talisman;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Nature talisman x 1"]);
					pictureBox11.BackgroundImage = Resources.Zamorak_robe__top_;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Zamorak robe (top) x 1"]);
					pictureBox12.BackgroundImage = Resources.Zamorak_robe__bottom_;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Zamorak robe (bottom) x 1"]);
					pictureBox13.BackgroundImage = Resources.Splitbark_body;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Splitbark body x 1"]);
					pictureBox14.BackgroundImage = Resources.Splitbark_legs;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Splitbark legs x 1"]);
					pictureBox15.BackgroundImage = Resources.Prayer_potion__4_;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prayer potion (4) x 1"]);
					pictureBox16.BackgroundImage = Resources.Grimy_lantadyme_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy lantadyme x 4"]);
					pictureBox17.BackgroundImage = Resources.Anchovy_pizza_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Anchovy pizza x 8"]);
					pictureBox18.BackgroundImage = Resources.Monkfish;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Monkfish x 3"]);
					pictureBox19.BackgroundImage = Resources.Shark;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 1"]);
					pictureBox20.BackgroundImage = Resources.Battlestaff_noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff x 5"]);
					pictureBox21.BackgroundImage = Resources.Wine_of_zamorak_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Wine of zamorak x 10"]);
					pictureBox22.BackgroundImage = Resources.Coins_10000;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox23.BackgroundImage = Resources.Sinister_key;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Sinister key x 1"]);
					pictureBox24.BackgroundImage = Resources.Mysterious_emblem;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mysterious emblem x 1"]);
					pictureBox25.BackgroundImage = Resources.Ancient_staff;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ancient staff x 1"]);
					pictureBox26.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox27.BackgroundImage = Resources.Odium_shard_1;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Odium shard 1 x 1"]);
					pictureBox28.BackgroundImage = Resources.Malediction_shard_1;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Malediction shard 1 x 1"]);
					pictureBox29.BackgroundImage = Resources.Pet_chaos_elemental;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet chaos elemental x 1"]);
					pictureBox30.BackgroundImage = Resources.RDT;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(30);
					setNPictureBoxesToDisabled(30);
					break;

				case "Crazy Archaeologist":
					pictureBox1.BackgroundImage = Resources.Rune_crossbow;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune crossbox x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_knife_generic;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune knife x 10"]);
					pictureBox3.BackgroundImage = Resources.Amulet_of_power;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Amulet of power x 1"]);
					pictureBox4.BackgroundImage = Resources.Mud_rune;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mud rune x 30"]);
					pictureBox5.BackgroundImage = Resources.Potato_with_cheese;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Potato with cheese x 3"]);
					pictureBox6.BackgroundImage = Resources.Anchovy_pizza_noted_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Anchovy pizza x 8"]);
					pictureBox7.BackgroundImage = Resources.Shark;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 1"]);
					pictureBox8.BackgroundImage = Resources.Prayer_potion__4_;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prayer potion (4) x 1"]);
					pictureBox9.BackgroundImage = Resources.Uncut_sapphire_noted_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut sapphire x 4"]);
					pictureBox10.BackgroundImage = Resources.Uncut_emerald_noted_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut emerald x 6"]);
					pictureBox11.BackgroundImage = Resources.Silver_ore_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Silver ore x 40"]);
					pictureBox12.BackgroundImage = Resources.Muddy_key;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Muddy key x 1"]);
					pictureBox13.BackgroundImage = Resources.Rusty_sword;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rusty sword x 1"]);
					pictureBox14.BackgroundImage = Resources.Grimy_dwarf_weed_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy dwarf weed x 4"]);
					pictureBox15.BackgroundImage = Resources.White_berries_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Whiteberries x 10"]);
					pictureBox16.BackgroundImage = Resources.Cannonball_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cannonball x 150"]);
					pictureBox17.BackgroundImage = Resources.Red_d_hide_body;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Red d'hide body x 1"]);
					pictureBox18.BackgroundImage = Resources.Red_dragonhide_noted_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Red dragonhide x 10"]);
					pictureBox19.BackgroundImage = Resources.Coins_10000;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox20.BackgroundImage = Resources.Onyx_bolt_tips_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Onyx bolt tips x 12"]);
					pictureBox21.BackgroundImage = Resources.Mysterious_emblem;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mysterious emblem x 1"]);
					pictureBox22.BackgroundImage = Resources.Dragon_arrow_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon arrow x 75"]);
					pictureBox23.BackgroundImage = Resources.Long_bone;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Long bone x 1"]);
					pictureBox24.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox25.BackgroundImage = Resources.Fedora;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fedora x 1"]);
					pictureBox26.BackgroundImage = Resources.Odium_shard_2;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Odium shard 2 x 1"]);
					pictureBox27.BackgroundImage = Resources.Malediction_shard_2;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Malediction shard 2 x 1"]);
					pictureBox28.BackgroundImage = Resources.RDT;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(28);
					setNPictureBoxesToDisabled(28);
					break;

				case "King Black Dragon":
					pictureBox1.BackgroundImage = Resources.Rune_longsword;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune longsword x 1"]);
					pictureBox2.BackgroundImage = Resources.Adamant_platebody;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant platebody x 1"]);
					pictureBox3.BackgroundImage = Resources.Adamant_kiteshield;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant kiteshield x 1"]);
					pictureBox4.BackgroundImage = Resources.Iron_arrow_generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Iron arrow x 690"]);
					pictureBox5.BackgroundImage = Resources.Runite_bolts_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune bolts"]);
					pictureBox6.BackgroundImage = Resources.Dragon_dart_tips_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon dart tips"]);
					pictureBox7.BackgroundImage = Resources.Dragon_arrowtips_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon arrowtips"]);
					pictureBox8.BackgroundImage = Resources.Dragon_javelin_heads_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon javelin heads x 15"]);
					pictureBox9.BackgroundImage = Resources.Fire_rune;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fire rune x 300"]);
					pictureBox10.BackgroundImage = Resources.Air_rune;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air rune x 300"]);
					pictureBox11.BackgroundImage = Resources.Blood_rune;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 30"]);
					pictureBox12.BackgroundImage = Resources.Law_rune;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Law rune x 30"]);
					pictureBox13.BackgroundImage = Resources.Amulet_of_power;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Amulet of power x 1"]);
					pictureBox14.BackgroundImage = Resources.Yew_logs_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew logs x 150"]);
					pictureBox15.BackgroundImage = Resources.Shark;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 4"]);
					pictureBox16.BackgroundImage = Resources.Gold_ore_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold ore x 100"]);
					pictureBox17.BackgroundImage = Resources.Runite_limbs;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite limbs x 1"]);
					pictureBox18.BackgroundImage = Resources.Adamantite_bar;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite bar x 3"]);
					pictureBox19.BackgroundImage = Resources.Runite_bar;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bar x 1"]);
					pictureBox20.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox21.BackgroundImage = Resources.Dragon_med_helm;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon med helm x 1"]);
					pictureBox22.BackgroundImage = Resources.Kbd_heads;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Kbd heads x 1"]);
					pictureBox23.BackgroundImage = Resources.Dragon_pickaxe;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon pickaxe x 1"]);
					pictureBox24.BackgroundImage = Resources.Draconic_visage;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Draconic visage x 1"]);
					pictureBox25.BackgroundImage = Resources.Prince_black_dragon;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prince black dragon x 1"]);
					pictureBox26.BackgroundImage = Resources.RDT;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(26);
					setNPictureBoxesToDisabled(26);
					break;

				case "Scorpia":
					pictureBox1.BackgroundImage = Resources.Rune_scimitar;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune scimitar x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_sword;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune sword x 1"]);
					pictureBox3.BackgroundImage = Resources.Rune_warhammer;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune warhammer x 1"]);
					pictureBox4.BackgroundImage = Resources.Rune_2h_sword;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune 2h sword x 1"]);
					pictureBox5.BackgroundImage = Resources.Rune_spear;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune spear x 1"]);
					pictureBox6.BackgroundImage = Resources.Rune_pickaxe;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune pickaxe x 1"]);
					pictureBox7.BackgroundImage = Resources.Rune_chainbody;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune chainbody x 1"]);
					pictureBox8.BackgroundImage = Resources.Phoenix_necklace;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Phoenix necklace x 1"]);
					pictureBox9.BackgroundImage = Resources.Dust_rune;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dust rune x 30"]);
					pictureBox10.BackgroundImage = Resources.Uncut_sapphire_noted_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut sapphire x 4"]);
					pictureBox11.BackgroundImage = Resources.Uncut_emerald_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut emerald x 5"]);
					pictureBox12.BackgroundImage = Resources.Coins_10000;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox13.BackgroundImage = Resources.Admiral_pie;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Admiral pie x 3"]);
					pictureBox14.BackgroundImage = Resources.Anchovy_pizza_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Anchovy pizza x 8"]);
					pictureBox15.BackgroundImage = Resources.Shark;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 1"]);
					pictureBox16.BackgroundImage = Resources.Cactus_spine_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cactus spine x 10"]);
					pictureBox17.BackgroundImage = Resources.Prayer_potion__4_;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prayer potion (4) x 1"]);
					pictureBox18.BackgroundImage = Resources.Superantipoison__4_;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Superantipoison (4) x 1"]);
					pictureBox19.BackgroundImage = Resources.Ensouled_scorpion_head;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ensouled scorpion head x 1"]);
					pictureBox20.BackgroundImage = Resources.Bucket_of_sand_noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bucket of sand x 25"]);
					pictureBox21.BackgroundImage = Resources.Kwuarm_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Kwuarm x 4"]);
					pictureBox22.BackgroundImage = Resources.Mysterious_emblem;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mysterious emblem x 1"]);
					pictureBox23.BackgroundImage = Resources.Dragon_scimitar;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon scimitar x 1"]);
					pictureBox24.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox25.BackgroundImage = Resources.Odium_shard_3;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Odium shard 3 x 1"]);
					pictureBox26.BackgroundImage = Resources.Malediction_shard_3;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Malediction shard 3 x 1"]);
					pictureBox27.BackgroundImage = Resources.Scorpia_s_offspring;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Scorpia's offspring x 1"]);
					pictureBox28.BackgroundImage = Resources.RDT;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(28);
					setNPictureBoxesToDisabled(28);
					break;

				case "Venenatis":
					pictureBox1.BackgroundImage = Resources.Rune_pickaxe;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune pickaxe x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_2h_sword;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune 2h sword x 1"]);
					pictureBox3.BackgroundImage = Resources.Rune_knife_generic;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune knife x 60"]);
					pictureBox4.BackgroundImage = Resources.Diamond_bolts__e__generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Diamond bolts (e) x 100"]);
					pictureBox5.BackgroundImage = Resources.Cannonball_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cannonball x 250"]);
					pictureBox6.BackgroundImage = Resources.Chaos_rune_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune x 400"]);
					pictureBox7.BackgroundImage = Resources.Death_rune_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 300"]);
					pictureBox8.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 200"]);
					pictureBox9.BackgroundImage = Resources.Dark_fishing_bait_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark fishing bait x 375"]);
					pictureBox10.BackgroundImage = Resources.Dark_crab;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark crab x 8"]);
					pictureBox11.BackgroundImage = Resources.Supercompost_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Supercompost x 100"]);
					pictureBox12.BackgroundImage = Resources.Unicorn_horn_noted_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Unicorn horn x 100"]);
					pictureBox13.BackgroundImage = Resources.Red_spiders__eggs_noted_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Red spiders' eggs x 500"]);
					pictureBox14.BackgroundImage = Resources.Uncut_ruby_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut ruby x 20"]);
					pictureBox15.BackgroundImage = Resources.Uncut_diamond_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond x 10"]);
					pictureBox16.BackgroundImage = Resources.Uncut_dragonstone;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut dragonstone x 1"]);
					pictureBox17.BackgroundImage = Resources.Gold_ore_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold ore x 300"]);
					pictureBox18.BackgroundImage = Resources.Limpwurt_root_noted_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Limpwurt root x 50"]);
					pictureBox19.BackgroundImage = Resources.Grimy_snapdragon_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy snapdragon x 100"]);
					pictureBox20.BackgroundImage = Resources.Antidote____4__noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Antidote++ (4) x 10"]);
					pictureBox21.BackgroundImage = Resources.Super_restore__4_;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (4) x 3"]);
					pictureBox22.BackgroundImage = Resources.Palm_tree_seed_1;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Palm tree seed x 1"]);
					pictureBox23.BackgroundImage = Resources.Yew_seed_1;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew seed x 1"]);
					pictureBox24.BackgroundImage = Resources.Magic_seed_1;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 1"]);
					pictureBox25.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs x 100"]);
					pictureBox26.BackgroundImage = Resources.Coins_10000;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox27.BackgroundImage = Resources.Mysterious_emblem;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mysterious emblem x 1"]);
					pictureBox28.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox29.BackgroundImage = Resources.Onyx_bolt_tips_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Onyx bolt tips x 60"]);
					pictureBox30.BackgroundImage = Resources.Dragon_2h_sword;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon 2h sword x 1"]);
					pictureBox31.BackgroundImage = Resources.Dragon_pickaxe;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon pickaxe x 1"]);
					pictureBox32.BackgroundImage = Resources.Treasonous_ring;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Treasonous ring x 1"]);
					pictureBox33.BackgroundImage = Resources.Venenatis_spiderling;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Venenatis spiderling x 1"]);
					pictureBox34.BackgroundImage = Resources.RDT;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(34);
					setNPictureBoxesToDisabled(34);
					break;

				case "Vet'ion":
					pictureBox1.BackgroundImage = Resources.Rune_pickaxe;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune pickaxe x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_2h_sword;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune 2h sword x 1"]);
					pictureBox3.BackgroundImage = Resources.Ancient_staff;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ancient staff x 1"]);
					pictureBox4.BackgroundImage = Resources.Gold_ore_noted_generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold ore x 300"]);
					pictureBox5.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs x 100"]);
					pictureBox6.BackgroundImage = Resources.Chaos_rune_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune x 400"]);
					pictureBox7.BackgroundImage = Resources.Death_rune_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 300"]);
					pictureBox8.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 200"]);
					pictureBox9.BackgroundImage = Resources.Dark_fishing_bait_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark fishing bait x 375"]);
					pictureBox10.BackgroundImage = Resources.Dark_crab;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark crab x 8"]);
					pictureBox11.BackgroundImage = Resources.Supercompost_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Supercompost x 100"]);
					pictureBox12.BackgroundImage = Resources.Limpwurt_root_noted_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Limpwurt root x 50"]);
					pictureBox13.BackgroundImage = Resources.Dragon_bones_noted_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bones x 100"]);
					pictureBox14.BackgroundImage = Resources.Uncut_ruby_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut ruby x 20"]);
					pictureBox15.BackgroundImage = Resources.Uncut_diamond_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond x 10"]);
					pictureBox16.BackgroundImage = Resources.Uncut_dragonstone;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut dragonstone x 1"]);
					pictureBox17.BackgroundImage = Resources.Oak_plank_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Oak plank x 300"]);
					pictureBox18.BackgroundImage = Resources.Mort_myre_fungus_noted_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mort myre fungus x 200"]);
					pictureBox19.BackgroundImage = Resources.Grimy_ranarr_weed_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed x 100"]);
					pictureBox20.BackgroundImage = Resources.Sanfew_serum__4__noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Sanfew serum (4) x 10"]);
					pictureBox21.BackgroundImage = Resources.Super_restore__4_;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (4) x 3"]);
					pictureBox22.BackgroundImage = Resources.Palm_tree_seed_1;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Palm tree seed x 1"]);
					pictureBox23.BackgroundImage = Resources.Yew_seed_1;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew seed x 1"]);
					pictureBox24.BackgroundImage = Resources.Magic_seed_1;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 1"]);
					pictureBox25.BackgroundImage = Resources.Ogre_coffin_key_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ogre coffin key x 10"]);
					pictureBox26.BackgroundImage = Resources.Cannonball_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cannonball x 250"]);
					pictureBox27.BackgroundImage = Resources.Coins_10000;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox28.BackgroundImage = Resources.Mysterious_emblem;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mysterious emblem x 1"]);
					pictureBox29.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox30.BackgroundImage = Resources.Dragon_2h_sword;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon 2h sword x 1"]);
					pictureBox31.BackgroundImage = Resources.Dragon_pickaxe;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon pickaxe x 1"]);
					pictureBox32.BackgroundImage = Resources.Ring_of_the_gods;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ring of the gods x 1"]);
					pictureBox33.BackgroundImage = Resources.Long_bone;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Long bone x 1"]);
					pictureBox34.BackgroundImage = Resources.Curved_bone;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Curved bone x 1"]);
					pictureBox35.BackgroundImage = Resources.Vet_ion_jr;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Vet'ion jr x 1"]);
					pictureBox36.BackgroundImage = Resources.RDT;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(36);
					setNPictureBoxesToDisabled(36);
					break;

				case "Abyssal Sire":
					pictureBox1.BackgroundImage = Resources.Rune_sword_noted_generic;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune sword x 3"]);
					pictureBox2.BackgroundImage = Resources.Rune_full_helm_noted_generic;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune full helm x 3"]);
					pictureBox3.BackgroundImage = Resources.Rune_platebody_noted_generic;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune platebody x 2"]);
					pictureBox4.BackgroundImage = Resources.Rune_kiteshield_noted_generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune kiteshield x 2"]);
					pictureBox5.BackgroundImage = Resources.Battlestaff_noted_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff x 10"]);
					pictureBox6.BackgroundImage = Resources.Air_battlestaff_noted_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air battlestaff x 6"]);
					pictureBox7.BackgroundImage = Resources.Mystic_air_staff_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic air staff x 2"]);
					pictureBox8.BackgroundImage = Resources.Mystic_lava_staff_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic lava staff x 2"]);
					pictureBox9.BackgroundImage = Resources.Cosmic_rune_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cosmic rune x 350"]);
					pictureBox10.BackgroundImage = Resources.Law_rune_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Law rune x 250"]);
					pictureBox11.BackgroundImage = Resources.Death_rune_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune"]);
					pictureBox12.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune"]);
					pictureBox13.BackgroundImage = Resources.Soul_rune_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Soul rune"]);
					pictureBox14.BackgroundImage = Resources.Pure_essence_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence x 600"]);
					pictureBox15.BackgroundImage = Resources.Earth_orb_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Earth orb"]);
					pictureBox16.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs"]);
					pictureBox17.BackgroundImage = Resources.Ranarr_seed_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranarr seed x 1"]);
					pictureBox18.BackgroundImage = Resources.Snapdragon_seed_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon seed x 2"]);
					pictureBox19.BackgroundImage = Resources.Torstol_seed_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol seed x 2"]);
					pictureBox20.BackgroundImage = Resources.Watermelon_seed_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Watermelon seed x 30"]);
					pictureBox21.BackgroundImage = Resources.Papaya_tree_seed_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Papaya tree seed x 2"]);
					pictureBox22.BackgroundImage = Resources.Palm_tree_seed_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Palm tree seed x 2"]);
					pictureBox23.BackgroundImage = Resources.Willow_seed_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Willow seed x 2"]);
					pictureBox24.BackgroundImage = Resources.Maple_seed_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Maple seed x 2"]);
					pictureBox25.BackgroundImage = Resources.Yew_seed_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew seed x 2"]);
					pictureBox26.BackgroundImage = Resources.Magic_seed_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 2"]);
					pictureBox27.BackgroundImage = Resources.Spirit_seed_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Spirit seed x 2"]);
					pictureBox28.BackgroundImage = Resources.Grimy_kwuarm_noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy kwuarm x 25"]);
					pictureBox29.BackgroundImage = Resources.Grimy_lantadyme_noted_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy lantadyme x 25"]);
					pictureBox30.BackgroundImage = Resources.Grimy_cadantine_noted_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy cadantine x 25"]);
					pictureBox31.BackgroundImage = Resources.Grimy_dwarf_weed_noted_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy dwarf weed x 25"]);
					pictureBox32.BackgroundImage = Resources.Chilli_potato;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chili potato x 10"]);
					pictureBox33.BackgroundImage = Resources.Saradomin_brew__3_;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saradomin brew (3) x 6"]);
					pictureBox34.BackgroundImage = Resources.Super_restore__4_;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (4) x 4"]);
					pictureBox35.BackgroundImage = Resources.Coal_noted_generic;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal"]);
					pictureBox36.BackgroundImage = Resources.Runite_ore_noted_generic;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite ore x 6"]);
					pictureBox37.BackgroundImage = Resources.Runite_bar_noted_generic;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bar x 5"]);
					pictureBox38.BackgroundImage = Resources.Jug_of_water_noted_generic;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Jug of water"]);
					pictureBox39.BackgroundImage = Resources.Binding_necklace_noted_generic;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Binding necklace x 25"]);
					pictureBox40.BackgroundImage = Resources.Air_talisman;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air talisman x 1"]);
					pictureBox41.BackgroundImage = Resources.Water_talisman;
					pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Water talisman x 1"]);
					pictureBox42.BackgroundImage = Resources.Fire_talisman;
					pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fire talisman x 1"]);
					pictureBox43.BackgroundImage = Resources.Earth_talisman;
					pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Earth talisman x 1"]);
					pictureBox44.BackgroundImage = Resources.Mind_talisman;
					pictureBox44.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mind talisman x 1"]);
					pictureBox45.BackgroundImage = Resources.Body_talisman;
					pictureBox45.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Body talisman x 1"]);
					pictureBox46.BackgroundImage = Resources.Cosmic_talisman;
					pictureBox46.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cosmic talisman x 1"]);
					pictureBox47.BackgroundImage = Resources.Nature_talisman;
					pictureBox47.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Nature talisman x 1"]);
					pictureBox48.BackgroundImage = Resources.Chaos_talisman;
					pictureBox48.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos talisman x 1"]);
					pictureBox49.BackgroundImage = Resources.Cannonball_generic;
					pictureBox49.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cannonball x 300"]);
					pictureBox50.BackgroundImage = Resources.Uncut_diamond_noted_generic;
					pictureBox50.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond x 15"]);
					pictureBox51.BackgroundImage = Resources.Coins_10000;
					pictureBox51.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox52.BackgroundImage = Resources.Onyx_bolt_tips_generic;
					pictureBox52.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Onyx bolt tips x 10"]);
					pictureBox53.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox53.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox54.BackgroundImage = Resources.Unsired;
					pictureBox54.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Unsired x 1"]);
					pictureBox55.BackgroundImage = Resources.RDT;
					pictureBox55.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(55);
					setNPictureBoxesToDisabled(55);
					break;

				case "Barrows":
					pictureBox1.BackgroundImage = Resources.Ahrim_s_hood;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ahrim's hood x 1"]);
					pictureBox2.BackgroundImage = Resources.Karil_s_coif;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Karil's coif x 1"]);
					pictureBox3.BackgroundImage = Resources.Dharok_s_helm;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dharok's helm x 1"]);
					pictureBox4.BackgroundImage = Resources.Guthan_s_helm;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Guthan's helm x 1"]);
					pictureBox5.BackgroundImage = Resources.Torag_s_helm;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torag's helm x 1"]);
					pictureBox6.BackgroundImage = Resources.Verac_s_helm;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Verac's helm x 1"]);
					pictureBox7.BackgroundImage = Resources.Mind_rune_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mind rune"]);
					pictureBox8.BackgroundImage = Resources.Chaos_rune_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune"]);
					pictureBox9.BackgroundImage = Resources.Ahrim_s_robetop;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ahrim's robetop x 1"]);
					pictureBox10.BackgroundImage = Resources.Karil_s_leathertop;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Karil's leathertop x 1"]);
					pictureBox11.BackgroundImage = Resources.Dharok_s_platebody;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dharok's platebody x 1"]);
					pictureBox12.BackgroundImage = Resources.Guthan_s_platebody;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Guthan's platebody x 1"]);
					pictureBox13.BackgroundImage = Resources.Torag_s_platebody;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torag's platebody x 1"]);
					pictureBox14.BackgroundImage = Resources.Verac_s_brassard;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Verac's brassard x 1"]);
					pictureBox15.BackgroundImage = Resources.Death_rune_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune"]);
					pictureBox16.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune"]);
					pictureBox17.BackgroundImage = Resources.Ahrim_s_robeskirt;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ahrim's robeskrit x 1"]);
					pictureBox18.BackgroundImage = Resources.Karil_s_leatherskirt;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Karil's leatherskirt x 1"]);
					pictureBox19.BackgroundImage = Resources.Dharok_s_platelegs;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dharok's platelegs x 1"]);
					pictureBox20.BackgroundImage = Resources.Guthan_s_chainskirt;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Guthan's chainskirt x 1"]);
					pictureBox21.BackgroundImage = Resources.Torag_s_platelegs;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torag's platelegs x 1"]);
					pictureBox22.BackgroundImage = Resources.Verac_s_plateskirt;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Verac's plateskirt x 1"]);
					pictureBox23.BackgroundImage = Resources.Loop_half_of_key;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Loop half of key x 1"]);
					pictureBox24.BackgroundImage = Resources.Tooth_half_of_key;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tooth half of key x 1"]);
					pictureBox25.BackgroundImage = Resources.Ahrim_s_staff;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ahrim's staff x 1"]);
					pictureBox26.BackgroundImage = Resources.Karil_s_crossbow;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Karil's crossbow x 1"]);
					pictureBox27.BackgroundImage = Resources.Dharok_s_greataxe;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dharok's greataxe x 1"]);
					pictureBox28.BackgroundImage = Resources.Guthan_s_warspear;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Guthan's warspear x 1"]);
					pictureBox29.BackgroundImage = Resources.Torag_s_hammers;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torag's hammers x 1"]);
					pictureBox30.BackgroundImage = Resources.Verac_s_flail;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Verac's flail x 1"]);
					pictureBox31.BackgroundImage = Resources.Coins_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox32.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox33.BackgroundImage = Resources.Dragon_med_helm;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon med helm x 1"]);
					pictureBox34.BackgroundImage = Resources.Bolt_rack_generic;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bolt rack"]);

					setNPictureBoxesToVisible(34);
					setNPictureBoxesToDisabled(34);
					break;

				case "Cerberus":
					pictureBox1.BackgroundImage = Resources.Rune_2h_sword;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune 2h sword x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_halberd;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune halberd x 1"]);
					pictureBox3.BackgroundImage = Resources.Rune_axe;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune axe x 1"]);
					pictureBox4.BackgroundImage = Resources.Rune_pickaxe;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune pickaxe x 1"]);
					pictureBox5.BackgroundImage = Resources.Rune_full_helm;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune full helm x 1"]);
					pictureBox6.BackgroundImage = Resources.Rune_platebody;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune platebody x 1"]);
					pictureBox7.BackgroundImage = Resources.Rune_chainbody;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune chainbody x 1"]);
					pictureBox8.BackgroundImage = Resources.Black_d_hide_body;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Black d'hide body x 1"]);
					pictureBox9.BackgroundImage = Resources.Battlestaff_noted_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff x 6"]);
					pictureBox10.BackgroundImage = Resources.Lava_battlestaff;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Lava battlestaff x 1"]);
					pictureBox11.BackgroundImage = Resources.Pure_essence_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence x 300"]);
					pictureBox12.BackgroundImage = Resources.Fire_rune_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fire rune x 300"]);
					pictureBox13.BackgroundImage = Resources.Death_rune_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 100"]);
					pictureBox14.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 60"]);
					pictureBox15.BackgroundImage = Resources.Soul_rune_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Soul rune x 100"]);
					pictureBox16.BackgroundImage = Resources.Runite_bolts__unf__generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bolts (unf) x 40"]);
					pictureBox17.BackgroundImage = Resources.Cannonball_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cannonball x 50"]);
					pictureBox18.BackgroundImage = Resources.Torstol_seed_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol seed x 3"]);
					pictureBox19.BackgroundImage = Resources.Grimy_torstol_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy torstol x 6"]);
					pictureBox20.BackgroundImage = Resources.Super_restore__4_;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (4) x 2"]);
					pictureBox21.BackgroundImage = Resources.Coal_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal x 120"]);
					pictureBox22.BackgroundImage = Resources.Runite_ore_noted_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite ore x 5"]);
					pictureBox23.BackgroundImage = Resources.Wine_of_zamorak_noted_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Wine of zamorak x 15"]);
					pictureBox24.BackgroundImage = Resources.Unholy_symbol;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Unholy symbol x 1"]);
					pictureBox25.BackgroundImage = Resources.Ashes_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ashes x 50"]);
					pictureBox26.BackgroundImage = Resources.Summer_pie;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Summer pie x 3"]);
					pictureBox27.BackgroundImage = Resources.Dragon_bones_noted_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bones x 20"]);
					pictureBox28.BackgroundImage = Resources.Fire_orb_noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fire orb x 20"]);
					pictureBox29.BackgroundImage = Resources.Uncut_diamond_noted_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond x 5"]);
					pictureBox30.BackgroundImage = Resources.Coins_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox31.BackgroundImage = Resources.Key_master_teleport_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Key master teleport x 3"]);
					pictureBox32.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox33.BackgroundImage = Resources.Smouldering_stone;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Smouldering stone x 1"]);
					pictureBox34.BackgroundImage = Resources.Pegasian_crystal;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pegasian crystal x 1"]);
					pictureBox35.BackgroundImage = Resources.Eternal_crystal;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Eternal crystal x 1"]);
					pictureBox36.BackgroundImage = Resources.Primordial_crystal;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Primordial crystal x 1"]);
					pictureBox37.BackgroundImage = Resources.Jar_of_souls;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Jar of souls x 1"]);
					pictureBox38.BackgroundImage = Resources.Hellpuppy;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Hellpuppy x 1"]);
					pictureBox39.BackgroundImage = Resources.RDT;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(39);
					setNPictureBoxesToDisabled(39);
					break;

				case "Corporeal Beast":
					pictureBox1.BackgroundImage = Resources.Adamant_arrow_generic;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant arrow x 750"]);
					pictureBox2.BackgroundImage = Resources.Runite_bolts_generic;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bolts x 250"]);
					pictureBox3.BackgroundImage = Resources.Cannonball_generic;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cannonball x 2000"]);
					pictureBox4.BackgroundImage = Resources.Mystic_air_staff;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic air staff x 1"]);
					pictureBox5.BackgroundImage = Resources.Mystic_water_staff;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic water staff x 1"]);
					pictureBox6.BackgroundImage = Resources.Mystic_earth_staff;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic earth staff x 1"]);
					pictureBox7.BackgroundImage = Resources.Mystic_fire_staff;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic fire staff x 1"]);
					pictureBox8.BackgroundImage = Resources.Nature_talisman;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Nature talisman"]);
					pictureBox9.BackgroundImage = Resources.Uncut_sapphire;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut sapphire"]);
					pictureBox10.BackgroundImage = Resources.Uncut_emerald;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut emerald"]);
					pictureBox11.BackgroundImage = Resources.Uncut_ruby;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut ruby"]);
					pictureBox12.BackgroundImage = Resources.Uncut_diamond;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond"]);
					pictureBox13.BackgroundImage = Resources.Mystic_robe_top__blue_;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic robe top (blue) x 1"]);
					pictureBox14.BackgroundImage = Resources.Mystic_robe_bottom__blue_;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic robe bottom (blue) x 1"]);
					pictureBox15.BackgroundImage = Resources.Mahogany_logs_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mahogany logs x 150"]);
					pictureBox16.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs x 75"]);
					pictureBox17.BackgroundImage = Resources.Pure_essence_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence x 2500"]);
					pictureBox18.BackgroundImage = Resources.Law_rune_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Law rune x 250"]);
					pictureBox19.BackgroundImage = Resources.Cosmic_rune_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cosmic rune x 500"]);
					pictureBox20.BackgroundImage = Resources.Death_rune_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 300"]);
					pictureBox21.BackgroundImage = Resources.Soul_rune_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Soul rune x 250"]);
					pictureBox22.BackgroundImage = Resources.Adamantite_bar_noted_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite bar x 35"]);
					pictureBox23.BackgroundImage = Resources.Adamantite_ore_noted_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite ore x 125"]);
					pictureBox24.BackgroundImage = Resources.Runite_ore_noted_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite ore x 20"]);
					pictureBox25.BackgroundImage = Resources.Teak_plank_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Teak plank x 100"]);
					pictureBox26.BackgroundImage = Resources.Green_dragonhide_noted_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Green dragonhide x 100"]);
					pictureBox27.BackgroundImage = Resources.Raw_shark_noted_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw shark x 70"]);
					pictureBox28.BackgroundImage = Resources.White_berries_noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Whiteberries x 120"]);
					pictureBox29.BackgroundImage = Resources.Desert_goat_horn_noted_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Desert goat horn x 120"]);
					pictureBox30.BackgroundImage = Resources.Antidote____4__noted_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Antidote++ (4) x 40"]);
					pictureBox31.BackgroundImage = Resources.Watermelon_seed_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Watermelon seed x 24"]);
					pictureBox32.BackgroundImage = Resources.Ranarr_seed_generic;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranarr seed x 10"]);
					pictureBox33.BackgroundImage = Resources.Tuna_potato;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tuna potato x 30"]);
					pictureBox34.BackgroundImage = Resources.Coins_generic;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox35.BackgroundImage = Resources.Shield_left_half;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shield left half x 1"]);
					pictureBox36.BackgroundImage = Resources.Dragon_spear;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon spear x 1"]);
					pictureBox37.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox38.BackgroundImage = Resources.Onyx_bolts__e__generic;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Onyx bolts (e) x 175"]);
					pictureBox39.BackgroundImage = Resources.Holy_elixir;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Holy elixir x 1"]);
					pictureBox40.BackgroundImage = Resources.Spirit_shield;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Spirit shield x 1"]);
					pictureBox41.BackgroundImage = Resources.Spectral_sigil;
					pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Spectral sigil x 1"]);
					pictureBox42.BackgroundImage = Resources.Arcane_sigil;
					pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Arcane sigil x 1"]);
					pictureBox43.BackgroundImage = Resources.Elysian_sigil;
					pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elysian sigil x 1"]);
					pictureBox44.BackgroundImage = Resources.Pet_dark_core;
					pictureBox44.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet dark core"]);

					setNPictureBoxesToVisible(44);
					setNPictureBoxesToDisabled(44);
					break;

				case "Dagannoth Kings":
					highlightPictureBox(pictureBoxDagannothPrimeLoot);
					if (selectedDagannothKingLoot == "Dagannoth Prime") {
						pictureBox1.BackgroundImage = Resources.Battlestaff_noted_generic;
						pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff"]);
						pictureBox2.BackgroundImage = Resources.Air_battlestaff;
						pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air battlestaff x 1"]);
						pictureBox3.BackgroundImage = Resources.Water_battlestaff;
						pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Water battlestaff x 1"]);
						pictureBox4.BackgroundImage = Resources.Earth_battlestaff;
						pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Earth battlestaff x 1"]);
						pictureBox5.BackgroundImage = Resources.Pure_essence_noted_generic;
						pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence x 150"]);
						pictureBox6.BackgroundImage = Resources.Air_rune_generic;
						pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air rune x 155"]);
						pictureBox7.BackgroundImage = Resources.Mud_rune_generic;
						pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mud rune x 32"]);
						pictureBox8.BackgroundImage = Resources.Death_rune_generic;
						pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune"]);
						pictureBox9.BackgroundImage = Resources.Ensouled_dagannoth_head;
						pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ensouled dagannoth head x 1"]);
						pictureBox10.BackgroundImage = Resources.Air_talisman;
						pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air talisman"]);
						pictureBox11.BackgroundImage = Resources.Water_talisman;
						pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Water talisman"]);
						pictureBox12.BackgroundImage = Resources.Earth_talisman;
						pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Earth talisman"]);
						pictureBox13.BackgroundImage = Resources.Grimy_ranarr_weed;
						pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed x 1"]);
						pictureBox14.BackgroundImage = Resources.Belladonna_seed_generic;
						pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Belladonna seed x 1"]);
						pictureBox15.BackgroundImage = Resources.Cactus_seed_generic;
						pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cactus seed x 1"]);
						pictureBox16.BackgroundImage = Resources.Poison_ivy_seed_generic;
						pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Poison ivy seed x 1"]);
						pictureBox17.BackgroundImage = Resources.Irit_seed_generic;
						pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Irit seed x 1"]);
						pictureBox18.BackgroundImage = Resources.Toadflax_seed_generic;
						pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Toadflax seed x 1"]);
						pictureBox19.BackgroundImage = Resources.Avantoe_seed_generic;
						pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Avantoe seed x 1"]);
						pictureBox20.BackgroundImage = Resources.Kwuarm_seed_generic;
						pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Kwuarm seed x 1"]);
						pictureBox21.BackgroundImage = Resources.Snapdragon_seed_generic;
						pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon seed x 1"]);
						pictureBox22.BackgroundImage = Resources.Cadantine_seed_generic;
						pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cadantine seed x 1"]);
						pictureBox23.BackgroundImage = Resources.Lantadyme_seed_generic;
						pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Lantadyme seed x 1"]);
						pictureBox24.BackgroundImage = Resources.Dwarf_weed_seed_generic;
						pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dwarf weed seed x 1"]);
						pictureBox25.BackgroundImage = Resources.Fremennik_shield;
						pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fremennik shield x 1"]);
						pictureBox26.BackgroundImage = Resources.Fremennik_helm;
						pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fremennik helm x 1"]);
						pictureBox27.BackgroundImage = Resources.Skeletal_top;
						pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Skeletal top x 1"]);
						pictureBox28.BackgroundImage = Resources.Skeletal_bottoms;
						pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Skeletal bottoms x 1"]);
						pictureBox29.BackgroundImage = Resources.Farseer_helm;
						pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Farseer helm x 1"]);
						pictureBox30.BackgroundImage = Resources.Coins_generic;
						pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
						pictureBox31.BackgroundImage = Resources.Hard_clue_scroll;
						pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Hard clue scroll x 1"]);
						pictureBox32.BackgroundImage = Resources.Elite_clue_scroll;
						pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
						pictureBox33.BackgroundImage = Resources.Dragon_axe;
						pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon axe x 1"]);
						pictureBox34.BackgroundImage = Resources.Mud_battlestaff;
						pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mud battlestaff x 1"]);
						pictureBox35.BackgroundImage = Resources.Seers_ring;
						pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Seers ring x 1"]);
						pictureBox36.BackgroundImage = Resources.Pet_dagannoth_prime;
						pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet dagannoth prime x 1"]);
						pictureBox37.BackgroundImage = Resources.RDT;
						pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

						setNPictureBoxesToVisible(37, "Dagannoth Kings Loot");
						setNPictureBoxesToDisabled(37);
						break;
					}
					if (selectedDagannothKingLoot == "Dagannoth Rex") {
						pictureBox1.BackgroundImage = Resources.Mithril_warhammer;
						pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril warhammer x 1"]);
						pictureBox2.BackgroundImage = Resources.Mithril_2h_sword;
						pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril 2h sword x 1"]);
						pictureBox3.BackgroundImage = Resources.Mithril_pickaxe;
						pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril pickaxe x 1"]);
						pictureBox4.BackgroundImage = Resources.Adamant_axe;
						pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant axe x 1"]);
						pictureBox5.BackgroundImage = Resources.Rune_battleaxe;
						pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune battleaxe x 1"]);
						pictureBox6.BackgroundImage = Resources.Rune_axe;
						pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune axe x 1"]);
						pictureBox7.BackgroundImage = Resources.Fremennik_blade;
						pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fremennik blade x 1"]);
						pictureBox8.BackgroundImage = Resources.Fremennik_helm;
						pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fremennik helm x 1"]);
						pictureBox9.BackgroundImage = Resources.Super_attack__2_;
						pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super attack (2) x 1"]);
						pictureBox10.BackgroundImage = Resources.Super_strength__2_;
						pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super strength (2) x 1"]);
						pictureBox11.BackgroundImage = Resources.Super_defence__2_;
						pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super defence (2) x 1"]);
						pictureBox12.BackgroundImage = Resources.Prayer_potion__2_;
						pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prayer potion (2) x 1"]);
						pictureBox13.BackgroundImage = Resources.Antifire_potion__2_;
						pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Antifire (2) x 1"]);
						pictureBox14.BackgroundImage = Resources.Zamorak_brew__2_;
						pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Zamorak brew (2) x 1"]);
						pictureBox15.BackgroundImage = Resources.Fremennik_shield;
						pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fremennik shield x 1"]);
						pictureBox16.BackgroundImage = Resources.Steel_kiteshield;
						pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Steel kiteshield x 1"]);
						pictureBox17.BackgroundImage = Resources.Air_talisman;
						pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air talisman x 1"]);
						pictureBox18.BackgroundImage = Resources.Fire_talisman;
						pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fire talisman x 1"]);
						pictureBox19.BackgroundImage = Resources.Water_talisman;
						pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Water talisman x 1"]);
						pictureBox20.BackgroundImage = Resources.Earth_talisman;
						pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Earth talisman x 1"]);
						pictureBox21.BackgroundImage = Resources.Mind_talisman;
						pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mind talisman x 1"]);
						pictureBox22.BackgroundImage = Resources.Body_talisman;
						pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Body talisman x 1"]);
						pictureBox23.BackgroundImage = Resources.Cosmic_talisman;
						pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cosmic talisman x 1"]);
						pictureBox24.BackgroundImage = Resources.Steel_platebody;
						pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Steel platebody x 1"]);
						pictureBox25.BackgroundImage = Resources.Grimy_ranarr_weed;
						pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed x 1"]);
						pictureBox26.BackgroundImage = Resources.Ensouled_dagannoth_head;
						pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ensouled dagannoth head x 1"]);
						pictureBox27.BackgroundImage = Resources.Iron_ore_noted_generic;
						pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Iron ore x 150"]);
						pictureBox28.BackgroundImage = Resources.Coal_noted_generic;
						pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal x 100"]);
						pictureBox29.BackgroundImage = Resources.Mithril_ore_noted_generic;
						pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril ore x 25"]);
						pictureBox30.BackgroundImage = Resources.Steel_bar_noted_generic;
						pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Steel bar"]);
						pictureBox31.BackgroundImage = Resources.Adamantite_bar;
						pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite bar x 1"]);
						pictureBox32.BackgroundImage = Resources.Adamant_platebody;
						pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant platebody x 1"]);
						pictureBox33.BackgroundImage = Resources.Bass;
						pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bass x 5"]);
						pictureBox34.BackgroundImage = Resources.Swordfish;
						pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Swordfish x 5"]);
						pictureBox35.BackgroundImage = Resources.Shark;
						pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 5"]);
						pictureBox36.BackgroundImage = Resources.Coins_generic;
						pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
						pictureBox37.BackgroundImage = Resources.Ring_of_life;
						pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ring of life x 1"]);
						pictureBox38.BackgroundImage = Resources.Rock_shell_plate;
						pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rock-shell plate x 1"]);
						pictureBox39.BackgroundImage = Resources.Rock_shell_legs;
						pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rock-shell legs x 1"]);
						pictureBox40.BackgroundImage = Resources.Hard_clue_scroll;
						pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Hard clue scroll x 1"]);
						pictureBox41.BackgroundImage = Resources.Elite_clue_scroll;
						pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
						pictureBox42.BackgroundImage = Resources.Dragon_axe;
						pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon axe x 1"]);
						pictureBox43.BackgroundImage = Resources.Warrior_ring;
						pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Warrior ring x 1"]);
						pictureBox44.BackgroundImage = Resources.Berserker_ring;
						pictureBox44.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Berserker ring x 1"]);
						pictureBox45.BackgroundImage = Resources.Pet_dagannoth_rex;
						pictureBox45.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet dagannoth rex x 1"]);
						pictureBox46.BackgroundImage = Resources.RDT;
						pictureBox46.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

						setNPictureBoxesToVisible(46, "Dagannoth Kings Loot");
						setNPictureBoxesToDisabled(46);
						break;
					}
					if (selectedDagannothKingLoot == "Dagannoth Supreme") {
						pictureBox1.BackgroundImage = Resources.Iron_arrow_generic;
						pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Iron arrow"]);
						pictureBox2.BackgroundImage = Resources.Steel_arrow_generic;
						pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Steel arrow"]);
						pictureBox3.BackgroundImage = Resources.Iron_knife_generic;
						pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Iron knife"]);
						pictureBox4.BackgroundImage = Resources.Steel_knife_generic;
						pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Steel knife"]);
						pictureBox5.BackgroundImage = Resources.Mithril_knife_generic;
						pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril knife"]);
						pictureBox6.BackgroundImage = Resources.Rune_thrownaxe_generic;
						pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune thrownaxe"]);
						pictureBox7.BackgroundImage = Resources.Rune_javelin_generic;
						pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune javelin"]);
						pictureBox8.BackgroundImage = Resources.Runite_bolts_generic;
						pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune bolts"]);
						pictureBox9.BackgroundImage = Resources.Runite_limbs;
						pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune limbs x 1"]);
						pictureBox10.BackgroundImage = Resources.Adamant_axe;
						pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant axe x 1"]);
						pictureBox11.BackgroundImage = Resources.Belladonna_seed_generic;
						pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Belladonna seed x 1"]);
						pictureBox12.BackgroundImage = Resources.Cactus_seed_generic;
						pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cactus seed x 1"]);
						pictureBox13.BackgroundImage = Resources.Poison_ivy_seed_generic;
						pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Poison ivy seed x 1"]);
						pictureBox14.BackgroundImage = Resources.Irit_seed_generic;
						pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Irit seed x 1"]);
						pictureBox15.BackgroundImage = Resources.Toadflax_seed_generic;
						pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Toadflax seed x 1"]);
						pictureBox16.BackgroundImage = Resources.Avantoe_seed_generic;
						pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Avantoe seed x 1"]);
						pictureBox17.BackgroundImage = Resources.Kwuarm_seed_generic;
						pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Kwuarm seed x 1"]);
						pictureBox18.BackgroundImage = Resources.Cadantine_seed_generic;
						pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cadantine seed x 1"]);
						pictureBox19.BackgroundImage = Resources.Lantadyme_seed_generic;
						pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Lantadyme seed x 1"]);
						pictureBox20.BackgroundImage = Resources.Dwarf_weed_seed_generic;
						pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dwarf weed seed x 1"]);
						pictureBox21.BackgroundImage = Resources.Torstol_seed_generic;
						pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol seed x 1"]);
						pictureBox22.BackgroundImage = Resources.Coins_generic;
						pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
						pictureBox23.BackgroundImage = Resources.Opal_bolt_tips_generic;
						pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Opal bolt tips"]);
						pictureBox24.BackgroundImage = Resources.Oyster_pearls;
						pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Oyster x 1"]);
						pictureBox25.BackgroundImage = Resources.Shark;
						pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 5"]);
						pictureBox26.BackgroundImage = Resources.Maple_logs_noted_generic;
						pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Maple logs"]);
						pictureBox27.BackgroundImage = Resources.Yew_logs_noted_generic;
						pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew logs"]);
						pictureBox28.BackgroundImage = Resources.Grimy_ranarr_weed;
						pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed x 1"]);
						pictureBox29.BackgroundImage = Resources.Ensouled_dagannoth_head;
						pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ensouled dagannoth head x 1"]);
						pictureBox30.BackgroundImage = Resources.Feather;
						pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Feather"]);
						pictureBox31.BackgroundImage = Resources.Red_d_hide_vamb;
						pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Red d'hide vambraces"]);
						pictureBox32.BackgroundImage = Resources.Fremennik_shield;
						pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fremennik shield x 1"]);
						pictureBox33.BackgroundImage = Resources.Fremennik_helm;
						pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fremennik helm x 1"]);
						pictureBox34.BackgroundImage = Resources.Spined_body;
						pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Spined body x 1"]);
						pictureBox35.BackgroundImage = Resources.Spined_chaps;
						pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Spined chaps x 1"]);
						pictureBox36.BackgroundImage = Resources.Archer_helm;
						pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Archer helm x 1"]);
						pictureBox37.BackgroundImage = Resources.Hard_clue_scroll;
						pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Hard clue scroll x 1"]);
						pictureBox38.BackgroundImage = Resources.Elite_clue_scroll;
						pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
						pictureBox39.BackgroundImage = Resources.Seercull;
						pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Seercull x 1"]);
						pictureBox40.BackgroundImage = Resources.Dragon_axe;
						pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon axe x 1"]);
						pictureBox41.BackgroundImage = Resources.Archers_ring;
						pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Archers ring x 1"]);
						pictureBox42.BackgroundImage = Resources.Pet_dagannoth_supreme;
						pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet dagannoth supreme x 1"]);
						pictureBox43.BackgroundImage = Resources.RDT;
						pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

						setNPictureBoxesToVisible(43, "Dagannoth Kings Loot");
						setNPictureBoxesToDisabled(43);
						break;

					}
					break;

				case "Giant Mole":
					pictureBox1.BackgroundImage = Resources.Mithril_battleaxe;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril battleaxe x 1"]);
					pictureBox2.BackgroundImage = Resources.Mithril_axe;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril axe x 1"]);
					pictureBox3.BackgroundImage = Resources.Adamant_longsword;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant longsword x 1"]);
					pictureBox4.BackgroundImage = Resources.Mithril_platebody;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril platebody x 1"]);
					pictureBox5.BackgroundImage = Resources.Rune_med_helm;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune med helm x 1"]);
					pictureBox6.BackgroundImage = Resources.Iron_arrow_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Iron arrow x 690"]);
					pictureBox7.BackgroundImage = Resources.Mithril_bar;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril bar x 1"]);
					pictureBox8.BackgroundImage = Resources.Iron_ore_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Iron ore x 100"]);
					pictureBox9.BackgroundImage = Resources.Amulet_of_strength;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Amulet of strength x 1"]);
					pictureBox10.BackgroundImage = Resources.Law_rune_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Law rune x 15"]);
					pictureBox11.BackgroundImage = Resources.Air_rune_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air rune x 105"]);
					pictureBox12.BackgroundImage = Resources.Fire_rune_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fire rune x 105"]);
					pictureBox13.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 15"]);
					pictureBox14.BackgroundImage = Resources.Death_rune_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 7"]);
					pictureBox15.BackgroundImage = Resources.Oyster_pearls;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Oyster x 1"]);
					pictureBox16.BackgroundImage = Resources.Shark;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 4"]);
					pictureBox17.BackgroundImage = Resources.Yew_logs_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew logs x 100"]);
					pictureBox18.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox19.BackgroundImage = Resources.Long_bone;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Long bone x 1"]);
					pictureBox20.BackgroundImage = Resources.Curved_bone;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Curved bone x 1"]);
					pictureBox21.BackgroundImage = Resources.Baby_mole;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Baby mole x 1"]);
					pictureBox22.BackgroundImage = Resources.RDT;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(22);
					setNPictureBoxesToDisabled(22);
					break;

				case "Grotesque Guardians":
					labelCurrentLogFor.Text = "Current log for: " + grotesqueGuardiansToolStripMenuItem.Text;
					pictureBox1.BackgroundImage = Resources.Chaos_rune;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune"]);
					pictureBox2.BackgroundImage = Resources.Death_rune;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune"]);
					pictureBox3.BackgroundImage = Resources.Diamond_bolt_tips_5;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Diamond bolt tips"]);
					pictureBox4.BackgroundImage = Resources.Dragon_bolt_tips_5;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bolt tips"]);
					pictureBox5.BackgroundImage = Resources.Onyx_bolt_tips_5;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Onyx bolt tips"]);
					pictureBox6.BackgroundImage = Resources.Dragon_dart_tips_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon dart tips"]);
					pictureBox7.BackgroundImage = Resources.Dragon_arrowtips_5;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon arrowtips"]);
					pictureBox8.BackgroundImage = Resources.Prayer_potion__4_;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prayer potion (4) x 1"]);
					pictureBox9.BackgroundImage = Resources.Coal_noted_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal"]);
					pictureBox10.BackgroundImage = Resources.Gold_ore_noted_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold ore"]);
					pictureBox11.BackgroundImage = Resources.Runite_ore_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite ore"]);
					pictureBox12.BackgroundImage = Resources.Gold_bar_noted_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold bar"]);
					pictureBox13.BackgroundImage = Resources.Mithril_bar_noted_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril bar"]);
					pictureBox14.BackgroundImage = Resources.Adamantite_bar_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite bar"]);
					pictureBox15.BackgroundImage = Resources.Runite_bar_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bar"]);
					pictureBox16.BackgroundImage = Resources.Saradomin_brew__4_;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saradomin brew (4) x 2"]);
					pictureBox17.BackgroundImage = Resources.Rune_pickaxe;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune pickaxe x 1"]);
					pictureBox18.BackgroundImage = Resources.Rune_battleaxe;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune battleaxe x 1"]);
					pictureBox19.BackgroundImage = Resources.Rune_2h_sword;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune 2h sword x 1"]);
					pictureBox20.BackgroundImage = Resources.Rune_full_helm;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune full helm x 1"]);
					pictureBox21.BackgroundImage = Resources.Rune_platelegs;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune platelegs x 1"]);
					pictureBox22.BackgroundImage = Resources.Dragon_longsword;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon longsword x 1"]);
					pictureBox23.BackgroundImage = Resources.Dragon_med_helm;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon med helm x 1"]);
					pictureBox24.BackgroundImage = Resources.Scb_range_magic_potion__2_;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super combat potion (2) x 1, ranging potion (2) x 1, magic potion (2) x 1"]);
					pictureBox25.BackgroundImage = Resources.Adamant_boots;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamant boots x 1"]);
					pictureBox26.BackgroundImage = Resources.Mushroom_potato;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mushroom potato x 5"]);
					pictureBox27.BackgroundImage = Resources.Crystal_key;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Crystal key x 1"]);
					pictureBox28.BackgroundImage = Resources.Granite_maul;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Granite maul x 1"]);
					pictureBox29.BackgroundImage = Resources.Granite_gloves;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Granite gloves x 1"]);
					pictureBox30.BackgroundImage = Resources.Granite_ring;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Granite ring x 1"]);
					pictureBox31.BackgroundImage = Resources.Granite_hammer;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Granite hammer x 1"]);
					pictureBox32.BackgroundImage = Resources.Black_tourmaline_core;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Black tourmaline core x 1"]);
					pictureBox33.BackgroundImage = Resources.Coins_10000;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox34.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox35.BackgroundImage = Resources.Jar_of_stone;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Jar of stone x 1"]);
					pictureBox36.BackgroundImage = Resources.Noon;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Noon x 1"]);
					setNPictureBoxesToVisible(36);
					setNPictureBoxesToDisabled(36);
					break;

				case "Kalphite Queen":
					pictureBox1.BackgroundImage = Resources.Battlestaff_noted_generic;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff x 10"]);
					pictureBox2.BackgroundImage = Resources.Lava_battlestaff;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Lava battlestaff x 1"]);
					pictureBox3.BackgroundImage = Resources.Mithril_arrow_generic;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril arrow x 500"]);
					pictureBox4.BackgroundImage = Resources.Rune_arrow_generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune arrow x 250"]);
					pictureBox5.BackgroundImage = Resources.Rune_knife__p____generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune knife (p++) x 25"]);
					pictureBox6.BackgroundImage = Resources.Red_d_hide_body;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Red d'hide body x 1"]);
					pictureBox7.BackgroundImage = Resources.Rune_chainbody;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune chainbody x 1"]);
					pictureBox8.BackgroundImage = Resources.Grapes_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grapes x 100"]);
					pictureBox9.BackgroundImage = Resources.Super_combat_potion__2_;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super combat potion (2) x 1"]);
					pictureBox10.BackgroundImage = Resources.Superantipoison__2_;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Superantipoison (2) x 1"]);
					pictureBox11.BackgroundImage = Resources.Ranging_potion__3_;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranging potion (3) x 1"]);
					pictureBox12.BackgroundImage = Resources.Saradomin_brew__4_;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saradomin brew (4) x 1"]);
					pictureBox13.BackgroundImage = Resources.Super_restore__4_;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Super restore (4) x 1"]);
					pictureBox14.BackgroundImage = Resources.Prayer_potion__4_;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prayer potion (4) x 2"]);
					pictureBox15.BackgroundImage = Resources.Weapon_poison______noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Weapon poison (++) x 5"]);
					pictureBox16.BackgroundImage = Resources.Wine_of_zamorak_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Wine of zamorak x 60"]);
					pictureBox17.BackgroundImage = Resources.Uncut_emerald_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut Emerald x 25"]);
					pictureBox18.BackgroundImage = Resources.Uncut_ruby_noted_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut ruby x 25"]);
					pictureBox19.BackgroundImage = Resources.Uncut_diamond_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond x 25"]);
					pictureBox20.BackgroundImage = Resources.Watermelon_seed_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Watermelon seed x 25"]);
					pictureBox21.BackgroundImage = Resources.Torstol_seed_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol seed x 2"]);
					pictureBox22.BackgroundImage = Resources.Papaya_tree_seed_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Papaya tree seed x 2"]);
					pictureBox23.BackgroundImage = Resources.Palm_tree_seed_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Palm tree seed x 1"]);
					pictureBox24.BackgroundImage = Resources.Magic_seed_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 2"]);
					pictureBox25.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 100"]);
					pictureBox26.BackgroundImage = Resources.Death_rune_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 100"]);
					pictureBox27.BackgroundImage = Resources.Potato_cactus_noted_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Potato cactus x 100"]);
					pictureBox28.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs x 60"]);
					pictureBox29.BackgroundImage = Resources.Toadflax_noted_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Toadflax x 25"]);
					pictureBox30.BackgroundImage = Resources.Ranarr_weed_noted_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranarr weed x 25"]);
					pictureBox31.BackgroundImage = Resources.Snapdragon_noted_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon x 25"]);
					pictureBox32.BackgroundImage = Resources.Torstol_noted_generic;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol x 25"]);
					pictureBox33.BackgroundImage = Resources.Runite_bar_noted_generic;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bar x 3"]);
					pictureBox34.BackgroundImage = Resources.Bucket_of_sand_noted_generic;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bucket of sand x 100"]);
					pictureBox35.BackgroundImage = Resources.Cactus_spine_noted_generic;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Cactus spine x 10"]);
					pictureBox36.BackgroundImage = Resources.Gold_ore_noted_generic;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold ore x 250"]);
					pictureBox37.BackgroundImage = Resources.Ensouled_kalphite_head;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ensouled kalphite head x 1"]);
					pictureBox38.BackgroundImage = Resources.Monkfish;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Monkfish x 3"]);
					pictureBox39.BackgroundImage = Resources.Shark;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 2"]);
					pictureBox40.BackgroundImage = Resources.Dark_crab;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark crab x 2"]);
					pictureBox41.BackgroundImage = Resources.Coins_10000;
					pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox42.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox43.BackgroundImage = Resources.Dragon_2h_sword;
					pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon 2h sword x 1"]);
					pictureBox44.BackgroundImage = Resources.Dragon_chainbody;
					pictureBox44.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon chainbody x 1"]);
					pictureBox45.BackgroundImage = Resources.Kq_head;
					pictureBox45.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Kq head x 1"]);
					pictureBox46.BackgroundImage = Resources.Jar_of_sand;
					pictureBox46.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Jar of sand x 1"]);
					pictureBox47.BackgroundImage = Resources.Kalphite_princess;
					pictureBox47.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Kalphite princess x 1"]);
					pictureBox48.BackgroundImage = Resources.RDT;
					pictureBox48.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(48);
					setNPictureBoxesToDisabled(48);
					break;

				case "Kraken":
					pictureBox1.BackgroundImage = Resources.Rune_warhammer;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune warhammer x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_longsword;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune longsword x 1"]);
					pictureBox3.BackgroundImage = Resources.Mystic_water_staff;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic water staff x 1"]);
					pictureBox4.BackgroundImage = Resources.Mystic_robe_top__blue_;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic robe top (blue) x 1"]);
					pictureBox5.BackgroundImage = Resources.Mystic_robe_bottom__blue_;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic robe bottom (blue) x 1"]);
					pictureBox6.BackgroundImage = Resources.Harpoon;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Harpoon x 1"]);
					pictureBox7.BackgroundImage = Resources.Seaweed_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Seaweed x 125"]);
					pictureBox8.BackgroundImage = Resources.Battlestaff_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff x 10"]);
					pictureBox9.BackgroundImage = Resources.Water_rune_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Water rune x 400"]);
					pictureBox10.BackgroundImage = Resources.Mist_rune_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mist rune x 100"]);
					pictureBox11.BackgroundImage = Resources.Chaos_rune_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune x 250"]);
					pictureBox12.BackgroundImage = Resources.Death_rune_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 150"]);
					pictureBox13.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 60"]);
					pictureBox14.BackgroundImage = Resources.Soul_rune_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Soul rune x 50"]);
					pictureBox15.BackgroundImage = Resources.Unpowered_orb_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Unpowered orb x 50"]);
					pictureBox16.BackgroundImage = Resources.Diamond_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Diamond x 8"]);
					pictureBox17.BackgroundImage = Resources.Oak_plank_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Oak plank x 60"]);
					pictureBox18.BackgroundImage = Resources.Raw_shark_noted_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw shark x 50"]);
					pictureBox19.BackgroundImage = Resources.Raw_monkfish_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw monkfish x 100"]);
					pictureBox20.BackgroundImage = Resources.Runite_bar;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bar x 2"]);
					pictureBox21.BackgroundImage = Resources.Grimy_snapdragon_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy snapdragon x 6"]);
					pictureBox22.BackgroundImage = Resources.Shark;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shark x 5"]);
					pictureBox23.BackgroundImage = Resources.Edible_seaweed;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Edible seaweed x 5"]);
					pictureBox24.BackgroundImage = Resources.Bucket;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bucket x 1"]);
					pictureBox25.BackgroundImage = Resources.Sanfew_serum__4_;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Sanfew serum (4) x 2"]);
					pictureBox26.BackgroundImage = Resources.Crystal_key;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Crystal key x 1"]);
					pictureBox27.BackgroundImage = Resources.Rusty_sword;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rusty sword x 1"]);
					pictureBox28.BackgroundImage = Resources.Antidote____4__noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Antidote++ (4) x 2"]);
					pictureBox29.BackgroundImage = Resources.Watermelon_seed_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Watermelon seed x 24"]);
					pictureBox30.BackgroundImage = Resources.Torstol_seed_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol seed x 2"]);
					pictureBox31.BackgroundImage = Resources.Magic_seed_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 1"]);
					pictureBox32.BackgroundImage = Resources.Pirate_boots;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pirate boots x 1"]);
					pictureBox33.BackgroundImage = Resources.Coins_generic;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox34.BackgroundImage = Resources.Dragonstone_ring;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragonstone ring x 1"]);
					pictureBox35.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox36.BackgroundImage = Resources.Trident_of_the_seas__full_;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Trident of the seas (full) x 1"]);
					pictureBox37.BackgroundImage = Resources.Kraken_tentacle;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Kraken tentacle x 1"]);
					pictureBox38.BackgroundImage = Resources.Jar_of_dirt;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Jar of dirt x 1"]);
					pictureBox39.BackgroundImage = Resources.Pet_kraken;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet kraken x 1"]);
					pictureBox40.BackgroundImage = Resources.RDT;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(40);
					setNPictureBoxesToDisabled(40);
					break;

				case "Raids":
					pictureBox1.BackgroundImage = Resources.Death_rune_generic;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune"]);
					pictureBox2.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune"]);
					pictureBox3.BackgroundImage = Resources.Soul_rune_generic;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Soul rune"]);
					pictureBox4.BackgroundImage = Resources.Rune_arrow_generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune arrow"]);
					pictureBox5.BackgroundImage = Resources.Dragon_arrow_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon arrow"]);
					pictureBox6.BackgroundImage = Resources.Grimy_toadflax_noted_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy toadflax"]);
					pictureBox7.BackgroundImage = Resources.Grimy_ranarr_weed_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed"]);
					pictureBox8.BackgroundImage = Resources.Grimy_irit_leaf_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy irit leaf"]);
					pictureBox9.BackgroundImage = Resources.Grimy_avantoe_noted_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy avantoe"]);
					pictureBox10.BackgroundImage = Resources.Grimy_kwuarm_noted_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy kwuarm"]);
					pictureBox11.BackgroundImage = Resources.Grimy_snapdragon_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy snapdragon"]);
					pictureBox12.BackgroundImage = Resources.Grimy_cadantine_noted_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy cadantine"]);
					pictureBox13.BackgroundImage = Resources.Grimy_lantadyme_noted_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy lantadyme"]);
					pictureBox14.BackgroundImage = Resources.Grimy_dwarf_weed_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy dwarf weed"]);
					pictureBox15.BackgroundImage = Resources.Grimy_torstol_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy torstol"]);
					pictureBox16.BackgroundImage = Resources.Silver_ore_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Silver ore"]);
					pictureBox17.BackgroundImage = Resources.Coal_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal"]);
					pictureBox18.BackgroundImage = Resources.Gold_ore_noted_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold ore"]);
					pictureBox19.BackgroundImage = Resources.Mithril_ore_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril ore"]);
					pictureBox20.BackgroundImage = Resources.Adamantite_ore_noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite ore"]);
					pictureBox21.BackgroundImage = Resources.Runite_ore_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite ore"]);
					pictureBox22.BackgroundImage = Resources.Saltpetre_noted_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saltpetre"]);
					pictureBox23.BackgroundImage = Resources.Teak_plank_noted_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Teak plank"]);
					pictureBox24.BackgroundImage = Resources.Mahogany_plank_noted_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mahogany plank"]);
					pictureBox25.BackgroundImage = Resources.Uncut_sapphire_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut sapphire"]);
					pictureBox26.BackgroundImage = Resources.Uncut_emerald_noted_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut emerald"]);
					pictureBox27.BackgroundImage = Resources.Uncut_ruby_noted_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut ruby"]);
					pictureBox28.BackgroundImage = Resources.Uncut_diamond_noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond"]);
					pictureBox29.BackgroundImage = Resources.Pure_essence_noted_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence"]);
					pictureBox30.BackgroundImage = Resources.Dynamite_noted_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dynamite"]);
					pictureBox31.BackgroundImage = Resources.Lizardman_fang_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Lizardman fang"]);
					pictureBox32.BackgroundImage = Resources.Torn_prayer_scroll;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torn prayer scroll x 1"]);
					pictureBox33.BackgroundImage = Resources.Ancient_tablet;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ancient tablet x 1"]);
					pictureBox34.BackgroundImage = Resources.Dark_relic;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark relic x 1"]);
					pictureBox35.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox36.BackgroundImage = Resources.Arcane_prayer_scroll;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Arcane prayer scroll x 1"]);
					pictureBox37.BackgroundImage = Resources.Dexterous_prayer_scroll;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dexterous prayer scroll x 1"]);
					pictureBox38.BackgroundImage = Resources.Dragon_sword;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon sword x 1"]);
					pictureBox39.BackgroundImage = Resources.Dragon_thrownaxe_generic;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon thrownaxe x 100"]);
					pictureBox40.BackgroundImage = Resources.Twisted_buckler;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Twisted buckler x 1"]);
					pictureBox41.BackgroundImage = Resources.Dragon_hunter_crossbow;
					pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon hunter crossbow x 1"]);
					pictureBox42.BackgroundImage = Resources.Dinh_s_bulwark;
					pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dinh's bulwark x 1"]);
					pictureBox43.BackgroundImage = Resources.Ancestral_hat;
					pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ancestral hat x 1"]);
					pictureBox44.BackgroundImage = Resources.Ancestral_robe_top;
					pictureBox44.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ancestral robe top x 1"]);
					pictureBox45.BackgroundImage = Resources.Ancestral_robe_bottom;
					pictureBox45.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ancestral robe bottom x 1"]);
					pictureBox46.BackgroundImage = Resources.Dragon_claws;
					pictureBox46.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon claws x 1"]);
					pictureBox47.BackgroundImage = Resources.Elder_maul;
					pictureBox47.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elder maul x 1"]);
					pictureBox48.BackgroundImage = Resources.Kodai_insignia;
					pictureBox48.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Kodai insignia x 1"]);
					//pictureBox49.BackgroundImage = Resources.Twisted_bow;
					pictureBox49.BackgroundImage = Resources.Twisted_bow;
					pictureBox49.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Twisted bow x 1"]);
					pictureBox50.BackgroundImage = Resources.Olmlet;
					pictureBox50.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Olmlet x 1"]);

					setNPictureBoxesToVisible(50);
					setNPictureBoxesToDisabled(50);
					break;

				case "Skotizo":
					pictureBox1.BackgroundImage = Resources.Death_rune_generic;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 500"]);
					pictureBox2.BackgroundImage = Resources.Soul_rune_generic;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Soul rune x 450"]);
					pictureBox3.BackgroundImage = Resources.Blood_rune_generic;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blood rune x 450"]);
					pictureBox4.BackgroundImage = Resources.Rune_platebody_noted_generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune platebody x 3"]);
					pictureBox5.BackgroundImage = Resources.Rune_kiteshield_noted_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune kiteshield x 3"]);
					pictureBox6.BackgroundImage = Resources.Rune_platelegs_noted_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune platelegs x 3"]);
					pictureBox7.BackgroundImage = Resources.Rune_plateskirt_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune plateskirt x 3"]);
					pictureBox8.BackgroundImage = Resources.Grimy_ranarr_weed_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed x 40"]);
					pictureBox9.BackgroundImage = Resources.Grimy_snapdragon_noted_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy snapdragon x 20"]);
					pictureBox10.BackgroundImage = Resources.Grimy_torstol_noted_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy torstol x 20"]);
					pictureBox11.BackgroundImage = Resources.Battlestaff_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff x 25"]);
					pictureBox12.BackgroundImage = Resources.Uncut_dragonstone_noted_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut dragonstone x 10"]);
					pictureBox13.BackgroundImage = Resources.Adamantite_ore_noted_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite ore x 75"]);
					pictureBox14.BackgroundImage = Resources.Runite_bar_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite bar x 20"]);
					pictureBox15.BackgroundImage = Resources.Raw_anglerfish_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw anglerfish x 60"]);
					pictureBox16.BackgroundImage = Resources.Mahogany_plank_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mahogany plank x 150"]);
					pictureBox17.BackgroundImage = Resources.Shield_left_half;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Shield left half x 1"]);
					pictureBox18.BackgroundImage = Resources.Dark_totem_base;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark totem base x 1"]);
					pictureBox19.BackgroundImage = Resources.Dark_totem_middle;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark totem middle x 1"]);
					pictureBox20.BackgroundImage = Resources.Dark_totem_top;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark totem top x 1"]);
					pictureBox21.BackgroundImage = Resources.Dark_totem;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dark totem x 1"]);
					pictureBox22.BackgroundImage = Resources.Onyx_bolt_tips_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Onyx bolt tips x 40"]);
					pictureBox23.BackgroundImage = Resources.Uncut_onyx;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut onyx x 1"]);
					pictureBox24.BackgroundImage = Resources.Hard_clue_scroll;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Hard clue scroll x 1"]);
					pictureBox25.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox26.BackgroundImage = Resources.Jar_of_darkness;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Jar of darkness x 1"]);

					setNPictureBoxesToVisible(26);
					setNPictureBoxesToDisabled(26);
					break;

				case "Thermonuclear Smoke Devil":
					pictureBox1.BackgroundImage = Resources.Rune_dagger;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune dagger x 1"]);
					pictureBox2.BackgroundImage = Resources.Rune_scimitar;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune scimitar x 1"]);
					pictureBox3.BackgroundImage = Resources.Rune_battleaxe;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune battleaxe x 1"]);
					pictureBox4.BackgroundImage = Resources.Mystic_air_staff;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic air staff x 1"]);
					pictureBox5.BackgroundImage = Resources.Mystic_fire_staff;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mystic fire staff x 1"]);
					pictureBox6.BackgroundImage = Resources.Dragon_scimitar;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon scimitar x 1"]);
					pictureBox7.BackgroundImage = Resources.Fire_talisman;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Fire talisman x 1"]);
					pictureBox8.BackgroundImage = Resources.Ancient_staff;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ancient staff x 1"]);
					pictureBox9.BackgroundImage = Resources.Red_d_hide_body;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Red d'hide body x 1"]);
					pictureBox10.BackgroundImage = Resources.Rune_chainbody;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune chainbody x 1"]);
					pictureBox11.BackgroundImage = Resources.Smoke_rune_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dust rune x 100"]);
					pictureBox12.BackgroundImage = Resources.Air_rune_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Air rune x 300"]);
					pictureBox13.BackgroundImage = Resources.Soul_rune_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Soul rune x 60"]);
					pictureBox14.BackgroundImage = Resources.Rune_knife__p____generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune knife (p++) x 50"]);
					pictureBox15.BackgroundImage = Resources.Rune_arrow_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune arrow x 100"]);
					pictureBox16.BackgroundImage = Resources.Snapdragon_seed_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon seed x 1"]);
					pictureBox17.BackgroundImage = Resources.Magic_seed_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 1"]);
					pictureBox18.BackgroundImage = Resources.Pure_essence_noted_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence x 300"]);
					pictureBox19.BackgroundImage = Resources.Desert_goat_horn_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Desert goat horn x 50"]);
					pictureBox20.BackgroundImage = Resources.Molten_glass_noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Molten glass x 100"]);
					pictureBox21.BackgroundImage = Resources.Mithril_bar_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril bar x 20"]);
					pictureBox22.BackgroundImage = Resources.Grimy_toadflax_noted_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy toadflax x 15"]);
					pictureBox23.BackgroundImage = Resources.Coal_noted_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal x 150"]);
					pictureBox24.BackgroundImage = Resources.Gold_ore_noted_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold ore x 200"]);
					pictureBox25.BackgroundImage = Resources.Onyx_bolt_tips_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Onyx bolt tips x 12"]);
					pictureBox26.BackgroundImage = Resources.Grapes_noted_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grapes x 100"]);
					pictureBox27.BackgroundImage = Resources.Diamond_noted_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Diamond x 10"]);
					pictureBox28.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs x 20"]);
					pictureBox29.BackgroundImage = Resources.Ugthanki_kebab;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ugthanki kebab x 3"]);
					pictureBox30.BackgroundImage = Resources.Tuna_potato;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tuna potato x 3"]);
					pictureBox31.BackgroundImage = Resources.Prayer_potion__4_;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Prayer potion (4) x 2"]);
					pictureBox32.BackgroundImage = Resources.Sanfew_serum__4_;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Sanfew serum (4) x 2"]);
					pictureBox33.BackgroundImage = Resources.Tinderbox;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tinderbox x 1"]);
					pictureBox34.BackgroundImage = Resources.Coins_generic;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox35.BackgroundImage = Resources.Bullseye_lantern__unlit_;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bullseye lantern (unlit) x 1"]);
					pictureBox36.BackgroundImage = Resources.Dragonstone_ring;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragonstone ring x 1"]);
					pictureBox37.BackgroundImage = Resources.Crystal_key;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Crystal key x 1"]);
					pictureBox38.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox39.BackgroundImage = Resources.Smoke_battlestaff;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Smoke battlestaff x 1"]);
					pictureBox40.BackgroundImage = Resources.Occult_necklace;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Occult necklace x 1"]);
					pictureBox41.BackgroundImage = Resources.Dragon_chainbody;
					pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon chainbody x 1"]);
					pictureBox42.BackgroundImage = Resources.Pet_smoke_devil;
					pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet smoke devil x 1"]);
					pictureBox43.BackgroundImage = Resources.RDT;
					pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(43);
					setNPictureBoxesToDisabled(43);
					break;

				case "Vorkath":
					pictureBox1.BackgroundImage = Resources.Rune_longsword;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune longsword"]);
					pictureBox2.BackgroundImage = Resources.Dragon_battleaxe;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon battleaxe x 1"]);
					pictureBox3.BackgroundImage = Resources.Dragon_longsword;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon longsword x 1"]);
					pictureBox4.BackgroundImage = Resources.Dragon_platelegs;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon platelegs x 1"]);
					pictureBox5.BackgroundImage = Resources.Dragon_plateskirt;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon plateskirt x 1"]);
					pictureBox6.BackgroundImage = Resources.Chaos_rune_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune"]);
					pictureBox7.BackgroundImage = Resources.Death_rune_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune"]);
					pictureBox8.BackgroundImage = Resources.Wrath_rune_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Wrath rune"]);
					pictureBox9.BackgroundImage = Resources.Rune_kiteshield;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune kiteshield"]);
					pictureBox10.BackgroundImage = Resources.Sapphire_bolt_tips_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Sapphire bolt tips"]);
					pictureBox11.BackgroundImage = Resources.Emerald_bolt_tips_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Emerald bolt tips"]);
					pictureBox12.BackgroundImage = Resources.Ruby_bolt_tips_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ruby bolt tips"]);
					pictureBox13.BackgroundImage = Resources.Diamond_bolt_tips_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Diamond bolt tips"]);
					pictureBox14.BackgroundImage = Resources.Amethyst_bolt_tips_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Amethyst bolt tips"]);
					pictureBox15.BackgroundImage = Resources.Dragon_bolt_tips_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bolt tips"]);
					pictureBox16.BackgroundImage = Resources.Onyx_bolt_tips_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Onyx bolt tips"]);
					pictureBox17.BackgroundImage = Resources.Rune_dart_tips_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Rune dart tips"]);
					pictureBox18.BackgroundImage = Resources.Dragon_dart_tips_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon dart tips"]);
					pictureBox19.BackgroundImage = Resources.Dragon_arrowtips_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon arrowtips"]);
					pictureBox20.BackgroundImage = Resources.Dragon_bolts__unf__generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bolts (unf)"]);
					pictureBox21.BackgroundImage = Resources.Diamond_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Diamond"]);
					pictureBox22.BackgroundImage = Resources.Dragonstone_noted_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragonstone"]);
					pictureBox23.BackgroundImage = Resources.Adamantite_bar_noted_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite bar"]);
					pictureBox24.BackgroundImage = Resources.Adamantite_ore_noted_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite ore"]);
					pictureBox25.BackgroundImage = Resources.Green_dragonhide_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Green dragonhide"]);
					pictureBox26.BackgroundImage = Resources.Blue_dragonhide_noted_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Blue dragonhide"]);
					pictureBox27.BackgroundImage = Resources.Red_dragonhide_noted_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Red dragonhide"]);
					pictureBox28.BackgroundImage = Resources.Black_dragonhide_noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Black dragonhide"]);
					pictureBox29.BackgroundImage = Resources.Battlestaff_noted_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff"]);
					pictureBox30.BackgroundImage = Resources.Dragon_bones_noted_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bones"]);
					pictureBox31.BackgroundImage = Resources.Grapes_noted_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grapes"]);
					pictureBox32.BackgroundImage = Resources.Manta_ray_noted_generic;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Manta ray"]);
					pictureBox33.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs x 50"]);
					pictureBox34.BackgroundImage = Resources.Crushed_nest_noted_generic;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Crushed nest"]);
					pictureBox35.BackgroundImage = Resources.Ranarr_seed_generic;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranarr seed"]);
					pictureBox36.BackgroundImage = Resources.Snapdragon_seed_generic;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon seed"]);
					pictureBox37.BackgroundImage = Resources.Torstol_seed_generic;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol seed"]);
					pictureBox38.BackgroundImage = Resources.Watermelon_seed_generic;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Watermelon seed x 15"]);
					pictureBox39.BackgroundImage = Resources.Teak_seed_generic;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Teak seed"]);
					pictureBox40.BackgroundImage = Resources.Mahogany_seed_generic;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mahogany seed"]);
					pictureBox41.BackgroundImage = Resources.Papaya_tree_seed_generic;
					pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Papaya tree seed"]);
					pictureBox42.BackgroundImage = Resources.Palm_tree_seed_generic;
					pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Palm tree seed"]);
					pictureBox43.BackgroundImage = Resources.Calquat_tree_seed_generic;
					pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Calquat tree seed"]);
					pictureBox44.BackgroundImage = Resources.Willow_seed_generic;
					pictureBox44.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Willow seed"]);
					pictureBox45.BackgroundImage = Resources.Maple_seed_generic;
					pictureBox45.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Maple seed"]);
					pictureBox46.BackgroundImage = Resources.Yew_seed_generic;
					pictureBox46.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew seed"]);
					pictureBox47.BackgroundImage = Resources.Magic_seed_generic;
					pictureBox47.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed"]);
					pictureBox48.BackgroundImage = Resources.Spirit_seed_generic;
					pictureBox48.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Spirit seed"]);
					pictureBox49.BackgroundImage = Resources.Coins_10000;
					pictureBox49.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox50.BackgroundImage = Resources.Wrath_talisman;
					pictureBox50.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Wrath talisman x 1"]);
					pictureBox51.BackgroundImage = Resources.Superior_dragon_bones;
					pictureBox51.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Superior dragon bones"]);
					pictureBox52.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox52.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox53.BackgroundImage = Resources.Vorkath_s_head;
					pictureBox53.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Vorkath's head x 1"]);
					pictureBox54.BackgroundImage = Resources.Dragonbone_necklace;
					pictureBox54.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragonbone necklace x 1"]);
					pictureBox55.BackgroundImage = Resources.Draconic_visage;
					pictureBox55.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Draconic visage x 1"]);
					pictureBox56.BackgroundImage = Resources.Skeletal_visage;
					pictureBox56.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Skeletal visage x 1"]);
					pictureBox57.BackgroundImage = Resources.Jar_of_decay;
					pictureBox57.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Jar of decay x 1"]);
					pictureBox58.BackgroundImage = Resources.Vorki;
					pictureBox58.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Vorki x 1"]);
					pictureBox59.BackgroundImage = Resources.RDT;
					pictureBox59.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);
					setNPictureBoxesToVisible(59);
					setNPictureBoxesToDisabled(59);
					break;

				case "Wintertodt":
					pictureBox1.BackgroundImage = Resources.Oak_logs_noted_generic;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Oak logs"]);
					pictureBox2.BackgroundImage = Resources.Willow_logs_noted_generic;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Willow logs"]);
					pictureBox3.BackgroundImage = Resources.Maple_logs_noted_generic;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Maple logs"]);
					pictureBox4.BackgroundImage = Resources.Teak_logs_noted_generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Teak logs"]);
					pictureBox5.BackgroundImage = Resources.Mahogany_logs_noted_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mahogany logs"]);
					pictureBox6.BackgroundImage = Resources.Yew_logs_noted_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew logs"]);
					pictureBox7.BackgroundImage = Resources.Magic_logs_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic logs"]);
					pictureBox8.BackgroundImage = Resources.Pure_essence_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence"]);
					pictureBox9.BackgroundImage = Resources.Uncut_sapphire_noted_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut sapphire"]);
					pictureBox10.BackgroundImage = Resources.Uncut_emerald_noted_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut emerald"]);
					pictureBox11.BackgroundImage = Resources.Uncut_ruby_noted_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut ruby"]);
					pictureBox12.BackgroundImage = Resources.Uncut_diamond_noted_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut diamond"]);
					pictureBox13.BackgroundImage = Resources.Coal_noted_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal"]);
					pictureBox14.BackgroundImage = Resources.Iron_ore_noted_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Iron ore"]);
					pictureBox15.BackgroundImage = Resources.Silver_ore_noted_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Silver ore"]);
					pictureBox16.BackgroundImage = Resources.Gold_ore_noted_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Gold ore"]);
					pictureBox17.BackgroundImage = Resources.Mithril_ore_noted_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mithril ore"]);
					pictureBox18.BackgroundImage = Resources.Adamantite_ore_noted_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite ore"]);
					pictureBox19.BackgroundImage = Resources.Runite_ore_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite ore"]);
					pictureBox20.BackgroundImage = Resources.Grimy_guam_leaf_noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy guam leaf"]);
					pictureBox21.BackgroundImage = Resources.Grimy_marrentill_noted_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy marrentill"]);
					pictureBox22.BackgroundImage = Resources.Grimy_harralander_noted_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy harralander"]);
					pictureBox23.BackgroundImage = Resources.Grimy_ranarr_weed_noted_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy ranarr weed"]);
					pictureBox24.BackgroundImage = Resources.Grimy_avantoe_noted_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy avantoe"]);
					pictureBox25.BackgroundImage = Resources.Grimy_cadantine_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy cadantine"]);
					pictureBox26.BackgroundImage = Resources.Grimy_torstol_noted_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy torstol"]);
					pictureBox27.BackgroundImage = Resources.Grimy_kwuarm_noted_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grimy kwuarm"]);
					pictureBox28.BackgroundImage = Resources.Tarromin_seed_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tarromin seed"]);
					pictureBox29.BackgroundImage = Resources.Harralander_seed_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Harralander seed"]);
					pictureBox30.BackgroundImage = Resources.Toadflax_seed_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Toadflax seed"]);
					pictureBox31.BackgroundImage = Resources.Ranarr_seed_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Ranarr seed"]);
					pictureBox32.BackgroundImage = Resources.Avantoe_seed_generic;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Avantoe seed"]);
					pictureBox33.BackgroundImage = Resources.Snapdragon_seed_generic;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon seed"]);
					pictureBox34.BackgroundImage = Resources.Watermelon_seed_generic;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Watermelon seed"]);
					pictureBox35.BackgroundImage = Resources.Teak_seed_generic;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Teak seed"]);
					pictureBox36.BackgroundImage = Resources.Mahogany_seed_generic;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mahogany seed"]);
					pictureBox37.BackgroundImage = Resources.Banana_tree_seed_generic;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Banana tree seed"]);
					pictureBox38.BackgroundImage = Resources.Acorn_generic;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Acorn x 1"]);
					pictureBox39.BackgroundImage = Resources.Willow_seed_generic;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Willow seed"]);
					pictureBox40.BackgroundImage = Resources.Maple_seed_generic;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Maple seed"]);
					pictureBox41.BackgroundImage = Resources.Yew_seed_generic;
					pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew seed"]);
					pictureBox42.BackgroundImage = Resources.Magic_seed_generic;
					pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 1"]);
					pictureBox43.BackgroundImage = Resources.Spirit_seed_generic;
					pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Spirit seed x 1"]);
					pictureBox44.BackgroundImage = Resources.Raw_anchovies_noted_generic;
					pictureBox44.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw anchovies"]);
					pictureBox45.BackgroundImage = Resources.Raw_trout_noted_generic;
					pictureBox45.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw trout"]);
					pictureBox46.BackgroundImage = Resources.Raw_salmon_noted_generic;
					pictureBox46.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw salmon"]);
					pictureBox47.BackgroundImage = Resources.Raw_lobster_noted_generic;
					pictureBox47.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw lobster"]);
					pictureBox48.BackgroundImage = Resources.Raw_tuna_noted_generic;
					pictureBox48.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw tuna"]);
					pictureBox49.BackgroundImage = Resources.Raw_swordfish_noted_generic;
					pictureBox49.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw swordfish"]);
					pictureBox50.BackgroundImage = Resources.Raw_shark_noted_generic;
					pictureBox50.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Raw shark"]);
					pictureBox51.BackgroundImage = Resources.Saltpetre_noted_generic;
					pictureBox51.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Saltpetre"]);
					pictureBox52.BackgroundImage = Resources.Limestone_noted_generic;
					pictureBox52.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Limestone"]);
					pictureBox53.BackgroundImage = Resources.Dynamite_noted_generic;
					pictureBox53.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dynamite"]);
					pictureBox54.BackgroundImage = Resources.Coins_generic;
					pictureBox54.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coins"]);
					pictureBox55.BackgroundImage = Resources.Burnt_page;
					pictureBox55.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Burnt page"]);
					pictureBox56.BackgroundImage = Resources.Bruma_torch;
					pictureBox56.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Bruma torch x 1"]);
					pictureBox57.BackgroundImage = Resources.Dragon_axe;
					pictureBox57.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon axe x 1"]);
					pictureBox58.BackgroundImage = Resources.Pyromancer_hood;
					pictureBox58.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pyromancer hood x 1"]);
					pictureBox59.BackgroundImage = Resources.Pyromancer_garb;
					pictureBox59.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pyromancer garb x 1"]);
					pictureBox60.BackgroundImage = Resources.Pyromancer_robe;
					pictureBox60.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pyromancer robe x 1"]);
					pictureBox61.BackgroundImage = Resources.Pyromancer_boots;
					pictureBox61.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pyromancer boots x 1"]);
					pictureBox62.BackgroundImage = Resources.Warm_gloves;
					pictureBox62.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Warm gloves x 1"]);
					pictureBox63.BackgroundImage = Resources.Tome_of_fire__empty_;
					pictureBox63.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tome of fire (empty) x 1"]);
					pictureBox64.BackgroundImage = Resources.Phoenix;
					pictureBox64.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Phoenix x 1"]);
					pictureBox65.BackgroundImage = Resources.RDT;
					pictureBox65.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(65);
					setNPictureBoxesToDisabled(65);
					break;

				case "Zulrah":
					pictureBox1.BackgroundImage = Resources.Pure_essence_noted_generic;
					pictureBox1.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pure essence x 1500"]);
					pictureBox2.BackgroundImage = Resources.Law_rune_generic;
					pictureBox2.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Law rune x 200"]);
					pictureBox3.BackgroundImage = Resources.Chaos_rune_generic;
					pictureBox3.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Chaos rune x 500"]);
					pictureBox4.BackgroundImage = Resources.Death_rune_generic;
					pictureBox4.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Death rune x 300"]);
					pictureBox5.BackgroundImage = Resources.Toadflax_noted_generic;
					pictureBox5.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Toadflax x 25"]);
					pictureBox6.BackgroundImage = Resources.Snapdragon_noted_generic;
					pictureBox6.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon x 10"]);
					pictureBox7.BackgroundImage = Resources.Dwarf_weed_noted_generic;
					pictureBox7.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dwarf weed x 30"]);
					pictureBox8.BackgroundImage = Resources.Torstol_noted_generic;
					pictureBox8.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol x 10"]);
					pictureBox9.BackgroundImage = Resources.Toadflax_seed_generic;
					pictureBox9.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Toadflax seed x 2"]);
					pictureBox10.BackgroundImage = Resources.Snapdragon_seed_generic;
					pictureBox10.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snapdragon seed x 1"]);
					pictureBox11.BackgroundImage = Resources.Dwarf_weed_seed_generic;
					pictureBox11.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dwarf weed seed x 2"]);
					pictureBox12.BackgroundImage = Resources.Torstol_seed_generic;
					pictureBox12.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Torstol seed x 1"]);
					pictureBox13.BackgroundImage = Resources.Papaya_tree_seed_generic;
					pictureBox13.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Papaya tree seed x 3"]);
					pictureBox14.BackgroundImage = Resources.Palm_tree_seed_generic;
					pictureBox14.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Palm tree seed x 1"]);
					pictureBox15.BackgroundImage = Resources.Magic_seed_generic;
					pictureBox15.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic seed x 1"]);
					pictureBox16.BackgroundImage = Resources.Calquat_tree_seed_generic;
					pictureBox16.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Calquat seed x 2"]);
					pictureBox17.BackgroundImage = Resources.Spirit_seed_generic;
					pictureBox17.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Spirit seed x 1"]);
					pictureBox18.BackgroundImage = Resources.Crystal_seed_generic;
					pictureBox18.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Crystal seed x 1"]);
					pictureBox19.BackgroundImage = Resources.Flax_noted_generic;
					pictureBox19.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Flax x 1000"]);
					pictureBox20.BackgroundImage = Resources.Snakeskin_noted_generic;
					pictureBox20.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Snakeskin x 35"]);
					pictureBox21.BackgroundImage = Resources.Dragon_bolt_tips_generic;
					pictureBox21.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bolt tips x 12"]);
					pictureBox22.BackgroundImage = Resources.Yew_logs_noted_generic;
					pictureBox22.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Yew logs x 35"]);
					pictureBox23.BackgroundImage = Resources.Coal_noted_generic;
					pictureBox23.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coal x 200"]);
					pictureBox24.BackgroundImage = Resources.Runite_ore_noted_generic;
					pictureBox24.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Runite ore x 2"]);
					pictureBox25.BackgroundImage = Resources.Adamantite_bar_noted_generic;
					pictureBox25.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Adamantite bar x 20"]);
					pictureBox26.BackgroundImage = Resources.Mahogany_logs_noted_generic;
					pictureBox26.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Mahogany logs x 50"]);
					pictureBox27.BackgroundImage = Resources.Dragon_bones_noted_generic;
					pictureBox27.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon bones x 12"]);
					pictureBox28.BackgroundImage = Resources.Coconut_noted_generic;
					pictureBox28.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Coconut x 20"]);
					pictureBox29.BackgroundImage = Resources.Grapes_noted_generic;
					pictureBox29.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Grapes x 250"]);
					pictureBox30.BackgroundImage = Resources.Zul_andra_teleport_generic;
					pictureBox30.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Zul-andra teleport x 4"]);
					pictureBox31.BackgroundImage = Resources.Zulrah_s_scales_generic;
					pictureBox31.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Zulrah's scales x 500"]);
					pictureBox32.BackgroundImage = Resources.Battlestaff_noted_generic;
					pictureBox32.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Battlestaff x 10"]);
					pictureBox33.BackgroundImage = Resources.Antidote____4__noted_generic;
					pictureBox33.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Antidote++ (4) x 10"]);
					pictureBox34.BackgroundImage = Resources.Manta_ray_noted_generic;
					pictureBox34.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Manta ray x 35"]);
					pictureBox35.BackgroundImage = Resources.Swamp_tar_generic;
					pictureBox35.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Swamp tar x 1000"]);
					pictureBox36.BackgroundImage = Resources.Crushed_nest_noted_generic;
					pictureBox36.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Crushed nest x 10"]);
					pictureBox37.BackgroundImage = Resources.Serpentine_visage;
					pictureBox37.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Serpentine visage x 1"]);
					pictureBox38.BackgroundImage = Resources.Magic_fang;
					pictureBox38.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magic fang x 1"]);
					pictureBox39.BackgroundImage = Resources.Tanzanite_fang;
					pictureBox39.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tanzanite fang x 1"]);
					pictureBox40.BackgroundImage = Resources.Uncut_onyx;
					pictureBox40.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Uncut onyx x 1"]);
					pictureBox41.BackgroundImage = Resources.Dragon_med_helm;
					pictureBox41.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon med helm x 1"]);
					pictureBox42.BackgroundImage = Resources.Dragon_halberd;
					pictureBox42.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Dragon halberd x 1"]);
					pictureBox43.BackgroundImage = Resources.Elite_clue_scroll;
					pictureBox43.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Elite clue scroll x 1"]);
					pictureBox44.BackgroundImage = Resources.Tanzanite_mutagen;
					pictureBox44.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Tanzanite mutagen x 1"]);
					pictureBox45.BackgroundImage = Resources.Magma_mutagen;
					pictureBox45.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Magma mutagen x 1"]);
					pictureBox46.BackgroundImage = Resources.Jar_of_swamp;
					pictureBox46.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Jar of swamp x 1"]);
					pictureBox47.BackgroundImage = Resources.Pet_snakeling;
					pictureBox47.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["Pet snakeling x 1"]);
					pictureBox48.BackgroundImage = Resources.RDT;
					pictureBox48.Image = iqc.createQuantityImage(allItemQuantitiesFromCurrentBoss["RDT x 1"]);

					setNPictureBoxesToVisible(48);
					setNPictureBoxesToDisabled(48);
					break;
				default:
					Console.WriteLine("displayTotalLootFromBoss(): " + boss + " not found");
					break;
			}
		}

		/* Constructor */
		public OldSchoolDropLogger() {
			InitializeComponent();

			// Add click listener to each picturebox
			foreach (Control c in this.Controls) {
				if (c is PictureBox) c.Click += pictureBox_Click;
			}

			putAllPictureBoxesIntoList();

			// Set side panel to hidden
			panelSidePanel.Visible = false;
			this.Size = new Size(490, 434);
			buttonToggleSidePanel.Location = new Point(440, 28);
			buttonToggleSidePanel.Text = "❯❯";

			// Set tooltips for sidebar buttons
			new ToolTip().SetToolTip(buttonSideBarBossKillcounts, "Killcounts");
			new ToolTip().SetToolTip(buttonSideBarTimers, "Timers");
			new ToolTip().SetToolTip(buttonSideBarEstimatedGPMade, "Estimated GP made");
			new ToolTip().SetToolTip(buttonSideBarDropRates, "Drop rates");
			new ToolTip().SetToolTip(buttonSideBarUniqueDrops, "Unique drops");
			new ToolTip().SetToolTip(buttonSidebarItemSplits, "Split drops");
		}

		public void printStringList(List<String> list) {
			Console.Write("OldSchoolDropLogger.printStringList():");
			Console.WriteLine("\n================= String List =====================");
			foreach (String s in list) {
				Console.WriteLine(s);
			}
			Console.WriteLine("====================================================\n");
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

		// ==============================================================================
		// ================= shouldn't have to touch these again ========================
		// ==============================================================================
		private void oldSchoolDropLoggerForm_Load(object sender, EventArgs e) {

			// === Obtaining settings
			Settings s = new Settings();
			s.getSettings();
			s.printSettings();

			// Opens the default boss if the matching setting is set
			ToolStripMenuItem defaultBoss = getDefaultBossFromSettings(s.getDefaultBoss());
			defaultBoss.PerformClick();
			// === End obtaining settings

			instance = this;
			stats = new stats.StatisticsForm();

		}
		private void putAllPictureBoxesIntoList() {
			// Put all pictureboxes into allPictureBoxes list
			Control[] c;
			for (int i = 1; i <= 72; i++) {
				c = this.Controls.Find("pictureBox" + i.ToString(), true);
				allPictureBoxes.Add((PictureBox)c[0]);
			}
		}
		private ToolStripMenuItem getDefaultBossFromSettings(String boss) {
			switch (boss) {
				case "Armadyl":
					return armadylToolStripMenuItem;
				case "Bandos":
					return bandosToolStripMenuItem;
				case "Saradomin":
					return saradominToolStripMenuItem;
				case "Zamorak":
					return zamorakToolStripMenuItem;
				case "Callisto":
					return callistoToolStripMenuItem;
				case "Chaos Elemental":
					return chaosElementalToolStripMenuItem;
				case "Chaos Fanatic":
					return chaosFanaticToolStripMenuItem;
				case "Crazy Archaeologist":
					return crazyArchaeologistToolStripMenuItem;
				case "King Black Dragon":
					return kingBlackDragonToolStripMenuItem;
				case "Scorpia":
					return scorpiaToolStripMenuItem;
				case "Venenatis":
					return venenatisToolStripMenuItem;
				case "Vet'ion":
					return vetionToolStripMenuItem;
				case "Abyssal Sire":
					return abyssalSireToolStripMenuItem;
				case "Barrows":
					return barrowsToolStripMenuItem;
				case "Cerberus":
					return cerberusToolStripMenuItem;
				case "Corporeal Beast":
					return corporealBeastToolStripMenuItem;
				case "Dagannoth Prime":
					setSelectedDagannothKing("Dagannoth Prime");
					return dagannothKingsToolStripMenuItem;
				case "Dagannoth Rex":
					setSelectedDagannothKing("Dagannoth Rex");
					return dagannothKingsToolStripMenuItem;
				case "Dagannoth Supreme":
					setSelectedDagannothKing("Dagannoth Supreme");
					return dagannothKingsToolStripMenuItem;
				case "Giant Mole":
					return giantMoleToolStripMenuItem;
				case "Kalphite Queen":
					return kalphiteQueenToolStripMenuItem;
				case "Kraken":
					return krakenToolStripMenuItem;
				case "Raids":
					return raidsToolStripMenuItem;
				case "Skotizo":
					return skotizoToolStripMenuItem;
				case "Thermy":
					return thermonuclearSmokeDevilToolStripMenuItem;
				case "Thermonuclear Smoke Devil":
					return thermonuclearSmokeDevilToolStripMenuItem;
				case "Zulrah":
					return zulrahToolStripMenuItem;
				default:
					return armadylToolStripMenuItem;
			}
		}
		private void removeAllItemQuantityOverlays() {
			for (int i = 0; i < allPictureBoxes.Count; i++) {

				allPictureBoxes[i].Image = null;
			}

			// Since we're removing the quantities
			sidebarViewingLootFromBoss = "";
		}
		private void setSidebarBossTimersToVisible(bool vis) {

			if (vis == true) activeSidebarWindow = "BossTimers";

			labelArmadylTimer.Visible = vis;
			labelBandosTimer.Visible = vis;
			labelZamorakTimer.Visible = vis;
			labelSaradominTimer.Visible = vis;
			labelCallistoTimer.Visible = vis;
			labelChaosElementalTimer.Visible = vis;
			labelChaosFanaticTimer.Visible = vis;
			labelCrazyArchaeologistTimer.Visible = vis;
			labelKingBlackDragonTimer.Visible = vis;
			labelScorpiaTimer.Visible = vis;
			labelVenenatisTimer.Visible = vis;
			labelVetionTimer.Visible = vis;
			labelDagannothPrimeTimer.Visible = vis;
			labelDagannothRexTimer.Visible = vis;
			labelDagannothSupremeTimer.Visible = vis;
			labelGiantMoleTimer.Visible = vis;
			labelKalphiteQueenTimer.Visible = vis;
			labelThermonuclearSmokeDevilTimer.Visible = vis;
		}
		private void setNPictureBoxesToEnabled(int n) {

			// 0 indexed because when accessing allPictureBoxes[i] this is 0 indexed
			int i = 0;

			while (i < allPictureBoxes.Count) {

				if (i < n) allPictureBoxes[i].Enabled = true;
				else allPictureBoxes[i].Enabled = false;

				i++;
			}
		}
		private void setNPictureBoxesToDisabled(int n) {

			// 0 indexed because when accessing allPictureBoxes[i] this is 0 indexed
			int i = 0;

			while (i < allPictureBoxes.Count) {

				if (i < n) allPictureBoxes[i].Enabled = false;
				else allPictureBoxes[i].Enabled = true;

				i++;
			}
			
		}
		public void setNPictureBoxesToVisible(int n, String boss = "") {
			if (boss == "Dagannoth Kings") {
				pictureBoxDagannothPrimeLoot.Hide();
				pictureBoxDagannothRexLoot.Hide();
				pictureBoxDagannothSupremeLoot.Hide();

				pictureBoxDagannothPrime.Show();
				pictureBoxDagannothRex.Show();
				pictureBoxDagannothSupreme.Show();
			}
			else if (boss == "Dagannoth Kings Loot") {
				pictureBoxDagannothPrime.Hide();
				pictureBoxDagannothRex.Hide();
				pictureBoxDagannothSupreme.Hide();

				pictureBoxDagannothPrimeLoot.Show();
				pictureBoxDagannothRexLoot.Show();
				pictureBoxDagannothSupremeLoot.Show();
			}
			else {
				pictureBoxDagannothPrime.Hide();
				pictureBoxDagannothRex.Hide();
				pictureBoxDagannothSupreme.Hide();

				pictureBoxDagannothPrimeLoot.Hide();
				pictureBoxDagannothRexLoot.Hide();
				pictureBoxDagannothSupremeLoot.Hide();
			}

			int numShowing = 0;

			for (int i = 0; i < allPictureBoxes.Count; i++) {

				if (numShowing < n) {
					allPictureBoxes[i].Visible = true;
				}
				else {
					allPictureBoxes[i].Visible = false;
				}
				numShowing++;
			}
		}

		Timer armadylTimer = new Timer();
		Timer bandosTimer = new Timer();
		Timer saradominTimer = new Timer();
		Timer zamorakTimer = new Timer();
		Timer callistoTimer = new Timer();
		Timer chaosElementalTimer = new Timer();
		Timer chaosFanaticTimer = new Timer();
		Timer crazyArchaeologistTimer = new Timer();
		Timer kingBlackDragonTimer = new Timer();
		Timer scorpiaTimer = new Timer();
		Timer venenatisTimer = new Timer();
		Timer vetionTimer = new Timer();
		Timer dagannothPrimeTimer = new Timer();
		Timer dagannothRexTimer = new Timer();
		Timer dagannothSupremeTimer = new Timer();
		Timer giantMoleTimer = new Timer();
		Timer kalphiteQueenTimer = new Timer();
		Timer thermonuclearSmokeDevilTimer = new Timer();
		private void labelArmadylTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = ARMADYL_RESPAWN_TIME - 1;
			Console.WriteLine("labelArmadylTimer_Click()");
			if (labelArmadylTimer.Text != "90") {
				labelArmadylTimer.Text = "90";
				labelArmadylTimer.ForeColor = Color.Yellow;
				armadylTimer.Dispose();
				time = 89;
			}
			else {
				armadylTimer = new Timer();
				armadylTimer.Interval = 1000;
				armadylTimer.Tick += (s, ee) => labelArmadylTimer_Tick(s, ee, time--, armadylTimer);
				if (time < 0) {
					armadylTimer.Stop();
				}
				armadylTimer.Start();
			}
		}
		private void labelArmadylTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelArmadylTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelArmadylTimer.Text = secondsLeft.ToString();
		}
		private void labelBandosTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = BANDOS_RESPAWN_TIME - 1;
			Console.WriteLine("labelBandosTimer_Click()");
			if (labelBandosTimer.Text != "90") {
				labelBandosTimer.Text = "90";
				labelBandosTimer.ForeColor = Color.Yellow;
				bandosTimer.Dispose();
				time = 89;
			}
			else {
				bandosTimer = new Timer();
				bandosTimer.Interval = 1000;
				bandosTimer.Tick += (s, ee) => labelBandosTimer_Tick(s, ee, time--, bandosTimer);
				if (time < 0) {
					bandosTimer.Stop();
				}
				bandosTimer.Start();
			}
		}
		private void labelBandosTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelBandosTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelBandosTimer.Text = secondsLeft.ToString();
		}
		private void labelSaradominTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = SARADOMIN_RESPAWN_TIME - 1;

			if (labelSaradominTimer.Text != "90") {
				labelSaradominTimer.Text = "90";
				labelSaradominTimer.ForeColor = Color.Yellow;
				saradominTimer.Dispose();
				time = 89;
			}
			else {
				saradominTimer = new Timer();
				saradominTimer.Interval = 1000;
				saradominTimer.Tick += (s, ee) => labelSaradominTimer_Tick(s, ee, time--, saradominTimer);
				if (time < 0) {
					saradominTimer.Stop();
				}
				saradominTimer.Start();
			}
		}
		private void labelSaradominTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelSaradominTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelSaradominTimer.Text = secondsLeft.ToString();
		}
		private void labelZamorakTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = ZAMORAK_RESPAWN_TIME - 1;

			if (labelZamorakTimer.Text != "90") {
				labelZamorakTimer.Text = "90";
				labelZamorakTimer.ForeColor = Color.Yellow;
				zamorakTimer.Dispose();
				time = 89;
			}
			else {
				zamorakTimer = new Timer();
				zamorakTimer.Interval = 1000;
				zamorakTimer.Tick += (s, ee) => labelZamorakTimer_Tick(s, ee, time--, zamorakTimer);
				if (time < 0) {
					zamorakTimer.Stop();
				}
				zamorakTimer.Start();
			}
		}
		private void labelZamorakTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelZamorakTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelZamorakTimer.Text = secondsLeft.ToString();
		}
		private void labelCallistoTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = CALLISTO_RESPAWN_TIME - 1;

			if (labelCallistoTimer.Text != "90") {
				labelCallistoTimer.Text = "90";
				labelCallistoTimer.ForeColor = Color.Yellow;
				callistoTimer.Dispose();
				time = 89;
			}
			else {
				callistoTimer = new Timer();
				callistoTimer.Interval = 1000;
				callistoTimer.Tick += (s, ee) => labelCallistoTimer_Tick(s, ee, time--, callistoTimer);
				if (time < 0) {
					callistoTimer.Stop();
				}
				callistoTimer.Start();
			}
		}
		private void labelCallistoTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelCallistoTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelCallistoTimer.Text = secondsLeft.ToString();
		}
		private void labelChaosElementalTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = CHAOS_ELEMENTAL_RESPAWN_TIME - 1;

			if (labelChaosElementalTimer.Text != "90") {
				labelChaosElementalTimer.Text = "90";
				labelChaosElementalTimer.ForeColor = Color.Yellow;
				chaosElementalTimer.Dispose();
				time = 89;
			}
			else {
				chaosElementalTimer = new Timer();
				chaosElementalTimer.Interval = 1000;
				chaosElementalTimer.Tick += (s, ee) => labelChaosElementalTimer_Tick(s, ee, time--, chaosElementalTimer);
				if (time < 0) {
					chaosElementalTimer.Stop();
				}
				chaosElementalTimer.Start();
			}
		}
		private void labelChaosElementalTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelChaosElementalTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelChaosElementalTimer.Text = secondsLeft.ToString();
		}
		private void labelChaosFanaticTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = CHAOS_FANATIC_RESPAWN_TIME - 1;

			if (labelChaosFanaticTimer.Text != "90") {
				labelChaosFanaticTimer.Text = "90";
				labelChaosFanaticTimer.ForeColor = Color.Yellow;
				chaosFanaticTimer.Dispose();
				time = 89;
			}
			else {
				chaosFanaticTimer = new Timer();
				chaosFanaticTimer.Interval = 1000;
				chaosFanaticTimer.Tick += (s, ee) => labelChaosFanaticTimer_Tick(s, ee, time--, chaosFanaticTimer);
				if (time < 0) {
					chaosFanaticTimer.Stop();
				}
				chaosFanaticTimer.Start();
			}
		}
		private void labelChaosFanaticTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelChaosFanaticTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelChaosFanaticTimer.Text = secondsLeft.ToString();
		}
		private void labelCrazyArchaeologistTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = CRAZY_ARCHAEOLOGIST_RESPAWN_TIME - 1;

			if (labelCrazyArchaeologistTimer.Text != "90") {
				labelCrazyArchaeologistTimer.Text = "90";
				labelCrazyArchaeologistTimer.ForeColor = Color.Yellow;
				crazyArchaeologistTimer.Dispose();
				time = 89;
			}
			else {
				crazyArchaeologistTimer = new Timer();
				crazyArchaeologistTimer.Interval = 1000;
				crazyArchaeologistTimer.Tick += (s, ee) => labelCrazyArchaeologistTimer_Tick(s, ee, time--, crazyArchaeologistTimer);
				if (time < 0) {
					crazyArchaeologistTimer.Stop();
				}
				crazyArchaeologistTimer.Start();
			}
		}
		private void labelCrazyArchaeologistTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelCrazyArchaeologistTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelCrazyArchaeologistTimer.Text = secondsLeft.ToString();
		}
		private void labelKingBlackDragonTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = KING_BLACK_DRAGON_RESPAWN_TIME - 1;

			if (labelKingBlackDragonTimer.Text != "90") {
				labelKingBlackDragonTimer.Text = "90";
				labelKingBlackDragonTimer.ForeColor = Color.Yellow;
				kingBlackDragonTimer.Dispose();
				time = 89;
			}
			else {
				kingBlackDragonTimer = new Timer();
				kingBlackDragonTimer.Interval = 1000;
				kingBlackDragonTimer.Tick += (s, ee) => labelKingBlackDragonTimer_Tick(s, ee, time--, kingBlackDragonTimer);
				if (time < 0) {
					kingBlackDragonTimer.Stop();
				}
				kingBlackDragonTimer.Start();
			}
		}
		private void labelKingBlackDragonTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelKingBlackDragonTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelKingBlackDragonTimer.Text = secondsLeft.ToString();
		}
		private void labelScorpiaTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = SCORPIA_RESPAWN_TIME - 1;

			if (labelScorpiaTimer.Text != "90") {
				labelScorpiaTimer.Text = "90";
				labelScorpiaTimer.ForeColor = Color.Yellow;
				scorpiaTimer.Dispose();
				time = 89;
			}
			else {
				scorpiaTimer = new Timer();
				scorpiaTimer.Interval = 1000;
				scorpiaTimer.Tick += (s, ee) => labelScorpiaTimer_Tick(s, ee, time--, scorpiaTimer);
				if (time < 0) {
					scorpiaTimer.Stop();
				}
				scorpiaTimer.Start();
			}
		}
		private void labelScorpiaTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelScorpiaTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelScorpiaTimer.Text = secondsLeft.ToString();
		}
		private void labelVenenatisTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = VENENATIS_RESPAWN_TIME - 1;

			if (labelVenenatisTimer.Text != "90") {
				labelVenenatisTimer.Text = "90";
				labelVenenatisTimer.ForeColor = Color.Yellow;
				venenatisTimer.Dispose();
				time = 89;
			}
			else {
				venenatisTimer = new Timer();
				venenatisTimer.Interval = 1000;
				venenatisTimer.Tick += (s, ee) => labelVenenatisTimer_Tick(s, ee, time--, venenatisTimer);
				if (time < 0) {
					venenatisTimer.Stop();
				}
				venenatisTimer.Start();
			}
		}
		private void labelVenenatisTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelVenenatisTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelVenenatisTimer.Text = secondsLeft.ToString();
		}
		private void labelVetionTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = VETION_RESPAWN_TIME - 1;

			if (labelVetionTimer.Text != "90") {
				labelVetionTimer.Text = "90";
				labelVetionTimer.ForeColor = Color.Yellow;
				vetionTimer.Dispose();
				time = 89;
			}
			else {
				vetionTimer = new Timer();
				vetionTimer.Interval = 1000;
				vetionTimer.Tick += (s, ee) => labelVetionTimer_Tick(s, ee, time--, vetionTimer);
				if (time < 0) {
					vetionTimer.Stop();
				}
				vetionTimer.Start();
			}
		}
		private void labelVetionTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelVetionTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelVetionTimer.Text = secondsLeft.ToString();
		}
		private void labelDagannothPrimeTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = DAGANNOTH_PRIME_RESPAWN_TIME - 1;

			if (labelDagannothPrimeTimer.Text != "90") {
				labelDagannothPrimeTimer.Text = "90";
				labelDagannothPrimeTimer.ForeColor = Color.Yellow;
				dagannothPrimeTimer.Dispose();
				time = 89;
			}
			else {
				dagannothPrimeTimer = new Timer();
				dagannothPrimeTimer.Interval = 1000;
				dagannothPrimeTimer.Tick += (s, ee) => labelDagannothPrimeTimer_Tick(s, ee, time--, dagannothPrimeTimer);
				if (time < 0) {
					dagannothPrimeTimer.Stop();
				}
				dagannothPrimeTimer.Start();
			}
		}
		private void labelDagannothPrimeTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelDagannothPrimeTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelDagannothPrimeTimer.Text = secondsLeft.ToString();
		}
		private void labelDagannothRexTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = DAGANNOTH_REX_RESPAWN_TIME - 1;

			if (labelDagannothRexTimer.Text != "90") {
				labelDagannothRexTimer.Text = "90";
				labelDagannothRexTimer.ForeColor = Color.Yellow;
				dagannothRexTimer.Dispose();
				time = 89;
			}
			else {
				dagannothRexTimer = new Timer();
				dagannothRexTimer.Interval = 1000;
				dagannothRexTimer.Tick += (s, ee) => labelDagannothRexTimer_Tick(s, ee, time--, dagannothRexTimer);
				if (time < 0) {
					dagannothRexTimer.Stop();
				}
				dagannothRexTimer.Start();
			}
		}
		private void labelDagannothRexTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelDagannothRexTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelDagannothRexTimer.Text = secondsLeft.ToString();
		}
		private void labelDagannothSupremeTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = DAGANNOTH_SUPREME_RESPAWN_TIME - 1;

			if (labelDagannothSupremeTimer.Text != "90") {
				labelDagannothSupremeTimer.Text = "90";
				labelDagannothSupremeTimer.ForeColor = Color.Yellow;
				dagannothSupremeTimer.Dispose();
				time = 89;
			}
			else {
				dagannothSupremeTimer = new Timer();
				dagannothSupremeTimer.Interval = 1000;
				dagannothSupremeTimer.Tick += (s, ee) => labelDagannothSupremeTimer_Tick(s, ee, time--, dagannothSupremeTimer);
				if (time < 0) {
					dagannothSupremeTimer.Stop();
				}
				dagannothSupremeTimer.Start();
			}
		}
		private void labelDagannothSupremeTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelDagannothSupremeTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelDagannothSupremeTimer.Text = secondsLeft.ToString();
		}
		private void labelGiantMoleTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = GIANT_MOLE_RESPAWN_TIME - 1;

			if (labelGiantMoleTimer.Text != "90") {
				labelGiantMoleTimer.Text = "90";
				labelGiantMoleTimer.ForeColor = Color.Yellow;
				giantMoleTimer.Dispose();
				time = 89;
			}
			else {
				giantMoleTimer = new Timer();
				giantMoleTimer.Interval = 1000;
				giantMoleTimer.Tick += (s, ee) => labelGiantMoleTimer_Tick(s, ee, time--, giantMoleTimer);
				if (time < 0) {
					giantMoleTimer.Stop();
				}
				giantMoleTimer.Start();
			}
		}
		private void labelGiantMoleTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelGiantMoleTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelGiantMoleTimer.Text = secondsLeft.ToString();
		}
		private void labelKalphiteQueenTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = KALPHITE_QUEEN_RESPAWN_TIME - 1;

			if (labelKalphiteQueenTimer.Text != "90") {
				labelKalphiteQueenTimer.Text = "90";
				labelKalphiteQueenTimer.ForeColor = Color.Yellow;
				kalphiteQueenTimer.Dispose();
				time = 89;
			}
			else {
				kalphiteQueenTimer = new Timer();
				kalphiteQueenTimer.Interval = 1000;
				kalphiteQueenTimer.Tick += (s, ee) => labelKalphiteQueenTimer_Tick(s, ee, time--, kalphiteQueenTimer);
				if (time < 0) {
					kalphiteQueenTimer.Stop();
				}
				kalphiteQueenTimer.Start();
			}
		}
		private void labelKalphiteQueenTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelKalphiteQueenTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelKalphiteQueenTimer.Text = secondsLeft.ToString();
		}
		private void labelThermonuclearSmokeDevilTimer_Click(object sender, EventArgs e) {
			// - 1 to account for delay when clicking timer
			int time = THERMONUCLEAR_SMOKE_DEVIL_RESPAWN_TIME - 1;

			if (labelThermonuclearSmokeDevilTimer.Text != "90") {
				labelThermonuclearSmokeDevilTimer.Text = "90";
				labelThermonuclearSmokeDevilTimer.ForeColor = Color.Yellow;
				thermonuclearSmokeDevilTimer.Dispose();
				time = 89;
			}
			else {
				thermonuclearSmokeDevilTimer = new Timer();
				thermonuclearSmokeDevilTimer.Interval = 1000;
				thermonuclearSmokeDevilTimer.Tick += (s, ee) => labelThermonuclearSmokeDevilTimer_Tick(s, ee, time--, thermonuclearSmokeDevilTimer);
				if (time < 0) {
					thermonuclearSmokeDevilTimer.Stop();
				}
				thermonuclearSmokeDevilTimer.Start();
			}
		}
		private void labelThermonuclearSmokeDevilTimer_Tick(object sender, EventArgs e, int secondsLeft, Timer t) {
			if (secondsLeft <= 10) {
				labelThermonuclearSmokeDevilTimer.ForeColor = Color.Red;
			}
			if (secondsLeft <= 0) {
				t.Stop();
			}
			labelThermonuclearSmokeDevilTimer.Text = secondsLeft.ToString();
		}

		private void statsToolStripMenuItem_Click(object sender, EventArgs e) {

			if (!isFormOpen("StatisticsForm")) {
				stats.Show();
			}
		}

		
	}
}

// Test commit 

/*
 * 
 * Was working on / TODO list:
 * 
 * - Finish inputting boss respawn timers
 * - Verify drop rates work correctly 
 *		- Possible setting for example:
 *			- if item is dropped 4:16, setting should let them choose to display 4:16 or 1:4
 *			- setting called "Reduce drop rates to simplest form"
 * 
 * 
 * 
 */
