using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetPanel : MonoBehaviour
{
    public static PetPanel instance;

    public GameObject content;

    public GameObject slot;

    public List<GameObject> listSlot;

    public HamsterData hamsterSelected;
    public GameObject hamsterObjectSelected;

    public FoodData foodSelected;
    public GameObject foodObjectSelected;

    public CanvasGroup foodPanel;

    public CanvasGroup namePanel;

    public CanvasGroup freePanel;

    //Info
    public GameObject frame;
    public Image avatar;
    public Text name;
    public Text height;
    public Text weight;
    public Text level;
    public Text rarity;
    public Image sex;
    public Stat exp;
    //Food
    public Image foodUI;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        hamsterSelected = null;
        foodSelected = null;
        listSlot = new List<GameObject>();
        DisplayList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectFood(ref FoodData data, GameObject obj)
    {
        foodSelected = data;
        foodUI.sprite = Resources.Load<Sprite>("Food/" + data.name);
        foodObjectSelected = obj;
    }

    public void SelectHamster(ref HamsterData data, GameObject obj)
    {
        hamsterSelected = data;
        hamsterObjectSelected = obj;
        DisplayInfo();
    }

    void DisplayList()
    {
        for (int i = 0; i < GameManager.instance.hamsterData.Count; i++)
        {
            listSlot.Add(Instantiate(slot, content.transform));
            listSlot[i].GetComponent<SlotPet>().SetData(GameManager.instance.hamsterData[i]);
        }
    }

    public void AddHamster()
    {
        for (int i = listSlot.Count; i < GameManager.instance.hamsterData.Count; i++)
        {
            listSlot.Add(Instantiate(slot, content.transform));
            listSlot[i].GetComponent<SlotPet>().SetData(GameManager.instance.hamsterData[i]);
        }
    }

    public void DisplayInfo()
    {
        //avatar
        if (hamsterSelected != null)
        {
            frame.SetActive(true);
            if (hamsterSelected.level >= 10)
            {
                avatar.sprite = Resources.Load<Sprite>("Adult/" + hamsterSelected.sprite);
            }
            else
            {
                avatar.sprite = Resources.Load<Sprite>("Baby/" + hamsterSelected.sprite);
            }
            name.text = hamsterSelected.name;
            height.text = "Height: " + hamsterSelected.height + " cm";
            weight.text = "Weight: " + hamsterSelected.weight + " g";
            level.text = "Lv. " + hamsterSelected.level;
            exp.Initialize((float)hamsterSelected.maxExp);
            exp.CurrentValue = hamsterSelected.exp;
            if (hamsterSelected.sex == EnumSex.MALE)
            {
                sex.sprite = Resources.Load<Sprite>("Gender/Male");
            }
            else
            {
                sex.sprite = Resources.Load<Sprite>("Gender/Female");
            }
            DisplayRarity();
        }
        else
        {
            frame.SetActive(false);
        }
    }

    void DisplayRarity()
    {
        EnumRarity type = hamsterSelected.rarity;
        switch(type)
        {
            case EnumRarity.COMMON:
                rarity.text = "Common";
                rarity.color = new Color(0.42f, 0.42f, 0.42f);
                break;
            case EnumRarity.UNCOMMON:
                rarity.text = "Uncommon";
                rarity.color = new Color(0, 0.83f, 0.26f);
                break;
            case EnumRarity.RARE:
                rarity.text = "Rare";
                rarity.color = new Color(0, 0.83f, 0.67f);
                break;
            case EnumRarity.MYTHICAL:
                rarity.text = "Mythical";
                rarity.color = new Color(0.49f, 0, 0.83f);
                break;
            case EnumRarity.LEGENDARY:
                rarity.text = "Legendary";
                rarity.color = new Color(0.83f, 0, 0.71f);
                break;
        }
    }
    public void CLose()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void FoodPanelOpen()
    {
        foodPanel.alpha = 1;
        foodPanel.blocksRaycasts = true;
    }

    public void NamePanelOpen()
    {
        namePanel.alpha = 1;
        namePanel.blocksRaycasts = true;
        namePanel.GetComponent<NamePanel>().SetData(ref hamsterSelected);
    }

    public void Feed()
    {
        if (foodSelected != null)
        {
            foodSelected.quantity--;
            foodObjectSelected.GetComponent<SlotFood>().quantity.text = "x" + foodSelected.quantity;
            Nutrition(foodSelected);
            if (foodSelected.quantity == 0)
            {
                GameManager.instance.foodData.Remove(foodSelected);
                foodSelected = null;
                FoodPanel.instance.listFood.Remove(foodObjectSelected);
                Destroy(foodObjectSelected);
                foodObjectSelected = null;
                foodUI.sprite = Resources.Load<Sprite>("Food/cart");
            }
            SaveManager.SaveData();
        }
    }

    public void FreePanelOpen()
    {
        freePanel.alpha = 1;
        freePanel.blocksRaycasts = true;
    }

    public void Free()
    {
        GameManager.instance.hamsterData.Remove(hamsterSelected);
        hamsterObjectSelected.GetComponent<SlotPet>().DestroyHamster();
        listSlot.Remove(hamsterObjectSelected);
        Destroy(hamsterObjectSelected);
        SaveManager.SaveData();
        hamsterSelected = null;
        hamsterObjectSelected = null;
        DisplayInfo();
    }

    public void Nutrition(FoodData food)
    {
        //+exp => lv => setimage
        //+energy
        hamsterSelected.ExpPlus(food.exp);
        hamsterSelected.energy += food.energy;
        if (hamsterSelected.level == 10)
        {
            hamsterObjectSelected.GetComponent<SlotPet>().SetAvatar();
        }
        DisplayInfo();
    }
}
