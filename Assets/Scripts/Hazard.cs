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
    public GameObject Cube;
    
    public float RepairGoal;
    public float RepairPower;
    public int Difficulty = 1;
    
    public Image RepairBar;
    public Image RepairBarFiller;
    public Image AwaitedInput;
    public Sprite[] SpritesInputs;
    
    private String _key;
    private float _repairLevel;
    private bool _isRepairBarShown;
    private bool _isRepaired;

    private Vector2 _joystick;
    private Vector2 _oldJoystick;
    private bool _sRight;
    private bool _sLeft;
    private float _spinCount;
    

    // Start is called before the first frame update
    void Start()
    {
        StartRepair();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateKey()
    {
        _key = "" + (Inputs) Random.Range(0, 6);
        Vector3 hazardPosition = Camera.WorldToScreenPoint(transform.position);
        AwaitedInput.transform.position = new Vector3(hazardPosition.x, hazardPosition.y + 105, hazardPosition.z);
        AwaitedInput.sprite = SpritesInputs[GetKeySprite()];
        Debug.Log("Input needed : " + _key);
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

    private void Repair(String key)
    {
        if (_repairLevel != RepairGoal && _key == key)
        {
            UpdateRepair();
            if (_repairLevel == RepairGoal)
            {
                Difficulty -= 1;
                if (Difficulty != 0)
                {
                    ResetRepair();
                }
                else
                {
                    EndRepair();
                }
            }
        }
    }

    private void StartRepair()
    {
        if (!_isRepairBarShown)
        {
            Cube.GetComponent<MeshRenderer>().material.color = Color.red;
            GenerateKey();
            Vector3 hazardPosition = Camera.WorldToScreenPoint(transform.position);
            RepairBar.transform.position = new Vector3(hazardPosition.x, hazardPosition.y + 60, hazardPosition.z);
            RepairBarFiller.transform.position = new Vector3(hazardPosition.x, hazardPosition.y + 60, hazardPosition.z);
            RepairBar.color = RepairBarFiller.color = new Color(255, 255, 255, 255f);
            RepairBarFiller.fillAmount = 0;
            _isRepairBarShown = true;
        }
    }

    private void UpdateRepair()
    {
        if (!_isRepaired)
        {
            _repairLevel += RepairPower;
            RepairBarFiller.fillAmount = _repairLevel / RepairGoal;
            Debug.Log("Repair Level : " + _repairLevel + "/" + RepairGoal);
        }
    }

    private void ResetRepair()
    {
        GenerateKey();
        _repairLevel = 0;
        RepairBarFiller.fillAmount = 0;
    }

    private void EndRepair()
    {
        _isRepaired = true;
        Cube.GetComponent<MeshRenderer>().material.color = Color.green;
        AwaitedInput.color = RepairBar.color = RepairBarFiller.color = new Color(0, 0, 0, 0);
        _isRepairBarShown = false;
        Debug.Log("Object Repaired !");
    }

    private void OnA()
    {
        //Debug.Log("BUTTON A PRESSED");
        Repair("A");
    }
    
    private void OnB()
    {
        //Debug.Log("BUTTON B PRESSED");
        Repair("B");
    }
    
    private void OnX()
    {
        //Debug.Log("BUTTON X PRESSED");
        Repair("X");
    }
    
    private void OnY()
    {
        //Debug.Log("BUTTON Y PRESSED");
        Repair("Y");
    }

    private void OnJoystick(InputValue value)
    {
        _joystick = (Vector2) value.Get();
        GetSpin();
        _oldJoystick = _joystick;
    }

    private void GetSpin()
    {
        if (_key == "SR")
        {
            //AVOID SPINNING SL
            if (_oldJoystick.x > 0 && _oldJoystick.y > 0 && _joystick.x > _oldJoystick.x && _joystick.y < _oldJoystick.y && !_sRight)
            {
                _spinCount += 0.5f;
                _sLeft = false;
                _sRight = true;
            }
            //AVOID SPINNING SL
            if (_oldJoystick.x < 0 && _oldJoystick.y < 0 && _joystick.x < _oldJoystick.x && _joystick.y > _oldJoystick.y)
            {
                _spinCount += 0.5f;
                _sRight = false;
                _sLeft = true;
            }
        }
        
        if (_key == "SL")
        {
            //AVOID SPINNING SR
            if (_oldJoystick.x < 0 && _oldJoystick.y > 0 && _joystick.x < _oldJoystick.x && _joystick.y < _oldJoystick.y && !_sLeft)
            {
                _spinCount += 0.5f;
                _sRight = false;
                _sLeft = true;
            }
            //AVOID SPINNING SR
            if (_oldJoystick.x > 0 && _oldJoystick.y < 0 && _joystick.x > _oldJoystick.x && _joystick.y > _oldJoystick.y && !_sRight)
            {
                _spinCount += 0.5f;
                _sLeft = false;
                _sRight = true;
            }
        }

        if (_spinCount >= 1)
        {
            _spinCount = 0; Repair(_key);
        }
    }
}
