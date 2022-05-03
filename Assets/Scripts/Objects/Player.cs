using UnityEngine;

public class Player : Game
{
    private float playerScale=0.5f;
    private bool inPortal = false;

    private void Awake()
    {
        app.player = gameObject.GetComponent<Player>();
        app.components.playerRb = gameObject.GetComponent<Rigidbody2D>();
        app.components.playerCol1 = gameObject.GetComponent<CircleCollider2D>();
        app.components.playerCol2 = gameObject.AddComponent<CircleCollider2D>();
        app.components.playerCol2.isTrigger = true;
    }
    //
    //Столкновения 
    //
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Platform") && app.components.playerCol2.IsTouching(col))
        {
            app.data.inside = true;
        }

        else if (col.CompareTag("Die") && app.components.playerCol2.IsTouching(col))
        {
            app.saveSerial.lives-=1;
            Debug.Log("You lose!");

            gameObject.SetActive(false);
            Instantiate(app.playerOff,gameObject.transform.position,gameObject.transform.rotation);

            app.saveSerial.Save();
            Invoke("Loadlevel", 1f);
        }

        else if (col.CompareTag("Key") && app.components.playerCol2.IsTouching(col))
        {
            col.gameObject.SetActive(false);
            app.data.key += 1;
            app.logic.Key();

            if (app.data.key == 3)
            {
                app.ui.keyOk.gameObject.SetActive(true);
                app.logic.PortalOn();
            }
        }

        else if (col.CompareTag("Finish") && app.data.key == 3 && app.components.portalCol1.IsTouching(app.components.playerCol2))
        {
            app.logic.LoadTime();
            app.ui.finalMenu.gameObject.SetActive(true);
            app.logic.SetTitle(app.saveSerial.curentLevel);
            app.logic.SetThisTime(app.data.minuts, app.data.seconds);
        }

        else if (col.CompareTag("Finish") && app.data.key == 3 && app.components.portalCol2.IsTouching(app.components.playerCol2))
        {
            app.data.timerOn = false;
            app.data.timerOff = true;
            inPortal = true;
            app.components.playerRb.gravityScale = 0;
            app.data.leftButton = false;
            app.data.rightButton = false;
            app.data.jumpButton = false;
            app.data.insideButton = false;
            app.ui.controller.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Platform") && app.components.playerCol2.IsTouching(col))
        {
            app.data.inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Platform")&& !app.components.playerCol2.IsTouching(col))
        {
            app.data.inside = false;
        }
    }

    private void Loadlevel()//для Invoke()//задержка для анимации входа в портал
    {
        app.scenes.LoadLevel();
    }
    
    private void FixedUpdate()
    {
        if (playerScale > 0.1f&&inPortal)//анимация
        {
            playerScale -= 0.01f;
            app.player.gameObject.transform.localScale = new Vector3(playerScale, playerScale, gameObject.transform.localScale.z);
        }
    }
}
