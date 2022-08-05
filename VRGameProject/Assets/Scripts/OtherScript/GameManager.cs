using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    [SerializeField] private Slider sli;
    public int score;
    public int wave;
    public int enemyCount;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text EnemyText;
    [SerializeField] private Text WaveText;
    [SerializeField] private Text HpText;
    [SerializeField] private int winScore;
    public int Hp;
    private int FHp;
    public bool isClickStart;
    public bool isClickReStart;
    public bool isClickReturnMenu;
    private bool playSound;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LoseUI;
    private void Start()
    {
        game = this;
        sli.maxValue = Hp;
        sli.minValue = 0;
        FHp = Hp;
        WinUI.SetActive(false);
        GameUI.SetActive(false);
        LoseUI.SetActive(false);
        MenuUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClickStart)
        {
            isClickReturnMenu = false;
            isClickReStart = false;
            sli.value = Hp;
            MenuUI.SetActive(false);
            GameUI.SetActive(true);
            ScoreText.text = $"You Kill : {score}";
            EnemyText.text = $"Enemy : {enemyCount}";
            WaveText.text = $"Wave : {wave}";
            HpText.text = $"Hp : {Hp}";
        }
        if (score >= winScore)
        {
            if (playSound==false)
            {
                Soundmanager.sM.Gamestart();
                playSound = true;
            }
            WinUI.SetActive(true);
            LoseUI.SetActive(false);
            GameUI.SetActive(false);
            isClickStart = false;
            //win
        }

        if (Hp<=0)
        {
            if (playSound==false)
            {
                Soundmanager.sM.Gamestart();
                playSound = true;
            }
            LoseUI.SetActive(true);
            WinUI.SetActive(false);
            GameUI.SetActive(false);
            isClickStart = false;
            //Lose
        }
        if (isClickReStart & isClickReturnMenu==false)
        {
            Restart();
            isClickStart = true;
            LoseUI.SetActive(false);
            WinUI.SetActive(false);
            GameUI.SetActive(true);
            sli.value = FHp;
        }

        if (isClickReturnMenu)
        {
            Restart();
            isClickReStart = true;
            LoseUI.SetActive(false);
            WinUI.SetActive(false);
            GameUI.SetActive(false);
            MenuUI.SetActive(true);
        }
    }

    void Restart()
    {
        playSound = false;
        score = 0;
        Hp = FHp;
        wave = 0;
        enemyCount = 0;
    }
    
}
