using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InBowl : MonoBehaviour, IPointerDownHandler
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
    List<ItemClass> currentItems = new List<ItemClass>();

    [SerializeField] ItemClass red;
    [SerializeField] ItemClass yellow;
    [SerializeField] ItemClass blue;

    [SerializeField] ItemClass redPaint;
    [SerializeField] ItemClass orangePaint;
    [SerializeField] ItemClass yellowPaint;
    [SerializeField] ItemClass greenPaint;
    [SerializeField] ItemClass bluePaint;
    [SerializeField] ItemClass purplePaint;

    bool paintReady;

    [SerializeField] Sprite[] paintSprites = new Sprite[6];
    string thisPaint;
    AmmoCount ac;

    // Start is called before the first frame update
    void Start()
    {
       // currentItems = new ItemClass[2];
        petalPositions = new Image[2];
        petalPositions[0] = this.gameObject.transform.GetChild(0).GetComponent<Image>();
        petalPositions[1] = this.gameObject.transform.GetChild(1).GetComponent<Image>();
        finalPaint = this.gameObject.transform.GetChild(2).GetComponent<Image>();
        petal1Full = false;
        petal2Full = false;
        startRotation = this.gameObject.transform.rotation;
        finalPaint.enabled = false;
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<NEWInventoryManager>();
        ac = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoCount>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canMix) {
            if (Input.GetKey(KeyCode.Space))
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
                       // petal.enabled = false;
                    }
                    finalPaint.enabled = true;
                    finalPaint.color = new Color(1, 1, 1, 1);
                    Craft();
                }
            }
        }
    }

    public bool CanAddToBowl()
    {
        return !petal1Full || !petal2Full;
    }

    public void PutInBowlPositions(ItemClass item)
    {

        if(petalPositions[0].sprite == null && !petal1Full)
        {
            Debug.Log(item);
            petalPositions[0].sprite = item.itemCraftingIcon;
            currentItems.Add(item);
            petalPositions[0].color = new Color (1, 1, 1, 1);
            canMix = true;
        }
        else if(petalPositions[1].sprite == null & !petal2Full)
        {
            Debug.Log(item);
            petalPositions[1].sprite = item.itemCraftingIcon;
            currentItems.Add(item);
            petalPositions[1].color = new Color(1, 1, 1, 1);
            canMix = true;
        }
    }

    private void Craft()
    {
        if (currentItems.Contains(red) && currentItems.Contains(blue))
        {
            finalPaint.sprite = paintSprites[5];
            thisPaint = "Purple";
        }
        else if (currentItems.Contains(red) && currentItems.Contains(yellow))
        {
            finalPaint.sprite = paintSprites[1];
            thisPaint = "Orange";
        }
        else if (currentItems.Contains(blue) && currentItems.Contains(yellow))
        {
            finalPaint.sprite = paintSprites[3];
            thisPaint = "Green";
        }
        else if (currentItems.Contains(red))
        {
            finalPaint.sprite = paintSprites[0];
            thisPaint = "Red";
        }
        else if (currentItems.Contains(yellow))
        {
            finalPaint.sprite = paintSprites[2];
            thisPaint = "Yellow";
        }
        else if (currentItems.Contains(blue))
        {
            finalPaint.sprite = paintSprites[4];
            thisPaint = "Blue";
        }
        paintReady = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (paintReady)
        {
            if(thisPaint == "Red")
            {
                inventory.AddItem(redPaint, 5);
                inventory.RemoveItem(red, 1);
                ac.addAmmoCount("Red", 5);

            }
            if (thisPaint == "Orange")
            {
                inventory.AddItem(orangePaint, 5);
                inventory.RemoveItem(red, 1);
                inventory.RemoveItem(yellow, 1);
                ac.addAmmoCount("Orange", 5);

            }
            if (thisPaint == "Yellow")
            {
                inventory.AddItem(yellowPaint, 5);
                inventory.RemoveItem(yellow, 1);
                ac.addAmmoCount("Yellow", 5);

            }
            if (thisPaint == "Green")
            {
                inventory.AddItem(greenPaint, 5);
                inventory.RemoveItem(yellow, 1);
                inventory.RemoveItem(blue, 1);
                ac.addAmmoCount("Green", 5);

            }
            if (thisPaint == "Blue")
            {
                inventory.AddItem(bluePaint, 5);
                inventory.RemoveItem(blue, 1);
                ac.addAmmoCount("Blue", 5);

            }
            if (thisPaint == "Purple")
            {
                inventory.AddItem(purplePaint, 5);
                inventory.RemoveItem(red, 1);
                inventory.RemoveItem(blue, 1);
                ac.addAmmoCount("Purple", 5);

            }


            finalPaint.sprite = null;
            finalPaint.color = new Color(1, 1, 1, 0);
            currentItems.Clear();
            Debug.Log("Updated Inventory");
            foreach(KeyValuePair<ItemClass, int> inv in inventory.itemsInInventory)
            {
                Debug.Log(inv.Key + " - " + inv.Value);
            }
            finalPaint.enabled = false;
            thisPaint = null;
            paintReady = false;
            petal1Full = false;
            petal2Full = false;
        }

    }
}
