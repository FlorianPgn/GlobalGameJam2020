using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ProgessionController : MonoBehaviour
{

    public Image Zeppelin;
    public Image ProgressionBar;
    public Vector3 StartPos;
    public Vector3 DifferencePos;
    public Vector3 EndPos;
    public float Timer;
    public float TripDuration = 30f;
    public GameObject Size;
    public GameManager Manager;
    public Transform End;
    private float _endTime;

    public AudioClip clip;

    private bool _musicPlayed;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 barPos = Size.transform.position;
        float barWidth = Size.GetComponent<RectTransform>().rect.width;
        float barHeight = Size.GetComponent<RectTransform>().rect.height;
        Debug.Log(barPos);
        Debug.Log(barWidth/ 2);
        StartPos = Zeppelin.transform.position;
        EndPos = StartPos + Vector3.right * barWidth;
        EndPos = End.position;
        DifferencePos = EndPos - StartPos;
    }

    // Update is called once per frame
    void Update()
    {
 
        float t = (Manager.TimeStart + Time.time) / 3f;
        //Debug.Log(t);
        Zeppelin.transform.position = Vector3.Lerp(StartPos, StartPos + DifferencePos, t);
        if (t > 0.6f && !_musicPlayed)
        {
            SoundManager.instance.MusicTransition(null, clip);
            _musicPlayed = true;
        }
    }
}
