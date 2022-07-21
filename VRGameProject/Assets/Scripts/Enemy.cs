using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamage
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

    public void IPoison(int Damage)
    {
        
    }

    public void IImpack(int Damage, int Range)
    {
        
    }

    public void IFreeze(int Damge)
    {
        
    }
}
