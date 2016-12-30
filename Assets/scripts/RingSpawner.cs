using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
	public GameObject objectToInstantiate;
	public Transform objectParentTransform;

	[Space(10)]

	public float radius = 1.0f;
	public float width = 0.5f;

	[Space(10)]

	public Interval interval = 1;
	public bool isPaused = false;

	[Space(10)]

	public bool shouldSpawnOnAwake = false;

	void Start ()
	{
		if(shouldSpawnOnAwake)
			interval.FastForward();

		if(objectParentTransform == null)
			objectParentTransform = this.transform;
	}

	void Update ()
	{
		if(isPaused)
			return;

		interval.Update();
		
		if(interval.isComplete)
		{
            Spawn( objectToInstantiate );
            interval.Reset();
		}
	}

	GameObject Spawn( GameObject obj )
	{
		if(obj == null)
		{
			Debug.LogError("Spawn object not set on:" + this.name );
			return null;
		}


		GameObject go = Instantiate(objectToInstantiate, randomPosition, Quaternion.identity) as GameObject;
		
		return go;
	}

	Vector3 randomPosition
	{
		get
		{
			Vector2 radiusPoints = radii;
			var dist = radiusPoints.x - radiusPoints.y;
				dist = dist * Random.value + radiusPoints.y;

			var angle = Random.value;

			Vector3 position = Vector3.zero;
					position.x = Mathf.Cos( angle * Mathf.PI * 2f ) * dist;
					position.y = Mathf.Sin( angle * Mathf.PI * 2f ) * dist;

			return position;
		}
	}

	Vector2 radii
	{
		get
		{
			if(width < 0)
				width = 0;

			float outerRadius = radius + width * 0.5f;
			float innerRadius = radius - width * 0.5f;

			return new Vector2(innerRadius,outerRadius);
		}
	}

	void OnDrawGizmosSelected()
	{
		if(objectParentTransform == null)
			objectParentTransform = this.transform;

		Vector2 radiusPoints = radii;

		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(objectParentTransform.position, radiusPoints.x);
		Gizmos.DrawWireSphere(objectParentTransform.position, radiusPoints.y);

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(objectParentTransform.position, radius);		
	}
}
	