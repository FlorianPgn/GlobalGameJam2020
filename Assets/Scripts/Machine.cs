using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : Selectable
{
    public Color SelectColor;
    
    private MeshRenderer _meshRenderer;
    private Color _baseColor;
    
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _baseColor = _meshRenderer.material.color;
    }


    protected override void OnSelect()
    {
        _meshRenderer.material.color = SelectColor;
    }

    protected override void OnUnselect()
    {
        _meshRenderer.material.color = _baseColor;
    }
}
