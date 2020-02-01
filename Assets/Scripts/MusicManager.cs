using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip mainTheme;
    public AudioClip menuTheme;

    public static MusicManager Instance;

    // Use this for initialization
    void Start () {
        Instance = this;
	}

    public void PlayMainTheme()
    {
        AudioManager.Instance.PlayMusic(mainTheme, 3);
    }

    public void PlayMenuTheme()
    {
        AudioManager.Instance.PlayMusic(menuTheme, 2);
    }
}
