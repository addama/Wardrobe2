using System;
using System.Collections.Generic;

namespace Wardrobe {
	abstract class Item : IWardrobeObject {
		public Slots slot { get; private set; }
		protected Dictionary<string, string> props { get; private set; }

		public Item(Slots slot, Dictionary<string, string> props) {
			this.slot = slot;
			this.props = props;
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

	class HeadItem : Item {
		public HeadItem(Dictionary<string, string> props) : base(Slots.head, props) {}
	}

	class NeckItem : Item {
		public NeckItem(Dictionary<string, string> props) : base(Slots.neck, props) {}
	}

	class ChestItem : Item {
		public ChestItem(Dictionary<string, string> props) : base(Slots.chest, props) {}
	}

	class BackItem : Item {
		public BackItem(Dictionary<string, string> props) : base(Slots.back, props) {}
	}

	class HandItem : Item {
		public HandItem(Dictionary<string, string> props) : base(Slots.hand, props) {}
	}

	class WaistItem : Item {
		public WaistItem(Dictionary<string, string> props) : base(Slots.waist, props) {}
	}

	class FeetItem : Item {
		public FeetItem(Dictionary<string, string> props) : base(Slots.feet, props) {}
	}

}
