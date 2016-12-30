using UnityEngine;
using System.Collections;

public class DestroyOffScreen : MonoBehaviour
{

	float tolerance = 1.0f;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 vp = Camera.main.WorldToViewportPoint( transform.position );
		if( vp.x >= -tolerance && vp.x <= 1 + tolerance && vp.y >= -tolerance && vp.y <= 1 + tolerance ) return;

		Destroy(gameObject);
	}
}
