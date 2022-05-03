using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOn : Game
{
    private void Awake()
    {
        app.ui.controllerOn = gameObject.GetComponent<ControllerOn>();

    }
    private void Start()
    {
        
    }
}
