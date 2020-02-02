using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public Machine[] Machines;
    public AudioClip music;
    public AudioClip ambiance;
    [Range(0f, 10f)]
    public float HazardDelay = 3f;
    public int silmutanousHazards;
    public AnimationCurve difficultyCurve;
    public int totalTimeInSec;
    [Range(0f, 0.50f)]
    public float speedLoss = .20f;
    [Range(0, 10)]
    public int timeBetweenSpeedLoss = 3;
    [Range(0, 30)]
    public int timeForFirstHazard;
    public float medecineCreationTime;

    public Text timerText;

    private float _nextHazardTiming;
    private int startingEstimatedTime;
    private int nbMedecine;
    
    private List<int> _workingMachines;


    public float TimeStart;
    private const int TWO_MINUTES = 2 * 60;
    
    void Start()
    {
        TimeStart = Time.timeSinceLevelLoad;
        Debug.Log(TimeStart);
        _nextHazardTiming = Time.timeSinceLevelLoad + HazardDelay + timeForFirstHazard;
        SoundManager.instance.PlayAmbiance(ambiance, .8f);
        SoundManager.instance.PlayLoop(music);
        nbMedecine = 0;

        startingEstimatedTime = totalTimeInSec;
        InvokeRepeating("findBrokenMachine", 0, timeBetweenSpeedLoss);
        InvokeRepeating("autoRepair", 0, timeBetweenSpeedLoss * 1.5f);
        InvokeRepeating("CreateMedecine", 0, medecineCreationTime);

        for (int i = 0; i < silmutanousHazards; i++)
        {
            StartCoroutine("triggerFirstHazard", timeForFirstHazard);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > _nextHazardTiming)
        {
            float percentageTimeLeft = Time.timeSinceLevelLoad / totalTimeInSec;
            _nextHazardTiming = Time.timeSinceLevelLoad + HazardDelay - difficultyCurve.Evaluate(percentageTimeLeft);

            for (int i = 0; i < silmutanousHazards; i++)
            {
                BreakMachine();
            }
        }
        
        displayTimer();
    }

    private IEnumerator triggerFirstHazard(int timeForFirstHazard)
    {
        yield return new WaitForSeconds(timeForFirstHazard);
        BreakMachine();
    }

    private void BreakMachine()
    {
        Machine machine = SelectWorkingMachine();
        if (machine != null)
        {
            machine.Break();
        }
    }

    private Machine SelectWorkingMachine()
    {
        Machine[] workingMachines = Machines.Where(machine => machine.IsWorking).ToArray();
        if (workingMachines.Length == 0)
        {
            return null;
        }
        int idx = UnityEngine.Random.Range(0, workingMachines.Length);
        return workingMachines[idx];
    }

    private void displayTimer()
    {
        string estimatedTime = "\n" + "Estimated travel time is: ";
        int estimatedMinutes = totalTimeInSec / 60;
        int estimatedSeconds = totalTimeInSec % 60;
        
        if (Time.timeSinceLevelLoad >= startingEstimatedTime && totalTimeInSec <= (startingEstimatedTime + TWO_MINUTES) / 2)
        {
            SceneManager.LoadScene("MenuEnd1");
        }
        else if (Time.timeSinceLevelLoad >= totalTimeInSec && totalTimeInSec >= (startingEstimatedTime + TWO_MINUTES) / 2)
        {
            String[] badEndings = { "MenuEnd2", "MenuEnd2" };

            int randomBadEnding = UnityEngine.Random.Range(0, 1);

            SceneManager.LoadScene(badEndings[randomBadEnding]);

        }
        else
        {
            if (estimatedSeconds < 10)
                estimatedTime += estimatedMinutes + ":0" + estimatedSeconds;
            else
                estimatedTime += estimatedMinutes + ":" + estimatedSeconds;

            if (Time.timeSinceLevelLoad < 60)
                timerText.text = Math.Round(Time.timeSinceLevelLoad, 2).ToString() + estimatedTime;
            else
            {
                int minutes = (int) Time.timeSinceLevelLoad / 60;
                int seconds = (int) Time.timeSinceLevelLoad % 60;

                if (seconds < 10)
                    timerText.text = minutes + ":0" + seconds + estimatedTime;
                else
                    timerText.text = minutes + ":" + seconds + estimatedTime;
            }
        }
    }

    private void findBrokenMachine()
    {
        int i = 0;
        Machine[] nonWorkingMachines = Machines.Where(machine => !machine.IsWorking).ToArray();
        
        if (nonWorkingMachines.Length != 0)
        {
            while (nonWorkingMachines[i])
            {
                totalTimeInSec = (int)(totalTimeInSec * (1 + speedLoss));
                i++;

                if (totalTimeInSec > startingEstimatedTime + TWO_MINUTES)
                    totalTimeInSec = startingEstimatedTime + TWO_MINUTES;

                if (i >= nonWorkingMachines.Length)
                    break;
            }

            if (totalTimeInSec >= startingEstimatedTime + TWO_MINUTES)
                totalTimeInSec = startingEstimatedTime + TWO_MINUTES;
        }
    }

    private void autoRepair()
    {
        totalTimeInSec -= (int)(totalTimeInSec * (speedLoss / 2));

        if (totalTimeInSec < startingEstimatedTime)
            totalTimeInSec = startingEstimatedTime;
    }

    private void CreateMedecine()
    {
        int i = 0;

        while (i < Machines.Length)
        {
            System.Object value = Machines.GetValue(i);

            if((value.Equals(Machines.GetValue(2)) ||
                value.Equals(Machines.GetValue(3))) &&
                Time.timeSinceLevelLoad >= medecineCreationTime &&
                Machines[i].IsWorking)
            {
                nbMedecine++;
            }

            i++;
        }
    }
}
