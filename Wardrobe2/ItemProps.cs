﻿using System;
using System.Data;
using System.Collections.Generic;


namespace Wardrobe {

	class ItemProps : IProps {
		private Dictionary<string, string> props;

		public ItemProps(Dictionary<string, string> props) {
			this.props = props;
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
	}

}
