using System;
using System.Collections.Generic;

namespace Wardrobe {

	static class DatabaseManager {
		public static string itemsTable = "items";
		public static string outfitsTable = "outfits";
		public static string colorsTable = "colors";
		public static string slotsTable = "slots";

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
				case "Item": table = itemsTable; break;
				case "Outfit": table = outfitsTable; break;
			}
			return table;
		}

		private static List<T> Query<T>(string sql) {
			List<Dictionary<string, string>> results = Database.Query(sql);
			List<T> items = ConvertToObject<T>(results);
			return items;
		}

		// Item/Outfit CRUD methods
		internal static List<T> GetAll<T>() {
			string table = GetTableByType<T>();
			string sql = "SELECT * FROM " + table;
			List<T> items = Query<T>(sql);
			return items;
		}

		internal static List<T> GetAllBy<T>(string column, string value) {
			string table = GetTableByType<T>();
			string sql = "SELECT * FROM " + table + " WHERE " + column + " = " + value;
			List<T> items = Query<T>(sql);
			return items;
		}

		internal static bool Create<T>(T obj) {
			string table = GetTableByType<T>();
			Dictionary<string, string> props = ((IWardrobeObject)obj).GetProps();
			bool result = Database.Insert(table, props);
			return result;
		}

		internal static bool Delete<T>(T obj) {
			string table = GetTableByType<T>();
			Dictionary<string, string> props = ((IWardrobeObject)obj).GetProps();
			string where = "id = " + props["id"].ToString();
			bool result = Database.Delete(table, where);
			return result;
		}

		internal static bool Update<T>(T obj) {
			string table = GetTableByType<T>();
			Dictionary<string, string> props = ((IWardrobeObject)obj).GetProps();
			string where = "id = " + props["id"].ToString();
			bool result = Database.Update(table, props, where);
			return result;
		}

		// Database methods
		internal static bool InitializeDatabase() {
			bool check = Database.CheckTable(itemsTable);
			Logger.Info("Table check " + check);
			if (!check) {
				string sql = FileManager.ReadAll(Constants.databaseInitSQL);
				int rows = Database.Write(sql);
				if (rows == 0) return false;
			}

			return true;
		}
	}

}
