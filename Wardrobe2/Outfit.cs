using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe {
	class Outfit : IWardrobeObject {
		public int id { get; private set; }
		public string name { get; private set; }
		public Dictionary<string, string> props { get; private set; }
		public List<Item> items { get; set; }
		public Dictionary<string, Rating> ratings { get; private set; }

		public Outfit(int id, string name, Dictionary<string, string> props, List<Item> items) {
			this.id = id;
			this.name = name;
			this.props = props;
			this.items = items;
			// Then generate the ratings based on constituent items
		}

		public string getProp(string key) {
			return this.props[key];
		}

		public void setProp(string key, string value) {
			this.props[key] = value;
		}

		public void setProp(string key, int value) {
			this.props[key] = value.ToString();
		}

		public Dictionary<string, string> getProps() {
			return this.props;
		}
	}
}
