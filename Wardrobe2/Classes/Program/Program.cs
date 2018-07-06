// https://sashat.me/2017/01/11/list-of-20-simple-distinct-colors/
using System;
using System.Collections.Generic;

namespace Wardrobe {
    static class Program {
        static void Main() {
			Logger.CheckLogs();
			Logger.Separator();
			Logger.Info("Wardrobe startup");
			Database.Connect(Constants.databaseFile);
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnExit);
			DatabaseManager.InitializeDatabase();
			MakeItem();
			MakeItem();
        }

		static void MakeItem() {
			Dictionary<string, string> props = new Dictionary<string, string>() {
				//{ "id", "0" },
				{ "slot", "chest" },
				{ "type", "tshirt" },
				{ "name", "Chili Heather Carhartt Tshirt" },
				{ "created", DatabaseManager.GetDateTime() },
				{ "size", "XL" },
				{ "formality", "casual" },
			};
			Item item = new Item(props);
			DatabaseManager.Create<Item>(item);
			List<Item> items = DatabaseManager.GetAll<Item>();
			foreach (Item x in items) {
				Logger.Info(x.GetProp("id") + " " + x.GetProp("name"));
			}
		}

		static void OnExit(object sender, EventArgs e) {
			Logger.Info("Wardrobe shutdown");
		}

		static void TestLogger() {
			Logger.Info("Info");
			Logger.Warn("Warn");
			Logger.Error("Error");
			Logger.Log("Direct to Highest", 3);
			Logger.Log("Custom severity", "Custom"); 
		}
    }
}
 