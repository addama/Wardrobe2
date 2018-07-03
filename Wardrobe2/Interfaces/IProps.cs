using System;
using System.Data;
using System.Collections.Generic;

namespace Wardrobe {
	interface IProps {
		string GetProp(string key);
		void SetProp(string key, string value);
		void SetProp(string key, int value);
	}
}
