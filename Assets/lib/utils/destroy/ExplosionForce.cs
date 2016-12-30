using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour
{
	public LayerMask layersToAffect;
	public float explosionRadius;
	public float force;
	public bool explodeOnStart = true;

	void Start ()
	{
		if( explodeOnStart )
		{
			Explode( transform.position );
		}
	}

	public void Explode( Vector3 point )
	{
		Collider[] colliders = Physics.OverlapSphere( point, explosionRadius, layersToAffect );

		foreach( Collider collider in colliders )
		{
			Rigidbody rb = collider.GetComponent<Rigidbody>();
			if( rb == null )
				continue;

			Vector3 forceVector = (rb.transform.position - point).normalized * force;
			rb.AddForceAtPosition( forceVector, point, ForceMode.Impulse );	
		}

	}
}
