using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public AudioClip menuTheme;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayLoop(menuTheme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
