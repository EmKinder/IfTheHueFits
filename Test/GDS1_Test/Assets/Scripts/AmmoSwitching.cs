using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSwitching : MonoBehaviour
{
    public int selectedAmmo = 0;
    string ammoString;
    public Image RedCheck;
    public Image OrangeCheck;
    public Image YellowCheck;
    public Image GreenCheck;
    public Image BlueCheck;
    public Image PurpleCheck;
 
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
            Debug.Log("Current Ammo: " + SelectAmmo(selectedAmmo));
        
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
            Debug.Log("Current Ammo: " + SelectAmmo(selectedAmmo));
            
        }
        ammoString = SelectAmmo(selectedAmmo);
    }

    private string SelectAmmo(int thisSelectedAmmo)
    {
        if (selectedAmmo == 0)
        {
            PurpleCheck.enabled = false;
            RedCheck.enabled = true;
            OrangeCheck.enabled = false;
            return "Red";
        }
        if (selectedAmmo == 1)
        {
            RedCheck.enabled = false;
            OrangeCheck.enabled = true;
            YellowCheck.enabled = false;

            return "Orange";
        }
        if (selectedAmmo == 2)
        {
            OrangeCheck.enabled = false;
            YellowCheck.enabled = true;
            GreenCheck.enabled = false;
            return "Yellow";
        }
        if (selectedAmmo == 3)
        {
            YellowCheck.enabled = false;
            GreenCheck.enabled = true;
            BlueCheck.enabled = false;
            return "Green";
        }
        if (selectedAmmo == 4)
        {
            GreenCheck.enabled = false;
            BlueCheck.enabled = true;
            PurpleCheck.enabled = false;
            return "Blue";
        }
        if (selectedAmmo == 5)
        {
            BlueCheck.enabled = false;
            PurpleCheck.enabled = true;
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
