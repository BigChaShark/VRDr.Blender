using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    
    
    
    [SerializeField]
    public AudioSource _startSound,_switch1,_switch2,_switch3,_mixPotion,_click,_throwpotion,_backGround,wait;
    
    
    public bool gamestarT= false,backgrounD= false,switcH1= false,switcH2= false,switcH3= false,miX= false,clicK= false,throwPotion = false;
    public static Soundmanager sM;
    void Start()
    {
        sM = this;
    }

    
    
    void Update()
    {
       
    }

    
    public  void Gamestart()
    {
        _startSound.Play();
    }
     
    public void PlaybackGround()
    {
        wait.Pause();
        wait.Stop();
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
    public void OnWait()
    {
        _backGround.Pause();
        _backGround.Stop();
        wait.Play();
    }
    
    
    
   
}
