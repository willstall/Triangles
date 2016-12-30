using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingForwardMotion : MonoBehaviour {
	public float force;
	public float randomness;
	// Use this for initialization
	void Start () {
		float Force = force + (randomness*(Random.value-0.5f));
		this.GetComponent<Rigidbody>().AddForce(this.transform.forward*Force,ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
