using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : Game
{
    private void Start()
    {
        app.respawn = gameObject.GetComponent<Respawn>();
    }
}
