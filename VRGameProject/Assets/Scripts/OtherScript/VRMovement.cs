using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VRMovement : MonoBehaviour
{
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftHand;
    public LineRenderer lineRentR;
    public LineRenderer lineRentL;
    
    [SerializeField] private float clickRange;
    bool isIndexTrigger;
   
    private Vector3 tarGetPoint;
    private bool isHit;
    private RaycastHit hit;
    public enum HandPriority
    {
          Primary,Secondary
    }
    public HandPriority handPriority;  
    public float inputIndex;
    public float inputThumb;
    public float inputGrip;
    public float inputA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lineRentR.enabled)
        { 
            lineRentR.SetPosition(0,rightHand.position);
            lineRentR.SetPosition(1,rightHand.position+ (rightHand.forward*clickRange));
            isHit = Physics.Raycast(rightHand.position, rightHand.forward, out hit, clickRange);
            //Select
            if (isHit)
            {
                var other = hit.transform.GetComponent<IHit>();
                if (other != null)
                {
                    if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5f && isIndexTrigger==false)
                    {
                        other.IsHit();
                        isIndexTrigger = true;
                    }
                    else if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) < 0.5f && isIndexTrigger)
                    {
                        isIndexTrigger = false;
                    }
                }
            }
            
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.5f && lineRentR.enabled==false)
        {
            lineRentR.enabled = true;
        }
        else if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.5f && lineRentR.enabled)
        {
            lineRentR.enabled = false;
        }
        if (lineRentL.enabled)
        { 
            lineRentL.SetPosition(0,leftHand.position);
            lineRentL.SetPosition(1,leftHand.position+ (leftHand.forward*clickRange));
            isHit = Physics.Raycast(leftHand.position, leftHand.forward, out hit, clickRange);
            //Select
            if (isHit)
            {
                var other = hit.transform.GetComponent<IHit>();
                if (other != null)
                {
                    if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.5f && isIndexTrigger==false)
                    {
                        other.IsHit();
                        isIndexTrigger = true;
                    }
                    else if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) < 0.5f && isIndexTrigger)
                    {
                        isIndexTrigger = false;
                    }
                }
            }
            
        }
        //Shoot
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.5f && lineRentL.enabled==false)
        {
            lineRentL.enabled = true;
        }
        else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.5f && lineRentL.enabled)
        {
            
            lineRentL.enabled = false;
        }
    }
}
