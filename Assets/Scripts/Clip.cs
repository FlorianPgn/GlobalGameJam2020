using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
[System.Serializable]
public struct Clip
{
   public AudioClip Audio;
   [Range(0,1)]
   public float Volume;
}
