using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FMTitle : Game
{
    private void Awake()
    {
        app.ui.fmTitle = gameObject.GetComponent<FMTitle>();
        app.components.titleFM = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        
    }
}
