using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour,IDamage
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
        [Header("Enemy Status")]
        [SerializeField]private float speed;
        [SerializeField]private int hp;
        private float fSpeed;
        [SerializeField]private Rigidbody e_rigi;
        //Fire Method
        private int fireDMG;
        private float StatusTimeCount;
        private float StatusTime;
        private float dmgFireTime;
        private float dmgFireTimeCount;
        private bool isFire = false;
        
        void Awake()
        {
            
        }
        private void Start()
        {
            hp = enemyType.hp;
            fSpeed = enemyType.speed;
            speed = enemyType.speed;
            e_rigi = GetComponent<Rigidbody>();
        }

        public void IHit(int Damage)
        {
            hp -= Damage;
            Debug.Log($"Enemy : {hp}");
        }

        public void IPoison(int Speed)
        {
            speed -= Speed;
        }

        public void IImpack(float Range)
        {
            e_rigi.AddForce(transform.up*Range);
            e_rigi.AddForce(-transform.forward*Range*2);
        }

        public void IFreeze(int Speed)
        {
            speed -= Speed;
        }

        public void IFire(int Damage , float DMGTime , float STSTime)
        {
            isFire = true;
            fireDMG = Damage;
            dmgFireTime = DMGTime;
            StatusTime = STSTime;
        }

        public void ReSpeed()
        {
            speed = fSpeed;
        }

        private void Fire()
        {
            if (dmgFireTimeCount>=dmgFireTime & StatusTimeCount<=StatusTime)
            {
                hp -= fireDMG;
                dmgFireTimeCount = 0;
                Debug.Log($"EnemyHP : {hp}");
            }
            if (StatusTimeCount>=StatusTime)
            {
                isFire = false;
                dmgFireTimeCount = 0;
                StatusTimeCount = 0;
            }
        }

        void Update()
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            Destroy();
            if (isFire)
            {
                dmgFireTimeCount += Time.deltaTime;
                StatusTimeCount += Time.deltaTime;
                Fire();
            }
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

            if (hp<=0)
            {
                Destroy(gameObject);
            }
        }

    }
}