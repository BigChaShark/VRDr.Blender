using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VRMovement : MonoBehaviour
{
    [SerializeField] private Transform rightHand;
    public LineRenderer lineRent;
    [SerializeField] private float clickRange;
    bool isIndexTrigger;
   
    private Vector3 tarGetPoint;
    private bool isHit;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lineRent.enabled)
        { 
            lineRent.SetPosition(0,rightHand.position);
            lineRent.SetPosition(1,rightHand.position+ (rightHand.forward*clickRange));
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
        //Shoot
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.5f && lineRent.enabled==false)
        {
            lineRent.enabled = true;
        }
        else if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.5f && lineRent.enabled)
        {
            
            lineRent.enabled = false;
        }
    }
}
