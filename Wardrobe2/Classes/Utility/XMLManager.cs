using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Globalization;

namespace Wardrobe {

	static class XMLManager {
		internal static XDocument Load(string file) {
			XDocument doc = new XDocument();
			FileManager.Validate(file);
			try { 
				doc = XDocument.Load(file); 
			} catch(System.IO.FileNotFoundException error) {
				Logger.Error(error);
			}

			return doc;
		}

		internal static void Query(XDocument source, string column, string value) {
			var query = from t in source.Descendants("Items") 
						where t.Element(column).Value == value
						select t;
			//return query.
		}

		internal static void Insert(XDocument source, Dictionary<string, string> row) {

		}

		internal static void Update(XDocument source, Dictionary<string, string> row, string where) {

		}

		internal static void Count(XDocument source, string where) {

		}
	}

}
