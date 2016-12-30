using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System;
using Reflection;

namespace XML
{
	public class XMLSaveableSerializer : MonoBehaviour
	{
		[XmlAttribute("name")]
		new public string name = "Untitled";

		public GameObject gameObjectToSave;
		public XMLSaveablePrefabList prefabList;
		public KeyCode debugSaveKey = KeyCode.BackQuote;
		public bool saveInactiveObjects = false;
		public bool debug = false;

		[XmlIgnore]
		public string resourcePath = "resources/data/";

		protected virtual void Restore(){}

		bool HasPrefabList()
		{
			if(prefabList == null)
			{
				Debug.LogWarning( "Cannot save seriliazable date in [" + gameObject.name + "] without a prefab list to link the assets for recreation.");
				return false;
			}
			return true;
		}

		public void Update()
		{
			if(!debug)
				return;
				
			if( Input.GetKeyDown( debugSaveKey ) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ) )
			{
				Debug.Log("LOAD");
				var data = Load( filename );
				Clear( gameObjectToSave );
				Create( gameObjectToSave, data );

				return;
			}


			if(Input.GetKeyDown( debugSaveKey ))
			{
				Debug.Log("SAVE");
				Save( gameObjectToSave );
			}

		}

		public void Save()
		{
			Save( gameObjectToSave );
		}

		public void Save( GameObject gameObject )
		{	
			
			if(gameObject == null)
				return;

			if(!HasPrefabList())
				return;

			XmlSerializerNamespaces namespaces;
			XmlWriterSettings settings;
			XmlTextWriter writer;
		
			settings = new XmlWriterSettings();
			settings.Indent = true; 
	        settings.OmitXmlDeclaration = true;
			
			namespaces = new XmlSerializerNamespaces();
	        namespaces.Add("", "");
		 
			writer = XmlTextWriter.Create(filename, settings) as XmlTextWriter;
		
			XmlSerializer serializer = new XmlSerializer( typeof(XMLSaveableData[]) );
			XMLSaveablePrefab[] components = gameObject.GetComponentsInChildren<XMLSaveablePrefab>( saveInactiveObjects );

			foreach( XMLSaveablePrefab component in components )
			{
				component.PrepareForSerialization();
			}

			XMLSaveableData[] data = components.Select(x => x.data).ToArray();

			serializer.Serialize( writer, data );
			
			writer.Close();

			#if UNITY_EDITOR 
				UnityEditor.AssetDatabase.Refresh();
			#endif	
		}
		

		public void Clear()
		{
			Clear( gameObjectToSave );
		}

		public void Clear( GameObject gameObject )
		{
			foreach( Transform child in gameObject.transform )
			{
				Destroy( child.gameObject );
			}
		}

		public void Create()
		{
			var data = Load( filename );
			Create( gameObjectToSave, data);
		}

		public void Create( string name )
		{
			this.name = name;
			Create();
		}

		public void Create( TextAsset textAsset )
		{
			this.name = textAsset.name;
			var data = LoadFromAsset( textAsset );
			Create( gameObjectToSave, data );
		}

		public void Create( GameObject gameObject, XMLSaveableData[] dataList )
		{
			if(gameObject == null)
				return;

			if(!HasPrefabList())
				return;


			foreach( XMLSaveableData data in dataList )
			{
				XMLSaveablePrefab prefab = prefabList.InstantiateSaveablePrefab( data );
				if( prefab == null ) continue;;
				prefab.transform.parent = gameObject.transform;
			}
		}

		public static XMLSaveableData[] Load( string path )
		{
			XmlSerializer serializer = new XmlSerializer( typeof(XMLSaveableData[]) );
			
			XMLSaveableData[] result = null;
			using( FileStream stream = new FileStream( path, FileMode.Open ) )
			{
				result = serializer.Deserialize( stream ) as XMLSaveableData[];
			}
			return result;
		}
		
		public static XMLSaveableData[] LoadFromAsset( TextAsset asset )
		{
			XmlSerializer serializer = new XmlSerializer( typeof(XMLSaveableData[]) );
			
			XMLSaveableData[] result = null;
			using( TextReader reader = new StringReader( asset.text ) )
			{
				result = serializer.Deserialize( reader ) as XMLSaveableData[];
			}
			return result;
		}

		public string dataPath
		{
			get
			{
				if( Application.isEditor )
				{
					return Path.Combine( Application.dataPath, resourcePath );
				} else {
					return Application.persistentDataPath + "/";
				}
			}
		}
		
		public string filename
		{
			get
			{
				return Path.Combine( dataPath, name + ".xml" );
			}
			
		}
	}
}