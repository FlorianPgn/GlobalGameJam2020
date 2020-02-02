using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Machine[] Machines;
    [Range(0f, 10f)]
    public float HazardDelay = 3f;
    public int silmutanousHazards;
    public AnimationCurve difficultyCurve;
    public int totalTimeInSec;
    [Range(0f, 0.50f)]
    public float speedLoss = .20f;

    public Text timerText;
    // Start is called before the first frame update

    private float _nextHazardTiming;

    private List<int> _workingMachines;
    
    void Start()
    {
        _nextHazardTiming = Time.time + HazardDelay;
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
        int idx = Random.Range(0, workingMachines.Length);
        return workingMachines[idx];
    }

    private void displayTimer()
    {
        string estimatedTime = "\n" + "Estimated travel time is: ";
        int estimatedMinutes = (int)totalTimeInSec / 60;
        int estimatedSeconds = (int)totalTimeInSec % 60;

        if (estimatedSeconds < 10)
            estimatedTime += estimatedMinutes + ":0" + estimatedSeconds;
        else
            estimatedTime += estimatedMinutes + ":" + estimatedSeconds;

        if (Time.time < 60)
            timerText.text = System.Math.Round(Time.time, 2).ToString() + estimatedTime;
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
