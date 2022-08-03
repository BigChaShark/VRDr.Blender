using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animetion : MonoBehaviour
{
    [SerializeField] private Enemy.Scripts.Enemy enemyDecoy;

    [SerializeField] private Animator enemyAnimetion;
    private bool chackanim;


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Awake()
    {
    
        enemyAnimetion = gameObject.GetComponent<Animator>();
       
    }

    private void Update()
    {
        chackanim = enemyDecoy.animwalk;
        if (chackanim == true)
        {
            enemyAnimetion.SetBool("Walk Forward",true);
        }
        if (chackanim == false)
        {
            enemyAnimetion.SetBool("Walk Forward",false);
        }
    }
}
