using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public GameObject paintball;
    public Transform paintPos;
    public NEWInventoryManager inventory; //is this necessary???
    AmmoCount ammoCount;
    bool managersFound;
    [SerializeField] AudioClip shootingSound;
    AudioSource audioS;
   


    // Start is called before the first frame update
    void Start()
    {
        managersFound = false;
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<NEWInventoryManager>();
        audioS = GameObject.FindGameObjectWithTag("ShootingSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) && !managersFound)
        {
            inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<NEWInventoryManager>();
            managersFound = true;
        }
    }

    IEnumerator CanShootPaint(Vector3 aimPoint)
    {
        yield return new WaitForSeconds(0.75f);
        Transform aim = transform;
        aim.Rotate(new Vector3(0f, 2f, 0f));
        GameObject paintballClone = Instantiate(paintball, paintPos.position, aim.rotation);
        audioS.clip = shootingSound;
        audioS.Play();
        Destroy(paintballClone, 1.5f);
    }

    public void ShootPaint(Vector3 aimPoint)
    {
      //  inventory.selectedItem.Use(this);
        //  Instantiate(paintball, transform.position, Quaternion.identity);
        //  paintball.transform.forward = transform.forward;
        StartCoroutine(CanShootPaint(aimPoint));

        
    }
}
