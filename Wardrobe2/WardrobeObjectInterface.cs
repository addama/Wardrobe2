using System;
using System.Collections.Generic;

namespace Wardrobe2 {
	interface WardrobeObjectInterface {
		string getProp(string key);
		string setProp(string key, string value);

		string getRating(string key);
		int getRatingIndex(string key);
		void setRating(string key, int value);
	}
}
