using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STitle : Game
{
    private void Awake()
    {
        app.ui.sTitle = gameObject.GetComponent<STitle>();
    }
    private void Start()
    {
        
    }
}
