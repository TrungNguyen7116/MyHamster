using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static void SaveData()
    {
        SaveData data = new SaveData();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/data.save");
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Saved");
    }
    public static void LoadData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/data.save", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            //Assign game manager
            GameManager.instance.hamsterData = data.hamsterData;
            GameManager.instance.foodData = data.foodData;
            GameManager.instance.money = data.money;
            //
            file.Close();
            Debug.Log("Load");
        }
        else
        {
            //Default when the first start game
            GameManager.instance.hamsterData = new List<HamsterData>();
            GameManager.instance.hamsterData.Add(new HamsterData(EnumHamster.ZERO, EnumSex.MALE));
            GameManager.instance.hamsterData.Add(new HamsterData(EnumHamster.ONE, EnumSex.MALE));
            GameManager.instance.hamsterData.Add(new HamsterData(EnumHamster.SIXTEEN, EnumSex.FEMALE));
            GameManager.instance.foodData = new List<FoodData>();
            GameManager.instance.foodData.Add(new FoodData(EnumFood.SEED));
            GameManager.instance.foodData[0].quantity = 10;
            GameManager.instance.money = 100;
            SaveData();
        }
    }
}
