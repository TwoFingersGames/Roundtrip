using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyCount : Game
{
    private void Awake()
    {
        app.ui.keyCount = gameObject.GetComponent<KeyCount>();
        app.components.keyText = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        
    }
}
