using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public void Top()
    {
        if (player.transform.position.y < 0)
        {
            player.transform.position += new Vector3(0, 2, 0);
        }
    }

    public void Bottom()
    {
        if (player.transform.position.y > -4)
        {
            player.transform.position += new Vector3(0, -2, 0);
        }
    }
}
