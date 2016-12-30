using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	float angle;
	public float radius = 1f;
	float anim = 0;
	// Use this for initialization
	void Start () {
		angle = Random.value;
		Camera.main.GetComponent<CameraRig>().Shoot();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<transform.childCount;i+=1){
			transform.GetChild(i).transform.localPosition = new Vector3(
				Mathf.Pow(anim,1f/2f) * radius * Mathf.Cos((angle*Mathf.PI*2f)+(Mathf.PI*2*(float)i/(float)transform.childCount)),
				Mathf.Pow(anim,1f/2f) * radius * Mathf.Sin((angle*Mathf.PI*2f)+(Mathf.PI*2*(float)i/(float)transform.childCount)),
				0f
				);
			transform.GetChild(i).transform.localScale = Vector3.one*(1f-anim)*.07f;
		}
		anim += (1f-anim)*.08f;
	}
}
