using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HamsterData
{
    public string name;
    public float height;
    public float weight;
    public int level;
    public int exp;
    public int maxExp;
    public float energy;
    public EnumHamster type;
    public EnumRarity rarity;
    public EnumSex sex;
    public string sprite;

    public HamsterData(EnumHamster type, EnumSex sex)
    {
        switch (type)
        {
            case EnumHamster.ZERO:
                sprite = "zero";
                rarity = EnumRarity.LEGENDARY;
                break;
            case EnumHamster.ONE:
                sprite = "one";
                rarity = EnumRarity.COMMON;
                break;
            case EnumHamster.TWO:
                sprite = "two";
                rarity = EnumRarity.LEGENDARY;
                break;
            case EnumHamster.THREE:
                sprite = "three";
                rarity = EnumRarity.COMMON;
                break;
            case EnumHamster.FOUR:
                sprite = "four";
                rarity = EnumRarity.COMMON;
                break;
            case EnumHamster.FIVE:
                sprite = "five";
                rarity = EnumRarity.COMMON;
                break;
            case EnumHamster.SIX:
                sprite = "six";
                rarity = EnumRarity.UNCOMMON;
                break;
            case EnumHamster.SEVEN:
                sprite = "seven";
                rarity = EnumRarity.UNCOMMON;
                break;
            case EnumHamster.EIGHT:
                sprite = "eight";
                rarity = EnumRarity.UNCOMMON;
                break;
            case EnumHamster.NINE:
                sprite = "nine";
                rarity = EnumRarity.UNCOMMON;
                break;
            case EnumHamster.TEN:
                sprite = "ten";
                rarity = EnumRarity.RARE;
                break;
            case EnumHamster.ELEVEN:
                sprite = "eleven";
                rarity = EnumRarity.RARE;
                break;
            case EnumHamster.TWELVE:
                sprite = "twelve";
                rarity = EnumRarity.RARE;
                break;
            case EnumHamster.THIRTEEN:
                sprite = "thirteen";
                rarity = EnumRarity.MYTHICAL;
                break;
            case EnumHamster.FOURTEEN:
                sprite = "fourteen";
                rarity = EnumRarity.LEGENDARY;
                break;
            case EnumHamster.FIFTEEN:
                sprite = "fifteen";
                rarity = EnumRarity.MYTHICAL;
                break;
            case EnumHamster.SIXTEEN:
                sprite = "sixteen";
                rarity = EnumRarity.COMMON;
                break;
        }
        level = 1;
        exp = 0;
        height = Mathf.Round(Random.Range(4f, 6f) * 100) / 100.0f;
        weight = Mathf.Round(Random.Range(60f, 80f) * 100) / 100.0f;
        maxExp = 10;
        energy = 100;
        this.type = type;
        this.sex = sex;
    }
    public HamsterData(HamsterData target)
    {
        name = target.name;
        level = target.level;
        type = target.type;
        rarity = target.rarity;
        sprite = target.sprite;
    }

    public void ExpPlus(int totalexp)
    {
        exp += totalexp;
        while (exp >= maxExp)
        {
            exp -= maxExp;
            Upgrade();
        }
    }
    public void Upgrade()
    {
        height = (Mathf.Round(height * 1.1f * 100)) / 100.0f;
        weight = (Mathf.Round(weight * 1.1f * 100)) / 100.0f;
        maxExp = 10 * (int)Mathf.Pow(1.3f, level);
        level++;
    }
}
