using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Invent;
    public GameObject Anchor;
    bool UIActive;

    private void Start()
    {
        Invent.SetActive(false);
        UIActive = false;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            UIActive = !UIActive;
            Invent.SetActive(UIActive);
        }
        if (UIActive)
        {
            Invent.transform.position = Anchor.transform.position;
            Invent.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y -40, 0);
        }
    }
}

