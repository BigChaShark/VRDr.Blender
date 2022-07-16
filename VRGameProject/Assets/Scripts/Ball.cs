using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Ball : MonoBehaviour,IsGrab
    {
        private Rigidbody rg;
        private void Start()
        {
            rg = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Destroy(gameObject);
            }
        }

        public void isGrab()
        {
            //rg.isKinematic = true;
        }
        public void isNonGrab()
        {
            //rg.isKinematic = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var pin = collision.gameObject.GetComponent<Pin>();
            if (pin)
            {
                pin.hit = true;
            }
        }
    }
}