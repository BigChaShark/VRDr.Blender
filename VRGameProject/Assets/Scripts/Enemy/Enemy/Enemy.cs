using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

       [SerializeField] private FileSo enemyType;
       
       
       [SerializeField] Transform target;

       [SerializeField] private float destroyLange;
        void Awake()
        {



          
        }
        

        public void IHit(int Damage)
        {
            
        }

        public void IPoison(int Damage)
        {
            
        }
        public void IImpack(int Damage ,int Range)
        {
            
        }
        public void IFreeze(int Damage)
        {
            
        }
        void Update()
        {
            
            var step =  enemyType.speed * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

         
            if (Vector3.Distance(transform.position, target.position) < destroyLange)
            {
                Destroy(gameObject);
              
            }
            if (Vector3.Distance(transform.position, target.position) < 100f)
            {Debug.Log($" distant{Vector3.Distance(transform.position, target.position)}");}
        }
    
}
