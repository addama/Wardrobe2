using System;
using System.Collections.Generic;

namespace Wardrobe2 {
	class Item {
		public int id { get; private set; }
		public string name { get; private set; }
		public Dictionary<string, string> props { get; private set; }

		public Item(int id, string name, Dictionary<string, string> props) {

		}
	}
}
