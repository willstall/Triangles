using UnityEngine;
using System.Collections;
using ApplicationLogic;

namespace ApplicationLogic
{
	public class QuitStateLoop : ApplicationStateLoop
	{

		public override void OnSetup()
		{
			Application.Quit();
		}

		public override void OnTeardown(){}
	}
}