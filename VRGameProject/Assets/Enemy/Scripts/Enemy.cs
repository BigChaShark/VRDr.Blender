using DefaultNamespace;
using UnityEngine;

namespace Enemy.Scripts
{
    public class Enemy : MonoBehaviour,IDamage
    {
        private bool isHit;
        private bool isIce;
        private bool isNormal;
        private float timeMat;
        private float timeMatCount;
        [SerializeField] private SkinnedMeshRenderer rend;
        [SerializeField] private Material MatHit;
        [SerializeField] private Material MatHitIce;
        private Material FMat;
        private Color color;
        [Header("ViewDistant_SelfDestroy")] 
        private bool openDebug=false;
        private bool enemyDeath;
        [SerializeField] private GameObject enm;
        
        [Header("DeadEffect(particle System)")] 
        [SerializeField] private ParticleSystem death;
        [SerializeField] private FileSo enemyType;
        
        private Transform target;
        private GameObject heeTarget;
        
        [Header("Enemy Status")]
        [SerializeField]private float speed;
        [SerializeField]private int hp;
        [SerializeField] private float destroyRange;
        [SerializeField] private int Damage;
        [SerializeField] private int DeadScore;
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

        //Freeze Method
        private float TimeFreez;
        private float TimeFreezCount;
        bool isFreez;

        //AnimetionBool
        public bool animwalk;
        
        private void Start()
        {
            timeMat = 1.5f;
            rend = enm.GetComponent<SkinnedMeshRenderer>();
            FMat = rend.material;
            isHit = false;
            hp = enemyType.hp;
            fSpeed = enemyType.speed;
            speed = enemyType.speed;
            Damage = enemyType.damage;
            DeadScore = enemyType.score;
            e_rigi = GetComponent<Rigidbody>();
            heeTarget = GameObject.FindGameObjectWithTag("Hee");
        }
        void Update()
        {
            target = heeTarget.transform;
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
            if (isFreez)
            {
                TimeFreezCount += Time.deltaTime;
                Freezer();
            }
           if (enemyDeath)
            {
                hp = 0;
            }
           if (GameManager.game.isClickReStart)
            {
                Destroy(gameObject);
            }
            if (isHit)
            {
                if (isIce)
                {
                    rend.material = MatHitIce;
                }
                if (isNormal)
                {
                    timeMatCount += Time.deltaTime;
                    if (timeMatCount<=timeMat )
                    {
                        rend.material = MatHit;
                    }
                    else
                    {
                        isHit = false;
                        isNormal = false;
                        timeMatCount = 0;
                    }
                }
                
            }
            else
            {
                rend.material = FMat;
            }
        }
        public void DestroyE()
        {
            if (Vector3.Distance(transform.position, target.position) < destroyRange)
            {
                Debug.Log("Is Plus Player");
                GameManager.game.scoreForwin += 1;
                Instantiate(death, transform.position, Quaternion.identity);
                GameManager.game.Hp -= Damage;
                Destroy(gameObject);
            }
            if (Vector3.Distance(transform.position, target.position) < 100f&& openDebug==true)
            {
                //Debug.Log($" distant{(int)Vector3.Distance(transform.position, target.position)}");
            }
            if (hp<=0)
            {
                Debug.Log("Is Plus");
                GameManager.game.scoreForwin += 1;
                GameManager.game.score += 1;
                Destroy(gameObject);
            }
        }
        public void IHit(int Damage)
        {
            hp -= Damage;
            isHit = true;
            isNormal = true;
        }

        public void IPoison(int Speed)
        {
            speed -= Speed;
            isHit = true;
            isNormal = true;
        }

        public void IImpack(float Range)
        {
            isHit = true;
            e_rigi.AddForce(transform.up*Range);
            e_rigi.AddForce(-transform.forward*Range*2);
            isNormal = true;
        }

        public void IFreeze(int Speed , int Damage ,float Time)
        {
            TimeFreez = Time;
            isHit = true;
            isIce = true;
            isFreez = true;
            hp -= Damage;
            rend.material = MatHitIce;
            speed = Speed;
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
            isIce = false;
            isHit = false;
            rend.material = FMat;
            speed = fSpeed;
        }
        private void Fire()
        {
            isHit = true;
            isNormal = true;
            if (dmgFireTimeCount>=dmgFireTime & StatusTimeCount<=StatusTime)
            {
                isHit = true;
                isNormal = true;
                hp -= fireDMG;
                dmgFireTimeCount = 0;
                rend.material = FMat;
                //Debug.Log($"EnemyHP : {hp}");
            }
            if (StatusTimeCount>=StatusTime)
            {
                isHit = false;
                timeMatCount = 0;
                isFire = false;
                dmgFireTimeCount = 0;
                StatusTimeCount = 0;
            }
        }
        private void Freezer()
        {
            if (TimeFreezCount>=TimeFreez)
            {
                ReSpeed();
                isFreez = false;
                TimeFreez = 0;
                TimeFreezCount = 0;
            }
        }

    }
}