using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HandOBJ : MonoBehaviour
{
    public HandCTL handCtl;
    public Animator HandAnimator;
    private GameObject currentAtchObj;
    
    // Start is called before the first frame update
    void Start()
    {
        HandAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }
    

    void UpdateAnimator()
    {
        HandAnimator.SetFloat("Hand",handCtl.inputIndex);
    }
    
}
