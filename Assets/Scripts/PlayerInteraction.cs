using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Collider SelectCollider;
    public Selectable SelectedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Selectable selectable = other.GetComponent<Selectable>();
        if (selectable != null)
        {
            SelectedObject = selectable;
            selectable.IsSelected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
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
