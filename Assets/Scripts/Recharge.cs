using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharge : MonoBehaviour
{
    public float RechargeRate = 1f;

    private float _nextRecharge;
    private bool _canRecharge;
    
    // Start is called before the first frame update
    void Start()
    {
        _nextRecharge = Time.time + RechargeRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextRecharge)
        {
            _canRecharge = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerInteraction p = other.GetComponent<PlayerInteraction>();
        if (p != null)
        {
            if (_canRecharge)
            {
                p.Power += 1f;
                _nextRecharge = Time.time + RechargeRate;
                _canRecharge = false;
            }
        }
    }
}
