using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioClip menuTheme;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayLoop(menuTheme);
    }

    public void Play()
    {
        SoundManager.instance.PlayStop();
        SceneManager.LoadScene("Main");
    }

    public void Tutorial()
    {
        SoundManager.instance.PlayStop();
        SceneManager.LoadScene("Tutorial");
    }

    public void Credits()
    {
        SoundManager.instance.PlayStop();
        SceneManager.LoadScene("Credits");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
