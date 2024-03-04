using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootInput : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float shootForce;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private List<GameObject> controllers;

    void Update()
    {
        // Checks if the gun is grabbed
        if (GetComponent<OVRGrabbable>().isGrabbed || Input.GetKey(KeyCode.R))
        {
            // Checks if the grab button is pressed
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || Input.GetKey(KeyCode.R))
            {
                // Deactivate controllers meshes
                controllers.ForEach(x => x.SetActive(false));

                // Checks if the shooting button is pressed and shoot a bullet
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKey(KeyCode.R))
                    Instantiate(bullet, new(shootPoint.position.x, shootPoint.position.y, shootPoint.position.z), shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.right * shootForce);
            }

        }
        // Activate controllers meshes
        else
            controllers.ForEach(x => x.SetActive(true));
    }
}
