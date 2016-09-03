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

namespace rareDropTable {
	public partial class RareDropTableForm : Form {

		public static RareDropTableForm instance;
		private List<PictureBox> allRDTPictureBoxes = new List<PictureBox>();

		private void pictureBox_Click(object sender, EventArgs e) {

			// Grabs the instance of oldSchoolDropLoggerForm rather than creating a new instance
			oldSchoolDropLoggerForm f = oldSchoolDropLoggerForm.instance;
			f.pictureBox_Click(sender, e);

			// Change background color for each RDT PictureBox
			PictureBox pb = (PictureBox)sender;
			resetRDTPictureBoxBackgroundColor();
			pb.BackColor = Color.FromArgb(179, 107, 0);
		}
		public void putRDTPictureBoxesIntoList() {
			// Put all RDT pictureboxes into allRDTPictureBoxes list
			Control[] d;
			for (int i = 1; i <= 28; i++) {
				d = this.Controls.Find("pictureBox" + i.ToString(), true);
				allRDTPictureBoxes.Add((PictureBox)d[0]);
			}
		}
		public void resetRDTPictureBoxBackgroundColor() {
			foreach (PictureBox a in allRDTPictureBoxes) {
				a.BackColor = Color.Transparent;
			}
		}
		public RareDropTableForm() {
			InitializeComponent();

			// Add click listener to each picturebox
			foreach (Control c in this.Controls) {
				if (c is PictureBox) c.Click += pictureBox_Click;
			}

			putRDTPictureBoxesIntoList();

			pictureBox1.Tag = "RDT: Law rune x 45";
			pictureBox2.Tag = "RDT: Nature rune x 67";
			pictureBox3.Tag = "RDT: Death rune x 45";
			pictureBox4.Tag = "RDT: Steel arrow x 150";
			pictureBox5.Tag = "RDT: Rune arrow x 42";
			pictureBox6.Tag = "RDT: Adamant javelin x 20";
			pictureBox7.Tag = "RDT: Uncut sapphire x 1";
			pictureBox8.Tag = "RDT: Uncut emerald x 1";
			pictureBox9.Tag = "RDT: Uncut ruby x 1";
			pictureBox10.Tag = "RDT: Uncut diamond x 1";
			pictureBox11.Tag = "RDT: Dragonstone x 1";
			pictureBox12.Tag = "RDT: Rune javelin x 5";
			pictureBox13.Tag = "RDT: Runite bar x 1";
			pictureBox14.Tag = "RDT: Silver ore x 100";
			pictureBox15.Tag = "RDT: Chaos talisman x 1";
			pictureBox16.Tag = "RDT: Nature talisman x 1";
			pictureBox17.Tag = "RDT: Coins 3000 x 1";
			pictureBox18.Tag = "RDT: Loop half of key x 1";
			pictureBox19.Tag = "RDT: Rune spear x 1";
			pictureBox20.Tag = "RDT: Rune 2h sword x 1";
			pictureBox21.Tag = "RDT: Rune battleaxe x 1";
			pictureBox22.Tag = "RDT: Rune sq shield x 1";
			pictureBox23.Tag = "RDT: Rune kiteshield x 1";
			pictureBox24.Tag = "RDT: Tooth half of key x 1";
			pictureBox25.Tag = "RDT: Dragon med helm x 1";
			pictureBox26.Tag = "RDT: Shield left half x 1";
			pictureBox27.Tag = "RDT: Dragon spear x 1";
			pictureBox28.Tag = "RDT: None";
		}
		private void buttonCloseRDT_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
