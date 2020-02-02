using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{

    public Machine[] Machines;
    [Range(0f, 10f)]
    public float HazardDelay = 3f;
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
            _nextHazardTiming = Time.time + HazardDelay;
            BreakMachine();
        } 
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
}
