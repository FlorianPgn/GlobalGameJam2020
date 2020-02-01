using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Hazard : MonoBehaviour
{
    //SR = SPIN RIGHT | SL = SPIN LEFT
    enum Inputs {A, B, X, Y, SR, SL}

    public Camera Camera;
    public InputsController Controls;
    public float RepairGoal;
    public float RepairPower;
    public Image RepairBar;
    public Image RepairBarFiller;
    public Image AwaitedInput;
    public Sprite[] SpritesInputs;
    public Color Color;

    public Vector2 Joystick;
    public Vector2 OldJoystick;
    
    private String _key;
    private float _repairLevel;
    private bool _isRepaired;
    private bool _isRepairBarShown;

    private bool _sRight;
    private bool _sLeft;
    private float _spinCount;
    

    // Start is called before the first frame update
    void Start()
    {
        GenerateKey();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateKey()
    {
        _key = "" + (Inputs) Random.Range(0, 6);
        Debug.Log("Input needed : " + _key);
        Vector3 hazardPosition = Camera.WorldToScreenPoint(transform.position);
        AwaitedInput.transform.position = new Vector3(hazardPosition.x, hazardPosition.y + 110, hazardPosition.z);
        AwaitedInput.sprite = SpritesInputs[GetKeySprite()];
    }

    private int GetKeySprite()
    {
        switch (_key)
        {
            case "A": return 0;
            case "B": return 1;
            case "X": return 2;
            case "Y": return 3;
            case "SR":
                _sRight = false;
                _sLeft = true;
                return 4;
            case "SL":
                _sLeft = false;
                _sRight = true;
                return 5;
        }
        return 0;
    }

    private void Repair(String key, float repairPower)
    {
        if (_repairLevel != RepairGoal && _key == key)
        {
            _repairLevel += repairPower;
            UpdateRepairBar();
            Debug.Log("Repair Level : " + _repairLevel + "/" + RepairGoal);
            if (_repairLevel == RepairGoal)
            {
                _isRepaired = true;
                _isRepairBarShown = false;
                Debug.Log("Object Repaired !");
            }
        }
    }

    private void UpdateRepairBar()
    {
        if (!_isRepaired)
        {
            if (!_isRepairBarShown)
            {
                Vector3 hazardPosition = Camera.WorldToScreenPoint(transform.position);
                RepairBar.transform.position = new Vector3(hazardPosition.x, hazardPosition.y + 60, hazardPosition.z);
                RepairBarFiller.transform.position = new Vector3(hazardPosition.x, hazardPosition.y + 60, hazardPosition.z);
                RepairBar.color = Color;
                RepairBarFiller.color = Color;
                RepairBarFiller.fillAmount = 0;
                _isRepairBarShown = true;
            }
            RepairBarFiller.fillAmount = _repairLevel / RepairGoal;
        }
    }

    private void OnA()
    {
        //Debug.Log("BUTTON A PRESSED");
        Repair("A", RepairPower);
    }
    
    private void OnB()
    {
        //Debug.Log("BUTTON B PRESSED");
        Repair("B", RepairPower);
    }
    
    private void OnX()
    {
        //Debug.Log("BUTTON X PRESSED");
        Repair("X", RepairPower);
    }
    
    private void OnY()
    {
        //Debug.Log("BUTTON Y PRESSED");
        Repair("Y", RepairPower);
    }

    private void OnJoystick(InputValue value)
    {
        Joystick = (Vector2) value.Get();
        GetSpin();
        OldJoystick = Joystick;
    }

    private void GetSpin()
    {
        if (_key == "SR")
        {
            //AVOID SPINNING SL
            if (OldJoystick.x > 0 && OldJoystick.y > 0 && Joystick.x > OldJoystick.x && Joystick.y < OldJoystick.y && !_sRight)
            {
                _spinCount += 0.5f;
                _sLeft = false;
                _sRight = true;
            }
            //AVOID SPINNING SL
            if (OldJoystick.x < 0 && OldJoystick.y < 0 && Joystick.x < OldJoystick.x && Joystick.y > OldJoystick.y)
            {
                _spinCount += 0.5f;
                _sRight = false;
                _sLeft = true;
            }
        }
        
        if (_key == "SL")
        {
            //AVOID SPINNING SR
            if (OldJoystick.x < 0 && OldJoystick.y > 0 && Joystick.x < OldJoystick.x && Joystick.y < OldJoystick.y && !_sLeft)
            {
                _spinCount += 0.5f;
                _sRight = false;
                _sLeft = true;
            }
            //AVOID SPINNING SR
            if (OldJoystick.x > 0 && OldJoystick.y < 0 && Joystick.x > OldJoystick.x && Joystick.y > OldJoystick.y && !_sRight)
            {
                _spinCount += 0.5f;
                _sLeft = false;
                _sRight = true;
            }
        }

        if (_spinCount >= 1)
        {
            _spinCount = 0; Repair(_key, RepairPower);
        }
    }
}
