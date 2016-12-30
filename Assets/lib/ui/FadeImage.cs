using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeImage : MonoBehaviour 
{
	public Graphic image;
	public float duration;
	public bool flashOnStart = false;

	float timer;


	void Start()
	{
		if(flashOnStart)
			Flash();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		image.color = new Color(1, 1, 1, timer/duration );

		timer -= Time.deltaTime;
		timer = Mathf.Clamp( timer, 0, duration );
	}

	public void Flash()
	{
		timer = duration;
	}
}
