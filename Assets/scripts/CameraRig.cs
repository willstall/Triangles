using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
	public float xRange = 2f;
	public float yRange = 1f;
	[Range(0,1)]
	public float moveAccel = .1f;

	[Space(10)]

	public float zRange = 2f;
	[Range(0,1)]
	public float zAccel = .1f;
	

	Vector3 originalLocalPosition;
	Vector3 mouseNormal = Vector3.zero;
	float currentPos = 0f;
	float shoot = 0f;

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
				pos.x += Mathf.Lerp(xRange * -0.5f , xRange * 0.5f, normal.x);

		transform.localPosition = Vector3.Lerp(transform.localPosition, pos, moveAccel);

		var targetNormal = transform.forward;
			targetNormal.z = Mathf.Lerp( zRange * -0.5f, zRange * 0.5f, normal.x);

		currentPos += (normal.x-currentPos)*zAccel;
		transform.localRotation = Quaternion.identity;
		transform.Rotate(new Vector3(0f,0f,Mathf.Lerp(-zRange,zRange,currentPos)));

		//Quaternion toRotation = Quaternion.LookRotation(lookPos);

		//transform.localRotation = toRotation;//Quaternion.Slerp(transform.localRotation, toRotation, zAccel);
		this.transform.position =new Vector3(this.transform.position.x,this.transform.position.y,Mathf.Lerp(-10f,-11f,shoot));
		shoot += (0f-shoot)*.08f;
	}

	public void Shoot(){
		shoot = 1f;
	}

}