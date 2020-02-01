using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{

    public AudioClip musicTheme;
    public AudioClip stressTheme;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayLoop(musicTheme);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.instance.MusicTransition(musicTheme, stressTheme);
        }


    }
}
