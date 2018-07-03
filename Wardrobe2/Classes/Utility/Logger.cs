using System;
using System.Collections.Generic;

namespace Wardrobe {
	
	// TODO: Log rotation - use FileManger.GetInfo()["Length"] to rotate files based on lines

	static class Logger {
		private static string file = ".\\logs\\wardrobe.log";
		private static List<string> levels = new List<string>{ "Info", "Warn", "Error", "Holy Shit" };
		private static int errorLevel = 2;
		private static int warnLevel = 1;
		private static int infoLevel = 0;
		private static int logLimit = 10485760; // 10mb
		private static string separator = "--------------------------------------------------------------------------------";
		private static bool alsoConsole = true;

		private static string FormatLine(string line, string severity = "") {
			string date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
			string result = date + "	" + severity + "	" + line;
			return result;
		}

		public static bool CheckLogs() {
			Dictionary<string, string> info = FileManager.GetInfo(file);
			if (info.ContainsKey("Length") && Int32.Parse(info["Length"]) >= logLimit) {
				Log("Log file rotated out!");
				FileManager.Rotate(file);
				return true;
			}
			return false;
		}

		private static void Write(string line) {
			if (alsoConsole) Console.WriteLine(line);
			FileManager.Append(file, line);
		}

		public static void Log(string line, string severity) {
			Write(FormatLine(line, severity));
		}

		public static void Log(string line, int level = 0) {
			if (level < 0) level = 0;
			if (level > levels.Count - 1) level = levels.Count - 1;
			Write(FormatLine(line, levels[level]));
		}

		public static void Error(string line) {
			Log(line, errorLevel);
		}

		public static void Error(Exception error) {
			Write(error.Message);
			Write(error.StackTrace);
		}

		public static void Info(string line) {
			Log(line, infoLevel);
		}

		public static void Warn(string line) {
			Log(line, warnLevel);
		}

		public static void Separator() {
			Write(separator);
		}

		public static void Space() {
			Write(Environment.NewLine);
		}
		
		public static void UseConsole(bool toggle) {
			alsoConsole = toggle;
		}
	}

}
