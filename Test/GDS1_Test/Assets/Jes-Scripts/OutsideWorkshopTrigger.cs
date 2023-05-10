using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideWorkshopTrigger : MonoBehaviour
{
    public Canvas winscene;
    // Start is called before the first frame update
    void Start()
    {
        winscene.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            winscene.enabled = true;
        }
    }
}
