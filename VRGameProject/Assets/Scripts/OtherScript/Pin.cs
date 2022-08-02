using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    private bool isChange = false;

    public bool hit;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.name+transform.eulerAngles.x);
        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(gameObject);
        }

        if (isChange==false && hit && transform.eulerAngles.x>50 | transform.eulerAngles.x<50)
        {
            Debug.Log("IsRotate");
            GameManager.game.score += 1;
            isChange = true;
        }
    }
}
