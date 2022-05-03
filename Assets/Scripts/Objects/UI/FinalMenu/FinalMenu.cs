public class FinalMenu : Game
{
    private void Awake()
    {
        app.ui.finalMenu = gameObject.GetComponent<FinalMenu>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
