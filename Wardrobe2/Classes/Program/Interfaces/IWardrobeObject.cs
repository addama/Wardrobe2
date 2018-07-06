using System;
using System.Collections.Generic;

namespace Wardrobe {

	interface IWardrobeObject {
		string GetProp(string key);
		void SetProp(string key, string value);
		void SetProp(string key, int value);
		Dictionary<string, string> GetProps();
		bool ValidateProps();
		List<Item> GetItems();
	}

}
