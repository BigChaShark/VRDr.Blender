using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
public class PotionManager : MonoBehaviour
{
    public enum Potion
    {
        Impact,
        Freeze,
        Poison,
        Fire,
        Wall,
        Bomb
    }
    private bool itHitZone;
    private RaycastHit[] rayHit;
    private bool ishit;
    private int bitMask;
    public Potion potionType;
    //
    [SerializeField] private int Damege;
    [SerializeField] private int ImpactRannge;
    [SerializeField] private float Objtime;
     private float time;
    private void Start()
    {
        itHitZone = false;
    }

    private void Update()
    {
        if (itHitZone)
        {
            time += Time.deltaTime;
        }
        IsHit();
    }

    void IsHit()
    {
        if (itHitZone)
        {
            bitMask = ~(1<<0)|~(1<<1)|~(1<<2)|(1<<3)|~(1<<4)|~(1<<5);
            rayHit = Physics.SphereCastAll(transform.position,100f,transform.forward,100f,bitMask);
            switch (potionType)
            {
                case Potion.Impact:
                {
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        IDmg.IImpack(Damege,ImpactRannge);
                        Destroy(gameObject);
                    }
                    break;
                }
                case Potion.Poison:
                {
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        IDmg.IPoison(Damege);
                        if (time>=Objtime)
                        {
                            Destroy(gameObject);
                        }
                    }
                    break;
                }
                case Potion.Freeze:
                {
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        IDmg.IFreeze(Damege);
                        Destroy(gameObject);
                    }
                    break;
                }
                case Potion.Fire:
                {
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        IDmg.IPoison(Damege);
                        if (time>=Objtime)
                        {
                            Destroy(gameObject);
                        }
                    }
                    break;
                }
                case Potion.Wall:
                {
                    
                    break;
                }
                case Potion.Bomb:
                {
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        if (IDmg!=null)
                        {
                            IDmg.IHit(Damege);
                            Destroy(gameObject);
                        }
                    }
                    break;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("BombZone"))
        {
            itHitZone = true;
            Debug.Log("IsHit123");
        }
    }
}
