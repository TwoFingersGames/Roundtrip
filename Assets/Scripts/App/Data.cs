using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : Game
{
    private void Awake()
    {
        app.data = gameObject.GetComponent<Data>();
    }
    
    public float gravity = -9.81f * 3f;
    [Header("SceneManager")]
    public int maxLevel = 1;
    
    public int selectLevel;
    [Header("Player")]
    public float playerSpeed;
    public float playerJump;
    public bool inside = false;
    public bool switchInside;
    [Header("RayGround")]
    public float distance;
    public bool grounded;
    [Header("UI")]
    public int key;
    public bool controllerOn = true;
    [Header("Timer")]
    public float timer;
    public string seconds;
    public float minuts;
    public bool timerOn;
    public bool timerOff;

    [Header("Controller Logic")]
    public bool leftButton;
    public bool rightButton;
    public bool insideButton;
    public bool jumpButton;
    public bool _jump;
    public float jumpTimer;
    public float _jumpTimer;
    [Header("Settings")]
    public float buttonsSize;

}
