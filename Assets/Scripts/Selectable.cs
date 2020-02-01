﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            if (_isSelected)
            {
                OnSelect();
            }
            else
            {
                OnUnselect();
            }
        }
    }

    public abstract bool ReceiveInput(ActionType type);

    public abstract bool ReceiveInput(ActionType type, float value);
    
    protected abstract void OnSelect();
    protected abstract void OnUnselect();
}
