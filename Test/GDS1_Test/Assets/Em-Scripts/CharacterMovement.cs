using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    Animator anim;
    float shootTimerLength = 1f;
    float hitTimerLength = 0.5f;

    float shootTimer = 0;
    float hitTimer = 0;
    bool canShoot;
    bool canHit;
    public Shooting shooting;
    public AmmoCount ac;
    public AmmoSwitching asw;
    string currentPaintShooting;
    bool managersFound;
    public bool testing;
    Vector3 pointToLook;

    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed = 720f;


    void Start()
    {
        anim = GetComponent<Animator>();
        canShoot = true;
        canHit = true;
        managersFound = false;
       if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 1f;
        }


       //For Disabling Inventory Manager requirments
       if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(14))
        {
            testing = true;
        }
       else
        {
            testing = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        //For when not testing, normal player Movement
        // - testing variable in player movement set for true (Testing) or false (Game scenes)
        if (!testing)
        {
            PlayerMovementRegular();
        }

        //Script For Bugtesting in seperate scene
        // - removes the need for inventory managers and gives 100 ammo each type
        else
        {
            PlayerMovementTesting();
        }

    }


    //Player Movement in regular levels
    public void PlayerMovementRegular()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0) && !managersFound)
        {
            ac = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoCount>();
            asw = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoSwitching>();
            managersFound = true;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        if (canHit && canShoot)
        {
            Vector3 moveVector = new Vector3(verticalInput, 0.0f, -horizontalInput);
            moveVector.Normalize();
            transform.position += moveVector * moveSpeed * Time.deltaTime;
            if (moveVector != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveVector, Vector3.up);
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
        if (Input.GetMouseButtonDown(1) && canShoot == true && SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
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
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    float hypoternuse = 0.1518f / Mathf.Sin(Camera.main.transform.rotation.eulerAngles.x);
                    pointToLook = cameraRay.GetPoint(rayLength - hypoternuse);
                    pointToLook = cameraRay.GetPoint(rayLength);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

                    transform.LookAt(new Vector3(pointToLook.x, 0.1518f, pointToLook.z));
                }

                currentPaintShooting = asw.GetAmmoType();
                ac.subAmmoCount(currentPaintShooting, 1);
                anim.ResetTrigger("isAttacking");
                anim.SetTrigger("isAttacking");
                shooting.ShootPaint(new Vector3(pointToLook.x, pointToLook.y, pointToLook.z));
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
                var moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
                var moveVelocity = moveInput * moveSpeed;

                Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    float hypoternuse = 0.1518f / Mathf.Sin(Camera.main.transform.rotation.eulerAngles.x);
                    pointToLook = cameraRay.GetPoint(rayLength - hypoternuse);
                    pointToLook = cameraRay.GetPoint(rayLength);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

                    transform.LookAt(new Vector3(pointToLook.x, 0.1518f, pointToLook.z));
                }

                currentPaintShooting = asw.GetAmmoType();
                ac.subAmmoCount(currentPaintShooting, 1);
                anim.ResetTrigger("isAttacking");
                anim.SetTrigger("isAttacking");
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
    }


    //Player Movement When Testing
    public void PlayerMovementTesting()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0) && !managersFound)
        {
            ac = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoCount>();
            asw = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoSwitching>();
            managersFound = true;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        if (canHit && canShoot)
        {
            Vector3 moveVector = new Vector3(verticalInput, 0.0f, -horizontalInput);
            moveVector.Normalize();
            transform.position += moveVector * moveSpeed * Time.deltaTime;
            if (moveVector != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveVector, Vector3.up);
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
        if (Input.GetMouseButtonDown(1) && canShoot == true && SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
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
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    //float hypoternuse = 0.1518f / Mathf.Sin(Camera.main.transform.rotation.eulerAngles.x);
                    //pointToLook = cameraRay.GetPoint(rayLength - hypoternuse);
                    pointToLook = cameraRay.GetPoint(rayLength);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

                    transform.LookAt(new Vector3(pointToLook.x, 0.1518f, pointToLook.z));
                }

                anim.ResetTrigger("isAttacking");
                anim.SetTrigger("isAttacking");
                shooting.ShootPaint(new Vector3(pointToLook.x, 0.1518f, pointToLook.z));
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
                var moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
                var moveVelocity = moveInput * moveSpeed;

                Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    //float hypoternuse = 0.1518f / Mathf.Sin(Camera.main.transform.rotation.eulerAngles.x);
                    //pointToLook = cameraRay.GetPoint(rayLength - hypoternuse);
                    pointToLook = cameraRay.GetPoint(rayLength);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

                    transform.LookAt(new Vector3(pointToLook.x, 0.1518f, pointToLook.z));
                }

                currentPaintShooting = asw.GetAmmoType();
                anim.ResetTrigger("isAttacking");
                anim.SetTrigger("isAttacking");
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
    }


    public bool IsHitting()
    {
        return canHit;
    }
}
