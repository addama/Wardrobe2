using System;
using System.Collections.Generic;

namespace Wardrobe {

	abstract class Rating {
		protected int current = 0;
		protected int max = 5;
		protected List<string> ratings;

		public Rating(int current, List<string> ratings) {
			this.ratings = ratings;
			this.max = this.ratings.Count - 1;
			if (current < 0) current = 0;
			if (current > this.max) current = this.max;
		}

		public string getRating() {
			return this.ratings[this.current];
		}

		public int getIndex() {
			return this.current;
		}

		public int getMax() {
			return this.max;
		}

		public void setRating(int value) {
			if (value < 0) value = 0;
			if (value > this.max) value = this.max;
			this.current = value;
		}

	}

	class GoodBadRating : Rating {
		public GoodBadRating(int current = 0) : base(current, Constants.goodbad) {}
	}

	class FormalityRating : Rating {
		public FormalityRating(int current) : base(current, Constants.formality) {}
	}

	class WarmthRating : Rating {
		public WarmthRating(int current) : base(current, Constants.warmth) { }
	}

	class WearRating : Rating {
		public WearRating(int current) : base(current, Constants.wear) { }
	}

	class FitRating : Rating {
		public FitRating(int current) : base(current, Constants.fit) { }
	}
}
