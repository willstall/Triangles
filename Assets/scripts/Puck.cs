using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ForceFields;

public class Puck : MonoBehaviour {
	public int goalNumber = 20;
	int number = 0;
	int number_p = 0;
	List<Rigidbody> collection;
	float anim = 1f;
	Transform ring;

	// Use this for initialization
	void Start () {
		collection = this.GetComponent<ForceField>().Collection();
		ring = this.transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		number = collection.Count;
		if (number>number_p){
			anim = 0f;
		}

		anim += (1f-anim)*.08f;
		float scale = anim*6f;
		ring.localScale = scale*Vector3.one;
		number_p = number;
	}
}
