using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce;
    public Transform shootPoint;
    public List<GameObject> mandeishons;

    /* void Update()
     {
         if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
         {
             Debug.Log("Hola buenas tardes");
             Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);

         }
     }*/

    void Update()
    {
        if (GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                mandeishons.ForEach(m =>
                {
                    m.SetActive(false);
                });
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);

                }
            }

        }
        else
        {
            mandeishons.ForEach(m =>
            {
                m.SetActive(true);
            });
        }
    }
}
