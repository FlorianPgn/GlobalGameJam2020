using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{

    public AudioClip drillSound;
    public AudioClip drillSoundEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            // SoundManager.instance.Randomizefx(drillSound);

        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // SoundManager.instance.Randomizefx(drillSoundEnd);
        }
        
    }


}
