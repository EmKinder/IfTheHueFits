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
    float hitTimerLength = 1f;

    float shootTimer = 0;
    float hitTimer = 0;
    bool canShoot;
    bool canHit;
    public Shooting shooting;
    public AmmoCount ac;
    public AmmoSwitching asw;
    string currentPaintShooting;
    bool managersFound;

    public float attackRange = 0.5f;


    void Start()
    {
        anim = GetComponent<Animator>();
        canShoot = true;
        canHit = true;
        managersFound = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0) && !managersFound)
        {
            ac = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoCount>();
            asw = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoSwitching>();
            managersFound = true;
        }

        float trans = Input.GetAxis("Vertical") * walkSpeed;
        trans *= Time.deltaTime;
        transform.Translate(0, 0, trans);
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


        //Right click to long range attack
        if (Input.GetMouseButtonDown(1) && canShoot == true && SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
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

            //left click melee attack
            if (Input.GetMouseButtonDown(0) && canHit == true && SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
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
                    anim.SetTrigger("isMeleeAttacking");
                    //shooting.ShootPaint();
                    canHit = false;
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
        if (canHit == false)
        {
            hitTimer += Time.deltaTime;
            if (hitTimer >= hitTimerLength)
            {
                canHit = true;
                Debug.Log("Should be able to hit now");
                hitTimer = 0;
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

    public bool IsHitting()
    {
        return canHit;
    }

    
}
