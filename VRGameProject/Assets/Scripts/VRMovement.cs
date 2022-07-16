using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRMovement : MonoBehaviour
{
    public enum  MoveType
    {
        Continue,
        Teleport
    }

    public MoveType moveType;

    [SerializeField]
    private float teleportSpeed;
    [SerializeField] private float Speed;
    [SerializeField] private Transform eyeTransform;
    [SerializeField] private Transform rightHand;
    public LineRenderer lineRent;
    [SerializeField] private float teleportRange;
    bool isIndexTrigger;
    [SerializeField] private Image image;
    [SerializeField]private float tarGetAlpha; 
    private Vector3 tarGetPoint;
    private bool isHit;
    private bool isFade = false;

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        tarGetPoint = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (moveType)
        {
            case MoveType.Continue :
            {
                Vector3 velocity = ((OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y * eyeTransform.forward)+ 
                                    (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x * eyeTransform.right)) * Speed ;
                velocity.y -= 10;
                characterController.Move(velocity * Time.deltaTime);
                break;
            }
            case MoveType.Teleport:
            {
                if (lineRent.enabled)
                {
                    lineRent.SetPosition(0,rightHand.position);
                    lineRent.SetPosition(1,rightHand.position+ (rightHand.forward*teleportRange));
                    if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5f && isIndexTrigger==false)
                    {
                        Vector3 originPoint = rightHand.position;
                        Vector3 dir = rightHand.forward;
                        RaycastHit hit;
                        isHit = Physics.Raycast(originPoint, dir, out hit ,teleportRange);
                        if (isHit)
                        {
                            tarGetPoint = hit.point;
                            isFade = true;
                        }
                        isIndexTrigger = true;
                    }
                    else if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) < 0.5f && isIndexTrigger)
                    {
                        isIndexTrigger = false;
                        //isFade = false;
                    }
                }
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.5f && lineRent.enabled==false)
                {
                    lineRent.enabled = true;
                }
                else if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.5f && lineRent.enabled)
                {
                    lineRent.enabled = false;
                }

                Vector3 directionMove = tarGetPoint - transform.position;
                Debug.Log(directionMove.magnitude);
                if (directionMove.magnitude < 1f)
                {
                    isFade = false;
                }
                characterController.Move(directionMove * teleportSpeed * Time.deltaTime);
                if (isFade)
                {
                    Color currenColor = image.color;
                    currenColor.a += (tarGetAlpha*5) * Time.deltaTime;
                    //Debug.Log(currenColor.a);
                    if (currenColor.a >= 255)
                    {
                        currenColor.a = 255;
                    }
                    image.color = currenColor;
                }
                if(isFade == false)
                {
                    Color currenColor = image.color;
                    currenColor.a -= tarGetAlpha * Time.deltaTime;
                    //Debug.Log(currenColor.a);
                    if (currenColor.a <= 0)
                    {
                        currenColor.a = 0;
                    }
                    image.color = currenColor;
                }
                break;
            }
        }
    }

    
}
