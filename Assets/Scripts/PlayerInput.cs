using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum PlayerId {P1, P2}

    public PlayerId Id;

    private PlayerMovement _movement;
    private PlayerInteraction _interaction;
    
    public Vector2 Joystick;
    public Vector2 OldJoystick;
    private bool _sRight;
    private bool _sLeft;
    private float _spinCount;
    private ActionType _spin;
    
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _interaction = GetComponent<PlayerInteraction>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("HorizontalL" + Id);
        float v = Input.GetAxisRaw("VerticalL" + Id);
        _movement.Move(h, v);
        
        if (Input.GetButtonDown("A"+Id))
        {
            _interaction.OnA();
            Debug.Log("A");
        }
        if (Input.GetButtonDown("B"+Id))
        {
            _interaction.OnB();
            Debug.Log("B");
        }
        if (Input.GetButtonDown("X"+Id))
        {
            _interaction.OnX();
            Debug.Log("X");
        }
        if (Input.GetButtonDown("Y"+Id))
        {
            _interaction.OnY();
            Debug.Log("Y");
        }
        if (Input.GetAxisRaw("L"+Id) > 0.9 && Input.GetAxisRaw("R"+Id) < 0.2)
        {
            _interaction.OnL();
            Debug.Log("L");
        }
        if (Input.GetAxisRaw("R"+Id) > 0.9 && Input.GetAxisRaw("L"+Id) < 0.2)
        {
            _interaction.OnR();
            Debug.Log("R");
        }
        
        if (Math.Abs(Input.GetAxisRaw("HorizontalR" + Id)) > 0.8 || Math.Abs(Input.GetAxisRaw("VerticalR" + Id)) > 0.8)
        {
            Joystick = new Vector2(Input.GetAxisRaw("HorizontalR" + Id), Input.GetAxisRaw("VerticalR" + Id));
            (bool isSpin, ActionType actionType) = GetSpin();
            if (isSpin)
            {
                if (actionType == ActionType.LS) _interaction.OnLS();
                if (actionType == ActionType.RS) _interaction.OnRS();
            }
            OldJoystick = Joystick;
        }
    }
    
    private (bool, ActionType) GetSpin()
    {
        ActionType actionType = ActionType.A;
        //Debug.Log(Joystick);
        //AVOID SPINNING SL
        if (OldJoystick.x > 0.4 && OldJoystick.y > 0.4 && Joystick.x > OldJoystick.x && Joystick.y < OldJoystick.y && !_sRight)
        {
            _spinCount += 0.5f;
            _sLeft = false;
            _sRight = true;
            if (_spinCount >= 1)
            {
                _spinCount = 0;
                return (true, ActionType.RS);
            }
        }
        //AVOID SPINNING SL
        if (OldJoystick.x < -0.4 && OldJoystick.y < -0.4 && Joystick.x < OldJoystick.x && Joystick.y > OldJoystick.y)
        {
            _spinCount += 0.5f;
            _sRight = false;
            _sLeft = true;
            if (_spinCount >= 1)
            {
                _spinCount = 0;
                return (true, ActionType.RS);
            }
        }
        
        //AVOID SPINNING SR
        if (OldJoystick.x < -0.4 && OldJoystick.y > 0.4 && Joystick.x < OldJoystick.x && Joystick.y < OldJoystick.y && !_sLeft)
        {
            _spinCount += 0.5f;
            _sRight = false;
            _sLeft = true;
            if (_spinCount >= 1)
            {
                _spinCount = 0;
                return (true, ActionType.LS);
            }
        }
        //AVOID SPINNING SR
        if (OldJoystick.x > 0.4 && OldJoystick.y < -0.4 && Joystick.x > OldJoystick.x && Joystick.y > OldJoystick.y && !_sRight)
        {
            _spinCount += 0.5f;
            _sLeft = false;
            _sRight = true;
            if (_spinCount >= 1)
            {
                _spinCount = 0;
                return (true, ActionType.LS);
            }
        }
        
        return (false, actionType);
    }
}
