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

using rareDropTable;
using Config;
using StatisticsForm;
using itemQuantityCreator;

namespace mainWindow {
	public partial class oldSchoolDropLoggerForm : Form {
		private String selectedDagannothKing = "Dagannoth Prime";
		private String logsFilePath = AppDomain.CurrentDomain.BaseDirectory + "/logs/";

		private List<String> listboxItemsList = new List<String>();

		private Color hightlightOrange = Color.FromArgb(179, 107, 0);

		// Create an instance of this class so data can be passed to it from other forms
		public static oldSchoolDropLoggerForm instance;

		private List<PictureBox> allPictureBoxes = new List<PictureBox>();

		/* Getters and Setters */
		private void setSelectedDagannothKing(String king) {
			selectedDagannothKing = king;
		}
		private String getSelectedDagannothKing() {
			return selectedDagannothKing;
		}
		private String getCurrentBoss() {
			return labelCurrentLogFor.Text.Replace("Current log for: ", "").Trim();
		}

		/* Menu strip handlers */
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}
		private void twitterToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("https://twitter.com/Im_Hess");
		}
		private void viewStatisticsToolStripMenuItem_Click(object sender, EventArgs e) {
			Statistics s = new Statistics();
			s.Show();
		}

		private void armadylToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + armadylToolStripMenuItem.Text; ;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_crossbow.png");
			pictureBox1.Tag = "Rune crossbow x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_sword.png"); ;
			pictureBox2.Tag = "Rune sword x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bolts_5.png"); ;
			pictureBox3.Tag = "Varies; Runite bolts";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_arrow_5.png"); ;
			pictureBox4.Tag = "Varies; Rune arrow";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_bolts_(e)_5.png"); ;
			pictureBox5.Tag = "Varies; Dragon bolts (e)";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mind_rune.png"); ;
			pictureBox6.Tag = "Varies; Mind rune";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png"); ;
			pictureBox7.Tag = "Varies; Coins";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dwarf_weed_noted_generic.png"); ;
			pictureBox8.Tag = "Varies; Dwarf weed";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dwarf_weed_seed_3.png"); ;
			pictureBox9.Tag = "Dward weed seed x 3";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Yew_seed_1.png"); ;
			pictureBox10.Tag = "Yew seed x 1";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ranging_potion_(3).png"); ;
			pictureBox11.Tag = "Ranging potion (3) x 3";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_defence_(3).png"); ;
			pictureBox12.Tag = "Super defence (3) x 3";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Crystal_key.png"); ;
			pictureBox13.Tag = "Crystal key x 1";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Black_d'hide_body.png"); ;
			pictureBox14.Tag = "Black d'hide body x 1";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Long_bone.png"); ;
			pictureBox15.Tag = "Long bone x 1";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Curved_bone.png"); ;
			pictureBox16.Tag = "Curved bone x 1";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_1.png"); ;
			pictureBox17.Tag = "Godsword shard 1 x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_2.png"); ;
			pictureBox18.Tag = "Godsword shard 2 x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_3.png"); ;
			pictureBox19.Tag = "Godsword shard 3 x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png"); ;
			pictureBox20.Tag = "Elite clue scroll x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Armadyl_helmet.png"); ;
			pictureBox21.Tag = "Armadyl helm x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Armadyl_chestplate.png"); ;
			pictureBox22.Tag = "Armadyl chestplate x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Armadyl_chainskirt.png"); ;
			pictureBox23.Tag = "Armadyl chainskirt x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Armadyl_hilt.png"); ;
			pictureBox24.Tag = "Armdadyl hilt x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_kree'arra.png"); ;
			pictureBox25.Tag = "Pet kree'arra x 1";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png"); ;
			pictureBox26.Tag = "RDT";
			setNPictureBoxesToVisible(26);
			resetItemDropListBox();
		}
		private void bandosToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + bandosToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_2h_sword.png");
			pictureBox1.Tag = "Rune 2h sword x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_pickaxe.png");
			pictureBox2.Tag = "Rune pickaxe x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_longsword.png");
			pictureBox3.Tag = "Rune longsword x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_sword.png");
			pictureBox4.Tag = "Rune sword x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_platebody.png");
			pictureBox5.Tag = "Rune platebody x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Nature_rune.png");
			pictureBox6.Tag = "Varies; Nature rune";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamantite_ore_noted_generic.png");
			pictureBox7.Tag = "Varies; Adamantite ore";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coal_noted_generic.png");
			pictureBox8.Tag = "Varies; Coal";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_generic.png");
			pictureBox9.Tag = "Varies; Magic logs";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snapdragon_seed_1.png");
			pictureBox10.Tag = "Snapdragon seed x 1";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_snapdragon_noted_3.png");
			pictureBox11.Tag = "Grimy snapdragon x 3";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(4).png");
			pictureBox12.Tag = "Super restore (4) x 3";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox13.Tag = "Varies; Coins";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Long_bone.png");
			pictureBox14.Tag = "Long bone x 1";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Curved_bone.png");
			pictureBox15.Tag = "Curved bone x 1";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox16.Tag = "Elite clue scroll x 1";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_1.png");
			pictureBox17.Tag = "Godsword shard 1 x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_2.png");
			pictureBox18.Tag = "Godsword shard 2 x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_3.png");
			pictureBox19.Tag = "Godsword shard 3 x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bandos_chestplate.png");
			pictureBox20.Tag = "Bandos platebody x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bandos_tassets.png");
			pictureBox21.Tag = "Bandos tassets x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bandos_boots.png");
			pictureBox22.Tag = "Bandos boots x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bandos_hilt.png");
			pictureBox23.Tag = "Bandos hilt x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_general_graardor.png");
			pictureBox24.Tag = "Pet general graardor x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox25.Tag = "RDT";
			setNPictureBoxesToVisible(25);
			resetItemDropListBox();
		}
		private void saradominToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + saradominToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_dart.png");
			pictureBox1.Tag = "Varies; Rune dart";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_sword.png");
			pictureBox2.Tag = "Rune sword x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_platebody.png");
			pictureBox3.Tag = "Adamant platebody x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_plateskirt.png");
			pictureBox4.Tag = "Rune plateskirt x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_kiteshield.png");
			pictureBox5.Tag = "Rune kiteshield x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Law_rune.png");
			pictureBox6.Tag = "Varies; Law rune";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ranarr_seed_2.png");
			pictureBox7.Tag = "Ranarr seed x 2";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_1.png");
			pictureBox8.Tag = "Magic seed x 1";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Diamond_noted_6.png");
			pictureBox9.Tag = "Diamond x 6";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_ranarr_weed.png");
			pictureBox10.Tag = "Grimy ranarr weed x 5";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Prayer_potion_(4).png");
			pictureBox11.Tag = "Prayer potion (4) x 3";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Saradomin_brew_(3).png");
			pictureBox12.Tag = "Saradomin brew (3) x 3";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(4).png");
			pictureBox13.Tag = "Super restore (4) x 3";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_defence_(4).png");
			pictureBox14.Tag = "Super defence (4) x 3";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_potion_(3).png");
			pictureBox15.Tag = "Magic potion (3) x 3";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox16.Tag = "Varies; Coins";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox17.Tag = "Elite clue scroll x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_1.png");
			pictureBox18.Tag = "Godsword shard 1 x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_2.png");
			pictureBox19.Tag = "Godsword shard 2 x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_3.png");
			pictureBox20.Tag = "Godsword shard 3 x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Saradomin's_light.png");
			pictureBox21.Tag = "Saradomin's light x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Saradomin_sword.png");
			pictureBox22.Tag = "Saradomin sword x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Armadyl_crossbow.png");
			pictureBox23.Tag = "Armadyl crossbow x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Saradomin_hilt.png");
			pictureBox24.Tag = "Saradomin hilt x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_zilyana.png");
			pictureBox25.Tag = "Pet zilyana x 1";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox26.Tag = "RDT";
			setNPictureBoxesToVisible(26);
			resetItemDropListBox();
		}
		private void zamorakToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + zamorakToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_sword.png");
			pictureBox1.Tag = "Rune sword x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_scimitar.png");
			pictureBox2.Tag = "Rune scimitar x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_dagger_(p++).png");
			pictureBox3.Tag = "Dragon dagger (p++) x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_arrow_5.png");
			pictureBox4.Tag = "Varies; Adamant arrow";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_platebody.png");
			pictureBox5.Tag = "Adamant platebody x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_platelegs.png");
			pictureBox6.Tag = "Rune platelegs x 1";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Lantadyme_seed_3.png");
			pictureBox7.Tag = "Lantadyme seed x 3";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_lantadyme_noted_generic.png");
			pictureBox8.Tag = "Varies; Grimy lantadyme";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_attack_(3).png");
			pictureBox9.Tag = "Super attack (3) x 3";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_strength_(3).png");
			pictureBox10.Tag = "Super strength (3) x 3";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(3).png");
			pictureBox11.Tag = "Super restore (3) x 3";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Zamorak_brew_(3).png");
			pictureBox12.Tag = "Zamorak brew (3) x 3";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune.png");
			pictureBox13.Tag = "Varies; Death rune";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune.png");
			pictureBox14.Tag = "Varies; Blood rune";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox15.Tag = "Varies; Coins";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox16.Tag = "Elite clue scroll x 1";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_1.png");
			pictureBox17.Tag = "Godsword shard 1 x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_2.png");
			pictureBox18.Tag = "Godsword shard 2 x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Godsword_shard_3.png");
			pictureBox19.Tag = "Godsword shard 3 x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Steam_battlestaff.png");
			pictureBox20.Tag = "Steam battlestaff x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Staff_of_the_dead.png");
			pictureBox21.Tag = "Staff of the dead x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Zamorakian_spear.png");
			pictureBox22.Tag = "Zamorakian spear x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Zamorak_hilt.png");
			pictureBox23.Tag = "Zamorak hilt x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_k'ril_tsutsaroth.png");
			pictureBox24.Tag = "Pet k'ril tsutsaroth x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox25.Tag = "RDT";
			setNPictureBoxesToVisible(25);
			resetItemDropListBox();
		}
		private void callistoToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + callistoToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_pickaxe.png");
			pictureBox1.Tag = "Rune pickaxe x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_2h_sword.png");
			pictureBox2.Tag = "Rune 2h sword x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Soul_rune_250.png");
			pictureBox3.Tag = "Soul rune x 250";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_300.png");
			pictureBox4.Tag = "Death rune x 300";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_rune_400.png");
			pictureBox5.Tag = "Chaos rune x 400";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_200.png");
			pictureBox6.Tag = "Blood rune x 200";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mahogany_logs_noted_400.png");
			pictureBox7.Tag = "Mahogany logs x 400";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_100.png");
			pictureBox8.Tag = "Magic logs x 100";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ranarr_seed_5.png");
			pictureBox9.Tag = "Ranarr seed x 5";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snapdragon_seed_3.png");
			pictureBox10.Tag = "Snapdragon seed x 3";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Palm_tree_seed_1.png");
			pictureBox11.Tag = "Palm tree seed x 1";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Yew_seed_1.png");
			pictureBox12.Tag = "Yew seed x 1";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_1.png");
			pictureBox13.Tag = "Magic seed x 1";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_toadflax_noted_100.png");
			pictureBox14.Tag = "Grimy toadflax x 100";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_fishing_bait_375.png");
			pictureBox15.Tag = "Dark fishing bait x 375";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_crab.png");
			pictureBox16.Tag = "Dark crab x 8";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(4).png");
			pictureBox17.Tag = "Super restore (4) x 3";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mysterious_emblem.png");
			pictureBox18.Tag = "Mysterious emblem x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Limpwurt_root_noted_50.png");
			pictureBox19.Tag = "Limpwurt root x 50";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coconut_noted_60.png");
			pictureBox20.Tag = "Coconut x 60";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Crushed_nest_noted_75.png");
			pictureBox21.Tag = "Crushed nest x 75";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Supercompost_noted_100.png");
			pictureBox22.Tag = "Supercompost x 100";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cannonball_250.png");
			pictureBox23.Tag = "Cannonball x 250";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Red_dragonhide_noted_75.png");
			pictureBox24.Tag = "Red dragonhide x 75";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_ruby_noted_20.png");
			pictureBox25.Tag = "Uncut ruby x 20";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_diamond_noted_10.png");
			pictureBox26.Tag = "Uncut diamond x 10";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_dragonstone.png");
			pictureBox27.Tag = "Uncut dragonstone x 1";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox28.Tag = "Varies; Coins";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox29.Tag = "Elite clue scroll x 1";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_pickaxe.png");
			pictureBox30.Tag = "Dragon pickaxe x 1";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_2h_sword.png");
			pictureBox31.Tag = "Dragon 2h sword x 1";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Tyrannical_ring.png");
			pictureBox32.Tag = "Tyrannical ring x 1";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Callisto_cub.png");
			pictureBox33.Tag = "Callisto cub x 1";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox34.Tag = "RDT";
			setNPictureBoxesToVisible(34);
			resetItemDropListBox();
		}
		private void chaosElementalToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + chaosElementalToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_dart_300.png");
			pictureBox1.Tag = "Mithril dart x 300";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_arrow_150.png");
			pictureBox2.Tag = "Rune arrow x 150";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_rune_250.png");
			pictureBox3.Tag = "Chaos rune x 250";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_rune_500.png");
			pictureBox4.Tag = "Air rune x 500";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_125.png");
			pictureBox5.Tag = "Death rune x 125";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_75.png");
			pictureBox6.Tag = "Blood rune x 75";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Anchovy_pizza.png");
			pictureBox7.Tag = "Anchovy pizza x 3";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Tuna.png");
			pictureBox8.Tag = "Tuna x 5";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_guam_leaf.png");
			pictureBox9.Tag = "Varies; Grimy guam leaf";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_marrentill.png");
			pictureBox10.Tag = "Varies; Grimy marrentill";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_tarromin.png");
			pictureBox11.Tag = "Varies; Grimy tarromin";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_harralander.png");
			pictureBox12.Tag = "Varies; Grimy harralander";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_ranarr_weed.png");
			pictureBox13.Tag = "Varies; Grimy ranarr weed";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_irit_leaf.png");
			pictureBox14.Tag = "Varies; Grimy irit leaf";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_avantoe.png");
			pictureBox15.Tag = "Varies; Grimy avantoe";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_kwuarm.png");
			pictureBox16.Tag = "Varies; Grimy kwuarm";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_cadantine.png");
			pictureBox17.Tag = "Varies; Grimy cadantine";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_lantadyme.png");
			pictureBox18.Tag = "Varies; Grimy lantadyme";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_dwarf_weed.png");
			pictureBox19.Tag = "Varies; Grimy dwarf weed";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_attack_(4).png");
			pictureBox20.Tag = "Super attack (4) x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_strength_(4).png");
			pictureBox21.Tag = "Super strength (4) x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_defence_(4).png");
			pictureBox22.Tag = "Super defence (4) x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Weapon_poison_(++).png");
			pictureBox23.Tag = "Weapon poison (++) x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Antidote++_(4).png");
			pictureBox24.Tag = "Antidote++ (4) x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Strange_fruit_noted_10.png");
			pictureBox25.Tag = "Strange fruit x 10";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bones.png");
			pictureBox26.Tag = "Bones x 4";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bat_bones.png");
			pictureBox27.Tag = "Bat bones x 5";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Big_bones.png");
			pictureBox28.Tag = "Big bones x 3";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Babydragon_bones.png");
			pictureBox29.Tag = "Babydragon bones x 2";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_bones.png");
			pictureBox30.Tag = "Dragon bones x 1";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_7500.png");
			pictureBox31.Tag = "Coins 7500 x 1";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox32.Tag = "Elite clue scroll x 1";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_chaos_elemental.png");
			pictureBox33.Tag = "Pet chaos elemental x 1";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox34.Tag = "RDT";
			setNPictureBoxesToVisible(34);
			resetItemDropListBox();
		}
		private void chaosFanaticToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + chaosFanaticToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fire_rune_250.png");
			pictureBox1.Tag = "Fire rune x 250";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Smoke_rune_30.png");
			pictureBox2.Tag = "Smoke rune x 30";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_rune_175.png");
			pictureBox3.Tag = "Chaos rune x 175";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_50.png");
			pictureBox4.Tag = "Blood rune x 50";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pure_essence_noted_250.png");
			pictureBox5.Tag = "Pur essence x 250";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_sapphire_noted_4.png");
			pictureBox6.Tag = "Uncut sapphire x 4";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_emerald_noted_6.png");
			pictureBox7.Tag = "Uncut emerald x 6";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ring_of_life.png");
			pictureBox8.Tag = "Ring of life x 1";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_talisman.png");
			pictureBox9.Tag = "Chaos talisman x 1";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Nature_talisman.png");
			pictureBox10.Tag = "Nature talisman x 1";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Zamorak_robe_(top).png");
			pictureBox11.Tag = "Zamorak robe (top) x 1";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Zamorak_robe_(bottom).png");
			pictureBox12.Tag = "Zamorak robe (bottom) x 1";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Splitbark_body.png");
			pictureBox13.Tag = "Splitbark body x 1";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Splitbark_legs.png");
			pictureBox14.Tag = "Splitbark legs x 1";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Prayer_potion_(4).png");
			pictureBox15.Tag = "Prayer potion (4) x 1";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_lantadyme_noted_4.png");
			pictureBox16.Tag = "Grimy lantadyme x 4";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Anchovy_pizza_noted_8.png");
			pictureBox17.Tag = "Anchovy pizza x 8";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Monkfish.png");
			pictureBox18.Tag = "Monkfish x 3";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
			pictureBox19.Tag = "Shark x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Battlestaff_noted_5.png");
			pictureBox20.Tag = "Battlestaff x 5";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Wine_of_zamorak_noted_10.png");
			pictureBox21.Tag = "Wine of zamorak x 10";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_1000.png");
			pictureBox22.Tag = "Varies; Coins";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Sinister_key.png");
			pictureBox23.Tag = "Sinister key x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mysterious_emblem.png");
			pictureBox24.Tag = "Mysterious emblem x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ancient_staff.png");
			pictureBox25.Tag = "Ancient staff x 1";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox26.Tag = "Elite clue scroll x 1";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Odium_shard_1.png");
			pictureBox27.Tag = "Odium shard 1 x 1";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Malediction_shard_1.png");
			pictureBox28.Tag = "Malediction shard 1 x 1";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_chaos_elemental.png");
			pictureBox29.Tag = "Pet chaos elemental x 1";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox30.Tag = "RDT";
			setNPictureBoxesToVisible(30);
			resetItemDropListBox();
		}
		private void crazyArchaeologistToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + crazyArchaeologistToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_crossbow.png");
			pictureBox1.Tag = "Rune crossbow x 2";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_knife_10.png");
			pictureBox2.Tag = "Rune knife x 10";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Amulet_of_power.png");
			pictureBox3.Tag = "Amulet of power x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mud_rune_30.png");
			pictureBox4.Tag = "Mud rune x 30";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Potato_with_cheese.png");
			pictureBox5.Tag = "Potato with cheese x 3";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Anchovy_pizza_noted_8.png");
			pictureBox6.Tag = "Anchovy pizza x 8";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
			pictureBox7.Tag = "Shark x 1";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Prayer_potion_(4).png");
			pictureBox8.Tag = "Prayer potion (4) x 1";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_sapphire_noted_4.png");
			pictureBox9.Tag = "Uncut sapphire x 4";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_emerald_noted_6.png");
			pictureBox10.Tag = "Uncut emerald x 6";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Silver_ore_noted_40.png");
			pictureBox11.Tag = "Silver ore x 40";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Muddy_key.png");
			pictureBox12.Tag = "Muddy key x 1";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rusty_sword.png");
			pictureBox13.Tag = "Rusty sword x 1";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_dwarf_weed_noted_4.png");
			pictureBox14.Tag = "Grimy dwarf weed x 4";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/White_berries_noted_10.png");
			pictureBox15.Tag = "White berries x 10";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cannonball_150.png");
			pictureBox16.Tag = "Cannonball x 150";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Red_d'hide_body.png");
			pictureBox17.Tag = "Red d'hide body x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Red_dragonhide_noted_10.png");
			pictureBox18.Tag = "Red dragonhide x 10";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_1000.png");
			pictureBox19.Tag = "Varies; Coins";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Onyx_bolt_tips_12.png");
			pictureBox20.Tag = "Onyx bolt tips x 12";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mysterious_emblem.png");
			pictureBox21.Tag = "Mysterious emblem x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_arrow_75.png");
			pictureBox22.Tag = "Dragon arrow x 75";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Long_bone.png");
			pictureBox23.Tag = "Long bone x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox24.Tag = "Elite clue scroll x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fedora.png");
			pictureBox25.Tag = "Fedora x 1";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Odium_shard_2.png");
			pictureBox26.Tag = "Odium shard 2 x 1";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Malediction_shard_2.png");
			pictureBox27.Tag = "Malediction shard 2 x 1";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox28.Tag = "RDT";
			setNPictureBoxesToVisible(28);
			resetItemDropListBox();
		}
		private void kingBlackDragonToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + kingBlackDragonToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_longsword.png");
			pictureBox1.Tag = "Rune longsword x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_platebody.png");
			pictureBox2.Tag = "Adamant platebody x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_kiteshield.png");
			pictureBox3.Tag = "Adamant kiteshield x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Iron_arrow_690.png");
			pictureBox4.Tag = "Iron arrow x 690";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bolts_5.png");
			pictureBox5.Tag = "Varies; Runite bolts";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_dart_tip.png");
			pictureBox6.Tag = "Varies; Dragon dart tip";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_arrowtips_5.png");
			pictureBox7.Tag = "Varies; Dragon arrowtips";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_javelin_heads_15.png");
			pictureBox8.Tag = "Dragon javelin heads x 15";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fire_rune_300.png");
			pictureBox9.Tag = "Fire rune x 300";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_rune_300.png");
			pictureBox10.Tag = "Air rune x 300";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_30.png");
			pictureBox11.Tag = "Blood rune x 30";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Law_rune_30.png");
			pictureBox12.Tag = "Law rune x 30";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Amulet_of_power.png");
			pictureBox13.Tag = "Amulet of power x 1";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Yew_logs_noted_150.png");
			pictureBox14.Tag = "Yew logs x 150";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
			pictureBox15.Tag = "Shark x 4";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Gold_ore_noted_100.png");
			pictureBox16.Tag = "Gold ore x 100";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_limbs.png");
			pictureBox17.Tag = "Runite limbs x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamantite_bar.png");
			pictureBox18.Tag = "Adamantite bar x 3";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bar.png");
			pictureBox19.Tag = "Runite bar x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox20.Tag = "Elite clue scroll x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_med_helm.png");
			pictureBox21.Tag = "Dragon med helm x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Kbd_heads.png");
			pictureBox22.Tag = "Kbd heads x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_pickaxe.png");
			pictureBox23.Tag = "Dragon pickaxe x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Draconic_visage.png");
			pictureBox24.Tag = "Draconic visage x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Prince_black_dragon.png");
			pictureBox25.Tag = "Prince black dragon x 1";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox26.Tag = "RDT";
			setNPictureBoxesToVisible(26);
			resetItemDropListBox();
		}
		private void scorpiaToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + scorpiaToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_scimitar.png");
			pictureBox1.Tag = "Rune scimitar x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_sword.png");
			pictureBox2.Tag = "Rune sword x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_warhammer.png");
			pictureBox3.Tag = "Rune warhammer x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_2h_sword.png");
			pictureBox4.Tag = "Rune 2h sword x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_spear.png");
			pictureBox5.Tag = "Rune spear x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_pickaxe.png");
			pictureBox6.Tag = "Rune pickaxe x 1";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_chainbody.png");
			pictureBox7.Tag = "Rune chainbody x 1";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Phoenix_necklace.png");
			pictureBox8.Tag = "Phoenix necklace x 1";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dust_rune_30.png");
			pictureBox9.Tag = "Dust rune x 30";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_sapphire_noted_4.png");
			pictureBox10.Tag = "Uncut sapphire x 4";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_emerald_noted_6.png");
			pictureBox11.Tag = "Uncut emerald x 6";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_1000.png");
			pictureBox12.Tag = "Varies; Coins";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Admiral_pie.png");
			pictureBox13.Tag = "Admiral pie x 3";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Anchovy_pizza_noted_8.png");
			pictureBox14.Tag = "Anchovy pizza x 8";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
			pictureBox15.Tag = "Shark x 1";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cactus_spine_noted_10.png");
			pictureBox16.Tag = "Cactus spine x 10";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Prayer_potion_(4).png");
			pictureBox17.Tag = "Prayer potion (4) x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Superantipoison_(4).png");
			pictureBox18.Tag = "Superantipoison (4) x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ensouled_scorpion_head.png");
			pictureBox19.Tag = "Ensouled scorpion head x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bucket_of_sand_noted_25.png");
			pictureBox20.Tag = "Bucket of sand x 25";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Kwuarm_noted_4.png");
			pictureBox21.Tag = "Kwuarm x 4";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mysterious_emblem.png");
			pictureBox22.Tag = "Mysterious emblem x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_scimitar.png");
			pictureBox23.Tag = "Dragon scimitar x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox24.Tag = "Elite clue scroll x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Odium_shard_3.png");
			pictureBox25.Tag = "Odium shard 3 x 1";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Malediction_shard_3.png");
			pictureBox26.Tag = "Malediction shard 3 x 1";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Scorpia's_offspring.png");
			pictureBox27.Tag = "Scropia's offspring x 1";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox28.Tag = "RDT";
			setNPictureBoxesToVisible(28);
			resetItemDropListBox();
		}
		private void venenatisToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + venenatisToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_pickaxe.png");
			pictureBox1.Tag = "Rune pickaxe x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_2h_sword.png");
			pictureBox2.Tag = "Rune 2h sword x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_knife_60.png");
			pictureBox3.Tag = "Rune knife x 60";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Diamond_bolts_(e)_100.png");
			pictureBox4.Tag = "Diamond bolts (e) x 100";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cannonball_250.png");
			pictureBox5.Tag = "Cannonball x 250";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_rune_400.png");
			pictureBox6.Tag = "Chaos rune x 400";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_300.png");
			pictureBox7.Tag = "Death rune x 300";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_200.png");
			pictureBox8.Tag = "Blood rune x 200";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_fishing_bait_375.png");
			pictureBox9.Tag = "Dark fishing bait x 375";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_crab.png");
			pictureBox10.Tag = "Dark crab x 8";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Supercompost_noted_100.png");
			pictureBox11.Tag = "Supercompost x 100";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Unicorn_horn_noted_100.png");
			pictureBox12.Tag = "Unicorn horn x 100";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Red_spiders'_eggs_noted_500.png");
			pictureBox13.Tag = "Red spiders' eggs x 500";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_ruby_noted_20.png");
			pictureBox14.Tag = "Uncut ruby x 20";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_diamond_noted_10.png");
			pictureBox15.Tag = "Uncut diamond x 10";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_dragonstone.png");
			pictureBox16.Tag = "Uncut dragonstone x 1";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Gold_ore_noted_300.png");
			pictureBox17.Tag = "Gold ore x 300";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Limpwurt_root_noted_50.png");
			pictureBox18.Tag = "Limpwurt root x 50";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_snapdragon_noted_100.png");
			pictureBox19.Tag = "Grimy snapdragon x 100";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Antidote++_(4)_noted_10.png");
			pictureBox20.Tag = "Antidote++ (4) x 10";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(4).png");
			pictureBox21.Tag = "Super restore (4) x 3";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Palm_tree_seed_1.png");
			pictureBox22.Tag = "Palm tree seed x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Yew_seed_1.png");
			pictureBox23.Tag = "Yew seed x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_1.png");
			pictureBox24.Tag = "Magic seed x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_100.png");
			pictureBox25.Tag = "Magic logs x 100";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox26.Tag = "Varies; Coins";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mysterious_emblem.png");
			pictureBox27.Tag = "Mysterious emblem x 1";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox28.Tag = "Elite clue scroll x 1";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Onyx_bolt_tips_60.png");
			pictureBox29.Tag = "Onyx bolt tips x 60";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_2h_sword.png");
			pictureBox30.Tag = "Dragon 2h sword x 1";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_pickaxe.png");
			pictureBox31.Tag = "Dragon pickaxe x 1";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Treasonous_ring.png");
			pictureBox32.Tag = "Treasonous ring x 1";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Venenatis_spiderling.png");
			pictureBox33.Tag = "Venanitis spiderling x 1";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox34.Tag = "RDT";
			setNPictureBoxesToVisible(34);
			resetItemDropListBox();
		}
		private void vetionToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + vetionToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_pickaxe.png");
			pictureBox1.Tag = "Rune pickaxe x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_2h_sword.png");
			pictureBox2.Tag = "Rune 2h sword x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ancient_staff.png");
			pictureBox3.Tag = "Ancient staff x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Gold_ore_noted_300.png");
			pictureBox4.Tag = "Gold ore x 300";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_100.png");
			pictureBox5.Tag = "Magic logs x 100";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_rune_400.png");
			pictureBox6.Tag = "Chaos rune x 400";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_300.png");
			pictureBox7.Tag = "Death rune x 300";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_200.png");
			pictureBox8.Tag = "Blood rune x 200";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_fishing_bait_375.png");
			pictureBox9.Tag = "Dark fishing bait x 375";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_crab.png");
			pictureBox10.Tag = "Dark crab x 8";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Supercompost_noted_100.png");
			pictureBox11.Tag = "Supercompost x 100";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Limpwurt_root_noted_50.png");
			pictureBox12.Tag = "Limpwurt root x 50";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_bones_noted_100.png");
			pictureBox13.Tag = "Dragon bones x 100";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_ruby_noted_20.png");
			pictureBox14.Tag = "Uncut ruby x 20";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_diamond_noted_10.png");
			pictureBox15.Tag = "Uncut diamond x 10";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_dragonstone.png");
			pictureBox16.Tag = "Uncut dragonstone x 1";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Oak_plank_noted_300.png");
			pictureBox17.Tag = "Oak plank x 300";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mort_myre_fungus_noted_200.png");
			pictureBox18.Tag = "Mort myre fungus x 200";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_ranarr_weed_noted_100.png");
			pictureBox19.Tag = "Grimy ranarr weed x 100";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Sanfew_serum_(4)_noted_10.png");
			pictureBox20.Tag = "Sanfew serum (4) x 10";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(4).png");
			pictureBox21.Tag = "Super restore (4) x 3";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Palm_tree_seed_1.png");
			pictureBox22.Tag = "Palm tree seed x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Yew_seed_1.png");
			pictureBox23.Tag = "Yew seed x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_1.png");
			pictureBox24.Tag = "Magic seed x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ogre_coffin_key_noted_10.png");
			pictureBox25.Tag = "Ogre coffin key x 10";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cannonball_250.png");
			pictureBox25.Tag = "Cannonball x 250";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox27.Tag = "Varies; ";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mysterious_emblem.png");
			pictureBox28.Tag = "Mysterious emblem x 1";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox29.Tag = "Elite clue scroll x 1";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_2h_sword.png");
			pictureBox30.Tag = "Dragon 2h sword x 1";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_pickaxe.png");
			pictureBox31.Tag = "Dragon pickaxe x 1";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ring_of_the_gods.png");
			pictureBox32.Tag = "Ring of the gods x 1";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Long_bone.png");
			pictureBox33.Tag = "Long bone x 1";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Curved_bone.png");
			pictureBox34.Tag = "Curved bone x 1";
			pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Vet'ion_jr.png");
			pictureBox35.Tag = "Vet'ion jr x 1";
			pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox36.Tag = "RDT";
			setNPictureBoxesToVisible(36);
			resetItemDropListBox();
		}
		private void abyssalSireToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + abyssalSireToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_sword_noted_3.png");
			pictureBox1.Tag = "Rune sword x 3";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_full_helm_noted_3.png");
			pictureBox2.Tag = "Rune full helm x 3";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_platebody_noted_2.png");
			pictureBox3.Tag = "Rune platebody x 2";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_kiteshield_noted_2.png");
			pictureBox4.Tag = "Rune kiteshield x 2";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Battlestaff_noted_10.png");
			pictureBox5.Tag = "Battlestaff x 10";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_battlestaff_noted_6.png");
			pictureBox6.Tag = "Air battlestaff x 6";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_air_staff_noted_2.png");
			pictureBox7.Tag = "Mystic air staff x 2";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_lava_staff_noted_2.png");
			pictureBox8.Tag = "Mystic lava staff x 2";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cosmic_rune_350.png");
			pictureBox9.Tag = "Cosmic rune x 350";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Law_rune_250.png");
			pictureBox10.Tag = "Law rune x 250";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune.png");
			pictureBox11.Tag = "Varies; Death rune";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune.png");
			pictureBox12.Tag = "Varies; Blood rune";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Soul_rune.png");
			pictureBox13.Tag = "Varies; Soul rune";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pure_essence_noted_600.png");
			pictureBox14.Tag = "Pure essence x 600";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Earth_orb_noted_generic.png");
			pictureBox15.Tag = "Varies; Earth orb";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_generic.png");
			pictureBox16.Tag = "Varies; Magic logs";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ranarr_seed_2.png");
			pictureBox17.Tag = "Ranarr seed x 2";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snapdragon_seed_2.png");
			pictureBox18.Tag = "Snapdragon seed x 2";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torstol_seed_2.png");
			pictureBox19.Tag = "Torstol seed x 2";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Watermelon_seed_30.png");
			pictureBox20.Tag = "Watermelon seed x 30";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Papaya_tree_seed_2.png");
			pictureBox21.Tag = "Papaya tree seed x 2";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Palm_tree_seed_2.png");
			pictureBox22.Tag = "Palm tree seed x 2";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Willow_seed_2.png");
			pictureBox23.Tag = "Willow seed x 2";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Maple_seed_2.png");
			pictureBox24.Tag = "Maple seed x 2";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Yew_seed_2.png");
			pictureBox25.Tag = "Yew seed x 2";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_2.png");
			pictureBox26.Tag = "Magic seed x 2";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Spirit_seed_2.png");
			pictureBox27.Tag = "Spirit seed x 2";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_kwuarm_noted_25.png");
			pictureBox28.Tag = "Grimy kwuarm x 25";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_lantadyme_noted_25.png");
			pictureBox29.Tag = "Grimy lantadyme x 25";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_cadantine_noted_25.png");
			pictureBox30.Tag = "Grimy cadantine x 25";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_dwarf_weed_noted_25.png");
			pictureBox31.Tag = "Grimy dwarf weed x 25";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chilli_potato.png");
			pictureBox32.Tag = "Chilli potato x 10";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Saradomin_brew_(3).png");
			pictureBox33.Tag = "Saradomin brew (3) x 6";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(4).png");
			pictureBox34.Tag = "Super restone (4) x 4";
			pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coal_noted_generic.png");
			pictureBox35.Tag = "Varies; Coal";
			pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_ore_noted_6.png");
			pictureBox36.Tag = "Runite ore x 6";
			pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bar_noted_5.png");
			pictureBox37.Tag = "Runite bar x 5";
			pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Jug_of_water_noted_generic.png");
			pictureBox38.Tag = "Varies; Jug of water";
			pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Binding_necklace_noted_25.png");
			pictureBox39.Tag = "Binding necklace x 25";
			pictureBox40.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_talisman.png");
			pictureBox40.Tag = "Air talisman x 1";
			pictureBox41.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Water_talisman.png");
			pictureBox41.Tag = "Water talisman x 1";
			pictureBox42.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fire_talisman.png");
			pictureBox42.Tag = "Fire talisman x 1";
			pictureBox43.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Earth_talisman.png");
			pictureBox43.Tag = "Earth talisman x 1";
			pictureBox44.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mind_talisman.png");
			pictureBox44.Tag = "Mind talisman x 1";
			pictureBox45.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Body_talisman.png");
			pictureBox45.Tag = "Body talisman x 1";
			pictureBox46.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cosmic_talisman.png");
			pictureBox46.Tag = "Cosmic talisman x 1";
			pictureBox47.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Nature_talisman.png");
			pictureBox47.Tag = "Nature talisman x 1";
			pictureBox48.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_talisman.png");
			pictureBox48.Tag = "Chaos talisman x 1";
			pictureBox49.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cannonball_300.png");
			pictureBox49.Tag = "Cannonball x 300";
			pictureBox50.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_diamond_noted_15.png");
			pictureBox50.Tag = "Uncut diamond x 15";
			pictureBox51.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox51.Tag = "Varies; Coins";
			pictureBox52.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Onyx_bolt_tips_10.png");
			pictureBox52.Tag = "Onyx bolt tips x 10";
			pictureBox53.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox53.Tag = "Elite clue scroll x 1";
			pictureBox54.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Unsired.png");
			pictureBox54.Tag = "Unsired x 1";
			pictureBox55.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox55.Tag = "RDT";
			setNPictureBoxesToVisible(55);
			resetItemDropListBox();
		}
		private void barrowsToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + barrowsToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ahrim's_hood.png");
			pictureBox1.Tag = "Ahrim's hood x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Karil's_coif.png");
			pictureBox2.Tag = "Karil's coif x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dharok's_helm.png");
			pictureBox3.Tag = "Dharok's helm x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Guthan's_helm.png");
			pictureBox4.Tag = "Guthan's helm x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torag's_helm.png");
			pictureBox5.Tag = "Torag's helm x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Verac's_helm.png");
			pictureBox6.Tag = "Verac's helm x 1";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mind_rune.png");
			pictureBox7.Tag = "Varies; Mind rune";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_rune.png");
			pictureBox8.Tag = "Varies; Chaos rune";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ahrim's_robetop.png");
			pictureBox9.Tag = "Ahrim's robetop x 1";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Karil's_leathertop.png");
			pictureBox10.Tag = "Karil's leathertop x 1";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dharok's_platebody.png");
			pictureBox11.Tag = "Dharok's platebody x 1";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Guthan's_platebody.png");
			pictureBox12.Tag = "Guthan's platebody x 1";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torag's_platebody.png");
			pictureBox13.Tag = "Torag's platebody x 1";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Verac's_brassard.png");
			pictureBox14.Tag = "Verac's brassard x 1";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune.png");
			pictureBox15.Tag = "Varies; Death rune";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune.png");
			pictureBox16.Tag = "Varies; Blood rune";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ahrim's_robeskirt.png");
			pictureBox17.Tag = "Ahrim's robeskirt x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Karil's_leatherskirt.png");
			pictureBox18.Tag = "Karil's leatherskirt x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dharok's_platelegs.png");
			pictureBox19.Tag = "Dharok's platelegs x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Guthan's_chainskirt.png");
			pictureBox20.Tag = "Guthan's chainskirt x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torag's_platelegs.png");
			pictureBox21.Tag = "Torag's platelegs x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Verac's_plateskirt.png");
			pictureBox22.Tag = "Verac's plateskirt x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Loop_half_of_key.png");
			pictureBox23.Tag = "Loop half of key x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Tooth_half_of_key.png");
			pictureBox24.Tag = "Tooth half of key x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ahrim's_staff.png");
			pictureBox25.Tag = "Ahrim's staff x 1";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Karil's_crossbow.png");
			pictureBox26.Tag = "Karil's crossbow x 1";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dharok's_greataxe.png");
			pictureBox27.Tag = "Dharok's greataxe x 1";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Guthan's_warspear.png");
			pictureBox28.Tag = "Guthan's warspear x 1";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torag's_hammers.png");
			pictureBox29.Tag = "Torag's hammers x 1";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Verac's_flail.png");
			pictureBox30.Tag = "Verac's flail x 1";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_1000.png");
			pictureBox31.Tag = "Varies; Coins";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox32.Tag = "Elite clue scroll x 1";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_med_helm.png");
			pictureBox33.Tag = "Dragon med helm x 1";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bolt_rack_5.png");
			pictureBox34.Tag = "Varies; Bolt rack";
			setNPictureBoxesToVisible(34);
			resetItemDropListBox();
		}
		private void cerberusToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + cerberusToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_2h_sword.png");
			pictureBox1.Tag = "Rune 2h sword x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_halberd.png");
			pictureBox2.Tag = "Rune halberd x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_axe.png");
			pictureBox3.Tag = "Rune axe x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_pickaxe.png");
			pictureBox4.Tag = "Rune pickaxe x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_full_helm.png");
			pictureBox5.Tag = "Rune full helm x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_platebody.png");
			pictureBox6.Tag = "Rune platebody x 1";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_chainbody.png");
			pictureBox7.Tag = "Rune chainbody x 1";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Black_d'hide_body.png");
			pictureBox8.Tag = "Black d'hide body x 1";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Battlestaff_noted_6.png");
			pictureBox9.Tag = "Battlestaff x 6";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Lava_battlestaff.png");
			pictureBox10.Tag = "Lava battlestaff x 1";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pure_essence_noted_300.png");
			pictureBox11.Tag = "Pure essence x 300";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fire_rune_300.png");
			pictureBox12.Tag = "Fire rune x 300";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_100.png");
			pictureBox13.Tag = "Death rune x 100";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_60.png");
			pictureBox14.Tag = "Blood rune x 60";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Soul_rune_100.png");
			pictureBox15.Tag = "Soul rune x 100";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bolts_(unf)_40.png");
			pictureBox16.Tag = "Runite bolts (unf) x 40";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cannonball_50.png");
			pictureBox17.Tag = "Cannonball x 50";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torstol_seed_3.png");
			pictureBox18.Tag = "Torstol seed x 3";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_torstol_noted_6.png");
			pictureBox19.Tag = "Grimy torstol x 6";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(4).png");
			pictureBox20.Tag = "Super restore (4) x 2";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coal_noted_120.png");
			pictureBox21.Tag = "Coal x 120";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_ore_noted_5.png");
			pictureBox22.Tag = "Runite ore x 5";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Wine_of_zamorak_noted_15.png");
			pictureBox23.Tag = "Wine of zamorak x 15";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Unholy_symbol.png");
			pictureBox24.Tag = "Unholy symbol x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ashes_noted_50.png");
			pictureBox25.Tag = "Ashes x 50";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Summer_pie.png");
			pictureBox26.Tag = "Summer pie x 3";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_bones_noted_20.png");
			pictureBox27.Tag = "Dragon bones x 20";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fire_orb_noted_20.png");
			pictureBox28.Tag = "Fire orb x 20";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_diamond_noted_5.png");
			pictureBox29.Tag = "Uncut diamond x 5";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox30.Tag = "Varies; Coins";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Key_master_teleport_3.png");
			pictureBox31.Tag = "Key master teleport x 3";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox32.Tag = "Elite clue scroll x 1";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Smouldering_stone.png");
			pictureBox33.Tag = "Smouldering stone x 1";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pegasian_crystal.png");
			pictureBox34.Tag = "Pegasian crystal x 1";
			pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Eternal_crystal.png");
			pictureBox35.Tag = "Eternal crystal x 1";
			pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Primordial_crystal.png");
			pictureBox36.Tag = "Primordial crystal x 1";
			pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Jar_of_souls.png");
			pictureBox37.Tag = "Jar of souls x 1";
			pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Hellpuppy.png");
			pictureBox38.Tag = "Hellpuppy x 1";
			pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox39.Tag = "RDT";
			setNPictureBoxesToVisible(39);
			resetItemDropListBox();
		}
		private void corporealBeastToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + corporealBeastToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_arrow_750.png");
			pictureBox1.Tag = "Adamant arrow x 750";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bolts_250.png");
			pictureBox2.Tag = "Runite bolts x 250";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cannonball_2000.png");
			pictureBox3.Tag = "Cannonball x 2000";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_air_staff.png");
			pictureBox4.Tag = "Mystic air staff x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_water_staff.png");
			pictureBox5.Tag = "Mystic water staff x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_earth_staff.png");
			pictureBox6.Tag = "Mystic earth staff x 1";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_fire_staff.png");
			pictureBox7.Tag = "Mystic fire staff x 1";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Nature_talisman.png");
			pictureBox8.Tag = "Varies; Nature talisman";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_sapphire.png");
			pictureBox9.Tag = "Varies; Uncut sapphire";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_emerald.png");
			pictureBox10.Tag = "Varies; Uncut emerald";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_ruby.png");
			pictureBox11.Tag = "Varies; Uncut ruby";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_diamond.png");
			pictureBox12.Tag = "Varies; Uncut diamond";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_robe_top_(blue).png");
			pictureBox13.Tag = "Mystic robe top (blue) x 1";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_robe_bottom_(blue).png");
			pictureBox14.Tag = "Mystic robe bottom (blue) x 1";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mahogany_logs_noted_150.png");
			pictureBox15.Tag = "Mahogany logs x 150";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_75.png");
			pictureBox16.Tag = "Magic logs x 75";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pure_essence_noted_2500.png");
			pictureBox17.Tag = "Pure essence x 2500";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Law_rune_250.png");
			pictureBox18.Tag = "Law rune x 250";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cosmic_rune_500.png");
			pictureBox19.Tag = "Cosmic rune x 500";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune.png");
			pictureBox20.Tag = "Varies; Death rune";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Soul_rune_250.png");
			pictureBox21.Tag = "Soul rune x 250";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamantite_bar_noted_35.png");
			pictureBox22.Tag = "Adamantite bar x 35";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamantite_ore_noted_125.png");
			pictureBox23.Tag = "Adamantite ore x 125";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_ore_noted_20.png");
			pictureBox24.Tag = "Runite ore x 20";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Teak_plank_noted_100.png");
			pictureBox25.Tag = "Teak plank x 100";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Green_dragonhide_noted_100.png");
			pictureBox26.Tag = "Green dragonhide x 100";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Raw_shark_noted_70.png");
			pictureBox27.Tag = "Raw shark x 70";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/White_berries_noted_120.png");
			pictureBox28.Tag = "White berries x 120";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Desert_goat_horn_noted_120.png");
			pictureBox29.Tag = "Desert goat horn x 120";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Antidote++_(4)_noted_40.png");
			pictureBox30.Tag = "Antidote++ (4) x 40";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Watermelon_seed_24.png");
			pictureBox31.Tag = "Watermelon seed x 24";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ranarr_seed_10.png");
			pictureBox32.Tag = "Ranarr seed x 10";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Tuna_potato.png");
			pictureBox33.Tag = "Tuna potato x 30";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox34.Tag = "Varies; Coins";
			pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shield_left_half.png");
			pictureBox35.Tag = "Shield left half x 1";
			pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_spear.png");
			pictureBox36.Tag = "Dragon spear x 1";
			pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox37.Tag = "Elite clue scroll x 1";
			pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Onyx_bolts_(e)_175.png");
			pictureBox38.Tag = "Onyx bolts (e) x 175";
			pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Holy_elixir.png");
			pictureBox39.Tag = "Holy elixir x 1";
			pictureBox40.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Spirit_shield.png");
			pictureBox40.Tag = "Spirit shield x 1";
			pictureBox41.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Spectral_sigil.png");
			pictureBox41.Tag = "Spectral sigil x 1";
			pictureBox42.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Arcane_sigil.png");
			pictureBox42.Tag = "Arcane sigil x 1";
			pictureBox43.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elysian_sigil.png");
			pictureBox43.Tag = "Elysian sigil x 1";
			pictureBox44.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_dark_core.png");
			pictureBox44.Tag = "Pet dark core x 1";
			setNPictureBoxesToVisible(44);
			resetItemDropListBox();
		}
		private void dagannothKingsToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + dagannothKingsToolStripMenuItem.Text;
			highlightPictureBox(pictureBoxDagannothPrime);
			if (selectedDagannothKing == "Dagannoth Prime") {
				pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Battlestaff_noted_generic.png");
				pictureBox1.Tag = "Varies; Battlestaff";
				pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_battlestaff.png");
				pictureBox2.Tag = "Air battlestaff x 1";
				pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Water_battlestaff.png");
				pictureBox3.Tag = "Water battlestaff x 1";
				pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Earth_battlestaff.png");
				pictureBox4.Tag = "Earth battlestaff x 1";
				pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pure_essence_noted_150.png");
				pictureBox5.Tag = "Pure essence x 150";
				pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_rune_155.png");
				pictureBox6.Tag = "Air rune x 155";
				pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mud_rune_32.png");
				pictureBox7.Tag = "Mud rune x 32";
				pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune.png");
				pictureBox8.Tag = "Varies; Death rune";
				pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ensouled_dagannoth_head.png");
				pictureBox9.Tag = "Ensouled dagannoth head x 1";
				pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_talisman.png");
				pictureBox10.Tag = "Varies; Air talisman";
				pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Water_talisman.png");
				pictureBox11.Tag = "Varies; Water talisman";
				pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Earth_talisman.png");
				pictureBox12.Tag = "Varies; Earth talisman";
				pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_ranarr_weed.png");
				pictureBox13.Tag = "Grimy ranarr weed x 1";
				pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Belladonna_seed_1.png");
				pictureBox14.Tag = "Belladonna seed x 1";
				pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cactus_seed_1.png");
				pictureBox15.Tag = "Cactus seed x 1";
				pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Poison_ivy_seed_1.png");
				pictureBox16.Tag = "Poison ivy seed x 1";
				pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Irit_seed_1.png");
				pictureBox17.Tag = "Irit seed x 1";
				pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Toadflax_seed_1.png");
				pictureBox18.Tag = "Toadflax seed x 1";
				pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Avantoe_seed_1.png");
				pictureBox19.Tag = "Avantoe seed x 1";
				pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Kwuarm_seed_1.png");
				pictureBox20.Tag = "Kwuarm seed x 1";
				pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cadantine_seed_1.png");
				pictureBox21.Tag = "Cadantine seed x 1";
				pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Lantadyme_seed_1.png");
				pictureBox22.Tag = "Lantadyme seed x 1";
				pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dwarf_weed_seed_1.png");
				pictureBox23.Tag = "Dwarf weed seed x 1";
				pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snapdragon_seed_1.png");
				pictureBox24.Tag = "Snapdragon seed x 1";
				pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fremennik_shield.png");
				pictureBox25.Tag = "Fremennik shield x 1";
				pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fremennik_helm.png");
				pictureBox26.Tag = "Fremennik helm x 1";
				pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Skeletal_top.png");
				pictureBox27.Tag = "Skeletal top x 1";
				pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Skeletal_bottoms.png");
				pictureBox28.Tag = "Skeletal bottoms x 1";
				pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Farseer_helm.png");
				pictureBox29.Tag = "Farseer helm x 1";
				pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_1000.png");
				pictureBox30.Tag = "Varies; Coins";
				pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Hard_clue_scroll.png");
				pictureBox31.Tag = "Hard clue scroll x 1";
				pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
				pictureBox32.Tag = "Elite clue scroll x 1";
				pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_axe.png");
				pictureBox33.Tag = "Dragon axe x 1";
				pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mud_battlestaff.png");
				pictureBox34.Tag = "Mud battlestaff x 1";
				pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Seers_ring.png");
				pictureBox35.Tag = "Seers ring x 1";
				pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_dagannoth_prime.png");
				pictureBox36.Tag = "Pet dagannoth prime x 1";
				pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
				pictureBox37.Tag = "RDT";
				setNPictureBoxesToVisible(37, "Dagannoth Kings");
			}
			if (selectedDagannothKing == "Dagannoth Rex") {
				pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_warhammer.png");
				pictureBox1.Tag = "Mithril warhammer x 1";
				pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_2h_sword.png");
				pictureBox2.Tag = "Mithril 2h sword x 1";
				pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_pickaxe.png");
				pictureBox3.Tag = "Mithril pickaxe x 1";
				pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_axe.png");
				pictureBox4.Tag = "Adamant axe x 1";
				pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_Battleaxe.png");
				pictureBox5.Tag = "Rune battleaxe x 1";
				pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_axe.png");
				pictureBox6.Tag = "Rune axe x 1";
				pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fremennik_blade.png");
				pictureBox7.Tag = "Fremennik blade x 1";
				pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fremennik_helm.png");
				pictureBox8.Tag = "Fremennik helm x 1";
				pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_attack_(2).png");
				pictureBox9.Tag = "Super attack (2) x 1";
				pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_strength_(2).png");
				pictureBox10.Tag = "Super strength (2) x 1";
				pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_defence_(2).png");
				pictureBox11.Tag = "Super defence (2) x 1";
				pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Prayer_potion_(2).png");
				pictureBox12.Tag = "Prayer potion (2) x 1";
				pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Antifire_potion_(2).png");
				pictureBox13.Tag = "Antifire potion (2) x 1";
				pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Zamorak_brew_(2).png");
				pictureBox14.Tag = "Zamorak brew (2) x 1";
				pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fremennik_shield.png");
				pictureBox15.Tag = "Fremennik shield x 1";
				pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Steel_kiteshield.png");
				pictureBox16.Tag = "Steel kiteshield x 1";
				pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_talisman.png");
				pictureBox17.Tag = "Air talisman x 1";
				pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fire_talisman.png");
				pictureBox18.Tag = "Fire talisman x 1";
				pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Water_talisman.png");
				pictureBox19.Tag = "Water talisman x 1";
				pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Earth_talisman.png");
				pictureBox20.Tag = "Earth talisman x 1";
				pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mind_talisman.png");
				pictureBox21.Tag = "Mind talisman x 1";
				pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Body_talisman.png");
				pictureBox22.Tag = "Body talisman x 1";
				pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cosmic_talisman.png");
				pictureBox23.Tag = "Cosmic talisman x 1";
				pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Steel_platebody.png");
				pictureBox24.Tag = "Steel platebody x 1";
				pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_ranarr_weed.png");
				pictureBox25.Tag = "Grimy ranarr weed x 1";
				pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ensouled_dagannoth_head.png");
				pictureBox26.Tag = "Ensouled dagannoth head x 1";
				pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Iron_ore_noted_150.png");
				pictureBox27.Tag = "Iron ore x 150";
				pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coal_noted_100.png");
				pictureBox28.Tag = "Coal x 100";
				pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_ore_noted_25.png");
				pictureBox29.Tag = "Mithril ore x 25";
				pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Steel_bar_noted_generic.png");
				pictureBox30.Tag = "Varies; Steel bar";
				pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamantite_bar.png");
				pictureBox31.Tag = "Adamantite bar x 1";
				pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_platebody.png");
				pictureBox32.Tag = "Admantite platebody x 1";
				pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bass.png");
				pictureBox33.Tag = "Bass x 5";
				pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Swordfish.png");
				pictureBox34.Tag = "Swordfish x 5";
				pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
				pictureBox35.Tag = "Shark x 5";
				pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_1000.png");
				pictureBox36.Tag = "Varies; Coins";
				pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ring_of_life.png");
				pictureBox37.Tag = "Ring of life x 1";
				pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rock-shell_plate.png");
				pictureBox38.Tag = "Rock-shell plate x 1";
				pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rock-shell_legs.png");
				pictureBox39.Tag = "Rock-shell legs x 1";
				pictureBox40.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Hard_clue_scroll.png");
				pictureBox40.Tag = "Hard clue scroll x 1";
				pictureBox41.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
				pictureBox41.Tag = "Elite clue scroll x 1";
				pictureBox42.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_axe.png");
				pictureBox42.Tag = "Dragon axe x 1";
				pictureBox43.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Warrior_ring.png");
				pictureBox43.Tag = "Warrior ring x 1";
				pictureBox44.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Berserker_ring.png");
				pictureBox44.Tag = "Berserker ring x 1";
				pictureBox45.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_dagannoth_rex.png");
				pictureBox45.Tag = "Pet dagannoth x 1";
				pictureBox46.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
				pictureBox46.Tag = "RDT";
				setNPictureBoxesToVisible(46, "Dagannoth Kings");
			}
			if (selectedDagannothKing == "Dagannoth Supreme") {
				pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Iron_arrow_5.png");
				pictureBox1.Tag = "Varies; Iron arrow";
				pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Steel_arrow_5.png");
				pictureBox2.Tag = "Varies; Steel arrow";
				pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Iron_knife.png");
				pictureBox3.Tag = "Varies; Iron knife";
				pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Steel_knife.png");
				pictureBox4.Tag = "Varies; Steel knife";
				pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_knife.png");
				pictureBox5.Tag = "Varies; Mithril knife";
				pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_thrownaxe.png");
				pictureBox6.Tag = "Varies; Rune thrownaxe";
				pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_javelin.png");
				pictureBox7.Tag = "Varies; Rune javelin";
				pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bolts_5.png");
				pictureBox8.Tag = "Varies; Runite bolts";
				pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_limbs.png");
				pictureBox9.Tag = "Runite limbs x 1";
				pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_axe.png");
				pictureBox10.Tag = "Adamant axe x 1";
				pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Belladonna_seed_1.png");
				pictureBox11.Tag = "Belladonna seed x 1";
				pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cactus_seed_1.png");
				pictureBox12.Tag = "Cactus seed x 1";
				pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Poison_ivy_seed_1.png");
				pictureBox13.Tag = "Poison ivy seed x 1";
				pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Irit_seed_1.png");
				pictureBox14.Tag = "Irit seed x 1";
				pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Toadflax_seed_1.png");
				pictureBox15.Tag = "Toadflax seed x 1";
				pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Avantoe_seed_1.png");
				pictureBox16.Tag = "Avantoe seed x 1";
				pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Kwuarm_seed_1.png");
				pictureBox17.Tag = "Kwuarm seed x 1";
				pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cadantine_seed_1.png");
				pictureBox18.Tag = "Cadantine seed x 1";
				pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Lantadyme_seed_1.png");
				pictureBox19.Tag = "Lantadyme seed x 1";
				pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dwarf_weed_seed_1.png");
				pictureBox20.Tag = "Dwarf weed seed x 1";
				pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torstol_seed_1.png");
				pictureBox21.Tag = "Torstol seed x 1";
				pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_1000.png");
				pictureBox22.Tag = "Varies; Coins";
				pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Opal_bolt_tips_5.png");
				pictureBox23.Tag = "Varies; Opal bolt tips";
				pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Oyster_pearls.png");
				pictureBox24.Tag = "Oyster pearls";
				pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
				pictureBox25.Tag = "Shark x 5";
				pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Maple_logs_noted_generic.png");
				pictureBox26.Tag = "Varies; Maple logs";
				pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Yew_logs_noted_generic.png");
				pictureBox27.Tag = "Varies; Yew logs";
				pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_ranarr_weed.png");
				pictureBox28.Tag = "Grimy ranarr weed x 1";
				pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ensouled_dagannoth_head.png");
				pictureBox29.Tag = "Ensouled dagannoth head x 1";
				pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Feather.png");
				pictureBox30.Tag = "Varies; Feather";
				pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Red_d'hide_vamb.png");
				pictureBox31.Tag = "Red d'hide vamb x 1";
				pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fremennik_shield.png");
				pictureBox32.Tag = "Fremennik shield x 1";
				pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fremennik_helm.png");
				pictureBox33.Tag = "Fremennik helm x 1";
				pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Spined_body.png");
				pictureBox34.Tag = "Spined body x 1";
				pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Spined_chaps.png");
				pictureBox35.Tag = "Spined chaps x 1";
				pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Archer_helm.png");
				pictureBox36.Tag = "Archer helm x 1";
				pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Hard_clue_scroll.png");
				pictureBox37.Tag = "Hard clue scroll x 1";
				pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
				pictureBox38.Tag = "Elite clue scroll x 1";
				pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Seercull.png");
				pictureBox39.Tag = "Seercull x 1";
				pictureBox40.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_axe.png");
				pictureBox40.Tag = "Dragon axe x 1";
				pictureBox41.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Archers_ring.png");
				pictureBox41.Tag = "Archers ring x 1";
				pictureBox42.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_dagannoth_supreme.png");
				pictureBox42.Tag = "Pet dagannoth supreme x 1";
				pictureBox43.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
				pictureBox43.Tag = "RDT";
				setNPictureBoxesToVisible(43, "Dagannoth Kings");

			}
			resetItemDropListBox();
		}
		private void giantMoleToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + giantMoleToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_battleaxe.png");
			pictureBox1.Tag = "Mithril battleaxe x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_axe.png");
			pictureBox2.Tag = "Mithril axe x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamant_longsword.png");
			pictureBox3.Tag = "Adamant longsword x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_platebody.png");
			pictureBox4.Tag = "Mithril platebody x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_med_helm.png");
			pictureBox5.Tag = "Rune med helm x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Iron_arrow_690.png");
			pictureBox6.Tag = "Iron arrow x 690";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_bar.png");
			pictureBox7.Tag = "Mithril bar x 1";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Iron_ore_noted_100.png");
			pictureBox8.Tag = "Iron ore x 100";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Amulet_of_strength.png");
			pictureBox9.Tag = "Amulet of strength x 1";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Law_rune_15.png");
			pictureBox10.Tag = "Law rune x 15";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_rune_105.png");
			pictureBox11.Tag = "Air rune x 105";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fire_rune_105.png");
			pictureBox12.Tag = "Fire rune x 105";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_15.png");
			pictureBox13.Tag = "Blood rune x 15";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_7.png");
			pictureBox14.Tag = "Death rune x 7";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Oyster_pearls.png");
			pictureBox15.Tag = "Oyster pearls x 1";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
			pictureBox16.Tag = "Shark x 4";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Yew_logs_noted_100.png");
			pictureBox17.Tag = "Yew logs x 100";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox18.Tag = "Elite clue scroll x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Long_bone.png");
			pictureBox19.Tag = "Long bone x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Curved_bone.png");
			pictureBox20.Tag = "Curved bone x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Baby_mole.png");
			pictureBox21.Tag = "Baby mole x 1";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox22.Tag = "RDT";
			setNPictureBoxesToVisible(22);
			resetItemDropListBox();
		}
		private void kalphiteQueenToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + kalphiteQueenToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Battlestaff_noted_10.png");
			pictureBox1.Tag = "Battlestaff x 10";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Lava_battlestaff.png");
			pictureBox2.Tag = "Lava battlestaff x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_arrow_500.png");
			pictureBox3.Tag = "Mithril arrow x 500";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_arrow_250.png");
			pictureBox4.Tag = "Rune arrow x 250";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_knife_(p++)_25.png");
			pictureBox5.Tag = "Rune knife (p++) x 25";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Red_d'hide_body.png");
			pictureBox6.Tag = "Red d'hide body x 1";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_chainbody.png");
			pictureBox7.Tag = "Rune chainbody x 1";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grapes_noted_100.png");
			pictureBox8.Tag = "Grapes x 100";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_combat_potion_(2).png");
			pictureBox9.Tag = "Super combat potion (2) x 1";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Superantipoison_(2).png");
			pictureBox10.Tag = "Superantipoison (2) x 1";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ranging_potion_(3).png");
			pictureBox11.Tag = "Ranging potion (3) x 1";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Saradomin_brew_(4).png");
			pictureBox12.Tag = "Saradomin brew (4) x 1";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Super_restore_(4).png");
			pictureBox13.Tag = "Super restore (4) x 1";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Prayer_potion_(4).png");
			pictureBox14.Tag = "Prayer potion (4) x 2";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Weapon_poison_(++)_noted_5.png");
			pictureBox15.Tag = "Weapon poison (++) x 5";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Wine_of_zamorak_noted_60.png");
			pictureBox16.Tag = "Wine of zamokak x 60";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_emerald_noted_25.png");
			pictureBox17.Tag = "Uncut emerald x 25";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_ruby_noted_25.png");
			pictureBox18.Tag = "Uncut ruby x 25";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_diamond_noted_25.png");
			pictureBox19.Tag = "Uncut diamond x 25";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Watermelon_seed_25.png");
			pictureBox20.Tag = "Watermelon seed x 25";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torstol_seed_2.png");
			pictureBox21.Tag = "Torstol seed x 2";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Papaya_tree_seed_2.png");
			pictureBox22.Tag = "Papaya tree seed x 2";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Palm_tree_seed_2.png");
			pictureBox23.Tag = "Palm tree seed x 2";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_2.png");
			pictureBox24.Tag = "Magic seed x 2";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_100.png");
			pictureBox25.Tag = "Blood rune x 100";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_150.png");
			pictureBox26.Tag = "Death rune x 150";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Potato_cactus_noted_100.png");
			pictureBox27.Tag = "Potato cactus x 100";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_60.png");
			pictureBox28.Tag = "Magic logs x 60";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Toadflax_noted_25.png");
			pictureBox29.Tag = "Toadflax x 25";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ranarr_weed_noted_25.png");
			pictureBox30.Tag = "Ranarr weed x 25";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snapdragon_noted_25.png");
			pictureBox31.Tag = "Snapdragon x 25";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torstol_noted_25.png");
			pictureBox32.Tag = "Torstol x 25";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bar_noted_3.png");
			pictureBox33.Tag = "Runite bar x 3";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bucket_of_sand_noted_100.png");
			pictureBox34.Tag = "Bucket of sand x 100";
			pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Cactus_spine_noted_10.png");
			pictureBox35.Tag = "Cactus spine x 10";
			pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Gold_ore_noted_250.png");
			pictureBox36.Tag = "Gold ore x 250";
			pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ensouled_kalphite_head.png");
			pictureBox37.Tag = "Ensouled kalphite head x 1";
			pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Monkfish.png");
			pictureBox38.Tag = "Monkfish x 3";
			pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
			pictureBox39.Tag = "Shark x 2";
			pictureBox40.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_crab.png");
			pictureBox40.Tag = "Dark crab x 2";
			pictureBox41.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox41.Tag = "Varies; Coins";
			pictureBox42.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox42.Tag = "Elite clue scroll x 1";
			pictureBox43.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_2h_sword.png");
			pictureBox43.Tag = "Dragon 2h sword x 1";
			pictureBox44.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_chainbody.png");
			pictureBox44.Tag = "Dragon chainbody x 1";
			pictureBox45.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Kq_head.png");
			pictureBox45.Tag = "Kq head x 1";
			pictureBox46.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Jar_of_sand.png");
			pictureBox46.Tag = "Jar of sand x 1";
			pictureBox47.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Kalphite_princess.png");
			pictureBox47.Tag = "Kalphite princess x 1";
			pictureBox48.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox48.Tag = "RDT";
			setNPictureBoxesToVisible(48);
			resetItemDropListBox();
		}
		private void krakenToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + krakenToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_warhammer.png");
			pictureBox1.Tag = "Rune warhammer x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_longsword.png");
			pictureBox2.Tag = "Rune longsword x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_water_staff.png");
			pictureBox3.Tag = "Mystic water staff x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_robe_top_(blue).png");
			pictureBox4.Tag = "Mystic robe top (blue) x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_robe_bottom_(blue).png");
			pictureBox5.Tag = "Mystic robe bottom (blue) x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Harpoon.png");
			pictureBox6.Tag = "Harpoon x 1";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Seaweed_noted_125.png");
			pictureBox7.Tag = "Seaweed x 125";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Battlestaff_noted_10.png");
			pictureBox8.Tag = "Battlestaff x 10";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Water_rune_400.png");
			pictureBox9.Tag = "Water rune x 400";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mist_rune_100.png");
			pictureBox10.Tag = "Mist rune x 100";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_rune_250.png");
			pictureBox11.Tag = "Chaos rune x 250";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_150.png");
			pictureBox12.Tag = "Death rune x 150";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_60.png");
			pictureBox13.Tag = "Blood rune x 60";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Soul_rune_50.png");
			pictureBox14.Tag = "Soul rune x 50";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Unpowered_orb_noted_50.png");
			pictureBox15.Tag = "Unpowered orb x 50";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Diamond_noted_8.png");
			pictureBox16.Tag = "Diamond x 8";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Oak_plank_noted_60.png");
			pictureBox17.Tag = "Oak plank x 60";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Raw_shark_noted_50.png");
			pictureBox18.Tag = "Raw shark x 50";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Raw_monkfish_noted_100.png");
			pictureBox19.Tag = "Raw monkfish x 100";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bar.png");
			pictureBox20.Tag = "Runite bar x 2";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_snapdragon_noted_6.png");
			pictureBox21.Tag = "Grimy snapdragon x 6";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shark.png");
			pictureBox22.Tag = "Shark x 5";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Edible_seaweed.png");
			pictureBox23.Tag = "Edible seaweed x 5";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bucket.png");
			pictureBox24.Tag = "Bucket x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Sanfew_serum_(4).png");
			pictureBox25.Tag = "Sanfew serum (4) x 2";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Crystal_key.png");
			pictureBox26.Tag = "Crystal key x 1";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rusty_sword.png");
			pictureBox27.Tag = "Rusty sword x 1";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Antidote++_(4)_noted_2.png");
			pictureBox28.Tag = "Antidote++ (4) x 2";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Watermelon_seed_24.png");
			pictureBox29.Tag = "Watermelon seed x 24";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torstol_seed_2.png");
			pictureBox30.Tag = "Torstol seed x 2";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_1.png");
			pictureBox31.Tag = "Magic seed x 1";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pirate_boots.png");
			pictureBox32.Tag = "Pirate boots x 1";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox33.Tag = "Varies; Coins";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragonstone_ring.png");
			pictureBox34.Tag = "Dragonstone ring x 1";
			pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox35.Tag = "Elite clue scroll x 1";
			pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Trident_of_the_seas_(full).png");
			pictureBox36.Tag = "Trident of the seas (full) x 1";
			pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Kraken_tentacle.png");
			pictureBox37.Tag = "Kraken tentacle x 1";
			pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Jar_of_dirt.png");
			pictureBox38.Tag = "Jar of dirt x 1";
			pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_kraken.png");
			pictureBox39.Tag = "Pet kraken x 1";
			pictureBox40.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox40.Tag = "RDT";
			setNPictureBoxesToVisible(40);
			resetItemDropListBox();
		}
		private void skotizoToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + skotizoToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_500.png");
			pictureBox1.Tag = "Death rune x 500";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Soul_rune_450.png");
			pictureBox2.Tag = "Soul rune x 450";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Blood_rune_450.png");
			pictureBox3.Tag = "Blood rune x 450";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_platebody_noted_3.png");
			pictureBox4.Tag = "Rune platebody x 3";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_kiteshield_noted_3.png");
			pictureBox5.Tag = "Rune kiteshield x 3";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_platelegs_noted_3.png");
			pictureBox6.Tag = "Rune platelegs x 3";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_plateskirt_noted_3.png");
			pictureBox7.Tag = "Rune plateskirt x 3";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_ranarr_weed_noted_40.png");
			pictureBox8.Tag = "Grimy ranarr x 40";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_snapdragon_noted_20.png");
			pictureBox9.Tag = "Grimy snapdragon x 20";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_torstol_noted_20.png");
			pictureBox10.Tag = "Grimy torstol x 20";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Battlestaff_noted_25.png");
			pictureBox11.Tag = "Battlestaff x 25";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_dragonstone_noted_10.png");
			pictureBox12.Tag = "Uncut dragonstone x 10";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamantite_ore_noted_75.png");
			pictureBox13.Tag = "Adamantite ore x 75";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_bar_noted_20.png");
			pictureBox14.Tag = "Runite bar x 20";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Raw_anglerfish_noted_60.png");
			pictureBox15.Tag = "Raw anglerfish x 60";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mahogany_plank_noted_150.png");
			pictureBox16.Tag = "Mahogany plank x 150";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Shield_left_half.png");
			pictureBox17.Tag = "Shield left half x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_totem_base.png");
			pictureBox18.Tag = "Dark totem base x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_totem_middle.png");
			pictureBox19.Tag = "Dark totem middle x 1";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dark_totem.png");
			pictureBox20.Tag = "Dark totem x 1";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Onyx_bolt_tips_40.png");
			pictureBox21.Tag = "Onyx bolt tips x 40";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_onyx.png");
			pictureBox22.Tag = "Uncut onyx x 1";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Hard_clue_scroll.png");
			pictureBox23.Tag = "Hard clue scroll x 1";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox24.Tag = "Elite clue scroll x 1";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Jar_of_darkness.png");
			pictureBox25.Tag = "Jar of darkness x 1";
			setNPictureBoxesToVisible(25);
			resetItemDropListBox();
		}
		private void thermonuclearSmokeDevilToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + thermonuclearSmokeDevilToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_dagger.png");
			pictureBox1.Tag = "Rune dagger x 1";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_scimitar.png");
			pictureBox2.Tag = "Rune scimitar x 1";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_battleaxe.png");
			pictureBox3.Tag = "Rune battleaxe x 1";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_air_staff.png");
			pictureBox4.Tag = "Mystic air staff x 1";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mystic_fire_staff.png");
			pictureBox5.Tag = "Mystic fire staff x 1";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_scimitar.png");
			pictureBox6.Tag = "Dragon scimitar x 1";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fire_talisman.png");
			pictureBox7.Tag = "Fire talisman x 1";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ancient_staff.png");
			pictureBox8.Tag = "Ancient staff x 1";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Red_d'hide_body.png");
			pictureBox9.Tag = "Red d'hide body x 1";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_chainbody.png");
			pictureBox10.Tag = "Rune chainbody x 1";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Smoke_rune_100.png");
			pictureBox11.Tag = "Smoke rune x 100";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Air_rune_300.png");
			pictureBox12.Tag = "Air rune x 300";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Soul_rune_60.png");
			pictureBox13.Tag = "Soul rune x 60";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_knife_(p++)_50.png");
			pictureBox14.Tag = "Rune knife (p++) x 50";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Rune_arrow_100.png");
			pictureBox15.Tag = "Rune arrow x 100";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snapdragon_seed_2.png");
			pictureBox16.Tag = "Snapdragon seed x 2";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_1.png");
			pictureBox17.Tag = "Magic seed x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pure_essence_noted_300.png");
			pictureBox18.Tag = "Pure essence x 300";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Desert_goat_horn_noted_50.png");
			pictureBox19.Tag = "Desert goat horn x 50";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Molten_glass_noted_100.png");
			pictureBox20.Tag = "Molten glass x 100";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mithril_bar_noted_20.png");
			pictureBox21.Tag = "Mithril bar x 20";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grimy_toadflax_noted_15.png");
			pictureBox22.Tag = "Grimy toadflax x 15";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coal_noted_150.png");
			pictureBox23.Tag = "Coal x 150";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Gold_ore_noted_200.png");
			pictureBox24.Tag = "Gold ore x 200";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Onyx_bolt_tips_12.png");
			pictureBox25.Tag = "Onyx bolt tips x 12";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grapes_noted_100.png");
			pictureBox26.Tag = "Grapes x 100";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Diamond_noted_10.png");
			pictureBox27.Tag = "Diamond x 10";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_20.png");
			pictureBox28.Tag = "Magic logs x 20";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Ugthanki_kebab.png");
			pictureBox29.Tag = "Ugthanki kebab x 3";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Tuna_potato.png");
			pictureBox30.Tag = "Tuna potato x 3";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Prayer_potion_(4).png");
			pictureBox31.Tag = "Prayer potion (4) x 2";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Sanfew_serum_(4).png");
			pictureBox32.Tag = "Sanfew serum (4) x 2";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Tinderbox.png");
			pictureBox33.Tag = "Tinderbox x 1";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coins_10000.png");
			pictureBox34.Tag = "Varies; Coins";
			pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Bullseye_lantern_(unlit).png");
			pictureBox35.Tag = "Bullseye lantern (unlit) x 1";
			pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragonstone_ring.png");
			pictureBox36.Tag = "Dragonstone ring x 1";
			pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Crystal_key.png");
			pictureBox37.Tag = "Crystal key x 1";
			pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox38.Tag = "Elite clue scroll x 1";
			pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Smoke_battlestaff.png");
			pictureBox39.Tag = "Smoke battlestaff x 1";
			pictureBox40.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Occult_necklace.png");
			pictureBox40.Tag = "Occult necklace x 1";
			pictureBox41.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_chainbody.png");
			pictureBox41.Tag = "Dragon chainbody x 1";
			pictureBox42.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_smoke_devil.png");
			pictureBox42.Tag = "Pet smoke devil x 1";
			pictureBox43.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox43.Tag = "RDT";
			setNPictureBoxesToVisible(43);
			resetItemDropListBox();
		}
		private void zulrahToolStripMenuItem_Click(object sender, EventArgs e) {
			labelCurrentLogFor.Text = "Current log for: " + zulrahToolStripMenuItem.Text;
			pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pure_essence_noted_1500.png");
			pictureBox1.Tag = "Pure essence x 1500";
			pictureBox2.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Law_rune_200.png");
			pictureBox2.Tag = "Law rune x 200";
			pictureBox3.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Chaos_rune_500.png");
			pictureBox3.Tag = "Chaos rune x 500";
			pictureBox4.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Death_rune_300.png");
			pictureBox4.Tag = "Death rune x 300";
			pictureBox5.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Toadflax_noted_20.png");
			pictureBox5.Tag = "Toadflax x 20";
			pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snapdragon_noted_20.png");
			pictureBox6.Tag = "Snapdragon x 20";
			pictureBox7.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dwarf_weed_noted_20.png");
			pictureBox7.Tag = "Dwarf weed x 20";
			pictureBox8.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torstol_noted_20.png");
			pictureBox8.Tag = "Torstol x 20";
			pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Toadflax_seed_2.png");
			pictureBox9.Tag = "Toadflax seed x 2";
			pictureBox10.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snapdragon_seed_2.png");
			pictureBox10.Tag = "Snapdragon seed x 2";
			pictureBox11.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dwarf_weed_seed_2.png");
			pictureBox11.Tag = "Dwarf weed seed x 2";
			pictureBox12.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Torstol_seed_2.png");
			pictureBox12.Tag = "Torstol seed x 2";
			pictureBox13.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Papaya_tree_seed_2.png");
			pictureBox13.Tag = "Papaya tree seed x 2";
			pictureBox14.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Palm_tree_seed_1.png");
			pictureBox14.Tag = "Palm tree seed x 1";
			pictureBox15.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_seed_1.png");
			pictureBox15.Tag = "Magic seed x 1";
			pictureBox16.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Calquat_tree_seed_2.png");
			pictureBox16.Tag = "Calquat tree seed x 2";
			pictureBox17.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Spirit_seed_1.png");
			pictureBox17.Tag = "Spirit seed x 1";
			pictureBox18.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Crystal_seed.png");
			pictureBox18.Tag = "Crystal seed x 1";
			pictureBox19.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Flax_noted_1000.png");
			pictureBox19.Tag = "Flax x 1000";
			pictureBox20.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Snakeskin_noted_35.png");
			pictureBox20.Tag = "Snakeskin x 35";
			pictureBox21.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_bolt_tips_12.png");
			pictureBox21.Tag = "Dragon bolt tips x 12";
			pictureBox22.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_logs_noted_100.png");
			pictureBox22.Tag = "Magic logs x 100";
			pictureBox23.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coal_noted_300.png");
			pictureBox23.Tag = "Coal x 300";
			pictureBox24.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Runite_ore_noted_10.png");
			pictureBox24.Tag = "Runite ore x 10";
			pictureBox25.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Adamantite_bar_noted_25.png");
			pictureBox25.Tag = "Adamantite bar x 25";
			pictureBox26.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Mahogany_plank_noted_50.png");
			pictureBox26.Tag = "Mahogany plank x 50";
			pictureBox27.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_bones_noted_30.png");
			pictureBox27.Tag = "Dragon bones x 30";
			pictureBox28.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Coconut_noted_20.png");
			pictureBox28.Tag = "Coconut x 20";
			pictureBox29.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Grapes_noted_250.png");
			pictureBox29.Tag = "Grapes x 250";
			pictureBox30.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Zul-andra_teleport.png");
			pictureBox30.Tag = "Zul-andra teleport x 1";
			pictureBox31.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Zulrah's_scales_500.png");
			pictureBox31.Tag = "Zulrah's scales x 500";
			pictureBox32.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Battlestaff_noted_10.png");
			pictureBox32.Tag = "Battlestaff x 10";
			pictureBox33.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Antidote++_(4)_noted_10.png");
			pictureBox33.Tag = "Antidote++ (4) x 10";
			pictureBox34.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Raw_shark_noted_100.png");
			pictureBox34.Tag = "Raw shark x 100";
			pictureBox35.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Swamp_tar_1000.png");
			pictureBox35.Tag = "Swamp tar x 1000";
			pictureBox36.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Saradomin_brew_(4)_noted_10.png");
			pictureBox36.Tag = "Saradomin brew (4) x 10";
			pictureBox37.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Serpentine_visage.png");
			pictureBox37.Tag = "Serpentine visage x 1";
			pictureBox38.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magic_fang.png");
			pictureBox38.Tag = "Magic fang x 1";
			pictureBox39.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Tanzanite_fang.png");
			pictureBox39.Tag = "Tanzanite fang x 1";
			pictureBox40.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Uncut_onyx.png");
			pictureBox40.Tag = "Uncut onyx x 1";
			pictureBox41.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_med_helm.png");
			pictureBox41.Tag = "Dragon med helm x 1";
			pictureBox42.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Dragon_halberd.png");
			pictureBox42.Tag = "Dragon halberd x 1";
			pictureBox43.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Elite_clue_scroll.png");
			pictureBox43.Tag = "Elite clue scroll x 1";
			pictureBox44.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Tanzanite_mutagen.png");
			pictureBox44.Tag = "Tanzanite mutagen x 1";
			pictureBox45.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Magma_mutagen.png");
			pictureBox45.Tag = "Magma mutagen x 1";
			pictureBox46.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Jar_of_swamp.png");
			pictureBox46.Tag = "Jar of swamp x 1";
			pictureBox47.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Pet_snakeling.png");
			pictureBox47.Tag = "Pet snakeling x 1";
			pictureBox48.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/RDT.png");
			pictureBox48.Tag = "RDT";
			setNPictureBoxesToVisible(48);
			resetItemDropListBox();
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
		
		public void highlightPictureBox(PictureBox pb, Boolean resetAll = true) {
			if (pb.Name == "pictureBoxDagannothPrime" ||
				pb.Name == "pictureBoxDagannothRex" ||
				pb.Name == "pictureBoxDagannothSupreme") {

				pictureBoxDagannothPrime.BackColor = Color.Transparent;
				pictureBoxDagannothRex.BackColor = Color.Transparent;
				pictureBoxDagannothSupreme.BackColor = Color.Transparent;
				pb.BackColor = Color.FromArgb(192, 255, 192);
			}
			else {
				// Only reset the pictures if it is set - this will not reset pictures when control is held
				if (resetAll) {
					resetAllPictureBoxBackgroundColor();
				}

				// Still change the picture box that was clicked
				pb.BackColor = hightlightOrange;
			}
		}

		public void pictureBox_Click(object sender, EventArgs e) {

			Boolean isControlPressed = false;
			PictureBox pbSender = (PictureBox)sender;
			String unloggedItem = pbSender.Tag.ToString();

			

			if (Control.ModifierKeys == Keys.Control) { isControlPressed = true; }


			// PictureBoxes to switch between the dagannoth kings behave differently,
			// don't want to do anything besides show the new items
			if (pbSender.Name == "pictureBoxDagannothPrime" ||
				pbSender.Name == "pictureBoxDagannothRex" ||
				pbSender.Name == "pictureBoxDagannothSupreme") {
				return;
			}

			// Open new window and handle RDT drops
			if (pbSender.Tag.ToString() == "RDT") {

				// Check if RDT is already open, if not, open it
				if (!isFormOpen("RareDropTableForm")) {
					RareDropTableForm rdt = new RareDropTableForm();
					// TODO give specific coordinates to where the RDT window opens
					//rdt.StartPosition = FormStartPosition.CenterParent;
					rdt.Show();
				}
			}

			// Else so RDT and "Varies" case don't occur together - never will unless RDT is updated with varying item amounts
			// Handle items that drop varying amounts
			else if (pbSender.Tag.ToString().Substring(0, 6) == "Varies") {
				PictureBox pb = (PictureBox)sender;

				// Get the tag of the selected item
				String item = pb.Tag.ToString().Substring(pb.Tag.ToString().IndexOf(";") + 2);

				highlightPictureBox(pbSender);
				labelAddCustomDrop.Text = "Enter amount:";

				// Use the retrieved tag and prepare it for the user to just enter a number after
				String preparedItem = item + " x ";

				// Handle control clicking of these items that have to be manually entered
				// Handled by placing a comma at the beginning of the string so when the "add custom drop" button is clicked
				// it knows where to place the item based on if that comma is there or not
				if (isControlPressed) {
					preparedItem = ", " + preparedItem;
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

					//printStringList(listboxItemsList);
					
					// Make sure there is at least one item to add a control clicked item to since it will have to be removed
					if (listboxItemsList.Count <= 1) { return; }

					// Get second to last item from the listboxItemsList (second to last since the ctrl-clicked item was already added)
					String lastItemInListBoxItemsList = listboxItemsList[listboxItemsList.Count - 2];

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
					List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());

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

			// Update the list box
			updateListBox();
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

		private List<PictureBox> getHighlightedPictureBox() {
			List<PictureBox> hpb = new List<PictureBox>();
			foreach (var pb in this.Controls.OfType<PictureBox>()) {
				if (pb.BackColor == hightlightOrange) {
					hpb.Add(pb);
				}
			}
			return hpb;
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

			Console.WriteLine("1:" + e.KeyCode);
			if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) && this.ActiveControl == textboxCustomDrop) {
				e.SuppressKeyPress = true;
				buttonAddCustomDrop.Click += buttonAddCustomDrop_Click;	
			}
		}

		void oldSchoolDropLoggerForm_KeyPress(object sender, KeyPressEventArgs e) {
			Console.WriteLine("2: " + e.KeyChar);
		}

		private void buttonAddCustomDrop_Click(object sender, EventArgs e) {

			String unloggedItem = textboxCustomDrop.Text;

			if (unloggedItem == "" || unloggedItem == null) return;

			// If there is a comma as the first character in the submitted string, we know that it was
			// control-clicked so it needs to be added to the previous item rather than a new line
			Console.WriteLine(unloggedItem);
			Console.WriteLine(unloggedItem.IndexOf(","));

			if (unloggedItem.IndexOf(",") == 0) {

				// Make sure there is at least one item to add a control clicked item to since it will have to be removed
				if (listboxItemsList.Count <= 0) { return; }

				// Get second to last item from the listboxItemsList (second to last since the ctrl-clicked item was already added)
				String lastItemInListBoxItemsList = listboxItemsList[listboxItemsList.Count - 1];

				// Remove the item previously logged so we can replace it with itself + the control-clicked item
				listboxItemsList.RemoveAt(listboxItemsList.Count - 1);

				// Create the new string to add
				String concatenatedItems = lastItemInListBoxItemsList + unloggedItem;

				// Add the new item to the listboxItemsList
				listboxItemsList.Add(concatenatedItems);

				/* File writing */
				// Write new item to file
				List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());

				// Need to remove the standalone item from the file and then re-add the concatenated items in
				loggedItems.RemoveAt(loggedItems.Count - 1);
				loggedItems = addItemToLoggedItems(loggedItems, concatenatedItems);
				writeLoggedItemsToFile(loggedItems, getCurrentBoss());
				/* End file writing */
			}
			else {

				listboxItemsList.Add(unloggedItem);

				// Prepare the item and add to list box
				prepareAndAddItemToListBox(unloggedItem);

				// Write new item to file
				List<String> loggedItems = getLoggedItemsFromFile(getCurrentBoss());
				loggedItems = addItemToLoggedItems(loggedItems, unloggedItem);
				writeLoggedItemsToFile(loggedItems, getCurrentBoss());
				
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

			// Remove the item from the list box
			//itemDropListBox.Items.RemoveAt(itemDropListBox.Items.Count - 1);

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
		private void resetItemDropListBox() {
			listboxItemsList.Clear();
			itemDropListBox.Items.Clear();
		}

		/* Constructor */
		public oldSchoolDropLoggerForm() {
			InitializeComponent();

			// Add click listener to each picturebox
			foreach (Control c in this.Controls) {
				if (c is PictureBox) c.Click += pictureBox_Click;
			}
		}

		public void printStringList(List<String> list) {
			Console.WriteLine("\n================= String List =====================");
			foreach (String s in list) {
				Console.WriteLine(s);
			}
			Console.WriteLine("====================================================\n");
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

			putAllPictureBoxesIntoList();
		}
		private void putAllPictureBoxesIntoList() {
			// Put all pictureboxes into allPictureBoxes list
			Control[] c;
			for (int i = 1; i <= 56; i++) {
				c = this.Controls.Find("pictureBox" + i.ToString(), true);
				allPictureBoxes.Add((PictureBox)c[0]);
			}
		}
		private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e) {
			if (alwaysOnTopCheckBox.Checked == true) {
				this.TopMost = true;
			}
			else {
				this.TopMost = false;
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
		private void setNPictureBoxesToVisible(int n, String boss = "") {
			if (boss == "Dagannoth Kings") {
				pictureBoxDagannothPrime.Show();
				pictureBoxDagannothRex.Show();
				pictureBoxDagannothSupreme.Show();
				//make prime selected by default
			}
			else {
				pictureBoxDagannothPrime.Hide();
				pictureBoxDagannothRex.Hide();
				pictureBoxDagannothSupreme.Hide();
			}
			switch (n) {
				case 20:
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
					pictureBox21.Visible = false;
					pictureBox22.Visible = false;
					pictureBox23.Visible = false;
					pictureBox24.Visible = false;
					pictureBox25.Visible = false;
					pictureBox26.Visible = false;
					pictureBox27.Visible = false;
					pictureBox28.Visible = false;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 21:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = false;
					pictureBox23.Visible = false;
					pictureBox24.Visible = false;
					pictureBox25.Visible = false;
					pictureBox26.Visible = false;
					pictureBox27.Visible = false;
					pictureBox28.Visible = false;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 22:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = false;
					pictureBox24.Visible = false;
					pictureBox25.Visible = false;
					pictureBox26.Visible = false;
					pictureBox27.Visible = false;
					pictureBox28.Visible = false;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 23:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = false;
					pictureBox25.Visible = false;
					pictureBox26.Visible = false;
					pictureBox27.Visible = false;
					pictureBox28.Visible = false;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 24:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = false;
					pictureBox26.Visible = false;
					pictureBox27.Visible = false;
					pictureBox28.Visible = false;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 25:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = false;
					pictureBox27.Visible = false;
					pictureBox28.Visible = false;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 26:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = false;
					pictureBox28.Visible = false;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 27:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = false;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 28:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = false;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 29:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = false;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 30:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = false;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 31:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = false;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 32:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = false;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 33:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = false;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 34:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = false;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 35:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = false;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 36:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = false;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 37:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = false;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 38:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = false;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 39:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = false;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 40:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = false;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 41:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = false;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 42:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = false;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 43:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = false;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 44:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = false;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 45:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = false;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 46:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = false;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 47:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = false;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 48:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = false;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 49:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 50:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = false;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 51:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = false;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 52:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = false;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 53:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = true;
					pictureBox53.Visible = false;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 54:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = true;
					pictureBox53.Visible = true;
					pictureBox54.Visible = false;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 55:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = true;
					pictureBox53.Visible = true;
					pictureBox54.Visible = true;
					pictureBox55.Visible = false;
					pictureBox56.Visible = false;
					break;
				case 56:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = true;
					pictureBox53.Visible = true;
					pictureBox54.Visible = true;
					pictureBox55.Visible = true;
					pictureBox56.Visible = false;
					break;
				case 57:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = true;
					pictureBox53.Visible = true;
					pictureBox54.Visible = true;
					pictureBox55.Visible = true;
					pictureBox56.Visible = true;
					break;
				case 58:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = true;
					pictureBox53.Visible = true;
					pictureBox54.Visible = true;
					pictureBox55.Visible = true;
					pictureBox56.Visible = true;
					break;
				case 59:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = true;
					pictureBox53.Visible = true;
					pictureBox54.Visible = true;
					pictureBox55.Visible = true;
					pictureBox56.Visible = true;
					break;
				case 60:
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
					pictureBox21.Visible = true;
					pictureBox22.Visible = true;
					pictureBox23.Visible = true;
					pictureBox24.Visible = true;
					pictureBox25.Visible = true;
					pictureBox26.Visible = true;
					pictureBox27.Visible = true;
					pictureBox28.Visible = true;
					pictureBox29.Visible = true;
					pictureBox30.Visible = true;
					pictureBox31.Visible = true;
					pictureBox32.Visible = true;
					pictureBox33.Visible = true;
					pictureBox34.Visible = true;
					pictureBox35.Visible = true;
					pictureBox36.Visible = true;
					pictureBox37.Visible = true;
					pictureBox38.Visible = true;
					pictureBox39.Visible = true;
					pictureBox40.Visible = true;
					pictureBox41.Visible = true;
					pictureBox42.Visible = true;
					pictureBox43.Visible = true;
					pictureBox44.Visible = true;
					pictureBox45.Visible = true;
					pictureBox46.Visible = true;
					pictureBox47.Visible = true;
					pictureBox48.Visible = true;
					pictureBox49.Visible = true;
					pictureBox50.Visible = true;
					pictureBox51.Visible = true;
					pictureBox52.Visible = true;
					pictureBox53.Visible = true;
					pictureBox54.Visible = true;
					pictureBox55.Visible = true;
					pictureBox56.Visible = true;
					break;
			}
		}

		private void testToolStripMenuItem_Click(object sender, EventArgs e) {

			ItemQuantityCreator iqc = new ItemQuantityCreator();

			pictureBox57.Image = iqc.createQuantityImage(19467904);

		}
	}
}
