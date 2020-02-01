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
    
    public RepairActionSprite[] RepairActionSprites;
    
    public Image RepairAction;
    public Image RepairJauge;

    public void RepairValue(float value)
    {
        value = Mathf.Clamp01(value);
        RepairJauge.fillAmount = value;
        RepairAction.enabled = RepairJauge.enabled = value < 1;
    }

    public void SetRepairAction(ActionType type)
    {
        foreach (var ras in RepairActionSprites)
        {
            if (ras.ActionType == type)
            {
                RepairAction.sprite = ras.ActionSprite;
            }
        }
    }
}
