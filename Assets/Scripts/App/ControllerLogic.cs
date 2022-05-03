using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLogic : Game
{
    private void Awake()
    {
        app.controllerLogic = gameObject.GetComponent<ControllerLogic>();
    }
    public void LeftDown()
    {
        app.data.leftButton = true;
    }
    public void LeftUp()
    {
        app.data.leftButton = false;
    }
    public void RightDown()
    {
        app.data.rightButton = true;
    }
    public void RightUp()
    {
        app.data.rightButton = false;
    }
    public void InsideDown()
    {
        app.data.insideButton = true;
    }
    public void InsideUp()
    {
        app.data.insideButton = false;
    }
    public void JumpDown()
    {
        if (app.data.grounded && !app.data.switchInside)
        {
            app.data._jumpTimer = app.data.jumpTimer;
            app.data._jump = true;
        }


    }

    public void JumpUp()
    {
        app.data._jump = false;
        app.data.jumpButton = false;
    }
    private void FixedUpdate()
    {
        if (app.data._jump)
        {
            if (app.data._jumpTimer > 0)
            {
                app.data.jumpButton = true;
                app.data._jumpTimer -= Time.deltaTime;
            }
            else
            {
                app.data._jump = false;
            }
        }
        else
        {
            app.data.jumpButton = false;
        }

    }
}
