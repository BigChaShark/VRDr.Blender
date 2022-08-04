using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    //public GameObject HandDRT;
    private Vector3 forceDir;
    private bool isGrabed;
    private Transform fSelectDir;
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
        forceDir = transform.position - lastPosition;
        lastPosition = transform.position;
        Debug.Log("x");
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
            //Debug.Log("ongrab");
            OnGrabObject();
            bIsActive = true;
        }
        else if (OVRInput.Get(inputActive) < activethresold && bIsActive)
        {
            //Debug.Log("onrelease");
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
        //Debug.Log("ongrab");
        selectedObj.transform.SetParent(holdObject);
        selectedObj.transform.localPosition=Vector3.zero;
        fSelectDir = selectedObj.transform;
        var rigid = selectedObj.GetComponent<Rigidbody>();
        rigid.isKinematic = true;
        isGrabed = true;
    }
    public void OnReleaseObject()
    {
        if (selectedObj == null)
        {
            return;
        }
        //Debug.Log("lineman");
        selectedObj.transform.SetParent(null);
        var rigid = selectedObj.GetComponent<Rigidbody>();
        rigid.isKinematic = false;
        rigid.velocity = forceDir*forcePower;
        if (isGrabed)
        {
            Soundmanager.sM.OnThrow();
            isGrabed = false;
        }
    }
   
}
