public class KeyOk : Game
{
    
    private void Awake()
    {
        app.ui.keyOk = gameObject.GetComponent<KeyOk>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
