using UnityEngine;
public class Saw : Game
{
    public Transform tr;
    private float angle;
    public float rotationSpeed;

    private void Start()
    {
        tr = gameObject.GetComponent<Rigidbody2D>().transform;
    }

    private void Update()
    {
        angle += rotationSpeed;
        tr.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);

        if (angle >= 360f)
        {
            angle = 0 + (angle % 360f);
        }
    }
}
