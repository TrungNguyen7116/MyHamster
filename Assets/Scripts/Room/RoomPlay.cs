using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlay : MonoBehaviour
{
    public GameObject hamster;

    public static RoomPlay instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        
    }
    public void Initialize()
    {
        float x = Random.Range(-2f, 2f);
        float y = Random.Range(-2.5f, -5f);
        for (int i = 0; i < GameManager.instance.hamsterData.Count; i++)
        {
            GameObject newHamster = Instantiate(hamster, new Vector2(x, y), Quaternion.identity);
            newHamster.GetComponent<Hamster>().SetData(GameManager.instance.hamsterData[i]);    
        }
    }
}
