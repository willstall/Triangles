using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Reflection;

namespace XML
{
	public class XMLSaveablePrefab : MonoBehaviour
	{
		[SerializeField]
		XMLSaveableData _data = new XMLSaveableData();

		public void PrepareForSerialization()
		{
			data.position = transform.position;
			data.rotation = transform.rotation;
			data.instanceId = gameObject.GetInstanceID();

			foreach( ComponentProperty property in data.properties )
			{
				property.CacheXml();
			}
		}

		public void Initialize( XMLSaveableData data )
		{
			this._data = data;
			transform.position = data.position;
			transform.rotation = data.rotation;

			//looad properites somehow;

			foreach( ComponentProperty property in data.properties )
			{
				property.LoadFromXml( gameObject );
			}
		}

		public XMLSaveableData data
		{
			get
			{
				return _data;
			}
		}
	}	
}