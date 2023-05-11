using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HuemanHit : MonoBehaviour
{
    AmmoSwitching ammoSwitch;
    string thisType;
    float meleeDamage;
    float paintballDamage;
    [SerializeField]
    Material white;
    EnemyMovement enemyMovement;
    bool managersFound;
  //  EnemyCounter enemyCounter;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        managersFound = false;
        thisType = this.tag;
        meleeDamage = 10.0f;
        paintballDamage = 5.0f;
        enemyMovement = this.GetComponent<EnemyMovement>();
     //   if (enemyCounter == null)
      //  {
      //      enemyCounter = GameObject.FindGameObjectWithTag("EnemyCounter").GetComponent<EnemyCounter>();
      //  }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
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
                EnemyHit(paintballDamage);
                Debug.Log("RedHuemanHitPaintball");
            }
            if (thisType == "OrangeHueman" && ammoSwitch.GetAmmoType() == "Blue")
            {
                EnemyHit(paintballDamage);
                Debug.Log("OrangeHuemanHitPaintball");
            }
            if (thisType == "YellowHueman" && ammoSwitch.GetAmmoType() == "Purple")
            {
                EnemyHit(paintballDamage);
                Debug.Log("YellownHuemanHitPaintball");
            }
            if (thisType == "GreenHueman" && ammoSwitch.GetAmmoType() == "Red")
            {
                EnemyHit(paintballDamage);
                Debug.Log("GreenHuemanHitPaintball");
            }
            if (thisType == "BlueHueman" && ammoSwitch.GetAmmoType() == "Orange")
            {
                EnemyHit(paintballDamage);
                Debug.Log("BlueHuemanHitPaintball");
            }
            if (thisType == "PurpleHueman" && ammoSwitch.GetAmmoType() == "Yellow")
            {
                EnemyHit(paintballDamage);
                Debug.Log("PurpleHuemanHitPaintball");
            }
            Destroy(other.gameObject);
        }
        if (player.gameObject.GetComponent<CharacterMovement>().IsHitting() == false)
        {
            if (other.tag == "PlayerAttackPoint")
                {
                if (thisType == "RedHueman" && ammoSwitch.GetAmmoType() == "Green")
                {
                    EnemyHit(meleeDamage);
                    Debug.Log("RedHuemanHitMelee");

                }
                if (thisType == "OrangeHueman" && ammoSwitch.GetAmmoType() == "Blue")
                {
                    EnemyHit(meleeDamage);
                    Debug.Log("OrangeHuemanHitMelee");
                }
                if (thisType == "YellowHueman" && ammoSwitch.GetAmmoType() == "Purple")
                {
                    EnemyHit(meleeDamage);
                    Debug.Log("YellownHuemanHitMelee");
                }
                if (thisType == "GreenHueman" && ammoSwitch.GetAmmoType() == "Red")
                {
                    EnemyHit(meleeDamage);
                    Debug.Log("GreenHuemanHitMelee");
                }
                if (thisType == "BlueHueman" && ammoSwitch.GetAmmoType() == "Orange")
                {
                    EnemyHit(meleeDamage);
                    Debug.Log("BlueHuemanHitMelee");
                }
                if (thisType == "PurpleHueman" && ammoSwitch.GetAmmoType() == "Yellow")
                {
                    EnemyHit(meleeDamage);
                    Debug.Log("PurpleHuemanHitMelee");
                }
            }
        }
    }

    private void EnemyHit(float damage)
    {
        bool enemHit = this.GetComponent<EnemyMovement>().EnemyHealth(damage);
        if (!enemHit)
        {
            Debug.Log("Hit, should be dead Dead");
            Cured();
        }
        else
        {
            Debug.Log("Hit, not Dead");
        }
    }

    private void Cured()
    {
        enemyMovement.healthBar.fillAmount = 0.0f;
        //this.GetComponentInChildren<SkinnedMeshRenderer>().material = white;
        MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material = white;
        }
        this.GetComponent<EnemyMovement>().enabled = false;
        enemyMovement.SetCured();
       // enemyCounter.EnemyCured();
        Destroy(this.gameObject, 2.5f);
    }
}
