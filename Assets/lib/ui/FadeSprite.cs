using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeSprite : MonoBehaviour 
{
	public SpriteRenderer sprite;
	public Interval interval = 1;

	Color origColor;

	void Start()
	{
		origColor = sprite.color;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		interval.Update();

		Color c = sprite.color;
		c.a = 1 - interval.percentComplete;

		sprite.color = c;
	
	}

}
