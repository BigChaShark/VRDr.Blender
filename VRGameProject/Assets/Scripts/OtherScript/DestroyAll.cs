using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        var en = other.transform.GetComponent<IDamage>();
        if (en!=null)
        {
            GameManager.game.score += 1;
            GameManager.game.scoreForwin += 1;
        }
        Destroy(other.gameObject);
    }
}
