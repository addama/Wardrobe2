// https://sashat.me/2017/01/11/list-of-20-simple-distinct-colors/
using System;

namespace Wardrobe {
    static class Program {
        static void Main() {
			Logger.CheckLogs();
			Logger.Separator();
			Logger.Info("Wardrobe startup");
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnExit);
			Database.Connect(Constants.databaseFile);
			
			DatabaseManager.InitializeDatabase();
			//testLogger();
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
