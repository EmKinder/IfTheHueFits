using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public GameObject paintball;
    public Transform paintPos;
    public InventoryManager inventory;
    AmmoCount ammoCount;
    bool managersFound;
   


    // Start is called before the first frame update
    void Start()
    {
        managersFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) && !managersFound)
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
            managersFound = true;
        }
    }

    IEnumerator CanShootPaint()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject paintballClone = Instantiate(paintball, paintPos.position + 1.0f * transform.forward, transform.rotation);
        Destroy(paintballClone, 2);
    }

    public void ShootPaint()
    {
      //  inventory.selectedItem.Use(this);
        //  Instantiate(paintball, transform.position, Quaternion.identity);
        //  paintball.transform.forward = transform.forward;
        StartCoroutine(CanShootPaint());
        
    }
}
