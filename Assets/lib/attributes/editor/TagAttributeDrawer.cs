using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer( typeof(TagAttribute) )]
public class TagAttributeDrawer : PropertyDrawer {

	
	public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
	{
		position = EditorGUI.PrefixLabel(position, label);
		property.stringValue = EditorGUI.TagField( position, property.stringValue );
		
	}
	
}
