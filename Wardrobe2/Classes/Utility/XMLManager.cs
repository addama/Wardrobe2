using System;
using System.Collections.Generic;
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

		internal static void Query(XDocument source, string type, string where) {
			
		}
	}

}
