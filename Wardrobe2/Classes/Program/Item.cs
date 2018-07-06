using System;
using System.Collections.Generic;

namespace Wardrobe {

	public class Item : IWardrobeObject {
		private Dictionary<string, string> props;

		public Item(Dictionary<string, string> props) {
			this.props = props;
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
			string slot = this.GetProp("slot");
			string type = this.GetProp("type");
			
			// Slot check
			if (!Constants.slots.Contains(slot)) {
				return false;
			}

			// Type check
			if (!Constants.types[slot].Contains(type)) {
				return false;
			}

			return true;
		}

		public string GetSlot() {
			return this.GetProp("slot");
		}

	}

}
