using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{

    public GameObject slot;

    public GameObject content;

    public Text money;

    private const int FOOD_COUNT = 9;
    void Start()
    {
        Initialize();
    }

    private void OnGUI()
    {
        if (this.GetComponent<CanvasGroup>().alpha == 0)
        {
            return;
        }
        else
        {
            money.text = GameManager.instance.money.ToString() + "$";
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < FOOD_COUNT; i++)
        {
            GameObject newSlot = Instantiate(slot, content.transform);
            newSlot.GetComponent<SlotShop>().SetData(new FoodData((EnumFood)i));
        }
    }

    public void CLose()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        FoodPanel.instance.Reload();
    }
}
