using DefaultNamespace;
using UnityEngine;

namespace Enemy.Scripts
{
    public class Enemy : MonoBehaviour,IDamage
    {

        [Header("ViewDistant_SelfDestroy")] 
        private bool openDebug=false;
        private bool enemyDeath;
        
        [Header("DeadEffect(particle System)")] 
        [SerializeField] private ParticleSystem death;
        [SerializeField] private FileSo enemyType;
        
        private Transform target;
        private GameObject heeTarget;
        
        [Header("Enemy Status")]
        [SerializeField]private float speed;
        [SerializeField]private int hp;
        [SerializeField] private float destroyRange;
        private float fSpeed;
        
        [Header("RigiBody")]
        [SerializeField]private Rigidbody e_rigi;
        
        //Fire Method
        private int fireDMG;
        private float StatusTimeCount;
        private float StatusTime;
        private float dmgFireTime;
        private float dmgFireTimeCount;
        private bool isFire = false;
       
        //AnimetionBool
        public bool animwalk;
        
        
        void Awake()
        {
            
        }
        private void Start()
        {
            
            hp = enemyType.hp;
            fSpeed = enemyType.speed;
            speed = enemyType.speed;
            e_rigi = GetComponent<Rigidbody>();
            
            heeTarget = GameObject.FindGameObjectWithTag("Hee");
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
            target = heeTarget.transform;
            
            Debug.Log(heeTarget.transform.position);
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
           
            Vector3 targetDirection = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetDirection,Vector3.up);
            transform.rotation = rotation;
            DestroyE();
           
           
           if (target!=null)
           {
               animwalk = true;
           }
           
           if (target==null)
           {
               animwalk = false;
           }
            
            
            if (isFire)
            {
                dmgFireTimeCount += Time.deltaTime;
                StatusTimeCount += Time.deltaTime;
                Fire();
            }

            if (enemyDeath==true)
            {
                hp = 0;
            }
        }

        public void DestroyE()
        {
            if (Vector3.Distance(transform.position, target.position) < destroyRange)
            {
                Instantiate(death, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }

            if (Vector3.Distance(transform.position, target.position) < 100f&& openDebug==true)
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