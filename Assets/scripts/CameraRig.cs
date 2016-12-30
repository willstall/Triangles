using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
	public float xRange = 2f;
	[Range(0,1)]
	public float xAccel = .1f;

	[Space(10)]

	public float yRange = 1f;
	[Range(0,1)]
	public float yAccel = .1f;

	Vector3 originalLocalPosition;
	Vector3 mouseNormal = Vector3.zero;
	float currentPos = 0f;

	Quaternion originalRotation;

	void Start ()
	{
		originalLocalPosition = transform.localPosition;
		originalRotation = transform.localRotation; 
	}

	void Update ()
	{
		Vector3 normal = Camera.main.ScreenToViewportPoint(Input.mousePosition);

		mouseNormal = normal;

		Vector3 pos = originalLocalPosition;
				pos.y += Mathf.Lerp(yRange * -0.5f , yRange * 0.5f, normal.y);

		transform.localPosition = Vector3.Lerp(transform.localPosition, pos, yAccel);

		var targetNormal = transform.forward;
			targetNormal.z = Mathf.Lerp( xRange * -0.5f, xRange * 0.5f, normal.x);

		currentPos += (normal.x-currentPos)*xAccel;
		transform.localRotation = Quaternion.identity;
		transform.Rotate(new Vector3(0f,0f,Mathf.Lerp(-35f,35f,currentPos)));

		//Quaternion toRotation = Quaternion.LookRotation(lookPos);

		//transform.localRotation = toRotation;//Quaternion.Slerp(transform.localRotation, toRotation, xAccel);

		Debug.Log( normal );
	}

}