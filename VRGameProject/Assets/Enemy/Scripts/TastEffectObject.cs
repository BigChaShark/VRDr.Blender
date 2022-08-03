using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastEffectObject : MonoBehaviour
{
    
    [SerializeField] float _timedestroy;
    void Start()
    {
       
        Destroy(gameObject,_timedestroy);
    }

  
   
}
