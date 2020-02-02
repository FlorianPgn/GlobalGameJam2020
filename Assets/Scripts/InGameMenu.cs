using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public Slider Volume;
    public Button ExitMenuBtn;
    public Button ExitGameBtn;
    public bool DisplayMenu;

    private void Start()
    {
        if (SoundManager.instance != null)
        {
            Volume.value = SoundManager.instance.GetVolume();
        }
        MenuPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        DisplayMenu = !DisplayMenu;
        MenuPanel.SetActive(DisplayMenu);
    }

    public void ExitToMenu()
    {
        if (SoundManager.instance != null)
        {
            //SoundManager.instance.PlayMenuTheme();
        }
        SceneManager.LoadScene("Menu");
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }

    public void SetVolume(float value)
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.SetVolume(value);
        }
    }
}
