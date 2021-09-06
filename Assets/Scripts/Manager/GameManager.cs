using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<HamsterData> hamsterData;
    public List<FoodData> foodData;
    public int money;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SaveManager.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
