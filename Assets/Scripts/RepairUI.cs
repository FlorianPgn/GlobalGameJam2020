using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairUI : MonoBehaviour
{
    [System.Serializable]
    public struct RepairActionSprite
    {
        public Sprite ActionSprite;
        public ActionType ActionType;
    }

    private Machine _machine;
    
    public RepairActionSprite[] RepairActionSprites;
    
    public Image RepairAction;
    public Image RepairBar;

    private void Start()
    {
        _machine = GetComponent<Machine>();
    }

    public void Update()
    {
        ShowRepairLevel(_machine.GetRepairLevel());
        CheckPump();
        if (!_machine.IsWorking && RepairAction != null) SetRepairAction(_machine.GetActionType());
        //
    }

    private void ShowRepairLevel(float value)
    {
        value = Mathf.Clamp01(value);
        RepairBar.fillAmount = value;
        RepairAction.enabled = RepairBar.enabled = value < 1;
    }

    private void SetRepairAction(ActionType type)
    {
        foreach (var ras in RepairActionSprites)
        {
            if (ras.ActionType == type)
            {
                RepairAction.sprite = ras.ActionSprite;
            }
        }
    }

    private void CheckPump()
    {
        if (_machine.GetActionType() == ActionType.L || _machine.GetActionType() == ActionType.R)
        {
            SetRepairAction(_machine.GetActionType());
        }
    }
}
