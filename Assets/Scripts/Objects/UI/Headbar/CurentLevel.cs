using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CurentLevel : Game
{
    private void SetLevel()
    {
        int level = app.saveSerial.curentLevel+1;
        gameObject.GetComponent<Text>().text = "Level: " + level;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
