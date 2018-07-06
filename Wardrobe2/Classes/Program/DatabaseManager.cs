using System;
using System.Collections.Generic;

namespace Wardrobe {

	static class DatabaseManager {
		private static string itemsTable = "items";
		private static string outfitsTable = "outfits";
		private static string slotsTable = "slots";

		// Utility methods
		private static List<T> ConvertToObject<T>(List<Dictionary<string, string>> list) {
			List<T> items = new List<T>();
			foreach (Dictionary<string, string> result in list) {
				items.Add((T)Activator.CreateInstance(typeof(T), result));
			}
			return items;
		}

		private static string GetTableByType<T>() {
			string table = "";
			switch (typeof(T).ToString()) {
				case "Wardrobe.Item": table = itemsTable; break;
				case "Wardrobe.Outfit": table = outfitsTable; break;
			}
			return table;
		}

		private static List<T> Query<T>(string sql) {
			List<Dictionary<string, string>> results = Database.Query(sql);
			List<T> items = ConvertToObject<T>(results);
			return items;
		}

		// Generic CRUD methods
		internal static List<T> Get<T>() {
			string table = GetTableByType<T>();
			string sql = "SELECT * FROM " + table;
			List<T> list = Query<T>(sql);
			if (typeof(T).ToString() == "Wardrobe.Outfit") {
				List<Outfit> outfits = new List<Outfit>();
				foreach (T obj in list) {
					Outfit outfit = (Outfit)Convert.ChangeType(obj, typeof(Outfit));
					List<Item> items = GetOutfitItems(outfit);
					outfit.items = items;
					outfits.Add(outfit);
					return list;
				}
			}
			return list;
		}

		internal static List<T> Get<T>(string column, string value) {
			string table = GetTableByType<T>();
			string sql = "SELECT * FROM " + table + " WHERE " + column + " = " + value;
			List<T> list = Query<T>(sql);
			if (typeof(T).ToString() == "Wardrobe.Outfit") {
				List<Outfit> outfits = new List<Outfit>();
				foreach (T obj in list) {
					Outfit outfit = (Outfit)Convert.ChangeType(obj, typeof(Outfit));
					List<Item> items = GetOutfitItems(outfit);
					outfit.items = items;
					outfits.Add(outfit);
					return list;
				}
			}
			return list;
		}

		internal static int Count<T>() {
			string table = GetTableByType<T>();
			int count = Database.Count(table);
			return count;
		}

		internal static int Count<T>(string column, string value) {
			string table = GetTableByType<T>();
			string where = column + " = " + value;
			int count = Database.Count(table, where);
			return count;
		}

		internal static T Create<T>(T obj) {
			string table = GetTableByType<T>();
			int id = -1;
			Dictionary<string, string> props = ((IWardrobeObject)obj).GetProps();
			id = Database.Insert(table, props);
			((IWardrobeObject)obj).SetProp("id", id);
			Logger.Info("New " + typeof(T).ToString() + " created with ID of " + id);
			if (typeof(T).ToString() == "Wardrobe.Outfit") {
				Outfit outfit = (Outfit)Convert.ChangeType(obj, typeof(Outfit));
				AddOutfitItems(outfit);
			}
			return obj;
		}

		internal static bool Delete<T>(T obj) {
			string table = GetTableByType<T>();
			Dictionary<string, string> props = ((IWardrobeObject)obj).GetProps();
			string where = "id = " + props["id"];
			bool result = Database.Delete(table, where);
			if (typeof(T).ToString() == "Wardrobe.Outfit") {
				string where2 = "outfit = " + props["id"];
				Database.Delete(slotsTable, where2);
			}

			if (typeof(T).ToString() == "Wardrobe.Item") {
				string where2 = "item = " + props["id"];
				Database.Delete(slotsTable, where2);
			}

			return result;
		}

		internal static bool Update<T>(T obj) {
			string table = GetTableByType<T>();
			Dictionary<string, string> props = ((IWardrobeObject)obj).GetProps();
			string where = "id = " + props["id"].ToString();
			props.Remove("id");
			bool result = Database.Update(table, props, where);
			return result;
		}

		// Type specific methods
		internal static int CountItemUses(Item item) {
			string where = "item = " + item.GetProp("id");
			int count = Database.Count(slotsTable, where);
			return count;
		}

		internal static List<Item> GetOutfitItems(Outfit outfit) {
			List<Item> items = new List<Item>();
			string sql = "SELECT * FROM items INNER JOIN slots ON slots.item = items.id;";
			List<Dictionary<string, string>> temp = Database.Query(sql);
			items = ConvertToObject<Item>(temp);
			return items;
		}

		internal static void AddOutfitItems(Outfit outfit) {
			List<Item> items = outfit.GetItems();
			if (items.Count > 0) {
				foreach (Item item in items) {
					AddOutfitItems(outfit, item);
				}
			}
		}

		internal static void AddOutfitItems(Outfit outfit, Item item) {
			// Assumption: The Items being associated are already defined
			int id = -1;
			string oID = outfit.GetProp("id");
			string iID = item.GetProp("id");
			Dictionary<string, string> props = new Dictionary<string, string>() {
				{ "outfit",  oID},
				{ "item",  iID}
			};
			id = Database.Insert(slotsTable, props);
			Logger.Info("Associated Item " + iID + " with Outfit " + oID + " with a row of " + id);
		}

		// Database methods
		internal static void InitializeDatabase() {
			string sql = FileManager.ReadAll(Constants.databaseInitSQL);
			int rows = Database.Write(sql);
			Logger.Info("Database initialized");
		}

		internal static string GetDateTime() {
			return DateTime.Now.ToString("s");
		}
	}

}
