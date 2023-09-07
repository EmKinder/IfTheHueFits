using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPickup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isHolding;
    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
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

    public void AddToBowl()
    {
        Destroy(this.gameObject);
    }

    public bool GetHoldingState()
    {
        return isHolding;
    }
}
