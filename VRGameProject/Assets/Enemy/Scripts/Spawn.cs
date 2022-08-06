using UnityEngine;

namespace Enemy
{
    public class Spawn : MonoBehaviour
    {
        [Header("Wave1")] [SerializeField] private float start1;
        [SerializeField] float end1;
        [Header("Wave2")] [SerializeField] private float start2;
        [SerializeField] float end2;
        [Header("Wave3")] [SerializeField] private float start3;
        [SerializeField] float end3;
        [Header("Wave4")] [SerializeField] private float start4;
        [SerializeField] float end4;
        
        [Header("numberOfEnemyWave1")]
        [SerializeField]
        int num1;
        [Header("numberOfEnemyWave2")]
        [SerializeField]
        int num2; 
        [Header("numberOfEnemyWave3")]
        [SerializeField]
        int num3;
        [Header("numberOfEnemyWave4")]
        [SerializeField]
        int num4;
        
        
        [Header("enterGameobject")]
        [SerializeField] private GameObject  enemy1,enemy2,enemy3;
        [SerializeField] private Transform   spawn1,spawn2,spawn3;
        private GameObject[] enemyS;
        private Transform[]  spawnS;
        public float timecount;
        public float spawnRate=1;
        int numEnemies=0;
      
        

        public void Start()
        {
            enemyS = new[] { enemy1, enemy2, enemy3 };
            spawnS = new[] { spawn1, spawn2, spawn3 };
            //Soundmanager.sM.Gamestart();
        }

        public void Update()
        {
            if (GameManager.game.isClickReStart)
            {
                timecount = 0;
                numEnemies = 0;
                spawnRate = 0;
            }
            if (GameManager.game.isClickStart)
            {
                timecount += Time.deltaTime;
                //Debug.Log($"{(int)timecount}Secon");
                if (timecount>=start1 && timecount<=end1)
                {
                    GameManager.game.wave = 1;
                    spawnRate += Time.deltaTime;
                    SpawnPoint();
                }
                if (timecount>=start2&& timecount<=end2)
                {
                    GameManager.game.wave = 2;
                    spawnRate += Time.deltaTime;
                    SpawnPoint1();
                } 
                if (timecount>=start3 && timecount<=end3)
                {
                    GameManager.game.wave = 3;
                    spawnRate += Time.deltaTime;
                    SpawnPoint2();
                }
                if (timecount>=start4 && timecount<=end4)
                {
                    GameManager.game.wave = 4;
                    spawnRate += Time.deltaTime;
                    SpawnPoint3();
                }
            }
        }

        void SpawnEnemy()
        {
        
            Instantiate(enemyS[UnityEngine.Random.Range(0,3)], spawnS[UnityEngine.Random.Range(0,3)].transform.position, Quaternion.identity);
            numEnemies++;
            GameManager.game.enemyCount += 1;
        }

        void SpawnPoint()
        {
            if ( spawnRate >= 1f && numEnemies<num1)
            {
                spawnRate = 0;
                SpawnEnemy();
            }
        }
        void SpawnPoint1()
        {
            if ( spawnRate >= 1f && numEnemies<num2+num1)
            {
                spawnRate = 0;
                SpawnEnemy();
            }
        }
        void SpawnPoint2()
        {
            if ( spawnRate >= 1f && numEnemies<num3+num1+num2)
            {
                spawnRate = 0;
                SpawnEnemy();
            }
        }
        void SpawnPoint3()
        {
            if ( spawnRate >= 1f && numEnemies<num4+num1+num2+num3)
            {
                spawnRate = 0;
                SpawnEnemy();
            }
        }
    }
}
