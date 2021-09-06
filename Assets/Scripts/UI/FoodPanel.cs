using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPanel : MonoBehaviour
{
    public static FoodPanel instance;

    public GameObject content;

    public GameObject slot;

    public List<GameObject> listFood;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Initilize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initilize()
    {
        listFood = new List<GameObject>();
        for (int i = 0; i < GameManager.instance.foodData.Count; i++)
        {
            listFood.Add(Instantiate(slot, content.transform));
            listFood[i].GetComponent<SlotFood>().Initilize(GameManager.instance.foodData[i]);
        }
    }

    public void Reload()
    {
        for (int i = listFood.Count; i < GameManager.instance.foodData.Count; i++)
        {
            listFood.Add(Instantiate(slot, content.transform));
        }
        for (int i = 0; i < GameManager.instance.foodData.Count; i++)
        {
            listFood[i].GetComponent<SlotFood>().Initilize(GameManager.instance.foodData[i]);
        }
    }

    public void CLose()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
