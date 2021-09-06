using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotShop : MonoBehaviour
{
    private FoodData data;

    //UI
    public Image avatar;
    public Text name;
    public Text price;
    public Text exp;
    public Text energy;


    public void SetData(FoodData data)
    {
        this.data = data;
        Initialize();
    }
    public void Initialize()
    {
        avatar.sprite = Resources.Load<Sprite>("Food/" + data.name);
        name.text = data.name;
        price.text = data.price + "$";
        exp.text = "Exp: +" + data.exp;
        energy.text = "Energy: +" + data.energy;
    }
    public void Buy()
    {
        if (GameManager.instance.money < data.price) return;
        GameManager.instance.money -= data.price;
        for (int i = 0; i < GameManager.instance.foodData.Count; i++)
        {
            if (data.type == GameManager.instance.foodData[i].type)
            {
                GameManager.instance.foodData[i].quantity++;
                SaveManager.SaveData();
                return;
            }
        }
        GameManager.instance.foodData.Add(new FoodData(data.type));
        SaveManager.SaveData();
    }
}
