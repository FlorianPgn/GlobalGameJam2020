using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    // Start is called before the first frame update
    public void Title()
    {
        SoundManager.instance.PlayStop();
        SceneManager.LoadScene("MenuTitle");
    }
}
