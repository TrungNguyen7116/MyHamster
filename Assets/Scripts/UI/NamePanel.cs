using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePanel : MonoBehaviour
{
    public HamsterData data;
    public InputField fieldName;


    public void SetData(ref HamsterData data)
    {
        fieldName.text = data.name;
        this.data = data;
    }
    public void OKButton()
    {
        data.name = fieldName.text;
        SaveManager.SaveData();
        PetPanel.instance.DisplayInfo();
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
