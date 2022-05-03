using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Game
{
    private void Awake()
    {
        app.ui.controller = gameObject.GetComponent<Controller>();
        app.components.buttons = gameObject.GetComponentsInChildren<RectTransform>();
    }
    private void Start()
    {
        
    }
}
