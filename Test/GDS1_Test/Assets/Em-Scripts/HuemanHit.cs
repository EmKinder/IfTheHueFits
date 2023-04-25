using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HuemanHit : MonoBehaviour
{
    AmmoSwitching ammoSwitch;
    string thisType;
    [SerializeField]
    Material white;
    EnemyMovement enemyMovement;
    bool managersFound;
    EnemyCounter enemyCounter;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        managersFound = false;
        thisType = this.tag;
        enemyMovement = this.GetComponent<EnemyMovement>();
        enemyCounter = GameObject.FindGameObjectWithTag("EnemyCounter").GetComponent<EnemyCounter>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0) && !managersFound)
        {
            ammoSwitch = GameObject.FindGameObjectWithTag("AmmoManager").GetComponent<AmmoSwitching>();
            managersFound = true;
        }
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
                Debug.Log("OrangeHuemanHit");
            }
            if (thisType == "YellowHueman" && ammoSwitch.GetAmmoType() == "Purple")
            {
                Cured();
                Debug.Log("YellownHuemanHit");
            }
            if (thisType == "GreenHueman" && ammoSwitch.GetAmmoType() == "Red")
            {
                Cured();
                Debug.Log("GreenHuemanHit");
            }
            if (thisType == "BlueHueman" && ammoSwitch.GetAmmoType() == "Orange")
            {
                Cured();
            }
            if (thisType == "PurpleHueman" && ammoSwitch.GetAmmoType() == "Yellow")
            {
                Cured();
            }
            Destroy(other.gameObject);
        }
        if (player.gameObject.GetComponent<CharacterMovement>().IsHitting() == false)
        {
            if (other.tag == "PlayerAttackPoint")
                {
                if (thisType == "RedHueman" && ammoSwitch.GetAmmoType() == "Green")
                {
                    Cured();


                }
                if (thisType == "OrangeHueman" && ammoSwitch.GetAmmoType() == "Blue")
                {
                    Cured();
                    Debug.Log("OrangeHuemanHit");
                }
                if (thisType == "YellowHueman" && ammoSwitch.GetAmmoType() == "Purple")
                {
                    Cured();
                    Debug.Log("YellownHuemanHit");
                }
                if (thisType == "GreenHueman" && ammoSwitch.GetAmmoType() == "Red")
                {
                    Cured();
                    Debug.Log("GreenHuemanHit");
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
    }

    private void Cured()
    {
        this.GetComponentInChildren<SkinnedMeshRenderer>().material = white;
        this.GetComponent<EnemyMovement>().enabled = false;
        enemyMovement.SetCured();
        enemyCounter.EnemyCured();
        Destroy(this.gameObject);
    }
}
