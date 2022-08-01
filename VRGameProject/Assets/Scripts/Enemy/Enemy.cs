using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {

        [Header("OpenDebug_distant_1_OR_0")] [SerializeField]
        private int openDebug;
        [Header("DeadEffect(particle System)")] 
        [SerializeField] private ParticleSystem death;
        [Header("EnemyType")] 
        [SerializeField] private FileSo enemyType;
        [Header("PlayerTarge")]
        [SerializeField] Transform target;
        [Header("DestroyRange")]
        [SerializeField] private float destroyRange;
       
        void Awake()
        {




        }


        public void IHit(int Damage)
        {

        }

        public void IPoison(int Damage)
        {

        }

        public void IImpack(int Damage, int Range)
        {

        }

        public void IFreeze(int Damage)
        {

        }

        void Update()
        {

            var step = enemyType.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            Destroy();
            
        }

        public void Destroy()
        {
            if (Vector3.Distance(transform.position, target.position) < destroyRange)
            {
                Instantiate(death, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }

            if (Vector3.Distance(transform.position, target.position) < 100f&& openDebug==1)
            {
                Debug.Log($" distant{(int)Vector3.Distance(transform.position, target.position)}");
            }
        }

    }
}