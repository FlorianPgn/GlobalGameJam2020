using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTitle : MonoBehaviour
{

    public AudioClip menuTheme;
    // Start is called before the first frame update
    void Start()
    {
        //SoundManager.instance.PlayLoop(menuTheme);
    }
    
    public void StartGame()
    {
        SoundManager.instance.PlayStop();
        SceneManager.LoadScene("Main");
    }

    public void Play()
    {
        SceneManager.LoadScene("MenuStory");
    }
    
    public void Controls()
    {
        SceneManager.LoadScene("MenuControls");
    }

    public void Credits()
    {
        SceneManager.LoadScene("MenuCredits");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void Back()
    {
        SceneManager.LoadScene("MenuTitle");
    }

}
