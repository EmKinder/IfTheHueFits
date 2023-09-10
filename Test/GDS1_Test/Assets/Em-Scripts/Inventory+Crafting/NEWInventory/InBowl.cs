using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InBowl : MonoBehaviour
{
    [SerializeField] private List<CraftingRecipeClass> craftingRecipies = new List<CraftingRecipeClass>();
    NEWInventoryManager inventory;
    Image[] petalPositions;
    bool petal1Full;
    bool petal2Full;
    Quaternion startRotation;
    bool canMix;
    Image finalPaint;
    float mixingTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        petalPositions = new Image[2];
        petalPositions[0] = this.gameObject.transform.GetChild(0).GetComponent<Image>();
        petalPositions[1] = this.gameObject.transform.GetChild(1).GetComponent<Image>();
        finalPaint = this.gameObject.transform.GetChild(2).GetComponent<Image>();
        petal1Full = false;
        petal2Full = false;
        startRotation = this.gameObject.transform.rotation;
        finalPaint.enabled = false;
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<NEWInventoryManager>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMix) {
            if (Input.GetKey(KeyCode.W))
            {
                this.gameObject.transform.Rotate(Vector3.back * 100 * Time.deltaTime);
                mixingTimer += Time.deltaTime;
                if(mixingTimer >= 4.5)
                {
                    mixingTimer = 0;
                    canMix = false;
                    foreach(Image petal in petalPositions)
                    {
                        petal.sprite = null;
                        petal.color = new Color(1, 1, 1, 0);
                        petal.enabled = false;
                    }
                    finalPaint.enabled = true;
                    finalPaint.color = new Color(1, 1, 1, 1);
                }
            }
        }
    }

    public bool PutInBowlPositions(ItemClass item)
    {

        if(petalPositions[0].sprite == null && !petal1Full)
        {
            petalPositions[0].sprite = item.itemCraftingIcon;
            petalPositions[0].color = new Color (1, 1, 1, 1);
            canMix = true;
            return true;
        }
        else if(petalPositions[1].sprite == null & !petal2Full)
        {
            petalPositions[1].sprite = item.itemCraftingIcon;
            petalPositions[1].color = new Color(1, 1, 1, 1);
            canMix = true;
            return true;
        }
        return false;
    }

    /*private void Craft(CraftingRecipeClass recipe)
    {
        if (recipe.CanCraft(this))
        {
            recipe.Craft(this);
            if (recipe == craftingRecipies[0])
            {
                redCrafted = true;
            }
            if (recipe == craftingRecipies[2])
            {
                blueCrafted = true;
            }
            if (recipe == craftingRecipies[5])
            {
                purpleCrafted = true;
            }

        }
        else
        {
            cannotCraftBool = true;
            Debug.Log("Cannot craft that item");
        }
    }*/
}
