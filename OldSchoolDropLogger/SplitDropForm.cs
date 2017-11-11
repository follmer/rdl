using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace splitDrop {
	public partial class SplitDropForm : Form {

		public static SplitDropForm instance;

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
			}

			if (string.IsNullOrWhiteSpace(splitAmountText)) {
				Console.WriteLine("[DEBUG]: splitAmountText is empty or null");
			}

			int splitAmount = Int32.Parse(splitAmountText);

			Console.WriteLine("[DEBUG]: splitItem = " + splitItem);
			Console.WriteLine("[DEBUG]: splitAmount = " + splitAmount);

		}

		private void buttonSplitCancel_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
