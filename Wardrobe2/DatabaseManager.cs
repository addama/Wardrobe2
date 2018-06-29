//https://www.connectionstrings.com/sqlite/
//https://www.dreamincode.net/forums/topic/157830-using-sqlite-with-c%23/

using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Wardrobe {
	
    class DatabaseManager {
		private SQLiteConnection connection;
		private string file;
		private bool isReady = false;

		public DatabaseManager(string file) {
			this.file = file;
			try {
				SQLiteConnection.CreateFile(this.file);
				this.connection = new SQLiteConnection("Data Source=" + this.file + ";Version=3;");
				this.isReady = true;
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
			}
			Logger.Info("DatabaseConnector created");
		}

		public bool IsReady() {
			return this.isReady;
		}

		public string GetDBFile() {
			return this.file;
		}

		private bool Open() {
			try {
				this.connection.Open();
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
				return false;
			}
			return true;
		}

		private bool Close() {
			try {
				this.connection.Close();
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
				return false;
			}
			return true;
		}

		private int Write(string sql) {
			int rowsUpdated = 0;
			try {
				this.Open();
				SQLiteCommand query = new SQLiteCommand(this.connection);
				query.CommandText = sql;
				rowsUpdated = query.ExecuteNonQuery();
				this.Close();
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
			}
			return rowsUpdated;
		}

		public DataTable Query(string sql) {
			DataTable result = new DataTable();
			try {
				this.Open();
				SQLiteCommand query = new SQLiteCommand(this.connection);
				query.CommandText = sql;
				SQLiteDataReader reader = query.ExecuteReader();
				result.Load(reader);
				reader.Close();
				this.Close();
			} catch(Exception error) {
				Logger.Error(error.StackTrace);
			}
			return result;
		}

		public bool Insert(string table, Dictionary<string, dynamic> row) {
			string columns = "";
			string values = "";

			foreach (KeyValuePair<string, dynamic> val in row) {
				columns += String.Format(" {0},", val.Key.ToString());
				values += String.Format(" '{0}',", val.Value);
			}

			columns = columns.Substring(0, columns.Length - 1);
			values = values.Substring(0, values.Length - 1);

			try {
				this.Write(String.Format("INSERT INTO {0}({1}) values({2})", table, columns, values));
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
				return false;
			}

			return true;
		}

		public bool Update(string table, Dictionary<string, dynamic> row, string where) {
			string vals = "";
			if (row.Count >= 1) {
				foreach (KeyValuePair<string, dynamic> val in row) {
					vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
				}
				vals = vals.Substring(0, vals.Length - 1);

				try {
					this.Write(String.Format("UPDATE {0} SET {1} WHERE {2};", table, vals, where));
				} catch (Exception error) {
					Logger.Error(error.StackTrace);
					return false;
				}
			} else {
				return false;
			}

			return true;
		}

		public bool Delete(string table, string where) {
			try {
				this.Write(String.Format("DELETE FROM {0} WHERE {1}", table, where));
			} catch (Exception error) {
				Logger.Error(error.StackTrace);
				return false;
			}
			return true;
		}
	}

}
