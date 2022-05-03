using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector3 offset = new Vector3(2f, 1f, 1f);
    public bool isLeft;
    public Transform player;
    private int lastX;

    void Start()
    {
        offset = new Vector3(Mathf.Abs(offset.x), offset.y, offset.z);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);

        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
        }
    }

    private void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);

            if (currentX > lastX)
            {
                isLeft = false;
            }

            else if (currentX < lastX)
            {
                isLeft = true;
            }

            lastX = Mathf.RoundToInt(player.position.x);
            Vector3 target;

            if (isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }

            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
