using System.Collections;
using UnityEngine;

public class ItemClass  : ScriptableObject
{
    [Header("Item")]

    public string itemName;
    public Sprite itemIcon;
    public bool isStackable = true;

    public virtual ItemClass GetItem()
    {
        return this;
    }
    public virtual AmmoClass GetAmmo()
    {
        return null; 
    }
    public virtual ResourceClass GetResource()
    {
        return null;
    }
}
