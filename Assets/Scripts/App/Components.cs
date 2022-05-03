using UnityEngine;
using UnityEngine.UI;

public class Components : Game
{
    [Header("PLAYER")]
    public Rigidbody2D playerRb;
    public Collider2D playerCol1;
    public Collider2D playerCol2;
    public Transform playerTr;

    [Header("HEADBAR")]
    public Text keyText;

    [Header("PORTAL")]
    public ParticleSystem portalPS;
    public CircleCollider2D portalCol1;
    public CircleCollider2D portalCol2;
    public PointEffector2D portalPE;
    
    [Header("FINAL MENU")]
    public Text titleFM;
    public Text youTime;
    public Text first;
    public Text second;
    public Text previous;

    [Header("SETTINGS")]
    public Component[] buttons;
    public RectTransform button;
    
    private void Awake()
    {
        app.components = gameObject.GetComponent<Components>();
    }
    

    



}
