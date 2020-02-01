using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardManager : MonoBehaviour
{
    public float interval;
    public float timeBeforeFirstHazard;
    public AnimationCurve difficultyCurve;
    public int silmutanousHazards;

    public Transform toiletHazardLocations;
    public Transform labHazardLocations;
    public Transform machineRoomHazardLocations;
    public Transform commandRoomHazardLocations;

    public int totalTimeInSec;

    public Text timerText;

    private List<Hazard> hazardList;
    private float startInterval;

    // Start is called before the first frame update
    void Start()
    {
        initHazardsList();
        startInterval = interval;

        StartCoroutine("GenerateHazardAfterInterval", timeBeforeFirstHazard);
    }

    private void Update()
    {
        float percentageTimeLeft = Time.time / totalTimeInSec;

        interval = startInterval - difficultyCurve.Evaluate(percentageTimeLeft);

        displayTimer();

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

    private IEnumerator GenerateHazardAfterInterval(float wait)
    {
        yield return new WaitForSeconds(wait);

        while (true)
        {
            Debug.Log("Hazards: " + interval);
            for (int i = 0; i < silmutanousHazards; i++)
            {
                Hazard randomHazard = selectRandomHazard();
                randomHazard.generateHazard();
            }
            yield return new WaitForSeconds(interval);
        }
        
    }

    private Hazard selectRandomHazard()
    {
        int randomLocationListIndex = (int) Random.Range(0f, hazardList.Count);

        return hazardList[randomLocationListIndex];
    }

    private void displayTimer()
    {
        float timerCountdown = totalTimeInSec - Time.time;

        if (timerCountdown <= 0)
        {
            timerCountdown = 0.00f;
            timerText.color = Color.red;
        }

        if (timerCountdown < 60)
            timerText.text = System.Math.Round(timerCountdown, 2).ToString();
        else
        {
            int minutes = (int)timerCountdown / 60;
            int seconds = (int)timerCountdown % 60;

            if (seconds < 10)
                timerText.text = minutes + " : 0" + seconds;
            else
                timerText.text = minutes + " : " + seconds;
        }
    }
}
