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
        _nextRecharge = Time.timeSinceLevelLoad + RechargeRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > _nextRecharge)
        {
            _canRecharge = true;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        PlayerInteraction p = other.GetComponentInParent<PlayerInteraction>();
        if (p != null)
        {
            if (_canRecharge)
            {
                p.Power += 1f;
                _nextRecharge = Time.timeSinceLevelLoad + RechargeRate;
                _canRecharge = false;
            }
        }
    }
}
