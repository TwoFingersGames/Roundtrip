public class LevelsLogic : Game
{
    private void Awake()
    {
        app.levelsLogic = gameObject.GetComponent<LevelsLogic>();
    }
}
