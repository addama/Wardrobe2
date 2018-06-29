using System;
using System.Collections.Generic;

namespace Wardrobe2 {
	class Rating {
		private int current;
		private int max;
		private static int defaultMax = 5;

		public Rating(int current, int max = -1) {
			if (current < 1) current = 1;
			if (current > defaultMax) current = defaultMax;
			if (max == -1) max = defaultMax;
			this.current = current;
			this.max = max;
		}

		public Rating(string current, int max = -1) : this(Int32.Parse(current), max) {}

		public int getRating() {
			return this.current;
		}

		public void setRating(int value) {
			if (value < 1) value = 1;
			if (value > defaultMax) value = defaultMax;
			this.current = value;
		}

		public void setRating(string value) {
			this.setRating(Int32.Parse(value));
		}
	}
}
