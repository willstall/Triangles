using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBuilder : MonoBehaviour {
	public GameObject boxObject;
	public float radius = 10.0f;
	public int quality = 25;
	// Use this for initialization
	void Start () {
			float circumference = radius*2f*Mathf.PI;
			float scale = circumference / (float)quality;
			float adjustedRadius = radius+(scale/2f);
		for(int i=0;i<quality;i+=1){
			GameObject box = Instantiate(boxObject,
					new Vector3(
						Mathf.Cos(i/(float)quality*2f*Mathf.PI)*adjustedRadius,
						Mathf.Sin(i/(float)quality*2f*Mathf.PI)*adjustedRadius,
						0f),
					//new Vector3(0f,0f,i/(float)quality*360f)
					Quaternion.identity
					);
			box.transform.Rotate(new Vector3(0f,0f,(float)i/(float)quality*360f));
			box.transform.localScale = new Vector3(scale,scale,scale);
		}
		this.gameObject.transform.localScale = new Vector3(radius/10f,radius/10f,radius/10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
