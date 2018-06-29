using System;
using System.Collections.Generic;
using System.IO;

namespace Wardrobe {

	static class FileManager {

		public static string ReadAll(string file) {
			string contents = "";
			try {
				TextReader r = new StreamReader(file);
				contents = r.ReadToEnd();
				r.Close();
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
			}
			return contents;
		}

		public static List<string> ReadLines(string file) {
			List<string> lines = new List<string>();
			try {
				TextReader r = new StreamReader(file);
				while (r.Peek() != -1) {
					lines.Add(r.ReadLine());
				}
				r.Close();
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
			}
			return lines;
		}

		public static bool Overwrite(string file, string contents) {
			try {
				TextWriter w = new StreamWriter(file, false);
				w.Write(contents);
				w.Close();
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
				return false;
			}
			return true;
		}

		public static bool Append(string file, string contents) {
			try {
				TextWriter w = new StreamWriter(file, true);
				w.WriteLine(contents);
				w.Close();
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
				return false;
			}
			return true;
		}

		public static Dictionary<string, string> GetInfo(string loc) {
			Dictionary<string, string> info = new Dictionary<string, string>();
            try {
                bool exists = File.Exists(loc);
            } catch (StackOverflowException error) {
				Logger.Error(error.StackTrace);
            }

			if (File.Exists(loc)) {
				FileInfo props = new FileInfo(loc);
				info.Add("FullName", props.FullName);
				info.Add("CreationTime", props.CreationTime.ToString());
				info.Add("LastAccessTime", props.LastAccessTime.ToString());
				info.Add("LastWriteTIme", props.LastWriteTime.ToString());
				info.Add("Length", props.Length.ToString());
			} else {
				Logger.Error("File not found: " + loc);
				throw new FileNotFoundException("File not found: " + loc);
			}
			return info;
		}

	}

}
