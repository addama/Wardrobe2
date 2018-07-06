using System;
using System.Collections.Generic;

namespace Wardrobe {

	public class Outfit : IWardrobeObject {
		public Dictionary<string, string> props { get; private set; }
		public List<Item> items { get; set; }

		public Outfit(Dictionary<string, string> props) {
			this.props = props;
			this.items = new List<Item>();
			this.ValidateProps();
		}

		public Outfit(Dictionary<string, string> props, List<Item> items) {
			this.props = props;
			this.items = items;
			this.ValidateProps();
		}

		public string GetProp(string key) {
			return this.props[key];
		}

		public void SetProp(string key, string value) {
			this.props[key] = value;
		}

		public void SetProp(string key, int value) {
			this.props[key] = value.ToString();
		}

		public Dictionary<string, string> GetProps() {
			return this.props;
		}

		public bool ValidateProps() {
			string type = this.GetProp("type");
			// Type check
			if (!Constants.outfitTypes.Contains(type)) {
				return false;
			}
			return true;
		}

		public List<Item> GetItems() {
			return this.items;
		}

		public List<Item> GetItems(string slot) {
			List<Item> matches = this.items.FindAll(delegate(Item item) {
				return item.GetSlot() == slot;
			});
			return matches;
		}

		public void AddItem(Item item) {
			this.items.Add(item);
		}

		public void RemoveItem(Item item) {
			this.items.Remove(item);
		}

		public int CountItems() {
			return this.items.Count;
		}
	}

}
