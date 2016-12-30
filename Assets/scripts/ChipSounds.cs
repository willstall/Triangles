using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSounds : MonoBehaviour {
	public AudioClip[] chips;
	public AudioClip[] walls;
	public bool madeSound = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
			//Debug.Log("making sound!");
		if (collision.relativeVelocity.magnitude > .5f && !madeSound){
			if (collision.gameObject.tag=="Chip"){
				collision.gameObject.GetComponent<ChipSounds>().madeSound = true;
				AudioClip clip = chips[Mathf.FloorToInt(((float)chips.Length*Random.value))];
				AudioSource.PlayClipAtPoint(clip,transform.position);
			}
			if (collision.gameObject.tag=="Solid"){
				AudioClip clip = walls[Mathf.FloorToInt(((float)walls.Length*Random.value))];
				AudioSource.PlayClipAtPoint(clip,transform.position);
			}
		}
		madeSound = false;
	}
}
