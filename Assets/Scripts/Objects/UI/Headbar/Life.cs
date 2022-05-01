using UnityEngine.UI;

public class Life : Game
{
    private void Start()
    {
        gameObject.GetComponent<Text>().text = "x "+app.saveSerial.lives + " ";
    }
}
