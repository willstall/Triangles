using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRandomRotation : MonoBehaviour {
	public bool randomX = true;
	public bool randomY = true;
	public bool randomZ = true;
	// Use this for initialization
	void Start () {
		this.transform.Rotate(
			randomX?Random.value*360f:0f,
			randomY?Random.value*360f:0f,
			randomZ?Random.value*360f:0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
