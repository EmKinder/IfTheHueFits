using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    float walkSpeed = 6.0f;
    float rotationSpeed = 300.0f;
    Animator anim;
    float shootTimerLength = 1.5f;
    float shootTimer = 0;
    bool canShoot;
    public Shooting shooting;
    public AmmoCount ac;
    public AmmoSwitching asw;
    string currentPaintShooting;
    bool managersFound;


    void Start()
    {
        anim = GetComponent<Animator>();
        canShoot = true;
        managersFound = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) && !managersFound)
        {
            ac = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoCount>();
            asw = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoSwitching>();
            managersFound = true;
        }

        float trans = Input.GetAxis("Vertical") * walkSpeed;
        trans *= Time.deltaTime;
          transform.Translate(0, 0, trans);
        //rb.MovePosition(rb.gameObject.transform.forward * walkSpeed);
    


    //    float rot = Input.GetAxis("Horizontal") * rotationSpeed;
   //     rot *= Time.deltaTime;
 //       transform.Rotate(0, rot, 0);
        

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



        if (Input.GetMouseButtonDown(0) && canShoot == true && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
         //   ) { 
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
              //  }
            }
        }

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
