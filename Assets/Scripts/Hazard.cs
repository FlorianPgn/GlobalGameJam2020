using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Hazard : ScriptableObject 
{
    public Transform hazardPossibleLocations;

    public Hazard(Transform hazardPossibleLocations)
    {
        this.hazardPossibleLocations = hazardPossibleLocations;
    }

    public void generateHazard()
    {
        Vector3 hazardPosition = getHazardLocation().position;
        generateEffects(hazardPosition);
    }

    public Transform getHazardLocation()
    {
        int randomIndex = (int) Random.Range(0f, hazardPossibleLocations.childCount);
        Transform randomTransform = hazardPossibleLocations.GetChild(randomIndex);

        return randomTransform;
    }

    public Transform getHazardPossibleLocations()
    {
        return hazardPossibleLocations;
    }

    public abstract void generateEffects(Vector3 hazardPositions);
}
