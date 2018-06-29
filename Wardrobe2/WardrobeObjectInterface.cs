using System;
using System.Collections.Generic;

namespace Wardrobe2 {
	interface WardrobeObjectInterface {
		public int id { get; private set; }
		public string name { get; private set; }
		public Dictionary<string, dynamic> props { get; private set; }

		public string getProp(string key);
		public string setProp(string key, string value);

		public int getRating(string key);
		public void setRating(string key, int value);
		public void setRating(string key, string value);
	}
}
