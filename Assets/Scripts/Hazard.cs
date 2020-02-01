using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hazard : MonoBehaviour
{
    
    public void generateHazard(List<Transform> hazardPossibleLocations)
    {
        Transform hazardPosition = getHazardLocation(hazardPossibleLocations);
        generateEffects(hazardPosition);
    }

    public Transform getHazardLocation(List<Transform> hazardPossibleLocations)
    {
        int randomIndex = (int) Random.Range(0f, hazardPossibleLocations.Count);
        Transform randomTransform = hazardPossibleLocations[randomIndex];
        return randomTransform;
    }

    public abstract void generateEffects(Transform hazardPosition);
}
