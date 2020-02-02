using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class LightsController : Toggled
{
    public Light[] MachinesLight;
    public Light[] BathroomLight;
    public Light[] LaboLight;

    private Light[][] _lights => new[] {MachinesLight, BathroomLight, LaboLight};

    public float LightsBugProba = 0.1f;

    private bool _lightBugHappening = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BugLoop());
        
    }

    private IEnumerator BugLoop()
    {
        while (true)
        {
            int maxBound = (int) (1/LightsBugProba);
            
            if (!_lightBugHappening && Random.Range(0, maxBound) == 0)
            {
                TurnOffLights();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void TurnOffLights()
    {
        _lightBugHappening = true;
        int idx = Random.Range(0, _lights.Length);
        foreach (var light in _lights[idx])
        {
            light.enabled = false;
        }
    }

    public override void Toggle()
    {
        TurnOnLights();
    }

    public void TurnOnLights()
    {
        _lightBugHappening = false;
        foreach (var lights in _lights)
        {
            foreach (var light in lights)
            {
                light.enabled = true;
            }
        }
    }
}
