using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPanel : MonoBehaviour
{
    public GameObject numberButton;

    public Transform viewPointl;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject newNumber = Instantiate(numberButton, viewPointl);
            newNumber.GetComponent<NumberButton>().SetNumber(i);
        }
    }
}
