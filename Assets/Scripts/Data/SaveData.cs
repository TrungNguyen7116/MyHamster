using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<HamsterData> hamsterData = GameManager.instance.hamsterData;
    public List<FoodData> foodData = GameManager.instance.foodData;
    public int money = GameManager.instance.money;
}
