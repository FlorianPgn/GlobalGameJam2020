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
    
    private float _endTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 barPos = Size.transform.position;
        float barWidth = Size.GetComponent<RectTransform>().rect.width;
        float barHeight = Size.GetComponent<RectTransform>().rect.height;
        Debug.Log(barPos);
        Debug.Log(barWidth/ 2);
        StartPos = new Vector3(barPos.x - barWidth / 2, ProgressionBar.GetComponent<RectTransform>().rect.height * 0.80f, 0);
        EndPos = new Vector3(barPos.x + barWidth / 2, ProgressionBar.GetComponent<RectTransform>().rect.height * 0.80f,0);
        DifferencePos = EndPos - StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
 
        float t = (Manager.TimeStart + Time.time) / Manager.totalTimeInSec;
        
        Zeppelin.transform.position = StartPos + DifferencePos * t;
    }
}
