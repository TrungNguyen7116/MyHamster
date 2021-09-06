using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LovePanel : MonoBehaviour
{

    public static LovePanel instance;

    public Button getButton;

    public Text textButton;

    public GameObject selectPanel;

    public GameObject malePanel;

    public GameObject femalePanel;

    public HamsterData maleSelected;
    public Image maleUI;

    public HamsterData femaleSelected;
    public Image femaleUI;

    private HamsterData baby;
    public Image babyUI;

    private bool loading = false;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Initialize();
    }
    public void Close()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void Initialize()
    {
        List<HamsterData> maleList = new List<HamsterData>();
        List<HamsterData> femaleList = new List<HamsterData>();
        for (int i = 0; i < GameManager.instance.hamsterData.Count; i++)
        {
            if (GameManager.instance.hamsterData[i].level >= 10 && GameManager.instance.hamsterData[i].type != EnumHamster.ZERO)
            {
                if (GameManager.instance.hamsterData[i].sex == EnumSex.MALE)
                {
                    maleList.Add(new HamsterData(GameManager.instance.hamsterData[i]));
                }
                else
                {
                    femaleList.Add(new HamsterData(GameManager.instance.hamsterData[i]));
                }
            }
        }
        malePanel = Instantiate(selectPanel, transform);
        malePanel.GetComponent<SelectPanel>().Initialize(maleList);
        femalePanel = Instantiate(selectPanel, transform);
        femalePanel.GetComponent<SelectPanel>().Initialize(femaleList);
    }

    public void ReloadData()
    {
        Destroy(malePanel);
        Destroy(femalePanel);
        Initialize();
        if (!loading)
        {
            maleSelected = null;
            femaleSelected = null;
            baby = null;
        }
        ReloadDisplay();
        Debug.Log("Reload");
    }

    public void ReloadDisplay()
    {
        if (!loading)
        {
            if (maleSelected != null)
            {
                maleUI.gameObject.SetActive(true);
                maleUI.sprite = Resources.Load<Sprite>("Adult/" + maleSelected.sprite);
            }
            else
            {
                maleUI.gameObject.SetActive(false);
            }
            if (femaleSelected != null)
            {
                femaleUI.gameObject.SetActive(true);
                femaleUI.sprite = Resources.Load<Sprite>("Adult/" + femaleSelected.sprite);
            }
            else
            {
                femaleUI.gameObject.SetActive(false);
            }
            if (maleSelected != null && femaleSelected != null)
            {
                getButton.gameObject.SetActive(true);
                textButton.text = "Summon";
            }
            else
            {
                getButton.gameObject.SetActive(false);
            }
        }
    }

    public void InputButton()
    {
        if (textButton.text == "Summon")
        {
            if (GameManager.instance.money < 100) return;
            Summon();
        }
        else if (textButton.text == "Get")
        {
            Get();
        }
    }

    public void GetTarget()
    {
        if (malePanel.GetComponent<SelectPanel>().targetSelected != null)
        {
            maleSelected = malePanel.GetComponent<SelectPanel>().targetSelected;
        }

        if (femalePanel.GetComponent<SelectPanel>().targetSelected != null)
        {
            femaleSelected = femalePanel.GetComponent<SelectPanel>().targetSelected;
        }
        ReloadDisplay();
    }

    public void MaleButton()
    {
        if (!loading)
        {
            malePanel.GetComponent<CanvasGroup>().alpha = 1;
            malePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void FemaleButton()
    {
        if (!loading)
        {
            femalePanel.GetComponent<CanvasGroup>().alpha = 1;
            femalePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void Get()
    {
        GameManager.instance.hamsterData.Add(baby);
        SaveManager.SaveData();
        PetPanel.instance.AddHamster();
        loading = false;
        maleSelected = null;
        femaleSelected = null;
        baby = null;
        getButton.gameObject.SetActive(false);
        ReloadDisplay();
        babyUI.sprite = Resources.Load<Sprite>("Baby/none");
    }

    public void Summon()
    {
        GameManager.instance.money -= 100;
        int sex = Random.Range(0, 2);
        int type = CalculateType();
        baby = new HamsterData((EnumHamster)type, (EnumSex)sex);
        loading = true;
        textButton.text = "Get";
        babyUI.sprite = Resources.Load<Sprite>("Baby/" + baby.sprite);
    }

    int CalculateType()
    {
        int maleGen = (int)maleSelected.type;
        int femaleGen = (int)femaleSelected.type;
        int babyGen = 0;
        int count = 4;
        while (count > 0)
        {
            int a = maleGen / (int)Mathf.Pow(10, count - 1);
            int b = femaleGen / (int)Mathf.Pow(10, count - 1);
            babyGen = babyGen * 10 + Random.Range(Mathf.Min(a, b), Mathf.Max(a, b) + 1);
            
            maleGen = maleGen % (int)Mathf.Pow(10, count - 1);
            femaleGen = femaleGen % (int)Mathf.Pow(10, count - 1);

            count--;
            Debug.Log(babyGen);
        }
        return babyGen;
    }
}
