using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    private Camera main;

    public GameObject player;

    void Start()
    {
        main = Camera.main;
        float y = -main.orthographicSize;
        float width = main.orthographicSize * main.aspect;
        transform.position = new Vector2(0, y);
        CreatePlayer(new Vector2(-width + 2f, -2));
    }

    void CreatePlayer(Vector2 pos)
    {
        player.transform.position = pos;
    }
}
