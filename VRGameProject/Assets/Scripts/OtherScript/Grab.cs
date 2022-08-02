using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    public GameObject HandDRT;
    private Vector3 forceDir;
    [SerializeField]private int forcePower;
    public OVRInput.Axis1D inputActive;
    public Transform holdObject;
    public List<string> ignorTags;
    public float activethresold;
    public bool bIsActive;
    public GameObject selectedObj;


    private Vector3 lastPosition;
    void Update()
    {
        UpdateGrabObJ();
        forceDir = this.transform.position - lastPosition;
        lastPosition = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var tag in ignorTags)
        {
            if (other.tag == tag)
            {
                return;
            }
        }

        selectedObj = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject==selectedObj)
        {
            selectedObj = null;
        }
    }

    private void UpdateGrabObJ()
    {
        if (OVRInput.Get(inputActive) >= activethresold && !bIsActive)
        {
            OnGrabObject();
            bIsActive = true;
        }
        else if (OVRInput.Get(inputActive) < activethresold && bIsActive)
        {
            OnReleaseObject();
            bIsActive = false;
        }
    }

    public void OnGrabObject()
    {
        if (selectedObj == null)
        {
            return;
        }
        selectedObj.transform.SetParent(holdObject);
        var k = selectedObj.GetComponent<IsGrab>();
        if (k != null)
        {
            k.isGrab();
        }
       
        selectedObj.transform.localPosition=Vector3.zero;
        var rigid = selectedObj.GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }
    public void OnReleaseObject()
    {
        if (selectedObj == null)
        {
            return;
        }
        selectedObj.transform.SetParent(null);
        var k = selectedObj.GetComponent<IsGrab>();
        if (k != null)
        {
            k.isNonGrab();
        }
       
        var rigid = selectedObj.GetComponent<Rigidbody>();
        rigid.isKinematic = false;
        rigid.velocity = forceDir*forcePower;

    }
   
}
