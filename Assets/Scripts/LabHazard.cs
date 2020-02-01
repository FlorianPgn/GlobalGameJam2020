using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabHazard : Hazard
{
    public LabHazard(Transform hazardPossibleLocations) : base(hazardPossibleLocations) { }

    public override void generateEffects(Vector3 hazardPosition)
    {
        //TODO Code the method.
        Debug.Log("Fuck le feu est pogner");
    }
}
