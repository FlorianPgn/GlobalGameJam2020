using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LightsController : Toggled
{
    public Light[] MachinesLight;
    public Light[] BathroomLight;
    public Light[] LaboLight;
    public Image[] MachinesImages;
    public Image[] BathroomImages;
    public Image[] LaboImages;

  
    private Light[][] _lights => new[] {MachinesLight, BathroomLight, LaboLight};
    private Image[][] _images => new[] {MachinesImages, BathroomImages, LaboImages};

    public float LightsBugProba = 0.1f;

    private bool _lightBugHappening = false;
    public AudioClip Clip;

    public GameObject LightAlarm;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BugLoop());
        
    }

    private void Update()
    {
        LightAlarm.SetActive(_lightBugHappening);
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
        SoundManager.instance.PlaySingle(Clip, 0.25f);
        int idx = Random.Range(0, _lights.Length);
        foreach (var light in _lights[idx])
        {
            light.enabled = false;
        }
        foreach (var image in _images[idx])
        {
            image.color = Color.black;
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
        foreach (var images in _images)
        {
            foreach (var image in images)
            {
                image.color = Color.white;
            }
        }
    }
}
