using DefaultNamespace;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamage
{
    [SerializeField] private FileSo enemyType;
    [SerializeField] Transform target;
    [SerializeField] private float destroyLange;
    private float speed;
    private int hp;
    private float fSpeed;
    
    private void Start()
    {
        hp = enemyType.hp;
        fSpeed = enemyType.speed;
        speed = enemyType.speed;
    }

    void Update()
    {
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (Vector3.Distance(transform.position, target.position) < destroyLange)
        {
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, target.position) < 100f)
        {
            //Debug.Log($" distant{Vector3.Distance(transform.position, target.position)}");
        }
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }
    
    public void IHit(int Damage)
    {
        hp -= Damage;
        Debug.Log($"Enemy : {hp}");
    }
    public void IPoison(int Speed)
    {
        this.speed -= Speed;
    }
    public void IImpack(int Damage ,float Range) 
    {
        hp -= Damage;
        Vector3 player = new Vector3(transform.position.x,transform.position.y+Range,transform.position.z-Range);
        transform.position = Vector3.MoveTowards(transform.position,player,35f);
    }
    public void IFreeze(int Speed)
    {
        this.speed = Speed;
    }
    public void ReSpeed()
    {
        speed = fSpeed;
    }
}
