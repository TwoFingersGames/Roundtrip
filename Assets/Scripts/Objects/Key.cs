using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Key : Game
{
    private void Start()
    {
        app.key = gameObject.GetComponent<Key>();
    }
}
