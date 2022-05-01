using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class First : Game
{
    private void Awake()
    {
        app.ui.first = gameObject.GetComponent<First>();
        app.components.first = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        
        
    }
}
