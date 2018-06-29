using System;
using System.Collections.Generic;

namespace Wardrobe {
	
	// TODO: Log rotation - use FileManger.GetInfo()["Length"] to rotate files based on lines

	static class Logger {
		private static string file = "./log";
		private static List<string> levels = new List<string>{ "Info", "Warn", "Error", "Holy Shit" };
		private static int errorLevel = 2;
		private static int warnLevel = 1;
		private static int infoLevel = 0;
		private static int logLimit = 1000000;

		private static string FormatLine(string line, string severity = "") {
			string date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
			string result = date + "	" + severity + "	" + line;
			return result;
		}

		private static bool NeedsRotation() {
			Dictionary<string, string> info = FileManager.GetInfo(file);
			if (Int32.Parse(info["Length"]) >= logLimit) {
				return true;
			}
			return false;
		}

		private static void Rotate() {
			// Rename the old $file to $file.$date
		}

		private static void Write(string line) {
			if (NeedsRotation()) Rotate();
			FileManager.Append(file, line);
		}

		public static void Log(string line, string severity) {
			Write(FormatLine(line, severity));
		}

		public static void Log(string line, int level) {
			if (level < 0) level = 0;
			if (level > levels.Count - 1) level = levels.Count - 1;
			Write(FormatLine(line, levels[level]));
		}

		public static void Error(string line) {
			Log(line, errorLevel);
		}

		public static void Info(string line) {
			Log(line, infoLevel);
		}

		public static void Warn(string line) {
			Log(line, warnLevel);
		}

		public static void Highest(string line) {
			Log(line, levels.Count - 1);
		}

		public static void Lowest(string line) {
			Log(line, 0);
		}
	}

}
