using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace itemQuantityCreator {
	class ItemQuantityCreator {

		public Bitmap createQuantityImage(int quantity) {

			Console.WriteLine("ItemQuantityCreator.createQuantityImage(): " + quantity);

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

			

			// Fetch a bitmap of the first number in the quantity with the correct text color
			// This is the starting image that other images will be "appended" to
			Bitmap first = new Bitmap(getNumberImage((int) Char.GetNumericValue(number[0]), textColor));

			// If the quantity is between 0 and 9, the string length is only 1, so we can just return
			// the correct bitmap image without having to do any magic
			if (quantity >= 0 && quantity < 10) return first;

			// Result bitmap uninstantiated
			Bitmap result = null;

			// Loop through all numbers in the quantity that will be shown
			// 10,000,000	=> 10
			// 9,403		=> 9403
			// 463,291		=> 463
			for (int i = 1; i < number.Length; i++) {
				
				// Second bitmap to be appended to the first bitmap
				Bitmap second = new Bitmap(getNumberImage((int) Char.GetNumericValue(number[i]), textColor));

				// Add the widths, height does not matter as they are both the same height always
				result = new Bitmap(first.Width + second.Width, first.Height);

				// Create the image at the specified location with specified size (from docs)
				Graphics g = Graphics.FromImage(result);
				g.DrawImageUnscaled(first, 0, 0);
				g.DrawImageUnscaled(second, first.Width, 0);

				// Update the baseline bitmap
				first = result;

				// If we reach the end of the number and it needs a K or M appended, do so
				if (i == number.Length - 1) {
					if (endingLetter != "") {
						Bitmap orig = new Bitmap(getNumberImage((int)Char.GetNumericValue(number[i]), textColor, endingLetter));

						// Combine bitmaps again
						result = new Bitmap(first.Width + orig.Width, first.Height);

						// Redraw, same as above
						Graphics gr = Graphics.FromImage(result);
						gr.DrawImageUnscaled(first, 0, 0);
						gr.DrawImageUnscaled(orig, first.Width, 0);
					}
				}
			}
			Console.WriteLine(result);
			// Returns the quantity to be shown with the appropriate letter and appropriate colors
			return result;
		}

		private Bitmap getNumberImage(int number, String textColor, String endingLetter = "") {

			// Item is more than 100k so need to fetch a letter K or M
			if (endingLetter != "") {
				return (Bitmap)Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Numbers/" + endingLetter + ".png");
			}

			// Fetch the correct number with the correct color
			return (Bitmap)Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Numbers/" + number.ToString() + textColor + ".png");
		}

		public ItemQuantityCreator() {

		}
	}
}
