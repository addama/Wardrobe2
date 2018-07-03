using System;
using System.Resources;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace Wardrobe {

	static class ColorFactory {
		private static string colorsXML = "./Resources/Colors.xml";
		private static Dictionary<string, int> colors;
		private static Dictionary<int, string> colorsLookup;
		private static List<Color> palette;

		public static void Initialize() {
			colors = LoadColors();
			palette = MakePalette();
			colorsLookup = colors.ToDictionary(kv => kv.Value, kv => kv.Key);
		}

		private static Dictionary<string, int> LoadColors() {
			XDocument doc = XMLManager.Load(colorsXML);
			Dictionary<string, int> colors = new Dictionary<string, int>();
			try {
				foreach (XElement color in doc.Root.Descendants("Color")) {
					string name = color.Attribute("name").Value;
					int hex = int.Parse(color.Attribute("hex").Value, System.Globalization.NumberStyles.HexNumber);
					colors.Add(name, hex);
				}
			} catch (Exception error) {
				Logger.Error(error);
			}
			return colors;
		}

		private static List<Color> MakePalette() {
			List<Color> colorList = new List<Color>();
			foreach(KeyValuePair<string, int> color in colors) {
				colorList.Add(new Color(color.Key, color.Value));
			}
			return colorList;
		}

		public static Color Create(string name) {
			if (colors.ContainsKey(name)) {
				return new Color(name, colors[name]);
			} else {
				if (name.StartsWith("#") || name.StartsWith("0x")) {
					throw new Exception("ColorFactory.Create() expects either the string name of a known color, or the int color value in hex format");
				} else {
					throw new Exception("Invalid name string passed to Color constructor");
				}
			}
		}

		public static Color Create(int hex) {
			if (colorsLookup.ContainsKey(hex)) {
				return new Color(colorsLookup[hex], hex);
			} else {
				throw new Exception("Invalid hex int passed to Color constructor");
			}
		}

		public static List<string> GetColorNames() {
			return new List<string>(colors.Keys);
		}

		public static List<Color> GetPalette() {
			return palette;
		}
	}

	class Color {
		private int hex;
		private string name;

		public int getHex() { return this.hex; }
		public string getName() { return this.name; }

		public Color(string name, int hex) {
			this.name = name;
			this.hex = hex;
		}
	}
}
