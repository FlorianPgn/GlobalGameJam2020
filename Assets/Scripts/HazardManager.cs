using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public int interval;
    public AnimationCurve difficultyCurve;

    private List<Hazard> hazardList;

    // Start is called before the first frame update
    void Start()
    {
        initHazardsList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initHazardsList()
    {
        Hazard toiletteHazard = new ToiletteHazard();
        Hazard commandRoomHazard = new CommandRoomHazard();
        Hazard labHazard = new LabHazard();
        Hazard machineRoomHazard = new MachineRoomHazard();

        hazardList = new List<Hazard>();

        hazardList.Add(toiletteHazard);
        hazardList.Add(commandRoomHazard);
        hazardList.Add(labHazard);
        hazardList.Add(machineRoomHazard);
    }
}
