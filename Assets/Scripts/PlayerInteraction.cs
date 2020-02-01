﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Selectable SelectedObject;

    public float RepairStrength = 0.25f;
    public float MaxPower = 10f;
    public float Power
    {
        get => _power;
        set => _power = Mathf.Clamp(value, 0, MaxPower);
    }
    private float _power = 10f;

    // Update is called once per frame
    void Start()
    {
        RepairStrength = 0.25f;
        _power = 10f;
    }

    private void SelectObject(ActionType type)
    {
        if (SelectedObject != null)
        {
            if (SelectedObject.ReceiveInput(type, RepairStrength * (_power/10f)))
            {
                Debug.Log(RepairStrength +" "+ _power);
                Power -= RepairStrength;
            }
        }
    }
    
    public void OnA()
    {
        SelectObject(ActionType.A);
    }

    public void OnB()
    {
        SelectObject(ActionType.B);
    }

    public void OnX()
    {
        SelectObject(ActionType.X);
    }

    public void OnY()
    {
        SelectObject(ActionType.Y);
    }

    public void OnLS()
    {
        SelectObject(ActionType.LS);
    }
    
    public void OnRS()
    {
        SelectObject(ActionType.RS);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Enter");
        Selectable selectable = other.GetComponent<Selectable>();
        if (selectable != null)
        {
            SelectedObject = selectable;
            selectable.IsSelected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("Exit");
        Selectable selectable = other.GetComponent<Selectable>();
        if (selectable != null)
        {
            if (selectable == SelectedObject)
            {
                selectable.IsSelected = false;
                SelectedObject = null;
            }
        }
    }
}
