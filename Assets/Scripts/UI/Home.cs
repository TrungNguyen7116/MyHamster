using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject canvas;

    public CanvasGroup petPanel;

    public CanvasGroup shopPanel;

    public CanvasGroup lovePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PetPanelOpen()
    {
        petPanel.alpha = 1;
        petPanel.blocksRaycasts = true;
    }
    public void ShopPanelOpen()
    {
        shopPanel.alpha = 1;
        shopPanel.blocksRaycasts = true;
    }

    public void LovePanelOpen()
    {
        lovePanel.alpha = 1;
        lovePanel.blocksRaycasts = true;
        lovePanel.GetComponent<LovePanel>().ReloadData();
    }

    public void WordsScene()
    {
        canvas.SetActive(false);
        LoadSceneManager.instance.LoadScene("WordsScene");   
    }

    public void ListenScene()
    {
        canvas.SetActive(false);
        LoadSceneManager.instance.LoadScene("ListenScene");
    }
}
