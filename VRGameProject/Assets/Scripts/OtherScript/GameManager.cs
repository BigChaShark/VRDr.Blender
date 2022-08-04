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
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text WaveText;
    [SerializeField] private Text HpText;
    [SerializeField] private int winScore;
    public int Hp;
    private int FHp;
    public bool isClickStart;
    public bool isClickReStart;
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
            isClickReStart = false;
            sli.value = Hp;
            MenuUI.SetActive(false);
            GameUI.SetActive(true);
            ScoreText.text = $"Score : {score}";
            WaveText.text = $"Wave: {wave}";
            HpText.text = $"Hp: {Hp}";
        }
        if (score >= winScore)
        {
            WinUI.SetActive(true);
            LoseUI.SetActive(false);
            GameUI.SetActive(false);
            isClickStart = false;
            //win
        }

        if (Hp<=0)
        {
            LoseUI.SetActive(true);
            WinUI.SetActive(false);
            GameUI.SetActive(false);
            isClickStart = false;
            //Lose
        }
        if (isClickReStart)
        {
            Restart();
            isClickStart = true;
            LoseUI.SetActive(false);
            WinUI.SetActive(false);
            GameUI.SetActive(true);
            sli.value = FHp;
        }
    }

    void Restart()
    {
        score = 0;
        Hp = FHp;
        wave = 0;
    }
    
}
