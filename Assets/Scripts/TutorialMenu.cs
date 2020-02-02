using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{

    public AudioClip music;
    public AudioClip clickSound;


    void Start()
    {
        SoundManager.instance.PlayLoop(music);
    }


    public void Back()
    {
        SoundManager.instance.PlayStop();
        SoundManager.instance.PlaySingle(clickSound, 1f);
        SceneManager.LoadScene("Menu");
    }

}
