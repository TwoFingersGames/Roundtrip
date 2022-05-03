using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : Game
{
    private void Awake()
    {
        app.ui.timer = gameObject.GetComponent<Timer>();
    }
    private void Start()
    {
        
    }
}
