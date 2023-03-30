using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;
    public int WinScore = 10;

    public BallControls BallControl;

    [Header("UI")]

    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;
    public TMP_Text PlayerWinText;
    public GameObject PanelWinScreen;


    public static GameManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Mengisikan nilai integer PlayerScore ke UI
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
        PanelWinScreen.SetActive(false);
    }



    //Method penyeleksi untuk menambah score
    public void Score(string wallID)
    {
        if (wallID == "Left Score Border")
        {
            PlayerScoreR = PlayerScoreR + 1; //Menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //Mengisikan nilai integer PlayerScore ke UI
        }
        else
        {
            PlayerScoreL = PlayerScoreL + 1;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
           
        }
        ScoreCheck();
    }

    public void ScoreCheck()
    {
        if (PlayerScoreL == WinScore)
        {
            PanelWinScreen.SetActive(true);
            PlayerWinText.text = "Player Left Win";
        }
        else if (PlayerScoreR == WinScore)
        {
            PanelWinScreen.SetActive(true);
            PlayerWinText.text = "Player Right Win";
        }

    }

    public void RestartGame()
    {
        PlayerScoreL = 0;
        PlayerScoreR = 0;
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
        BallControl.Invoke(nameof(BallControl.GoBall), 1.0f);
        PanelWinScreen.SetActive(false);
    }

}