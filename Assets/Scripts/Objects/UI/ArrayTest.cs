using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ArrayTest : Game
{
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = gameObject.GetComponentsInChildren<Text>();
        texts[0].text = "1:" + app.saveSerial.first[1, 0] + "-" + app.saveSerial.first[0, 0];
        texts[1].text = "2:" + app.saveSerial.first[1, 1] + "-" + app.saveSerial.first[0, 1];
        texts[2].text = "3:" + app.saveSerial.first[1, 2] + "-" + app.saveSerial.first[0, 2];
        texts[3].text = "4:" + app.saveSerial.first[1, 3] + "-" + app.saveSerial.first[0, 3];
        texts[4].text = "5:" + app.saveSerial.first[1, 4] + "-" + app.saveSerial.first[0, 4];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
