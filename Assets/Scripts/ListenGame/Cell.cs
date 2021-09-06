using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text choice;

    public void SetChoice(string c)
    {
        choice.text = c;
    }
}
