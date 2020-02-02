using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : Selectable
{
    public Toggled ToggledObj;
    
    private Animator _animator;
    private bool _toggled;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public override bool ReceiveInput(ActionType type)
    {
        throw new System.NotImplementedException();
    }

    public override bool ReceiveInput(ActionType type, float value)
    {
        ToggledObj.Toggle();
        _animator.SetBool("Toggle", _toggled);
        _toggled = !_toggled;
        return false;
    }

    protected override void OnSelect()
    {
        
    }

    protected override void OnUnselect()
    {
        
    }
}
