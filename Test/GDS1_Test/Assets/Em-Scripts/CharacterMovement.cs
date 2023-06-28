using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    Animator anim;
    float moveTimerLength = 1.0f;
    float shootTimerLength = 0.8f;
    float hitTimerLength = 1f;

    float shootTimer = 0;
    float hitTimer = 0;
    bool canShoot;
    bool canMove;
    bool canHit;
    public Shooting shooting;
    public AmmoCount ac;
    public AmmoSwitching asw;
    string currentPaintShooting;
    bool managersFound;
    Vector3 pointToLook;
    GameObject planePosition;
    //GameObject trackingSphere;
    Plane groundPlane;
    //GameObject ptl;
    bool planePositionFound;

    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed = 720f;

    AudioSource audio;
    public AudioClip shootingSound;


    void Start()
    {
        anim = GetComponent<Animator>();
        canShoot = true;
        canHit = true;
        canMove = true;
        managersFound = false;
        planePositionFound = false;
       if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 1f;
        }

        audio = GameObject.FindGameObjectWithTag("ShootingSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        if (!planePositionFound && SceneManagerBool())
        {
            planePosition = GameObject.FindGameObjectWithTag("groundPlane");
            groundPlane = new Plane(Vector3.up, planePosition.transform.position);
            planePositionFound = true;
        }

        PlayerMovementRegular();

    }


    //Player Movement in regular levels
    public void PlayerMovementRegular()
    {
        if (SceneManagerBool() && !managersFound)
        {
            ac = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoCount>();
            asw = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoSwitching>();
            managersFound = true;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");



        if (canMove)
        {
            Vector3 moveVector = new Vector3(verticalInput, 0.0f, -horizontalInput);
            moveVector.Normalize();
            transform.position += moveVector * moveSpeed * Time.deltaTime;
            if (moveVector != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveVector, Vector3.up);
                Debug.Log("Aim Rotation = " + toRotation);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("AnimSpeed", 1.0f);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        //Right click to long range attack
        if (Input.GetMouseButtonDown(1) && canShoot == true && SceneManagerBool())
        {
            if (asw.GetAmmoType() == "Red" && ac.getAmmoCount("Red") > 0
                || asw.GetAmmoType() == "Orange" && ac.getAmmoCount("Orange") > 0
                || asw.GetAmmoType() == "Yellow" && ac.getAmmoCount("Yellow") > 0
                || asw.GetAmmoType() == "Green" && ac.getAmmoCount("Green") > 0
                || asw.GetAmmoType() == "Blue" && ac.getAmmoCount("Blue") > 0
                || asw.GetAmmoType() == "Purple" && ac.getAmmoCount("Purple") > 0)
            {
                var moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
                var moveVelocity = moveInput * moveSpeed;

                Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    float opposite = Camera.main.transform.position.y - cameraRay.GetPoint(rayLength).y;
                    Vector2 cam = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.z);
                    Vector2 poin = new Vector2(cameraRay.GetPoint(rayLength).x, cameraRay.GetPoint(rayLength).z);
                    float adjacent = Vector2.Distance(cam, poin);
                    float ratio = opposite / 0.1518f;
                    float hypoternuse = rayLength / ratio;
                    float aimingPoint = rayLength - hypoternuse;
                    pointToLook = cameraRay.GetPoint(aimingPoint);
                    transform.LookAt(new Vector3(pointToLook.x, pointToLook.y, pointToLook.z));

                    //Debugging Aiming
                    /*
                    Debug.Log("cam = " + cam + "    poin = " + poin);
                    Debug.Log("<color=red>Ratio: </color>" + ratio);
                    Debug.Log("<color=green>Hypoternuse: </color>" + hypoternuse);
                    Debug.Log("<color=blue>Point to Look: </color>" + pointToLook);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);
                    Debug.Log("<color=blue>Tracking Sphere: </color>" + cameraRay.GetPoint(rayLength));

                    //Aiming Testing
                    ptl.transform.position = pointToLook;
                    */
                }

                audio.clip = shootingSound;
                audio.Play();
                currentPaintShooting = asw.GetAmmoType();
                ac.subAmmoCount(currentPaintShooting, 1);
                anim.ResetTrigger("isAttacking");
                anim.SetTrigger("isAttacking");
                shooting.ShootPaint(new Vector3(pointToLook.x, pointToLook.y, pointToLook.z));
                canShoot = false;
               // canMove = false; //Jes changed so that player can move when shooting
                Debug.Log("Should Not be able to shoot now");
            }
        }

        //left click melee attack
        if (Input.GetMouseButtonDown(0) && canHit == true && SceneManagerBool())
        {
            if (asw.GetAmmoType() == "Red" && ac.getAmmoCount("Red") > 0
                || asw.GetAmmoType() == "Orange" && ac.getAmmoCount("Orange") > 0
                || asw.GetAmmoType() == "Yellow" && ac.getAmmoCount("Yellow") > 0
                || asw.GetAmmoType() == "Green" && ac.getAmmoCount("Green") > 0
                || asw.GetAmmoType() == "Blue" && ac.getAmmoCount("Blue") > 0
                || asw.GetAmmoType() == "Purple" && ac.getAmmoCount("Purple") > 0)
            {
                var moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
                var moveVelocity = moveInput * moveSpeed;

                Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    float opposite = Camera.main.transform.position.y - cameraRay.GetPoint(rayLength).y;
                    Vector2 cam = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.z);
                    Vector2 poin = new Vector2(cameraRay.GetPoint(rayLength).x, cameraRay.GetPoint(rayLength).z);
                    float adjacent = Vector2.Distance(cam, poin);

                    float ratio = opposite / 0.1518f;
                    float hypoternuse = rayLength / ratio;
                    float aimingPoint = rayLength - hypoternuse;
                    pointToLook = cameraRay.GetPoint(aimingPoint);

                    //Debugging Aiming
                    /*
                    Debug.Log("cam = " + cam + "    poin = " + poin);
                    Debug.Log("<color=red>Ratio: </color>" + ratio);
                    Debug.Log("<color=green>Hypoternuse: </color>" + hypoternuse);
                    Debug.Log("<color=blue>Point to Look: </color>" + pointToLook);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

                    //Aiming Testing
                    ptl.transform.position = pointToLook;
                    */

                    transform.LookAt(new Vector3(pointToLook.x, pointToLook.y, pointToLook.z));

                }
                audio.clip = shootingSound;
                audio.Play();
                currentPaintShooting = asw.GetAmmoType();
                ac.subAmmoCount(currentPaintShooting, 1);
                anim.ResetTrigger("isMeleeAttacking");
                anim.SetTrigger("isMeleeAttacking");
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
            if (shootTimer >= moveTimerLength && !canShoot)
            {
                canMove = true;
                Debug.Log("Should be able to move now");
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
    }


    //Player Movement When Testing
    public bool IsHitting()
    {
        return canHit;
    }

    public bool SceneManagerBool()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0)
            && SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(1)
            && SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
