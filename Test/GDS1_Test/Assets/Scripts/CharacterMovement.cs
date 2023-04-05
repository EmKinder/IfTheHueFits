using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float walkSpeed = 4.0f;
    float rotationSpeed = 200.0f;
    Animator anim;
    float shootTimerLength = 1.5f;
    float shootTimer = 0;
    bool canShoot;
    public Shooting shooting;
    public AmmoCount ac;
    public AmmoSwitching asw;
    string currentPaintShooting;
    //public InventoryManager inventory;
    
   
   // public AmmoSwitching ammo;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        canShoot = true;
        ac = GameObject.FindGameObjectWithTag("Manager").GetComponent<AmmoCount>();
        asw = GameObject.FindGameObjectWithTag("Manager").GetComponent<AmmoSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        float trans = Input.GetAxis("Vertical") * walkSpeed;
        trans *= Time.deltaTime;
        transform.Translate(0, 0, trans);

        float rot = Input.GetAxis("Horizontal") * rotationSpeed;
        rot *= Time.deltaTime;
        transform.Rotate(0, rot, 0);

        if (trans != 0)
        {
            anim.SetBool("isWalking", true);
            if (trans > 0)
            {

                anim.SetFloat("AnimSpeed", 1.0f);


            }
            else
            {
                anim.SetFloat("AnimSpeed", -1.0f);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }



        if (Input.GetKeyDown(KeyCode.LeftShift) && canShoot == true)
        {
            if (asw.GetAmmoType() == "Red" && ac.getAmmoCount("Red") > 0
                || asw.GetAmmoType() == "Orange" && ac.getAmmoCount("Orange") > 0
                || asw.GetAmmoType() == "Yellow" && ac.getAmmoCount("Yellow") > 0
                || asw.GetAmmoType() == "Green" && ac.getAmmoCount("Green") > 0
                || asw.GetAmmoType() == "Blue" && ac.getAmmoCount("Blue") > 0
                || asw.GetAmmoType() == "Purple" && ac.getAmmoCount("Purple") > 0)
            {
                currentPaintShooting = asw.GetAmmoType();
                ac.subAmmoCount(currentPaintShooting, 1);
                anim.SetTrigger("isAttacking");
                shooting.ShootPaint();
                canShoot = false;
                Debug.Log("Should Not be able to shoot now");

            }
        }
        if (canShoot == false)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootTimerLength)
            {
                canShoot = true;
                Debug.Log("Should be able to shoot now");
                shootTimer = 0;
            }
        }
    }
}
