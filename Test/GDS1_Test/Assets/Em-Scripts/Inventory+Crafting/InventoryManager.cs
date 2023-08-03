using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<CraftingRecipeClass> craftingRecipies = new List<CraftingRecipeClass>();
    [SerializeField] private GameObject itemCursor;
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private GameObject seedmeed;
    [SerializeField] private SlotClass[] startingItems;
    [SerializeField] private SlotClass[] items;


    private GameObject[] slots;
    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;
    bool isMovingItem;
    public AmmoCount ammoCount;
    public ItemClass onStartRedResource;
    public ItemClass onStartBlueResource;
    public bool blueCrafted;
    public bool redCrafted;
    public bool purpleCrafted;

    public Button RedCraftButton;
    public Button OrangeCraftButton;
    public Button YellowCraftButton;
    public Button GreenCraftButton;
    public Button BlueCraftButton;
    public Button PurpleCraftButton;
    AudioSource audio;
    public AudioClip craftedSound;
    public Image cannotCraft;
    bool cannotCraftBool;
    float timer = 0.0f;

    //jes trying something out:
    public SeedCount seedCount;

    private void Start()
    {
        if (slotHolder != null)
        {
            slots = new GameObject[slotHolder.transform.childCount];
            items = new SlotClass[slots.Length];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new SlotClass();
            }
            for (int i = 0; i < startingItems.Length; i++)
            {
                items[i] = startingItems[i];
            }
            //set all the slots 
            for (int i = 0; i < slotHolder.transform.childCount; i++)
            {
                slots[i] = slotHolder.transform.GetChild(i).gameObject;
            }

            Add(onStartRedResource, 2);
            Add(onStartBlueResource, 2);
            RefreshUI();
        }

        RedCraftButton.onClick.AddListener(RedCraftClick);
        OrangeCraftButton.onClick.AddListener(OrangeCraftClick);
        YellowCraftButton.onClick.AddListener(YellowCraftClick);
        GreenCraftButton.onClick.AddListener(GreenCraftClick);
        BlueCraftButton.onClick.AddListener(BlueCraftClick);
        PurpleCraftButton.onClick.AddListener(PurpleCraftClick);

        audio = this.GetComponent<AudioSource>();

        redCrafted = false;
        blueCrafted = false;
        cannotCraftBool = false;
        cannotCraft.enabled = false;

    }

    private void Update()
    {

        if (itemCursor != null)
        {
            itemCursor.SetActive(isMovingItem);
            itemCursor.transform.position = Input.mousePosition;
            if (isMovingItem)
                itemCursor.GetComponent<Image>().sprite = movingSlot.GetItem().itemIcon;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //find the cloests slot(slot we clicked on)
            if (isMovingItem)
            {
                EndItemMove();
            }
            else
            {
                BeginItemMove();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (isMovingItem)
            {
                EndItemMove_Single();
            }
            else
            {
                BeginItemMove_Half();
            }
        }

        if (cannotCraftBool)
        {
            cannotCraft.enabled = true;
            timer += Time.deltaTime;
            if(timer >= 1.0f)
            {
                cannotCraft.enabled = false;
                timer = 0;
                cannotCraftBool = false;
                
            }
        }
    }

    public void gameReset()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            items[i].Clear();
        }
        Add(onStartRedResource, 2);
        Add(onStartBlueResource, 2);
        RefreshUI();

    }
    #region Crafting
    void RedCraftClick()
    {
        Craft(craftingRecipies[0]);

    }
    void YellowCraftClick()
    {
        if (PlayerPrefs.GetInt("Current") >= 5)
        {
            Craft(craftingRecipies[1]);
        }

    }
    void BlueCraftClick()
    {
        Craft(craftingRecipies[2]);

    }
    void OrangeCraftClick()
    {
        if (PlayerPrefs.GetInt("Current") >= 6)
        {
            Craft(craftingRecipies[3]);
        }
    }
    void GreenCraftClick()
    {
        if (PlayerPrefs.GetInt("Current") >= 6)
        {
            Craft(craftingRecipies[4]);
        }
    }
    void PurpleCraftClick()
    {
        if(PlayerPrefs.GetInt("Current") >= 4) { 
            Craft(craftingRecipies[5]);
        }

    }
    #endregion

    #region Inventory Utils
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].GetQuantity() + "";
                else
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
        }
    }

    public bool Add(ItemClass item, int quantity)
    {

        SlotClass slot = Contains(item);
        
        if (slot != null && slot.GetItem().isStackable)
        {
            slot.AddQuantity(quantity);
            if (ammoCount != null)
            {
                
                if (slot.GetItem().itemName == "RedAmmo")
                {
                    ammoCount.addAmmoCount("Red", quantity);
                    Debug.Log(ammoCount.getAmmoCount("Red"));
                }
                if (slot.GetItem().itemName == "OrangeAmmo")
                {
                    ammoCount.addAmmoCount("Orange", quantity);
                    Debug.Log(ammoCount.getAmmoCount("Orange"));
                }
                if (slot.GetItem().itemName == "YellowAmmo")
                {
                    ammoCount.addAmmoCount("Yellow", quantity);
                    Debug.Log(ammoCount.getAmmoCount("Yellow"));
                }
                if (slot.GetItem().itemName == "GreenAmmo")
                {
                    ammoCount.addAmmoCount("Green", quantity);
                    Debug.Log(ammoCount.getAmmoCount("Green"));
                }
                if (slot.GetItem().itemName == "BlueAmmo")
                {
                    ammoCount.addAmmoCount("Blue", quantity);
                    Debug.Log(ammoCount.getAmmoCount("Blue"));
                }
                if (slot.GetItem().itemName == "PurpleAmmo")
                {
                    ammoCount.addAmmoCount("Purple", quantity);
                    Debug.Log(ammoCount.getAmmoCount("Purple"));
                }
            }
            //jes trying something out
            if(seedCount != null)
            {
                if (slot.GetItem().itemName == "RedSeed")
                {
                    seedCount.addSeedCount("Red", quantity);
                    Debug.Log(seedCount.getSeedCount("Red"));
                }
                if (slot.GetItem().itemName == "BlueSeed")
                {
                    seedCount.addSeedCount("Blue", quantity);
                    Debug.Log(seedCount.getSeedCount("Blue"));
                }
                if (slot.GetItem().itemName == "YellowSeed")
                {
                    seedCount.addSeedCount("Yellow", quantity);
                    Debug.Log(seedCount.getSeedCount("Yellow"));
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null)
                {
                    items[i].AddItem(item, quantity);
                    if (item.GetItem().itemName == "RedAmmo")
                    {
                        ammoCount.addAmmoCount("Red", quantity);
                        Debug.Log(ammoCount.getAmmoCount("Red"));
                    }
                    if (item.GetItem().itemName == "OrangeAmmo")
                    {
                        ammoCount.addAmmoCount("Orange", quantity);
                        Debug.Log(ammoCount.getAmmoCount("Orange"));
                    }
                    if (item.GetItem().itemName == "YellowAmmo")
                    {
                        ammoCount.addAmmoCount("Yellow", quantity);
                        Debug.Log(ammoCount.getAmmoCount("Yellow"));
                    }
                    if (item.GetItem().itemName == "GreenAmmo")
                    {
                        ammoCount.addAmmoCount("Green", quantity);
                        Debug.Log(ammoCount.getAmmoCount("Green"));
                    }
                    if (item.GetItem().itemName == "BlueAmmo")
                    {
                        ammoCount.addAmmoCount("Blue", quantity);
                        Debug.Log(ammoCount.getAmmoCount("Blue"));
                    }
                    if (item.GetItem().itemName == "PurpleAmmo")
                    {
                        ammoCount.addAmmoCount("Purple", quantity);
                        Debug.Log(ammoCount.getAmmoCount("Purple"));
                    }
                    //jes trying something 
                    if (item.GetItem().itemName == "RedSeed")
                    {
                        seedCount.addSeedCount("Red", quantity);
                        Debug.Log(seedCount.getSeedCount("Red"));
                    }
                    if (item.GetItem().itemName == "BlueSeed")
                    {
                        seedCount.addSeedCount("Blue", quantity);
                        Debug.Log(seedCount.getSeedCount("Blue"));
                    }
                    if (item.GetItem().itemName == "YellowSeed")
                    {
                        seedCount.addSeedCount("Yellow", quantity);
                        Debug.Log(seedCount.getSeedCount("Yellow"));
                    }
                    //

                    break;
                }
            }
        }
        RefreshUI();
        return true;
    }

   

    public bool Remove(ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() >= 1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }

                items[slotToRemoveIndex].Clear();
            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

    

    public bool Remove(ItemClass item, int quantity)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(quantity);
            }
            else
            {
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }

                items[slotToRemoveIndex].Clear();
            }
        }
        else
        {

            return false;
        }

        RefreshUI();
        return true;
    }

    
    public SlotClass Contains(ItemClass item)
    {
        if (slotHolder != null)
        {

        
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == item)
            {
                return items[i];
            }
        }
    }
        return null;
    }

   
    public bool Contains(ItemClass item, int quantity)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == item && items[i].GetQuantity() >= quantity)
            {
                return true;
            }
        }
        return false;
    }
    #endregion

    #region Moving Stuff
    private bool BeginItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null || originalSlot.GetItem() == null)
        {
            return false;
        }
        movingSlot = new SlotClass(originalSlot);
        originalSlot.Clear();
        RefreshUI();
        isMovingItem = true;
        return true;
    }

    private bool BeginItemMove_Half()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null || originalSlot.GetItem() == null)
        {
            return false;
        }
        movingSlot = new SlotClass(originalSlot.GetItem(), Mathf.CeilToInt(originalSlot.GetQuantity() / 2f));
        originalSlot.SubQuantity(Mathf.CeilToInt(originalSlot.GetQuantity() / 2f));
        if (originalSlot.GetQuantity() == 0)
        {
            originalSlot.Clear();
        }
        RefreshUI();
        isMovingItem = true;
        return true;
    }

    private bool EndItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null)
        {
            Add(movingSlot.GetItem(), movingSlot.GetQuantity());
            movingSlot.Clear();
        }
        else
        {


            if (originalSlot.GetItem() != null)
            {
                if (originalSlot.GetItem() == movingSlot.GetItem()) //they are same item, stack
                {
                    if (originalSlot.GetItem().isStackable)
                    {
                        originalSlot.AddQuantity(movingSlot.GetQuantity());
                        movingSlot.Clear();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    tempSlot = new SlotClass(originalSlot); //a = b
                    originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity()); //b = c
                    movingSlot.AddItem(tempSlot.GetItem(), tempSlot.GetQuantity()); // a = c
                    RefreshUI();
                    return true;
                }
            }
            else //place item as usual
            {
                originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity());
                movingSlot.Clear();
            }
        }
        isMovingItem = false;
        RefreshUI();
        return true;
    }

    private bool EndItemMove_Single()
    {
        if (slotHolder != null)
        {
            originalSlot = GetClosestSlot();
            if (originalSlot == null)
            {
                return false;
            }
            if (originalSlot.GetItem() != null && originalSlot.GetItem() != movingSlot.GetItem())
            {
                return false;
            }
            movingSlot.SubQuantity(1);
            if (originalSlot.GetItem() != null && originalSlot.GetItem() == movingSlot.GetItem())
            {
                originalSlot.AddQuantity(1);
            }
            else
            {
                originalSlot.AddItem(movingSlot.GetItem(), 1);
            }


            if (movingSlot.GetQuantity() < 1)
            {
                isMovingItem = false;
                movingSlot.Clear();
            }
            else
            {
                isMovingItem = true;
            }

        }
        RefreshUI();
        return true;
    }

    private SlotClass GetClosestSlot()
    {
        if (slotHolder != null)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 32)
                {
                    return items[i];
                }
            }
        }

        return null;
    }
    #endregion

    public bool isFull()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == null)
            {
                return false;
            }
        }
        return true;
    }

    private void Craft(CraftingRecipeClass recipe)
    {
        if (recipe.CanCraft(this))
        {
            recipe.Craft(this);
            audio.clip = craftedSound;
            audio.Play();
            if(recipe == craftingRecipies[0])
            {
                redCrafted = true;
            }
            if(recipe == craftingRecipies[2])
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
    }

 
}
