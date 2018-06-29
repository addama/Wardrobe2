using System;
using System.Collections.Generic;

namespace Wardrobe2 {

	abstract class Rating {
		protected int current = 0;
		protected int max = 5;
		protected string[] ratings;

		public Rating(int current, string[] ratings) {
			this.ratings = ratings;
			this.max = this.ratings.Length - 1;
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
		public GoodBadRating(int current) : base(current, new string[] { "Terrible", "Bad", "Neutral", "Good", "Great" }) {}
	}

	class FormalityRating : Rating {
		public FormalityRating(int current) : base(current, new string[] { "Casual", "Semi-Casual", "Business", "Semi-Formal", "Formal" }) {}
	}

	class WarmthRating : Rating {
		public WarmthRating(int current) : base(current, new string[] { "Cool", "Neutral", "Warm" }) { }
	}

	class WearRating : Rating {
		public WearRating(int current) : base(current, new string[] { "Ratty", "Well-worn", "Like New", "Pristine" }) { }
	}

	class FitRating : Rating {
		public FitRating(int current) : base(current, new string[] { "Too tight", "Tight", "Fits", "Loose", "Too loose" }) { }
	}
}
