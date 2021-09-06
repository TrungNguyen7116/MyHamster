using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotFood : MonoBehaviour
{
    public FoodData data;
    public Text quantity;

    public void SetQuantity()
    {
        quantity.text = "x" + data.quantity;
    }

    public void Initilize(FoodData data)
    {
        this.data = data;
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Food/" + data.name);
        SetQuantity();
    }

    public void SelectFood()
    {
        PetPanel.instance.SelectFood(ref data, this.gameObject);
    }
}
