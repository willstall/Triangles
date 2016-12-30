using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour {
	public int goalNumber = 20;
	int number = 0;
	//RaycastHit hit;
	int layerMask = 1 << 6;
	float radius;
	// Use this for initialization
	void Start () {
		radius = this.GetComponent<SphereCollider>().radius;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit[] hits = Physics.SphereCastAll(Vector3.zero,radius,Vector3.zero,0f);
		number = hits.Length;

		if (number>=goalNumber){Debug.Log("you have "+number+" triangles!!!");}
	}
}
