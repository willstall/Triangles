using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Reflection;

namespace XML
{
	[Serializable]
	public class XMLSaveableData 
	{
		[HideInInspector]
		[XmlAttribute("instanceId")]
		public int instanceId;
		
		[HideInInspector]
		public Vector3 position;

		[HideInInspector]
		public Quaternion rotation;

		[HideInInspector]
		public XMLSaveablePrefabData prefabData;

		public List<ComponentProperty> properties = new List<ComponentProperty>();
	}
}