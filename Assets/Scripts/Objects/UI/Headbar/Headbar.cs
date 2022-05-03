using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbar : Game
{
    private void Awake()
    {
        app.ui.headbar = gameObject.GetComponent<Headbar>();
    }
    private void Start()
    {
        
    }
}
