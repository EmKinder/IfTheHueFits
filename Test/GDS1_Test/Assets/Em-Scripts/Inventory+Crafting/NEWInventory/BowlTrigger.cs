using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlTrigger : MonoBehaviour
{
    InBowl inBowl;
    // Start is called before the first frame update
    void Start()
    {
        inBowl = this.gameObject.transform.GetChild(0).GetComponent<InBowl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "SelectableItem")
        {
            Debug.Log("Triggering");
            InventoryPickup thisObject = collision.GetComponent<InventoryPickup>();
            if (!thisObject.GetHoldingState())
            {
                thisObject.AddToBowl(inBowl);
            }
        }
    }
}
