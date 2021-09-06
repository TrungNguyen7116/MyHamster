using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScale : MonoBehaviour
{
    private Camera main;

    public GameObject wallLeft;

    public GameObject wallRight;
    void Start()
    {
        main = Camera.main;
        float y = -main.orthographicSize;
        float width = main.orthographicSize * main.aspect;
        transform.position = new Vector2(0, y);
        wallLeft.transform.position = new Vector2(-width - 1, 0);
        wallRight.transform.position = new Vector2(width + 1, 0);
    }
}
