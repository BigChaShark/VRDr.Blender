using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pinObj;
    [SerializeField] private Transform[] Spawn;
    private GameObject pin;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < Spawn.Length; )
            {
                pin = Instantiate(pinObj, Spawn[i].transform);
                i++;
            }
        }

    }
}
