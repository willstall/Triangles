using UnityEngine;
using System.Collections;

public class LayerMaskTool
{
	public static bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
       return ((mask.value & (1 << obj.layer)) > 0);
    } 
}
