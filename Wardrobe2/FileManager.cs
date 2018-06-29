using System;
using System.Collections.Generic;
using System.IO;

namespace Wardrobe {

	static class FileManager {

		public static string ReadAll(string file) {
			string contents = "";
			try {
				Validate(file);
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
				Validate(file);
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
				Validate(file);
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
				Validate(file);
				TextWriter w = new StreamWriter(file, true);
				w.WriteLine(contents);
				w.Close();
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
				return false;
			}
			return true;
		}

		public static Dictionary<string, string> GetInfo(string file) {
			Dictionary<string, string> info = new Dictionary<string, string>();
			try {
				Validate(file);
				FileInfo props = new FileInfo(file);
				info.Add("FullName", props.FullName);
				info.Add("CreationTime", props.CreationTime.ToString());
				info.Add("LastAccessTime", props.LastAccessTime.ToString());
				info.Add("LastWriteTIme", props.LastWriteTime.ToString());
				info.Add("Length", props.Length.ToString());
			} catch (Exception error) {
				Console.Write(error.StackTrace);
			}
			return info;
		}

		public static bool Validate(string file) {
			try {
				string exact = Path.GetFullPath(file);
				if (!File.Exists(exact)) {
					Directory.CreateDirectory(Path.GetDirectoryName(exact));
					return false;
				}
			} catch (Exception error) {
				Console.WriteLine(error.StackTrace);
			}
			return true;
		}

		private static void Rename(string oldName, string newName) {
			try {
				File.Move(oldName, newName);
			} catch (Exception error) {
				Console.WriteLine(error.StackTrace);
			}
		}

		public static void Rotate(string file) {
			string newName = file + "." + DateTime.Now.ToString("yyyyMMddTHHmmss");
			Validate(file);
			Rename(file, newName);
			Append(file, "---> Continued from " + newName);
		}

	}

}
