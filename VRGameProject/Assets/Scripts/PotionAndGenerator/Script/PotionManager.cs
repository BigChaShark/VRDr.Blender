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

    [SerializeField] private ParticleSystem _particleOn;
    private bool itHitZone;
    private RaycastHit[] rayHit;
    private bool ishit;
    private int bitMask;
    public Potion potionType;
    //Ability
    [SerializeField] private int Damege;
    [SerializeField] private int ImpactRannge;
    [SerializeField] private int speedReduce;
    [SerializeField] private float Objtime;
    private float time;
    private bool isBroke;
    private bool isGlassBroke;
    private float DMGTime;
    [SerializeField]private float DMGTimeRate;

    [SerializeField] private float StatusTime;
    //Wall
    [SerializeField] private GameObject wall;
    [SerializeField] private float Range;
    private Rigidbody rigi;
    private void Start()
    {
        isGlassBroke = false;
        itHitZone = false;
        isBroke = false;
        wall.SetActive(false);
        rigi = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (itHitZone)
        {
            time += Time.deltaTime;
            DMGTime += Time.deltaTime;
        }
        IsHit();
        if (GameManager.game.isClickReStart)
        {
            Destroy(gameObject);
        }
    }

    void IsHit()
    {
        if (itHitZone)
        {
            bitMask = ~(1<<0)|~(1<<1)|~(1<<2)|(1<<3)|~(1<<4)|~(1<<5);
            rayHit = Physics.SphereCastAll(transform.position,Range,transform.forward,Range,bitMask);
            
            switch (potionType)
            {
                case Potion.Impact:
                {
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        if (IDmg!=null)
                        {
                            IDmg.IHit(Damege);
                            IDmg.IImpack(ImpactRannge);
                        }
                    }
                    Instantiate(_particleOn, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;
                }
                case Potion.Poison:
                {
                    if (isGlassBroke==false)
                    {
                        Instantiate(_particleOn, transform.position, Quaternion.identity);
                        isGlassBroke = true;
                    }
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        if (isBroke == false & IDmg!=null)
                        {
                            IDmg.IPoison(speedReduce);
                        }
                    }
                    isBroke = true;
                    if (DMGTime >= DMGTimeRate)
                    {
                        foreach (var hit in rayHit)
                        {
                            var IDmg = hit.transform.GetComponent<IDamage>();
                        
                            if (IDmg!=null)
                            {
                                IDmg.IHit(Damege);
                            }
                        }
                        DMGTime = 0;
                    }
                    if (time>=Objtime)
                    {
                        foreach (var hit in rayHit)
                        {
                            var IDmg = hit.transform.GetComponent<IDamage>();
                            if (IDmg!=null)
                            {
                                IDmg.ReSpeed();
                            }
                        }
                        Destroy(gameObject);
                    }
                    break;
                }
                case Potion.Freeze:
                {
                    if (isGlassBroke==false)
                    {
                        Instantiate(_particleOn, transform.position, Quaternion.identity);
                        isGlassBroke = true;
                    }
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        if (isBroke==false & IDmg!=null)
                        {
                            IDmg.IFreeze(speedReduce,Damege,Objtime);
                        }
                    }
                    isBroke = true;
                    if (time>=Objtime)
                    {
                        Destroy(gameObject);
                    }
                    break;
                }
                case Potion.Fire: 
                {
                    Instantiate(_particleOn, transform.position, Quaternion.identity);
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        if (IDmg!=null)
                        {
                            IDmg.IFire(Damege,DMGTimeRate,StatusTime);
                        }
                    }
                    Destroy(gameObject);
                    break;
                }
                case Potion.Wall:
                {
                    wall.transform.rotation = Quaternion.identity;
                    wall.SetActive(true);
                    if (time>=Objtime)
                    {
                        Destroy(gameObject);
                    }
                    break;
                }
                case Potion.Bomb:
                {
                    Instantiate(_particleOn, transform.position, Quaternion.identity);
                    foreach (var hit in rayHit)
                    {
                        var IDmg = hit.transform.GetComponent<IDamage>();
                        if (IDmg!=null)
                        {
                            IDmg.IImpack(ImpactRannge);
                            IDmg.IHit(Damege);
                        }
                    }
                    Destroy(gameObject);
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
            rigi.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position,Range);
    }
}
