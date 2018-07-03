using System;
using System.Collections.Generic;

namespace Wardrobe {
	interface IWardrobeObject {
		string getProp(string key);
		void setProp(string key, string value);
		void setProp(string key, int value);
		Dictionary<string, string> getProps();
	}
}
