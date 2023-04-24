using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneDoorScene : MonoBehaviour
{
    public int resource;
  //  public Scene[] scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddResourceSystem(int pickup)
    {
        resource = resource + pickup;
    }


}
