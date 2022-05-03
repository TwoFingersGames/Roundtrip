using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Previous : Game
{
    private void Awake()
    {
        app.ui.previous = gameObject.GetComponent<Previous>();
        app.components.previous = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        
    }
}
