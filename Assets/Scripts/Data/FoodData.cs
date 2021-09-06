using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodData
{
    public string name;
    public int price;
    public int quantity;
    public int exp;
    public int energy;
    public EnumFood type;

    public FoodData(EnumFood type)
    {
        switch (type)
        {
            case EnumFood.SEED:
                name = "Seed";
                price = 10;
                exp = 5;
                energy = 10;   
                break;
            case EnumFood.PEANUT:
                name = "Peanut";
                price = 12;
                exp = 7;
                energy = 14;
                break;
            case EnumFood.WALNUT:
                name = "Walnut";
                price = 15;
                exp = 10;
                energy = 15;
                break;
            case EnumFood.CARROT:
                name = "Carrot";
                price = 20;
                exp = 20;
                energy = 15;
                break;
            case EnumFood.SPINACH:
                name = "Spinach";
                price = 15;
                exp = 15;
                energy = 10;
                break;
            case EnumFood.CABBAGE:
                name = "Cabbage";
                price = 20;
                exp = 20;
                energy = 15;
                break;
            case EnumFood.CORN:
                name = "Corn";
                price = 30;
                exp = 30;
                energy = 30;
                break;
            case EnumFood.PUMPKIN:
                name = "Pumpkin";
                price = 35;
                exp = 40;
                energy = 45;
                break;
            case EnumFood.MILK:
                name = "Milk";
                price = 30;
                exp = 45;
                energy = 50;
                break;
        }
        quantity = 1;
        this.type = type;
    }
}

