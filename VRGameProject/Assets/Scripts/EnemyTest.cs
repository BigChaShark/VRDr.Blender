using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private int hp = 10;
    public void IHit(int Damage)
    {
        hp -= Damage;
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }

    public void IPoison(int Damage , int Speed)
    {
        
    }

    public void IImpack(int Damage, float Range)
    {
        
    }

    public void IFreeze(int Speed)
    {
        
    }

    public void ReSpeed()
    {
        
    }
}
