using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSwitching : MonoBehaviour
{
    public int selectedAmmo = 0;
    string ammoString;
    public Text RedCheck;
    public Text OrangeCheck;
    public Text YellowCheck;
    public Text GreenCheck;
    public Text BlueCheck;
    public Text PurpleCheck;
    int ammoQuantity;
    public AmmoClass redAmmo;
    public AmmoClass orangeAmmo;
    public AmmoClass yellowAmmo;
    public AmmoClass greenAmmo;
    public AmmoClass blueAmmo;
    public AmmoClass purpleAmmo;
    public InventoryManager inventory;
    public AmmoCount ammoCount;


    void Start()
    {
        RedCheck.enabled = false;
        OrangeCheck.enabled = false;
        YellowCheck.enabled = false;
        GreenCheck.enabled = false;
        BlueCheck.enabled = false;
        PurpleCheck.enabled = false;

        SelectAmmo(selectedAmmo);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedAmmo >= 5)
            {
                selectedAmmo = 0;

            }
            else
            {
                selectedAmmo++;
            }
         //   Debug.Log("Current Ammo: " + SelectAmmo(selectedAmmo));
        
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedAmmo <= 0)
            {
                selectedAmmo = 5;

            }
            else
            {
                selectedAmmo--;
            }
          //  Debug.Log("Current Ammo: " + SelectAmmo(selectedAmmo));
            
        }
        ammoString = SelectAmmo(selectedAmmo);
    }

    private string SelectAmmo(int thisSelectedAmmo)
    {
        if (selectedAmmo == 0)
        {
            PurpleCheck.enabled = false;
            RedCheck.enabled = true;
            RedCheck.text = ammoCount.getAmmoCount("Red").ToString();
            OrangeCheck.enabled = false;
            return "Red";
        }
        if (selectedAmmo == 1)
        {
            RedCheck.enabled = false;
            OrangeCheck.enabled = true;
            OrangeCheck.text = ammoQuantity.ToString();
            YellowCheck.enabled = false;

            return "Orange";
        }
        if (selectedAmmo == 2)
        {
            OrangeCheck.enabled = false;
            YellowCheck.enabled = true;
            YellowCheck.text = ammoQuantity.ToString();
            GreenCheck.enabled = false;
            return "Yellow";
        }
        if (selectedAmmo == 3)
        {
            YellowCheck.enabled = false;
            GreenCheck.enabled = true;
            GreenCheck.text = ammoQuantity.ToString();
            BlueCheck.enabled = false;
            return "Green";
        }
        if (selectedAmmo == 4)
        {
            GreenCheck.enabled = false;
            BlueCheck.enabled = true;
            BlueCheck.text = ammoQuantity.ToString();
            PurpleCheck.enabled = false;
            return "Blue";
        }
        if (selectedAmmo == 5)
        {
            BlueCheck.enabled = false;
            PurpleCheck.enabled = true;
            PurpleCheck.text = ammoQuantity.ToString();
            RedCheck.enabled = false;

            return "Purple";
        }
        return null;
    }

    public string GetAmmoType()
    {
        return ammoString;
    }
}
