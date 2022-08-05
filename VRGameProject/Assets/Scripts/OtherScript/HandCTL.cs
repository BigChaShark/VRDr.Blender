using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCTL : MonoBehaviour
{
    public enum HandPriority
    {
        Primary,Secondary
    }

    public HandPriority handPriority;
    
        
    public float inputIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (handPriority == HandPriority.Primary)
        {
            inputIndex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        }

        if (handPriority == HandPriority.Secondary)
        {
            inputIndex = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        }
    }
}
