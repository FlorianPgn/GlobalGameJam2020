using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Machine : Selectable
{
    public Color SelectColor;
    public ActionType[] PossibleActions;

    public bool IsWorking = true;
    public int Difficulty = 1;
    
    private MeshRenderer _meshRenderer;
    private Color _baseColor;

    private float _repairLevel = 1f;
    private ActionType _actionType;
    
    private Vector2 _joystick;
    private Vector2 _oldJoystick;
    private bool _sRight;
    private bool _sLeft;
    private float _spinCount;
    
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _baseColor = _meshRenderer.material.color;
        IsWorking = true;
    }

    private void Update()
    {
        
    }

    public float GetRepairLevel()
    {
        return _repairLevel;
    }

    public ActionType GetActionType()
    {
        return _actionType;
    }

    public void Break()
    {
        _actionType = PossibleActions[Random.Range(0, PossibleActions.Length)];
        _repairLevel = 0f;
        IsWorking = false;
    }

    private void Repair(float value)
    {
        _repairLevel = Mathf.Clamp01(_repairLevel + value);
        if (_repairLevel == 1f)
        {
            Difficulty -= 1;
            if (Difficulty > 0)
            {
                Break();
            }
            else
            {
                if (IsWorking)
                {
                    ResetMachine();
                }
            }
        }
    }

    private void ResetMachine()
    {
        
    }
    public override bool ReceiveInput(ActionType type)
    {
        throw new NotImplementedException();
    }
    
    public override bool ReceiveInput(ActionType type, float value)
    {
        Debug.Log(type + " - " + _repairLevel);
        if (_actionType == type && !IsWorking)
        {
            Repair(value);
            return true;
        }

        return false;
    }

    protected override void OnSelect()
    {
        _meshRenderer.material.color = SelectColor;
    }

    protected override void OnUnselect()
    {
        _meshRenderer.material.color = _baseColor;
    }
}
