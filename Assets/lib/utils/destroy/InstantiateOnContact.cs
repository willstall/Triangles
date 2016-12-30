using UnityEngine;
using System.Collections;

public class InstantiateOnContact : MonoBehaviour
{
	public GameObject obj;
	public LayerMask layersToCollideWith;
	public bool inheritParentTransform = true;

	void OnCollisionEnter(Collision collision)
	{
		if(enabled == false)
			return;

		if(obj == null)
			return;

		if( !LayerMaskTool.IsInLayerMask( collision.gameObject, layersToCollideWith ) )
			return;


		GameObject go = Instantiate( obj, transform.position, transform.rotation ) as GameObject;

		if(inheritParentTransform == true)
			go.transform.parent = transform.parent;
	}

	void OnEnable(){}

	void OnDisable(){}
}