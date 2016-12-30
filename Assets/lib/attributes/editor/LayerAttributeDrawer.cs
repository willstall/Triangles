using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer( typeof(LayerAttribute) )]
public class LayerAttributeDrawer : PropertyDrawer {

	
	public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
	{
		position = EditorGUI.PrefixLabel(position, label);
		property.intValue = EditorGUI.LayerField( position, property.intValue );
		
	}
	
}
