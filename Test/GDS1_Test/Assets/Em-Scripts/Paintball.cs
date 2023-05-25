using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour
{
    Rigidbody rb;
    public float force = 0.000005f;
    AmmoSwitching ammoSwitch;
    public Material red;
    public Material orange;
    public Material yellow;
    public Material green;
    public Material blue;
    public Material purple;
    public InventoryManager inventory;
    //bool managerFound;

    // Start is called before the first frame update
    void Start()
    {
        ammoSwitch = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoSwitching>();


        if (ammoSwitch.GetAmmoType() == "Red")
        {
            this.GetComponent<MeshRenderer>().material = red;
        }
        if (ammoSwitch.GetAmmoType() == "Orange")
        {
            this.GetComponent<MeshRenderer>().material = orange;
        }
        if (ammoSwitch.GetAmmoType() == "Yellow")
        {
            this.GetComponent<MeshRenderer>().material = yellow;
        }
        if (ammoSwitch.GetAmmoType() == "Green")
        {
            this.GetComponent<MeshRenderer>().material = green;
        }
        if (ammoSwitch.GetAmmoType() == "Blue")
        {
            this.GetComponent<MeshRenderer>().material = blue;
        }
        if (ammoSwitch.GetAmmoType() == "Purple")
        {
            this.GetComponent<MeshRenderer>().material = purple;
        }

        /*   Material newMaterial = Resources.Load<Material>("Materials/" + ammoSwitch.GetAmmoType() + ".mat");
           Debug.Log("Materials/" + ammoSwitch.GetAmmoType()+".mat");
           this.GetComponent<MeshRenderer>().material = newMaterial;
           Debug.Log(newMaterial);*/

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
