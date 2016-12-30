using UnityEngine;
using System.Collections;


public static class TransformExtensions  {

    public static Bounds GetBoundsWithChildren( this Transform transform )
    {
        Bounds newBounds = new Bounds();
        foreach (Transform child in transform)
        {
            newBounds.Encapsulate(child.position);
        }
        return newBounds;
    }

    public static void DestroyAllChildren(this Transform transform) {
        foreach (Transform child in transform) {
            UnityEngine.Object.Destroy(child.gameObject);
        }
    }

    public static T InstantiateChild<T>( this Transform trans, T obj ) where T:UnityEngine.Component
    {
        return InstantiateAndParent( obj, trans.position, trans.rotation, trans, obj.name );
    }

    public static T InstantiateChild<T>( this Transform trans, T obj, Vector3 pos ) where T:UnityEngine.Component
    {
        return InstantiateAndParent( obj, pos, trans.rotation, trans, obj.name );
    }

    public static T InstantiateChild<T>( this Transform trans, T obj, Vector3 pos, Quaternion rot ) where T:UnityEngine.Component
    {
        return InstantiateAndParent( obj, pos, rot, trans, obj.name );
    }

    public static T InstantiateChild<T>( this Transform trans, T obj, Vector3 pos, Quaternion rot, string name ) where T:UnityEngine.Component
    {
        return InstantiateAndParent( obj, pos, rot, trans, name );
    }

    private static T InstantiateAndParent<T>( T obj, Vector3 pos, Quaternion rot, Transform parent, string name ) where T:UnityEngine.Component
    {
        T newObject = UnityEngine.Object.Instantiate( obj, pos, rot ) as T;
        newObject.gameObject.name = name;
        newObject.transform.parent = parent;

        return newObject;
    }
}
