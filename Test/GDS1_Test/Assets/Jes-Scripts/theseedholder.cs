using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theseedholder : MonoBehaviour
{
    [SerializeField]
    private ItemClass item;
    [SerializeField]
    private int quantity;

    public theseedholder()
    {
        item = null;
        quantity = 0;
    }
    public theseedholder(ItemClass _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }

    public theseedholder(ItemClass _item)
    {
        item = _item;

    }

    public theseedholder(theseedholder seed)
    {
        this.item = seed.GetItem();
        this.quantity = seed.GetQuantity();
    }


    public ItemClass GetItem()
    {
        return item;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public void AddQuantity(int _quantity)
    {
        quantity += _quantity;
    }

    public void SubQuantity(int _quantity)
    {
        quantity -= _quantity;
    }

    public void AddItem(ItemClass item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public void Clear()
    {
        this.item = null;
        this.quantity = 0;
    }
}
