using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Second : Game
{
    private void Awake()
    {
        app.ui.second = gameObject.GetComponent<Second>();
        app.components.second = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        
    }
}
