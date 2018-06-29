using System;

namespace Wardrobe {
    static class Program {
		private static string file = "./wardrobe.db";
        static void Main() {
			Logger.Info("Wardrobe startup");
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnExit);
			DatabaseManager db = new DatabaseManager(file);
			//testLogger();
        }

		static void OnExit(object sender, EventArgs e) {
			Logger.Info("Wardrobe shutdown");
		}

		static void testLogger() {
			Logger.Info("Info");
			Logger.Warn("Warn");
			Logger.Error("Error");
			Logger.Lowest("Lowest");
			Logger.Highest("Highest");
			Logger.Log("Direct to Highest", 3);
			Logger.Log("Custom severity", "Custom"); 
		}
    }
}
