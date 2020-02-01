using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineRoomHazard : Hazard
{
    public MachineRoomHazard(Transform hazardPossibleLocations) : base(hazardPossibleLocations){}

    public new void generateEffects(Vector3 hazardPosition)
    {
        //TODO Code the method.
        Debug.Log("Fuck un tuyau est percer");
    }
}
