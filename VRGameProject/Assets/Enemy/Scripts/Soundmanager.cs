using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    
    
    
    [SerializeField]
    public AudioSource _startSound,_switch1,_switch2,_switch3,_mixPotion,_click,_throwpotion,_backGround;
    
    
    public bool gamestarT= false,backgrounD= false,switcH1= false,switcH2= false,switcH3= false,miX= false,clicK= false,throwPotion = false;
    void Start()
    {
       
    }

    
    void Update()
    {
        Debug.Log($"{gamestarT}{backgrounD}{switcH1}{switcH2}{switcH3}{miX}{clicK}{throwPotion}");
        if (gamestarT == true)
        {
         Gamestart();   
        }
        if (backgrounD == true)
        {
            PlaybackGround();
        } 
        if (switcH1 == true)
        {
            pushBotton1();
        } 
        if (switcH2 == true)
        {
            pushBotton2();
        } 
        if (switcH3 == true)
        {
            pushBotton3();
        } 
        if (miX == true)
        {
            MixPoiton();
        } 
        if (clicK == true)
        {
            Onclick();
        } 
        if (throwPotion == true)
        {
            OnThrow();
        }
    }

    
    public void Gamestart()
    {
        _startSound.Play();
    }
     
    public void PlaybackGround()
    {
        _backGround.Play();
    }

    public void pushBotton1()
    {
        _switch1.Play();
    }
    public void pushBotton2()
    {
        _switch2.Play();
    } 
    public void pushBotton3()
    {
        _switch3.Play();
    }
    public void MixPoiton()
    {
        _mixPotion.Play();
    } 
    public void Onclick()
    {
        _click.Play();
    }
    public void OnThrow()
    {
        _throwpotion.Play();
    }
    
    
    
   
}
