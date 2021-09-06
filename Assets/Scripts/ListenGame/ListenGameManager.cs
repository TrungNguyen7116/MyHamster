using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ListenGameManager : MonoBehaviour
{
    public Text switchButton;

    public Transform listChoice;

    public GameObject cell;
    public GameObject freeCell;

    public Text currentNumberUI;
    private int currentNumber;

    private char[] choice;
    private Cell[] choiceUI;

    public CanvasGroup scorePanel;
    public Text score;

    private int numberText;

    private string[] solution = new string[] {
    "ACBCCCBAACBCAABBBACBACCCB",

"CCABCCBAACABCBBAACCACCABA",

"ACBBCABBACCABBCAACCBABBAC",

"ABAAACBCACACACBBBCACBACCB",

"BCBBACCBBACCABCCBAACCBAAA",

"BCBACBBACCACCBBBAAACBCABC",

"CACBCBCCABBCCBCCACABABABA",

"AABBABACCCBCACCACCBBCAAAC",

"CACBCBCBABCBBAACAAABCBACA",

"ABACBAAAAABBAACBACBAABCBB",

"AAABAACBBACCBBABCABACACBA",

"ACACBBBCABACABBCBACBABABB",

"CABCAABAABACBBCCAAACACCAA",

"CCABBCBBBCCBACBBABCBBACAA",

"BCABBCAACACCBAAABABBCCBAA"};

    private AudioSource source;
    private AudioClip currentClip;


    void Start()
    {
        choice = new char[25];
        choiceUI = new Cell[25];
        currentNumber = 0;
        source = GetComponent<AudioSource>();
        InitializeListChoice();
    }

    public void InitializeGame(int number)
    {
        numberText = number;
        currentClip = AudioManager.instance.english[numberText];
        source.PlayOneShot(currentClip);
    }

    void InitializeListChoice()
    {
        int number = 7;
        for (int i = 0; i < 25; i++)
        {
            GameObject newCell = Instantiate(cell, listChoice);
            newCell.GetComponent<Cell>().SetChoice(number.ToString());
            number++;
            choiceUI[i] = Instantiate(freeCell, listChoice).GetComponent<Cell>();
        }
    }

    public void PreNumber()
    {
        if (currentNumber > 0)
        {
            currentNumber--;
            currentNumberUI.text = (currentNumber + 7).ToString();
        }
    }
    public void NextNumber()
    {
        if (currentNumber < 24)
        {
            currentNumber++;
            currentNumberUI.text = (currentNumber + 7).ToString();
        }
    }
    public void Choice_A()
    {
        choice[currentNumber] = 'A';
        choiceUI[currentNumber].SetChoice("A");
        if (currentNumber == 24)
        {
            switchButton.text = "FINISH";
        }
    }
    public void Choice_B()
    {
        choice[currentNumber] = 'B';
        choiceUI[currentNumber].SetChoice("B");
        if (currentNumber == 24)
        {
            switchButton.text = "FINISH";
        }
    }
    public void Choice_C()
    {
        choice[currentNumber] = 'C';
        choiceUI[currentNumber].SetChoice("C");
        if (currentNumber == 24)
        {
            switchButton.text = "FINISH";
        }
    }
    public void SwitchButton()
    {
        if (switchButton.text == "PLAY")
        {
            PlayButton();
        }
        else if (switchButton.text == "PAUSE")
        {
            PauseButton();  
        }
        else if (switchButton.text == "FINISH")
        {
            FinishButton();
        }
    }
    public void PauseButton()
    {
        source.Pause();
        switchButton.text = "PLAY";
    }
    public void PlayButton()
    {
        source.UnPause();
        switchButton.text = "PAUSE";
    }
    public void FinishButton()
    {
        source.Pause();
        int correct = 0;
        for (int i = 0; i < 25; i++)
        {
            if (choice[i] == solution[numberText][i])
            {
                correct++;
            }
        }
        scorePanel.alpha = 1;
        scorePanel.blocksRaycasts = true;
        score.text = "Score: " + correct + " / 25";
        GameManager.instance.money += (correct * 4);
        SaveManager.SaveData();
    }
    public void Replay()
    {
        LoadSceneManager.instance.LoadScene("ListenScene");
    }

    public void Home()
    {
        LoadSceneManager.instance.LoadScene("HomeScene");
    }
}
