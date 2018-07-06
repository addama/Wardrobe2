using System;
using System.Collections.Generic;

namespace Wardrobe {

	internal static class Constants {
		// Item Slots and Types
		internal static readonly List<string> slots = new List<string>()		{ "head", "neck", "chest", "hand", "waist", "legs", "feet", "outer", "inner" };
		internal static readonly List<string> headTypes = new List<string>() { "baseball hat", "brimmed hat", "beanie", "sunglasses", "earring", "sun hat" };
		internal static readonly List<string> neckTypes = new List<string>() { "necklace", "tie", "scarf", "choker" };
		internal static readonly List<string> outerTypes = new List<string>()	{ "snow jacket", "lightweight jacket", "rain jacket", "hoodie", "sweatshirt", "vest", "suit jacket", "blazer", "sweater", "cardigan" };
		internal static readonly List<string> chestTypes = new List<string>() { "tshirt", "tanktop", "polo", "buttonup", "blouse", "bodysuit", "thermal" };
		internal static readonly List<string> handTypes = new List<string>()	{ "ring", "bracelet", "glove", "watch", "clutch", "purse" };
		internal static readonly List<string> waistTypes = new List<string>() { "belt", "fannypack" };
		internal static readonly List<string> legTypes = new List<string>()	{ "jeans", "jogger", "shorts", "trunks", "pajama", "khaki", "slacks", "leggings", "skirt", "skort" };
		internal static readonly List<string> feetTypes = new List<string>()	{ "sport", "boot", "sandal", "fashion", "formal", "slipper" };
		internal static readonly List<string> innerTypes = new List<string>() { "boxers", "briefs", "panties", "thong", "tights", "fishnet", "hosiery", "socks", "thermal" };

		internal static readonly Dictionary<string, List<string>> types = new Dictionary<string,List<string>>() {
			{ "head", headTypes },
			{ "neck", neckTypes },
			{ "back", outerTypes },
			{ "chest", chestTypes },
			{ "hand", handTypes },
			{ "waist", waistTypes },
			{ "legs", legTypes },
			{ "feet", feetTypes },
			{ "inner", innerTypes }
		};

		// Outfit Types
		internal static readonly List<string> outfitTypes = new List<string>() { "general", "spring", "summer", "autumn", "winter", "formal", "casual", "work", "sport", "club" };

		// Colors
		internal static readonly Dictionary<string, int> colors = new Dictionary<string, int>() {
			{ "beige", 0xfffac8 },
			{ "black", 0x000000 },
			{ "blue", 0x0082c8 },
			{ "brown", 0xaa6e28 },
			{ "coral", 0xffd8b1 },
			{ "cyan", 0x46f0f0 },
			{ "green", 0x3cb44b },
			{ "grey", 0x808080 },
			{ "lavender", 0xe6beff },
			{ "lime", 0xd2f53c },
			{ "magenta", 0xf032e6 },
			{ "maroon", 0x800000 },
			{ "mint", 0xaaffc3 },
			{ "navy", 0x000080 },
			{ "olive", 0x808000 },
			{ "orange", 0xf58231 },
			{ "pink", 0xfabebe },
			{ "purple", 0x911eb4 },
			{ "red", 0xe6194b },
			{ "teal", 0x008080 },
			{ "white", 0xffffff },
			{ "yellow", 0xffe119 },
		};

		// Item Props
		internal static readonly List<string> sleeveLengths = new List<string>() { "none", "short", "three-quarter", "long" };

		internal static readonly List<string> materials = new List<string>() {
			"cotton", "wool", "denim", "canvas", "linen", "leather", "mixed",
			"suede/nubuck", "polyester", "silk", "nylon", "velvet", "satin", 
			"blend", "unknown", "metal", "fur", "blend", "plastic", "rubber"
		};

		internal static readonly List<string> patterns = new List<string>() {
			"heather", "houndstooth", "plaid", "stripe", "dots", "graphic", 
			"none", "paisley", "geometric", "basketweave", "checked", "floral", 
			"chevron", "gingham", "harlequin", "herringbone", "animal print", 
			"toile", "mixed"
		};

		// Ratings
		internal static readonly List<string> goodbad = new List<string>() { "terrible", "bad", "neutral", "good", "great" };
		internal static readonly List<string> wear = new List<string>() { "destroyed", "ratty", "worn", "like-new", "pristine", "never worn" };
		internal static readonly List<string> fit = new List<string>() { "too small", "small", "fits well", "big", "too big" };
		internal static readonly List<string> formality = new List<string>() { "sport", "casual", "business casual", "business formal", "semi-formal", "formal", "black tie", "white tie" };
		internal static readonly List<string> warmth = new List<string>() { "cold", "neutral", "warm" };

		// Defaults
		internal static readonly Dictionary<string, string> defaults = new Dictionary<string, string>() {
			{ "wear", "like-new" },
			{ "fit", "fits well" },
			{ "formality", "casual" },
			{ "warmth", "neutral" },
			{ "sleeveLengths", "short" },
			{ "outfitTypes", "general" }
		};

		// Units of Time
		internal static readonly int minute = 1 * 60 * 1000;
		internal static readonly int day = minute * 60 * 24;
		internal static readonly int week = day * 7;

		// File Locations
		internal static readonly string databaseFile = ".\\wardrobe.db";
		internal static readonly string databaseInitSQL = ".\\Resources\\InitializeTables.sql";
		internal static readonly string logFile = ".\\logs\\wardrobe.log";
	}

}

