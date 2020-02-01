using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ToiletHazard : Hazard
{

    public ToiletHazard(Transform hazardPossibleLocations) : base(hazardPossibleLocations){}

    public new void generateEffects(Vector3 hazardPosition)
    {
        //TODO Code the method.
        Debug.Log("Fuck une toilette est boucher a: " + hazardPosition);
    }
}
