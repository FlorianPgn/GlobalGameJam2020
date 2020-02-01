using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public int interval;
    public AnimationCurve difficultyCurve;
    public int silmutanousHazards;

    public Transform toiletHazardLocations;
    public Transform labHazardLocations;
    public Transform machineRoomHazardLocations;
    public Transform commandRoomHazardLocations;

    private List<Hazard> hazardList;

    // Start is called before the first frame update
    void Start()
    {
        initHazardsList();
        InvokeRepeating("GenerateHazardAfterInterval", 0f, interval);
    }

    private void initHazardsList()
    {
        Hazard toiletHazard = new ToiletHazard(toiletHazardLocations);
        Hazard commandRoomHazard = new CommandRoomHazard(commandRoomHazardLocations);
        Hazard labHazard = new LabHazard(labHazardLocations);
        Hazard machineRoomHazard = new MachineRoomHazard(machineRoomHazardLocations);

        hazardList = new List<Hazard>();

        hazardList.Add(toiletHazard);
        hazardList.Add(commandRoomHazard);
        hazardList.Add(labHazard);
        hazardList.Add(machineRoomHazard);
    }

    private void GenerateHazardAfterInterval()
    {
       /* float pauseEndTime = Time.realtimeSinceStartup + interval;

        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return null;
        }
        */
        for (int i = 0; i < silmutanousHazards; i++)
        {
            Hazard randomHazard = selectRandomHazard();
            randomHazard.generateHazard();
        }
    }

    private Hazard selectRandomHazard()
    {
        int randomLocationListIndex = (int) Random.Range(0f, hazardList.Count);

        return hazardList[randomLocationListIndex];
    }
}
