using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe2 {
	class Outfit : WardrobeObjectInterface {
		public int id { get; private set; }
		public string name { get; private set; }
		public Dictionary<string, dynamic> props { get; private set; }
		public List<Item> items { get; set; }
		public Dictionary<string, Rating> ratings { get; private set; }

		public Outfit(int id, string name, Dictionary<string, dynamic> props, List<Item> items) {
			this.id = id;
			this.name = name;
			this.props = props;
			this.items = items;
			// Then generate the ratings based on constituent items
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
