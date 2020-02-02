using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : Selectable
{
    public Toggled ToggledObj;
    
    private Animator _animator;
    private bool _toggled;
    public Color SelectColor; 
    private MeshRenderer _meshRenderer;
    private Color _base;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _base = _meshRenderer.material.color;

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
        _meshRenderer.material.color = SelectColor;
    }

    protected override void OnUnselect()
    {
        _meshRenderer.material.color = _base;
    }
}
