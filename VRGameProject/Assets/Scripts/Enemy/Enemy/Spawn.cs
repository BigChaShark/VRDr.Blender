using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject  enemy1;
    [SerializeField] private GameObject  enemy2;
    [SerializeField] private GameObject  enemy3;

    [SerializeField] private Transform   spawn1;
    [SerializeField] private Transform   spawn2;
    [SerializeField] private Transform   spawn3;
    private GameObject[] enemyS;
    private Transform[]  spawnS;
    public float timecount;
    
    public float spawnTime;
    public float spawnTime1;
    public float spawnTime2;
    public float spawnRate;
    public float spawnRate2;
    public float spawnRate3;
    int numEnemies=0;

    public void Start()
    {
        enemyS = new[] { enemy1, enemy2, enemy3 };
        spawnS = new[] { spawn1, spawn2, spawn3 };
       
    }

    public void FixedUpdate()
    {
        timecount += Time.deltaTime;
        Debug.Log($"{timecount}Secon");
       
        
        if (timecount>=5 && timecount<=39)
        {
            spawnRate += Time.deltaTime;
            SpawnPoint();
        }
        if (timecount>=40&& timecount<=119)
        {
            spawnRate += Time.deltaTime;
            SpawnPoint1();
        } 
        if (timecount>=120 && timecount<=200)
        {
            spawnRate += Time.deltaTime;
            SpawnPoint2();
        }
        
    }

    void SpawnEnemy()
    {
        
        Instantiate(enemyS[UnityEngine.Random.Range(0,3)], spawnS[UnityEngine.Random.Range(0,3)].transform.position, Quaternion.identity);
        numEnemies++;
        
    }

    void SpawnPoint()
    {
        if ( spawnRate >= 1f && numEnemies<20)
        {
            spawnRate = 0;
            SpawnEnemy();
         
        }
        
    }
    void SpawnPoint1()
    {
        if ( spawnRate >= 1f && numEnemies<30)
        {
            spawnRate = 0;
            SpawnEnemy();
         
        }
        
    }
    void SpawnPoint2()
    {
        if ( spawnRate >= 1f && numEnemies<40)
        {
            spawnRate = 0;
            SpawnEnemy();
         
        }
        
    }

}
