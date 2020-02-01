using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Selectable SelectedObject;

    public float RepairStrength = 0.25f;
    public float Power = 10f;

    // Update is called once per frame
    void Start()
    {
        RepairStrength = 0.25f;
        Power = 10f;
    }

    public void SelectObject(ActionType type)
    {
        if (SelectedObject != null)
        {
            if (SelectedObject.ReceiveInput(type, RepairStrength))
            {
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
