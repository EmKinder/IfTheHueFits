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
    EnemyMovement enemyMovement;
    bool managersFound;
    //  EnemyCounter enemyCounter;
    GameObject player;
    public Animator anim;
    OutsideWorkshopTrigger outsideWorkshop;
    // Start is called before the first frame update

    //CHARACTER MESH 
    //general
    public Material bodyMat;
    public Material clothesMat;
    public SkinnedMeshRenderer[] bodyArray;
    public SkinnedMeshRenderer[] clothesArray;
    //kahlo 
    public Material flowerMat;
    public Material hairMat;
    public SkinnedMeshRenderer[] flowerArray;
    public SkinnedMeshRenderer[] hairArray;
    //dali
    public Material innerClothesMat;
    public Material outerClothesMat;
    public SkinnedMeshRenderer[] innerClothesArray;
    public SkinnedMeshRenderer[] outerClothesArray;

    AudioSource audio;
    public AudioClip cured;



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
        outsideWorkshop = GameObject.FindGameObjectWithTag("finish").GetComponent<OutsideWorkshopTrigger>();
        audio = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<AudioSource>();
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
        if (other.tag == "Paintball")
        {
            if (thisType == "RedHueman" && ammoSwitch.GetAmmoType() == "Green")
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
        anim.SetTrigger("isHit");
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
        audio.clip = cured;
        audio.Play();

        if(thisType == "PurpleHueman")
        {
            for(int i = 0; i < bodyArray.Length; i++)
            {
                bodyArray[i].material = bodyMat;
            }
            for(int i = 0; i < flowerArray.Length; i++)
            {
                flowerArray[i].material = flowerMat;
            }
            for (int i = 0; i < hairArray.Length; i++)
            {
                hairArray[i].material = flowerMat;
            }
        }
        else if(thisType == "OrangeHueman")
        {
            for(int i = 0; i < bodyArray.Length; i++)
            {
                bodyArray[i].material = bodyMat;
            }
            for(int i = 0; i < innerClothesArray.Length; i++)
            {
                innerClothesArray[i].material = innerClothesMat;
            }
            for(int i = 0; i < outerClothesArray.Length; i++)
            {
                outerClothesArray[i].material = outerClothesMat;
            }
        }
        else
        {
            for(int i = 0; i < bodyArray.Length; i++)
            {
                bodyArray[i].material = bodyMat;
            }
            for(int i = 0; i < clothesArray.Length; i++)
            {
                clothesArray[i].material = clothesMat;
            }
        }

        this.GetComponent<EnemyMovement>().enabled = false;
        enemyMovement.SetCured();
        outsideWorkshop.EnemyCuredCount();
        // enemyCounter.EnemyCured();
        Destroy(this.gameObject, 2.5f);
    }
}


/*        MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material = white;
        }*/