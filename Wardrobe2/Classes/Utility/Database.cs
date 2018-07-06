//https://www.connectionstrings.com/sqlite/
//https://www.dreamincode.net/forums/topic/157830-using-sqlite-with-c%23/

using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wardrobe {
	
    internal static class Database {
		private static SQLiteConnection connection;
		private static string dbFile;
		private static bool isReady = false;
		private static bool isOpen = false;

		internal static void Connect(string file) {
			dbFile = file;
			try {
				SQLiteConnection.CreateFile(file);
				connection = new SQLiteConnection("Data Source=" + file + ";Version=3;");
			} catch (Exception error) {
				Logger.Error(error);
			} finally {
				isReady = true;
				Logger.Info("Database connection established");
			}
		}

		internal static bool IsReady() {
			return isReady && isOpen;
		}

		private static bool Open() {
			try {
				connection.Open();
			} catch (Exception error) {
				Logger.Error(error);
				return false;
			} finally {
				isOpen = true;
			}
			return true;
		}

		private static bool Close() {
			try {
				connection.Close();
			} catch (Exception error) {
				Logger.Error(error);
				return false;
			} finally {
				isOpen = false;
			}
			return true;
		}

		private static SQLiteDataReader GetReader(string sql) {
			Open();
			SQLiteCommand query = new SQLiteCommand(connection);
			System.Threading.Thread.Sleep(5000);
			query.CommandText = sql;
			SQLiteDataReader reader = query.ExecuteReader();
			return reader;
		}

		internal static int Write(string sql) {
			int rowsUpdated = 0;
			try {
				Open();
				SQLiteCommand query = new SQLiteCommand(connection);
				query.CommandText = sql;
				rowsUpdated = query.ExecuteNonQuery();
				Close();
			} catch (Exception error) {
				Logger.Error(error);
			}
			return rowsUpdated;
		}

		internal static DataTable QueryAsTable(string sql) {
			DataTable result = new DataTable();
			try {
				SQLiteDataReader reader = GetReader(sql);
				result.Load(reader);
				reader.Close();
				Close();
			} catch(Exception error) {
				Logger.Error(error);
			}
			return result;
		}

		internal static List<Dictionary<string, string>> Query(string sql) {
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			try {
				SQLiteDataReader reader = GetReader(sql);
				while (reader.Read()) {
					Dictionary<string, string> row = new Dictionary<string, string>();
					for (int i = 0; i < reader.FieldCount; i++) {
						string column = reader.GetName(i);
						row.Add(column, reader[column].ToString());
					}
					result.Add(row);
				}
				reader.Close();
				Close();
			} catch (Exception error) {
				Logger.Error(error);
			}
			return result;
		}

		internal static bool Insert(string table, Dictionary<string, string> row) {
			string columns = "";
			string values = "";

			foreach (KeyValuePair<string, string> val in row) {
				columns += String.Format(" {0},", val.Key);
				values += String.Format(" '{0}',", val.Value);
			}

			columns = columns.Substring(0, columns.Length - 1);
			values = values.Substring(0, values.Length - 1);

			try {
				Write(String.Format("INSERT INTO {0}({1}) values({2})", table, columns, values));
			} catch (Exception error) {
				Logger.Error(error);
				return false;
			}

			return true;
		}

		internal static bool Update(string table, Dictionary<string, string> row, string where) {
			string vals = "";
			if (row.Count >= 1) {
				foreach (KeyValuePair<string, string> val in row) {
					vals += String.Format(" {0} = '{1}',", val.Key, val.Value);
				}
				vals = vals.Substring(0, vals.Length - 1);

				try {
					Write(String.Format("UPDATE {0} SET {1} WHERE {2};", table, vals, where));
				} catch (Exception error) {
					Logger.Error(error);
					return false;
				}
			} else {
				return false;
			}

			return true;
		}

		internal static bool Delete(string table, string where) {
			try {
				Write(String.Format("DELETE FROM {0} WHERE {1}", table, where));
			} catch (Exception error) {
				Logger.Error(error);
				return false;
			}
			return true;
		}

		internal static bool CheckTable(string table) {
			string sql = "SELECT name as 'check' FROM sqlite_master WHERE type='table' AND name='" + table + "';";
			bool result = false;
			try {
				Open();
				SQLiteCommand query = new SQLiteCommand(connection);
				query.CommandText = sql;
				string check = (string)query.ExecuteScalar();
				Logger.Info("Check " + check);
				Close();
			} catch (Exception error) {
				Logger.Error(error);
			}
			return result;
		}

		internal static int Count(string table) {
			string sql = "SELECT COUNT(*) FROM " + table + ";";
			int result = 0;
			try {
				SQLiteDataReader reader = GetReader(sql);
				result = (int)reader.GetValue(0);
				reader.Close();
				Close();
			} catch (Exception error) {
				Logger.Error(error);
			}
			return result;
		}

		internal static int Count(string table, string where) {
			string sql = "SELECT COUNT(*) FROM " + table + " WHERE " + where + ";";
			int result = 0;
			try {
				SQLiteDataReader reader = GetReader(sql);
				result = (int)reader.GetValue(0);
				reader.Close();
				Close();
			} catch (Exception error) {
				Logger.Error(error);
			}
			return result;
		}
	}

}
