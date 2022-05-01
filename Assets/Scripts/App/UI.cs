using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Game
{
    [Header("Headbar")]
    public Headbar headbar;
    public Timer timer;
    public KeyCount keyCount;
    public KeyOk keyOk;
    [Header("Settings")]
    public Settings settings;
    public STitle sTitle;
    public ControllerOn controllerOn;
    public ControllerSize controllerSize;
    [Header("FinalMenu")]
    public FinalMenu finalMenu;
    public FMTitle fmTitle;
    public YouTime youTime;
    public First first;
    public Second second;
    public Previous previous;
    [Header("Controller")]
    public Controller controller;
    public Levels levels;
    private void Awake()
    {
        app.ui = gameObject.GetComponent<UI>();
    }
    
}
