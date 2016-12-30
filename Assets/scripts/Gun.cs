using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		  if (Input.GetButtonDown("Fire1")){
		  	Vector3 pos = Input.mousePosition;
		  	pos.z = 10.0f;
            Instantiate(bullet, Camera.main.ScreenToWorldPoint(pos), Quaternion.identity);
    }
	}
}
