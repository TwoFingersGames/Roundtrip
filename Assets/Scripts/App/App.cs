using UnityEngine;

public class Game : MonoBehaviour
{
    // Gives access to the application and all instances.
    public App app { get { return GameObject.FindObjectOfType<App>(); } }
}
public class App : MonoBehaviour
{
    public SaveSerial saveSerial;
    public Data data;
    public Logic logic;
    public Components components;
    public UI ui;
    public ControllerLogic controllerLogic;
    public Scenes scenes;
    public LevelsLogic levelsLogic;
    
    [Header("OBJECTS")]
    public Player player;
    public PlayerOff playerOff;
    public Portal portal;
    public Respawn respawn;
    public Key key;
}
