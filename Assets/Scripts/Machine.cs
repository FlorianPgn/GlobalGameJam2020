using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Machine : Selectable
{
    public SoundEffect.Type[] Types;
    
    public Color SelectColor;
    public ActionType[] PossibleActions = {ActionType.A, ActionType.B, ActionType.L, ActionType.X, ActionType.Y, ActionType.R, ActionType.LS, ActionType.RS};

    public bool IsWorking = true;
    public int Difficulty = 1;

    public Clip BreakClip;
    public Clip RepairClip;
    
    public MeshRenderer MeshRenderer;
    private Color _baseColor;
    private float _repairLevel = 1f;    
    private ActionType _actionType;
    public Animator MachineAnimator;
    
    private bool _pumpedLeft;
    private bool _pumpedRight;

    // Start is called before the first frame update
    void Start()
    {
        if (MeshRenderer == null)
        {
            MeshRenderer = GetComponent<MeshRenderer>();        
        }
        
        if (MeshRenderer != null)
        {
            _baseColor = MeshRenderer.material.color;        
        }
        IsWorking = true;
        if(MachineAnimator == null)
            MachineAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(MachineAnimator != null)
            MachineAnimator.SetBool("Broken", !IsWorking);
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
        if (BreakClip.Audio == null)
        {
            SoundManager.instance.Randomizefx(SoundEffect.Instance.GetTypeSounds(SoundEffect.Type.BREAK));
        }
        else
        {
            SoundManager.instance.PlaySingle(BreakClip.Audio, BreakClip.Volume);
        }
    }

    private void Repair(float value)
    {
        _repairLevel = Mathf.Clamp01(_repairLevel + value);
        Debug.Log("Repair", gameObject);
        SoundManager.instance.Randomizefx(SoundEffect.Instance.GetTypeSounds(Types));
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
        if (RepairClip.Audio == null)
        {
            SoundManager.instance.Randomizefx(SoundEffect.Instance.GetTypeSounds(SoundEffect.Type.SUCCESS));
        }
        else
        {
            SoundManager.instance.PlaySingle(RepairClip.Audio, RepairClip.Volume);
        }
    }
    
    public override bool ReceiveInput(ActionType type)
    {
        throw new NotImplementedException();
    }
    
    public override bool ReceiveInput(ActionType type, float value)
    {
        if (!IsWorking && type == _actionType)
        {
            if (type == ActionType.L && !_pumpedLeft)
            {
                _pumpedLeft = true;
                _pumpedRight = false;
                _actionType = ActionType.R;
                Repair(value / 2f);
                return true;
            }
        
            if (type == ActionType.R && !_pumpedRight)
            {
                _pumpedLeft = false;
                _pumpedRight = true;
                _actionType = ActionType.L;
                Repair(value / 2f);
                return true;
            }
            else
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
        if (MeshRenderer != null)
        {
            MeshRenderer.material.color = SelectColor;
        }
    }

    protected override void OnUnselect()
    {
        if (MeshRenderer != null)
        {
            MeshRenderer.material.color = _baseColor;
        }
    }
}
