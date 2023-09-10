using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCraftingRecipe", menuName = "Crafting/Recipe")]
public class CraftingRecipeClass : ScriptableObject
{
    [Header("Crafting Recipe")]
    public SlotClass[] inputItems;
    public SlotClass outputItem;
    public AmmoCount ammoCount;

   /* public bool CanCraft(NEWInventoryManager inventory)
    {
        if (inventory.isFull())
        {
            return false;
        }
        for (int i = 0; i < inputItems.Length; i++)
        {
            if(!inventory.Contains(inputItems[i].GetItem(), inputItems[i].GetQuantity()))
            {
                return false;
            }
        }
        return true;
    }*/

    public void Craft(NEWInventoryManager inventory, ItemClass[] inputItems)
    {
        //remove the input items from the inventory 
        for (int i = 0; i < inputItems.Length; i++)
        {
       //     inventory.Remove(inputItems[i].GetItem(), inputItems[i].GetQuantity());
        }
        //add the output item to the inventory 
        inventory.AddItem(outputItem.GetItem(), outputItem.GetQuantity());



    }
}
