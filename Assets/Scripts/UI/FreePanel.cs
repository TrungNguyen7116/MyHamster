using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreePanel : MonoBehaviour
{
    public void Close()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OKButton()
    {
        PetPanel.instance.Free();
        Close();
    }
}
