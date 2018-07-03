using System;
using System.Collections.Generic;

namespace Wardrobe {

	internal static class Color {
		private static Dictionary<string, int> palette = new Dictionary<string, int>();

		static Color() {
			palette = MakePalette();
		}

		internal static string NameFromHex(int hex) {
			return Enum.GetName(typeof(ColorEnum), hex);
		}

		internal static int HexFromName(string name) {
			return (int)Enum.Parse(typeof(ColorEnum), name);
		}

		private static Dictionary<string, int> MakePalette() {
			Dictionary<string, int> palette = new Dictionary<string, int>();
			foreach (ColorEnum color in Enum.GetValues(typeof(ColorEnum))) {
				palette.Add(color.ToString(), (int)color);
			}
			return palette;
		}

		internal static Dictionary<string, int> GetPalette() {
			return palette;
		}
	}
}
