using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Config {
	class Settings {

		public Dictionary<String, String> settings = new Dictionary<String, String>();
		private String settingsFile = AppDomain.CurrentDomain.BaseDirectory + "Settings.conf";
		private String defaultBoss = "Armdayl";

		public Dictionary<String, String> getSettings() {
			return settings;
		}
		public String getDefaultBoss() {
			return defaultBoss;
		}

		public void setSettings() {

			try {

				String[] lines = File.ReadAllLines(settingsFile);

				foreach (String line in lines) {

					if (line.StartsWith(";") || line.Length == 0 || line.IndexOf("=") == -1) {
						continue;
					}
					else {

						int indexOfEquals = line.IndexOf("=");
						String setting = line.Substring(0, indexOfEquals);
						String value = line.Substring(indexOfEquals + 1);

						settings.Add(setting, value);
					}
				}
			}
			catch (FileNotFoundException) { }
		}

		// Looks for and if found, sets DEFAULT_BOSS 
		// 
		// Default = Armadyl
		public void setDefaultBoss() {

			if (settings.ContainsKey("DEFAULT_BOSS")) {
				if (settings["DEFAULT_BOSS"] != "") { defaultBoss = settings["DEFAULT_BOSS"]; }
			}
		}

		public void printSettings() {
			Console.WriteLine("\n===================== Settings =====================");
			foreach (KeyValuePair<String,String> s in settings) {
				Console.WriteLine(s);
			}
			Console.WriteLine("====================================================\n");
		}

		public Settings() {
			setSettings();
			setDefaultBoss();
		}
	}
}
