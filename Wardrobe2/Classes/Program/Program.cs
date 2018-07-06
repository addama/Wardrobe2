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
			//Test();
        }

		static void Test() {
			Item item = MakeItem();
			DatabaseManager.Create<Item>(item);
			DatabaseManager.Create<Outfit>(MakeOutfit(item));
		}

		static Item MakeItem() {
			Dictionary<string, string> props = new Dictionary<string, string>() {
				{ "slot", "chest" },
				{ "type", "tshirt" },
				{ "name", "Chili Heather Carhartt Tshirt" },
				{ "created", DatabaseManager.GetDateTime() },
				{ "size", "XL" },
				{ "formality", "casual" },
				{ "color1", "red" }
			};
			Item item = new Item(props);
			return item;
		}

		static Outfit MakeOutfit(Item item) {
			Dictionary<string, string> props = new Dictionary<string, string>() {
				{ "type", "casual" },
				{ "name", "Test outfit" },
				{ "created", DatabaseManager.GetDateTime() },
			};
			List<Item> items = new List<Item>() {
				item
			};
			Outfit outfit = new Outfit(props, items);
			return outfit;
		}

		static void OnExit(object sender, EventArgs e) {
			Database.Cleanup();
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
 