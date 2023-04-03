using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuemanHit : MonoBehaviour
{
    AmmoSwitching ammoSwitch;
    string thisType;
    // Start is called before the first frame update
    void Start()
    {
        ammoSwitch = GameObject.FindGameObjectWithTag("Manager").GetComponent<AmmoSwitching>();
        thisType = this.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Paintball")
        {
            if(thisType == "RedHueman" && ammoSwitch.GetAmmoType() == "Green")
            {
                Destroy(this.gameObject);
            }
            if (thisType == "OrangeHueman" && ammoSwitch.GetAmmoType() == "Blue")
            {
                Destroy(this.gameObject);
            }
            if (thisType == "YellowHueman" && ammoSwitch.GetAmmoType() == "Purple")
            {
                Destroy(this.gameObject);
            }
            if (thisType == "GreenHueman" && ammoSwitch.GetAmmoType() == "Red")
            {
                Destroy(this.gameObject);
            }
            if (thisType == "BlueHueman" && ammoSwitch.GetAmmoType() == "Orange")
            {
                Destroy(this.gameObject);
            }
            if (thisType == "PurpleHueman" && ammoSwitch.GetAmmoType() == "Yellow")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
