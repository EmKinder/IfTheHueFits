using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPickup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isHolding;
    ItemClass thisItem;
    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
      //  this.gameObject.get
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            transform.position = Input.mousePosition;
        }
    }

    private void OnMouseDown()
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Should be put down");
        isHolding = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Should be holding");
        isHolding = true;
    }

    public void AddToBowl(InBowl thisBowl)
    {
        if (thisBowl.PutInBowlPositions(thisItem))
        {
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Bowl Full");
        }

    }

    public bool GetHoldingState()
    {
        return isHolding;
    }

    public void SetThisItem(ItemClass item)
    {
        thisItem = item;
    }
}
