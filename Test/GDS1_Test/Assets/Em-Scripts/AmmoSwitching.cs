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
    public Image ammoBackground;
    public Sprite redBackground;
    public Sprite orangeBackground;
    public Sprite yellowBackground;
    public Sprite greenBackground;
    public Sprite blueBackground;
    public Sprite purpleBackground;

    public Material redMat;
    public Material orangeMat;
    public Material yellowMat;
    public Material greenMat;
    public Material blueMat;
    public Material purpleMat;

    MeshRenderer paintTip;


    void Start()
    {
 
            RedCheck.enabled = false;
            OrangeCheck.enabled = false;
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;

            SelectAmmo(selectedAmmo);

        if (paintTip == null)
        {
            paintTip = GameObject.FindGameObjectWithTag("PlayerAttackPoint").GetComponent<MeshRenderer>();
            if (paintTip)
            {
                Debug.Log("Paint Tip Found");
                paintTip.material = redMat;
            }
        }




    }

    // Update is called once per frame
    void Update()
    {
        if (paintTip == null) { 
            paintTip = GameObject.FindGameObjectWithTag("PlayerAttackPoint").GetComponent<MeshRenderer>();
            if (paintTip) { 
                Debug.Log("Paint Tip Found");
                }
            }



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
            ammoBackground.sprite = redBackground;
            PurpleCheck.enabled = false;
            RedCheck.enabled = true;
            RedCheck.text = ammoCount.getAmmoCount("Red").ToString();
            OrangeCheck.enabled = false;
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;
        //    paintTip.material = redMat;
            return "Red";
        }
        if (selectedAmmo == 1)
        {
            ammoBackground.sprite = orangeBackground;
            RedCheck.enabled = false;
            OrangeCheck.enabled = true;
            OrangeCheck.text = ammoCount.getAmmoCount("Orange").ToString();
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;
            paintTip.material = orangeMat;


            return "Orange";
        }
        if (selectedAmmo == 2)
        {
            ammoBackground.sprite = yellowBackground;
            RedCheck.enabled = false;
            OrangeCheck.enabled = false;
            YellowCheck.enabled = true;
            YellowCheck.text = ammoCount.getAmmoCount("Yellow").ToString();
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;
            paintTip.material = yellowMat;
            return "Yellow";
        }
        if (selectedAmmo == 3)
        {
            ammoBackground.sprite = greenBackground;
            RedCheck.enabled = false;
            OrangeCheck.enabled = false;
            YellowCheck.enabled = false;
            GreenCheck.enabled = true;
            GreenCheck.text = ammoCount.getAmmoCount("Green").ToString();
            BlueCheck.enabled = false;
            PurpleCheck.enabled = false;
            paintTip.material = greenMat;
            return "Green";
        }
        if (selectedAmmo == 4)
        {
            ammoBackground.sprite = blueBackground;
            RedCheck.enabled = false;
            OrangeCheck.enabled = false;
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = true;
            BlueCheck.text = ammoCount.getAmmoCount("Blue").ToString();
            PurpleCheck.enabled = false;
            paintTip.material = blueMat;
            return "Blue";
        }
        if (selectedAmmo == 5)
        {
            ammoBackground.sprite = purpleBackground;
            OrangeCheck.enabled = false;
            YellowCheck.enabled = false;
            GreenCheck.enabled = false;
            BlueCheck.enabled = false;
            PurpleCheck.enabled = true;
            PurpleCheck.text = ammoCount.getAmmoCount("Purple").ToString();
            RedCheck.enabled = false;
            paintTip.material = purpleMat;
            return "Purple";
        }
        return null;
    }

    public string GetAmmoType()
    {
        return ammoString;
    }
    

}
