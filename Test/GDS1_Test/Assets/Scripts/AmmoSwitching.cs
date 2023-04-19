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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedAmmo = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedAmmo = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedAmmo = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedAmmo = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedAmmo = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedAmmo = 5;
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
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;
            return "Red";
        }
        if (selectedAmmo == 1)
        {
            RedCheck.enabled = false;
            OrangeCheck.enabled = true;
            OrangeCheck.text = ammoCount.getAmmoCount("Orange").ToString();
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;


            return "Orange";
        }
        if (selectedAmmo == 2)
        {
            RedCheck.enabled = false;
            OrangeCheck.enabled = false;
            YellowCheck.enabled = true;
            YellowCheck.text = ammoCount.getAmmoCount("Yellow").ToString();
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;
            return "Yellow";
        }
        if (selectedAmmo == 3)
        {
            RedCheck.enabled = false;
            OrangeCheck.enabled = false;
            YellowCheck.enabled = false;
            GreenCheck.enabled = true;
            GreenCheck.text = ammoCount.getAmmoCount("Green").ToString();
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;
            return "Green";
        }
        if (selectedAmmo == 4)
        {
            RedCheck.enabled = false;
            OrangeCheck.enabled = false;
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = true;
            BlueCheck.text = ammoCount.getAmmoCount("Blue").ToString();
            PurpleCheck.enabled = false;
            return "Blue";
        }
        if (selectedAmmo == 5)
        {
            OrangeCheck.enabled = false;
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = true;
            PurpleCheck.text = ammoCount.getAmmoCount("Purple").ToString();
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
