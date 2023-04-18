using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
   public ManagingSceneChanges scene;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BackButton()
    {
        scene.GoBackToCrafting();
    }

   public void Level1Button()
    {
    //    scene.FirstLevelLoad();
    

    }

    public void Level2Button()
    {
         scene.SecondLevelLoad();
       
    }

    public void Level3Button()
    {
        scene.ThirdLevelLoad();
    }
    
    public void Level4Button()
    {
        scene.ForthLevelLoad();
    }

    public void Level5Button()
    {
        scene.FifthLevelLoad();
    }

    public void Level6Button()
    {
        scene.SixthLevelLoad();
    }

}
