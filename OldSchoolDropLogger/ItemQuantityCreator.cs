using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using OldSchoolDropLogger.Properties;

namespace itemQuantityCreator {
	class ItemQuantityCreator {

		public Bitmap createQuantityImage(int quantity) {

			// Default quantity color is yellow and there is no ending letter
			String textColor = "_yellow";
			String endingLetter = "";

			// If the quantity is over 10M, change the color to green and only pull the 10 from 10,000,000 and indicate a trailing M
			if (quantity >= 10000000) {
				textColor = "_green";
				quantity = quantity / 1000000;
				endingLetter = "M";
			}
			// Same case but for items between 100,000 and 9,999,999 => white color and add a K
			else if (quantity >= 100000) {
				textColor = "_white";
				quantity = quantity / 1000;
				endingLetter = "K";
			}

			String number = quantity.ToString();

			// Since some of the numbers are of smaller width and look different, keep track of this and modify offset as necessary
			int modifyOffset = 0;
			if (number[0] == '1') {
				modifyOffset = -1;
			}
			//else if (number[0] == '4') {
			//	modifyOffset = -1;
			//}

			// Fetch a bitmap of the first number in the quantity with the correct text color
			// This is the starting image that other images will be "appended" to
			Bitmap first = new Bitmap(getNumberImage((int) Char.GetNumericValue(number[0]), textColor));

			// If the quantity is between 0 and 9, the string length is only 1, so we can just return
			// the correct bitmap image without having to do any magic
			if (quantity >= 0 && quantity < 10) {

				// Create a new bitmap with the same dimensions as our number
				Bitmap firstShifted = new Bitmap(first.Width, first.Height + 2);

				// Draw the number with an offset of 2 from the left (to match real item quantities)
				Graphics gr = Graphics.FromImage(firstShifted);
				gr.DrawImageUnscaled(first, 2, 2);

				return firstShifted;
			}

			// Result bitmap uninstantiated
			Bitmap result = null;

			// Loop through all numbers in the quantity that will be shown
			// 10,000,000	=> 10
			// 9,403		=> 9403
			// 463,291		=> 463
			for (int i = 1; i < number.Length; i++) {

				// Second bitmap to be appended to the first bitmap
				Bitmap second = new Bitmap(getNumberImage((int)Char.GetNumericValue(number[i]), textColor));

				// Add the widths, height does not matter as they are both the same height always
				result = new Bitmap(first.Width + second.Width + modifyOffset, first.Height + 2);

				if (number[i - 1] == '1') {
					modifyOffset = -1;
				}
				else if (number[i - 1] == '4') {
					modifyOffset = -2;
				}
				else {
					modifyOffset = 0;
				}

				// If we reach the end of the number, but there's no K or M to append,
				// shift the entire bitmap 2 px to the right and 2 px down so it looks correct
				//
				// Else continue on as normal
				if (i == (number.Length - 1) && endingLetter == "") {
					result = new Bitmap(first.Width + second.Width + 2, first.Height + 2);
					Graphics g = Graphics.FromImage(result);
					g.DrawImageUnscaled(first, 2, 2);
					g.DrawImageUnscaled(second, first.Width + 2 + modifyOffset, 2);
				}
				else {
					Graphics g = Graphics.FromImage(result);
					g.DrawImageUnscaled(first, 0, 0);
					g.DrawImageUnscaled(second, first.Width + modifyOffset, 0);
				}

				// Update the baseline bitmap
				first = result;
				
				// If we reach the end of the number and it needs a K or M appended, do so
				if (i == number.Length - 1) {
					if (endingLetter != "") {
						Bitmap orig = new Bitmap(getNumberImage((int)Char.GetNumericValue(number[i]), textColor, endingLetter));

						if (orig == null) {
							Console.WriteLine("[DEBUG]: IQC 'orig' was null.");
							Console.Read();
						}
						// Combine bitmaps again // + 2 offset to move entire bitmap 2px right
						result = new Bitmap(first.Width + orig.Width + 2, first.Height);

						// Redraw, same as above // + 2 offset to move entire bitmap 2px right
						Graphics gr = Graphics.FromImage(result);
						gr.DrawImageUnscaled(first, 2, 2); // Place 2px right
						gr.DrawImageUnscaled(orig, first.Width + 2 + modifyOffset, 2);
					}
				}
			}

			// Returns the quantity to be shown with the appropriate letter and appropriate colors
			return result;
		}

		private Bitmap getNumberImage(int number, String textColor, String endingLetter = "") {

			// Item is more than 100k so need to fetch a letter K or M
			if (endingLetter != "") {

				if (Resources.ResourceManager.GetObject(endingLetter) == null) {
					Console.WriteLine("[DEBUG]: Resource manager unable to fetch IQC letter image.");
					Console.ReadLine();
				}
				else {
					return (Bitmap)Resources.ResourceManager.GetObject(endingLetter);
				}
					
				//return (Bitmap)Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Numbers/" + endingLetter + ".png");
			}
			// TODO the above is returning just a letter, while below its returning a color, not 100% if thats right, but i think it is
			// Fetch the correct number with the correct color
			if (Resources.ResourceManager.GetObject("_" + number.ToString() + textColor) == null) {
				Console.WriteLine("[DEBUG]: Resource manager unable to fetch IQC number image.");
				Console.ReadLine();
			}
			else {
				return (Bitmap)Resources.ResourceManager.GetObject("_" + number.ToString() + textColor);
			}
			return null;
			//return (Bitmap)Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Numbers/" + number.ToString() + textColor + ".png");
		}

		public ItemQuantityCreator() {

		}
	}
}
