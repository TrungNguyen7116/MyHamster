using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotLove : MonoBehaviour
{
    public HamsterData data;

    public Image avatar;
    public Text name;
    public Text level;
    public Text rarity;
    public void Initialize(HamsterData data)
    {
        this.data = data;
        avatar.sprite = Resources.Load<Sprite>("Adult/" + data.sprite);
        name.text = data.name;
        level.text = "Lv. " + data.level;
        DisplayRarity();
    }
    void DisplayRarity()
    {
        EnumRarity type = data.rarity;
        switch (type)
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

    public void Select()
    {
        this.transform.parent.parent.parent.GetComponent<SelectPanel>().targetSelected = data;
        this.transform.parent.parent.parent.parent.GetComponent<LovePanel>().GetTarget();
    }
}
