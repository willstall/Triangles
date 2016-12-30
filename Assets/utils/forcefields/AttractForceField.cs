﻿using UnityEngine;
using System.Collections;

namespace ForceFields
{
	public class AttractForceField : ForceField
	{
		public float force = 1.0f;

		public override Vector3 GetVectorField( Vector3 position )
		{
			return (transform.position - position).normalized * force;
		}
	}
}