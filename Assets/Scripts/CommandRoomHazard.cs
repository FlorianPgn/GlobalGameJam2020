using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRoomHazard : Hazard
{
    public CommandRoomHazard(Transform hazardPossibleLocations) : base(hazardPossibleLocations) { }

    public new void generateEffects(Vector3 hazardPosition)
    {
        //TODO Code the method.
        Debug.Log("Fuck un fil a briser");
    }
}
