using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSize : Game
{
    private void Awake()
    {
        app.ui.controllerSize = gameObject.GetComponent<ControllerSize>();
    }
    private void Start()
    {
        
    }
}
