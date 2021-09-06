using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private float currentValue;
    private float maxValue;

    public float MaxValue { get => maxValue; set => maxValue = value; }
    public float CurrentValue { get => currentValue; 
        set { currentValue = value; 
            if (currentValue > maxValue) currentValue = maxValue; 
            if (currentValue < 0) currentValue = 0;
            Display();
        } }

    public void Initialize(float value)
    {
        maxValue = value;
        currentValue = value;
    }

    public void Display()
    {
        this.GetComponent<Image>().fillAmount = 1.0f * currentValue / maxValue;
    }
}
