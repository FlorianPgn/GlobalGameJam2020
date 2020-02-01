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

    private int _pumpLeft;
    private int _pumpRight;
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
        _actionType = PossibleActions[Random.Range(5, 6)];
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
        if (type == ActionType.L || type == ActionType.R)
        {
            
            if (_pumpLeft == 10 && _pumpRight == 10)
            {
                Repair(value);
                return true;
            }

            switch (type)
            {
                case ActionType.L when _pumpedRight:
                    Debug.Log("OUI");
                    _pumpLeft += 1;
                    _pumpedLeft = true;
                    _pumpedRight = false;
                    _actionType = ActionType.R;
                    break;
                case ActionType.R when _pumpedLeft:
                    Debug.Log("NON");
                    _pumpRight += 1;
                    _pumpedLeft = false;
                    _pumpedRight = true;
                    _actionType = ActionType.L;
                    break;
            }
        }
        else 
        { 
            if (_actionType == type && !IsWorking)
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
