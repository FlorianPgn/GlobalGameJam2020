using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ProgessionController : MonoBehaviour
{

    public Image Zeppelin;
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
        StartPos = Zeppelin.transform.position;
        Debug.Log(Size.GetComponent<RectTransform>().rect.width);
        EndPos = new Vector3(Size.GetComponent<RectTransform>().rect.width - Zeppelin.GetComponent<RectTransform>().rect.width, Zeppelin.transform.position.y, Zeppelin.transform.position.z);
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
