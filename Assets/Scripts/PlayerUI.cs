using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image EnergyBar;
    private PlayerInteraction _interaction;
    
    // Start is called before the first frame update
    void Start()
    {
        _interaction = GetComponent<PlayerInteraction>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_interaction.Power);
        EnergyBar.fillAmount = _interaction.Power / _interaction.MaxPower;
    }
}
