using System;
using System.Collections.Generic;

namespace Wardrobe2 {
	class Item : WardrobeObjectInterface {
		public int id { get; private set; }
		public string name { get; private set; }
		public Dictionary<string, dynamic> props { get; private set; }
		public Dictionary<string, Rating> ratings { get; private set; }

		public Item(int id, string name, Dictionary<string, dynamic> props) {

		}

		public string getProp(string key) {
			return "";
		}

		public string setProp(string key, string value) {
			return "";
		}

		public string getRating(string key) {
			return "";
		}

		public int getRatingIndex(string key) {
			return 0;
		}

		public void setRating(string key, int value) {

		}
	}
}
