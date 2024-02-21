
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    public Image slotImage;
    Color originalColor=Color.red;
    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (ItemInSlot != null) return;
        GameObject obj = other.gameObject;
    
        if (obj.GetComponent<Items>() == null) return;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            InsertItem(obj);
        }

    }

    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;

        // Ponemos el objeto Item como hijo del slot.

        obj.transform.SetParent(gameObject.transform, true);

        // Ponemos a cero la posición relativa al transform del Slot

        obj.transform.localPosition = new Vector3(-0.2f,-0.1f,0);
        // Ponemos los angulos definidos en el Item. 

        obj.transform.localEulerAngles = obj.GetComponent<Items>().slotRotation;
        obj.GetComponent<Items>().inSlot = true;
        obj.GetComponent<Items>().currentSlot = this;
        ItemInSlot = obj;
        slotImage.color = Color.gray;
    }
    public void ResetColor()
    {
        slotImage.color = originalColor;
    }
   
}




