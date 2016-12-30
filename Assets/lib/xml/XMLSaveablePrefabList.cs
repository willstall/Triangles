using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XML
{
	public class XMLSaveablePrefabList : MonoBehaviour, ISerializationCallbackReceiver
	{
		public List<XMLSaveablePrefabData> prefabs = new List<XMLSaveablePrefabData>();

		public XMLSaveablePrefab InstantiateSaveablePrefabByName( string name )
		{
			return InstantiateSaveablePrefabByName( name, Vector3.zero, Quaternion.identity);
		}

		public XMLSaveablePrefab InstantiateSaveablePrefabByName( string name, Vector3 position )
		{
			return InstantiateSaveablePrefabByName( name, position, Quaternion.identity);
		}

		public XMLSaveablePrefab InstantiateSaveablePrefabByName( string name, Vector3 position,  Quaternion rotation )
		{
			XMLSaveablePrefabData prefabData = GetPrefabDataByName( name );
			if( prefabData == null ) return null;
			XMLSaveablePrefab go = Instantiate(prefabData.prefab, position, rotation) as XMLSaveablePrefab;
			go.name = prefabData.name;
			go.data.prefabData = prefabData;
			return go;
		}

		public XMLSaveablePrefab InstantiateSaveablePrefab( XMLSaveableData data )
		{
			return InstantiateSaveablePrefab( data, Vector3.zero, Quaternion.identity);
		}

		public XMLSaveablePrefab InstantiateSaveablePrefab( XMLSaveableData data, Vector3 position )
		{
			return InstantiateSaveablePrefab( data, position, Quaternion.identity);
		}

		public XMLSaveablePrefab InstantiateSaveablePrefab( XMLSaveableData data, Vector3 position,  Quaternion rotation )
		{
			XMLSaveablePrefabData prefabData = GetPrefabDataByGuid( data.prefabData.guid );
			if( prefabData == null ) return null;
			XMLSaveablePrefab go = Instantiate(prefabData.prefab, position, rotation) as XMLSaveablePrefab;
			data.prefabData = prefabData;
			go.name = prefabData.name;
			go.Initialize( data );
			return go;
		}

		public string[] GetPrefabNames()
		{
			string[] list = new string[ prefabs.Count ];
			for( int i = 0; i < list.Length; i++)
			{
				list[i] = prefabs[i].name;
			}
			return list;
		}

		public string[] GetPrefabGuids()
		{
			string[] list = new string[ prefabs.Count ];
			for( int i = 0; i < list.Length; i++)
			{
				list[i] = prefabs[i].guid;
			}
			return list;
		}

		public string GetGuidByName( string name )
		{
			var prefab = GetPrefabDataByName( name );
			if( prefab != null)
				return prefab.guid;
			else
				return "";
		}

		public string GetNameByGuid( string guid )
		{
			var prefab = GetPrefabDataByGuid( guid );
			if( prefab != null)
				return prefab.name;
			else
				return "";
		}

		XMLSaveablePrefabData GetPrefabDataByName( string name )
		{
			foreach( XMLSaveablePrefabData prefab in prefabs )
			{
				if(prefab.name == name )
					return prefab;
			}
			return null;
		}

		XMLSaveablePrefabData GetPrefabDataByGuid( string guid )
		{
			foreach( XMLSaveablePrefabData prefab in prefabs )
			{
				if(prefab.guid == guid )
					return prefab;
			}
			return null;
		}

		public void OnBeforeSerialize()
		{
			List<string> usedGuid = new List<string>();

			foreach( XMLSaveablePrefabData prefab in prefabs )
			{
				string newGuid = prefab.guid;
				while( usedGuid.Contains( newGuid ) || newGuid == "" )
				{
					newGuid = System.Guid.NewGuid().ToString();
				}

				usedGuid.Add( newGuid );
				prefab.guid = newGuid;
			}
		}

		public void OnAfterDeserialize()
		{
			//mook
		}
	}
}