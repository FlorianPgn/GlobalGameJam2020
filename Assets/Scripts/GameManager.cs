using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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
    [Range(0, 5)]
    public int timeForFirstHazard;

    public Text timerText;

    private float _nextHazardTiming;
    private int startingEstimatedTime;
    
    private List<int> _workingMachines;

    private const int SIX_MINUTES = 6 * 60;
    
    void Start()
    {
        _nextHazardTiming = Time.time + HazardDelay;
        SoundManager.instance.PlayAmbiance(ambiance, .8f);
        SoundManager.instance.PlayLoop(music);

        startingEstimatedTime = totalTimeInSec;
        InvokeRepeating("findBrokenMachine", 0, timeBetweenSpeedLoss);
        InvokeRepeating("autoRepair", 0, timeBetweenSpeedLoss * 1.5f);

        for (int i = 0; i < silmutanousHazards; i++)
        {
            StartCoroutine("triggerFirstHazard", timeForFirstHazard);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextHazardTiming)
        {
            float percentageTimeLeft = Time.time / totalTimeInSec;
            _nextHazardTiming = Time.time + HazardDelay - difficultyCurve.Evaluate(percentageTimeLeft);

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

        if (Time.time >= totalTimeInSec)
            timerText.text = "Game over"; //Ajouter la méchanique de game over ici.
        else
        {
            if (estimatedSeconds < 10)
                estimatedTime += estimatedMinutes + ":0" + estimatedSeconds;
            else
                estimatedTime += estimatedMinutes + ":" + estimatedSeconds;

            if (Time.time < 60)
                timerText.text = Math.Round(Time.time, 2).ToString() + estimatedTime;
            else
            {
                int minutes = (int)Time.time / 60;
                int seconds = (int)Time.time % 60;

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

                if (totalTimeInSec > SIX_MINUTES)
                    totalTimeInSec = SIX_MINUTES;

                if (i >= nonWorkingMachines.Length)
                    break;
            }
        }
    }

    private void autoRepair()
    {
        totalTimeInSec -= (int)(totalTimeInSec * (speedLoss / 2));

        if (totalTimeInSec < startingEstimatedTime)
            totalTimeInSec = startingEstimatedTime;
    }
}
