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

    IEnumerator CanShootPaint(Vector3 aimPoint)
    {
        yield return new WaitForSeconds(0.5f);
        Transform aim = transform;
        aim.Rotate(new Vector3(0f, 2f, 0f));
        GameObject paintballClone = Instantiate(paintball, paintPos.position, aim.rotation);
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
