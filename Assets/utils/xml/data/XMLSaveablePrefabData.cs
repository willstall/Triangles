using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

namespace XML
{
	[System.Serializable]
	public class XMLSaveablePrefabData 
	{
		[XmlAttribute("name")]
		public string name;

		[HideInInspector]
		[XmlAttribute("guid")]
		public string guid;
		
		[XmlIgnore]
		public XMLSaveablePrefab prefab;
	}
}