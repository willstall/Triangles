using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashGraphic : MonoBehaviour {

	public Graphic graphic;
	public float frequency;

	float t = 0;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		t += Time.deltaTime;

		Color c = graphic.color;
		c.a = Mathf.InverseLerp(-1, 1, Mathf.Sin( t * frequency ) );
		graphic.color = c;
	}
}
