using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuemanHit : MonoBehaviour
{
    AmmoSwitching ammoSwitch;
    string thisType;
    [SerializeField]
    Material white;
    EnemyMovement enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        ammoSwitch = GameObject.FindGameObjectWithTag("Manager").GetComponent<AmmoSwitching>();
        thisType = this.tag;
        enemyMovement = this.GetComponent<EnemyMovement>();
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
                Cured();
            }
            if (thisType == "OrangeHueman" && ammoSwitch.GetAmmoType() == "Blue")
            {
                Cured();
            }
            if (thisType == "YellowHueman" && ammoSwitch.GetAmmoType() == "Purple")
            {
                Cured();
            }
            if (thisType == "GreenHueman" && ammoSwitch.GetAmmoType() == "Red")
            {
                Cured();
            }
            if (thisType == "BlueHueman" && ammoSwitch.GetAmmoType() == "Orange")
            {
                Cured();
            }
            if (thisType == "PurpleHueman" && ammoSwitch.GetAmmoType() == "Yellow")
            {
                Cured();
            }
        }
    }

    private void Cured()
    {
        this.GetComponentInChildren<SkinnedMeshRenderer>().material = white;
        this.GetComponent<EnemyMovement>().enabled = false;
        enemyMovement.SetCured();
    }
}
