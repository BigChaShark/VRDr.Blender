using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    public int score;
    [SerializeField] private Text ScoreText;

    private void Start()
    {
        game = this;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = $"Score : {score}";
    }
}
