using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum PlayerId {P1, P2}

    public PlayerId Id;

    private PlayerMovement _movement;
    private PlayerInteraction _interaction;
    
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _interaction = GetComponent<PlayerInteraction>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal" + Id);
        float v = Input.GetAxisRaw("Vertical" + Id);
        _movement.Move(h, v);
        
        if (Input.GetButtonDown("Fire1"+Id))
        {
            _interaction.OnA();
            Debug.Log("A");
        }
        if (Input.GetButtonDown("Fire2"+Id))
        {
            _interaction.OnB();
            Debug.Log("B");
        }
        if (Input.GetButtonDown("Fire3"+Id))
        {
            _interaction.OnX();
            Debug.Log("X");
        }
        if (Input.GetButtonDown("Fire4"+Id))
        {
            _interaction.OnY();
            Debug.Log("Y");
        }    
    }
}
