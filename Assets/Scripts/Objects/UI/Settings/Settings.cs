using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : Game
{
    private void Awake()
    {
        app.ui.settings = gameObject.GetComponent<Settings>();

    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
