using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundManager : MonoBehaviour
{

    public AudioClip music;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayLoop(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
