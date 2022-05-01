public class Levels : Game
{
    private void Awake()
    {
        app.ui.levels = gameObject.GetComponent<Levels>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
