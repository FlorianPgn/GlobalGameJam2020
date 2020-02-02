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
    
    private bool _pumpedLeft;
    private bool _pumpedRight;

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
        _actionType = PossibleActions[Random.Range(0, 6)];
        _repairLevel = 0f;
        IsWorking = false;
    }

    private void Repair(float value)
    {
        _repairLevel = Mathf.Clamp01(_repairLevel + value);
        if (_repairLevel == 1f)
        {
            IsWorking = true;
            Difficulty -= 1;
            if (Difficulty > 0)
            {
                Break();
            }
            if (IsWorking)
            {
                ResetMachine();
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
        if (!IsWorking)
        {
            if (type == ActionType.L && !_pumpedLeft)
            {
                _pumpedLeft = true;
                _pumpedRight = false;
                _actionType = ActionType.R;
                Repair(value / 5);
                return true;
            }
        
            if (type == ActionType.R && !_pumpedRight)
            {
                _pumpedLeft = false;
                _pumpedRight = true;
                _actionType = ActionType.L;
                Repair(value / 5);
                return true;
            }
        
            if (type == _actionType)
            {
                Repair(value);
                return true;
            }
        }
        return false;
    }

    public (bool, bool) GetPumped()
    {
        return (_pumpedLeft, _pumpedRight);
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
