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

    public Machine Machine;
    
    public RepairActionSprite[] RepairActionSprites;
    
    public Image RepairAction;
    public Image RepairBar;

    public void Update()
    {
        ShowRepairLevel(Machine.GetRepairLevel());
        if (!Machine.IsWorking && RepairAction != null) SetRepairAction(Machine.GetActionType());
        CheckPump();
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
        if (Machine.GetActionType() == ActionType.L || Machine.GetActionType() == ActionType.R)
        {
            SetRepairAction(Machine.GetActionType());
        }
    }
}
