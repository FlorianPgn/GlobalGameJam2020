using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Machine : Selectable
{
    public Color SelectColor;
    public ActionType[] PossibleRepairs;

    public bool IsWorking => _repairValue == 1f;
    
    private MeshRenderer _meshRenderer;
    private Color _baseColor;

    private float _repairValue = 1f;
    private RepairUI _repairUi;
    private ActionType _actionType;
    
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _baseColor = _meshRenderer.material.color;
        _repairUi = GetComponent<RepairUI>();
    }

    private void Update()
    {
        _repairUi.RepairValue(_repairValue);
    }

    public void Break()
    {
        _actionType = PossibleRepairs[Random.Range(0, PossibleRepairs.Length)];
        _repairUi.SetRepairAction(_actionType);
        _repairValue = 0f;
    }

    private void Repair(float value)
    {
        _repairValue = Mathf.Clamp01(_repairValue + value);
        if (IsWorking)
        {
            ResetMachine();
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
