using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class YouTime : Game
{
    private void Awake()
    {
        app.ui.youTime = gameObject.GetComponent<YouTime>();
        app.components.youTime = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        
    }
}
