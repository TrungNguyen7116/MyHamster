using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPanel : MonoBehaviour
{
    public GameObject content;

    public GameObject slot;

    public HamsterData targetSelected;

    public void Initialize(List<HamsterData> list)
    {
        targetSelected = null;
        for (int i = 0; i < list.Count; i++)
        {
            GameObject newSlot = Instantiate(slot, content.transform);
            newSlot.GetComponent<SlotLove>().Initialize(list[i]);
        }
    }

    public void Close()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        targetSelected = null;
    }
}
