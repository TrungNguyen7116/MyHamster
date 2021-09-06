using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    private int number;

    public Text textUI;

    public void SetNumber(int value)
    {
        number = value;
        textUI.text = (number + 1).ToString();
    }
    public void Select()
    {
        GameObject listenManager = GameObject.Find("ListenGameManager");
        listenManager.GetComponent<ListenGameManager>().InitializeGame(number);
        transform.parent.parent.GetComponent<CanvasGroup>().alpha = 0;
        transform.parent.parent.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
