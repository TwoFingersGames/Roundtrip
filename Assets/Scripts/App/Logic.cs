using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Logic : Game   //Необходимо разграничить логику когда-нибудь! Пока так)
{
    private void Awake()
    {
        app.logic = gameObject.GetComponent<Logic>();
    }
    private void Start()
    {
        SetTimerTime(app.ui.timer.gameObject, app.data.minuts, app.data.seconds);
    }

    private void RayGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(app.components.playerRb.transform.position, Vector2.down, app.data.distance, 1);

        if (hit.collider != null)
        {
            app.data.grounded = true;
        }

        else
        {
            app.data.grounded = false;
        }
    }
    
    //
    //MOVE
    //
    private void Run()
    {
        if (app.data.leftButton)
        {
            app.components.playerRb.velocity = new Vector2(-app.data.playerSpeed, app.components.playerRb.velocity.y);
        }

        else if (app.data.rightButton)
        {
            app.components.playerRb.velocity = new Vector2(app.data.playerSpeed, app.components.playerRb.velocity.y);
        }

        else
        {
            app.components.playerRb.velocity = new Vector2(0, app.components.playerRb.velocity.y);
        }
    }
    private void Jump()
    {
        if (app.data.jumpButton)
        {
            app.components.playerRb.velocity = new Vector2(app.components.playerRb.velocity.x, app.data.playerJump);
        }
    }

    //HEADBAR
    public void Key()
    {
        app.components.keyText.text = app.data.key + " - 3";
    }

    public void PortalOn()
    {
        app.components.portalPS.Play(true);
        app.components.portalPE.enabled = true;
    }

    //TIMER
    public void Timer()
    {
        if (!app.data.timerOn && !app.data.timerOff)
        {
            if (app.data.leftButton || app.data.rightButton || app.data.insideButton || app.data.jumpButton)
            {
                app.data.timerOn = true;
            }
        }

        else if (app.data.timerOn)
        {
            app.data.timer += Time.smoothDeltaTime;
            app.data.seconds = app.data.timer.ToString("f2");

            if (app.data.timer >= 60f)
            {
                app.data.timer = 0;
                ++app.data.minuts;
            }
        }

        SetTimerTime(app.ui.timer.gameObject, app.data.minuts, app.data.seconds);
    }
    private void SetTimerTime(GameObject @object, float mValue, string sValue)
    {
        if (mValue / 10f < 1f && sValue.Length >= 5)
        {
            @object.GetComponent<Text>().text = "0" + mValue + "." + sValue;
        }

        else if (mValue / 10f >= 1f && sValue.Length < 5)
        {
            @object.GetComponent<Text>().text = mValue + ".0" + sValue;
        }

        else if (mValue / 10f < 1f && sValue.Length < 3)
        {
            @object.GetComponent<Text>().text = "0" + mValue + ".00.00" + sValue;
        }

        else if (mValue / 10f < 1f && sValue.Length < 5)
        {
            @object.GetComponent<Text>().text = "0" + mValue + ".0" + sValue;
        }
        
        else
        {
            @object.GetComponent<Text>().text = mValue + "." + sValue;
        }
    }
    //FINAL MENU ON/Off


    //FINAL MENU BUTTONS
    public void Menu()
    {
        app.saveSerial.last[0, app.saveSerial.curentLevel] = app.data.minuts;
        app.saveSerial.last[1, app.saveSerial.curentLevel] = app.data.timer;
        app.saveSerial.Save();
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Replay()
    {
        app.saveSerial.last[0, app.saveSerial.curentLevel] = app.data.minuts;
        app.saveSerial.last[1, app.saveSerial.curentLevel] = app.data.timer;
        app.saveSerial.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Next()
    {
        app.saveSerial.last[0, app.saveSerial.curentLevel] = app.data.minuts;
        app.saveSerial.last[1, app.saveSerial.curentLevel] = app.data.timer;
        ++app.saveSerial.curentLevel;
        app.saveSerial.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    //FINAL MENU FUNC
    public void SetTitle(int x)
    {
        x++;
        app.components.titleFM.text = "Level " + x + " - Completed!";
    }
    public void SetThisTime(float mValue, string sValue)
    {
        if (mValue / 10f < 1f && sValue.Length >= 5)
        {
            app.components.youTime.text = "You time:\n0" + mValue + "." + sValue;
        }

        else if (mValue / 10f >= 1f && sValue.Length < 5)
        {
            app.components.youTime.text = "You time:\n" + mValue + ".0" + sValue;
        }

        else if (mValue / 10f < 1f && sValue.Length < 5)
        {
            app.components.youTime.text = "You time:\n0" + mValue + ".0" + sValue;
        }

        else
        {
            app.components.youTime.text = "You time:\n" + mValue + "." + sValue;
        }
    }
    private void SetTime(GameObject @object, float mValue, string sValue)
    {
        if (mValue / 10f < 1f && sValue.Length >= 5)
        {
            @object.GetComponent<Text>().text = @object.name + ":0" + mValue + "." + sValue;
        }

        else if (mValue / 10f >= 1f && sValue.Length < 5)
        {
            @object.GetComponent<Text>().text = @object.name + ":" + mValue + ".0" + sValue;
        }

        else if (mValue / 10f < 1f && sValue.Length < 5)
        {
            @object.GetComponent<Text>().text = @object.name + ":0" + mValue + ".0" + sValue;
        }

        else
        {
            @object.GetComponent<Text>().text = @object.name + ":" + mValue + "." + sValue;
        }
    }
    private void SortTime()
    {
        if (app.saveSerial.first[0, app.saveSerial.curentLevel] == 0 && app.saveSerial.first[1, app.saveSerial.curentLevel] == 0)
        {
            app.saveSerial.first[0, app.saveSerial.curentLevel] = app.data.minuts;
            app.saveSerial.first[1, app.saveSerial.curentLevel] = app.data.timer;
        }

        else if (app.data.minuts <= app.saveSerial.first[0, app.saveSerial.curentLevel] && app.data.timer < app.saveSerial.first[1, app.saveSerial.curentLevel])
        {
            app.saveSerial.second[0, app.saveSerial.curentLevel] = app.saveSerial.first[0, app.saveSerial.curentLevel];
            app.saveSerial.second[1, app.saveSerial.curentLevel] = app.saveSerial.first[1, app.saveSerial.curentLevel];
            app.saveSerial.first[0, app.saveSerial.curentLevel] = app.data.minuts;
            app.saveSerial.first[1, app.saveSerial.curentLevel] = app.data.timer;
        }

        else if (app.data.minuts >= app.saveSerial.first[0, app.saveSerial.curentLevel])
        {
            if (app.data.timer > app.saveSerial.first[1, app.saveSerial.curentLevel])
            {
                if (app.saveSerial.second[0, app.saveSerial.curentLevel] == 0 && app.saveSerial.second[1, app.saveSerial.curentLevel] == 0 || app.data.minuts <= app.saveSerial.second[0, app.saveSerial.curentLevel] && app.data.timer < app.saveSerial.second[1, app.saveSerial.curentLevel])
                {
                    app.saveSerial.second[0, app.saveSerial.curentLevel] = app.data.minuts;
                    app.saveSerial.second[1, app.saveSerial.curentLevel] = app.data.timer;
                }

            }

        }
    }
    public void LoadTime()
    {
        SortTime();
        SetTime(app.ui.first.gameObject, app.saveSerial.first[0, app.saveSerial.curentLevel], app.saveSerial.first[1, app.saveSerial.curentLevel].ToString("f2"));
        SetTime(app.ui.second.gameObject, app.saveSerial.second[0, app.saveSerial.curentLevel], app.saveSerial.second[1, app.saveSerial.curentLevel].ToString("f2"));
        SetTime(app.ui.previous.gameObject, app.saveSerial.last[0, app.saveSerial.curentLevel], app.saveSerial.last[1, app.saveSerial.curentLevel].ToString("f2"));
        app.saveSerial.Save();
    }
    //
    //SETTINGS
    //
    public void SetOnScreenButtons(bool value)
    {
        app.ui.controller.gameObject.SetActive(value);
        app.saveSerial.buttonActive = value;
    }

    public void SetScreenButtonsSize(float value)
    {
        app.data.buttonsSize = 100f + (150f * value);
        foreach (RectTransform button in app.components.buttons)
            button.sizeDelta = new Vector2(app.data.buttonsSize, app.data.buttonsSize);
        app.saveSerial.buttonSize = value;
    }

    public void SettingsOpen()
    {
        app.ui.settings.gameObject.SetActive(true);
    }

    public void SettingsClose()
    {
        app.ui.settings.gameObject.SetActive(false);
    }

    public void OkButton()
    {
        app.saveSerial.Save();
        SettingsClose();
    }

    //
    //CONTROLLER
    //
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

    private void JumpTimer()
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
    public void LevelsOpen()
    {
        app.ui.levels.gameObject.SetActive(true);
    }

    public void LevelsClose()
    {
        app.ui.levels.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (app.player != null)
        {
            Timer();
            Run();
            Jump();
            RayGround();
            JumpTimer();

            if (app.data.insideButton && app.data.inside)
            {
                app.data.switchInside = true;
                app.components.playerCol1.enabled = false;
                app.components.playerRb.AddForce(Vector2.down * app.data.gravity * 2F, ForceMode2D.Force);
            }

            else if (app.data.switchInside && app.data.inside)
            {
                app.components.playerCol1.enabled = false;
                app.components.playerRb.AddForce(Vector2.down * app.data.gravity * 2F, ForceMode2D.Force);
            }

            else
            {
                app.components.playerCol1.enabled = true;
                app.data.switchInside = false;
            }

        }
        
    }

}
