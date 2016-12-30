using UnityEngine;
using System.Collections;

public class LayerMaskTool
{
	public static bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
       return ((mask.value & (1 << obj.layer)) > 0);
    } 
}

namespace ExtensionMethods {
     public static class LayerMaskExtensions {
         public static bool IsInLayerMask(this LayerMask mask, int layer) {
             return ((mask.value & (1 << layer)) > 0);
         }
         
         public static bool IsInLayerMask(this LayerMask mask, GameObject obj) {
             return ((mask.value & (1 << obj.layer)) > 0);
         }
     }
 }