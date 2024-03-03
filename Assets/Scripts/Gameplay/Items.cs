using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public bool inSlot;
    public Vector3 slotRotation = Vector3.zero;
    public Slot currentSlot;
    public OVRGrabbable itemGrababble;

    private void Start()
    {
        itemGrababble=GetComponent<OVRGrabbable>();
    }
    private void Update()
    {
        
        if (itemGrababble.allowOffhandGrab && inSlot && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            GetComponentInParent<Slot>().ItemInSlot = null;           
            transform.parent = null;
            GetComponent<Items>().inSlot = false;
            GetComponent<Items>().currentSlot.ResetColor();
            GetComponent<Items>().currentSlot=null;



            

        }
    }
}
