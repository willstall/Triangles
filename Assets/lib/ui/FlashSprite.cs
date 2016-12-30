using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashSprite : MonoBehaviour {

	public SpriteRenderer sprite;
	public float frequency;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Color c = sprite.color;
		c.a = Mathf.InverseLerp(-1, 1, Mathf.Sin( Time.time * frequency ) );
		sprite.color = c;
	}
}
